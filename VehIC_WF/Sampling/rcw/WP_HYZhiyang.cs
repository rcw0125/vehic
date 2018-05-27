using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zhc.Data;
using VehIC_WF.Class;
using System.Drawing.Drawing2D;
using Xg.Lab.Sample;
using Xg.Lab.Sample.View;
using  VehIC_WF.Sampling.czl.Class;
using System.Text.RegularExpressions;
using DevExpress.XtraTab;
using VehIC_WF.Sampling;

namespace VehIC_WF.WorkPoint
{
    public partial class WP_HYZhiyang : UserControl, ICardMessage
    {
        public WP_HYZhiyang()
        {
            InitializeComponent();
        }

        private QC_SampleMix_ZhiYang_Table zyMixSamples = new QC_SampleMix_ZhiYang_Table();

        private QC_Sample_Lab curSelLab = null;

        private DbEntityTable<QC_Sample_Lab> labTable = new DbEntityTable<QC_Sample_Lab>();

        /// <summary>
        /// 窗体加载
        /// </summary>
        string workpointCode = "0099";
       // string workpointCode = "0084";
        private void WP_Zhiyangdan_Load(object sender, EventArgs e)
        {
            zyMixSamples.LoadZyAllData(workpointCode);
            this.qCSampleMixZhiYangBindingSource.DataSource = zyMixSamples;
            this.qCSampleLabBindingSource1.DataSource = labTable;
            LabTabs();
            initDanHao();

        }

        public void initDanHao()
        {
            comboBox1.Text = "";
            hymixs.LoadDataByWhere("main.samplestate = @samplestate and main.wllx=@wllx and main.cardid='' and main.matpk in (SELECT   MATNCID  FROM  QC_Material WHERE WLLX <> '煤') ", Xg.Lab.Sample.SampleState.组批完成, "火运");
            comboBox1.Items.Clear();
            foreach (var item in hymixs)
            {
                comboBox1.Items.Add(QC_Sample_Mix.ShortStoreCode(item.StoreCode));

            }
        }

        void LabTabs()
        {
            QC_SampleMix_ZhiYang_Table zyMix = new QC_SampleMix_ZhiYang_Table();
            zyMix.LoadDataByWhere("SampleState=@SampleState and Mix_time>=@mixtime", 2, DateTime.Today);
         //   label4.Text = zyMix.Count.ToString();
            List<string> tabs = new List<string>();
            foreach (var item in zyMixSamples.LabTable)
            {
                if ((item.CheckGroupType == "立刻检验" || item.CheckGroupType == "后续检验"))
                {
                    if (!tabs.Contains(item.CheckGroupName))
                    {
                        tabs.Add(item.CheckGroupName);
                    }
                }
            }

            List<string> tabs2 = new List<string>();
            foreach (XtraTabPage tabPage in xtraTabControl1.TabPages)
            {
                tabs2.Add(tabPage.Text);
            }

            bool xiangdeng = false;
            tabs.Sort();
            tabs2.Sort();
            if (tabs.Count == tabs2.Count)
            {
                xiangdeng = true;
                for (int i = 0; i < tabs.Count; i++)
                {
                    if (tabs[i] != tabs2[i])
                    {
                        xiangdeng = false;
                        break;
                    }
                }
            }

            if (!xiangdeng)
            {
                int oldIdx = xtraTabControl1.SelectedTabPageIndex;
                xtraTabControl1.TabPages.Clear();
                foreach (var item in tabs)
                {
                    xtraTabControl1.TabPages.Add(item);
                }
                int selIdx = 0;
                if (oldIdx >= 0 && oldIdx < xtraTabControl1.TabPages.Count)
                {
                    selIdx = oldIdx;
                }
                xtraTabControl1.SelectedTabPageIndex = selIdx;

            }

            labTable.Empty();
            if (xtraTabControl1.SelectedTabPage != null)
            {
                foreach (var item in zyMixSamples.LabTable)
                {
                    if (item.CheckGroupName == xtraTabControl1.SelectedTabPage.Text)
                    {
                        labTable.Add(item);
                    }
                }
                if (labTable.Count > 0)
                {
                    this.gridView3.FocusedRowHandle = 0;
                }
            }

        }

        /// <summary>
        /// 刷新
        /// </summary>
          DbEntityTable<QC_Sample_Mix> hymixs = new DbEntityTable<QC_Sample_Mix>();
        private void btnRefresh_Click(object sender, EventArgs e)
        {


            initDanHao();
            zyMixSamples.LoadZyAllData(workpointCode);
            LabTabs();
        }

