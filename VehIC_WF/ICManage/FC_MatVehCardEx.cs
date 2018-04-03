namespace VehIC_WF.ICManage
{
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using VehIC_WF;
    using VehIC_WF.CommonService;
    using VehIC_WF.ICCardManageService;
    using VehIC_WF.Utility;

    public class FC_MatVehCardEx : UserControl,ICardMessage
    {
        private Button btn_ok;
        public ICCard card = null;
        private CheckBox chbox_fixveh;
        private CheckBox chbox_needweigh;
        private IContainer components = null;
        public VehIC_WF.CommonService.CommonService CS;
        public NoticeBill curnotice = null;
        private GroupBox groupBox3;
        public VehIC_WF.ICCardManageService.ICCardManageService IC = null;
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
        public string lastrecmsg = string.Empty;
        public long lastrectime = 0L;
        private ListBox listBox1;
        private Panel panel2;
        private Panel panel3;
        private RadioButton rb_wzlx_in;
        private RadioButton rb_wzlx_out;
        public int timelimit = 10;
        private TreeListColumn tlc1;
        private TreeListColumn tlc10;
        private TreeListColumn tlc11;
        private TreeListColumn tlc2;
        private TreeListColumn tlc3;
        private TreeListColumn tlc4;
        private TreeListColumn tlc5;
        private TreeListColumn tlc6;
        private TreeListColumn tlc7;
        private TreeListColumn tlc8;
        private TreeListColumn tlc9;
        private TreeList treeList1;
        private TextBox txt_billno;
        private TextBox txt_billstatus;
        private TextBox txt_billtype;
        private TextBox txt_fkr;
        private TextBox txt_fksj;
        private TextBox txt_icno;
        private TextBox txt_icno_new;
        private TextBox txt_remark;
        private TextBox txt_vehno;
        private TextBox txt_vehtype;

        public FC_MatVehCardEx()
        {
            this.InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if ((this.curnotice != null) && (this.card != null))
            {
                if (this.IC.ISFixVeh(this.curnotice.vehno))
                {
                    MessageBox.Show("固定车辆请做多次卡车辆发卡单进行补卡！");
                }
                else
                {
                    try
                    {
                        string billno = this.curnotice.billno;
                        string iCNo = this.card.ICNo;
                        string icno = this.curnotice.icno;
                        string iD = LocalInfo.Current.user.ID;
                        string remark = this.curnotice.Remark;
                        string remarkex = this.txt_remark.Text.Trim();
                        string code = FrmMain.localinfo.workpoint.Code;
                        string text = this.CS.UpdateNoticeBillCard(billno, iCNo, icno, iD, code, remark, remarkex);
                        if (text == "OK")
                        {
                            MessageBox.Show("补卡成功！");
                            this.InitMember();
                            this.InitForm();
                        }
                        else
                        {
                            MessageBox.Show(text);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("数据异常，请重试！");
                    }
                }
            }
        }

        public bool CheckCardID(string cardid)
        {
            if ((this.lastrecmsg == cardid) && (((DateTime.Now.Ticks - this.lastrectime) / 0x989680L) < this.timelimit))
            {
                return false;
            }
            if (this.lastrecmsg == cardid)
            {
                return false;
            }
            this.lastrecmsg = cardid;
            this.lastrectime = DateTime.Now.Ticks;
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FC_MatVehCardEx_Load(object sender, EventArgs e)
        {
            this.CS = new VehIC_WF.CommonService.CommonService();
            this.IC = new VehIC_WF.ICCardManageService.ICCardManageService();
            if (!FrmMain.Debug)
            {
                this.CS.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/CommonService.asmx";
                this.IC.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/ICCardManageService.asmx";
            }
        }

        public bool FillListView(string vehnoex)
        {
            try
            {
                string[] loseCardVehNo = this.IC.GetLoseCardVehNo(vehnoex);
                if ((loseCardVehNo == null) && (loseCardVehNo.Length == 0))
                {
                    return false;
                }
                for (int i = 0; i < loseCardVehNo.Length; i++)
                {
                    if (!this.IC.ISFixVeh(loseCardVehNo[i]))
                    {
                        this.listBox1.Items.Add(loseCardVehNo[i]);
                    }
                }
                if (loseCardVehNo.Length == 1)
                {
                    this.listBox1.Height = 30;
                }
                else if (loseCardVehNo.Length < 10)
                {
                    this.listBox1.Height = (this.listBox1.ItemHeight + 1) * loseCardVehNo.Length;
                }
                else
                {
                    this.listBox1.Height = 150;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool GetNoticeBill()
        {
            try
            {
                string cph = this.txt_vehno.Text.Trim();
                if (cph == string.Empty)
                {
                    return false;
                }
                this.curnotice = this.CS.GetNoticeBillByVehNo(cph);
                if (this.curnotice == null)
                {
                    MessageBox.Show("获取作业单据失败！");
                    return false;
                }
                if (this.curnotice.billno == string.Empty)
                {
                    MessageBox.Show("不存在对应的作业单据！");
                    return false;
                }
                this.ViewNoticeBill();
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("网络处理错误" + exception.ToString());
                return false;
            }
        }

        private void InitForm()
        {
            this.txt_billno.Text = "";
            this.txt_billstatus.Text = "";
            this.txt_billtype.Text = "";
            this.txt_fkr.Text = "";
            this.txt_fksj.Text = "";
            this.txt_icno.Text = "";
            this.txt_icno_new.Text = "";
            this.txt_vehno.Text = "";
            this.txt_vehtype.Text = "";
            this.txt_remark.Text = string.Empty;
            this.treeList1.Nodes.Clear();
            this.chbox_fixveh.Checked = false;
            this.chbox_needweigh.Checked = false;
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FC_MatVehCardEx));
            this.treeList1 = new TreeList();
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
            this.panel2 = new Panel();
            this.txt_remark = new TextBox();
            this.label6 = new Label();
            this.listBox1 = new ListBox();
            this.txt_icno_new = new TextBox();
            this.label5 = new Label();
            this.panel3 = new Panel();
            this.btn_ok = new Button();
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
            this.treeList1.BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            base.SuspendLayout();
            this.treeList1.BackgroundImage = (Image) resources.GetObject("treeList1.BackgroundImage");
            this.treeList1.Columns.AddRange(new TreeListColumn[] { this.tlc1, this.tlc2, this.tlc3, this.tlc4, this.tlc5, this.tlc6, this.tlc7, this.tlc8, this.tlc9, this.tlc10, this.tlc11 });
            this.treeList1.Dock = DockStyle.Fill;
            this.treeList1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.treeList1.HorzScrollVisibility = ScrollVisibility.Always;
            this.treeList1.Location = new Point(0, 0xc6);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsView.ShowFocusedFrame = false;
            this.treeList1.Size = new Size(0x385, 310);
            this.treeList1.TabIndex = 0xbf;
            this.treeList1.TreeLevelWidth = 12;
            this.tlc1.Caption = "行号";
            this.tlc1.FieldName = "行号";
            this.tlc1.MinWidth = 30;
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
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txt_remark);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Controls.Add(this.txt_icno_new);
            this.panel2.Controls.Add(this.label5);
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
            this.panel2.Size = new Size(0x385, 0xc6);
            this.panel2.TabIndex = 190;
            this.txt_remark.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_remark.Location = new Point(0x58, 0x87);
            this.txt_remark.Margin = new Padding(4);
            this.txt_remark.Multiline = true;
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.Size = new Size(0x270, 0x33);
            this.txt_remark.TabIndex = 0xd7;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label6.Location = new Point(0x37, 0x8a);
            this.label6.Margin = new Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x23, 14);
            this.label6.TabIndex = 0xd6;
            this.label6.Text = "说明";
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new Point(0x238, 0x42);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBox1.Size = new Size(0x90, 14);
            this.listBox1.TabIndex = 0xd3;
            this.listBox1.Visible = false;
            this.listBox1.DoubleClick += new EventHandler(this.listBox1_DoubleClick);
            this.listBox1.KeyUp += new KeyEventHandler(this.listBox1_KeyUp);
            this.txt_icno_new.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_icno_new.Location = new Point(0x238, 12);
            this.txt_icno_new.Margin = new Padding(4);
            this.txt_icno_new.Name = "txt_icno_new";
            this.txt_icno_new.ReadOnly = true;
            this.txt_icno_new.Size = new Size(0x90, 0x17);
            this.txt_icno_new.TabIndex = 0xb9;
            this.txt_icno_new.TextAlign = HorizontalAlignment.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label5.Location = new Point(0x1fc, 15);
            this.label5.Margin = new Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x3f, 14);
            this.label5.TabIndex = 0xb8;
            this.label5.Text = "新IC卡号";
            this.panel3.Controls.Add(this.btn_ok);
            this.panel3.Dock = DockStyle.Right;
            this.panel3.Location = new Point(750, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(0x95, 0xc4);
            this.panel3.TabIndex = 0xb7;
            this.btn_ok.Location = new Point(0x19, 0x30);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new Size(0x69, 0x24);
            this.btn_ok.TabIndex = 0x8e;
            this.btn_ok.Text = "补卡";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new EventHandler(this.btn_ok_Click);
            this.txt_icno.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_icno.Location = new Point(0x58, 12);
            this.txt_icno.Margin = new Padding(4);
            this.txt_icno.Name = "txt_icno";
            this.txt_icno.ReadOnly = true;
            this.txt_icno.Size = new Size(0x90, 0x17);
            this.txt_icno.TabIndex = 0xad;
            this.txt_icno.TextAlign = HorizontalAlignment.Right;
            this.txt_icno.KeyUp += new KeyEventHandler(this.txt_icno_KeyUp);
            this.txt_fksj.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_fksj.Location = new Point(0x148, 0x2c);
            this.txt_fksj.Margin = new Padding(4);
            this.txt_fksj.Name = "txt_fksj";
            this.txt_fksj.ReadOnly = true;
            this.txt_fksj.Size = new Size(0x90, 0x17);
            this.txt_fksj.TabIndex = 0xb3;
            this.txt_fksj.TextAlign = HorizontalAlignment.Right;
            this.groupBox3.Controls.Add(this.rb_wzlx_out);
            this.groupBox3.Controls.Add(this.rb_wzlx_in);
            this.groupBox3.Location = new Point(0x148, 0x43);
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
            this.txt_billstatus.Location = new Point(0x58, 0x49);
            this.txt_billstatus.Margin = new Padding(4);
            this.txt_billstatus.Name = "txt_billstatus";
            this.txt_billstatus.ReadOnly = true;
            this.txt_billstatus.Size = new Size(0x90, 0x17);
            this.txt_billstatus.TabIndex = 0xb5;
            this.txt_billstatus.TextAlign = HorizontalAlignment.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label4.Location = new Point(0x1b, 0x4d);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x3f, 14);
            this.label4.TabIndex = 180;
            this.label4.Text = "单据状态";
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label2.Location = new Point(0x10b, 0x30);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x3f, 14);
            this.label2.TabIndex = 0xb2;
            this.label2.Text = "发卡时间";
            this.txt_fkr.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_fkr.Location = new Point(0x148, 14);
            this.txt_fkr.Margin = new Padding(4);
            this.txt_fkr.Name = "txt_fkr";
            this.txt_fkr.ReadOnly = true;
            this.txt_fkr.Size = new Size(0x90, 0x17);
            this.txt_fkr.TabIndex = 0xb1;
            this.txt_fkr.TextAlign = HorizontalAlignment.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label3.Location = new Point(0x119, 0x12);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x31, 14);
            this.label3.TabIndex = 0xb0;
            this.label3.Text = "发卡人";
            this.chbox_needweigh.AutoSize = true;
            this.chbox_needweigh.Enabled = false;
            this.chbox_needweigh.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.chbox_needweigh.Location = new Point(0x21a, 0x6c);
            this.chbox_needweigh.Name = "chbox_needweigh";
            this.chbox_needweigh.Size = new Size(0x3b, 20);
            this.chbox_needweigh.TabIndex = 0xaf;
            this.chbox_needweigh.Text = "计重";
            this.chbox_needweigh.UseVisualStyleBackColor = true;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label10.Location = new Point(0x1c, 15);
            this.label10.Margin = new Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x3f, 14);
            this.label10.TabIndex = 0xac;
            this.label10.Text = "原IC卡号";
            this.chbox_fixveh.AutoSize = true;
            this.chbox_fixveh.Enabled = false;
            this.chbox_fixveh.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.chbox_fixveh.Location = new Point(270, 0x6c);
            this.chbox_fixveh.Name = "chbox_fixveh";
            this.chbox_fixveh.Size = new Size(0x5b, 20);
            this.chbox_fixveh.TabIndex = 0x9e;
            this.chbox_fixveh.Text = "固定车辆";
            this.chbox_fixveh.UseVisualStyleBackColor = true;
            this.txt_vehtype.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_vehtype.Location = new Point(0x238, 0x4c);
            this.txt_vehtype.Margin = new Padding(4);
            this.txt_vehtype.Name = "txt_vehtype";
            this.txt_vehtype.ReadOnly = true;
            this.txt_vehtype.Size = new Size(0x90, 0x17);
            this.txt_vehtype.TabIndex = 0x9d;
            this.txt_vehtype.TextAlign = HorizontalAlignment.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label1.Location = new Point(0x217, 0x4f);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x23, 14);
            this.label1.TabIndex = 0x9c;
            this.label1.Text = "车型";
            this.txt_billtype.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_billtype.Location = new Point(0x58, 0x68);
            this.txt_billtype.Margin = new Padding(4);
            this.txt_billtype.Name = "txt_billtype";
            this.txt_billtype.ReadOnly = true;
            this.txt_billtype.Size = new Size(0x90, 0x17);
            this.txt_billtype.TabIndex = 0x97;
            this.txt_billtype.TextAlign = HorizontalAlignment.Right;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label14.Location = new Point(0x1b, 0x6c);
            this.label14.Margin = new Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x3f, 14);
            this.label14.TabIndex = 150;
            this.label14.Text = "业务类型";
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label11.Location = new Point(0x10b, 0x4f);
            this.label11.Margin = new Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x3f, 14);
            this.label11.TabIndex = 0x94;
            this.label11.Text = "物资流向";
            this.txt_billno.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_billno.Location = new Point(0x58, 0x2b);
            this.txt_billno.Margin = new Padding(4);
            this.txt_billno.Name = "txt_billno";
            this.txt_billno.ReadOnly = true;
            this.txt_billno.Size = new Size(0x90, 0x17);
            this.txt_billno.TabIndex = 0x93;
            this.txt_billno.TextAlign = HorizontalAlignment.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label12.Location = new Point(0x1b, 0x2f);
            this.label12.Margin = new Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x3f, 14);
            this.label12.TabIndex = 0x92;
            this.label12.Text = "作业单号";
            this.txt_vehno.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_vehno.Location = new Point(0x238, 0x2b);
            this.txt_vehno.Margin = new Padding(4);
            this.txt_vehno.Name = "txt_vehno";
            this.txt_vehno.Size = new Size(0x90, 0x17);
            this.txt_vehno.TabIndex = 140;
            this.txt_vehno.TextAlign = HorizontalAlignment.Right;
            this.txt_vehno.KeyUp += new KeyEventHandler(this.txt_vehno_KeyUp);
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label9.Location = new Point(0x209, 0x2f);
            this.label9.Margin = new Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x31, 14);
            this.label9.TabIndex = 0x8b;
            this.label9.Text = "车牌号";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.treeList1);
            base.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            base.Name = "FC_MatVehCardEx";
            base.Size = new Size(0x385, 0x1fc);
            base.Load += new EventHandler(this.FC_MatVehCardEx_Load);
            this.treeList1.EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            base.ResumeLayout(false);
        }

        private void InitMember()
        {
            this.curnotice = null;
            this.card = null;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex != -1)
            {
                this.txt_vehno.Text = this.listBox1.Text;
                this.listBox1.Visible = false;
                this.txt_vehno.SelectionStart = this.txt_vehno.Text.Length;
                this.txt_vehno.Focus();
                if (!this.GetNoticeBill())
                {
                    this.card = null;
                    this.InitForm();
                    this.InitMember();
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
                    if (!this.GetNoticeBill())
                    {
                        this.card = null;
                        this.InitForm();
                        this.InitMember();
                    }
                    break;

                case 0x1b:
                    this.listBox1.Visible = false;
                    this.txt_vehno.Focus();
                    break;
            }
        }

        public void HandleCardMessage(Device.CardReader device, string cardid)
        {
            try
            {
                if (this.CheckCardID(cardid))
                {
                    this.card = this.IC.GetCard(cardid);
                    if (this.card.CardNo == string.Empty)
                    {
                        MessageBox.Show("此卡还没有注册！");
                        this.card = null;
                    }
                    else if (this.card.Status != 0)
                    {
                        MessageBox.Show("卡[" + this.card.CardNo + "]当前状态不允许发卡！");
                        this.card = null;
                    }
                    else
                    {
                        this.txt_icno_new.Text = this.card.CardNo;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void txt_icno_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.txt_vehno.SelectionStart = this.txt_vehno.Text.Length;
                this.txt_vehno.Focus();
            }
        }

        private void txt_vehno_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    this.listBox1.Visible = false;
                    if (!this.GetNoticeBill())
                    {
                        this.card = null;
                        this.InitForm();
                        this.InitMember();
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
            string vehnoex = this.txt_vehno.Text.Trim();
            if ((vehnoex != "") && (vehnoex.Length > 1))
            {
                this.listBox1.Items.Clear();
                this.listBox1.Visible = this.FillListView(vehnoex);
            }
            else
            {
                this.listBox1.Visible = false;
            }
        }

        public void ViewNoticeBill()
        {
            if (this.curnotice != null)
            {
                this.txt_billno.Text = this.curnotice.billno;
                this.txt_billstatus.Text = Common.GetNoticeStatusDesc(this.curnotice.status);
                this.txt_billtype.Text = this.curnotice.billtypedesc;
                this.txt_fkr.Text = this.curnotice.fkr;
                this.txt_fksj.Text = this.curnotice.fksj;
                ICCard card = this.IC.GetCard(this.curnotice.icno);
                this.txt_icno.Text = card.CardNo;
                this.txt_vehno.Text = this.curnotice.vehno;
                this.txt_vehtype.Text = this.curnotice.vehtype;
                this.txt_remark.Text = this.curnotice.Remark;
                this.treeList1.Nodes.Clear();
                this.chbox_fixveh.Checked = this.curnotice.vehisfix;
                this.chbox_needweigh.Checked = this.curnotice.needweigh;
                this.rb_wzlx_in.Checked = this.curnotice.wzlx == "0";
                this.rb_wzlx_out.Checked = this.curnotice.wzlx == "1";
                if (this.curnotice.Items != null)
                {
                    this.treeList1.Nodes.Clear();
                    for (int i = 0; i < this.curnotice.Items.Length; i++)
                    {
                        NBItem item = this.curnotice.Items[i];
                        string str = string.Empty;
                        int imageIndex = 1;
                        switch (item.status)
                        {
                            case 0:
                                str = "初始";
                                if (!item.Available)
                                {
                                    imageIndex = 3;
                                }
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
                        object[] nodeData = new object[] { item.rowno, item.invcode, item.invname, item.spectypegraphid, item.unit, item.plannum, item.planassistnum, item.factnum, item.factassistnum, str, item.remark };
                        this.treeList1.AppendNode(nodeData, -1, imageIndex, imageIndex, imageIndex);
                    }
                }
            }
        }
    }
}

