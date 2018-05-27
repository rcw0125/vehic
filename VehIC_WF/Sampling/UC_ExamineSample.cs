using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zhc.Data;
using Xg.Lab.Sample;
using Xg.Lab.Sample.View;
using DevExpress.XtraTreeList.Nodes;
using VehIC_WF.Sampling.Sample.View;
using VehIC_WF.Sampling.czl.Class;

namespace VehIC_WF.Sampling
{
    public partial class UC_ExamineSample : UserControl, ICardMessage
    {
        private string cylx = "普通抽样";

        public string Cylx
        {
            get { return cylx; }
            set { cylx = value; }
        }

        public UC_ExamineSample()
        {
            InitializeComponent();
        }
        private DbEntityTable<QC_Sample_Veh> veh = new DbEntityTable<QC_Sample_Veh>();
        private QC_Sample_Mix curData = new QC_Sample_Mix();

        private QC_Sample_Mix_Table examineSamples = new QC_Sample_Mix_Table();


        private void UC_ExamineSample_Load(object sender, EventArgs e)
        {
            this.sourceCurData.DataSource = curData;
            this.sourceAllInpsectSamples.DataSource = examineSamples;

            if (this.Cylx == "管理抽样")
            {
                this.label1.Text = "管理抽样";
                examineSamples.LoadManageInpsectSamples();
            }
            else
                examineSamples.LoadInpsectSamples();
        }

        /// <summary>
        /// 加载车辆信息
        /// </summary>
        /// <param name="cph"></param>
        /// <param name="sampleTime"></param>
        public void LoadBy()
        {

            QC_Sample_Veh selectedVeh = null;

            if (string.IsNullOrEmpty(txtCph.Text.Trim()))
            {
                MessageBox.Show("车牌号不能为空");
                return;
            }

            string cph = txtCph.Text.Trim();

            if (dateEdit_SampleTime.EditValue == DBNull.Value)
            {
                DlgChe dlg = new DlgChe(cph, DateTime.Now.AddMinutes(-10));
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    selectedVeh = dlg.SelectedVeh;
                    curData.FetchTime = selectedVeh.FetchTime;
                }
                else
                {
                    return;
                }
            }
            else
            {
                DateTime sampleTime = dateEdit_SampleTime.DateTime;

                if (sampleTime > DateTime.MinValue && sampleTime < DateTime.Now)
                {
                    DbEntityTable<QC_Sample_Veh> noticeVeh = new DbEntityTable<QC_Sample_Veh>();
                    noticeVeh.LoadDataByWhere(string.Format("vehno like '%{0}%' ", cph));
                    if (noticeVeh.Count == 1)
                    {
                        selectedVeh = noticeVeh[0];
                    }
                    else
                    {
                        DlgChe dlg = new DlgChe(cph, sampleTime);
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            selectedVeh = dlg.SelectedVeh;
                            curData.FetchTime = selectedVeh.FetchTime;
                       
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("取样时间不在合理范围");
                }
            }

            if (selectedVeh != null)
            {

                curData.VehNo = selectedVeh.VehNo;
                txtCph.Text = curData.VehNo;
                //if (selectedVeh.WLLX == "火运")
                //{ curData.NoticeBillId = selectedVeh.Sample_Veh_ID.ToString(); }
                curData.NoticeBillId = selectedVeh.NoticeBillId; 
                curData.SupplierCode = selectedVeh.SupplierCode;
                curData.SupplierName = selectedVeh.SupplierName;
                curData.MatPK = selectedVeh.MatPK;
                curData.MatCode = selectedVeh.MatCode;
                curData.MatName = selectedVeh.MatName;

                curData.CheckItems.Empty();
                DbEntityTable<QC_CheckItem> CheckItemView = new DbEntityTable<QC_CheckItem>();
                if (selectedVeh.MatCode == "16911" || selectedVeh.MatCode == "16912")
                { CheckItemView.LoadDataByWhere("CHECKITEMCODE in ('10001','10120','10011','10012')"); }
                else
                { CheckItemView.LoadDataByWhere("CHECKITEMCODE in ('10001','10002','10011','10012')"); }

                //DbEntityTable<QC_MatCheckItem_View> CheckItemView = new DbEntityTable<QC_MatCheckItem_View>();
                //CheckItemView.LoadDataByWhere("MatNCid=@MatNCid", curData.MatPK);
                foreach (var stdCheckItem in CheckItemView)
                {
                    QC_MixCheckItem item = new QC_MixCheckItem();
                    item.CheckItemNcId = stdCheckItem.CheckItemNcId;
                    item.CheckItemCode = stdCheckItem.CheckItemCode;
                    item.CheckItemName = stdCheckItem.CheckItemName;
                    item.CheckItemUnit = stdCheckItem.CheckItemUnit;
                    item.CheckGroupCode = stdCheckItem.CheckGroupCode;
                    //item.CheckGroupName = stdCheckItem.CheckGroupName;
                    //item.CheckGroupType = stdCheckItem.CheckGroupType;
                    //item.CkgShortWord = stdCheckItem.CkgShortWord;
                    item.Sample_Mix_ID = item.Sample_Mix_ID;
                    item.Source = "抽查样";
                    curData.CheckItems.Add(item);
                }
                //SetCheckItems();
                MessageBox.Show("加载完成");
            }
            else
            {

                MessageBox.Show("没有找到作业单信息");
            }

        }