        /// <summary>
        /// 刷卡
        /// </summary>
        public void HandleCardMessage(Device.CardReader device, string cardId)
        {
            QC_IC_Info icCard = QC_IC_Info.FindByCardId(cardId);
            if (icCard == null)
            {
                MessageBox.Show("此卡未注册");
                return;
            }
            if (icCard.CardType == QC_IC_Info.CardUseType_Mix)
            {
                if (icCard.SampleId <= 0)
                {
                    MessageBox.Show("此卡没有业务信息");
                    return;
                }

                QC_SampleMix_ZhiYang zySample = QC_SampleMix_ZhiYang.GetById(icCard.SampleId);
                if (zySample == null)
                {
                    MessageBox.Show("找不到单据");
                    return;
                }

                if (zySample.SampleState < SampleState.组批完成)
                {
                    MessageBox.Show("磁卡所对大桶还未组批完成");
                    return;
                }
                if (zySample.WLLX != "火运")
                {
                    MessageBox.Show("物料不是火运请选择其他制样点");
                    return;

                }
                zySample.ZyDanHao = zySample.MatClassWord + DbContext.GetSeq(DateTime.Now.Date.ToString("yyyyMMdd"), 2);
                zySample.SampleState = SampleState.开始制样;
                zySample.ZyWpCode = workpointCode;
                zySample.ZyRecvUser = LocalInfo.Current.user.ID;
                zySample.ZyRecvTime = DateTime.Now;
                if (zySample.SampleType == SampleType.人工取样|| zySample.SampleType == SampleType.机器取样)
                {
                    DbEntityTable<QC_MatAllCheckItem> bjCheckItem = new DbEntityTable<QC_MatAllCheckItem>();
                    bjCheckItem.LoadDataByWhere("MATNCID=@MATNCID and JYLX='必检'", zySample.MatPK);
                    foreach (var stdCheckItem in bjCheckItem)
                    {
                        QC_MixCheckItem ckItem = zySample.CheckItems.FirstOrDefault<QC_MixCheckItem>((ck) => ck.CheckItemNcId == stdCheckItem.CheckItemNcId);
                        if (ckItem == null)
                        {
                            QC_MixCheckItem item = new QC_MixCheckItem();
                            item.CheckItemNcId = stdCheckItem.CheckItemNcId;
                            item.CheckItemCode = stdCheckItem.CheckItemCode;
                            item.CheckItemName = stdCheckItem.CheckItemName;
                            item.CheckItemUnit = stdCheckItem.CheckItemUnit;
                            item.CheckGroupCode = stdCheckItem.CheckGroupCode;
                            item.CheckGroupName = stdCheckItem.CheckGroupName;
                            item.CheckGroupType = stdCheckItem.CheckGroupType;
                            item.CkgShortWord = stdCheckItem.CkgShortWord;
                            item.Sample_Mix_ID = item.Sample_Mix_ID;
                            item.CheckGroupVisIdx = stdCheckItem.CheckGroupVisIdx;
                            item.Source = "检验标准-必检";
                            zySample.CheckItems.Add(item);
                        }
                    }
                    DbEntityTable<QC_MatAllCheckItem> myCheckItem = new DbEntityTable<QC_MatAllCheckItem>();
                    myCheckItem.LoadDataByWhere("MATNCID=@MATNCID and JYLX='每月'", zySample.MatPK);

                    DateTime yue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                    foreach (var stdCheckItem in myCheckItem)
                    {
                        object cntObj = DbContext.ExecuteScalar("SELECT count(*)  FROM  QC_MixCheckItem mck  inner join qc_sample_mix mix on mix.SAMPLE_MIX_ID=mck.SAMPLE_MIX_ID  where mix.Mix_Time>=@MixTime and mix.SampleType=" + (int)SampleType.普通样 + " and mix.SupplierCode=@SupplierCode and mix.MatPK=@MatPK and mck.CheckItemNcId=@CheckItemNcId", yue, zySample.SupplierCode, zySample.MatPK, stdCheckItem.CheckItemNcId);
                        if (cntObj != null)
                        {
                            int cnt = Convert.ToInt32(cntObj);
                            if (cnt == 0)
                            {
                                QC_MixCheckItem ckItem = zySample.CheckItems.FirstOrDefault<QC_MixCheckItem>((ck) => ck.CheckItemNcId == stdCheckItem.CheckItemNcId);
                                if (ckItem == null)
                                {
                                    QC_MixCheckItem item = new QC_MixCheckItem();
                                    item.CheckItemNcId = stdCheckItem.CheckItemNcId;
                                    item.CheckItemCode = stdCheckItem.CheckItemCode;
                                    item.CheckItemName = stdCheckItem.CheckItemName;
                                    item.CheckItemUnit = stdCheckItem.CheckItemUnit;
                                    item.CheckGroupCode = stdCheckItem.CheckGroupCode;
                                    item.CheckGroupName = stdCheckItem.CheckGroupName;
                                    item.CheckGroupType = stdCheckItem.CheckGroupType;
                                    item.CkgShortWord = stdCheckItem.CkgShortWord;
                                    item.Sample_Mix_ID = item.Sample_Mix_ID;
                                    item.CheckGroupVisIdx = stdCheckItem.CheckGroupVisIdx;
                                    item.Source = "检验标准-每月";
                                    zySample.CheckItems.Add(item);
                                }
                            }
                        }
                    }

                    int wd2 = (int)DateTime.Now.DayOfWeek - 1;
                    if (wd2 == -1)
                    {
                        wd2 = 6;
                    }

                    DateTime zhou1 = DateTime.Today.AddDays(0 - wd2);
                    DbEntityTable<QC_MatAllCheckItem> meizhouCheckItem = new DbEntityTable<QC_MatAllCheckItem>();
                    meizhouCheckItem.LoadDataByWhere("MATNCID=@MATNCID and JYLX='每周'", zySample.MatPK);

                    foreach (var stdCheckItem in meizhouCheckItem)
                    {
                        object cntObj = DbContext.ExecuteScalar("SELECT count(*)  FROM  QC_MixCheckItem mck  inner join qc_sample_mix mix on mix.SAMPLE_MIX_ID=mck.SAMPLE_MIX_ID  where mix.Mix_Time>=@MixTime and mix.SampleType=" + (int)SampleType.普通样 + " and mix.SupplierCode=@SupplierCode and mix.MatPK=@MatPK and mck.CheckItemNcId=@CheckItemNcId", zhou1, zySample.SupplierCode, zySample.MatPK, stdCheckItem.CheckItemNcId);
                        if (cntObj != null)
                        {
                            int cnt = Convert.ToInt32(cntObj);
                            if (cnt == 0)
                            {
                                QC_MixCheckItem ckItem = zySample.CheckItems.FirstOrDefault<QC_MixCheckItem>((ck) => ck.CheckItemNcId == stdCheckItem.CheckItemNcId);
                                if (ckItem == null)
                                {
                                    QC_MixCheckItem item = new QC_MixCheckItem();
                                    item.CheckItemNcId = stdCheckItem.CheckItemNcId;
                                    item.CheckItemCode = stdCheckItem.CheckItemCode;
                                    item.CheckItemName = stdCheckItem.CheckItemName;
                                    item.CheckItemUnit = stdCheckItem.CheckItemUnit;
                                    item.CheckGroupCode = stdCheckItem.CheckGroupCode;
                                    item.CheckGroupName = stdCheckItem.CheckGroupName;
                                    item.CheckGroupType = stdCheckItem.CheckGroupType;
                                    item.CkgShortWord = stdCheckItem.CkgShortWord;
                                    item.Sample_Mix_ID = item.Sample_Mix_ID;
                                    item.CheckGroupVisIdx = stdCheckItem.CheckGroupVisIdx;
                                    item.Source = "检验标准-每周";
                                    zySample.CheckItems.Add(item);
                                }
                            }
                        }
                    }
                    DateTime tian1 = DateTime.Today;
                    DbEntityTable<QC_MatAllCheckItem> meitianCheckItem = new DbEntityTable<QC_MatAllCheckItem>();
                    meizhouCheckItem.LoadDataByWhere("MATNCID=@MATNCID and JYLX='每天'", zySample.MatPK);

                    foreach (var stdCheckItem in meizhouCheckItem)
                    {
                        object cntObj = DbContext.ExecuteScalar("SELECT count(*)  FROM  QC_MixCheckItem mck  inner join qc_sample_mix mix on mix.SAMPLE_MIX_ID=mck.SAMPLE_MIX_ID  where mix.Mix_Time>=@MixTime and mix.SampleType=" + (int)SampleType.普通样 + " and mix.SupplierCode=@SupplierCode and mix.MatPK=@MatPK and mck.CheckItemNcId=@CheckItemNcId", tian1, zySample.SupplierCode, zySample.MatPK, stdCheckItem.CheckItemNcId);
                        if (cntObj != null)
                        {
                            int cnt = Convert.ToInt32(cntObj);
                            if (cnt == 0)
                            {
                                QC_MixCheckItem ckItem = zySample.CheckItems.FirstOrDefault<QC_MixCheckItem>((ck) => ck.CheckItemNcId == stdCheckItem.CheckItemNcId);
                                if (ckItem == null)
                                {
                                    QC_MixCheckItem item = new QC_MixCheckItem();
                                    item.CheckItemNcId = stdCheckItem.CheckItemNcId;
                                    item.CheckItemCode = stdCheckItem.CheckItemCode;
                                    item.CheckItemName = stdCheckItem.CheckItemName;
                                    item.CheckItemUnit = stdCheckItem.CheckItemUnit;
                                    item.CheckGroupCode = stdCheckItem.CheckGroupCode;
                                    item.CheckGroupName = stdCheckItem.CheckGroupName;
                                    item.CheckGroupType = stdCheckItem.CheckGroupType;
                                    item.CkgShortWord = stdCheckItem.CkgShortWord;
                                    item.Sample_Mix_ID = item.Sample_Mix_ID;
                                    item.CheckGroupVisIdx = stdCheckItem.CheckGroupVisIdx;
                                    item.Source = "检验标准-每天";
                                    zySample.CheckItems.Add(item);
                                }
                            }
                        }
                    }
                   
                }
                //else if (zySample.SampleType == SampleType.校验样)
                //{
                //    //加载校验样项目
                //    QC_MixCheckItem_Table table = new QC_MixCheckItem_Table();
                //    table.LoadDataByWhere("main.SAMPLE_VEH_ID=(select SAMPLE_VEH_ID from QC_Sample_Veh veh where veh.SAMPLE_MIX_ID=@SAMPLE_MIX_ID)", zySample.Sample_Mix_ID);
                //    foreach (var item in table)
                //    {
                //        item.Sample_Mix_ID = zySample.Sample_Mix_ID;
                //        item.Source = "校验样";
                //        zySample.CheckItems.Add(item);
                //    }

                //    //DbContext.ExeSql("update t1 set t1.SAMPLE_MIX_ID =(select SAMPLE_MIX_ID from QC_Sample_Veh t2 where t2.SAMPLE_VEH_ID=t1.SAMPLE_VEH_ID) from QC_MIXCHECKITEM t1 where ISnull(t1.SAMPLE_VEH_ID,0)>0 and ISnull(t1.SAMPLE_MIX_ID,0)<=0");
                //}

                //生成样品分类
                foreach (var item in zySample.CheckItems)
                {
                    QC_MixCheckGroup mixCG = zySample.CheckGroups.FirstOrDefault<QC_MixCheckGroup>((mcg) => mcg.CheckGroupCode == item.CheckGroupCode);
                    if (mixCG == null)
                    {
                        mixCG = new QC_MixCheckGroup();
                        mixCG.CheckGroupCode = item.CheckGroupCode;
                        mixCG.CheckGroupName = item.CheckGroupName;
                        mixCG.CheckGroupType = item.CheckGroupType;
                        mixCG.CkgShortWord = item.CkgShortWord;
                        mixCG.VisIdx = item.CheckGroupVisIdx;
                        mixCG.StoreCode = zySample.ZyDanHao + item.CkgShortWord;
                        mixCG.MatPK = zySample.MatPK;
                        mixCG.SupplierCode = zySample.SupplierCode;
                        mixCG.Sample_TBZD = zySample.Sample_TBZD;
                        mixCG.Sample_Mix_ID = zySample.Sample_Mix_ID;
                        mixCG.ZySample = zySample;

                        zySample.CheckGroups.Add(mixCG);
                    }
                    mixCG.MixCheckItem.Add(item);
                }
                //加载物料设置样品分类
                DbEntityTable<QC_MatCheckGroup> MatCheckGroup = new DbEntityTable<QC_MatCheckGroup>();
                MatCheckGroup.LoadDataByWhere("MatNcId=@MatNcId", zySample.MatPK);
                for (int i = 0; i < MatCheckGroup.Count; i++)
                {
                    QC_MixCheckGroup item = new QC_MixCheckGroup();
                    item.CheckGroupCode = MatCheckGroup[i].CheckGroupCode;
                    item.CheckGroupName = MatCheckGroup[i].CheckGroupName;
                    item.CheckGroupType = MatCheckGroup[i].CheckGroupType;
                    item.CkgShortWord = MatCheckGroup[i].ShortWord;
                    item.VisIdx = MatCheckGroup[i].CheckGroupVisIdx;
                    item.StoreCode = zySample.ZyDanHao + MatCheckGroup[i].ShortWord;
                    item.MatPK = zySample.MatPK;
                    item.SupplierCode = zySample.SupplierCode;
                    item.Sample_TBZD = zySample.Sample_TBZD;
                    item.Sample_Mix_ID = zySample.Sample_Mix_ID;
                    item.ZySample = zySample;
                    zySample.CheckGroups.Add(item);
                }

                zySample.CheckGroups.Sort((tx, ty) => tx.VisIdx.CompareTo(ty.VisIdx));
                foreach (var item in zySample.CheckGroups)
                {
                    item.MatPK = zySample.MatPK;
                    item.SupplierCode = zySample.SupplierCode;
                    item.Sample_TBZD = zySample.Sample_TBZD;
                    item.ZySample = zySample;
                    item.Billtype = "未绑定样品扣";
                    item.LabState = "制样";
                }
                IDbConnection conn = DbContext.GetDefaultConnection();
                conn.Open();
                IDbTransaction trans = conn.BeginTransaction();
                         
                icCard.SampleId = 0;
                zySample.SaveCheckGroups = true;
                zySample.SaveCheckItems = true;
                zySample.Save(trans);
                icCard.Save(trans);

                //生成Lab
                foreach (var ckg in zySample.CheckGroups)
                {
                    if (!ckg.CheckGroupName.Contains("角质层") && (ckg.CheckGroupType == "立刻检验" || ckg.CheckGroupType == "后续检验"))
                    {
                        QC_Sample_Lab lb = new QC_Sample_Lab();
                        lb.MixCheckGroup.Add(ckg);
                        lb.StoreCode = ckg.StoreCode;
                        lb.WpCode = workpointCode;
                        lb.Billtype = "未绑定样品扣";
                        lb.LabState = "制样";
                        lb.WLLX = zySample.WLLX;
                        lb.CheckGroupCode = ckg.CheckGroupCode;
                        lb.CheckGroupName = ckg.CheckGroupName;
                        lb.CheckGroupType = ckg.CheckGroupType;
                        lb.Sample_Mix_ID = ckg.Sample_Mix_ID;
                        foreach (var ck in ckg.MixCheckItem)
                        {
                            QC_Sample_Value qcVal = new QC_Sample_Value();
                            qcVal.CheckItemNcId = ck.CheckItemNcId;
                            qcVal.CheckItemCode = ck.CheckItemCode;
                            qcVal.CheckItemName = ck.CheckItemName;
                            qcVal.ActualVal = ck.ActualVal;
                            lb.CheckVals.Add(qcVal);
                        }
                        lb.SaveCheckVals = true;
                        zyMixSamples.LabTable.Add(lb);
                    }
                }
                zyMixSamples.LabTable.Save(trans);

                trans.Commit();
                conn.Close();

                zyMixSamples.Add(zySample);

                lblRecvDanHao.Text = zySample.ZyShortDanHao;
                this.gridView1.FocusedRowHandle = this.gridView1.GetRowHandle(zyMixSamples.Count - 1);
                LabTabs();
                this.printDocument1.Print();
            }
            else if (icCard.CardType.StartsWith("CUT_"))
            {
                if (icCard.SampleId > 0)
                {
                    MessageBox.Show("此卡已绑定信息");
                    return;
                }
                if (curSelLab == null)
                {
                    MessageBox.Show("请先查询样品单号");
                    return;
                }
                if (curSelLab.CheckGroupType != "后续检验")
                {
                    MessageBox.Show("此样品单号不需要绑定磁卡");
                    return;
                }
                if (curSelLab.LabState != "制样")
                {
                    MessageBox.Show("此样品已绑定磁扣");
                    return;
                }

                string ckgCode = icCard.CardType.Substring(4);
                if (curSelLab.CheckGroupName.Contains("角质层") || curSelLab.CheckGroupName.Contains("煤岩"))
                {
                    if (ckgCode != "04" && ckgCode != "05")
                    {
                        MessageBox.Show("磁扣类型不对");
                        return;
                    }
                }
                else
                {
                    if (curSelLab.CheckGroupCode != ckgCode)
                    {
                        MessageBox.Show("磁扣类型不对");
                        return;
                    }
                }

                QC_Sample_Lab tempLab = curSelLab;

                icCard.SampleId = tempLab.Sample_Lab_ID;
                tempLab.CardId = icCard.CardID;
                tempLab.MakeUser = LocalInfo.Current.user.ID;
                tempLab.MakeTime = DateTime.Now;
                tempLab.Billtype = "已扫样品扣";
                tempLab.LabState = "送检";
                tempLab.RefreshState();

                IDbConnection conn = DbContext.GetDefaultConnection();
                conn.Open();
                IDbTransaction trans = conn.BeginTransaction();
                tempLab.Save(trans);
                icCard.Save(trans);
                trans.Commit();
                conn.Close();

                //DbContext.ExeSql("update mix set mix.SampleState=4 from QC_SAMPLE_MIX mix where mix.SampleState=3 and not exists (select * from QC_SAMPLE_LAB t1 inner join QC_MIXCHECKGROUP t2 on t2.SAMPLE_LAB_ID= t1.SAMPLE_LAB_ID where t2.SAMPLE_MIX_ID=mix.SAMPLE_MIX_ID and t1.CheckGroupName!='水分样' and IsNull(t1.BILLTYPE,'')='未绑定样品扣')");
                lblLabMakeTime.Text = DateTime.Now.ToString("HH:mm:ss") + "完成刷卡";


                DlgZyInfo dlg = new DlgZyInfo(curSelLab.CheckGroupName, curSelLab.ShortStoreCode);

                dlg.ShowDialog();
            }
            else
            {
                MessageBox.Show("磁卡类型不对");
                return;
            }
        }

