namespace VehIC_WF.WorkPoint
{
   
    using DevExpress.Utils;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using VehIC_BL;
    using VehIC_WF;
    using VehIC_WF.AuthService;
    using VehIC_WF.CommonService;
    using VehIC_WF.ICCardManageService;
    using VehIC_WF.Properties;
    using VehIC_WF.SamplingService;
    using VehIC_WF.Utility;
    using Zhc.Data;
    using System.Data;
    using Xg.Lab.Sample;
    using VehIC_WF.Sampling.Sample;
    using System.Collections.Generic;
    using Xg.Tools;

    using System.Net;
    using System.Text;
    using System.IO;
    using VehIC_WF.Sampling;
    using VehIC_WF.Sampling.czl.WorkPoint;
    public class WP_Sampling : UserControl,ICardMessage
    {
        public Boolean matQuYang = false;
        public VehIC_WF.AuthService.AuthService ath;
        private Button btn_cancel;
        private Button btn_ok;
        public VehIC_WF.ICCardManageService.ICCard card = null;
        public VehIC_WF.CommonService.CommonService commonservice;
        private IContainer components = null;
        private string curitemid = string.Empty;
        public VehIC_WF.CommonService.NoticeBill curnotice = null;
      
        private ImageList imageList1;
        private Label label12;
        private Label label2;
        private Label label3;
        private Label label9;
        public string lastrecmsg = string.Empty;
        public long lastrectime = 0L;
        public int limitpos = 0;
        private Panel panel1;
        private Panel panel2;
   
        private TabControl tabControl1;
        private TabPage tabPage1;
        public int timelimit = 15;
        private TextBox txt_billno;
        private TextBox txt_gys;
        private TextBox txt_wl;
        private Label label7;
        private Label label5;
        private Label label8;
        private TextBox kouza;
        private TextBox koushui;
        private Label label15;
        private Label label13;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private BindingSource qCSampleVehBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn 物料类型;
        private TextBox textBox1;
        private Label label1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
        private PrintDialog printDialog1;
        private Button 选择物料;
        private Button 选择供应商;
        private ComboBox txt_vehno;
        private Button 查询;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 打印合金取样单;
        private Label 外矿大样位置号;
        private CheckBox kuaiyang;
    

