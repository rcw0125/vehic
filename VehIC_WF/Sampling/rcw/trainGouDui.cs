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

namespace VehIC_WF.Sampling.rcw
{
    public partial class trainGouDui : UserControl
    {
        public trainGouDui()
        {
            InitializeComponent();
        }
        public DbEntityTable<View_train_to_sample> trainData;
        /// <summary>
        /// 传输数据用
        /// </summary>
        public DbEntityTable<QC_Sample_Veh>  trans_train_sample;
        /// <summary>
        /// 等待勾选的火车
        /// </summary>
        public DbEntityTable<QC_Sample_Veh> sample_unselect=new DbEntityTable<QC_Sample_Veh>();
        /// <summary>
        /// 
        /// </summary>
        public DbEntityTable<QC_Sample_Veh> sample_selected  = new DbEntityTable<QC_Sample_Veh>();
        public DbEntityTable<View_arrivebill> arrivebill;
        public DbEntityTable<QC_Sample_Mix> printbill = new DbEntityTable<QC_Sample_Mix>();
        DbEntityTable<QC_Sample_Mix> mixDanHao = new DbEntityTable<QC_Sample_Mix>();
        /// <summary>
        /// 火车皮号
        /// </summary>
        public string hcph="";
        public string matname = "";
        public string ncdhd = "";
        private void trainGouDui_Load(object sender, EventArgs e)
        {

            refresh();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        public void refresh()
        {
            initdata();
            initview();
        }
        /// <summary>
        /// 从视图读取集中计量火车信息，保存到QC_Sample_Veh表中
        /// </summary>
        public void initdata()
        {
            trainData = new DbEntityTable<View_train_to_sample>();
            trainData.LoadData();
            //没有数据时，返回
            if (trainData.Count < 1)
            {
                return;
            }
            DbEntityTable<QC_Sample_Veh> veh = new DbEntityTable<QC_Sample_Veh>();
           
            foreach (var item in trainData)
            {
                QC_Sample_Veh sample = new QC_Sample_Veh();
                //物流的主键
                sample.FetchPlace = item.matchid;
                //发站
                sample.zpdh = item.FAZHAN;
                //物料名称
                sample.rwdh = item.WLMC;
                sample.VehNo = item.CPH;
                sample.CardID = item.HCPH;
                sample.begintime = item.GROSSTIME;
                sample.SampleState = Xg.Lab.Sample.SampleState.初始状态;
                sample.WLLX = "火运";
                veh.Add(sample);

            }
            veh.Save();

            //trans_train_sample = new DbEntityTable<QC_Sample_Veh>();
            //foreach (var item in trainData)
            //{
            //    QC_Sample_Veh sample = new QC_Sample_Veh();
            //    sample.Sample_Veh_ID = item.matchid;
            //    sample.FAZHAN = item.FAZHAN;
            //    sample.WLMC = item.WLMC;
            //    sample.VehNo = item.CPH;
            //    sample.CardID = item.HCPH;
            //    sample.begintime = item.GROSSTIME.ToString("yyyy-MM-dd HH:mm:ss");
            //    sample.SampleState = Xg.Lab.Sample.SampleState.初始状态;
            //    trans_train_sample.Add(sample);

            //}
            //trans_train_sample.Save();

        }
        /// <summary>
        /// 初始化窗体
        /// </summary>
        public void initview()
        {
            initArrivebill();
            initcmbHCPH();
            initTaskbill();
            initDanHao();


           // gridControl1.DataSource = sample_unselect;
        }

        public void initPrintbill()
        {
            printbill.LoadDataByWhere("main.samplestate = @samplestate and main.wllx=@wllx", Xg.Lab.Sample.SampleState.开始组批, "火运");
        }


        public void initDanHao()
        {
            mixDanHao.LoadDataByWhere("main.samplestate = @samplestate and main.wllx=@wllx and main.cardid='' and main.matpk in (SELECT   MATNCID  FROM  QC_Material WHERE WLLX = '煤') ", Xg.Lab.Sample.SampleState.组批完成, "火运");
            foreach (var item in mixDanHao)
            {
                item.StoreCode = QC_Sample_Mix.ShortStoreCode(item.StoreCode);
            }
            gridControl2.DataSource = mixDanHao;
        }
        /// <summary>
        /// 初始化任务单
        /// </summary>
        public void initTaskbill()
        {
          
            sample_selected.LoadDataByWhere("samplestate = @samplestate and wllx=@wllx", Xg.Lab.Sample.SampleState.开始组批, "火运");
            if (sample_selected.Count > 0)
            {
                hcph = sample_selected[0].CardID;
                matname = sample_selected[0].rwdh;
                ncdhd = sample_selected[0].NcDhdHeadNo;
                lbtask.Text = "等待取样的火车：" + hcph;
            }
            else
            {
                hcph = "";
                matname = "";
                ncdhd = "";
                lbtask.Text = "请勾选物料到货单！";
            }
        }
        /// <summary>
        /// 初始化火车皮号选择下拉框
        /// </summary>
        public void initcmbHCPH()
        {
            DbEntityTable<View_train> train_num = new DbEntityTable<View_train>();
            // train_num.LoadDataBySql("select distinct(cardid) from  QC_Sample_Veh where samplestate=@samplestate and wllx=@wllx", Xg.Lab.Sample.SampleState.初始状态,"火运");
            train_num.LoadDataBySql("select distinct(zpdh+'_'+rwdh) as cardid from  QC_Sample_Veh where samplestate=@samplestate and wllx=@wllx", Xg.Lab.Sample.SampleState.初始状态, "火运");
            cmbHCPH.DataSource = train_num;

            if (train_num.Count > 0)
            {
                cmbHCPH.SelectedIndex = 0;
            }
            else
            {
                cmbHCPH.Text = "";
                initHCgrid();
            }
            
        }
        /// <summary>
        /// 初始化集中计量火车表格
        /// </summary>
        public void initHCgrid()
        {
          
            if (cmbHCPH.Text.Trim() == "")
            {
                sample_unselect.LoadDataByWhere("wllx='火运' and samplestate=@samplestate order by begintime ", Xg.Lab.Sample.SampleState.初始状态);
            }
            else
            {
                string[] leibie = cmbHCPH.Text.Trim().Split('_');
                if (leibie.Count() != 2)
                {
                    return;
                }
                string fazhan = leibie[0].ToString();
                string wuliao = leibie[1].ToString();
                sample_unselect.LoadDataByWhere("wllx='火运' and samplestate=@samplestate and zpdh=@zpdh and rwdh=@rwdh order by fetchplace ", Xg.Lab.Sample.SampleState.初始状态,fazhan,wuliao);
            }
            gridControl1.DataSource = sample_unselect;
           // bstrain.DataSource = sample_unselect;


        }
        /// <summary>
        /// 初始化NC到货单
        /// </summary>
        public void initArrivebill()
        {
            arrivebill = new DbEntityTable<View_arrivebill>();
            arrivebill.LoadDataByWhere(" 1=1 order by vdef5,custname,invname,varrordercode desc");
            // gridControl3.DataSource = arrivebill;
            gridControl3.DataSource = arrivebill;
        }

      

       
        /// <summary>
        /// 勾兑火车物料到货单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkMat())
            {
                MessageBox.Show("请检查物料、到货单，必须是同一物料、同一到货单","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            //var view = gridView1;

            //if (view.RowCount < 1)
            //{
            //    MessageBox.Show("没有火车，请稍后刷新");
            //    return;
            //}

            //QC_Sample_Veh train = view.GetRow(0) as QC_Sample_Veh;
            //var hc= train.CardID;

            //if (hcph != "" && hc != hcph)
            //{
            //    MessageBox.Show("请先取样："+hcph);
            //    return;
            //}

            var view3 = gridView3;
            View_arrivebill bill = view3.GetFocusedRow() as View_arrivebill;
            if (bill == null)
            {
                MessageBox.Show("没有NC到货单！");
                return;
            }

            foreach (var item in sample_unselect)
            {
                if (item.zp)
                {
                    //状态 0 改变成1 
                    item.SampleState = Xg.Lab.Sample.SampleState.开始组批;
                    item.WpCode = "HYQY";
                    item.MatCode = bill.invcode;
                    item.MatPK = bill.cbaseid;
                    item.NcDhdHeadNo = bill.varrordercode;
                    item.SupplierCode = bill.custcode;
                    //取样人
                    item.FetchPerson = LocalInfo.Current.user.ID;
                    //取样时间
                    item.FetchTime = DateTime.Now;
                }
            }
            sample_unselect.Save();
            initview();
            //gridControl1.DataSource = trainData;
        }

      
       

        /// <summary>
        /// 如果有未打印的任务单，控制必须是同一种物料，同一个到货单
        /// </summary>
        /// <param name="hcph"></param>
        /// <returns></returns>
        public bool checkMat()
        {
            var view = gridView1;
            if (view.RowCount < 1)
            {
                return false;               
            }
            QC_Sample_Veh train = view.GetRow(0) as QC_Sample_Veh;
            string hc = train.CardID;
            string mat = train.rwdh;
            //gridcontrol列表内选择的是同一种物料
            for (int i = 0; i < view.RowCount; i++)
            {
                if (view.IsGroupRow(i))
                    continue;
                var entity = view.GetRow(i) as QC_Sample_Veh;
                if (entity.rwdh != mat&&entity.zp)
                {
                    return false;
                }
            }
            //选择的和任务单不是同一个火车
            //if (hcph != ""&&hcph!=hc)
            //{
            //    return false;
            //}
            if (matname != "" && matname != mat)
            {
                return false;
            }

           //判断是否是同一张到货单
            if (ncdhd != "")
            {
                var viewdhd = gridView3;
                if (viewdhd.RowCount < 1)
                {
                    return false;
                }
                View_arrivebill dhd = viewdhd.GetFocusedRow() as View_arrivebill;
                if (ncdhd != dhd.varrordercode)
                {
                    return false;
                }

            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Zhc.Data.DbContext.Create<QC_Sample_Veh>(false);
        }

        private void cmbHCPH_SelectedIndexChanged(object sender, EventArgs e)
        {
            initHCgrid();
            if (gridView3.RowCount > 0)
            {
                gridView3.FocusedRowHandle = gridView3.GetRowHandle(selectdhd());
            }
           
        }

        public int selectdhd()
        {
            try 
            {
                var view = gridView1;
                if (view.RowCount < 1)
                {
                    return 0;
                }

                QC_Sample_Veh train = view.GetRow(0) as QC_Sample_Veh;
                string fazhan = train.zpdh;

                var viewdhd = gridView3;
                for (int i = 0; i < viewdhd.RowCount; i++)
                {
                    if (view.IsGroupRow(i))
                        continue;
                    var entity = viewdhd.GetRow(i) as View_arrivebill;
                    if (entity.vdef5 == fazhan)
                    {
                        return i;
                    }
                }
                return 0;
            
            }
            catch
            {
                return 0;
            }
           

        }
       

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            selectAll();
        }

        /// <summary>
        /// 刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            refresh();
        }
        /// <summary>
        /// 添加行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            View_arrivebill select_arrivebill = bsarrivebill.Current as View_arrivebill;
            ////MessageBox.Show(select_arrivebill.varrordercode);
            //MessageBox.Show(gridView1.RowCount.ToString());
            //gridView1.GetRow(0);

         


        }
        /// <summary>
        /// 全选操作
        /// </summary>
        public void selectAll()
        {
            //全选操作之前，先取消所有项选中
            foreach (var item in sample_unselect)
            {
                if (item.zp)
                {
                    item.zp = false;
                }
            }
            var view = gridView1;
            for (int i = 0; i < view.RowCount; i++)
            {
                if (view.IsGroupRow(i))
                    continue;
                var entity = view.GetRow(i) as QC_Sample_Veh;
                entity.zp = true;
            }

        }