        #region 打印1

        private void 打印详细制样编码_Click(object sender, EventArgs e)
        {
         
            this.printPreviewDialog1.ShowDialog();
          

        }

        private int curZyPrintPage = 1;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //int curRow = 0;
            QC_SampleMix_ZhiYang zySample = this.qCSampleMixZhiYangBindingSource.Current as QC_SampleMix_ZhiYang;
            if (zySample != null && zySample.CheckGroups.Count > 0)
            {
                int printPage = zySample.CheckGroups.Count - curZyPrintPage;
                if (printPage >= 0 && printPage < zySample.CheckGroups.Count)
                {
                    var item = zySample.CheckGroups[printPage];

                    string head = item.ShortStoreCode;
                    string body = item.CheckGroupName;

                    string riqi = zySample.ZyRecvTime == null ? "" : zySample.ZyRecvTime.Value.ToString("yyyyMM");
                    if (zySample.SampleType == SampleType.抽查样) riqi += "(抽样)";


                    Font f1 = new System.Drawing.Font("宋体", 21, FontStyle.Bold);
                    SizeF headSize = e.Graphics.MeasureString(head, f1);

                    Font f2 = new System.Drawing.Font("宋体", 12f, FontStyle.Bold);
                    SizeF bodySize = e.Graphics.MeasureString(body, f2);

                    Font f3 = new System.Drawing.Font("宋体", 12f, FontStyle.Bold);

                    if (curZyPrintPage ==1)
                    {
                        riqi = QC_Sample_Mix.ShortStoreCode(zySample.YpDanHao);
                    }
                   
                    SizeF riqiSize = e.Graphics.MeasureString(riqi, f2);

                    Rectangle rect = new Rectangle(9, 3, 112, 94);
                    // e.Graphics.DrawRectangle(Pens.Black, rect);

                    float topMargin = rect.Top + (rect.Height - headSize.Height - bodySize.Height - riqiSize.Height - 6) / 2;
                    float leftMargin = rect.Left + (rect.Width - headSize.Width) / 2;

                    e.Graphics.DrawString(head, f1, Brushes.Black, new PointF(leftMargin, topMargin));

                    float topMargin2 = topMargin + Math.Max(headSize.Height + 3, 12);
                    float leftMargin2 = rect.Left + (rect.Width - bodySize.Width) / 2;
                    e.Graphics.DrawString(body, f2, Brushes.Black, new PointF(leftMargin2, topMargin2));

                    float topMargin3 = topMargin2 + Math.Max(bodySize.Height + 2, 12);
                    float leftMargin3 = rect.Left + (rect.Width - riqiSize.Width) / 2;
                    e.Graphics.DrawString(riqi, f2, Brushes.Black, new PointF(leftMargin3, topMargin3));
                }
                if (curZyPrintPage < zySample.CheckGroups.Count)
                {
                    e.HasMorePages = true;
                    curZyPrintPage++;
                }
                else
                {
                    e.HasMorePages = false;
                    curZyPrintPage = 1;
                }
            }
            else
            {
                e.HasMorePages = false;
                curZyPrintPage = 1;
            }
        }

