namespace VehIC_WF.ICManage
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using VehIC_WF;
    using VehIC_WF.ICCardManageService;

    public class FC_OperaterCard : UserControl,ICardMessage
    {
        public Bill_OperCard[] bills = null;
        private Button button1;
        public ICCard card = null;
        private IContainer components = null;
        public Bill_OperCard curbill = null;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        public VehIC_WF.ICCardManageService.ICCardManageService iccardmanageservice = null;
        private Label label1;
        private Label label17;
        private Label label19;
        private Label label2;
        private Label label21;
        private Label label23;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        public string lastrecmsg = string.Empty;
        public long lastrectime = 0L;
        private Panel panel3;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private TextBox textBox1;
        private TextBox textBox17;
        private TextBox textBox18;
        private TextBox textBox2;
        private TextBox textBox20;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        public int timelimit = 10;

        public FC_OperaterCard()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.curbill != null)
            {
                if (this.card == null)
                {
                    MessageBox.Show("请放好IC卡！");
                }
                else
                {
                    string billNo = this.curbill.BillNo;
                    int ictype = this.curbill.ISZLK ? 5 : 4;
                    string iD = LocalInfo.Current.user.ID;
                    string code = FrmMain.localinfo.workpoint.Code;
                    if (this.iccardmanageservice.OperCardAssign(this.card.ICNo, ictype, billNo, iD, code) == -1)
                    {
                        MessageBox.Show("数据库操作失败！请重新尝试！");
                    }
                    else
                    {
                        MessageBox.Show("发卡成功！请取走IC卡！");
                        this.InitFrm();
                        this.bills = null;
                        this.curbill = null;
                        this.card = null;
                        this.textBox6.Text = "";
                        this.textBox8.Text = "";
                        this.textBox8.Focus();
                    }
                }
            }
        }

        public bool CheckCardID(string cardid)
        {
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

        private void FC_OperaterCard_Load(object sender, EventArgs e)
        {
            try
            {
                this.iccardmanageservice = new VehIC_WF.ICCardManageService.ICCardManageService();
                if (!FrmMain.Debug)
                {
                    this.iccardmanageservice.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/ICCardManageService.asmx";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("初始化数据时出错！\r\n" + exception.ToString());
            }
        }

        public void InitBillView()
        {
            if (this.curbill != null)
            {
                if (this.curbill.ISZLK)
                {
                    this.radioButton2.Checked = true;
                    this.radioButton1.Checked = false;
                }
                else
                {
                    this.radioButton2.Checked = false;
                    this.radioButton1.Checked = true;
                }
                this.textBox4.Text = this.curbill.BillNo;
                this.textBox17.Text = this.curbill.Dept;
                this.textBox8.Text = this.curbill.UserID;
                this.textBox7.Text = this.curbill.UserName;
                this.textBox6.Text = this.curbill.IDCardNo;
                try
                {
                    this.dateTimePicker1.Value = DateTime.Parse(this.curbill.BeginTime);
                    this.dateTimePicker2.Value = DateTime.Parse(this.curbill.EndTime);
                }
                catch (Exception)
                {
                }
                this.textBox20.Text = this.curbill.ZDR;
                this.textBox1.Text = this.curbill.ZDRQ;
                this.textBox3.Text = this.curbill.SHR;
                this.textBox2.Text = this.curbill.SHRQ;
                this.textBox5.Text = (this.curbill.flag == 1) ? "已审核" : "";
            }
        }

        public void InitFrm()
        {
            this.radioButton2.Checked = false;
            this.radioButton1.Checked = true;
            this.textBox4.Text = "";
            this.textBox17.Text = "";
            this.textBox7.Text = "";
            this.dateTimePicker1.Value = DateTime.Parse("2008-01-01");
            this.dateTimePicker2.Value = DateTime.Parse("2009-01-01");
            this.textBox20.Text = "";
            this.textBox1.Text = "";
            this.textBox3.Text = "";
            this.textBox2.Text = "";
            this.textBox5.Text = "";
            this.textBox18.Text = "";
        }

        private void InitializeComponent()
        {
            this.groupBox2 = new GroupBox();
            this.textBox8 = new TextBox();
            this.label9 = new Label();
            this.textBox4 = new TextBox();
            this.textBox5 = new TextBox();
            this.label5 = new Label();
            this.textBox2 = new TextBox();
            this.label2 = new Label();
            this.textBox3 = new TextBox();
            this.label4 = new Label();
            this.textBox1 = new TextBox();
            this.label1 = new Label();
            this.textBox20 = new TextBox();
            this.label23 = new Label();
            this.dateTimePicker2 = new DateTimePicker();
            this.label19 = new Label();
            this.dateTimePicker1 = new DateTimePicker();
            this.textBox17 = new TextBox();
            this.label17 = new Label();
            this.label8 = new Label();
            this.textBox7 = new TextBox();
            this.label7 = new Label();
            this.textBox6 = new TextBox();
            this.label6 = new Label();
            this.label3 = new Label();
            this.groupBox1 = new GroupBox();
            this.groupBox3 = new GroupBox();
            this.radioButton2 = new RadioButton();
            this.radioButton1 = new RadioButton();
            this.panel3 = new Panel();
            this.button1 = new Button();
            this.textBox18 = new TextBox();
            this.label21 = new Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            base.SuspendLayout();
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox20);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.textBox17);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.groupBox2.Location = new Point(0, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x385, 0x21e);
            this.groupBox2.TabIndex = 0xa6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "人员卡单据信息";
            this.textBox8.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBox8.Location = new Point(0x68, 0x5f);
            this.textBox8.Margin = new Padding(4);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Size(0xd1, 0x17);
            this.textBox8.TabIndex = 0xc1;
            this.textBox8.TextAlign = HorizontalAlignment.Right;
            this.textBox8.KeyPress += new KeyPressEventHandler(this.textBox8_KeyPress);
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label9.Location = new Point(0x3a, 0x62);
            this.label9.Margin = new Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x31, 14);
            this.label9.TabIndex = 0xc2;
            this.label9.Text = "人员号";
            this.textBox4.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox4.Location = new Point(0x69, 0x1a);
            this.textBox4.Margin = new Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new Size(0xd1, 0x17);
            this.textBox4.TabIndex = 0xbf;
            this.textBox4.TextAlign = HorizontalAlignment.Right;
            this.textBox5.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox5.Location = new Point(0x69, 0x16e);
            this.textBox5.Margin = new Padding(4);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new Size(0xd1, 0x17);
            this.textBox5.TabIndex = 0xbd;
            this.textBox5.TextAlign = HorizontalAlignment.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label5.Location = new Point(0x2c, 370);
            this.label5.Margin = new Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x3f, 14);
            this.label5.TabIndex = 0xbc;
            this.label5.Text = "单据状态";
            this.textBox2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox2.Location = new Point(0x69, 0x14d);
            this.textBox2.Margin = new Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new Size(0xd1, 0x17);
            this.textBox2.TabIndex = 0xbb;
            this.textBox2.TextAlign = HorizontalAlignment.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label2.Location = new Point(0x2c, 0x150);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x3f, 14);
            this.label2.TabIndex = 0xba;
            this.label2.Text = "审核日期";
            this.textBox3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox3.Location = new Point(0x69, 0x12b);
            this.textBox3.Margin = new Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new Size(0xd1, 0x17);
            this.textBox3.TabIndex = 0xb9;
            this.textBox3.TextAlign = HorizontalAlignment.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label4.Location = new Point(0x3a, 0x12e);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x31, 14);
            this.label4.TabIndex = 0xb8;
            this.label4.Text = "审核人";
            this.textBox1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox1.Location = new Point(0x69, 0x109);
            this.textBox1.Margin = new Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new Size(0xd1, 0x17);
            this.textBox1.TabIndex = 0xb7;
            this.textBox1.TextAlign = HorizontalAlignment.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label1.Location = new Point(0x2c, 0x10c);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x3f, 14);
            this.label1.TabIndex = 0xb6;
            this.label1.Text = "制单日期";
            this.textBox20.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox20.Location = new Point(0x69, 0xe7);
            this.textBox20.Margin = new Padding(4);
            this.textBox20.Name = "textBox20";
            this.textBox20.ReadOnly = true;
            this.textBox20.Size = new Size(0xd1, 0x17);
            this.textBox20.TabIndex = 0xb5;
            this.textBox20.TextAlign = HorizontalAlignment.Right;
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label23.Location = new Point(0x3a, 0xea);
            this.label23.Margin = new Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new Size(0x31, 14);
            this.label23.TabIndex = 180;
            this.label23.Text = "制单人";
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Location = new Point(0xfe, 0xc5);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new Size(0x83, 0x17);
            this.dateTimePicker2.TabIndex = 0xb0;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label19.Location = new Point(0xec, 0xc9);
            this.label19.Margin = new Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new Size(0x15, 14);
            this.label19.TabIndex = 0xb1;
            this.label19.Text = "－";
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new Point(0x69, 0xc5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new Size(0x83, 0x17);
            this.dateTimePicker1.TabIndex = 0xaf;
            this.textBox17.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox17.Location = new Point(0x69, 60);
            this.textBox17.Margin = new Padding(4);
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new Size(0xd1, 0x17);
            this.textBox17.TabIndex = 0xac;
            this.textBox17.TextAlign = HorizontalAlignment.Right;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label17.Location = new Point(0x48, 0x40);
            this.label17.Margin = new Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new Size(0x23, 14);
            this.label17.TabIndex = 0xab;
            this.label17.Text = "部门";
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label8.Location = new Point(0x3a, 0xc9);
            this.label8.Margin = new Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x31, 14);
            this.label8.TabIndex = 0xa6;
            this.label8.Text = "有效期";
            this.textBox7.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox7.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBox7.Location = new Point(0x69, 0x80);
            this.textBox7.Margin = new Padding(4);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new Size(0xd1, 0x17);
            this.textBox7.TabIndex = 0xa5;
            this.textBox7.TextAlign = HorizontalAlignment.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label7.Location = new Point(0x48, 0x84);
            this.label7.Margin = new Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x23, 14);
            this.label7.TabIndex = 0xa4;
            this.label7.Text = "姓名";
            this.textBox6.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox6.Location = new Point(0x69, 0xa2);
            this.textBox6.Margin = new Padding(4);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Size(0xd1, 0x17);
            this.textBox6.TabIndex = 0xa3;
            this.textBox6.TextAlign = HorizontalAlignment.Right;
            this.textBox6.KeyPress += new KeyPressEventHandler(this.textBox6_KeyPress);
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label6.Location = new Point(0x2c, 0xa6);
            this.label6.Margin = new Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x3f, 14);
            this.label6.TabIndex = 0xa2;
            this.label6.Text = "身份证号";
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label3.Location = new Point(0x3b, 0x1f);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x31, 14);
            this.label3.TabIndex = 0x9e;
            this.label3.Text = "单据号";
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.textBox18);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Dock = DockStyle.Top;
            this.groupBox1.Location = new Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x385, 70);
            this.groupBox1.TabIndex = 0xa5;
            this.groupBox1.TabStop = false;
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Location = new Point(0x14d, 0x11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0xe4, 0x27);
            this.groupBox3.TabIndex = 0x9f;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发卡类型";
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Location = new Point(0x8d, 0x10);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new Size(0x3b, 0x10);
            this.radioButton2.TabIndex = 0x95;
            this.radioButton2.Text = "指令卡";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Location = new Point(0x37, 0x10);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new Size(0x47, 0x10);
            this.radioButton1.TabIndex = 0x94;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "操作员卡";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = DockStyle.Right;
            this.panel3.Location = new Point(0x26d, 0x11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(0x115, 50);
            this.panel3.TabIndex = 160;
            this.button1.Location = new Point(0x90, 8);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x66, 0x1d);
            this.button1.TabIndex = 0x8e;
            this.button1.Text = "发卡";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.textBox18.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox18.Location = new Point(0x69, 0x1b);
            this.textBox18.Margin = new Padding(4);
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new Size(0xd1, 0x17);
            this.textBox18.TabIndex = 0x9e;
            this.textBox18.TextAlign = HorizontalAlignment.Right;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label21.Location = new Point(0x3a, 0x1f);
            this.label21.Margin = new Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new Size(0x31, 14);
            this.label21.TabIndex = 0x9d;
            this.label21.Text = "IC卡号";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.Name = "FC_OperaterCard";
            base.Size = new Size(0x385, 0x264);
            base.Load += new EventHandler(this.FC_OperaterCard_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel3.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        public void HandleCardMessage(Device.CardReader device, string cardid)
        {
            if (this.CheckCardID(cardid))
            {
                this.card = this.iccardmanageservice.GetCard(cardid);
                if (this.card.CardNo == string.Empty)
                {
                    MessageBox.Show("此卡还没有注册！");
                    this.card = null;
                }
                else if (this.card.Status != 0)
                {
                    MessageBox.Show("当前状态不允许发卡！卡无效！");
                    this.card = null;
                }
                else
                {
                    this.textBox18.Text = this.card.CardNo;
                }
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                string iDNo = this.textBox6.Text.Trim();
                if (iDNo == string.Empty)
                {
                    this.curbill = null;
                    this.InitFrm();
                    this.textBox6.Text = "";
                    this.textBox8.Text = "";
                    this.textBox6.Focus();
                }
                else
                {
                    this.bills = this.iccardmanageservice.GetOperCardBill(iDNo);
                    if ((this.bills == null) || (this.bills.Length == 0))
                    {
                        this.curbill = null;
                        this.InitFrm();
                        MessageBox.Show("没有查询到相关人员的发卡单！");
                        this.textBox8.Text = "";
                        this.textBox6.SelectionStart = this.textBox6.Text.Length;
                        this.textBox6.Focus();
                    }
                    else
                    {
                        this.curbill = this.bills[0];
                        this.InitBillView();
                    }
                }
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                string uid = this.textBox8.Text.Trim();
                if (uid == string.Empty)
                {
                    this.curbill = null;
                    this.InitFrm();
                    this.textBox6.Text = "";
                    this.textBox8.Text = "";
                    this.textBox8.Focus();
                }
                else
                {
                    this.bills = this.iccardmanageservice.QueryBillByUserID(uid);
                    if ((this.bills == null) || (this.bills.Length == 0))
                    {
                        this.curbill = null;
                        this.InitFrm();
                        MessageBox.Show("没有查询到相关人员的发卡单！");
                        this.textBox6.Text = "";
                        this.textBox8.SelectionStart = this.textBox8.Text.Length;
                        this.textBox8.Focus();
                    }
                    else
                    {
                        this.curbill = this.bills[0];
                        this.InitBillView();
                    }
                }
            }
        }

     
    }
}