        /// <summary>
        /// 车辆信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadVehData_Click(object sender, EventArgs e)
        {
            LoadBy();
        }


        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            QC_Sample_Mix sample = this.curData;
            veh.LoadDataByWhere("NoticeBillId=@NoticeBillId", this.curData.NoticeBillId);
            if (string.IsNullOrEmpty(sample.NoticeBillId))
            {
                MessageBox.Show("没有车辆信息，不能保存。");
                return;
            }

            if (string.IsNullOrEmpty(sample.CardID))
            {
                MessageBox.Show("还没有刷卡。");
                return;
            }
            if (veh.Count > 0)
            sample.WLLX = veh[0].WLLX;
            //if (veh[0].WLLX == "火运")
            //{ sample.NoticeBillId = veh[0].Sample_Veh_ID.ToString(); }
            sample.SampleType = SampleType.抽查样;
            sample.Sample_Cylx = this.Cylx;
            sample.MixCount = 1;
            sample.MixPlanCount = 1;

            sample.SampleState = SampleState.组批完成;
            sample.Sample_TBZD = true;

            sample.ShouTong_User = LocalInfo.Current.user.ID;
            sample.ShouTong_Time = DateTime.Now;
            if (sample.DataState == DataRowState.Added)
            {
                sample.MixUser = LocalInfo.Current.user.ID;
                sample.Mix_Time = DateTime.Now;
                examineSamples.Insert(0, sample);
            }
            sample.SaveCheckItems = true;
           
            sample.Save();
            btnUnBindCard.Visible = false;
            CreateSample();

            QC_Sample_Mix.UpdateInspectMainSample();

            MessageBox.Show("保存完成");

        }