        #endregion


        private void 查询_Click(object sender, EventArgs e)
        {
            string storecode = textBox1.Text.Trim();
            if (!string.IsNullOrEmpty(storecode))
            {
                string fullCode = QC_Sample_Mix.FullStoreCode(storecode);
                QC_Sample_Lab sellLab = zyMixSamples.LabTable.FirstOrDefault<QC_Sample_Lab>((lb) => lb.StoreCode == fullCode);

              
                if (sellLab != null)
                {
                    if (xtraTabControl1.SelectedTabPage != null && xtraTabControl1.SelectedTabPage.Text != sellLab.CheckGroupName)
                    {
                        foreach (XtraTabPage tabPage in xtraTabControl1.TabPages)
                        {
                            if (tabPage.Text == sellLab.CheckGroupName)
                            {
                                xtraTabControl1.SelectedTabPage = tabPage;
                                break;
                            }
                        }
                    }
                    int idx = this.labTable.IndexOf(sellLab);
                    this.gridView3.FocusedRowHandle = this.gridView3.GetRowHandle(idx);
                 ;
                }
                else
                {
                    MessageBox.Show("没有找到样品");
                }
            }
            else
            {
                MessageBox.Show("样品编码不能为空");
            }
        }

        private void SetCurSelLab(QC_Sample_Lab sellLab)
        {
            if (curSelLab == sellLab) return;

            curSelLab = sellLab;

            if (curSelLab != null && curSelLab.CheckGroupType == "立刻检验")
            {
                curSelLab.CheckVals.LoadDataByWhere("main.Sample_Lab_Id=@Sample_Lab_Id", curSelLab.Sample_Lab_ID);
                gridCtl_CheckVal.DataSource = curSelLab.CheckVals;

                lblLabGroupName.Text = "(" + curSelLab.ShortStoreCode + ")" + curSelLab.CheckGroupName;
                lblLabMakeTime.Text = "";
                this.panelLab.Visible = true;
                btnSaveLab.Visible = true;
                zyMixSamples.Save();

                textBox1.Text = curSelLab.ShortStoreCode;
            }
            else if (curSelLab != null && curSelLab.CheckGroupType == "后续检验")
            {
                this.panelLab.Visible = true;
                curSelLab.CheckVals.Empty();
                curSelLab.SetDataStateAsUnchanged();
                curSelLab.SaveEnable = false;
                gridCtl_CheckVal.DataSource = curSelLab.CheckVals;

                lblLabGroupName.Text = "(" + curSelLab.ShortStoreCode + ")" + curSelLab.CheckGroupName + "刷卡:";
                lblLabMakeTime.Left = lblLabGroupName.Left + lblLabGroupName.Width + 3;
                if (curSelLab.LabState == "制样")
                    lblLabMakeTime.Text = "";
                else
                    lblLabMakeTime.Text = curSelLab.MakeTime == null ? "" : curSelLab.MakeTime.Value.ToString("HH:mm:ss") + "完成刷卡";
                btnSaveLab.Visible = false;
                zyMixSamples.Save();
                textBox1.Text = curSelLab.ShortStoreCode;
            }
            else
            {
                // curSelLab.CheckVals.Empty();
                textBox1.Text = "";
                gridCtl_CheckVal.DataSource = new QC_Sample_Value_Table();

                this.panelLab.Visible = false;
                btnSaveLab.Visible = false;
            }
        }

      