        /// <summary>  
       /// 获取GridView过滤或排序后的数据集  
       /// </summary>  
       /// <typeparam name="T">泛型对象</typeparam>  
       /// <param name="view">GridView</param>  
       /// <returns></returns>  
       public IEnumerable<T> GetGridViewFilteredAndSortedData<T>(DevExpress.XtraGrid.Views.Grid.GridView view) where T : class
        {
            var list = new List<T>();
            for (int i = 0; i < view.RowCount; i++)
            {
                if (view.IsGroupRow(i))
                    continue;
                var entity = view.GetRow(i) as T;
                if (entity == null)
                    continue;
                list.Add(entity);
            }
            return list;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {

        }

        //抽取
        private void button8_Click(object sender, EventArgs e)
        {
            if (sample_selected.Count > 0)
            {
                MessageBox.Show("已勾选其他物料，请先处理");
                return;
            }
            int  cq = 0;
            long vehno = 0;
            sampleNum sm = new sampleNum();
            sm.showDialogEx("ChouQu");
            if (sm.DialogResult != DialogResult.OK)
            {
                MessageBox.Show("没有确认取样的个数");
                return;
            }
            else
            {
               
                cq = sm.chouNum;
                vehno = sm.vehno;
            }

            if ((cq == 0))
            {
                MessageBox.Show("没有确认取样的个数");
                return;
            }
            if ((vehno == 0))
            {
                MessageBox.Show("没有输入车号");
                return;
            }

            sample_selected.LoadDataByWhere("vehno=@vehno order by fetchtime desc",vehno.ToString());

            if (sample_selected.Count < 1)
            {
                MessageBox.Show("输入的车号不存在！！");
                return;
            }
           

            DbEntityTable<QC_Sample_Mix> qc = new DbEntityTable<QC_Sample_Mix>();

            for (int i = 0; i < cq; i++)
            {
                QC_Sample_Mix mix = new QC_Sample_Mix();
                mix.WpCode = "Huoyun";
                mix.MatCode = sample_selected[0].MatCode;
                mix.MatPK = sample_selected[0].MatPK;
                mix.Mix_Time = DateTime.Now;
                mix.FangTong_Time = DateTime.Now;
                mix.ShouTong_Time = DateTime.Now;
                mix.ShouTong_User = LocalInfo.Current.user.ID;
                mix.FangTong_User = LocalInfo.Current.user.ID;
                mix.MixCount = sample_selected.Count;
                mix.MixPlanCount = sample_selected.Count;
                mix.SupplierCode = sample_selected[0].SupplierCode;
                mix.MixUser = LocalInfo.Current.user.ID;
                mix.SampleState = SampleState.开始组批;
                mix.SampleType = SampleType.抽查样;
                mix.WLLX = sample_selected[0].WLLX;
                mix.StoreCode = Zhc.Data.DbContext.GetSeq("HY" + DateTime.Now.Date.ToString("yyyyMMdd"), 2);
                mix.MainSampleMixId = sample_selected[0].Sample_Mix_ID;
                qc.Add(mix);
               

            }
            qc.Save();
            print();

            //sample_selected[0].Sample_Mix_ID = mix.Sample_Mix_ID;
            //sample_selected[0].Mix_Time = DateTime.Now;
            //sample_selected[0].SampleType = SampleType.抽查样;
            //sample_selected[0].SampleState = SampleState.组批完成;
            //sample_selected[0].Save();







        }

        /// <summary>
        /// 打印取样任务单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {

            quYang("quyang");
            print();

        }


