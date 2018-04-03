namespace VehIC_WF
{
    using DevExpress.Utils;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using VehIC_BL;
    using VehIC_WF.CommonService;
    using VehIC_WF.ICCardManageService;
    using VehIC_WF.Utility;

    public class FrmTaskBillInfo : Form
    {
        public string billno = string.Empty;
        public VehIC_WF.ICCardManageService.ICCard card = null;
        private CheckBox chbox_fixveh;
        private CheckBox chbox_needweigh;
        private CheckBox chbox_th;
        private IContainer components = null;
        public VehIC_WF.CommonService.CommonService cs;
        private GroupBox groupBox1;
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
        private Label label6;
        private Label label9;
        private Panel panel2;
        private RadioButton rb_task_in;
        private RadioButton rb_task_out;
        private RadioButton rb_wzlx_in;
        private RadioButton rb_wzlx_out;
        private TabControl tabControl2;
        private TabPage tabPage2;
        private TabPage tabPage4;
        private TabPage tabPage5;
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
        private TreeListColumn treeListColumn11;
        private TreeListColumn treeListColumn12;
        private TreeListColumn treeListColumn13;
        private TreeListColumn treeListColumn14;
        private TreeListColumn treeListColumn15;
        private TreeListColumn treeListColumn16;
        private TreeListColumn treeListColumn17;
        private TreeListColumn treeListColumn18;
        private TreeListColumn treeListColumn19;
        private TreeListColumn treeListColumn20;
        private TreeListColumn treeListColumn21;
        private TextBox txt_billno;
        private TextBox txt_billstatus;
        private TextBox txt_billtype;
        private TextBox txt_fkr;
        private TextBox txt_fksj;
        private TextBox txt_icno;
        private TextBox txt_remark;
        private TextBox txt_vehno;
        private TextBox txt_vehtype;

        public FrmTaskBillInfo(string billno)
        {
            this.InitializeComponent();
            this.billno = billno;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmTaskBillInfo_Load(object sender, EventArgs e)
        {
            this.cs = new VehIC_WF.CommonService.CommonService();
            this.ics = new VehIC_WF.ICCardManageService.ICCardManageService();

            this.cs.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/CommonService.asmx";
            this.ics.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/ICCardManageService.asmx";

            try
            {
                this.task = this.cs.GetTaskBillByBillNo(this.billno);
                this.ViewTaskBill();
            }
            catch
            {
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTaskBillInfo));
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_remark = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chbox_th = new System.Windows.Forms.CheckBox();
            this.txt_icno = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_task_out = new System.Windows.Forms.RadioButton();
            this.rb_task_in = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_fksj = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rb_wzlx_out = new System.Windows.Forms.RadioButton();
            this.rb_wzlx_in = new System.Windows.Forms.RadioButton();
            this.txt_billstatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_fkr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chbox_needweigh = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chbox_fixveh = new System.Windows.Forms.CheckBox();
            this.txt_vehtype = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_billtype = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_billno = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_vehno = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tl_BillItem = new DevExpress.XtraTreeList.TreeList();
            this.tlc1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlc2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlc3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlc4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlc5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlc6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlc7 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlc8 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlc9 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlc10 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlc11 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlc12 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlc13 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tl_taskflow = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn11 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn12 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn13 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn14 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn15 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn16 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn17 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn18 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tl_door_limite = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn19 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn20 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn21 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tl_BillItem)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tl_taskflow)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tl_door_limite)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txt_remark);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.chbox_th);
            this.panel2.Controls.Add(this.txt_icno);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label5);
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
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(865, 195);
            this.panel2.TabIndex = 189;
            // 
            // txt_remark
            // 
            this.txt_remark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_remark.Location = new System.Drawing.Point(88, 135);
            this.txt_remark.Margin = new System.Windows.Forms.Padding(4);
            this.txt_remark.Multiline = true;
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.ReadOnly = true;
            this.txt_remark.Size = new System.Drawing.Size(713, 51);
            this.txt_remark.TabIndex = 221;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(55, 138);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 220;
            this.label6.Text = "说明";
            // 
            // chbox_th
            // 
            this.chbox_th.AutoSize = true;
            this.chbox_th.Enabled = false;
            this.chbox_th.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chbox_th.Location = new System.Drawing.Point(706, 78);
            this.chbox_th.Name = "chbox_th";
            this.chbox_th.Size = new System.Drawing.Size(91, 20);
            this.chbox_th.TabIndex = 187;
            this.chbox_th.Text = "是否退货";
            this.chbox_th.UseVisualStyleBackColor = true;
            // 
            // txt_icno
            // 
            this.txt_icno.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_icno.Location = new System.Drawing.Point(657, 14);
            this.txt_icno.Margin = new System.Windows.Forms.Padding(4);
            this.txt_icno.Name = "txt_icno";
            this.txt_icno.ReadOnly = true;
            this.txt_icno.Size = new System.Drawing.Size(144, 23);
            this.txt_icno.TabIndex = 173;
            this.txt_icno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_task_out);
            this.groupBox1.Controls.Add(this.rb_task_in);
            this.groupBox1.Location = new System.Drawing.Point(657, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 33);
            this.groupBox1.TabIndex = 186;
            this.groupBox1.TabStop = false;
            // 
            // rb_task_out
            // 
            this.rb_task_out.AutoSize = true;
            this.rb_task_out.Enabled = false;
            this.rb_task_out.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rb_task_out.Location = new System.Drawing.Point(81, 11);
            this.rb_task_out.Name = "rb_task_out";
            this.rb_task_out.Size = new System.Drawing.Size(58, 20);
            this.rb_task_out.TabIndex = 175;
            this.rb_task_out.Text = "出厂";
            this.rb_task_out.UseVisualStyleBackColor = true;
            // 
            // rb_task_in
            // 
            this.rb_task_in.AutoSize = true;
            this.rb_task_in.Checked = true;
            this.rb_task_in.Enabled = false;
            this.rb_task_in.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rb_task_in.Location = new System.Drawing.Point(11, 10);
            this.rb_task_in.Name = "rb_task_in";
            this.rb_task_in.Size = new System.Drawing.Size(58, 20);
            this.rb_task_in.TabIndex = 174;
            this.rb_task_in.TabStop = true;
            this.rb_task_in.Text = "进厂";
            this.rb_task_in.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(596, 47);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 185;
            this.label5.Text = "进出类别";
            // 
            // txt_fksj
            // 
            this.txt_fksj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_fksj.Location = new System.Drawing.Point(368, 44);
            this.txt_fksj.Margin = new System.Windows.Forms.Padding(4);
            this.txt_fksj.Name = "txt_fksj";
            this.txt_fksj.ReadOnly = true;
            this.txt_fksj.Size = new System.Drawing.Size(144, 23);
            this.txt_fksj.TabIndex = 179;
            this.txt_fksj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rb_wzlx_out);
            this.groupBox3.Controls.Add(this.rb_wzlx_in);
            this.groupBox3.Location = new System.Drawing.Point(368, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(144, 33);
            this.groupBox3.TabIndex = 182;
            this.groupBox3.TabStop = false;
            // 
            // rb_wzlx_out
            // 
            this.rb_wzlx_out.AutoSize = true;
            this.rb_wzlx_out.Enabled = false;
            this.rb_wzlx_out.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rb_wzlx_out.Location = new System.Drawing.Point(81, 11);
            this.rb_wzlx_out.Name = "rb_wzlx_out";
            this.rb_wzlx_out.Size = new System.Drawing.Size(58, 20);
            this.rb_wzlx_out.TabIndex = 175;
            this.rb_wzlx_out.Text = "出厂";
            this.rb_wzlx_out.UseVisualStyleBackColor = true;
            // 
            // rb_wzlx_in
            // 
            this.rb_wzlx_in.AutoSize = true;
            this.rb_wzlx_in.Checked = true;
            this.rb_wzlx_in.Enabled = false;
            this.rb_wzlx_in.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rb_wzlx_in.Location = new System.Drawing.Point(11, 10);
            this.rb_wzlx_in.Name = "rb_wzlx_in";
            this.rb_wzlx_in.Size = new System.Drawing.Size(58, 20);
            this.rb_wzlx_in.TabIndex = 174;
            this.rb_wzlx_in.TabStop = true;
            this.rb_wzlx_in.Text = "入厂";
            this.rb_wzlx_in.UseVisualStyleBackColor = true;
            // 
            // txt_billstatus
            // 
            this.txt_billstatus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_billstatus.Location = new System.Drawing.Point(88, 44);
            this.txt_billstatus.Margin = new System.Windows.Forms.Padding(4);
            this.txt_billstatus.Name = "txt_billstatus";
            this.txt_billstatus.ReadOnly = true;
            this.txt_billstatus.Size = new System.Drawing.Size(144, 23);
            this.txt_billstatus.TabIndex = 181;
            this.txt_billstatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(27, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 180;
            this.label4.Text = "单据状态";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(307, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 178;
            this.label2.Text = "发卡时间";
            // 
            // txt_fkr
            // 
            this.txt_fkr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_fkr.Location = new System.Drawing.Point(368, 14);
            this.txt_fkr.Margin = new System.Windows.Forms.Padding(4);
            this.txt_fkr.Name = "txt_fkr";
            this.txt_fkr.ReadOnly = true;
            this.txt_fkr.Size = new System.Drawing.Size(144, 23);
            this.txt_fkr.TabIndex = 177;
            this.txt_fkr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(321, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 176;
            this.label3.Text = "发卡人";
            // 
            // chbox_needweigh
            // 
            this.chbox_needweigh.AutoSize = true;
            this.chbox_needweigh.Enabled = false;
            this.chbox_needweigh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chbox_needweigh.Location = new System.Drawing.Point(599, 78);
            this.chbox_needweigh.Name = "chbox_needweigh";
            this.chbox_needweigh.Size = new System.Drawing.Size(91, 20);
            this.chbox_needweigh.TabIndex = 175;
            this.chbox_needweigh.Text = "是否计重";
            this.chbox_needweigh.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(610, 17);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 14);
            this.label10.TabIndex = 172;
            this.label10.Text = "IC卡号";
            // 
            // chbox_fixveh
            // 
            this.chbox_fixveh.AutoSize = true;
            this.chbox_fixveh.Enabled = false;
            this.chbox_fixveh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chbox_fixveh.Location = new System.Drawing.Point(599, 107);
            this.chbox_fixveh.Name = "chbox_fixveh";
            this.chbox_fixveh.Size = new System.Drawing.Size(123, 20);
            this.chbox_fixveh.TabIndex = 158;
            this.chbox_fixveh.Text = "是否固定车辆";
            this.chbox_fixveh.UseVisualStyleBackColor = true;
            // 
            // txt_vehtype
            // 
            this.txt_vehtype.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_vehtype.Location = new System.Drawing.Point(368, 105);
            this.txt_vehtype.Margin = new System.Windows.Forms.Padding(4);
            this.txt_vehtype.Name = "txt_vehtype";
            this.txt_vehtype.ReadOnly = true;
            this.txt_vehtype.Size = new System.Drawing.Size(144, 23);
            this.txt_vehtype.TabIndex = 157;
            this.txt_vehtype.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(335, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 156;
            this.label1.Text = "车型";
            // 
            // txt_billtype
            // 
            this.txt_billtype.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_billtype.Location = new System.Drawing.Point(88, 75);
            this.txt_billtype.Margin = new System.Windows.Forms.Padding(4);
            this.txt_billtype.Name = "txt_billtype";
            this.txt_billtype.ReadOnly = true;
            this.txt_billtype.Size = new System.Drawing.Size(144, 23);
            this.txt_billtype.TabIndex = 151;
            this.txt_billtype.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(27, 79);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 14);
            this.label14.TabIndex = 150;
            this.label14.Text = "业务类型";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(307, 79);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 148;
            this.label11.Text = "物资流向";
            // 
            // txt_billno
            // 
            this.txt_billno.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_billno.Location = new System.Drawing.Point(88, 14);
            this.txt_billno.Margin = new System.Windows.Forms.Padding(4);
            this.txt_billno.Name = "txt_billno";
            this.txt_billno.ReadOnly = true;
            this.txt_billno.Size = new System.Drawing.Size(144, 23);
            this.txt_billno.TabIndex = 147;
            this.txt_billno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(27, 18);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 14);
            this.label12.TabIndex = 146;
            this.label12.Text = "作业单号";
            // 
            // txt_vehno
            // 
            this.txt_vehno.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_vehno.Location = new System.Drawing.Point(88, 104);
            this.txt_vehno.Margin = new System.Windows.Forms.Padding(4);
            this.txt_vehno.Name = "txt_vehno";
            this.txt_vehno.ReadOnly = true;
            this.txt_vehno.Size = new System.Drawing.Size(144, 23);
            this.txt_vehno.TabIndex = 140;
            this.txt_vehno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(41, 108);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 14);
            this.label9.TabIndex = 139;
            this.label9.Text = "车牌号";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl2.Location = new System.Drawing.Point(0, 195);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(865, 386);
            this.tabControl2.TabIndex = 190;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tl_BillItem);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(857, 358);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "物资明细";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tl_BillItem
            // 
            this.tl_BillItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tl_BillItem.BackgroundImage")));
            this.tl_BillItem.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlc1,
            this.tlc2,
            this.tlc3,
            this.tlc4,
            this.tlc5,
            this.tlc6,
            this.tlc7,
            this.tlc8,
            this.tlc9,
            this.tlc10,
            this.tlc11,
            this.tlc12,
            this.tlc13});
            this.tl_BillItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tl_BillItem.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tl_BillItem.HorzScrollVisibility = DevExpress.XtraTreeList.ScrollVisibility.Always;
            this.tl_BillItem.Location = new System.Drawing.Point(3, 3);
            this.tl_BillItem.Name = "tl_BillItem";
            this.tl_BillItem.OptionsView.AutoWidth = false;
            this.tl_BillItem.OptionsView.ShowFocusedFrame = false;
            this.tl_BillItem.Size = new System.Drawing.Size(851, 352);
            this.tl_BillItem.StateImageList = this.imageList1;
            this.tl_BillItem.TabIndex = 191;
            this.tl_BillItem.TreeLevelWidth = 12;
            // 
            // tlc1
            // 
            this.tlc1.Caption = "行号";
            this.tlc1.FieldName = "行号";
            this.tlc1.MinWidth = 55;
            this.tlc1.Name = "tlc1";
            this.tlc1.OptionsColumn.AllowEdit = false;
            this.tlc1.OptionsColumn.AllowMove = false;
            this.tlc1.OptionsColumn.AllowSort = false;
            this.tlc1.OptionsColumn.ReadOnly = true;
            this.tlc1.OptionsColumn.ShowInCustomizationForm = false;
            this.tlc1.Visible = true;
            this.tlc1.VisibleIndex = 0;
            this.tlc1.Width = 45;
            // 
            // tlc2
            // 
            this.tlc2.Caption = "存货编码";
            this.tlc2.FieldName = "存货编码";
            this.tlc2.Name = "tlc2";
            this.tlc2.OptionsColumn.AllowEdit = false;
            this.tlc2.OptionsColumn.AllowMove = false;
            this.tlc2.OptionsColumn.AllowSort = false;
            this.tlc2.OptionsColumn.ReadOnly = true;
            this.tlc2.Visible = true;
            this.tlc2.VisibleIndex = 1;
            this.tlc2.Width = 120;
            // 
            // tlc3
            // 
            this.tlc3.Caption = "存货名称";
            this.tlc3.FieldName = "存货名称";
            this.tlc3.Name = "tlc3";
            this.tlc3.OptionsColumn.AllowEdit = false;
            this.tlc3.OptionsColumn.AllowMove = false;
            this.tlc3.OptionsColumn.AllowSort = false;
            this.tlc3.Visible = true;
            this.tlc3.VisibleIndex = 2;
            this.tlc3.Width = 120;
            // 
            // tlc4
            // 
            this.tlc4.Caption = "型号规格图号";
            this.tlc4.FieldName = "型号规格图号";
            this.tlc4.Name = "tlc4";
            this.tlc4.OptionsColumn.AllowEdit = false;
            this.tlc4.OptionsColumn.AllowMove = false;
            this.tlc4.OptionsColumn.AllowSort = false;
            this.tlc4.Visible = true;
            this.tlc4.VisibleIndex = 3;
            this.tlc4.Width = 100;
            // 
            // tlc5
            // 
            this.tlc5.Caption = "计量单位";
            this.tlc5.FieldName = "计量单位";
            this.tlc5.Name = "tlc5";
            this.tlc5.OptionsColumn.AllowEdit = false;
            this.tlc5.OptionsColumn.AllowMove = false;
            this.tlc5.OptionsColumn.AllowSort = false;
            this.tlc5.Visible = true;
            this.tlc5.VisibleIndex = 4;
            // 
            // tlc6
            // 
            this.tlc6.Caption = "数量";
            this.tlc6.FieldName = "数量";
            this.tlc6.Name = "tlc6";
            this.tlc6.OptionsColumn.AllowEdit = false;
            this.tlc6.OptionsColumn.AllowMove = false;
            this.tlc6.OptionsColumn.AllowSort = false;
            this.tlc6.Visible = true;
            this.tlc6.VisibleIndex = 5;
            // 
            // tlc7
            // 
            this.tlc7.Caption = "辅数量";
            this.tlc7.FieldName = "实际数量";
            this.tlc7.Name = "tlc7";
            this.tlc7.Visible = true;
            this.tlc7.VisibleIndex = 6;
            // 
            // tlc8
            // 
            this.tlc8.Caption = "实际数量";
            this.tlc8.FieldName = "实际数量";
            this.tlc8.Name = "tlc8";
            this.tlc8.Visible = true;
            this.tlc8.VisibleIndex = 7;
            // 
            // tlc9
            // 
            this.tlc9.Caption = "实际辅数量";
            this.tlc9.FieldName = "实际辅数量";
            this.tlc9.Name = "tlc9";
            this.tlc9.Visible = true;
            this.tlc9.VisibleIndex = 8;
            // 
            // tlc10
            // 
            this.tlc10.Caption = "状态";
            this.tlc10.FieldName = "状态";
            this.tlc10.Name = "tlc10";
            this.tlc10.Visible = true;
            this.tlc10.VisibleIndex = 9;
            // 
            // tlc11
            // 
            this.tlc11.Caption = "备注";
            this.tlc11.FieldName = "备注";
            this.tlc11.Name = "tlc11";
            this.tlc11.Visible = true;
            this.tlc11.VisibleIndex = 10;
            // 
            // tlc12
            // 
            this.tlc12.Caption = "客商/业务单位";
            this.tlc12.FieldName = "客商/业务单位";
            this.tlc12.Name = "tlc12";
            this.tlc12.Visible = true;
            this.tlc12.VisibleIndex = 11;
            this.tlc12.Width = 160;
            // 
            // tlc13
            // 
            this.tlc13.Caption = "单据号";
            this.tlc13.FieldName = "单据号";
            this.tlc13.Name = "tlc13";
            this.tlc13.Visible = true;
            this.tlc13.VisibleIndex = 12;
            this.tlc13.Width = 160;
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
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tl_taskflow);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(857, 358);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "实际路线";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tl_taskflow
            // 
            this.tl_taskflow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tl_taskflow.BackgroundImage")));
            this.tl_taskflow.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn11,
            this.treeListColumn12,
            this.treeListColumn13,
            this.treeListColumn14,
            this.treeListColumn15,
            this.treeListColumn16,
            this.treeListColumn17,
            this.treeListColumn18});
            this.tl_taskflow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tl_taskflow.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tl_taskflow.Location = new System.Drawing.Point(3, 3);
            this.tl_taskflow.Name = "tl_taskflow";
            this.tl_taskflow.OptionsView.ShowFocusedFrame = false;
            this.tl_taskflow.Size = new System.Drawing.Size(851, 352);
            this.tl_taskflow.TabIndex = 10;
            this.tl_taskflow.TreeLevelWidth = 12;
            // 
            // treeListColumn11
            // 
            this.treeListColumn11.AppearanceCell.BorderColor = System.Drawing.Color.Red;
            this.treeListColumn11.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn11.AppearanceCell.Options.UseBorderColor = true;
            this.treeListColumn11.AppearanceCell.Options.UseFont = true;
            this.treeListColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treeListColumn11.Caption = "序号";
            this.treeListColumn11.FieldName = "状态";
            this.treeListColumn11.MinWidth = 16;
            this.treeListColumn11.Name = "treeListColumn11";
            this.treeListColumn11.OptionsColumn.AllowEdit = false;
            this.treeListColumn11.OptionsColumn.AllowSize = false;
            this.treeListColumn11.OptionsColumn.FixedWidth = true;
            this.treeListColumn11.Visible = true;
            this.treeListColumn11.VisibleIndex = 0;
            this.treeListColumn11.Width = 45;
            // 
            // treeListColumn12
            // 
            this.treeListColumn12.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn12.AppearanceCell.Options.UseFont = true;
            this.treeListColumn12.Caption = "作业类型";
            this.treeListColumn12.FieldName = "作业类型";
            this.treeListColumn12.Name = "treeListColumn12";
            this.treeListColumn12.OptionsColumn.AllowSize = false;
            this.treeListColumn12.Visible = true;
            this.treeListColumn12.VisibleIndex = 1;
            this.treeListColumn12.Width = 25;
            // 
            // treeListColumn13
            // 
            this.treeListColumn13.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn13.AppearanceCell.Options.UseFont = true;
            this.treeListColumn13.Caption = "作业点名称";
            this.treeListColumn13.FieldName = "作业点名称";
            this.treeListColumn13.Name = "treeListColumn13";
            this.treeListColumn13.Visible = true;
            this.treeListColumn13.VisibleIndex = 2;
            this.treeListColumn13.Width = 60;
            // 
            // treeListColumn14
            // 
            this.treeListColumn14.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn14.AppearanceCell.Options.UseFont = true;
            this.treeListColumn14.Caption = "作业结果";
            this.treeListColumn14.FieldName = "作业结果";
            this.treeListColumn14.Name = "treeListColumn14";
            this.treeListColumn14.OptionsColumn.AllowEdit = false;
            this.treeListColumn14.OptionsColumn.AllowMove = false;
            this.treeListColumn14.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.treeListColumn14.OptionsColumn.AllowSort = false;
            this.treeListColumn14.OptionsColumn.ShowInCustomizationForm = false;
            this.treeListColumn14.Visible = true;
            this.treeListColumn14.VisibleIndex = 3;
            this.treeListColumn14.Width = 60;
            // 
            // treeListColumn15
            // 
            this.treeListColumn15.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn15.AppearanceCell.Options.UseFont = true;
            this.treeListColumn15.Caption = "作业人";
            this.treeListColumn15.FieldName = "作业人";
            this.treeListColumn15.Name = "treeListColumn15";
            this.treeListColumn15.OptionsColumn.FixedWidth = true;
            this.treeListColumn15.Visible = true;
            this.treeListColumn15.VisibleIndex = 4;
            this.treeListColumn15.Width = 55;
            // 
            // treeListColumn16
            // 
            this.treeListColumn16.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn16.AppearanceCell.Options.UseFont = true;
            this.treeListColumn16.Caption = "开始时间";
            this.treeListColumn16.FieldName = "开始时间";
            this.treeListColumn16.Name = "treeListColumn16";
            this.treeListColumn16.Visible = true;
            this.treeListColumn16.VisibleIndex = 5;
            this.treeListColumn16.Width = 100;
            // 
            // treeListColumn17
            // 
            this.treeListColumn17.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn17.AppearanceCell.Options.UseFont = true;
            this.treeListColumn17.Caption = "结束时间";
            this.treeListColumn17.FieldName = "结束时间";
            this.treeListColumn17.Name = "treeListColumn17";
            this.treeListColumn17.Visible = true;
            this.treeListColumn17.VisibleIndex = 6;
            this.treeListColumn17.Width = 100;
            // 
            // treeListColumn18
            // 
            this.treeListColumn18.Caption = "状态";
            this.treeListColumn18.FieldName = "状态";
            this.treeListColumn18.Name = "treeListColumn18";
            this.treeListColumn18.Visible = true;
            this.treeListColumn18.VisibleIndex = 7;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tl_door_limite);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(857, 358);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "进出门限制";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tl_door_limite
            // 
            this.tl_door_limite.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tl_door_limite.BackgroundImage")));
            this.tl_door_limite.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn19,
            this.treeListColumn20,
            this.treeListColumn21});
            this.tl_door_limite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tl_door_limite.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tl_door_limite.Location = new System.Drawing.Point(3, 3);
            this.tl_door_limite.Name = "tl_door_limite";
            this.tl_door_limite.OptionsView.AutoWidth = false;
            this.tl_door_limite.OptionsView.ShowFocusedFrame = false;
            this.tl_door_limite.Size = new System.Drawing.Size(851, 352);
            this.tl_door_limite.TabIndex = 11;
            this.tl_door_limite.TreeLevelWidth = 12;
            // 
            // treeListColumn19
            // 
            this.treeListColumn19.Caption = "进出门";
            this.treeListColumn19.FieldName = "进出门";
            this.treeListColumn19.MinWidth = 16;
            this.treeListColumn19.Name = "treeListColumn19";
            this.treeListColumn19.Visible = true;
            this.treeListColumn19.VisibleIndex = 0;
            this.treeListColumn19.Width = 90;
            // 
            // treeListColumn20
            // 
            this.treeListColumn20.Caption = "门岗编码";
            this.treeListColumn20.FieldName = "门岗编码";
            this.treeListColumn20.Name = "treeListColumn20";
            this.treeListColumn20.Visible = true;
            this.treeListColumn20.VisibleIndex = 1;
            this.treeListColumn20.Width = 100;
            // 
            // treeListColumn21
            // 
            this.treeListColumn21.Caption = "门岗名称";
            this.treeListColumn21.FieldName = "门岗名称";
            this.treeListColumn21.Name = "treeListColumn21";
            this.treeListColumn21.Visible = true;
            this.treeListColumn21.VisibleIndex = 2;
            this.treeListColumn21.Width = 150;
            // 
            // FrmTaskBillInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 581);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTaskBillInfo";
            this.Text = "FrmTaskBillInfo";
            this.Load += new System.EventHandler(this.FrmTaskBillInfo_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tl_BillItem)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tl_taskflow)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tl_door_limite)).EndInit();
            this.ResumeLayout(false);

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

        public void ViewTaskBill()
        {
            if (this.task != null)
            {
                this.tl_BillItem.Nodes.Clear();
                this.tl_taskflow.Nodes.Clear();
                this.tl_door_limite.Nodes.Clear();
                this.txt_billno.Text = this.task.billno;
                this.txt_billstatus.Text = VehIC_WF.Utility.Common.GetNoticeStatusDesc(this.task.status);
                this.txt_billtype.Text = this.task.billtypedesc;
                this.txt_fkr.Text = this.task.fkr;
                this.txt_fksj.Text = this.task.fksj;
                this.txt_remark.Text = this.task.Remark;
                VehIC_WF.ICCardManageService.ICCard card = this.ics.GetCard(this.task.icno);
                this.txt_icno.Text = card.CardNo;
                this.txt_vehno.Text = this.task.vehno;
                this.txt_vehtype.Text = this.task.vehtype;
                this.chbox_fixveh.Checked = this.task.vehisfix;
                this.chbox_needweigh.Checked = this.task.needweigh;
                this.rb_wzlx_in.Checked = this.task.wzlx == "0";
                this.rb_wzlx_out.Checked = this.task.wzlx == "1";
                if (this.task.billtype == 0)
                {
                    this.chbox_th.Checked = this.task.wzlx == "1";
                }
                if (this.task.billtype == 2)
                {
                    this.chbox_th.Checked = this.task.wzlx == "0";
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