        private void btnSaveLab_Click(object sender, EventArgs e)
        {
            if (curSelLab == null)
            {
                MessageBox.Show("没有选中数据");
                return;
            }
            QC_Sample_Lab tempLab = curSelLab;

            if (tempLab.CheckGroupType == "立刻检验")
            {
                foreach (var item in tempLab.CheckVals)
                {
                    item.CheckUser = LocalInfo.Current.user.ID;
                    item.CheckTime = DateTime.Now;
                }
                tempLab.Billtype = "检验完成";
                tempLab.LabState = "检验完成";
                tempLab.MakeUser = LocalInfo.Current.user.ID;
                tempLab.MakeTime = DateTime.Now;
                tempLab.RefreshState();
                tempLab.SaveCheckVals = true;
                tempLab.Save();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                查询_Click(null, null);
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            labTable.Empty();
            if (xtraTabControl1.SelectedTabPage != null)
            {
                foreach (var item in zyMixSamples.LabTable)
                {
                    if (item.CheckGroupName == xtraTabControl1.SelectedTabPage.Text)
                    {
                        labTable.Add(item);
                    }
                }
            }
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //QC_MixCheckGroup cg = sampleLabsBindingSource.Current as QC_MixCheckGroup;
            //if (cg != null)
            //{
            //    if (cg.CheckGroupName.Contains("角质层"))
            //        textBox1.Text = cg.ShortZupiHao;
            //    else
            //        textBox1.Text = cg.ShortStoreCode;
            //    查询_Click(null, null);
            //}

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string code=textBox1.Text.Trim();
            Regex reg = new Regex(@"(?<MatWord>([a-z]|[A-Z])+)(?<BianHao>\d+)(?<YangWord>\w*)");
            Match match= reg.Match(code);
            if (match.Success)
            {
                string MatWord = match.Groups["MatWord"].Value;
                string BianHao = match.Groups["BianHao"].Value;
                string YangWord = match.Groups["YangWord"].Value;
                string xuhao = BianHao.Substring(BianHao.Length - 2, 2);
                int nextXuhao = Convert.ToInt32(xuhao) + 1;
                textBox1.Text = MatWord + BianHao.Substring(0, BianHao.Length - 2) + nextXuhao.ToString("00") + YangWord;
                查询_Click(null, null);
            }
            else
            {
                MessageBox.Show("对不起，不认识您录入的字符串格式");
            }
        }

        private void qCSampleLabBindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            //if (this.curSelLab!=null && this.curSelLab.SaveEnable)
            //{
            //    if (MessageBox.Show("已经修改数据，是否保存？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        btnSaveLab_Click(null, null);
            //    }
            //}

            QC_Sample_Lab selLab = qCSampleLabBindingSource1.Current as QC_Sample_Lab;
            SetCurSelLab(selLab);
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void 制样_Click(object sender, EventArgs e)
        {
           
            if (!comboBox1.Text.StartsWith("HY"))
            {
                MessageBox.Show("请选择正确单号");
                return;
            }
            DbEntityTable<QC_Sample_Mix> mix = new DbEntityTable<QC_Sample_Mix>();
            int mixid = 100000000;
            mix.LoadDataByWhere("main.ypdanhao=@ypdanhao", QC_Sample_Mix.FullStoreCode(comboBox1.Text));
            if (mix.Count > 0)
            { mixid = mix[0].Sample_Mix_ID; }
            QC_SampleMix_ZhiYang zySample = QC_SampleMix_ZhiYang.GetById(mixid); 
            if (zySample == null)
            {
                MessageBox.Show("找不到单据");
                return;
            }

            if (zySample.SampleState < SampleState.组批完成)
            {
                MessageBox.Show("磁卡所对大桶还未组批完成");
                return;
            }
            if (zySample.WLLX != "火运")
            {
                MessageBox.Show("物料不是火运请选择其他制样点");
                return;

            }
            zySample.ZyDanHao = zySample.MatClassWord + DbContext.GetSeq(DateTime.Now.Date.ToString("yyyyMMdd"), 2);
            zySample.SampleState = SampleState.开始制样;
            zySample.ZyWpCode = workpointCode;
            zySample.ZyRecvUser = LocalInfo.Current.user.ID;
            zySample.ZyRecvTime = DateTime.Now;
            if (zySample.SampleType == SampleType.人工取样 || zySample.SampleType == SampleType.机器取样 || zySample.SampleType == SampleType.抽查样)
            {
                DbEntityTable<QC_MatAllCheckItem> bjCheckItem = new DbEntityTable<QC_MatAllCheckItem>();
                bjCheckItem.LoadDataByWhere("MATNCID=@MATNCID and JYLX='必检'", zySample.MatPK);
                foreach (var stdCheckItem in bjCheckItem)
                {
                    QC_MixCheckItem ckItem = zySample.CheckItems.FirstOrDefault<QC_MixCheckItem>((ck) => ck.CheckItemNcId == stdCheckItem.CheckItemNcId);
                    if (ckItem == null)
                    {
                        QC_MixCheckItem item = new QC_MixCheckItem();
                        item.CheckItemNcId = stdCheckItem.CheckItemNcId;
                        item.CheckItemCode = stdCheckItem.CheckItemCode;
                        item.CheckItemName = stdCheckItem.CheckItemName;
                        item.CheckItemUnit = stdCheckItem.CheckItemUnit;
                        item.CheckGroupCode = stdCheckItem.CheckGroupCode;
                        item.CheckGroupName = stdCheckItem.CheckGroupName;
                        item.CheckGroupType = stdCheckItem.CheckGroupType;
                        item.CkgShortWord = stdCheckItem.CkgShortWord;
                        item.Sample_Mix_ID = item.Sample_Mix_ID;
                        item.CheckGroupVisIdx = stdCheckItem.CheckGroupVisIdx;
                        item.Source = "检验标准-必检";
                        //正样id不为0且是角质层时 不添加
                        if (!(zySample.MainSampleMixId != 0 && item.CheckGroupName == "角质层"))
                        {
                            zySample.CheckItems.Add(item);
                        }
                      
                      
                    }
                }
                DbEntityTable<QC_MatAllCheckItem> myCheckItem = new DbEntityTable<QC_MatAllCheckItem>();
                myCheckItem.LoadDataByWhere("MATNCID=@MATNCID and JYLX='每月'", zySample.MatPK);

                DateTime yue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                foreach (var stdCheckItem in myCheckItem)
                {
                    object cntObj = DbContext.ExecuteScalar("SELECT count(*)  FROM  QC_MixCheckItem mck  inner join qc_sample_mix mix on mix.SAMPLE_MIX_ID=mck.SAMPLE_MIX_ID  where mix.Mix_Time>=@MixTime and (mix.SampleType=" + (int)SampleType.机器取样 + " or mix.SampleType=" + (int)SampleType.人工取样 + ") and mix.SupplierCode=@SupplierCode and mix.MatPK=@MatPK and mck.CheckItemNcId=@CheckItemNcId", yue, zySample.SupplierCode, zySample.MatPK, stdCheckItem.CheckItemNcId);
                    if (cntObj != null)
                    {
                        int cnt = Convert.ToInt32(cntObj);
                        if (cnt == 0)
                        {
                            QC_MixCheckItem ckItem = zySample.CheckItems.FirstOrDefault<QC_MixCheckItem>((ck) => ck.CheckItemNcId == stdCheckItem.CheckItemNcId);
                            if (ckItem == null)
                            {
                                QC_MixCheckItem item = new QC_MixCheckItem();
                                item.CheckItemNcId = stdCheckItem.CheckItemNcId;
                                item.CheckItemCode = stdCheckItem.CheckItemCode;
                                item.CheckItemName = stdCheckItem.CheckItemName;
                                item.CheckItemUnit = stdCheckItem.CheckItemUnit;
                                item.CheckGroupCode = stdCheckItem.CheckGroupCode;
                                item.CheckGroupName = stdCheckItem.CheckGroupName;
                                item.CheckGroupType = stdCheckItem.CheckGroupType;
                                item.CkgShortWord = stdCheckItem.CkgShortWord;
                                item.Sample_Mix_ID = item.Sample_Mix_ID;
                                item.CheckGroupVisIdx = stdCheckItem.CheckGroupVisIdx;
                                item.Source = "检验标准-每月";
                                //if (!(zySample.SampleType == SampleType.普通样 && item.CheckGroupName == "粒度样"))
                                //正样id不为0且是角质层时 不添加
                                if (!(zySample.MainSampleMixId != 0 && item.CheckGroupName == "角质层"))
                                {
                                    zySample.CheckItems.Add(item);
                                }
                      
                            }
                        }
                    }
                }

                int wd2 = (int)DateTime.Now.DayOfWeek - 1;
                if (wd2 == -1)
                {
                    wd2 = 6;
                }

                DateTime zhou1 = DateTime.Today.AddDays(0 - wd2);
                DbEntityTable<QC_MatAllCheckItem> meizhouCheckItem = new DbEntityTable<QC_MatAllCheckItem>();
                meizhouCheckItem.LoadDataByWhere("MATNCID=@MATNCID and JYLX='每周'", zySample.MatPK);

                foreach (var stdCheckItem in meizhouCheckItem)
                {
                    object cntObj = DbContext.ExecuteScalar("SELECT count(*)  FROM  QC_MixCheckItem mck  inner join qc_sample_mix mix on mix.SAMPLE_MIX_ID=mck.SAMPLE_MIX_ID  where mix.Mix_Time>=@MixTime and (mix.SampleType=" + (int)SampleType.机器取样 + " or mix.SampleType=" + (int)SampleType.人工取样 + ")and mix.SupplierCode=@SupplierCode and mix.MatPK=@MatPK and mck.CheckItemNcId=@CheckItemNcId", zhou1, zySample.SupplierCode, zySample.MatPK, stdCheckItem.CheckItemNcId);
                    if (cntObj != null)
                    {
                        int cnt = Convert.ToInt32(cntObj);
                        if (cnt == 0)
                        {
                            QC_MixCheckItem ckItem = zySample.CheckItems.FirstOrDefault<QC_MixCheckItem>((ck) => ck.CheckItemNcId == stdCheckItem.CheckItemNcId);
                            if (ckItem == null)
                            {
                                QC_MixCheckItem item = new QC_MixCheckItem();
                                item.CheckItemNcId = stdCheckItem.CheckItemNcId;
                                item.CheckItemCode = stdCheckItem.CheckItemCode;
                                item.CheckItemName = stdCheckItem.CheckItemName;
                                item.CheckItemUnit = stdCheckItem.CheckItemUnit;
                                item.CheckGroupCode = stdCheckItem.CheckGroupCode;
                                item.CheckGroupName = stdCheckItem.CheckGroupName;
                                item.CheckGroupType = stdCheckItem.CheckGroupType;
                                item.CkgShortWord = stdCheckItem.CkgShortWord;
                                item.Sample_Mix_ID = item.Sample_Mix_ID;
                                item.CheckGroupVisIdx = stdCheckItem.CheckGroupVisIdx;
                                item.Source = "检验标准-每周";

                                //正样id不为0且是角质层时 不添加
                                if (!(zySample.MainSampleMixId != 0 && item.CheckGroupName == "角质层"))
                                {
                                    zySample.CheckItems.Add(item);
                                }
                      
                            }
                        }
                    }
                }
                DateTime tian1 = DateTime.Today;
                DbEntityTable<QC_MatAllCheckItem> meitianCheckItem = new DbEntityTable<QC_MatAllCheckItem>();
                meizhouCheckItem.LoadDataByWhere("MATNCID=@MATNCID and JYLX='每天'", zySample.MatPK);

                foreach (var stdCheckItem in meizhouCheckItem)
                {
                    object cntObj = DbContext.ExecuteScalar("SELECT count(*)  FROM  QC_MixCheckItem mck  inner join qc_sample_mix mix on mix.SAMPLE_MIX_ID=mck.SAMPLE_MIX_ID  where mix.Mix_Time>=@MixTime and (mix.SampleType=" + (int)SampleType.机器取样 + " or mix.SampleType=" + (int)SampleType.人工取样 + ") and mix.SupplierCode=@SupplierCode and mix.MatPK=@MatPK and mck.CheckItemNcId=@CheckItemNcId", tian1, zySample.SupplierCode, zySample.MatPK, stdCheckItem.CheckItemNcId);
                    if (cntObj != null)
                    {
                        int cnt = Convert.ToInt32(cntObj);
                        if (cnt == 0)
                        {
                            QC_MixCheckItem ckItem = zySample.CheckItems.FirstOrDefault<QC_MixCheckItem>((ck) => ck.CheckItemNcId == stdCheckItem.CheckItemNcId);
                            if (ckItem == null)
                            {
                                QC_MixCheckItem item = new QC_MixCheckItem();
                                item.CheckItemNcId = stdCheckItem.CheckItemNcId;
                                item.CheckItemCode = stdCheckItem.CheckItemCode;
                                item.CheckItemName = stdCheckItem.CheckItemName;
                                item.CheckItemUnit = stdCheckItem.CheckItemUnit;
                                item.CheckGroupCode = stdCheckItem.CheckGroupCode;
                                item.CheckGroupName = stdCheckItem.CheckGroupName;
                                item.CheckGroupType = stdCheckItem.CheckGroupType;
                                item.CkgShortWord = stdCheckItem.CkgShortWord;
                                item.Sample_Mix_ID = item.Sample_Mix_ID;
                                item.CheckGroupVisIdx = stdCheckItem.CheckGroupVisIdx;
                                item.Source = "检验标准-每天";

                                //正样id不为0且是角质层时 不添加
                                if (!(zySample.MainSampleMixId != 0 && item.CheckGroupName == "角质层"))
                                {
                                    zySample.CheckItems.Add(item);
                                }
                      
                            }
                        }
                    }
                }
               
            }
            //else if (zySample.SampleType == SampleType.校验样)
            //{
            //    //加载校验样项目
            //    QC_MixCheckItem_Table table = new QC_MixCheckItem_Table();
            //    table.LoadDataByWhere("main.SAMPLE_VEH_ID=(select SAMPLE_VEH_ID from QC_Sample_Veh veh where veh.SAMPLE_MIX_ID=@SAMPLE_MIX_ID)", zySample.Sample_Mix_ID);
            //    foreach (var item in table)
            //    {
            //        item.Sample_Mix_ID = zySample.Sample_Mix_ID;
            //        item.Source = "校验样";
            //        zySample.CheckItems.Add(item);
            //    }

            //    //DbContext.ExeSql("update t1 set t1.SAMPLE_MIX_ID =(select SAMPLE_MIX_ID from QC_Sample_Veh t2 where t2.SAMPLE_VEH_ID=t1.SAMPLE_VEH_ID) from QC_MIXCHECKITEM t1 where ISnull(t1.SAMPLE_VEH_ID,0)>0 and ISnull(t1.SAMPLE_MIX_ID,0)<=0");
            //}

            //生成样品分类
            foreach (var item in zySample.CheckItems)
            {
                QC_MixCheckGroup mixCG = zySample.CheckGroups.FirstOrDefault<QC_MixCheckGroup>((mcg) => mcg.CheckGroupCode == item.CheckGroupCode);
                if (mixCG == null)
                {
                    mixCG = new QC_MixCheckGroup();
                    mixCG.CheckGroupCode = item.CheckGroupCode;
                    mixCG.CheckGroupName = item.CheckGroupName;
                    mixCG.CheckGroupType = item.CheckGroupType;
                    mixCG.CkgShortWord = item.CkgShortWord;
                    mixCG.VisIdx = item.CheckGroupVisIdx;
                    mixCG.StoreCode = zySample.ZyDanHao + item.CkgShortWord;
                    mixCG.MatPK = zySample.MatPK;
                    mixCG.SupplierCode = zySample.SupplierCode;
                    mixCG.Sample_TBZD = zySample.Sample_TBZD;
                    mixCG.Sample_Mix_ID = zySample.Sample_Mix_ID;
                    mixCG.ZySample = zySample;

                    zySample.CheckGroups.Add(mixCG);
                }
                mixCG.MixCheckItem.Add(item);
            }
            //加载物料设置样品分类
            DbEntityTable<QC_MatCheckGroup> MatCheckGroup = new DbEntityTable<QC_MatCheckGroup>();
            MatCheckGroup.LoadDataByWhere("MatNcId=@MatNcId", zySample.MatPK);
            for (int i = 0; i < MatCheckGroup.Count; i++)
            {
                QC_MixCheckGroup item = new QC_MixCheckGroup();
                item.CheckGroupCode = MatCheckGroup[i].CheckGroupCode;
                item.CheckGroupName = MatCheckGroup[i].CheckGroupName;
                item.CheckGroupType = MatCheckGroup[i].CheckGroupType;
                item.CkgShortWord = MatCheckGroup[i].ShortWord;
                item.VisIdx = MatCheckGroup[i].CheckGroupVisIdx;
                item.StoreCode = zySample.ZyDanHao + MatCheckGroup[i].ShortWord;
                item.MatPK = zySample.MatPK;
                item.SupplierCode = zySample.SupplierCode;
                item.Sample_TBZD = zySample.Sample_TBZD;
                item.Sample_Mix_ID = zySample.Sample_Mix_ID;
                item.ZySample = zySample;
                
                zySample.CheckGroups.Add(item);
            }

            zySample.CheckGroups.Sort((tx, ty) => tx.VisIdx.CompareTo(ty.VisIdx));
            foreach (var item in zySample.CheckGroups)
            {
                item.MatPK = zySample.MatPK;
                item.SupplierCode = zySample.SupplierCode;
                item.Sample_TBZD = zySample.Sample_TBZD;
                item.ZySample = zySample;
                item.Billtype = "未绑定样品扣";
                item.LabState = "制样";
            }

            IDbConnection conn = DbContext.GetDefaultConnection();
            conn.Open();
            IDbTransaction trans = conn.BeginTransaction();

            try
            {

                zySample.SaveCheckGroups = true;
                zySample.SaveCheckItems = true;
                zySample.Save(trans);


                //生成Lab
                foreach (var ckg in zySample.CheckGroups)
                {
                    //if (!ckg.CheckGroupName.Contains("角质层") && (ckg.CheckGroupType == "立刻检验" || ckg.CheckGroupType == "后续检验"))
                    if (ckg.CheckGroupType == "立刻检验" || ckg.CheckGroupType == "后续检验")
                    {
                        QC_Sample_Lab lb = new QC_Sample_Lab();
                        lb.MixCheckGroup.Add(ckg);
                        lb.StoreCode = ckg.StoreCode;
                        lb.WpCode = workpointCode;
                        lb.Billtype = "未绑定样品扣";
                        lb.LabState = "制样";
                        lb.WLLX = zySample.WLLX;
                        lb.CheckGroupCode = ckg.CheckGroupCode;
                        lb.CheckGroupName = ckg.CheckGroupName;
                        lb.CheckGroupType = ckg.CheckGroupType;
                        lb.Sample_Mix_ID = ckg.Sample_Mix_ID;
                        foreach (var ck in ckg.MixCheckItem)
                        {
                            QC_Sample_Value qcVal = new QC_Sample_Value();
                            qcVal.CheckItemNcId = ck.CheckItemNcId;
                            qcVal.CheckItemCode = ck.CheckItemCode;
                            qcVal.CheckItemName = ck.CheckItemName;
                            qcVal.ActualVal = ck.ActualVal;
                            lb.CheckVals.Add(qcVal);
                        }
                        lb.SaveCheckVals = true;
                        zyMixSamples.LabTable.Add(lb);
                    }
                }
                zyMixSamples.LabTable.Save(trans);
            }
            catch(Exception ex)
            {
                trans.Rollback();
                conn.Close();
                MessageBox.Show("出现异常，稍后重新操作"+ex.ToString());
                return;

            }


            trans.Commit();
            conn.Close();

            zyMixSamples.Add(zySample);

            lblRecvDanHao.Text = zySample.ZyShortDanHao;
            this.gridView1.FocusedRowHandle = this.gridView1.GetRowHandle(zyMixSamples.Count - 1);
            LabTabs();
            //this.printPreviewDialog1.ShowDialog();
            this.printDocument1.Print();
            initDanHao();

        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        /// <summary>
        /// 大桶所分配的小桶号
        /// </summary>
        /// <param name="xtShu">小桶数量</param>
        /// <param name="dtShu">大桶数量</param>
        /// <returns></returns>
        private Dictionary<int, List<int>> FenZu(int xtShu, int dtShu)
        {
            //小桶号，大桶号
            List<int> xiaotongHao = new List<int>();
            for (int i = 0; i < xtShu; i++)
            {
                xiaotongHao.Add(i);
            }
            //为每个大桶分配一个小桶
            Dictionary<int, List<int>> result = new Dictionary<int, List<int>>();
            for (int i = 0; i < dtShu; i++)
            {
                Random r = new Random(DateTime.Now.Second + i * 27);
                int idx = r.Next(xiaotongHao.Count);
                List<int> item = new List<int>();
                item.Add(xiaotongHao[idx]);
                result.Add(i, item);
                xiaotongHao.RemoveAt(idx);
            }

            foreach (var xtHao in xiaotongHao)
            {
                Random r = new Random(DateTime.Now.Second + xtHao * 11);
                int idx = r.Next(dtShu);
                result[idx].Add(xtHao);
            }

            return result;
        }


        private void 组批_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要角质层组批吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DbEntityTable<QC_MixCheckGroup> zupi = new DbEntityTable<QC_MixCheckGroup>();

                int tbzd = 1;
                Dictionary<string, List<QC_SampleMix_ZhiYang>> sampleFenzu = new Dictionary<string, List<QC_SampleMix_ZhiYang>>();
                foreach (var zySample in this.zyMixSamples)
                {
                    bool youJzc = false;
                    if (zySample.SampleType != SampleType.复检样)
                    {
                        foreach (var item in zySample.CheckGroups)
                        {
                            if (item.CheckGroupName.StartsWith("角质层") && string.IsNullOrEmpty(item.ZupiHao))
                            {
                                youJzc = true;
                            }
                        }
                        if (youJzc)
                        {

                          
                            string key = zySample.MatPK + "_" + zySample.SupplierCode + "_";
                            if (zySample.Sample_TBZD) key += "_" + (tbzd++).ToString();
                            if (zySample.MainSampleMixId == 0)
                                key += zySample.Sample_Mix_ID;
                            else key += zySample.MainSampleMixId;
                            if (sampleFenzu.ContainsKey(key))
                            {
                                sampleFenzu[key].Add(zySample);
                            }
                            else
                            {
                                sampleFenzu.Add(key, new List<QC_SampleMix_ZhiYang>() { zySample });
                            }
                        }
                    }
                }

                DbEntityTable<QC_Sample_Lab> jzLabs = zyMixSamples.LabTable;

                foreach (var item in sampleFenzu)
                {
                    int xiaotongshu = item.Value.Count;
                    int datongshu = 1;
                    QC_SampleMix_ZhiYang tempZySample = item.Value[0];
                    DbEntityTable<QC_LabRule> labrule = new DbEntityTable<QC_LabRule>();
                    labrule.LoadDataByWhere("MatNcId=@MatNcId and (CustCode=@CustCode or CustCode='' or CustCode is null) and MixNumber<=@MixNumber", tempZySample.MatPK, tempZySample.SupplierCode, xiaotongshu);
                    if (labrule.Count > 0)
                    {
                        if (labrule[0].PlanCount > 0)
                        {
                            datongshu = labrule[0].PlanCount;  //组多少桶
                            //PlanCount 多少桶一批
                            //  tongshu = Convert.ToInt32(Math.Ceiling(mixCheckGroups.Count * 1.0 / labrule[0].PlanCount));
                        }
                    }
                    if (datongshu > xiaotongshu) datongshu = xiaotongshu;

                    Dictionary<int, List<int>> fp = FenZu(xiaotongshu, datongshu);

                    foreach (var fpItem in fp)
                    {
                        string bm = Zhc.Data.DbContext.GetSeq("JZ" + DateTime.Now.Date.ToString("yyyyMMdd"), 2);

                        List<QC_MixCheckGroup> mgYLst = new List<QC_MixCheckGroup>();
                        List<QC_MixCheckGroup> mgGLst = new List<QC_MixCheckGroup>();
                        List<QC_MixCheckGroup> mgMLst = new List<QC_MixCheckGroup>();
                        foreach (var xtHao in fpItem.Value)
                        {
                            QC_SampleMix_ZhiYang tempZySample2 = item.Value[xtHao];
                            var mgY = from mg in tempZySample2.CheckGroups
                                      where mg.CheckGroupName == "角质层Y"
                                      select mg;

                            if (mgY.Count<QC_MixCheckGroup>() > 0)
                            {
                                foreach (var mgYItem in mgY)
                                {
                                    mgYLst.Add(mgYItem);
                                }
                            }

                            var mgG = from mg in tempZySample2.CheckGroups
                                      where mg.CheckGroupName == "角质层G"
                                      select mg;

                            if (mgG.Count<QC_MixCheckGroup>() > 0)
                            {
                                foreach (var mgGItem in mgG)
                                {
                                    mgGLst.Add(mgGItem);
                                }
                            }

                            var mgM = from mg in tempZySample2.CheckGroups
                                      where mg.CheckGroupName == "煤岩样"
                                      select mg;

                            if (mgM.Count<QC_MixCheckGroup>() > 0)
                            {
                                foreach (var mgMItem in mgM)
                                {
                                    mgMLst.Add(mgMItem);
                                }
                            }
                        }

                        if (mgYLst.Count > 0)
                        {
                            QC_Sample_Lab lY = new QC_Sample_Lab();
                            lY.StoreCode = bm + "Y";
                            lY.WpCode = LocalInfo.Current.workpoint.Code;
                            lY.Billtype = "未绑定样品扣";
                            lY.LabState = "制样";
                            lY.WLLX = item.Value[0].WLLX;
                            lY.CheckGroupCode = mgYLst[0].CheckGroupCode;
                            lY.CheckGroupName = mgYLst[0].CheckGroupName;
                            lY.CheckGroupType = mgYLst[0].CheckGroupType;
                            mgYLst[0].MixCheckItem.LoadDataByWhere("main.CheckGroupId=@CheckGroupId", mgYLst[0].Id);
                            foreach (var ck in mgYLst[0].MixCheckItem)
                            {
                                QC_Sample_Value qcVal = new QC_Sample_Value();
                                qcVal.CheckItemNcId = ck.CheckItemNcId;
                                qcVal.CheckItemCode = ck.CheckItemCode;
                                qcVal.CheckItemName = ck.CheckItemName;
                                qcVal.ActualVal = ck.ActualVal;
                                lY.CheckVals.Add(qcVal);
                            }
                            lY.SaveCheckVals = true;
                            foreach (var mg in mgYLst)
                            {
                                mg.ZupiHao = lY.StoreCode;
                                mg.SampleLab = lY;
                                lY.MixCheckGroup.Add(mg);

                            }
                            jzLabs.Add(lY);
                        }

                        if (mgGLst.Count > 0)
                        {
                            QC_Sample_Lab lG = new QC_Sample_Lab();
                            lG.StoreCode = bm + "G";
                            lG.WpCode = LocalInfo.Current.workpoint.Code;
                            lG.Billtype = "未绑定样品扣";
                            lG.LabState = "制样";
                            lG.CheckGroupCode = mgGLst[0].CheckGroupCode;
                            lG.CheckGroupName = mgGLst[0].CheckGroupName;
                            lG.CheckGroupType = mgGLst[0].CheckGroupType;
                            lG.WLLX = item.Value[0].WLLX;
                            mgGLst[0].MixCheckItem.LoadDataByWhere("main.CheckGroupId=@CheckGroupId", mgGLst[0].Id);
                            foreach (var ck in mgGLst[0].MixCheckItem)
                            {
                                QC_Sample_Value qcVal = new QC_Sample_Value();
                                qcVal.CheckItemNcId = ck.CheckItemNcId;
                                qcVal.CheckItemCode = ck.CheckItemCode;
                                qcVal.CheckItemName = ck.CheckItemName;
                                qcVal.ActualVal = ck.ActualVal;
                                lG.CheckVals.Add(qcVal);
                            }
                            lG.SaveCheckVals = true;
                            foreach (var mg in mgGLst)
                            {
                                mg.ZupiHao = lG.StoreCode;
                                mg.SampleLab = lG;
                                lG.MixCheckGroup.Add(mg);

                            }
                            jzLabs.Add(lG);
                        }
                        if (mgMLst.Count > 0)
                        {
                            QC_Sample_Lab lM = new QC_Sample_Lab();
                            lM.StoreCode = bm + "M";
                            lM.WpCode = LocalInfo.Current.workpoint.Code;
                            lM.Billtype = "未绑定样品扣";
                            lM.LabState = "制样";
                            lM.CheckGroupCode = mgMLst[0].CheckGroupCode;
                            lM.CheckGroupName = mgMLst[0].CheckGroupName;
                            lM.CheckGroupType = mgMLst[0].CheckGroupType;
                            lM.WLLX = item.Value[0].WLLX;
                            mgMLst[0].MixCheckItem.LoadDataByWhere("main.CheckGroupId=@CheckGroupId", mgMLst[0].Id);
                            foreach (var ck in mgMLst[0].MixCheckItem)
                            {
                                QC_Sample_Value qcVal = new QC_Sample_Value();
                                qcVal.CheckItemNcId = ck.CheckItemNcId;
                                qcVal.CheckItemCode = ck.CheckItemCode;
                                qcVal.CheckItemName = ck.CheckItemName;
                                qcVal.ActualVal = ck.ActualVal;
                                lM.CheckVals.Add(qcVal);
                            }
                            lM.SaveCheckVals = true;
                            foreach (var mg in mgMLst)
                            {
                                mg.ZupiHao = lM.StoreCode;
                                mg.SampleLab = lM;
                                lM.MixCheckGroup.Add(mg);

                            }
                            jzLabs.Add(lM);
                        }
                    }

                }
                jzLabs.Save();
                this.gridView1.RefreshData();
                LabTabs();
                PrintZupi();
            }
        }