        public void quYang(string type)
        {

            if (sample_selected.Count < 1)
            {
                MessageBox.Show("没有勾选物料");
                return;
            }

            int jq = 0, sq = 0;
            sampleNum sm = new sampleNum();
            sm.showDialogEx(type);
            if (sm.DialogResult != DialogResult.OK)
            {
                MessageBox.Show("没有确认取样的个数");
                return;
            }
            else
            {
                jq = sm.autoNum;
                sq = sm.manuNum;
                //cq = sm.chouNum;
            }

            if ((jq == 0) && (sq == 0))
            {
                MessageBox.Show("没有确认取样的个数");
                return;
            }
         

            int mixid = 0;
            IDbConnection conn = DbContext.GetDefaultConnection();
            conn.Open();
            IDbTransaction trans = conn.BeginTransaction();
            try

            {

                

                for (int i = 0; i < jq; i++)
                {
                    QC_Sample_Mix mix = new QC_Sample_Mix();
                    mix.WpCode = "Huoyun";
                    mix.MatCode = sample_selected[0].MatCode;
                    mix.MatPK = sample_selected[0].MatPK;
                    mix.Mix_Time = DateTime.Now;
                    mix.FangTong_Time = DateTime.Now;
                    mix.ShouTong_Time = DateTime.Now;
                    mix.ShouTong_User = LocalInfo.Current.user.ID;
                    mix.FangTong_User = LocalInfo.Current.user.ID;
                    mix.MixCount = sample_selected.Count;
                    mix.MixPlanCount = sample_selected.Count;
                    mix.SupplierCode = sample_selected[0].SupplierCode;
                    mix.MixUser = LocalInfo.Current.user.ID;
                    mix.SampleState = SampleState.开始组批;
                    mix.SampleType = SampleType.机器取样;
                    mix.WLLX = sample_selected[0].WLLX;
                    mix.StoreCode = Zhc.Data.DbContext.GetSeq("HY" + DateTime.Now.Date.ToString("yyyyMMdd"), 2);
                    mix.MainSampleMixId = mixid;
                    mix.Save(trans);
                    if (mixid == 0)
                    {
                        foreach (var veh in sample_selected)
                        {
                            veh.Sample_Mix_ID = mix.Sample_Mix_ID;
                            veh.Mix_Time = DateTime.Now;
                            veh.SampleState = SampleState.组批完成;
                            veh.SampleType = SampleType.机器取样;
                            veh.Save(trans);
                        }
                        mixid = mix.Sample_Mix_ID;
                    }



                }

                for (int i = 0; i < sq; i++)
                {
                    QC_Sample_Mix mix = new QC_Sample_Mix();
                    mix.WpCode = "Huoyun";
                    mix.MatCode = sample_selected[0].MatCode;
                    mix.MatPK = sample_selected[0].MatPK;
                    mix.Mix_Time = DateTime.Now;
                    mix.FangTong_Time = DateTime.Now;
                    mix.ShouTong_Time = DateTime.Now;
                    mix.ShouTong_User = LocalInfo.Current.user.ID;
                    mix.FangTong_User = LocalInfo.Current.user.ID;
                    mix.MixCount = sample_selected.Count;
                    mix.MixPlanCount = sample_selected.Count;
                    mix.SupplierCode = sample_selected[0].SupplierCode;
                    mix.MixUser = LocalInfo.Current.user.ID;
                    mix.SampleState = SampleState.开始组批;
                    mix.SampleType = SampleType.人工取样;
                    mix.WLLX = sample_selected[0].WLLX;
                    mix.StoreCode = Zhc.Data.DbContext.GetSeq("HY" + DateTime.Now.Date.ToString("yyyyMMdd"), 2);
                    mix.MainSampleMixId = mixid;
                    mix.Save(trans);
                    if (mixid == 0)
                    {
                        foreach (var veh in sample_selected)
                        {
                            veh.Sample_Mix_ID = mix.Sample_Mix_ID;
                            veh.Mix_Time = DateTime.Now;
                            veh.SampleState = SampleState.组批完成;
                            veh.SampleType = SampleType.人工取样;
                            veh.Save(trans);
                        }
                        mixid = mix.Sample_Mix_ID;
                    }


                }
                trans.Commit();
                conn.Close();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                conn.Close();
                MessageBox.Show("出现异常,重新操作："+ex.ToString());
                return;

            }



            print();


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
                Font f2 = new System.Drawing.Font("宋体", 8f, FontStyle.Bold);
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

                       // float leftMargin2 = rect.Left + (rect.Width - itemSize.Width) / 2;
                        float leftMargin2 = rect.Left;
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
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            List<ZupiData> printData = new List<ZupiData>();

            foreach (var mix in printbill)
            {
                List<string> vehnos = new List<string>();
                DbEntityTable<QC_Sample_Veh> vehs = new DbEntityTable<QC_Sample_Veh>();
                vehs.LoadDataByWhere("main.Sample_Mix_ID=@Sample_Mix_ID order by begintime", mix.Sample_Mix_ID);
                //vehnos.Add(mix.SupplierName);
                vehnos.Add(mix.MatName);

                //if (mix.SampleType == SampleType.人工取样)
                //{
                //    vehnos.Add("人取"+"共" + vehs.Count+"车");
                //}
                //else if (mix.SampleType == SampleType.机器取样)
                //{
                //    vehnos.Add("机取" + "共" + vehs.Count + "车");
                //}
                //else if (mix.SampleType == SampleType.抽查样)
                //{
                //    vehnos.Add("抽查" + "共" + vehs.Count + "车");
                //}

                if (vehs.Count > 0)
                {
                    if (mix.SampleType == SampleType.人工取样)
                    {
                        vehnos.Add("人取" + "共" + vehs.Count + "车");
                    }
                    else if (mix.SampleType == SampleType.机器取样)
                    {
                        vehnos.Add("机取" + "共" + vehs.Count + "车");
                    }
                    else if (mix.SampleType == SampleType.抽查样)
                    {
                        vehnos.Add("抽查" + "共" + vehs.Count + "车");
                    }
                }
                else
                {
                    if (mix.SampleType == SampleType.人工取样)
                    {
                        vehnos.Add("人取");
                    }
                    else if (mix.SampleType == SampleType.机器取样)
                    {
                        vehnos.Add("机取");
                    }
                    else if (mix.SampleType == SampleType.抽查样)
                    {
                        vehnos.Add("抽查");
                    }
                
                }

                if (vehs.Count > 0)
                {
                    vehnos.Add(vehs[0].VehNo+"->" + vehs[vehs.Count-1].VehNo);
                }

                //if (vehs.Count >0)
                //{
                //    vehnos.Add("共" + vehs.Count+"车");
                //}

                //foreach (var item in vehs)
                //{
                //    vehnos.Add(item.VehNo);

                //}

                if (vehnos.Count > 0)
                {
                    //ZupiData zd = new ZupiData();
                    //zd.Head = QC_Sample_Mix.ShortStoreCode(mix.CardID);
                    //zd.ZupiItems = vehnos;
                    //printData.Add(zd);
                    ZupiData pbzd = new ZupiData();
                    //编号
                    //pbzd.Head = QC_Sample_Mix.ShortStoreCode("HY" + mix.CardID.Remove(0, 2));
                    pbzd.Head = QC_Sample_Mix.ShortStoreCode(mix.StoreCode);
                    pbzd.ZupiItems = vehnos;
                    printData.Add(pbzd);
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

        public void print()
        {
            initPrintbill();
            //printPreviewDialog1.ShowDialog();
            printDocument1.Print();
            //打印完成后，大样状态从开始组批变为组批完成
            foreach (var mix in printbill)
            {
                mix.SampleState = SampleState.组批完成;

            }
            printbill.Save();
            //刷新任务单
            initTaskbill();
        }

        /// <summary>
        /// 异常补打
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            exceptBill();
            printPreviewDialog1.ShowDialog();
            //printDocument1.Print();                    
            //刷新任务单
            initTaskbill();
        }

        public void exceptBill()
        {
            initPrintbill();
            if (printbill.Count > 0)
            {
                return;
            }

            DbEntityTable<QC_Sample_Mix> temp = new DbEntityTable<QC_Sample_Mix>();
            temp.LoadDataByWhere("main.samplestate = @samplestate and main.wllx=@wllx order by SAMPLE_MIX_ID desc", Xg.Lab.Sample.SampleState.组批完成, "火运");
            if (temp.Count < 1)
            {
                return;
            }
            int sid = temp[0].MainSampleMixId;
            printbill.Clear();
            
                if (sid == 0)
                {
                   
                        printbill.Add(temp[0]);                   
                }
                else
                {

                  for (int i = 0; i < temp.Count; i++)
                  {
                    if (temp[i].Sample_Mix_ID >= sid)
                    {
                        printbill.Add(temp[i]);
                    }

                   }
                }
        }

        private void gridView1_CustomDrawRowIndicator_1(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认要进行重新勾兑吗","确认", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            if (hcph!= "")
            {
                MessageBox.Show("请先打印已勾选的火车");
                return;
            
            }

            if (cmbHCPH.Text.Trim() == "")
            {
                MessageBox.Show("请输入火车勾号");
                return;
            }
            //else
            //{
            //    sample_unselect.LoadDataByWhere("wllx='火运' and  cardid=@cardid  order by begintime", cmbHCPH.Text.Trim());
            //}

            //foreach (var item in sample_unselect)
            //{
            //    item.SampleState = Xg.Lab.Sample.SampleState.初始状态;
            //    item.WpCode = "";
            //    item.MatCode = "";
            //    item.MatPK = "";
            //    item.NcDhdHeadNo = "";
            //    item.SupplierCode = "";
            //    //取样人
            //    item.FetchPerson = LocalInfo.Current.user.ID;
            //    //取样时间
            //    item.FetchTime = DateTime.Now;
            //    item.zp = false;
            //}
            //sample_unselect.Save();

          


            //bstrain.DataSource = sample_unselect;


            if (!checkMat())
            {
                MessageBox.Show("请检查物料、到货单，必须是同一物料、同一到货单");
                return;
            }


            var view3 = gridView3;
            View_arrivebill bill = view3.GetFocusedRow() as View_arrivebill;
            if (bill == null)
            {
                MessageBox.Show("没有NC到货单！");
                return;
            }

            foreach (var item in sample_unselect)
            {
                if (item.zp)
                {
                    //item.SampleState = Xg.Lab.Sample.SampleState.开始组批;
                    //item.WpCode = "HYQY";
                    item.MatCode = bill.invcode;
                    item.MatPK = bill.cbaseid;
                    item.NcDhdHeadNo = bill.varrordercode;
                    item.SupplierCode = bill.custcode;
                    //取样人
                    item.FetchPerson =item.FetchPerson+"~~"+ LocalInfo.Current.user.ID;
                    //取样时间
                    item.FetchTime = DateTime.Now;
                }
            }
            sample_unselect.Save();

            DbEntityTable<QC_Sample_Mix> dbmix = new DbEntityTable<QC_Sample_Mix>();
            dbmix.LoadDataByWhere("main.sample_mix_id in ( select distinct(sample_mix_id) from qc_sample_veh where cardid='" + cmbHCPH.Text.Trim() + "')");
            foreach (var item in dbmix)
            {
                //item.SampleState = SampleState.处理完成;
                item.MatCode = bill.invcode;
                item.MatPK = bill.cbaseid;
                item.SupplierCode = bill.custcode;
            }

            dbmix.Save();
            initview();
            MessageBox.Show("操作成功！");

        }

        private void cmbHCPH_KeyDown(object sender, KeyEventArgs e)
        {
            //if (cmbHCPH.Text.Trim() == "")
            //{
            //    MessageBox.Show("请输入火车勾号");
            //    return;
            //}
            //else
            //{
            //    sample_unselect.LoadDataByWhere("wllx='火运' and  cardid=@cardid  order by begintime", cmbHCPH.Text.Trim());
            //}
        }

        public string CardID="";
        public void HandleCardMessage(Device.CardReader device, string cardId)
        {

            CardID = cardId;

            DbEntityTable<QC_IC_Info> hycrds = new DbEntityTable<QC_IC_Info>();
            hycrds.LoadDataByWhere("CardID=@CardID and CardType=@CardType ", CardID, "CUT002");

            if (hycrds.Count == 0)
            {
                CardID = "";
                label2.Text = "该卡类型不对!";
                label2.ForeColor = Color.Red;
            }

            foreach (var qcic in hycrds)
            {
                if (qcic.SampleId == 0)
                {
                  
                    label2.Text = System.DateTime.Now + "扫卡成功!";

                    label2.ForeColor = Color.Red;
                }
                else
                {
                    label2.Text = "该卡已经使用!";
                    label2.ForeColor = Color.Red;
                    CardID = "";
                }
            }

          

            //icCard.SampleId = 0;

            //IDbConnection conn = DbContext.GetDefaultConnection();
            //conn.Open();
            //IDbTransaction trans = conn.BeginTransaction();
            //icCard.Save(trans);
            //tempLab.Save(trans);
            //trans.Commit();
            //conn.Close();

         

        }
        /// <summary>
        /// 绑扣
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            if (CardID == "")
            {
                MessageBox.Show("请刷卡");
                return;
            }

            DbEntityTable<QC_IC_Info> hycrds = new DbEntityTable<QC_IC_Info>();
            hycrds.LoadDataByWhere("CardID=@CardID and CardType=@CardType ", CardID, "CUT002");

            if (hycrds.Count == 0)
            {
                CardID = "";
                label2.Text = "该卡类型不对!";
                label2.ForeColor = Color.Red;
                return;
            }

           

            var view = gridView2;
            if (mixDanHao.Count < 1)
            {
                MessageBox.Show("没有大样单号！请刷新");
                return;
            }
            QC_Sample_Mix bill = view.GetFocusedRow() as QC_Sample_Mix;
            if (bill == null)
            {
                MessageBox.Show("没有大样单号！");
                return;
            }
            bill.CardID = CardID;
            bill.StoreCode = QC_Sample_Mix.FullStoreCode(bill.StoreCode);
          

            IDbConnection conn = DbContext.GetDefaultConnection();
            conn.Open();
            IDbTransaction trans = conn.BeginTransaction();
            bill.Save(trans);
            foreach (var qcic in hycrds)
            {
                qcic.SampleId = bill.Sample_Mix_ID;
               
            }
            hycrds.Save(trans);
            trans.Commit();
            conn.Close();

            //foreach (var item in mixDanHao)
            //{
            //    if (item.Sample_Mix_ID == bill.Sample_Mix_ID)
            //    {
            //        item.CardID = CardID;
            //        item.StoreCode = QC_Sample_Mix.FullStoreCode(bill.StoreCode);
            //        break;
            //    }
            //}
            //mixDanHao.Save();
            initDanHao();


        }
    }
}
