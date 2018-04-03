namespace VehIC_WF.ICManage
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using VehIC_WF;
    using VehIC_WF.ICCardManageService;

    public class FC_FixVehCard : UserControl,ICardMessage
    {
        public Bill_FixVehCard[] bills = null;
        private Button button1;
        public ICCard card = null;
        private IContainer components = null;
        public Bill_FixVehCard curbill = null;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker3;
        private DateTimePicker dateTimePicker4;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        public VehIC_WF.ICCardManageService.ICCardManageService iccardmanageservice = null;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label16;
        private Label label17;
        private Label label19;
        private Label label2;
        private Label label21;
        private Label label23;
        private Label label24;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        public string lastrecmsg = string.Empty;
        public long lastrectime = 0L;
        private ListBox listBox1;
        private Panel panel3;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private TextBox textBox1;
        private TextBox textBox14;
        private TextBox textBox17;
        private TextBox textBox18;
        private TextBox textBox2;
        private TextBox textBox20;
        private TextBox textBox21;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        public int timelimit = 10;
        private TextBox txt_vehno;

        public FC_FixVehCard()
        {
            try
            {
                this.InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.curbill != null)
                {
                    if (this.card == null)
                    {
                        MessageBox.Show("请放好IC卡！");
                    }
                    else
                    {
                        string iCNo = this.card.ICNo;
                        string vehID = this.curbill.VehID;
                        bool flag = this.iccardmanageservice.ISExistTaskOfVehNo(vehID) > 0;
                        string[] vehinfo = new string[] { this.curbill.VehID, this.curbill.VehType, this.curbill.ISMulti ? "1" : "0" };
                        int ictype = this.curbill.ISMulti ? 2 : 3;
                        string iD = LocalInfo.Current.user.ID;
                        string billNo = this.curbill.BillNo;
                        string dept = this.curbill.Dept;
                        string code = FrmMain.localinfo.workpoint.Code;
                        if (this.iccardmanageservice.FixVehCardAssign(iCNo, ictype, iD, billNo, vehinfo, dept, code) == -1)
                        {
                            MessageBox.Show("数据库操作失败！请重新尝试！");
                        }
                        else
                        {
                            if (this.curbill.ISMulti && flag)
                            {
                                MessageBox.Show("发卡成功，请取走卡！\r\n已经将未执行作业单完成绑定！");
                            }
                            else
                            {
                                MessageBox.Show("发卡成功，请取走卡！");
                            }
                            this.curbill = null;
                            this.card = null;
                            this.textBox18.Text = string.Empty;
                            this.InitView();
                            this.txt_vehno.Text = "";
                            this.txt_vehno.Focus();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("数据处理异常！" + exception.ToString());
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

        public bool FillListView(string vehnoex)
        {
            try
            {
                string[] strArray = this.iccardmanageservice.QueryAvailableVehNo(vehnoex);
                if ((strArray == null) && (strArray.Length == 0))
                {
                    return false;
                }
                for (int i = 0; i < strArray.Length; i++)
                {
                    this.listBox1.Items.Add(strArray[i]);
                }
                if (strArray.Length == 1)
                {
                    this.listBox1.Height = 30;
                }
                else if (strArray.Length < 10)
                {
                    this.listBox1.Height = (this.listBox1.ItemHeight + 1) * strArray.Length;
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

        public void InitBillView()
        {
            if (this.curbill != null)
            {
                this.textBox9.Text = this.curbill.username;
                this.textBox2.Text = this.curbill.BillNo;
                this.txt_vehno.Text = this.curbill.VehID;
                this.textBox4.Text = this.curbill.VehType;
                this.textBox17.Text = this.curbill.Dept;
                this.textBox6.Text = this.curbill.IDCardNo;
                try
                {
                    this.dateTimePicker1.Value = DateTime.Parse(this.curbill.BeginTime);
                    this.dateTimePicker2.Value = DateTime.Parse(this.curbill.EndTime);
                    this.dateTimePicker4.Value = DateTime.Parse(this.curbill.InTime);
                    this.dateTimePicker3.Value = DateTime.Parse(this.curbill.OutTime);
                }
                catch (Exception)
                {
                }
                this.textBox5.Text = this.curbill.reason;
                this.textBox14.Text = this.curbill.Memo;
                this.textBox20.Text = this.curbill.ZDR;
                this.textBox21.Text = this.curbill.ZDRQ;
                this.textBox8.Text = this.curbill.SHR;
                this.textBox7.Text = this.curbill.SHRQ;
                this.radioButton1.Checked = this.curbill.ISMulti;
                this.radioButton2.Checked = !this.curbill.ISMulti;
                this.textBox1.Text = (this.curbill.flag == 1) ? "已审核" : "";
            }
            else
            {
                this.InitView();
            }
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new Panel();
            this.button1 = new Button();
            this.groupBox3 = new GroupBox();
            this.radioButton2 = new RadioButton();
            this.radioButton1 = new RadioButton();
            this.textBox18 = new TextBox();
            this.label21 = new Label();
            this.groupBox2 = new GroupBox();
            this.listBox1 = new ListBox();
            this.textBox9 = new TextBox();
            this.label12 = new Label();
            this.textBox7 = new TextBox();
            this.label7 = new Label();
            this.textBox8 = new TextBox();
            this.label11 = new Label();
            this.textBox5 = new TextBox();
            this.label4 = new Label();
            this.dateTimePicker3 = new DateTimePicker();
            this.label9 = new Label();
            this.dateTimePicker4 = new DateTimePicker();
            this.label10 = new Label();
            this.textBox4 = new TextBox();
            this.label2 = new Label();
            this.txt_vehno = new TextBox();
            this.textBox2 = new TextBox();
            this.textBox1 = new TextBox();
            this.label1 = new Label();
            this.textBox21 = new TextBox();
            this.label24 = new Label();
            this.textBox20 = new TextBox();
            this.label23 = new Label();
            this.dateTimePicker2 = new DateTimePicker();
            this.label19 = new Label();
            this.dateTimePicker1 = new DateTimePicker();
            this.textBox17 = new TextBox();
            this.label17 = new Label();
            this.textBox14 = new TextBox();
            this.label16 = new Label();
            this.label8 = new Label();
            this.textBox6 = new TextBox();
            this.label6 = new Label();
            this.label5 = new Label();
            this.label3 = new Label();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.textBox18);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Dock = DockStyle.Top;
            this.groupBox1.Location = new Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x385, 70);
            this.groupBox1.TabIndex = 0xa1;
            this.groupBox1.TabStop = false;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = DockStyle.Right;
            this.panel3.Location = new Point(0x2dc, 0x11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(0xa6, 50);
            this.panel3.TabIndex = 0xa1;
            this.button1.Location = new Point(0x1c, 7);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x66, 0x1d);
            this.button1.TabIndex = 0x8e;
            this.button1.Text = "发卡";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Location = new Point(0x150, 0x11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0xda, 0x27);
            this.groupBox3.TabIndex = 0x9f;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发卡类型";
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Location = new Point(0x8a, 0x10);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new Size(0x3b, 0x10);
            this.radioButton2.TabIndex = 0x95;
            this.radioButton2.Text = "一次卡";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Location = new Point(0x34, 0x10);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new Size(0x3b, 0x10);
            this.radioButton1.TabIndex = 0x94;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "多次卡";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.textBox18.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox18.Location = new Point(0x68, 0x1b);
            this.textBox18.Margin = new Padding(4);
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new Size(0xd1, 0x17);
            this.textBox18.TabIndex = 0x9e;
            this.textBox18.TextAlign = HorizontalAlignment.Right;
            this.textBox18.KeyUp += new KeyEventHandler(this.textBox18_KeyUp);
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label21.Location = new Point(0x39, 0x1f);
            this.label21.Margin = new Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new Size(0x31, 14);
            this.label21.TabIndex = 0x9d;
            this.label21.Text = "IC卡号";
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Controls.Add(this.textBox9);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dateTimePicker3);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.dateTimePicker4);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txt_vehno);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox21);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.textBox20);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.textBox17);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.textBox14);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = DockStyle.Fill;
            this.groupBox2.Location = new Point(0, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x385, 0x21e);
            this.groupBox2.TabIndex = 0xa2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "单据信息";
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new Point(0x69, 0x65);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBox1.Size = new Size(0xd1, 14);
            this.listBox1.TabIndex = 0xd1;
            this.listBox1.Visible = false;
            this.listBox1.DoubleClick += new EventHandler(this.listBox1_DoubleClick);
            this.listBox1.KeyUp += new KeyEventHandler(this.listBox1_KeyUp);
            this.textBox9.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox9.Location = new Point(0x68, 50);
            this.textBox9.Margin = new Padding(4);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new Size(0xd1, 0x17);
            this.textBox9.TabIndex = 0xd0;
            this.textBox9.TextAlign = HorizontalAlignment.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label12.Location = new Point(0x47, 0x36);
            this.label12.Margin = new Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x23, 14);
            this.label12.TabIndex = 0xcf;
            this.label12.Text = "姓名";
            this.textBox7.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox7.Location = new Point(0x68, 0x1c4);
            this.textBox7.Margin = new Padding(4);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new Size(0xd1, 0x17);
            this.textBox7.TabIndex = 0xce;
            this.textBox7.TextAlign = HorizontalAlignment.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label7.Location = new Point(0x2a, 0x1c8);
            this.label7.Margin = new Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x3f, 14);
            this.label7.TabIndex = 0xcd;
            this.label7.Text = "审核日期";
            this.textBox8.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox8.Location = new Point(0x68, 0x1a5);
            this.textBox8.Margin = new Padding(4);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new Size(0xd1, 0x17);
            this.textBox8.TabIndex = 0xcc;
            this.textBox8.TextAlign = HorizontalAlignment.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label11.Location = new Point(0x38, 0x1a9);
            this.label11.Margin = new Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x31, 14);
            this.label11.TabIndex = 0xcb;
            this.label11.Text = "审核人";
            this.textBox5.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox5.Location = new Point(0x68, 260);
            this.textBox5.Margin = new Padding(4);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new Size(0x1fa, 0x27);
            this.textBox5.TabIndex = 0xca;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label4.Location = new Point(70, 0x107);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x23, 14);
            this.label4.TabIndex = 0xc9;
            this.label4.Text = "事由";
            this.dateTimePicker3.Enabled = false;
            this.dateTimePicker3.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.dateTimePicker3.Format = DateTimePickerFormat.Time;
            this.dateTimePicker3.Location = new Point(0xfd, 0xe1);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new Size(0x83, 0x1a);
            this.dateTimePicker3.TabIndex = 0xc7;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label9.Location = new Point(0xeb, 0xe7);
            this.label9.Margin = new Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x15, 14);
            this.label9.TabIndex = 200;
            this.label9.Text = "－";
            this.dateTimePicker4.Enabled = false;
            this.dateTimePicker4.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.dateTimePicker4.Format = DateTimePickerFormat.Time;
            this.dateTimePicker4.Location = new Point(0x68, 0xe1);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new Size(0x83, 0x1a);
            this.dateTimePicker4.TabIndex = 0xc6;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label10.Location = new Point(0x2a, 230);
            this.label10.Margin = new Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x3f, 14);
            this.label10.TabIndex = 0xc5;
            this.label10.Text = "进厂时间";
            this.textBox4.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox4.Location = new Point(0x69, 0x6a);
            this.textBox4.Margin = new Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new Size(0xd1, 0x17);
            this.textBox4.TabIndex = 0xc1;
            this.textBox4.TextAlign = HorizontalAlignment.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label2.Location = new Point(0x47, 0x6f);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x23, 14);
            this.label2.TabIndex = 0xc0;
            this.label2.Text = "车型";
            this.txt_vehno.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_vehno.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txt_vehno.Location = new Point(0x69, 0x4e);
            this.txt_vehno.Margin = new Padding(4);
            this.txt_vehno.Name = "txt_vehno";
            this.txt_vehno.Size = new Size(0xd1, 0x17);
            this.txt_vehno.TabIndex = 0xbf;
            this.txt_vehno.TextAlign = HorizontalAlignment.Right;
            this.txt_vehno.KeyUp += new KeyEventHandler(this.textBox3_KeyUp);
            this.textBox2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox2.Location = new Point(0x69, 0x15);
            this.textBox2.Margin = new Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new Size(0xd1, 0x17);
            this.textBox2.TabIndex = 0xbd;
            this.textBox2.TextAlign = HorizontalAlignment.Right;
            this.textBox1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox1.Location = new Point(0x68, 0x1e3);
            this.textBox1.Margin = new Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new Size(0xd1, 0x17);
            this.textBox1.TabIndex = 0xb9;
            this.textBox1.TextAlign = HorizontalAlignment.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label1.Location = new Point(0x2a, 0x1e7);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x3f, 14);
            this.label1.TabIndex = 0xb8;
            this.label1.Text = "单据状态";
            this.textBox21.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox21.Location = new Point(0x68, 390);
            this.textBox21.Margin = new Padding(4);
            this.textBox21.Name = "textBox21";
            this.textBox21.ReadOnly = true;
            this.textBox21.Size = new Size(0xd1, 0x17);
            this.textBox21.TabIndex = 0xb7;
            this.textBox21.TextAlign = HorizontalAlignment.Right;
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label24.Location = new Point(0x2a, 0x18a);
            this.label24.Margin = new Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new Size(0x3f, 14);
            this.label24.TabIndex = 0xb6;
            this.label24.Text = "制单日期";
            this.textBox20.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox20.Location = new Point(0x68, 0x167);
            this.textBox20.Margin = new Padding(4);
            this.textBox20.Name = "textBox20";
            this.textBox20.ReadOnly = true;
            this.textBox20.Size = new Size(0xd1, 0x17);
            this.textBox20.TabIndex = 0xb5;
            this.textBox20.TextAlign = HorizontalAlignment.Right;
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label23.Location = new Point(0x38, 0x16b);
            this.label23.Margin = new Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new Size(0x31, 14);
            this.label23.TabIndex = 180;
            this.label23.Text = "制单人";
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.dateTimePicker2.Location = new Point(0xfd, 0xc2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new Size(0x83, 0x17);
            this.dateTimePicker2.TabIndex = 0xb0;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label19.Location = new Point(0xeb, 0xc6);
            this.label19.Margin = new Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new Size(0x15, 14);
            this.label19.TabIndex = 0xb1;
            this.label19.Text = "－";
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.dateTimePicker1.Location = new Point(0x68, 0xc2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new Size(0x83, 0x17);
            this.dateTimePicker1.TabIndex = 0xaf;
            this.textBox17.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox17.Location = new Point(0x69, 0x87);
            this.textBox17.Margin = new Padding(4);
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new Size(0xd1, 0x17);
            this.textBox17.TabIndex = 0xac;
            this.textBox17.TextAlign = HorizontalAlignment.Right;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label17.Location = new Point(0x47, 140);
            this.label17.Margin = new Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new Size(0x23, 14);
            this.label17.TabIndex = 0xab;
            this.label17.Text = "部门";
            this.textBox14.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox14.Location = new Point(0x68, 0x133);
            this.textBox14.Margin = new Padding(4);
            this.textBox14.Multiline = true;
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new Size(0x1fa, 0x27);
            this.textBox14.TabIndex = 170;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label16.Location = new Point(70, 310);
            this.label16.Margin = new Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0x23, 14);
            this.label16.TabIndex = 0xa9;
            this.label16.Text = "备注";
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label8.Location = new Point(0x39, 0xc5);
            this.label8.Margin = new Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x31, 14);
            this.label8.TabIndex = 0xa6;
            this.label8.Text = "有效期";
            this.textBox6.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox6.Location = new Point(0x69, 0xa4);
            this.textBox6.Margin = new Padding(4);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new Size(0xd1, 0x17);
            this.textBox6.TabIndex = 0xa3;
            this.textBox6.TextAlign = HorizontalAlignment.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label6.Location = new Point(0x2b, 0xa9);
            this.label6.Margin = new Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x3f, 14);
            this.label6.TabIndex = 0xa2;
            this.label6.Text = "证件号码";
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label5.Location = new Point(0x39, 0x53);
            this.label5.Margin = new Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x31, 14);
            this.label5.TabIndex = 160;
            this.label5.Text = "车牌号";
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label3.Location = new Point(0x39, 0x1a);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x31, 14);
            this.label3.TabIndex = 0x9e;
            this.label3.Text = "单据号";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.Name = "FC_FixVehCard";
            base.Size = new Size(0x385, 0x264);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            base.ResumeLayout(false);
        }

        public void InitView()
        {
            this.textBox9.Text = "";
            this.textBox2.Text = "";
            this.textBox4.Text = "";
            this.textBox17.Text = "";
            this.textBox6.Text = "";
            try
            {
                this.dateTimePicker1.Value = DateTime.Parse("2008-01-01");
                this.dateTimePicker2.Value = DateTime.Parse("2009-01-01");
                this.dateTimePicker4.Value = DateTime.Parse("00:00:01");
                this.dateTimePicker3.Value = DateTime.Parse("23:59:59");
            }
            catch (Exception)
            {
            }
            this.textBox5.Text = "";
            this.textBox14.Text = "";
            this.textBox20.Text = "";
            this.textBox21.Text = "";
            this.textBox8.Text = "";
            this.textBox7.Text = "";
            this.radioButton1.Checked = true;
            this.radioButton2.Checked = false;
            this.textBox1.Text = "";
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex != -1)
            {
                this.txt_vehno.Text = this.listBox1.Text;
                this.listBox1.Visible = false;
                this.txt_vehno.SelectionStart = this.txt_vehno.Text.Length;
                this.txt_vehno.Focus();
                this.SearchBill();
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
                    this.SearchBill();
                    return;

                case 0x1b:
                    this.listBox1.Visible = false;
                    this.txt_vehno.Focus();
                    break;
            }
        }

        public void SearchBill()
        {
            string vehid = this.txt_vehno.Text.Trim();
            if (vehid == string.Empty)
            {
                this.InitView();
            }
            else
            {
                this.bills = this.iccardmanageservice.GetFixVehCardBill(vehid);
                if ((this.bills == null) || (this.bills.Length == 0))
                {
                    this.InitView();
                    this.textBox18.Focus();
                    MessageBox.Show("没有查询到相关车辆的发卡单！");
                }
                else if (this.bills.Length > 1)
                {
                    this.InitView();
                    MessageBox.Show("存在相关车辆的多个发卡单！");
                }
                else
                {
                    this.curbill = this.bills[0];
                    this.InitBillView();
                }
            }
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
                    MessageBox.Show("卡" + this.card.CardNo + "当前状态不允许发卡！");
                    this.card = null;
                }
                else
                {
                    this.textBox18.Text = this.card.CardNo;
                }
            }
        }

        private void textBox18_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.txt_vehno.SelectionStart = this.txt_vehno.Text.Length;
                this.txt_vehno.Focus();
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    this.listBox1.Visible = false;
                    this.SearchBill();
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
    }
}