        private void PrintZupi()
        {
            this.printPreviewDialog2.ShowDialog();
        }

        class ZupiData
        {
            private string head = "";

            public string Head
            {
                get { return head; }
                set { head = value; }
            }

            private List<string> zupiItems = new List<string>();

            public List<string> ZupiItems
            {
                get { return zupiItems; }
                set { zupiItems = value; }
            }

            private int beginPage = 0;

            public int BeginPage
            {
                get { return beginPage; }
                set { beginPage = value; }
            }

            public int NeadPage
            {
                get
                {
                    if (zupiItems.Count <= 6)
                    {
                        return 1;
                    }
                    else
                    {
                        return 1 + Convert.ToInt32(Math.Ceiling((ZupiItems.Count - 6) / 10.0));
                    }
                }
            }

            public int EndPage
            {
                get
                {
                    return BeginPage + NeadPage;
                }
            }

            public void Print(Graphics Graphics, int curPage)
            {
                Font f2 = new System.Drawing.Font("宋体", 10f, FontStyle.Bold);
                SizeF bodySize = Graphics.MeasureString(ZupiItems[0], f2);
                Rectangle rect = new Rectangle(9, 3, 112, 94);
                if (curPage == beginPage)
                {
                    Font f1 = new System.Drawing.Font("宋体", 21, FontStyle.Bold);
                    SizeF headSize = Graphics.MeasureString(head, f1);
                    float leftMargin = rect.Left + (rect.Width - headSize.Width) / 2;

                    float height = headSize.Height;

                    List<string> temp = new List<string>();
                    for (int i = 0; i < 6 && i < zupiItems.Count; i += 2)
                    {
                        string prefix = "/";
                        if (i == 0) prefix = "";
                        if (i + 1 < zupiItems.Count)
                            temp.Add(prefix + zupiItems[i] + "/" + zupiItems[i + 1]);
                        else
                            temp.Add(prefix + zupiItems[i]);

                        height += bodySize.Height + 2;
                    }

                    float topMargin = rect.Top + (rect.Height - height) / 2;

                    Graphics.DrawString(head, f1, Brushes.Black, new PointF(leftMargin, topMargin));
                    topMargin += headSize.Height;
                    foreach (var item in temp)
                    {
                        SizeF itemSize = Graphics.MeasureString(item, f2);

                        float leftMargin2 = rect.Left + (rect.Width - itemSize.Width) / 2;
                        Graphics.DrawString(item, f2, Brushes.Black, new PointF(leftMargin2, topMargin));
                        topMargin += itemSize.Height + 2;
                    }
                }
                else
                {
                    int p = curPage - BeginPage;
                    int i = 6 + (p - 1) * 10;
                    int endi = i + 10;
                    float height = 0;
                    List<string> temp = new List<string>();
                    for (; i < endi && i < zupiItems.Count; i += 2)
                    {
                        string prefix = "/";
                        if (i == 0) prefix = "";
                        if (i + 1 < zupiItems.Count)
                            temp.Add(prefix + zupiItems[i] + "/" + zupiItems[i + 1]);
                        else
                            temp.Add(prefix + zupiItems[i]);

                        height += bodySize.Height + 2;
                    }

                    float topMargin = rect.Top + (rect.Height - height) / 2;

                    foreach (var item in temp)
                    {
                        SizeF itemSize = Graphics.MeasureString(item, f2);
                        float leftMargin2 = rect.Left + (rect.Width - itemSize.Width) / 2;
                        Graphics.DrawString(item, f2, Brushes.Black, new PointF(leftMargin2, topMargin));
                        topMargin += itemSize.Height + 2;
                    }
                }
                // e.Graphics.DrawRectangle(Pens.Black, rect);

                //

            }

        }
        private int curZupiPrintPage = 1;
        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var jzFenZu = from zySample in this.zyMixSamples
                          where zySample.ZyJzZuPiHao.StartsWith("JZ" + DateTime.Today.Day.ToString("00")) && zySample.SampleType != SampleType.复检样
                          group zySample by zySample.ZyJzZuPiHao into g
                          select g;