        public WP_Sampling()
        {
            this.InitializeComponent();
        }

      
        /// <summary>
        /// 取消刷卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancel_Click(object sender, EventArgs e)
        {
         
            //if (cheCardid != "")
            //{ DbContext.ExeSql("update tb_noticebill_head set status='0' where status=1 and icno=@cheCardid", cheCardid); }
            cheCardid = "";
            txt_billno.Text = null;
            txt_vehno.Text = null;
            txt_gys.Text = null;
            txt_wl.Text = null;
            nbill = null;
            CardID = "";
        }

       
        public string hjdh = "";
        /// <summary>
        /// 取样确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        DbEntityTable<QC_Sample_Mix> wkmixs = new DbEntityTable<QC_Sample_Mix>();
        private void btn_ok_Click(object sender, EventArgs e)
        {

            if (txt_vehno.Text.Length > 4 && nbill.CUSTCODE != "" && nbill.INVCODE != "")
            {
                if (nbill.NoticeId == "")
                {
                    nbill.NoticeId = Zhc.Data.DbContext.GetSeq("NO" + DateTime.Now.Date.ToString("yyyyMMdd"), 2);
                    nbill.NoticeBodyId = nbill.NoticeId;
                    nbill.Cph = txt_vehno.Text;
                }

                DbEntityTable<QC_Material> mat = new DbEntityTable<QC_Material>();

                if (CardID == "")
                {

                    if (matQuYang == false && nbill != null)
                    {
                        mat.LoadDataByWhere("inv.INVCODE=@MatCode", nbill.INVCODE);
                        //向集中计量返回状态
                        string strURL = "http://192.168.2.42:7080/MeasureService/qualityInterface/returnsampleflag.do?matchid=" + this.nbill.NoticeId + "&sampleunitcode=" + FrmMain.localinfo.workpoint.Code + "&sampleunitname=" + FrmMain.localinfo.workpoint.Name + "&cph=" + this.nbill.Cph + "&icno=" + cheCardid + "&samplercode=" + LocalInfo.Current.user.ID + "&samplername=" + LocalInfo.Current.user.Name + "&deduction=" + StringTool.FNumVal(koushui.Text) + "&deduction2=" + StringTool.FNumVal(kouza.Text);
                        System.Net.HttpWebRequest request;
                        request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
                        System.Net.HttpWebResponse response = null;
                        try
                        {
                            response = (System.Net.HttpWebResponse)request.GetResponse();
                        }
                        catch (Exception exception)
                        {
                            Encoding encode = Encoding.GetEncoding("gb2312");
                            File.WriteAllText(@".\log\" + nbill.Cph + ".xml", exception.ToString(), encode);
                        }
                        System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        string responseText = myreader.ReadToEnd();
                        myreader.Close();
                        String str = responseText.Split(',')[0].Substring(responseText.Split(',')[0].Length - 4);
                        //String str = "true";
                        if (str == "true")
                        {
                            DbContext.ExeSql("update tb_noticebill_head set status=2 where status=0 and icno=@cheCardid and noticebillid=@noticebillid", cheCardid, nbill.NoticeId);

                            if (FrmMain.localinfo.workpoint.Code == "JFQY" || FrmMain.localinfo.workpoint.Code == "JMQY" || FrmMain.localinfo.workpoint.Code == "HJQY" || FrmMain.localinfo.workpoint.Code == "JTQY")
                            {
                                QC_Sample_Veh sm = new QC_Sample_Veh();
                                sm.WpCode = FrmMain.localinfo.workpoint.Code;       //作业点编码
                                sm.FetchPerson = LocalInfo.Current.user.ID;                 //取样人ID
                                sm.VehNo = this.nbill.Cph;                     //车牌号晩

                                sm.CardID = CardID;                    //磁卡号  目前先用进门磁卡的卡号代替
                                sm.NoticeBillId = this.nbill.NoticeId;            //磁卡作业单号
                                sm.Sample_Mix_ID = 0;                               //混样ID
                                sm.FetchTime = System.DateTime.Now;                 //取样时间
                                sm.KouShui = StringTool.FNumVal(koushui.Text);
                                sm.KouZa = StringTool.FNumVal(kouza.Text);
                                if (mat != null)
                                    sm.WLLX = mat[0].WLLX;
                                if (sm.WLLX == "合金" || sm.WLLX == "外矿" || sm.WLLX == "焦炭" || sm.WLLX == "熔剂")
                                { sm.SampleState = SampleState.初始状态; }
                                else { sm.SampleState = SampleState.组批完成; }
                                sm.NcDhdBodyId = this.nbill.NcDhdBodyId;  //车辆作业单主键
                                sm.MatCode = this.nbill.INVCODE;      //物料编码

                                sm.SupplierCode = this.nbill.CUSTCODE;  //供应商编码

                                sm.MatPK = this.nbill.PK_INVBASDOC;         //物料主键

                                if (sm.NcDhdBodyId != "")
                                {
                                    object result = DbContext.ExecuteScalar("select djno from tb_dhd_body where carriveorder_bid='" + sm.NcDhdBodyId + "'");
                                    if (result != null && result != DBNull.Value)
                                    {
                                        sm.NcDhdHeadNo = Convert.ToString(result);             //NC到货单
                                    }
                                    object resultbill = DbContext.ExecuteScalar("select carriveorder_bid from tb_dhd_body where carriveorder_bid='" + sm.NcDhdBodyId + "'");
                                    if (resultbill != null && resultbill != DBNull.Value)
                                    {
                                        sm.NcDhdBodyId = Convert.ToString(resultbill);             //NC到货单
                                    }

                                    xysamples.LoadDataByWhere("main.NcDhdBodyId=@NcDhdBodyId", sm.NcDhdBodyId);
                                    foreach (var xycard in xysamples)
                                    {

                                        label8.Text = System.DateTime.Now.ToString("HH:mm:ss") + "该车已取样";
                                        return;

                                    }
                                    if (sm.WLLX == "合金")
                                    {
                                        sm.CardID = Zhc.Data.DbContext.GetSeq("H" + DateTime.Now.Date.ToString("yyyyMMdd"), 2);
                                        hjdh = sm.CardID;

                                    }

                                    sm.Save();
                                    if (sm.WLLX == "合金")
                                    {
                                        cph = this.nbill.Cph;
                                        head = QC_Sample_Mix.ShortStoreCode(hjdh);
                                        body = cph;
                                        if (sm.MatCode == "13314")
                                            body1 = this.nbill.INVNAME + "-06";
                                        else if (sm.MatCode == "13316")
                                            body1 = this.nbill.INVNAME + "-05";
                                        else if (sm.MatCode == "13317")
                                            body1 = this.nbill.INVNAME + "-01";
                                        else if (sm.MatCode == "13318")
                                            body1 = this.nbill.INVNAME + "-02";
                                        else if (sm.MatCode == "13321")
                                            body1 = this.nbill.INVNAME + "-04";
                                        else if (sm.MatCode == "13331")
                                            body1 = this.nbill.INVNAME + "-03";
                                        else if (sm.MatCode == "13332")
                                            body1 = this.nbill.INVNAME + "-07";
                                        else if (sm.MatCode == "12612")
                                            body1 = this.nbill.INVNAME + "-01";
                                        else if (sm.MatCode == "12613")
                                            body1 = this.nbill.INVNAME + "-02";
                                        else if (sm.MatCode == "12614")
                                            body1 = this.nbill.INVNAME + "-03";
                                        else if (sm.MatCode == "12615")
                                            body1 = this.nbill.INVNAME + "-04";
                                        else if (sm.MatCode == "12616")
                                            body1 = this.nbill.INVNAME + "-05";
                                        else if (sm.MatCode == "12619")
                                            body1 = this.nbill.INVNAME + "-06";
                                        else body1 = this.nbill.INVNAME;
                                        body2 = this.nbill.CUSTNAME;
                                        //    printDocument1.Print();
                                        this.printPreviewDialog1.ShowDialog();
                                    }
                                }
                                else { sm.Save(); }

                            }
                            hjdh = "";
                            txt_billno.Text = null;
                            txt_vehno.Text = null;
                            txt_gys.Text = null;
                            txt_wl.Text = null;
                            nbill = null;
                            CardID = "";
                            MixCardID = "";
                            外矿大样位置号.Text = "";
                            cheCardid = "";
                            koushui.Text = "";
                            kouza.Text = "";
                            cph = "";
                            head = "";
                            body = "";
                            body1 = "";
                            body2 = "";

                            qyts ts1 = new qyts("非煤样取样成功！");
                            ts1.ShowDialog();
                        }
                        else if (str == "fals")
                        {
                            DbContext.ExeSql("update tb_noticebill_head set status=3 where status=0 and icno=@cheCardid", cheCardid);
                            qyts ts1 = new qyts("非煤样取样失败！");
                            ts1.ShowDialog();
                        }
                        else
                        {

                            DbContext.ExeSql("update tb_noticebill_head set status=4 where status=0 and icno=@cheCardid", cheCardid);
                            qyts ts1 = new qyts("非煤样取样失败！");
                            ts1.ShowDialog();
                        }

                    }
                    if (matQuYang)
                    {

                        MessageBox.Show("没有关联取样卡，请绑定取样卡后操作");
                        // if (MessageBox.Show("没有关联取样卡，是否继续", "询问", MessageBoxButtons.YesNo) == DialogResult.No)
                        //{
                        return;
                        //}
                    }

                }



                else
                {

                    if (!isNumberic(koushui.Text) && koushui.Text != "")
                    {

                        qyts ts1 = new qyts("扣水输入了非数字字符,请核实！");
                        ts1.ShowDialog();
                        return;
                    }
                    if (!isNumberic(kouza.Text) && kouza.Text != "")
                    {

                        qyts ts1 = new qyts("扣杂输入了非数字字符,请核实！");
                        ts1.ShowDialog();
                        return;
                    }
                    if (kuaiyang.Checked == true)     //如果是快样
                    {
                        //刷的小样卡
                        xycards.LoadDataByWhere("CardID=@CardID and CardType=@CardType", CardID, QC_IC_Info.CardUseType_Veh);
                        foreach (var x in xycards)
                        {
                            label8.Text = "快样需要刷大桶卡";

                            qyts ts1 = new qyts("快样需要刷红色卡,请核实！");
                            ts1.ShowDialog();
                            return;
                        }
                        //2016-1-29
                        if (matQuYang)
                        {
                            qyky();
                            nbill = null;
                            //  DbContext.ExeSql("update tb_noticebill_head set status=1 where status=0 and icno=@cheCardid", cheCardid);
                            txt_billno.Text = null;
                            txt_vehno.Text = null;
                            txt_gys.Text = null;
                            txt_wl.Text = null;
                            nbill = null;
                            CardID = "";
                            cheCardid = "";
                            MixCardID = "";
                            外矿大样位置号.Text = "";
                            koushui.Text = "";
                            kouza.Text = "";
                            kuaiyang.Checked = false;
                        }

                    }
                    else
                    {
                        xycards.LoadDataByWhere("CardID=@CardID and CardType=@CardType", CardID, QC_IC_Info.CardUseType_Mix);
                        foreach (var x in xycards)
                        {
                            label8.Text = "普通样需要刷小样卡";

                            qyts ts1 = new qyts("普通样需要刷蓝色卡,请核实！");
                            ts1.ShowDialog();

                            return;
                        }
                        //2016-1-29
                        if (matQuYang)
                        {

                            quyang();
                            //   DbContext.ExeSql("update tb_noticebill_head set status=1 where status=0 and icno=@cheCardid", cheCardid);
                            txt_billno.Text = null;
                            txt_vehno.Text = null;
                            txt_gys.Text = null;
                            txt_wl.Text = null;
                            nbill = null;
                            CardID = "";
                            cheCardid = "";
                            MixCardID = "";
                            外矿大样位置号.Text = "";
                            koushui.Text = "";
                            kouza.Text = "";

                        }





                    }


                    //     this.Complete();
                    //shuaxin
                    if (FrmMain.localinfo.workpoint.Code == "HJQY")
                    {
                        vehs.LoadDataByWhere("main.FetchTime>=@FetchTime and WLLX='合金' order by fetchtime desc", DateTime.Now.AddHours(-24));
                    }
                    else vehs.LoadDataByWhere("main.FetchTime>=@FetchTime and WLLX<>'外矿' and WLLX<>'合金' and WLLX<>'火运' order by fetchtime desc", DateTime.Now.AddHours(-24));
                    this.qCSampleVehBindingSource.DataSource = vehs;
                    //判定是车卡还是样品卡

                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WP_Sampling));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打印合金取样单 = new System.Windows.Forms.ToolStripMenuItem();
            this.qCSampleVehBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.物料类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.外矿大样位置号 = new System.Windows.Forms.Label();
            this.查询 = new System.Windows.Forms.Button();
            this.txt_vehno = new System.Windows.Forms.ComboBox();
            this.选择物料 = new System.Windows.Forms.Button();
            this.选择供应商 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.kuaiyang = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.kouza = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.koushui = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_wl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_gys = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_billno = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qCSampleVehBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gridControl1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(25, 4);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(963, 729);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "取样质检";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.DataSource = this.qCSampleVehBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(4, 308);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(955, 417);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打印合金取样单});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 26);
            // 
            // 打印合金取样单
            // 
            this.打印合金取样单.Name = "打印合金取样单";
            this.打印合金取样单.Size = new System.Drawing.Size(160, 22);
            this.打印合金取样单.Text = "打印合金取样单";
            this.打印合金取样单.Click += new System.EventHandler(this.打印合金取样单_Click);
            // 
            // qCSampleVehBindingSource
            // 
            this.qCSampleVehBindingSource.DataSource = typeof(Xg.Lab.Sample.QC_Sample_Veh);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn9,
            this.物料类型});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(649, 460, 210, 179);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "车牌号";
            this.gridColumn7.FieldName = "VehNo";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 149;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "供应商";
            this.gridColumn2.FieldName = "SupplierName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 60;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "物料编码";
            this.gridColumn3.FieldName = "MatCode";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 140;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "物料名称";
            this.gridColumn4.FieldName = "MatName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 147;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "取样地点";
            this.gridColumn5.FieldName = "WpCode";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 148;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "取样时间";
            this.gridColumn6.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn6.FieldName = "FetchTime";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 179;
            // 
            // gridColumn8
            // 
            this.gridColumn8.FieldName = "KouShui";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridColumn9
            // 
            this.gridColumn9.FieldName = "KouZa";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // 物料类型
            // 
            this.物料类型.Caption = "物料类型";
            this.物料类型.FieldName = "WLLX";
            this.物料类型.Name = "物料类型";
            this.物料类型.OptionsColumn.AllowEdit = false;
            this.物料类型.Visible = true;
            this.物料类型.VisibleIndex = 6;
            this.物料类型.Width = 90;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.外矿大样位置号);
            this.panel1.Controls.Add(this.查询);
            this.panel1.Controls.Add(this.txt_vehno);
            this.panel1.Controls.Add(this.选择物料);
            this.panel1.Controls.Add(this.选择供应商);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.kuaiyang);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.kouza);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.koushui);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_wl);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_gys);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_billno);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(955, 304);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // 外矿大样位置号
            // 
            this.外矿大样位置号.AutoSize = true;
            this.外矿大样位置号.Location = new System.Drawing.Point(560, 22);
            this.外矿大样位置号.Name = "外矿大样位置号";
            this.外矿大样位置号.Size = new System.Drawing.Size(0, 14);
            this.外矿大样位置号.TabIndex = 235;
            // 
            // 查询
            // 
            this.查询.Location = new System.Drawing.Point(525, 126);
            this.查询.Name = "查询";
            this.查询.Size = new System.Drawing.Size(128, 26);
            this.查询.TabIndex = 233;
            this.查询.Text = "查询";
            this.查询.UseVisualStyleBackColor = true;
            this.查询.Click += new System.EventHandler(this.查询_Click);
            // 
            // txt_vehno
            // 
            this.txt_vehno.Font = new System.Drawing.Font("宋体", 20F);
            this.txt_vehno.FormattingEnabled = true;
            this.txt_vehno.ItemHeight = 27;
            this.txt_vehno.Location = new System.Drawing.Point(100, 121);
            this.txt_vehno.Name = "txt_vehno";
            this.txt_vehno.Size = new System.Drawing.Size(401, 35);
            this.txt_vehno.TabIndex = 232;
            this.txt_vehno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_vehno_KeyPress);
            // 
            // 选择物料
            // 
            this.选择物料.Location = new System.Drawing.Point(269, 18);
            this.选择物料.Name = "选择物料";
            this.选择物料.Size = new System.Drawing.Size(91, 23);
            this.选择物料.TabIndex = 231;
            this.选择物料.Text = "选择物料";
            this.选择物料.UseVisualStyleBackColor = true;
            this.选择物料.Click += new System.EventHandler(this.选择物料_Click);
            // 
            // 选择供应商
            // 
            this.选择供应商.Location = new System.Drawing.Point(100, 18);
            this.选择供应商.Name = "选择供应商";
            this.选择供应商.Size = new System.Drawing.Size(128, 23);
            this.选择供应商.TabIndex = 230;
            this.选择供应商.Text = "选择供应商";
            this.选择供应商.UseVisualStyleBackColor = true;
            this.选择供应商.Click += new System.EventHandler(this.选择供应商_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(597, 209);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(27, 23);
            this.textBox1.TabIndex = 229;
            this.textBox1.Text = "3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(520, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 228;
            this.label1.Text = "取样点数";
            // 
            // kuaiyang
            // 
            this.kuaiyang.AutoSize = true;
            this.kuaiyang.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kuaiyang.Location = new System.Drawing.Point(665, 129);
            this.kuaiyang.Name = "kuaiyang";
            this.kuaiyang.Size = new System.Drawing.Size(91, 20);
            this.kuaiyang.TabIndex = 227;
            this.kuaiyang.Text = "是否快样";
            this.kuaiyang.UseVisualStyleBackColor = true;
            this.kuaiyang.CheckedChanged += new System.EventHandler(this.kuaiyang_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(764, 161);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 14);
            this.label15.TabIndex = 226;
            this.label15.Text = "吨";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(632, 161);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 14);
            this.label13.TabIndex = 225;
            this.label13.Text = "吨";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(624, 100);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 14);
            this.label8.TabIndex = 224;
            // 
            // kouza
            // 
            this.kouza.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kouza.Location = new System.Drawing.Point(700, 156);
            this.kouza.Margin = new System.Windows.Forms.Padding(4);
            this.kouza.Name = "kouza";
            this.kouza.Size = new System.Drawing.Size(56, 23);
            this.kouza.TabIndex = 223;
            this.kouza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(660, 161);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 222;
            this.label7.Text = "扣杂";
            // 
            // koushui
            // 
            this.koushui.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.koushui.Location = new System.Drawing.Point(563, 156);
            this.koushui.Margin = new System.Windows.Forms.Padding(4);
            this.koushui.Name = "koushui";
            this.koushui.Size = new System.Drawing.Size(61, 23);
            this.koushui.TabIndex = 221;
            this.koushui.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(520, 160);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 220;
            this.label5.Text = "扣水";
            // 
            // txt_wl
            // 
            this.txt_wl.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_wl.Location = new System.Drawing.Point(100, 241);
            this.txt_wl.Margin = new System.Windows.Forms.Padding(4);
            this.txt_wl.Name = "txt_wl";
            this.txt_wl.ReadOnly = true;
            this.txt_wl.Size = new System.Drawing.Size(401, 38);
            this.txt_wl.TabIndex = 201;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(32, 250);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 200;
            this.label2.Text = "物料";
            // 
            // txt_gys
            // 
            this.txt_gys.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_gys.Location = new System.Drawing.Point(100, 178);
            this.txt_gys.Margin = new System.Windows.Forms.Padding(4);
            this.txt_gys.Name = "txt_gys";
            this.txt_gys.ReadOnly = true;
            this.txt_gys.Size = new System.Drawing.Size(401, 38);
            this.txt_gys.TabIndex = 199;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(23, 187);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 198;
            this.label3.Text = "供应商";
            // 
            // txt_billno
            // 
            this.txt_billno.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_billno.Location = new System.Drawing.Point(100, 60);
            this.txt_billno.Margin = new System.Windows.Forms.Padding(4);
            this.txt_billno.Name = "txt_billno";
            this.txt_billno.ReadOnly = true;
            this.txt_billno.Size = new System.Drawing.Size(401, 38);
            this.txt_billno.TabIndex = 188;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(15, 69);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 20);
            this.label12.TabIndex = 187;
            this.label12.Text = "作业单号";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(23, 127);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 20);
            this.label9.TabIndex = 185;
            this.label9.Text = "车牌号";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_cancel);
            this.panel2.Controls.Add(this.btn_ok);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(802, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(151, 302);
            this.panel2.TabIndex = 169;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(24, 174);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(110, 33);
            this.btn_cancel.TabIndex = 149;
            this.btn_cancel.Text = "取消刷卡";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Location = new System.Drawing.Point(24, 65);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(110, 33);
            this.btn_ok.TabIndex = 148;
            this.btn_ok.Text = "取样确认";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "1.ico");
            this.imageList1.Images.SetKeyName(1, "2.ico");
            this.imageList1.Images.SetKeyName(2, "3.ico");
            this.imageList1.Images.SetKeyName(3, "4.ico");
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(992, 737);
            this.tabControl1.TabIndex = 1;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // WP_Sampling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "WP_Sampling";
            this.Size = new System.Drawing.Size(992, 737);
            this.Load += new System.EventHandler(this.WP_Sampling_Load);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qCSampleVehBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

      
        private Boolean xyCard = false;
        private string cheCardid = "";

        DbEntityTable<QC_IC_Info> xycards = new DbEntityTable<QC_IC_Info>();
        DbEntityTable<QC_Sample_Veh> xysamples = new DbEntityTable<QC_Sample_Veh>();
        private void WP_Sampling_Load(object sender, EventArgs e)
        {
            btn_ok.Focus();
            vehs.LoadDataByWhere("main.FetchTime>=@FetchTime and WLLX<>'外矿' and  WLLX<>'合金' and WLLX<>'火运' order by fetchtime desc", DateTime.Now.AddHours(-24));
            this.qCSampleVehBindingSource.DataSource = vehs;
            if (FrmMain.localinfo.workpoint.Code != "JMQY" && FrmMain.localinfo.workpoint.Code != "JFQY" && FrmMain.localinfo.workpoint.Code != "HJQY" && FrmMain.localinfo.workpoint.Code != "JTQY")
            {
                gridControl1.Visible = false;
            }
            if (FrmMain.localinfo.workpoint.Code == "HJQY")
            {
                vehs.LoadDataByWhere("main.FetchTime>=@FetchTime and WLLX='合金' order by fetchtime desc", DateTime.Now.AddHours(-24));
            }
            if (FrmMain.localinfo.workpoint.Code == "JTQY")
            {
                vehs.LoadDataByWhere("main.FetchTime>=@FetchTime and WLLX='焦炭' order by fetchtime desc", DateTime.Now.AddHours(-24));
            }
            wkmixs.LoadDataByWhere("main.WLLX='合金' and main.SampleState=@SampleState", SampleState.初始状态);
            if (FrmMain.localinfo.workpoint.Code != "JFQY")
            {
             
                label1.Visible = false;
                textBox1.Visible = false;
            }
            else
            {
                btn_ok.Visible = false;


            }
            
        }
        private bool isNumberic(string var)
        {
            try
            {
                double a = Convert.ToDouble(var);
                return true;
            }
            catch
            {
                return false;
            }
        }
        string CardID = "";
        string MixCardID = "";

        private void quyang()
        {
          
            if (cheCardid != "")
            {
                DbEntityTable<QC_Material> mat = new DbEntityTable<QC_Material>();
                mat.LoadDataByWhere("inv.INVCODE=@MatCode", nbill.INVCODE);
               // xkcurnotice = this.commonservice.GetNoticeBill(cheCardid);
                QC_Sample_Veh sm = new QC_Sample_Veh();
                sm.WpCode = FrmMain.localinfo.workpoint.Code;       //作业点编码
                sm.FetchPerson = LocalInfo.Current.user.ID;                 //取样人ID
                sm.VehNo = this.nbill.Cph;                     //车牌号
                sm.CardID = CardID;  //磁卡号  目前先用进门磁卡的卡号代替
                if (mat!=null)
                sm.WLLX = mat[0].WLLX;
                sm.NoticeBillId = this.nbill.NoticeId;            //磁卡作业单号
                sm.Sample_Mix_ID = 0;                               //混样ID
                sm.FetchTime = System.DateTime.Now;                 //取样时间
                sm.SampleState = SampleState.初始状态;
                sm.KouShui = StringTool.FNumVal(koushui.Text);
                sm.KouZa = StringTool.FNumVal(kouza.Text);

                sm.NcDhdBodyId = this.nbill.NcDhdBodyId;  //车辆作业单主键
                sm.MatCode = this.nbill.INVCODE;      //物料编码

                sm.SupplierCode = this.nbill.CUSTCODE;  //供应商编码

                sm.MatPK = this.nbill.PK_INVBASDOC;         //物料主键

                if (sm.NcDhdBodyId != "")
                {
                    object result = DbContext.ExecuteScalar("select djno from tb_dhd_body where carriveorder_bid='" + sm.NcDhdBodyId + "'");
                    if (result != null && result != DBNull.Value)
                    {
                        sm.NcDhdHeadNo = Convert.ToString(result);             //NC到货单
                    }
                    object resultbill = DbContext.ExecuteScalar("select carriveorder_bid from tb_dhd_body where carriveorder_bid='" + sm.NcDhdBodyId + "'");
                    if (resultbill != null && resultbill != DBNull.Value)
                    {
                        sm.NcDhdBodyId = Convert.ToString(resultbill);             //NC到货单
                    }

                    xysamples.LoadDataByWhere("main.NcDhdBodyId=@NcDhdBodyId", sm.NcDhdBodyId);
                    foreach (var xycard in xysamples)
                    {

                        label8.Text = System.DateTime.Now.ToString("HH:mm:ss") + "该车已取样";
                        return;

                    }
                    sm.Save();
                    xycards.LoadDataByWhere("CardID=@CardID and CardType=@CardType", CardID, QC_IC_Info.CardUseType_Veh);
                    foreach (var xy in xycards)
                    {
                        xy.SampleId = sm.Sample_Veh_ID;
                        xy.Save();
                        label8.Text = System.DateTime.Now.ToString("HH:mm:ss") + "小样采集完成";
                    }
                    TB_TaskFlow tt = new TB_TaskFlow();
                    tt.ID = sm.Sample_Veh_ID.ToString();
                    tt.NoticeID = nbill.NoticeId;
                    tt.NoticeItemID = nbill.NoticeBodyId;
                    tt.OperatorID = LocalInfo.Current.user.ID;
                    tt.XH = 1;
                    tt.WCCode = FrmMain.localinfo.workpoint.Code;
                    tt.Status = 1;
                    tt.BeginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    tt.EndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    tt.Result = "取样完成";
                    tt.Save();
                    //向集中计量返回状态
                    string strURL = "http://192.168.2.42:7080/MeasureService/qualityInterface/returnsampleflag.do?matchid=" + this.nbill.NoticeId + "&sampleunitcode=" + FrmMain.localinfo.workpoint.Code + "&sampleunitname=" + FrmMain.localinfo.workpoint.Name + "&cph=" + sm.VehNo + "&icno=" + cheCardid + "&samplercode=" + LocalInfo.Current.user.ID + "&samplername=" + LocalInfo.Current.user.Name + "&deduction=" + StringTool.FNumVal(koushui.Text) + "&deduction2=" + StringTool.FNumVal(kouza.Text);
                    System.Net.HttpWebRequest request;
                    request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
                    System.Net.HttpWebResponse response = null;
                    try
                    {
                        response = (System.Net.HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception exception)
                    {
                        Encoding encode = Encoding.GetEncoding("gb2312");
                        File.WriteAllText(@".\log\" + nbill.Cph + ".xml", exception.ToString(), encode);
                    }
                    System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    string responseText = myreader.ReadToEnd();
                    myreader.Close();
                    String str = responseText.Split(',')[0].Substring(responseText.Split(',')[0].Length - 4);
                    if (str == "true")
                    {
                        DbContext.ExeSql("update tb_noticebill_head set status=2 where status=0 and icno=@cheCardid", cheCardid);
                    }
                    else if (str == "false")
                    {
                        DbContext.ExeSql("update tb_noticebill_head set status=3 where status=0 and icno=@cheCardid", cheCardid);
                    }
                    else
                    {
                        DbContext.ExeSql("update tb_noticebill_head set status=4 where status=0 and icno=@cheCardid", cheCardid);
                    }
                    QC_Material matInfo = QC_Material.GetByID(nbill.PK_INVBASDOC);
                    if (matInfo.sfqyj == true && FrmMain.localinfo.workpoint.Code == "JFQY")
                    { qyxx.Save(); }
                    qyxx = new QC_Qyxx();
                    qyts ts = new qyts("普通样采集成功！");
                    ts.ShowDialog();
                    //
                }
               
                else {
                    sm.Save();
                    xycards.LoadDataByWhere("CardID=@CardID and CardType=@CardType", CardID, QC_IC_Info.CardUseType_Veh);
                    foreach (var xy in xycards)
                    {
                        xy.SampleId = sm.Sample_Veh_ID;
                        xy.Save();
                        label8.Text = System.DateTime.Now.ToString("HH:mm:ss") + "小样采集完成";
                    }
                    TB_TaskFlow tt = new TB_TaskFlow();
                    tt.ID = sm.Sample_Veh_ID.ToString();
                    tt.NoticeID = nbill.NoticeId;
                    tt.NoticeItemID = nbill.NoticeBodyId;
                    tt.OperatorID = LocalInfo.Current.user.ID;
                    tt.XH = 1;
                    tt.WCCode = FrmMain.localinfo.workpoint.Code;
                    tt.Status = 1;
                    tt.BeginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    tt.EndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    tt.Result = "取样完成";
                    tt.Save();
                    QC_Material matInfo = QC_Material.GetByID(nbill.PK_INVBASDOC);
                    if (matInfo.sfqyj == true && FrmMain.localinfo.workpoint.Code == "JFQY")
                    { qyxx.Save(); }
                    qyxx = new QC_Qyxx();
                    qyts ts = new qyts("普通样采集成功！");
                    ts.ShowDialog();
                
                }

            }
            else
            {
                MessageBox.Show("请刷车卡！");
                return;
            }

        }

     
        // 取快样
        private void qyky()
        {

            if (cheCardid != "")
            {
                //xkcurnotice = this.commonservice.GetNoticeBill(cheCardid);
                DbEntityTable<QC_Material> mat = new DbEntityTable<QC_Material>();
                mat.LoadDataByWhere("inv.INVCODE=@MatCode", nbill.INVCODE);
                QC_Sample_Veh sm = new QC_Sample_Veh();
                sm.WpCode = FrmMain.localinfo.workpoint.Code;       //作业点编码
                sm.FetchPerson = LocalInfo.Current.user.ID;          //取样人ID
                sm.VehNo = this.nbill.Cph;                    //车牌号
                sm.CardID = CardID;
                if (mat != null)//磁卡号 
                sm.WLLX = mat[0].WLLX;
                sm.NoticeBillId = this.nbill.NoticeId;            //磁卡作业单号
                sm.FetchTime = System.DateTime.Now;                 //取样时间
                sm.SampleState = SampleState.组批完成;
                sm.SampleType = SampleType.普通样;
                sm.KouShui = StringTool.FNumVal(koushui.Text);
                sm.KouZa = StringTool.FNumVal(kouza.Text);
                sm.NcDhdBodyId = this.nbill.NcDhdBodyId;  //车辆作业单主键
                sm.MatCode = this.nbill.INVCODE;      //物料编码
                sm.SupplierCode = this.nbill.CUSTCODE;  //供应商编码
                sm.SupplierName = this.nbill.CUSTNAME;
                sm.MatPK = this.nbill.PK_INVBASDOC;         //物料主键
                if (sm.NcDhdBodyId != "")
                {
                    object result = DbContext.ExecuteScalar("select djno from tb_dhd_body where carriveorder_bid='" + sm.NcDhdBodyId + "'");
                    if (result != null && result != DBNull.Value)
                    {
                        sm.NcDhdHeadNo = Convert.ToString(result);             //NC到货单
                    }
                    object resultbill = DbContext.ExecuteScalar("select carriveorder_bid from tb_dhd_body where carriveorder_bid='" + sm.NcDhdBodyId + "'");
                    if (resultbill != null && resultbill != DBNull.Value)
                    {
                        sm.NcDhdBodyId = Convert.ToString(resultbill);             //NC到货单
                    }

                    xysamples.LoadDataByWhere("main.NcDhdBodyId=@NcDhdBodyId", sm.NcDhdBodyId);
                    foreach (var xycard in xysamples)
                    {

                        label8.Text = System.DateTime.Now.ToString("HH:mm:ss") + "该车已取样";
                        return;

                    }
                    QC_Sample_Mix dty = new QC_Sample_Mix();
                    dty.MatPK = sm.MatPK;                      //物料主键
                    dty.Mix_Time = System.DateTime.Now;        //混样时间
                    dty.SupplierCode = sm.SupplierCode;        //供应商
                    dty.SupplierName = sm.SupplierName;
                    dty.MatCode = sm.MatCode;                  //物料编码
                    dty.MixUser = LocalInfo.Current.user.ID;   //混样人
                    dty.Sample_TBZD = sm.SAMPLE_TBZD;
                    dty.SampleType = sm.SampleType;        //样品类型
                    dty.SampleState = SampleState.组批完成;    //样品状态
                    dty.SaveVehSamples = true;
                    dty.WLLX = mat[0].WLLX;
                    dty.VehSamples.Add(sm);
                    dty.Save();
                    //sm.Sample_Mix_ID = dty.Sample_Mix_ID;
                    //sm.Save();

                    xycards.LoadDataByWhere("CardID=@CardID and CardType=@CardType", CardID, QC_IC_Info.CardUseType_Mix);
                    foreach (var xy in xycards)
                    {
                        xy.SampleId = sm.Sample_Mix_ID;
                        xy.Save();
                        label8.Text = System.DateTime.Now.ToString("HH:mm:ss") + "快样采集完成";

                    }
                    TB_TaskFlow tt = new TB_TaskFlow();
                    tt.ID = sm.Sample_Veh_ID.ToString();
                    tt.NoticeID = nbill.NoticeId;
                    tt.NoticeItemID = nbill.NoticeBodyId;
                    tt.OperatorID = LocalInfo.Current.user.ID;
                    tt.XH = 1;
                    tt.WCCode = FrmMain.localinfo.workpoint.Code;
                    tt.Status = 1;
                    tt.BeginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    tt.EndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    tt.Result = "取样完成";
                    tt.Save();

                    //向集中计量返回状态
                    string strURL = "http://192.168.2.42:7080/MeasureService/qualityInterface/returnsampleflag.do?matchid=" + this.nbill.NoticeId + "&sampleunitcode=" + FrmMain.localinfo.workpoint.Code + "&sampleunitname=" + FrmMain.localinfo.workpoint.Name + "&cph=" + sm.VehNo + "&icno=" + cheCardid + "&samplercode=" + LocalInfo.Current.user.ID + "&samplername=" + LocalInfo.Current.user.Name + "&deduction=" + StringTool.FNumVal(koushui.Text) + "&deduction2=" + StringTool.FNumVal(kouza.Text);
                    System.Net.HttpWebRequest request;
                    request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
                    System.Net.HttpWebResponse response = null;
                    try
                    {
                        response = (System.Net.HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception exception)
                    {
                        Encoding encode = Encoding.GetEncoding("gb2312");
                        File.WriteAllText(@".\log\" + nbill.Cph + ".xml", exception.ToString(), encode);
                    }
                    System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    string responseText = myreader.ReadToEnd();
                    myreader.Close();
                    String str = responseText.Split(',')[0].Substring(responseText.Split(',')[0].Length - 4);
                    if (str == "true")
                    {
                        DbContext.ExeSql("update tb_noticebill_head set status=2 where status=0 and icno=@cheCardid", cheCardid);
                    }
                    else if (str == "false")
                    {
                        DbContext.ExeSql("update tb_noticebill_head set status=3 where status=0 and icno=@cheCardid", cheCardid);
                    }
                    else
                    {

                        DbContext.ExeSql("update tb_noticebill_head set status=4 where status=0 and icno=@cheCardid", cheCardid);

                    }
                    QC_Material matInfo = QC_Material.GetByID(nbill.PK_INVBASDOC);
                    if (matInfo.sfqyj == true && FrmMain.localinfo.workpoint.Code == "JFQY")
                    { qyxx.Save(); }
                    qyxx = new QC_Qyxx();
                    qyts ts = new qyts("快样采集成功！");
                    ts.ShowDialog();
                    //
                }
                //else
                //{
                //    MessageBox.Show("该车没有到货单信息！");
                //    return;
                //}
                else {
                    QC_Sample_Mix dty = new QC_Sample_Mix();
                    dty.MatPK = sm.MatPK;                      //物料主键
                    dty.Mix_Time = System.DateTime.Now;        //混样时间
                    dty.SupplierCode = sm.SupplierCode;        //供应商
                    dty.SupplierName = sm.SupplierName;
                    dty.MatCode = sm.MatCode;                  //物料编码
                    dty.MixUser = LocalInfo.Current.user.ID;   //混样人
                    dty.Sample_TBZD = sm.SAMPLE_TBZD;
                    dty.SampleType = sm.SampleType;        //样品类型
                    dty.SampleState = SampleState.组批完成;    //样品状态
                    dty.SaveVehSamples = true;
                    dty.WLLX = mat[0].WLLX;
                    dty.VehSamples.Add(sm);
                    dty.Save();
                    //sm.Sample_Mix_ID = dty.Sample_Mix_ID;
                    //sm.Save();

                    xycards.LoadDataByWhere("CardID=@CardID and CardType=@CardType", CardID, QC_IC_Info.CardUseType_Mix);
                    foreach (var xy in xycards)
                    {
                        xy.SampleId = sm.Sample_Mix_ID;
                        xy.Save();
                        label8.Text = System.DateTime.Now.ToString("HH:mm:ss") + "快样采集完成";

                    }
                    TB_TaskFlow tt = new TB_TaskFlow();
                    tt.ID = sm.Sample_Veh_ID.ToString();
                    tt.NoticeID = nbill.NoticeId;
                    tt.NoticeItemID = nbill.NoticeBodyId;
                    tt.OperatorID = LocalInfo.Current.user.ID;
                    tt.XH = 1;
                    tt.WCCode = FrmMain.localinfo.workpoint.Code;
                    tt.Status = 1;
                    tt.BeginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    tt.EndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    tt.Result = "取样完成";
                    tt.Save();

                    //向集中计量返回状态
                    //string strURL = "http://192.168.2.42:7080/MeasureService/qualityInterface/returnsampleflag.do?matchid=" + this.nbill.NoticeId + "&sampleunitcode=" + FrmMain.localinfo.workpoint.Code + "&sampleunitname=" + FrmMain.localinfo.workpoint.Name + "&cph=" + sm.VehNo + "&icno=" + cheCardid + "&samplercode=" + LocalInfo.Current.user.ID + "&samplername=" + LocalInfo.Current.user.Name + "&deduction=" + StringTool.FNumVal(koushui.Text) + "&deduction2=" + StringTool.FNumVal(kouza.Text);
                    //System.Net.HttpWebRequest request;
                    //request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
                    //System.Net.HttpWebResponse response = null;
                    //try
                    //{
                    //    response = (System.Net.HttpWebResponse)request.GetResponse();
                    //}
                    //catch (Exception exception)
                    //{
                    //    Encoding encode = Encoding.GetEncoding("gb2312");
                    //    File.WriteAllText(@".\log\" + nbill.Cph + ".xml", exception.ToString(), encode);
                    //}
                    //System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    //string responseText = myreader.ReadToEnd();
                    //myreader.Close();
                    //String str = responseText.Split(',')[0].Substring(responseText.Split(',')[0].Length - 4);
                    //if (str == "true")
                    //{
                    //    DbContext.ExeSql("update tb_noticebill_head set status=2 where status=0 and icno=@cheCardid", cheCardid);
                    //}
                    //else if (str == "false")
                    //{
                    //    DbContext.ExeSql("update tb_noticebill_head set status=3 where status=0 and icno=@cheCardid", cheCardid);
                    //}
                    //else
                    //{

                    //    DbContext.ExeSql("update tb_noticebill_head set status=4 where status=0 and icno=@cheCardid", cheCardid);

                    //}
                    QC_Material matInfo = QC_Material.GetByID(nbill.PK_INVBASDOC);
                    if (matInfo.sfqyj == true && FrmMain.localinfo.workpoint.Code == "JFQY")
                    { qyxx.Save(); }
                    qyxx = new QC_Qyxx();
                    qyts ts = new qyts("快样采集成功！");
                    ts.ShowDialog();
                    //
                
                
                
                }
            }
            else
            {
                MessageBox.Show("请刷车卡！");
                return;
            }

        }
     
        private string Random(int p)
        {
            throw new NotImplementedException();
        }
      
        public void HandleCardMessage(Device.CardReader device, string cardId)
        {
            xyCard = false;
        
         
            QC_IC_Info icCard = QC_IC_Info.FindByCardId(cardId);
            if (icCard != null)
            {
                if (icCard.SampleId != 0)
                {
                    label8.Text = System.DateTime.Now.ToString("HH:mm:ss") + "该卡信息已经和别的车绑定！";
                    return;
                }

                if (cheCardid=="")
                {
                    label8.Text = "请先刷车卡";
                    return;
                }
                if (kuaiyang.Checked != true && icCard.CardType == QC_IC_Info.CardUseType_Mix)
                {
                    MixCardID = cardId;
                    label8.Text = System.DateTime.Now.ToString("HH:mm:ss") + "外矿大样卡采集成功";
                    return;

                }
                    if (kuaiyang.Checked == true)     //如果是快样
                {
                    if (icCard.CardType != QC_IC_Info.CardUseType_Mix)
                    {
                        label8.Text = "快样需要刷大桶卡";
                        return;
                    }
                }
                else
                {
                    if (icCard.CardType != QC_IC_Info.CardUseType_Veh)
                    {
                        label8.Text = "磁卡类型不对,需要刷小样卡";
                        return;
                    }
                }
                QC_Material wl = QC_Material.GetByID(nbill.PK_INVBASDOC);
                if (wl != null)
                {
                    if (wl.WLLX == "精粉" && icCard.RegUser != "陈至立")
                    {

                        label8.Text = "精粉取样，需要刷红扣";
                        return;
                    }
                    if (wl.WLLX == "煤" && icCard.RegUser != "赵贺朝")
                    {

                        label8.Text = "煤取样，需要刷蓝扣";
                        return;
                    }
                }
               
                    if (kuaiyang.Checked)
                    {
                        label8.Text = System.DateTime.Now.ToString("HH:mm:ss") + "大样卡采集成功";
                    }
                    else
                    {
                        label8.Text = System.DateTime.Now.ToString("HH:mm:ss") + "小样卡采集成功";
                    }
               
                if (CardID != cardId && CardID != "")
                {
                    label8.Text = System.DateTime.Now.ToString("HH:mm:ss") + "更换卡片成功";
                }
                CardID = cardId;
                xyCard = true;

                koushui.Focus();
            }
            else //如果是车辆卡
            {

                QC_NoticeDhdItem_View nb = QC_NoticeDhdItem_View.GetByIcNo(cardId);

              
                if (nb != null)
                {
                    cheCardid = cardId;
                    if (nb.Status == 1)
                    {
                        MessageBox.Show("该车已取样");
                        return;
                    }
                }
                if (nb != null)
                {
                    txt_billno.Text = nb.NoticeId;
                    txt_vehno.Text = nb.Cph;
                     txt_gys.Text=nb.CUSTNAME;
                     txt_wl.Text = nb.INVNAME;
                }
                nbill = nb;
                            matQuYang = false;

                //SetICCardID(cardId);

                label8.Text = "";
                CardID = "";
                xyCard = false;

                string wllx = "";
                if (nb != null)
                {
                    QC_Material matInfo = QC_Material.GetByID(nb.PK_INVBASDOC);
                    if (matInfo != null)
                    {
                        if (matInfo.InUse)
                        {
                            matQuYang = true;
                        }
                        wllx = matInfo.WLLX;
                    }

                }
                if (matQuYang && wllx == "精粉")
                {
                    if (kuaiyang.Checked)     //如果是快样
                    {
                        label8.ForeColor = System.Drawing.Color.Black;
                        label8.Text = "快样需要刷大样卡(精粉黄色)";
                    }
                    else
                    {
                        label8.ForeColor = System.Drawing.Color.Black;
                        label8.Text = "需要刷小样卡(精粉红色)";
                    }
                
                }
                if (matQuYang && wllx == "煤")
                {
                    if (kuaiyang.Checked)     //如果是快样
                    {
                        label8.ForeColor = System.Drawing.Color.Red;
                        label8.Text = "快样需要刷大样卡(精煤红色)";
                    }
                    else
                    {
                        label8.ForeColor = System.Drawing.Color.Red;
                        label8.Text = "需要刷小样卡(精煤蓝色)";
                    }
                }
                else if (!matQuYang)
                {
                    label8.Text = "不需要刷磁扣";
                }
            }
        }
        QC_NoticeDhdItem_View nbill = new QC_NoticeDhdItem_View();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kuaiyang_CheckedChanged(object sender, EventArgs e)
        {
            if (kuaiyang.Checked == true)
            {
                label8.Text = "快样需要刷大桶卡";
            }
            else
            {
                label8.Text = "";
            }
        }
        DbEntityTable<QC_Sample_Veh> vehs = new DbEntityTable<QC_Sample_Veh>();

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        QC_Qyxx qyxx = new QC_Qyxx();
        string cph = "";
        string head = "";
        string body = "";
        string body1 = "";
        string body2 = "";
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
    
            Rectangle rect = new Rectangle(9, 3, 112, 94);
            Font f1 = new System.Drawing.Font("宋体", 18, FontStyle.Bold);
            SizeF headSize = e.Graphics.MeasureString(head, f1);
            Font f2 = new System.Drawing.Font("宋体", 8f, FontStyle.Bold);
            SizeF bodySize = e.Graphics.MeasureString(body, f2);
            Font f3 = new System.Drawing.Font("宋体", 8f, FontStyle.Bold);
            SizeF body1Size = e.Graphics.MeasureString(body1, f3);
           

            float topMargin = rect.Top + (rect.Height - headSize.Height - bodySize.Height - body1Size.Height - 6) / 2;
            float leftMargin = rect.Left + (rect.Width - headSize.Width) / 2;
            e.Graphics.DrawString(head, f1, Brushes.Black, new PointF(leftMargin, topMargin));

           
            float topMargin2 = topMargin + Math.Max(headSize.Height + 3, 12);
            float leftMargin2 = rect.Left;
            e.Graphics.DrawString(body, f2, Brushes.Black, new PointF(leftMargin2, topMargin2));

           
            float topMargin3 = topMargin2 + Math.Max(bodySize.Height + 1, 12);
            float leftMargin3 = rect.Left;
            e.Graphics.DrawString(body1, f2, Brushes.Black, new PointF(leftMargin3, topMargin3));

           
            
            float topMargin4 = topMargin3 + Math.Max(bodySize.Height + 1, 12);
            float leftMargin4 = rect.Left;
            e.Graphics.DrawString(body2, f2, Brushes.Black, new PointF(leftMargin4, topMargin4));
        }

        private void 选择供应商_Click(object sender, EventArgs e)
        {
            if (nbill == null)
            { nbill = new QC_NoticeDhdItem_View(); }
            QC_Gys gys = new QC_Gys();
            if (gys.ShowDialog() == DialogResult.OK)
            {
                if (gys.SelectedGys != null)
                {
                    nbill.PK_CUBASDOC = gys.SelectedGys.PK_CUBASDOC;
                    nbill.CUSTCODE = gys.SelectedGys.CUSTCODE;
                    nbill.CUSTNAME = gys.SelectedGys.CUSTSHORTNAME;
                    txt_gys.Text = gys.SelectedGys.CUSTSHORTNAME;
                }
            }
        }

        private void 选择物料_Click(object sender, EventArgs e)
        {
            if (nbill == null)
            { nbill = new QC_NoticeDhdItem_View(); }
            string wllx = "";
            matQuYang = false;
            QC_Wuliao wl = new QC_Wuliao();
            if (wl.ShowDialog() == DialogResult.OK)
            {
                if (wl.SelectedWl != null)
                {
                    nbill.PK_INVBASDOC = wl.SelectedWl.MatNcId;
                    nbill.INVCODE = wl.SelectedWl.MatCode;
                    nbill.INVNAME = wl.SelectedWl.MatName;
                    txt_wl.Text = wl.SelectedWl.MatName;
                    QC_Material matInfo = QC_Material.GetByID(nbill.PK_INVBASDOC);
                    if (matInfo != null)
                    {
                        if (matInfo.InUse)
                        {
                            matQuYang = true;
                        }
                        wllx = matInfo.WLLX;
                        cheCardid = "1";
                    }
                }
            }
           
            
            
            if (matQuYang && wllx == "精粉")
            {
                if (kuaiyang.Checked)     //如果是快样
                {
                    label8.ForeColor = System.Drawing.Color.Black;
                    label8.Text = "快样需要刷大样卡(精粉黄色)";
                }
                else
                {
                    label8.ForeColor = System.Drawing.Color.Black;
                    label8.Text = "需要刷小样卡(精粉红色)";
                }

            }
            if (matQuYang && wllx == "煤")
            {
                if (kuaiyang.Checked)     //如果是快样
                {
                    label8.ForeColor = System.Drawing.Color.Red;
                    label8.Text = "快样需要刷大样卡(精煤红色)";
                }
                else
                {
                    label8.ForeColor = System.Drawing.Color.Red;
                    label8.Text = "需要刷小样卡(精煤蓝色)";
                }
            }
            else if (!matQuYang)
            {
                label8.Text = "不需要刷取样卡";
            }
        }

        private void txt_vehno_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (txt_vehno.Text.Length == 4)
            //{
            //    txt_vehno.Items.Clear();
            //    DbEntityTable<QC_Sample_Veh> vehs = new DbEntityTable<QC_Sample_Veh>();
            //    vehs.LoadDataBySql("  select distinct vehno from QC_Sample_Veh where vehno like '%" + txt_vehno.Text + "%'");
            //    foreach (var item in vehs)
            //    {  
            //        txt_vehno.Items.Add(item.VehNo);

            //    }      
            //    txt_vehno.DroppedDown = true;

            //}
        }

        private void 查询_Click(object sender, EventArgs e)
        {
            txt_vehno.Items.Clear();
            DbEntityTable<QC_Sample_Veh> vehs = new DbEntityTable<QC_Sample_Veh>();
            vehs.LoadDataBySql("  select distinct vehno from QC_Sample_Veh where vehno like '%" + txt_vehno.Text + "%'");
            foreach (var item in vehs)
            {
                txt_vehno.Items.Add(item.VehNo);

            }
            txt_vehno.DroppedDown = true;
        }

        private void 打印合金取样单_Click(object sender, EventArgs e)
        {
            QC_Sample_Veh veh = qCSampleVehBindingSource.Current as QC_Sample_Veh;

             cph = veh.VehNo;
             head =QC_Sample_Mix.ShortStoreCode(veh.CardID);
             body = cph;
             body1 = veh.MatName;
             body2 = veh.SupplierName;

            this.printPreviewDialog1.ShowDialog();
            cph = "";
            head = "";
            body = "";
            body1 = "";
            body2 = "";

        }

        private void 外矿收桶_Click(object sender, EventArgs e)
        {
            foreach (var item in wkmixs)
            {





            }
        }
    }
}

