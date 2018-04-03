namespace VehIC_WF
{
    using DevExpress.Utils;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using FastReport;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;
    using VehIC_BL;
    using VehIC_WF.AuthService;
    using VehIC_WF.CommonService;
    using VehIC_WF.DoorService;
    using VehIC_WF.GoodsSite;
    using VehIC_WF.ICCardManageService;
    using VehIC_WF.SamplingService;
    using VehIC_WF.ScaleService;
    using VehIC_WF.Utility;

    public class FrmTaskSearch : Form
    {
        public string abitemid = string.Empty;
        public string abwpcode = string.Empty;
        public VehIC_WF.AuthService.AuthService ath;
        private Button btn_print;
        private Button btn_task_cancel;
        private Button btn_task_terminal;
        public VehIC_WF.ICCardManageService.ICCard card = null;
        private CheckBox cb_th;
        private CheckBox chbox_fixveh;
        private CheckBox chbox_needweigh;
        private IContainer components = null;
        public VehIC_WF.CommonService.CommonService cs;
        private FrxDataTable datatable = null;
        public VehIC_WF.DoorService.DoorService door = null;
        public VehIC_WF.GoodsSite.GoodsSite goodssite = null;
        private GroupBox groupBox3;
        public VehIC_WF.ICCardManageService.ICCardManageService ics = null;
        private ImageList imageList1;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label14;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label9;
        private ListBox listBox1;
        private FrmMain main = null;
        private Panel panel2;
        private Panel panel3;
        private RadioButton rb_wzlx_in;
        private RadioButton rb_wzlx_out;
        private TfrxReportClass report = null;
        public VehIC_WF.SamplingService.SamplingService sample = null;
        public VehIC_WF.ScaleService.ScaleService scale = null;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        public VehIC_WF.CommonService.NoticeBill task = null;
        private TreeList tl_BillItem;
        private TreeList tl_door_limite;
        private TreeList tl_taskflow;
        private TreeListColumn tlc1;
        private TreeListColumn tlc10;
        private TreeListColumn tlc11;
        private TreeListColumn tlc12;
        private TreeListColumn tlc13;
        private TreeListColumn tlc2;
        private TreeListColumn tlc3;
        private TreeListColumn tlc4;
        private TreeListColumn tlc5;
        private TreeListColumn tlc6;
        private TreeListColumn tlc7;
        private TreeListColumn tlc8;
        private TreeListColumn tlc9;
        private TreeListColumn treeListColumn1;
        private TreeListColumn treeListColumn19;
        private TreeListColumn treeListColumn2;
        private TreeListColumn treeListColumn20;
        private TreeListColumn treeListColumn21;
        private TreeListColumn treeListColumn3;
        private TreeListColumn treeListColumn4;
        private TreeListColumn treeListColumn5;
        private TreeListColumn treeListColumn6;
        private TreeListColumn treeListColumn7;
        private TreeListColumn treeListColumn8;
        private TextBox txt_billno;
        private TextBox txt_billstatus;
        private TextBox txt_billtype;
        private TextBox txt_fkr;
        private TextBox txt_fksj;
        private TextBox txt_icno;
        private TextBox txt_remark;
        private TextBox txt_vehno;
        private TextBox txt_vehtype;

        public FrmTaskSearch(FrmMain main)
        {
            this.InitializeComponent();
            this.main = main;
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (this.task != null)
            {
                if (this.report == null)
                {
                    this.report = new TfrxReportClass();
                    this.datatable = new FrxDataTable("Task");
                    Assembly executingAssembly = Assembly.GetExecutingAssembly();
                    this.report.MainWindowHandle = (int)base.Handle;
                    this.report.LoadReportFromStream(executingAssembly.GetManifestResourceStream("VehIC_WF.Res.Task.fr3"));
                    this.datatable.Columns.Add("LineNo", typeof(int));
                    this.datatable.Columns.Add("InvCode", typeof(string));
                    this.datatable.Columns.Add("InvName", typeof(string));
                    this.datatable.Columns.Add("Vendor", typeof(string));
                    this.datatable.Columns.Add("SourBillNo", typeof(string));
                    this.datatable.Columns.Add("JHSL", typeof(string));
                    this.datatable.Columns.Add("SJSL", typeof(string));
                    this.datatable.Columns.Add("Status", typeof(string));
                    this.datatable.Columns.Add("Unit", typeof(string));
                    this.datatable.Columns.Add("Remark", typeof(string));
                    this.datatable.AssignToReport(true, this.report);
                    this.datatable.AssignToDataBand("MasterData1", this.report);
                    this.report.OnBeforePrint += new IfrxReportEvents_OnBeforePrintEventHandler(this.Report_OnBeforePrint);
                    this.report.OnAfterPrint += new IfrxReportEvents_OnAfterPrintEventHandler(this.Report_OnAfterPrint);
                }
                this.FillTableData(this.datatable);
                this.report.ShowReport();
            }
        }

        private void btn_task_cancel_Click(object sender, EventArgs e)
        {
            if ((this.task != null) && (FrmMain.localinfo.workpoint.type != VehIC_BL.RouteNodeType.unknow))
            {
                string code = FrmMain.localinfo.workpoint.Code;
                string iD = LocalInfo.Current.user.ID;
                if (!FrmMain.Debug)
                {
                    string text = this.cs.BillRouteIncludeWP(this.task.billno, code);
                    if (text != "OK")
                    {
                        MessageBox.Show(text);
                        return;
                    }
                }
                if (FrmMain.localinfo.workpoint.type == VehIC_BL.RouteNodeType.door)
                {
                    if (this.task.status != 1)
                    {
                        MessageBox.Show("非未进厂状态不允许撤销!");
                    }
                    else
                    {
                        string str4 = string.Empty;
                        if (!FrmMain.Debug)
                        {
                            str4 = this.ath.CheckAuthority(code, iD, "W_Door_VehCard", string.Empty, false);
                            if (str4 != "OK")
                            {
                                MessageBox.Show(str4);
                                return;
                            }
                        }
                        str4 = this.door.TaskCancel(this.task.billno, code, iD);
                        if (str4 == "OKFix")
                        {
                            MessageBox.Show("操作成功！");
                            this.task = null;
                            this.InitForm();
                        }
                        else if (str4 == "OK")
                        {
                            MessageBox.Show("操作成功！临时车辆请收回磁卡！");
                            this.task = null;
                            this.InitForm();
                        }
                        else
                        {
                            MessageBox.Show(str4);
                        }
                    }
                }
                else if (this.task.needweigh)
                {
                    if (FrmMain.localinfo.workpoint.type == VehIC_BL.RouteNodeType.sampling)
                    {
                        if (this.sample.HaveNectRec(this.task.billno, this.abitemid, code))
                        {
                            MessageBox.Show("下个作业点已经开始作业，不能取消！");
                        }
                        else if (!this.sample.CancelTaskFlowInitRec(this.task.billno, this.abitemid, code, iD))
                        {
                            MessageBox.Show("操作失败，请重试！");
                        }
                        else
                        {
                            MessageBox.Show("操作成功！");
                            this.task = null;
                            this.InitForm();
                        }
                    }
                    else if (FrmMain.localinfo.workpoint.type == VehIC_BL.RouteNodeType.scales)
                    {
                        if (this.scale.HaveNectRec(this.task.billno, this.abitemid, code))
                        {
                            MessageBox.Show("下个作业点已经开始作业，不能取消！");
                        }
                        else if (!this.scale.CancelTaskFlowInitRec(this.task.billno, this.abitemid, code, iD))
                        {
                            MessageBox.Show("操作失败，请重试！");
                        }
                        else
                        {
                            MessageBox.Show("操作成功！");
                            this.task = null;
                            this.InitForm();
                        }
                    }
                    else if ((FrmMain.localinfo.workpoint.type == VehIC_BL.RouteNodeType.goodssite) && this.task.needweigh)
                    {
                        if (this.goodssite.HaveNectRec(this.task.billno, this.abitemid, code))
                        {
                            MessageBox.Show("下个作业点已经开始作业，不能取消！");
                        }
                        else if (!this.goodssite.CancelTaskFlowInitRec(this.task.billno, this.abitemid, code, iD))
                        {
                            MessageBox.Show("操作失败，请重试！");
                        }
                        else
                        {
                            MessageBox.Show("操作成功！");
                            this.task = null;
                            this.InitForm();
                        }
                    }
                }
            }
        }

        private void btn_task_terminal_Click(object sender, EventArgs e)
        {
            if ((this.task != null) && (FrmMain.localinfo.workpoint.type != VehIC_BL.RouteNodeType.unknow))
            {
                if (!this.task.needweigh)
                {
                    MessageBox.Show("计件类物资没有终止!");
                }
                else
                {
                    string code = FrmMain.localinfo.workpoint.Code;
                    string iD = LocalInfo.Current.user.ID;
                    if (!FrmMain.Debug)
                    {
                        string text = this.cs.BillRouteIncludeWP(this.task.billno, code);
                        if (text != "OK")
                        {
                            MessageBox.Show(text);
                            return;
                        }
                    }
                    string authname = string.Empty;
                    if (FrmMain.localinfo.workpoint.type == VehIC_BL.RouteNodeType.door)
                    {
                        authname = "W_Door_VehCard";
                    }
                    if (FrmMain.localinfo.workpoint.type == VehIC_BL.RouteNodeType.scales)
                    {
                        authname = "W_Scale_Terminate";
                    }
                    if (FrmMain.localinfo.workpoint.type == VehIC_BL.RouteNodeType.sampling)
                    {
                        authname = "W_Sampling_Terminate";
                    }
                    if (FrmMain.localinfo.workpoint.type == VehIC_BL.RouteNodeType.goodssite)
                    {
                        authname = "W_GoodsSite_Terminate";
                    }
                    if (!this.checkbillstatus())
                    {
                        MessageBox.Show("当前作业单状态:" + VehIC_BL.NoticeBill.GetNoticeStatusDesc(this.task.status) + "终止无效!");
                    }
                    else
                    {
                        string str5 = this.ath.CheckAuthority(code, iD, authname, string.Empty, false);
                        if (str5 != "OK")
                        {
                            MessageBox.Show(str5);
                        }
                        else if (MessageBox.Show("终止后将不能进行任何操作！确实要终止此作业单吗？", "提示", MessageBoxButtons.OKCancel) != DialogResult.Cancel)
                        {
                            if (this.cs.TerminalTask(this.task.billno, code, iD) == "OK")
                            {
                                MessageBox.Show("操作成功！");
                                this.InitForm();
                                this.task = null;
                            }
                            else
                            {
                                MessageBox.Show("操作失败，请重试！");
                            }
                        }
                    }
                }
            }
        }

        public bool checkbillstatus()
        {
            return ((this.task.status == -1) || ((this.task.status == 2) || (this.task.status == 3)));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool FetchTask()
        {
            try
            {
                string vehno = this.txt_vehno.Text.Trim();
                if (vehno == string.Empty)
                {
                    return false;
                }
                this.task = this.cs.GetTaskBillByVehNo(vehno);
                if (this.task == null)
                {
                    MessageBox.Show("获取作业单据失败！");
                    return false;
                }
                if (this.task.billno == string.Empty)
                {
                    this.task = null;
                    MessageBox.Show("不存在对应的作业单据！");
                    return false;
                }
                this.abitemid = string.Empty;
                this.abwpcode = string.Empty;
                this.ViewTaskBill();
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("网络处理错误" + exception.ToString());
                return false;
            }
        }

        private bool FetchTerminalBtnStatus()
        {
            if (this.task == null)
            {
                return false;
            }
            if (this.task.billtype <= 2)
            {
                int num;
                VehIC_WF.CommonService.NBItem item;
                if (!this.task.needweigh)
                {
                    return false;
                }
                for (num = 0; num < this.task.Items.Length; num++)
                {
                    item = this.task.Items[num];
                    if (item.status == 1)
                    {
                        return false;
                    }
                }
                int num2 = 0;
                for (num = 0; num < this.task.Items.Length; num++)
                {
                    item = this.task.Items[num];
                    if (item.status == 0)
                    {
                        num2++;
                    }
                }
                if (num2 == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool FillListView(string vehno)
        {
            try
            {
                string[] cardVehNo = this.cs.GetCardVehNo(vehno);
                if ((cardVehNo == null) && (cardVehNo.Length == 0))
                {
                    return false;
                }
                for (int i = 0; i < cardVehNo.Length; i++)
                {
                    this.listBox1.Items.Add(cardVehNo[i]);
                }
                if (cardVehNo.Length == 1)
                {
                    this.listBox1.Height = 30;
                }
                else if (cardVehNo.Length < 8)
                {
                    this.listBox1.Height = (this.listBox1.ItemHeight + 1) * cardVehNo.Length;
                }
                else
                {
                    this.listBox1.Height = 110;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void FillTableData(FrxDataTable datatable)
        {
            datatable.Rows.Clear();
            for (int i = 0; i < this.task.Items.Length; i++)
            {
                int num2 = i + 1;
                string invcode = this.task.Items[i].invcode;
                string str2 = this.task.Items[i].invname + this.task.Items[i].spectypegraphid;
                string vendor = this.task.Items[i].Vendor;
                string billNo = this.task.Items[i].BillNo;
                string plannum = this.task.Items[i].plannum;
                string factnum = this.task.Items[i].factnum;
                string str7 = string.Empty;
                switch (this.task.Items[i].status)
                {
                    case 0:
                        str7 = "初始";
                        break;

                    case 1:
                        str7 = "开始";
                        break;

                    case 2:
                        str7 = "完成";
                        break;
                }
                string unit = this.task.Items[i].unit;
                string remark = this.task.Items[i].remark;
                datatable.Rows.Add(new object[] { num2, invcode, str2, vendor, billNo, plannum, factnum, str7, unit, remark });
            }
            datatable.AcceptChanges();
        }

        private void FrmTaskSearch_Load(object sender, EventArgs e)
        {
            this.goodssite = new VehIC_WF.GoodsSite.GoodsSite();
            this.scale = new VehIC_WF.ScaleService.ScaleService();
            this.sample = new VehIC_WF.SamplingService.SamplingService();
            this.ath = new VehIC_WF.AuthService.AuthService();
            this.cs = new VehIC_WF.CommonService.CommonService();
            this.ics = new VehIC_WF.ICCardManageService.ICCardManageService();
            this.door = new VehIC_WF.DoorService.DoorService();
            if (!FrmMain.Debug)
            {
                this.goodssite.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/GoodsSite.asmx";
                this.scale.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/ScaleService.asmx";
                this.sample.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/SamplingService.asmx";
                this.door.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/DoorService.asmx";
                this.ath.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/AuthService.asmx";
                this.cs.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/CommonService.asmx";
                this.ics.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/ICCardManageService.asmx";
            }
            if (FrmMain.localinfo.workpoint.type != VehIC_BL.RouteNodeType.door)
            {
                this.btn_task_cancel.Text = "取消作业";
                this.btn_task_terminal.Text = "终止作业";
            }
            else if (FrmMain.localinfo.workpoint.type == VehIC_BL.RouteNodeType.unknow)
            {
                this.btn_task_cancel.Enabled = false;
                this.btn_task_terminal.Enabled = false;
            }
            VehIC_WF.Utility.Common.RegSvrFastReport();
        }

        private void InitForm()
        {
            this.txt_icno.Text = "";
            this.txt_billno.Text = "";
            this.txt_billstatus.Text = "";
            this.txt_billtype.Text = "";
            this.txt_fkr.Text = "";
            this.txt_fksj.Text = "";
            this.txt_vehtype.Text = "";
            this.txt_remark.Text = "";
            this.chbox_fixveh.Checked = false;
            this.chbox_needweigh.Checked = false;
            this.tl_BillItem.Nodes.Clear();
            this.tl_taskflow.Nodes.Clear();
            this.tl_door_limite.Nodes.Clear();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTaskSearch));
            this.panel2 = new Panel();
            this.txt_remark = new TextBox();
            this.label5 = new Label();
            this.cb_th = new CheckBox();
            this.listBox1 = new ListBox();
            this.panel3 = new Panel();
            this.btn_print = new Button();
            this.btn_task_terminal = new Button();
            this.btn_task_cancel = new Button();
            this.txt_icno = new TextBox();
            this.txt_fksj = new TextBox();
            this.groupBox3 = new GroupBox();
            this.rb_wzlx_out = new RadioButton();
            this.rb_wzlx_in = new RadioButton();
            this.txt_billstatus = new TextBox();
            this.label4 = new Label();
            this.label2 = new Label();
            this.txt_fkr = new TextBox();
            this.label3 = new Label();
            this.chbox_needweigh = new CheckBox();
            this.label10 = new Label();
            this.chbox_fixveh = new CheckBox();
            this.txt_vehtype = new TextBox();
            this.label1 = new Label();
            this.txt_billtype = new TextBox();
            this.label14 = new Label();
            this.label11 = new Label();
            this.txt_billno = new TextBox();
            this.label12 = new Label();
            this.txt_vehno = new TextBox();
            this.label9 = new Label();
            this.tabControl1 = new TabControl();
            this.tabPage1 = new TabPage();
            this.tl_BillItem = new TreeList();
            this.tlc1 = new TreeListColumn();
            this.tlc2 = new TreeListColumn();
            this.tlc3 = new TreeListColumn();
            this.tlc4 = new TreeListColumn();
            this.tlc5 = new TreeListColumn();
            this.tlc6 = new TreeListColumn();
            this.tlc7 = new TreeListColumn();
            this.tlc8 = new TreeListColumn();
            this.tlc9 = new TreeListColumn();
            this.tlc10 = new TreeListColumn();
            this.tlc11 = new TreeListColumn();
            this.tlc12 = new TreeListColumn();
            this.tlc13 = new TreeListColumn();
            this.imageList1 = new ImageList(this.components);
            this.tabPage2 = new TabPage();
            this.tl_taskflow = new TreeList();
            this.treeListColumn1 = new TreeListColumn();
            this.treeListColumn2 = new TreeListColumn();
            this.treeListColumn3 = new TreeListColumn();
            this.treeListColumn4 = new TreeListColumn();
            this.treeListColumn5 = new TreeListColumn();
            this.treeListColumn6 = new TreeListColumn();
            this.treeListColumn7 = new TreeListColumn();
            this.treeListColumn8 = new TreeListColumn();
            this.tabPage3 = new TabPage();
            this.tl_door_limite = new TreeList();
            this.treeListColumn19 = new TreeListColumn();
            this.treeListColumn20 = new TreeListColumn();
            this.treeListColumn21 = new TreeListColumn();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tl_BillItem.BeginInit();
            this.tabPage2.SuspendLayout();
            this.tl_taskflow.BeginInit();
            this.tabPage3.SuspendLayout();
            this.tl_door_limite.BeginInit();
            base.SuspendLayout();
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txt_remark);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cb_th);
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.txt_icno);
            this.panel2.Controls.Add(this.txt_fksj);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.txt_billstatus);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_fkr);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.chbox_needweigh);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.chbox_fixveh);
            this.panel2.Controls.Add(this.txt_vehtype);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txt_billtype);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txt_billno);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txt_vehno);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = DockStyle.Top;
            this.panel2.Location = new Point(0, 0);
            this.panel2.Margin = new Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x3bb, 0xce);
            this.panel2.TabIndex = 0xbf;
            this.txt_remark.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_remark.Location = new Point(0x56, 0x93);
            this.txt_remark.Margin = new Padding(4);
            this.txt_remark.Multiline = true;
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.ReadOnly = true;
            this.txt_remark.Size = new Size(0x247, 0x33);
            this.txt_remark.TabIndex = 0xdd;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label5.Location = new Point(0x35, 150);
            this.label5.Margin = new Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x23, 14);
            this.label5.TabIndex = 220;
            this.label5.Text = "说明";
            this.cb_th.AutoSize = true;
            this.cb_th.Enabled = false;
            this.cb_th.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.cb_th.Location = new Point(0x137, 0x77);
            this.cb_th.Name = "cb_th";
            this.cb_th.Size = new Size(0x5b, 20);
            this.cb_th.TabIndex = 0xd5;
            this.cb_th.Text = "是否退货";
            this.cb_th.UseVisualStyleBackColor = true;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new Point(0x20d, 0x24);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBox1.Size = new Size(0x90, 0x10);
            this.listBox1.TabIndex = 0xd4;
            this.listBox1.Visible = false;
            this.listBox1.DoubleClick += new EventHandler(this.listBox1_DoubleClick);
            this.listBox1.KeyUp += new KeyEventHandler(this.listBox1_KeyUp);
            this.panel3.Controls.Add(this.btn_print);
            this.panel3.Controls.Add(this.btn_task_terminal);
            this.panel3.Controls.Add(this.btn_task_cancel);
            this.panel3.Dock = DockStyle.Right;
            this.panel3.Location = new Point(0x2f2, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(0xc7, 0xcc);
            this.panel3.TabIndex = 0xb7;
            this.btn_print.Location = new Point(0x18, 0x66);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new Size(0x98, 0x2b);
            this.btn_print.TabIndex = 0xd6;
            this.btn_print.Text = "打印作业单";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Visible = false;
            this.btn_print.Click += new EventHandler(this.btn_print_Click);
            this.btn_task_terminal.Location = new Point(0x18, 0x35);
            this.btn_task_terminal.Name = "btn_task_terminal";
            this.btn_task_terminal.Size = new Size(0x98, 0x2b);
            this.btn_task_terminal.TabIndex = 0xd5;
            this.btn_task_terminal.Text = "终止未完成作业单";
            this.btn_task_terminal.UseVisualStyleBackColor = true;
            this.btn_task_terminal.Click += new EventHandler(this.btn_task_terminal_Click);
            this.btn_task_cancel.Location = new Point(0x18, 8);
            this.btn_task_cancel.Name = "btn_task_cancel";
            this.btn_task_cancel.Size = new Size(0x98, 0x2b);
            this.btn_task_cancel.TabIndex = 0x90;
            this.btn_task_cancel.Text = "撤销未进厂作业单";
            this.btn_task_cancel.UseVisualStyleBackColor = true;
            this.btn_task_cancel.Click += new EventHandler(this.btn_task_cancel_Click);
            this.txt_icno.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_icno.Location = new Point(0x20d, 0x4a);
            this.txt_icno.Margin = new Padding(4);
            this.txt_icno.Name = "txt_icno";
            this.txt_icno.ReadOnly = true;
            this.txt_icno.Size = new Size(0x90, 0x17);
            this.txt_icno.TabIndex = 0xad;
            this.txt_icno.TextAlign = HorizontalAlignment.Right;
            this.txt_fksj.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_fksj.Location = new Point(0x137, 0x2c);
            this.txt_fksj.Margin = new Padding(4);
            this.txt_fksj.Name = "txt_fksj";
            this.txt_fksj.ReadOnly = true;
            this.txt_fksj.Size = new Size(0x90, 0x17);
            this.txt_fksj.TabIndex = 0xb3;
            this.txt_fksj.TextAlign = HorizontalAlignment.Right;
            this.groupBox3.Controls.Add(this.rb_wzlx_out);
            this.groupBox3.Controls.Add(this.rb_wzlx_in);
            this.groupBox3.Location = new Point(0x137, 0x43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x90, 0x21);
            this.groupBox3.TabIndex = 0xb6;
            this.groupBox3.TabStop = false;
            this.rb_wzlx_out.AutoSize = true;
            this.rb_wzlx_out.Enabled = false;
            this.rb_wzlx_out.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.rb_wzlx_out.Location = new Point(0x51, 11);
            this.rb_wzlx_out.Name = "rb_wzlx_out";
            this.rb_wzlx_out.Size = new Size(0x3a, 20);
            this.rb_wzlx_out.TabIndex = 0xaf;
            this.rb_wzlx_out.Text = "出厂";
            this.rb_wzlx_out.UseVisualStyleBackColor = true;
            this.rb_wzlx_in.AutoSize = true;
            this.rb_wzlx_in.Checked = true;
            this.rb_wzlx_in.Enabled = false;
            this.rb_wzlx_in.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.rb_wzlx_in.Location = new Point(11, 10);
            this.rb_wzlx_in.Name = "rb_wzlx_in";
            this.rb_wzlx_in.Size = new Size(0x3a, 20);
            this.rb_wzlx_in.TabIndex = 0xae;
            this.rb_wzlx_in.TabStop = true;
            this.rb_wzlx_in.Text = "入厂";
            this.rb_wzlx_in.UseVisualStyleBackColor = true;
            this.txt_billstatus.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_billstatus.Location = new Point(0x56, 0x2b);
            this.txt_billstatus.Margin = new Padding(4);
            this.txt_billstatus.Name = "txt_billstatus";
            this.txt_billstatus.ReadOnly = true;
            this.txt_billstatus.Size = new Size(0x90, 0x17);
            this.txt_billstatus.TabIndex = 0xb5;
            this.txt_billstatus.TextAlign = HorizontalAlignment.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label4.Location = new Point(0x19, 0x2f);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x3f, 14);
            this.label4.TabIndex = 180;
            this.label4.Text = "单据状态";
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label2.Location = new Point(250, 0x30);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x3f, 14);
            this.label2.TabIndex = 0xb2;
            this.label2.Text = "发卡时间";
            this.txt_fkr.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_fkr.Location = new Point(0x137, 14);
            this.txt_fkr.Margin = new Padding(4);
            this.txt_fkr.Name = "txt_fkr";
            this.txt_fkr.ReadOnly = true;
            this.txt_fkr.Size = new Size(0x90, 0x17);
            this.txt_fkr.TabIndex = 0xb1;
            this.txt_fkr.TextAlign = HorizontalAlignment.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label3.Location = new Point(0x108, 0x12);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x31, 14);
            this.label3.TabIndex = 0xb0;
            this.label3.Text = "发卡人";
            this.chbox_needweigh.AutoSize = true;
            this.chbox_needweigh.Enabled = false;
            this.chbox_needweigh.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.chbox_needweigh.Location = new Point(180, 0x77);
            this.chbox_needweigh.Name = "chbox_needweigh";
            this.chbox_needweigh.Size = new Size(0x3b, 20);
            this.chbox_needweigh.TabIndex = 0xaf;
            this.chbox_needweigh.Text = "计重";
            this.chbox_needweigh.UseVisualStyleBackColor = true;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label10.Location = new Point(0x1de, 0x4e);
            this.label10.Margin = new Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x31, 14);
            this.label10.TabIndex = 0xac;
            this.label10.Text = "IC卡号";
            this.chbox_fixveh.AutoSize = true;
            this.chbox_fixveh.Enabled = false;
            this.chbox_fixveh.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.chbox_fixveh.Location = new Point(0x1c, 0x77);
            this.chbox_fixveh.Name = "chbox_fixveh";
            this.chbox_fixveh.Size = new Size(0x5b, 20);
            this.chbox_fixveh.TabIndex = 0x9e;
            this.chbox_fixveh.Text = "固定车辆";
            this.chbox_fixveh.UseVisualStyleBackColor = true;
            this.txt_vehtype.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_vehtype.Location = new Point(0x20d, 0x2c);
            this.txt_vehtype.Margin = new Padding(4);
            this.txt_vehtype.Name = "txt_vehtype";
            this.txt_vehtype.ReadOnly = true;
            this.txt_vehtype.Size = new Size(0x90, 0x17);
            this.txt_vehtype.TabIndex = 0x9d;
            this.txt_vehtype.TextAlign = HorizontalAlignment.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label1.Location = new Point(0x1ec, 0x31);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x23, 14);
            this.label1.TabIndex = 0x9c;
            this.label1.Text = "车型";
            this.txt_billtype.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_billtype.Location = new Point(0x56, 0x4a);
            this.txt_billtype.Margin = new Padding(4);
            this.txt_billtype.Name = "txt_billtype";
            this.txt_billtype.ReadOnly = true;
            this.txt_billtype.Size = new Size(0x90, 0x17);
            this.txt_billtype.TabIndex = 0x97;
            this.txt_billtype.TextAlign = HorizontalAlignment.Right;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label14.Location = new Point(0x19, 0x4e);
            this.label14.Margin = new Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x3f, 14);
            this.label14.TabIndex = 150;
            this.label14.Text = "业务类型";
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label11.Location = new Point(250, 0x4f);
            this.label11.Margin = new Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x3f, 14);
            this.label11.TabIndex = 0x94;
            this.label11.Text = "物资流向";
            this.txt_billno.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_billno.Location = new Point(0x56, 13);
            this.txt_billno.Margin = new Padding(4);
            this.txt_billno.Name = "txt_billno";
            this.txt_billno.ReadOnly = true;
            this.txt_billno.Size = new Size(0x90, 0x17);
            this.txt_billno.TabIndex = 0x93;
            this.txt_billno.TextAlign = HorizontalAlignment.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label12.Location = new Point(0x19, 0x11);
            this.label12.Margin = new Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x3f, 14);
            this.label12.TabIndex = 0x92;
            this.label12.Text = "作业单号";
            this.txt_vehno.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_vehno.Location = new Point(0x20d, 13);
            this.txt_vehno.Margin = new Padding(4);
            this.txt_vehno.Name = "txt_vehno";
            this.txt_vehno.Size = new Size(0x90, 0x17);
            this.txt_vehno.TabIndex = 140;
            this.txt_vehno.TextAlign = HorizontalAlignment.Right;
            this.txt_vehno.KeyUp += new KeyEventHandler(this.txt_vehno_KeyUp);
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label9.Location = new Point(0x1de, 0x11);
            this.label9.Margin = new Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x31, 14);
            this.label9.TabIndex = 0x8b;
            this.label9.Text = "车牌号";
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.Location = new Point(0, 0xce);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(0x3bb, 0x18a);
            this.tabControl1.TabIndex = 0xc0;
            this.tabPage1.Controls.Add(this.tl_BillItem);
            this.tabPage1.Location = new Point(4, 0x17);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new Padding(3);
            this.tabPage1.Size = new Size(0x3b3, 0x16f);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "物资明细";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tl_BillItem.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.tl_BillItem.Appearance.FocusedRow.Options.UseFont = true;
            this.tl_BillItem.Appearance.FocusedRow.Options.UseTextOptions = true;
            this.tl_BillItem.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.tl_BillItem.Appearance.Row.Options.UseFont = true;
            this.tl_BillItem.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.tl_BillItem.Appearance.SelectedRow.ForeColor = Color.FromArgb(0, 0, 0x40);
            this.tl_BillItem.Appearance.SelectedRow.Options.UseFont = true;
            this.tl_BillItem.Appearance.SelectedRow.Options.UseForeColor = true;
            this.tl_BillItem.Appearance.SelectedRow.Options.UseTextOptions = true;
            this.tl_BillItem.BackgroundImage = (Image) resources.GetObject("tl_BillItem.BackgroundImage");
            this.tl_BillItem.Columns.AddRange(new TreeListColumn[] { this.tlc1, this.tlc2, this.tlc3, this.tlc4, this.tlc5, this.tlc6, this.tlc7, this.tlc8, this.tlc9, this.tlc10, this.tlc11, this.tlc12, this.tlc13 });
            this.tl_BillItem.Dock = DockStyle.Fill;
            this.tl_BillItem.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.tl_BillItem.HorzScrollVisibility = ScrollVisibility.Always;
            this.tl_BillItem.Location = new Point(3, 3);
            this.tl_BillItem.Name = "tl_BillItem";
            this.tl_BillItem.OptionsView.AutoWidth = false;
            this.tl_BillItem.OptionsView.ShowFocusedFrame = false;
            this.tl_BillItem.Size = new Size(0x3ad, 0x169);
            this.tl_BillItem.StateImageList = this.imageList1;
            this.tl_BillItem.TabIndex = 0xc0;
            this.tl_BillItem.TreeLevelWidth = 12;
            this.tlc1.Caption = "行号";
            this.tlc1.FieldName = "行号";
            this.tlc1.MinWidth = 160;
            this.tlc1.Name = "tlc1";
            this.tlc1.OptionsColumn.AllowEdit = false;
            this.tlc1.OptionsColumn.AllowMove = false;
            this.tlc1.OptionsColumn.AllowSort = false;
            this.tlc1.OptionsColumn.FixedWidth = true;
            this.tlc1.OptionsColumn.ReadOnly = true;
            this.tlc1.OptionsColumn.ShowInCustomizationForm = false;
            this.tlc1.VisibleIndex = 0;
            this.tlc1.Width = 0x2d;
            this.tlc2.Caption = "存货编码";
            this.tlc2.FieldName = "存货编码";
            this.tlc2.Name = "tlc2";
            this.tlc2.OptionsColumn.AllowEdit = false;
            this.tlc2.OptionsColumn.AllowMove = false;
            this.tlc2.OptionsColumn.AllowSort = false;
            this.tlc2.OptionsColumn.ReadOnly = true;
            this.tlc2.VisibleIndex = 1;
            this.tlc2.Width = 120;
            this.tlc3.Caption = "存货名称";
            this.tlc3.FieldName = "存货名称";
            this.tlc3.Name = "tlc3";
            this.tlc3.OptionsColumn.AllowEdit = false;
            this.tlc3.OptionsColumn.AllowMove = false;
            this.tlc3.OptionsColumn.AllowSort = false;
            this.tlc3.VisibleIndex = 2;
            this.tlc3.Width = 120;
            this.tlc4.Caption = "型号规格图号";
            this.tlc4.FieldName = "型号规格图号";
            this.tlc4.Name = "tlc4";
            this.tlc4.OptionsColumn.AllowEdit = false;
            this.tlc4.OptionsColumn.AllowMove = false;
            this.tlc4.OptionsColumn.AllowSort = false;
            this.tlc4.VisibleIndex = 3;
            this.tlc4.Width = 100;
            this.tlc5.Caption = "计量单位";
            this.tlc5.FieldName = "计量单位";
            this.tlc5.Name = "tlc5";
            this.tlc5.OptionsColumn.AllowEdit = false;
            this.tlc5.OptionsColumn.AllowMove = false;
            this.tlc5.OptionsColumn.AllowSort = false;
            this.tlc5.VisibleIndex = 4;
            this.tlc6.Caption = "数量";
            this.tlc6.FieldName = "数量";
            this.tlc6.Name = "tlc6";
            this.tlc6.OptionsColumn.AllowEdit = false;
            this.tlc6.OptionsColumn.AllowMove = false;
            this.tlc6.OptionsColumn.AllowSort = false;
            this.tlc6.VisibleIndex = 5;
            this.tlc7.Caption = "辅数量";
            this.tlc7.FieldName = "实际数量";
            this.tlc7.Name = "tlc7";
            this.tlc7.VisibleIndex = 6;
            this.tlc8.Caption = "实际数量";
            this.tlc8.FieldName = "实际数量";
            this.tlc8.Name = "tlc8";
            this.tlc8.VisibleIndex = 7;
            this.tlc9.Caption = "实际辅数量";
            this.tlc9.FieldName = "实际辅数量";
            this.tlc9.Name = "tlc9";
            this.tlc9.VisibleIndex = 8;
            this.tlc10.Caption = "状态";
            this.tlc10.FieldName = "状态";
            this.tlc10.Name = "tlc10";
            this.tlc10.VisibleIndex = 9;
            this.tlc11.Caption = "备注";
            this.tlc11.FieldName = "备注";
            this.tlc11.Name = "tlc11";
            this.tlc11.VisibleIndex = 10;
            this.tlc11.Width = 100;
            this.tlc12.Caption = "客商/业务单位";
            this.tlc12.FieldName = "客商/业务单位";
            this.tlc12.Name = "tlc12";
            this.tlc12.VisibleIndex = 11;
            this.tlc12.Width = 170;
            this.tlc13.Caption = "单据号";
            this.tlc13.FieldName = "单据号";
            this.tlc13.Name = "tlc13";
            this.tlc13.VisibleIndex = 12;
            this.tlc13.Width = 170;
            this.imageList1.ImageStream = (ImageListStreamer) resources.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "1.ico");
            this.imageList1.Images.SetKeyName(1, "2.ico");
            this.imageList1.Images.SetKeyName(2, "3.ico");
            this.imageList1.Images.SetKeyName(3, "4.ico");
            this.imageList1.Images.SetKeyName(4, "5.ico");
            this.imageList1.Images.SetKeyName(5, "6.ico");
            this.imageList1.Images.SetKeyName(6, "point.ico");
            this.tabPage2.Controls.Add(this.tl_taskflow);
            this.tabPage2.Location = new Point(4, 0x17);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new Padding(3);
            this.tabPage2.Size = new Size(0x3b3, 0x16f);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "实际路线";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tl_taskflow.BackgroundImage = (Image) resources.GetObject("tl_taskflow.BackgroundImage");
            this.tl_taskflow.Columns.AddRange(new TreeListColumn[] { this.treeListColumn1, this.treeListColumn2, this.treeListColumn3, this.treeListColumn4, this.treeListColumn5, this.treeListColumn6, this.treeListColumn7, this.treeListColumn8 });
            this.tl_taskflow.Dock = DockStyle.Fill;
            this.tl_taskflow.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.tl_taskflow.Location = new Point(3, 3);
            this.tl_taskflow.Name = "tl_taskflow";
            this.tl_taskflow.OptionsView.ShowFocusedFrame = false;
            this.tl_taskflow.Size = new Size(0x3ad, 0x169);
            this.tl_taskflow.TabIndex = 9;
            this.tl_taskflow.TreeLevelWidth = 12;
            this.treeListColumn1.AppearanceCell.BorderColor = Color.Red;
            this.treeListColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.treeListColumn1.AppearanceCell.Options.UseBorderColor = true;
            this.treeListColumn1.AppearanceCell.Options.UseFont = true;
            this.treeListColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn1.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
            this.treeListColumn1.Caption = "序号";
            this.treeListColumn1.FieldName = "状态";
            this.treeListColumn1.MinWidth = 10;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.AllowSize = false;
            this.treeListColumn1.OptionsColumn.FixedWidth = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 0x2d;
            this.treeListColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.treeListColumn2.AppearanceCell.Options.UseFont = true;
            this.treeListColumn2.Caption = "作业类型";
            this.treeListColumn2.FieldName = "作业类型";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowSize = false;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 0x19;
            this.treeListColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.treeListColumn3.AppearanceCell.Options.UseFont = true;
            this.treeListColumn3.Caption = "作业点名称";
            this.treeListColumn3.FieldName = "作业点名称";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.VisibleIndex = 2;
            this.treeListColumn3.Width = 60;
            this.treeListColumn4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.treeListColumn4.AppearanceCell.Options.UseFont = true;
            this.treeListColumn4.Caption = "作业结果";
            this.treeListColumn4.FieldName = "作业结果";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.OptionsColumn.AllowEdit = false;
            this.treeListColumn4.OptionsColumn.AllowMove = false;
            this.treeListColumn4.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.treeListColumn4.OptionsColumn.AllowSort = false;
            this.treeListColumn4.OptionsColumn.ShowInCustomizationForm = false;
            this.treeListColumn4.VisibleIndex = 3;
            this.treeListColumn4.Width = 60;
            this.treeListColumn5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.treeListColumn5.AppearanceCell.Options.UseFont = true;
            this.treeListColumn5.Caption = "作业人";
            this.treeListColumn5.FieldName = "作业人";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.OptionsColumn.FixedWidth = true;
            this.treeListColumn5.VisibleIndex = 4;
            this.treeListColumn5.Width = 0x37;
            this.treeListColumn6.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.treeListColumn6.AppearanceCell.Options.UseFont = true;
            this.treeListColumn6.Caption = "开始时间";
            this.treeListColumn6.FieldName = "开始时间";
            this.treeListColumn6.Name = "treeListColumn6";
            this.treeListColumn6.VisibleIndex = 5;
            this.treeListColumn6.Width = 100;
            this.treeListColumn7.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.treeListColumn7.AppearanceCell.Options.UseFont = true;
            this.treeListColumn7.Caption = "结束时间";
            this.treeListColumn7.FieldName = "结束时间";
            this.treeListColumn7.Name = "treeListColumn7";
            this.treeListColumn7.VisibleIndex = 6;
            this.treeListColumn7.Width = 100;
            this.treeListColumn8.Caption = "状态";
            this.treeListColumn8.FieldName = "状态";
            this.treeListColumn8.Name = "treeListColumn8";
            this.treeListColumn8.VisibleIndex = 7;
            this.tabPage3.Controls.Add(this.tl_door_limite);
            this.tabPage3.Location = new Point(4, 0x17);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new Padding(3);
            this.tabPage3.Size = new Size(0x3b3, 0x16f);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "进出门限制";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tl_door_limite.BackgroundImage = (Image) resources.GetObject("tl_door_limite.BackgroundImage");
            this.tl_door_limite.Columns.AddRange(new TreeListColumn[] { this.treeListColumn19, this.treeListColumn20, this.treeListColumn21 });
            this.tl_door_limite.Dock = DockStyle.Fill;
            this.tl_door_limite.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.tl_door_limite.Location = new Point(3, 3);
            this.tl_door_limite.Name = "tl_door_limite";
            this.tl_door_limite.OptionsView.AutoWidth = false;
            this.tl_door_limite.OptionsView.ShowFocusedFrame = false;
            this.tl_door_limite.Size = new Size(0x3ad, 0x169);
            this.tl_door_limite.StateImageList = this.imageList1;
            this.tl_door_limite.TabIndex = 12;
            this.tl_door_limite.TreeLevelWidth = 12;
            this.treeListColumn19.Caption = "进出门";
            this.treeListColumn19.FieldName = "进出门";
            this.treeListColumn19.MinWidth = 160;
            this.treeListColumn19.Name = "treeListColumn19";
            this.treeListColumn19.VisibleIndex = 0;
            this.treeListColumn19.Width = 90;
            this.treeListColumn20.Caption = "门岗编码";
            this.treeListColumn20.FieldName = "门岗编码";
            this.treeListColumn20.Name = "treeListColumn20";
            this.treeListColumn20.VisibleIndex = 1;
            this.treeListColumn20.Width = 100;
            this.treeListColumn21.Caption = "门岗名称";
            this.treeListColumn21.FieldName = "门岗名称";
            this.treeListColumn21.Name = "treeListColumn21";
            this.treeListColumn21.VisibleIndex = 2;
            this.treeListColumn21.Width = 150;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x3bb, 600);
            base.Controls.Add(this.tabControl1);
            base.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            base.Name = "FrmTaskSearch";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "作业单";
            base.Load += new EventHandler(this.FrmTaskSearch_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tl_BillItem.EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tl_taskflow.EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tl_door_limite.EndInit();
            base.ResumeLayout(false);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex != -1)
            {
                this.txt_vehno.Text = this.listBox1.Text;
                this.listBox1.Visible = false;
                this.txt_vehno.SelectionStart = this.txt_vehno.Text.Length;
                this.txt_vehno.Focus();
                if (!this.FetchTask())
                {
                    this.InitForm();
                    this.task = null;
                }
            }
        }

        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    this.txt_vehno.Text = this.listBox1.Text;
                    this.listBox1.Visible = false;
                    this.txt_vehno.SelectionStart = this.txt_vehno.Text.Length;
                    this.txt_vehno.Focus();
                    if (!this.FetchTask())
                    {
                        this.InitForm();
                        this.task = null;
                    }
                    break;

                case 0x1b:
                    this.listBox1.Visible = false;
                    this.txt_vehno.Focus();
                    break;
            }
        }

        public void LoadDoorLimite()
        {
            TreeListNode node = null;
            string wPBM;
            string wPName;
            if (this.task.doorroute[0].ISOver)
            {
                wPBM = this.task.doorroute[0].WPS[0].WPBM;
                wPName = this.task.doorroute[0].WPS[0].WPName;
                this.tl_door_limite.AppendNode(new object[] { "进门", wPBM, wPName }, -1, 4, 4, 4);
            }
            else
            {
                node = this.tl_door_limite.AppendNode(new object[] { "进门" }, -1, 5, 5, 5);
                for (int j = 0; j < this.task.doorroute[0].WPS.Length; j++)
                {
                    wPBM = this.task.doorroute[0].WPS[j].WPBM;
                    wPName = this.task.doorroute[0].WPS[j].WPName;
                    this.tl_door_limite.AppendNode(new object[] { "", wPBM, wPName }, node.Id, 6, 6, 6);
                }
            }
            node = this.tl_door_limite.AppendNode(new object[] { "出门" }, -1, 5, 5, 5);
            for (int i = 0; i < this.task.doorroute[1].WPS.Length; i++)
            {
                wPBM = this.task.doorroute[1].WPS[i].WPBM;
                wPName = this.task.doorroute[1].WPS[i].WPName;
                this.tl_door_limite.AppendNode(new object[] { "", wPBM, wPName }, node.Id, 6, 6, 6);
            }
            this.tl_door_limite.ExpandAll();
        }

        public void LoadTaskFlow()
        {
            VehIC_WF.CommonService.TaskFlow[] taskFlowRecs = this.cs.GetTaskFlowRecs(this.task.billno);
            this.tl_taskflow.Nodes.Clear();
            for (int i = 0; i < taskFlowRecs.Length; i++)
            {
                object[] nodeData = new object[] { taskFlowRecs[i].XH, taskFlowRecs[i].WCTypeName, taskFlowRecs[i].WCName, taskFlowRecs[i].Result, taskFlowRecs[i].OperatorName, taskFlowRecs[i].BeginTime, taskFlowRecs[i].EndTime, taskFlowRecs[i].Status };
                this.tl_taskflow.AppendNode(nodeData, -1, -1, -1, -1);
            }
        }

        private void Report_OnAfterPrint(IfrxComponent Sender)
        {
        }

        private void Report_OnBeforePrint(IfrxComponent Sender)
        {
            if (Sender is IfrxView)
            {
                if (Sender.Name == "Memo4")
                {
                    (Sender as IfrxCustomMemoView).Text = this.task.billno;
                }
                if (Sender.Name == "Memo12")
                {
                    (Sender as IfrxCustomMemoView).Text = this.task.fksj;
                }
                if (Sender.Name == "Memo16")
                {
                    (Sender as IfrxCustomMemoView).Text = this.task.vehno;
                }
                if (Sender.Name == "Memo8")
                {
                    (Sender as IfrxCustomMemoView).Text = this.txt_billtype.Text;
                }
                if (Sender.Name == "Memo20")
                {
                    (Sender as IfrxCustomMemoView).Text = this.txt_icno.Text;
                }
                if (Sender.Name == "Memo18")
                {
                    (Sender as IfrxCustomMemoView).Text = this.task.vehtype;
                }
                if (Sender.Name == "Memo6")
                {
                    (Sender as IfrxCustomMemoView).Text = this.txt_billstatus.Text;
                }
                if (Sender.Name == "Memo24")
                {
                    (Sender as IfrxCustomMemoView).Text = this.chbox_needweigh.Checked ? "是" : "否";
                }
                if (Sender.Name == "Memo22")
                {
                    (Sender as IfrxCustomMemoView).Text = this.chbox_fixveh.Checked ? "是" : "否";
                }
                if (Sender.Name == "Memo14")
                {
                    (Sender as IfrxCustomMemoView).Text = this.rb_wzlx_in.Checked ? "入厂" : "出厂";
                }
                if (Sender.Name == "Memo26")
                {
                    (Sender as IfrxCustomMemoView).Text = this.cb_th.Checked ? "是" : "否";
                }
                if (Sender.Name == "Memo46")
                {
                    (Sender as IfrxCustomMemoView).Text = this.txt_remark.Text;
                }
            }
        }

        private void txt_vehno_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    this.listBox1.Visible = false;
                    if (!this.FetchTask())
                    {
                        this.InitForm();
                        this.task = null;
                    }
                    return;

                case 0x1b:
                    if (this.listBox1.Visible)
                    {
                        this.listBox1.Visible = false;
                        this.txt_vehno.Focus();
                    }
                    return;

                case 0x20:
                    this.listBox1.Visible = false;
                    return;

                case 40:
                    if (this.listBox1.Visible)
                    {
                        this.listBox1.Focus();
                        this.listBox1.SetSelected(0, true);
                    }
                    return;
            }
            string vehno = this.txt_vehno.Text.Trim();
            if ((vehno != "") && (vehno.Length > 1))
            {
                this.listBox1.Items.Clear();
                this.listBox1.Visible = this.FillListView(vehno);
            }
            else
            {
                this.listBox1.Visible = false;
            }
        }

        public void ViewTaskBill()
        {
            if (this.task != null)
            {
                this.btn_task_cancel.Enabled = false;
                this.btn_task_terminal.Enabled = false;
                if (FrmMain.localinfo.workpoint.type == VehIC_BL.RouteNodeType.door)
                {
                    this.btn_task_cancel.Enabled = this.task.status == 1;
                    this.btn_task_terminal.Enabled = this.FetchTerminalBtnStatus();
                }
                else if (FrmMain.localinfo.workpoint.type != VehIC_BL.RouteNodeType.unknow)
                {
                    this.btn_task_cancel.Enabled = true;
                    this.btn_task_terminal.Enabled = true;
                }
                this.tl_BillItem.Nodes.Clear();
                this.tl_taskflow.Nodes.Clear();
                this.tl_door_limite.Nodes.Clear();
                this.txt_billno.Text = this.task.billno;
                this.txt_billstatus.Text = VehIC_WF.Utility.Common.GetNoticeStatusDesc(this.task.status);
                this.txt_billtype.Text = this.task.billtypedesc;
                this.txt_fkr.Text = this.task.fkr;
                this.txt_fksj.Text = this.task.fksj;
                VehIC_WF.ICCardManageService.ICCard card = this.ics.GetCard(this.task.icno);
                this.txt_icno.Text = card.CardNo;
                this.txt_vehno.Text = this.task.vehno;
                this.txt_vehtype.Text = this.task.vehtype;
                this.txt_remark.Text = this.task.Remark;
                this.chbox_fixveh.Checked = this.task.vehisfix;
                this.chbox_needweigh.Checked = this.task.needweigh;
                this.rb_wzlx_in.Checked = this.task.wzlx == "0";
                this.rb_wzlx_out.Checked = this.task.wzlx == "1";
                if (this.task.billtype == 0)
                {
                    this.cb_th.Checked = this.task.wzlx == "1";
                }
                if (this.task.billtype == 2)
                {
                    this.cb_th.Checked = this.task.wzlx == "0";
                }
                if (this.task.Items != null)
                {
                    for (int i = 0; i < this.task.Items.Length; i++)
                    {
                        VehIC_WF.CommonService.NBItem item = this.task.Items[i];
                        string str = string.Empty;
                        int imageIndex = 1;
                        switch (item.status)
                        {
                            case 0:
                                str = "初始";
                                break;

                            case 1:
                                str = "开始";
                                imageIndex = 2;
                                break;

                            case 2:
                                str = "完成";
                                imageIndex = 0;
                                break;
                        }
                        object[] nodeData = new object[] { item.rowno, item.invcode, item.invname, item.spectypegraphid, item.unit, item.plannum, item.planassistnum, item.factnum, item.factassistnum, str, item.remark, item.Vendor, item.BillNo };
                        TreeListNode node = this.tl_BillItem.AppendNode(nodeData, -1, imageIndex, imageIndex, imageIndex);
                        if (item.status != 2)
                        {
                            for (int j = 0; j < item.itemroute.Length; j++)
                            {
                                string wPBM;
                                string wPName;
                                string routeTypeDesc = VehIC_BL.RouteNode.GetRouteTypeDesc(VehIC_BL.RouteNode.GetRouteType(item.itemroute[j].WPTypeCode));
                                if (item.itemroute[j].ISOver)
                                {
                                    if (this.abitemid == string.Empty)
                                    {
                                        this.abitemid = item.rowid;
                                        this.abwpcode = item.itemroute[j].WPS[0].WPCode;
                                    }
                                    wPBM = item.itemroute[j].WPS[0].WPBM;
                                    wPName = item.itemroute[j].WPS[0].WPName;
                                    this.tl_BillItem.AppendNode(new object[] { "", routeTypeDesc, wPBM, wPName }, node.Id, 4, 4, 4);
                                }
                                else
                                {
                                    TreeListNode node2 = this.tl_BillItem.AppendNode(new object[] { "", routeTypeDesc }, node.Id, 5, 5, 5);
                                    for (int k = 0; k < item.itemroute[j].WPS.Length; k++)
                                    {
                                        wPBM = item.itemroute[j].WPS[k].WPBM;
                                        wPName = item.itemroute[j].WPS[k].WPName;
                                        this.tl_BillItem.AppendNode(new object[] { "", "", wPBM, wPName }, node2.Id, 6, 6, 6);
                                    }
                                }
                            }
                        }
                        this.tl_BillItem.ExpandAll();
                    }
                    this.LoadTaskFlow();
                    this.LoadDoorLimite();
                }
            }
        }
    }
}