            List<ZupiData> printData = new List<ZupiData>();

            foreach (var jz in jzFenZu)
            {
                List<string> jzY = new List<string>();
                List<string> jzG = new List<string>();
                List<string> jzM = new List<string>();
                foreach (var item in jz)
                {
                    var jzYmcg = item.CheckGroups.FirstOrDefault<QC_MixCheckGroup>((mcg) => mcg.CheckGroupName == "角质层Y");
                    if (jzYmcg != null)
                    {
                        jzY.Add(jzYmcg.ShortStoreCode);
                    }
                    var jzGmcg = item.CheckGroups.FirstOrDefault<QC_MixCheckGroup>((mcg) => mcg.CheckGroupName == "角质层G");
                    if (jzGmcg != null)
                    {
                        jzG.Add(jzGmcg.ShortStoreCode);
                    }
                    var jzMmcg = item.CheckGroups.FirstOrDefault<QC_MixCheckGroup>((mcg) => mcg.CheckGroupName == "煤岩样");
                    if (jzMmcg != null)
                    {
                        jzM.Add(jzMmcg.ShortStoreCode);
                    }
                }

                if (jzY.Count > 0)
                {
                    ZupiData zd = new ZupiData();
                    zd.Head = jz.Key + "Y";
                    zd.ZupiItems = jzY;
                    printData.Add(zd);
                }

                if (jzG.Count > 0)
                {
                    ZupiData zd = new ZupiData();
                    zd.Head = jz.Key + "G";
                    zd.ZupiItems = jzG;
                    printData.Add(zd);
                }
                if (jzM.Count > 0)
                {
                    ZupiData zd = new ZupiData();
                    zd.Head = jz.Key + "M";
                    zd.ZupiItems = jzM;
                    printData.Add(zd);
                }
            }
            int totalPage = 1;
            foreach (var item in printData)
            {
                item.BeginPage = totalPage;
                totalPage += item.NeadPage;
            }

            int printPage = totalPage - curZupiPrintPage;

            foreach (var item in printData)
            {
                if (printPage >= item.BeginPage && printPage < item.EndPage)
                {
                    item.Print(e.Graphics, printPage);
                    break;
                }
            }

            if (curZupiPrintPage < totalPage - 1)
            {
                curZupiPrintPage++;
                e.HasMorePages = true;
            }
            else
            {
                curZupiPrintPage = 1;
                e.HasMorePages = false;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintZupi();
        }
    }
}