        /// <summary>
        /// 新建抽查样
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateSample();
        }

        private void CreateSample()
        {
            curData = new QC_Sample_Mix();
            this.sourceCurData.DataSource = curData;

            //  SetCheckItems();

        }

        /// <summary>
        /// 查询
        /// </summary>
        private void tsmBtnQuery_Click(object sender, EventArgs e)
        {
            DlgQueryExamineSample dlg = new DlgQueryExamineSample();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.WhereSql != "")
                {
                    if (this.Cylx == "管理抽样")
                        examineSamples.LoadManageInpsectSamples(dlg.WhereSql);
                    else
                        examineSamples.LoadInpsectSamples(dlg.WhereSql);
                }
            }
        }

        //private void SetCheckItems()
        //{
        //    allCheckItem.Empty();
        //    foreach (var item in allCheckItem_back)
        //    {
        //        bool find = false;
        //        foreach (var ci in curData.CheckItems)
        //        {
        //            if (ci.CheckItemNcId == item.CheckItemNcId)
        //            {
        //                find = true;
        //                break;
        //            }
        //        }
        //        if (!find)
        //        {
        //            item.SetDataStateAsAdded();
        //            allCheckItem.Add(item);
        //        }
        //    }
        //}

        /// <summary>
        /// 修改抽查样
        /// </summary>
        private void tsmBtnUpdate_Click(object sender, EventArgs e)
        {
            QC_Sample_Mix selData = sourceAllInpsectSamples.Current as QC_Sample_Mix;
            if (selData != null)
            {
                selData.CheckItems.LoadDataByWhere("Sample_Mix_ID=@Sample_Mix_ID", selData.Sample_Mix_ID);
                this.curData = selData;
                this.sourceCurData.DataSource = this.curData;
                //SetCheckItems();
                curData.SaveEnable = false;
                btnUnBindCard.Visible = false;
            }
            else
            {
                MessageBox.Show("没有选中数据");
            }
        }

        /// <summary>
        /// 删除抽查样
        /// </summary>
        private void tsmBtnDelete_Click(object sender, EventArgs e)
        {
            QC_Sample_Mix selData = sourceAllInpsectSamples.Current as QC_Sample_Mix;
            if (selData != null)
            {
                int sampleState = Convert.ToInt32(DbContext.ExecuteScalar("Select SampleState From QC_Sample_Mix where Sample_Mix_ID=" + selData.Sample_Mix_ID));
                if (sampleState >= 3)
                {
                    MessageBox.Show("已经制样,不能再删除");
                    return;
                }
                if (MessageBox.Show("确实要删除此抽查样吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (selData == curData)
                    {
                        CreateSample();
                    }
                    sourceAllInpsectSamples.RemoveCurrent();
                    selData.SaveCheckItems = true;
                    examineSamples.Save();
                }
            }
            else
            {
                MessageBox.Show("没有选中数据", "提示");
            }
        }

        /// <summary>
        /// 扫卡
        /// </summary>
        public void HandleCardMessage(Device.CardReader device, string cardId)
        {
            if (string.IsNullOrEmpty(curData.NoticeBillId))
            {
                MessageBox.Show(string.Format("请先添加车辆消息"));
                return;
            }
            QC_IC_Info card = QC_IC_Info.FindByCardId(cardId);
            if (card == null)
            {
                Tb_IC ic = Tb_IC.GetByICNo(cardId);
                if (ic != null)
                {
                    MessageBox.Show(string.Format("此卡为车辆卡"));
                    return;
                }
                else
                {
                    MessageBox.Show(string.Format("此卡没有注册"));
                    return;
                }
            }
            if (card.CardType != QC_IC_Info.CardUseType_Mix)
            {
                MessageBox.Show("卡的类型不对");
                return;
            }
            if (card.SampleId > 0)
            {
                MessageBox.Show("此卡正在使用");
                return;
            }
            if (!string.IsNullOrEmpty(curData.CardID))
            {
                MessageBox.Show("已关联磁卡");
                return;
            }
            if (curData.WLLX == "精粉" && card.RegUser != "陈至立")
            {
                MessageBox.Show("精粉取样，需要刷黄扣");
              
                return;
            }
            if (curData.WLLX == "煤" && card.RegUser != "赵贺朝")
            {
                MessageBox.Show("煤取样，需要刷红扣");
             
                return;
            }
            curData.FangTong_User = LocalInfo.Current.user.ID;
            curData.FangTong_Time = DateTime.Now;
            curData.CardID = cardId;
            curData.SaveIcInfo = true;
            curData.IcInfo = card;
            btnUnBindCard.Visible = true;
        }

        /// <summary>
        /// 解除磁卡绑定
        /// </summary>
        private void btnUnBindCard_Click(object sender, EventArgs e)
        {
            curData.FangTong_User = "";
            curData.FangTong_Time = null;
            curData.CardID = "";
            if (curData.IcInfo != null)
            {
                curData.IcInfo.SampleId = 0;
            }
            btnUnBindCard.Visible = false;
        }

        private void 添加检验项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.curData != null)
            {
                List<string> filterIds = new List<string>();
                foreach (var item in curData.CheckItems)
                {
                    filterIds.Add(item.CheckItemNcId);
                }
                DlgCheckItem dlg = null;
                if (string.IsNullOrEmpty(this.curData.MatPK))
                    dlg = new DlgCheckItem(filterIds);
                else
                    dlg = new DlgCheckItem(filterIds, this.curData.MatPK);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.SelectedCheckItem != null)
                    {
                        QC_MixCheckItem qrc = new QC_MixCheckItem();
                        qrc.CheckItemNcId = dlg.SelectedCheckItem.CheckItemNcId;
                        qrc.CheckItemCode = dlg.SelectedCheckItem.CheckItemCode;
                        qrc.CheckItemName = dlg.SelectedCheckItem.CheckItemName;
                        qrc.CheckItemUnit = dlg.SelectedCheckItem.CheckItemUnit;
                        qrc.CheckGroupCode = dlg.SelectedCheckItem.CheckGroupCode;
                        qrc.SetDataStateAsAdded();
                        this.curData.CheckItems.Add(qrc);
                    }
                }
            }
            else
            {
                MessageBox.Show("没有选中数据", "提示");
            }
        }

        private void 删除检验项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QC_MixCheckItem selData = this.checkItemsBindingSource.Current as QC_MixCheckItem;
            if (selData != null)
            {
                if (MessageBox.Show("确实要删除吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.checkItemsBindingSource.RemoveCurrent();
                }
            }
            else
            {
                MessageBox.Show("没有选中数据", "提示");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (this.Cylx == "管理抽样")
                examineSamples.LoadManageInpsectSamples();
            else
                examineSamples.LoadInpsectSamples();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
