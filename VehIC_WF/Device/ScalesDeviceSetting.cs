namespace VehIC_WF.Device
{
    using LFY;
    using LFY.Controls;
    using LFY.Windows.Controls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using VehIC_Device;
    using VehIC_WF.Utility;

    public class ScalesDeviceSetting : Form
    {
        private AGauge aGauge4;
        private BevelLine bevelLine2;
        private Button btn_irda_save;
        private Button btn_scale_close;
        private Button btn_scale_open;
        private Button btn_scale_save;
        private ComboBox cb_bautrate;
        private ComboBox cb_databits;
        private ComboBox cb_parity;
        private ComboBox cb_port;
        private ComboBox cb_scaletype;
        private ComboBox cb_stopbits;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private ComboBox comboBox1;
        private IContainer components = null;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label10;
        private Label label12;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private AquaButton lamp_irda1;
        private AquaButton lamp_irda2;
        private TextBox textBox1;
        private Timer timer1;
        private TextBox txt_irda_channel;
        private TextBox txt_irda_deviceno;
        private TextBox txt_scale_sign;
        private TextBox txt_scale_status;
        private TextBox txt_scale_unit;
        private TextBox txt_scale_weigh;

        public ScalesDeviceSetting()
        {
            this.InitializeComponent();
        }

        private void btn_irda_save_Click(object sender, EventArgs e)
        {
            Regedit.SaveDevicePara("Irda", "InUse", this.checkBox1.Checked ? "1" : "0");
            Regedit.SaveDevicePara("Irda", "DeviceType", (this.comboBox1.SelectedIndex == 1) ? "1" : "0");
            Regedit.SaveDevicePara("Irda", "DeviceNo", this.txt_irda_deviceno.Text.Trim());
            Regedit.SaveDevicePara("Irda", "Channel", this.txt_irda_channel.Text.Trim());
            MessageBox.Show("保存成功！");
        }

        private void btn_scale_close_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            ScalesAsst.CloseDevice();
            this.lamp_irda1.ButtonColour = Color.Yellow;
            this.lamp_irda2.ButtonColour = Color.Yellow;
            this.txt_scale_unit.Text = string.Empty;
            this.txt_scale_sign.Text = string.Empty;
            this.txt_scale_weigh.Text = string.Empty;
            this.btn_scale_close.Enabled = false;
            this.btn_scale_open.Enabled = true;
        }

        private void btn_scale_open_Click(object sender, EventArgs e)
        {
            if (ScalesAsst.OpenDevice())
            {
                ScalesAsst.SetGaugePara(this.aGauge4);
                this.timer1.Start();
                this.btn_scale_close.Enabled = true;
                this.btn_scale_open.Enabled = false;
            }
        }

        private void btn_scale_save_Click(object sender, EventArgs e)
        {
            if (this.cb_scaletype.Text.Trim() != "")
            {
                if (this.cb_port.SelectedIndex == -1)
                {
                    MessageBox.Show("没有可用的Com端口！");
                }
                else
                {
                    Regedit.SaveDevicePara("Scale", "Type", this.cb_scaletype.SelectedIndex.ToString());
                    Regedit.SaveDevicePara("Scale", "Port", this.cb_port.Text.Trim().Substring(3));
                    Regedit.SaveDevicePara("Scale", "BaudRate", this.cb_bautrate.Text.Trim());
                    Regedit.SaveDevicePara("Scale", "DataBits", this.cb_databits.Text.Trim());
                    Regedit.SaveDevicePara("Scale", "StopBits", this.cb_stopbits.SelectedIndex.ToString());
                    Regedit.SaveDevicePara("Scale", "Parity", this.cb_parity.SelectedIndex.ToString());
                    MessageBox.Show("保存成功！");
                }
            }
        }

        private void cb_scaletype_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cb_bautrate.Items.Clear();
            switch (this.cb_scaletype.SelectedIndex)
            {
                case 0:
                    this.cb_bautrate.Items.Add("1200");
                    this.cb_bautrate.Items.Add("2400");
                    this.cb_bautrate.Items.Add("4800");
                    this.cb_bautrate.Items.Add("9600");
                    this.cb_bautrate.SelectedIndex = 1;
                    break;

                case 1:
                    this.cb_bautrate.Items.Add("2400");
                    this.cb_bautrate.Items.Add("4800");
                    this.cb_bautrate.Items.Add("9600");
                    this.cb_bautrate.Items.Add("19200");
                    this.cb_bautrate.SelectedIndex = 2;
                    break;

                case 2:
                    this.cb_bautrate.Items.Add("1200");
                    this.cb_bautrate.Items.Add("2400");
                    this.cb_bautrate.Items.Add("4800");
                    this.cb_bautrate.Items.Add("9600");
                    this.cb_bautrate.SelectedIndex = 1;
                    break;

                case 3:
                    this.cb_bautrate.Items.Add("1200");
                    this.cb_bautrate.Items.Add("2400");
                    this.cb_bautrate.SelectedIndex = 1;
                    break;

                case 4:
                    this.cb_bautrate.Items.Add("1200");
                    this.cb_bautrate.Items.Add("2400");
                    this.cb_bautrate.Items.Add("4800");
                    this.cb_bautrate.Items.Add("9600");
                    this.cb_bautrate.SelectedIndex = 1;
                    break;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.comboBox1.Enabled = this.checkBox1.Checked;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0)
            {
                this.txt_irda_channel.Text = "2";
            }
            if (this.comboBox1.SelectedIndex == 1)
            {
                this.txt_irda_channel.Text = "1、2";
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

        private void FillPorts()
        {
            MoblieReader reader = new MoblieReader();
            for (int i = 0; i < 0x63; i++)
            {
                string s = "COM" + i.ToString();
                if (reader.IsPortAvailable(s) == CommBase.PortStatus.available)
                {
                    this.cb_port.Items.Add(s);
                }
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ScalesDeviceSetting));
            this.groupBox1 = new GroupBox();
            this.comboBox1 = new ComboBox();
            this.label10 = new Label();
            this.checkBox1 = new CheckBox();
            this.btn_irda_save = new Button();
            this.txt_irda_channel = new TextBox();
            this.label3 = new Label();
            this.txt_irda_deviceno = new TextBox();
            this.label12 = new Label();
            this.groupBox2 = new GroupBox();
            this.txt_scale_sign = new TextBox();
            this.txt_scale_unit = new TextBox();
            this.txt_scale_weigh = new TextBox();
            this.checkBox2 = new CheckBox();
            this.textBox1 = new TextBox();
            this.btn_scale_close = new Button();
            this.btn_scale_open = new Button();
            this.cb_parity = new ComboBox();
            this.cb_stopbits = new ComboBox();
            this.cb_databits = new ComboBox();
            this.cb_bautrate = new ComboBox();
            this.cb_port = new ComboBox();
            this.cb_scaletype = new ComboBox();
            this.label9 = new Label();
            this.txt_scale_status = new TextBox();
            this.label8 = new Label();
            this.btn_scale_save = new Button();
            this.label7 = new Label();
            this.label5 = new Label();
            this.label4 = new Label();
            this.label2 = new Label();
            this.label1 = new Label();
            this.label6 = new Label();
            this.timer1 = new Timer(this.components);
            this.aGauge4 = new AGauge();
            this.bevelLine2 = new BevelLine();
            this.lamp_irda2 = new AquaButton();
            this.lamp_irda1 = new AquaButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.btn_irda_save);
            this.groupBox1.Controls.Add(this.txt_irda_channel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_irda_deviceno);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Dock = DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("楷体_GB2312", 15f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.groupBox1.Location = new Point(0, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x2db, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "红外设备";
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.Font = new System.Drawing.Font("楷体_GB2312", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] { "PCL730", "AC6652" });
            this.comboBox1.Location = new Point(120, 0x22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(0x90, 0x1b);
            this.comboBox1.TabIndex = 0xce;
            this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("楷体_GB2312", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label10.Location = new Point(0x1f, 0x26);
            this.label10.Margin = new Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x59, 0x13);
            this.label10.TabIndex = 0xcf;
            this.label10.Text = "设备类型";
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("楷体_GB2312", 15f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.checkBox1.Location = new Point(0x61, -1);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(70, 0x18);
            this.checkBox1.TabIndex = 0xcd;
            this.checkBox1.Text = "启用";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
            this.btn_irda_save.Location = new Point(0x25f, 0x18);
            this.btn_irda_save.Name = "btn_irda_save";
            this.btn_irda_save.Size = new Size(0x72, 0x27);
            this.btn_irda_save.TabIndex = 0xca;
            this.btn_irda_save.Text = "保存设置";
            this.btn_irda_save.UseVisualStyleBackColor = true;
            this.btn_irda_save.Click += new EventHandler(this.btn_irda_save_Click);
            this.txt_irda_channel.Font = new System.Drawing.Font("黑体", 15f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_irda_channel.Location = new Point(0x1fa, 0x22);
            this.txt_irda_channel.Margin = new Padding(4);
            this.txt_irda_channel.Name = "txt_irda_channel";
            this.txt_irda_channel.ReadOnly = true;
            this.txt_irda_channel.Size = new Size(0x52, 30);
            this.txt_irda_channel.TabIndex = 0xb5;
            this.txt_irda_channel.Text = "2";
            this.txt_irda_channel.TextAlign = HorizontalAlignment.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体_GB2312", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label3.Location = new Point(0x1ca, 0x26);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x31, 0x13);
            this.label3.TabIndex = 180;
            this.label3.Text = "通道";
            this.txt_irda_deviceno.Font = new System.Drawing.Font("黑体", 15f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_irda_deviceno.Location = new Point(0x15b, 0x22);
            this.txt_irda_deviceno.Margin = new Padding(4);
            this.txt_irda_deviceno.Name = "txt_irda_deviceno";
            this.txt_irda_deviceno.ReadOnly = true;
            this.txt_irda_deviceno.Size = new Size(0x52, 30);
            this.txt_irda_deviceno.TabIndex = 0xb3;
            this.txt_irda_deviceno.Text = "0";
            this.txt_irda_deviceno.TextAlign = HorizontalAlignment.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("楷体_GB2312", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label12.Location = new Point(0x116, 0x26);
            this.label12.Margin = new Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x45, 0x13);
            this.label12.TabIndex = 0xb2;
            this.label12.Text = "设备号";
            this.groupBox2.Controls.Add(this.txt_scale_sign);
            this.groupBox2.Controls.Add(this.txt_scale_unit);
            this.groupBox2.Controls.Add(this.txt_scale_weigh);
            this.groupBox2.Controls.Add(this.aGauge4);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.bevelLine2);
            this.groupBox2.Controls.Add(this.lamp_irda2);
            this.groupBox2.Controls.Add(this.lamp_irda1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.btn_scale_close);
            this.groupBox2.Controls.Add(this.btn_scale_open);
            this.groupBox2.Controls.Add(this.cb_parity);
            this.groupBox2.Controls.Add(this.cb_stopbits);
            this.groupBox2.Controls.Add(this.cb_databits);
            this.groupBox2.Controls.Add(this.cb_bautrate);
            this.groupBox2.Controls.Add(this.cb_port);
            this.groupBox2.Controls.Add(this.cb_scaletype);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txt_scale_status);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btn_scale_save);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Dock = DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("楷体_GB2312", 15f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.groupBox2.Location = new Point(0, 0x55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x2db, 0x193);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "地磅";
            this.txt_scale_sign.BackColor = SystemColors.WindowFrame;
            this.txt_scale_sign.Font = new System.Drawing.Font("宋体", 24f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.txt_scale_sign.ForeColor = Color.Lime;
            this.txt_scale_sign.Location = new Point(0x1ab, 0x83);
            this.txt_scale_sign.Margin = new Padding(4);
            this.txt_scale_sign.Name = "txt_scale_sign";
            this.txt_scale_sign.ReadOnly = true;
            this.txt_scale_sign.Size = new Size(20, 0x2c);
            this.txt_scale_sign.TabIndex = 0xf3;
            this.txt_scale_sign.TextAlign = HorizontalAlignment.Center;
            this.txt_scale_unit.BackColor = SystemColors.WindowFrame;
            this.txt_scale_unit.Font = new System.Drawing.Font("宋体", 24f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.txt_scale_unit.ForeColor = Color.Lime;
            this.txt_scale_unit.Location = new Point(0x272, 0x83);
            this.txt_scale_unit.Margin = new Padding(4);
            this.txt_scale_unit.Name = "txt_scale_unit";
            this.txt_scale_unit.ReadOnly = true;
            this.txt_scale_unit.Size = new Size(0x29, 0x2c);
            this.txt_scale_unit.TabIndex = 0xf2;
            this.txt_scale_unit.TextAlign = HorizontalAlignment.Center;
            this.txt_scale_weigh.BackColor = SystemColors.WindowFrame;
            this.txt_scale_weigh.Font = new System.Drawing.Font("宋体", 24f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.txt_scale_weigh.ForeColor = Color.Lime;
            this.txt_scale_weigh.Location = new Point(0x1c0, 0x83);
            this.txt_scale_weigh.Margin = new Padding(4);
            this.txt_scale_weigh.Name = "txt_scale_weigh";
            this.txt_scale_weigh.ReadOnly = true;
            this.txt_scale_weigh.Size = new Size(0xb1, 0x2c);
            this.txt_scale_weigh.TabIndex = 0xf1;
            this.txt_scale_weigh.TextAlign = HorizontalAlignment.Right;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new Point(0x1f5, 0x120);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new Size(15, 14);
            this.checkBox2.TabIndex = 0xef;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.textBox1.BackColor = SystemColors.WindowFrame;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = DockStyle.Bottom;
            this.textBox1.Font = new System.Drawing.Font("宋体", 18f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.textBox1.ForeColor = Color.Lime;
            this.textBox1.Location = new Point(3, 0x16d);
            this.textBox1.Margin = new Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x2d5, 0x23);
            this.textBox1.TabIndex = 0xca;
            this.textBox1.TextAlign = HorizontalAlignment.Right;
            this.btn_scale_close.Location = new Point(0x25f, 0x138);
            this.btn_scale_close.Name = "btn_scale_close";
            this.btn_scale_close.Size = new Size(0x72, 0x27);
            this.btn_scale_close.TabIndex = 0xc9;
            this.btn_scale_close.Text = "关闭";
            this.btn_scale_close.UseVisualStyleBackColor = true;
            this.btn_scale_close.Click += new EventHandler(this.btn_scale_close_Click);
            this.btn_scale_open.Location = new Point(0x1e5, 0x138);
            this.btn_scale_open.Name = "btn_scale_open";
            this.btn_scale_open.Size = new Size(0x72, 0x27);
            this.btn_scale_open.TabIndex = 200;
            this.btn_scale_open.Text = "打开";
            this.btn_scale_open.UseVisualStyleBackColor = true;
            this.btn_scale_open.Click += new EventHandler(this.btn_scale_open_Click);
            this.cb_parity.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cb_parity.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.cb_parity.FormattingEnabled = true;
            this.cb_parity.Items.AddRange(new object[] { "none", "odd", "even", "mark", "space" });
            this.cb_parity.Location = new Point(120, 0xe7);
            this.cb_parity.Name = "cb_parity";
            this.cb_parity.Size = new Size(0x90, 0x16);
            this.cb_parity.TabIndex = 0xc6;
            this.cb_stopbits.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cb_stopbits.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.cb_stopbits.FormattingEnabled = true;
            this.cb_stopbits.Items.AddRange(new object[] { "one", "onePointFive", "two" });
            this.cb_stopbits.Location = new Point(120, 0xc6);
            this.cb_stopbits.Name = "cb_stopbits";
            this.cb_stopbits.Size = new Size(0x90, 0x16);
            this.cb_stopbits.TabIndex = 0xc5;
            this.cb_databits.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cb_databits.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.cb_databits.FormattingEnabled = true;
            this.cb_databits.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8" });
            this.cb_databits.Location = new Point(120, 0xa5);
            this.cb_databits.Name = "cb_databits";
            this.cb_databits.Size = new Size(0x90, 0x16);
            this.cb_databits.TabIndex = 0xc4;
            this.cb_bautrate.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cb_bautrate.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.cb_bautrate.FormattingEnabled = true;
            this.cb_bautrate.Location = new Point(120, 0x7b);
            this.cb_bautrate.Name = "cb_bautrate";
            this.cb_bautrate.Size = new Size(0x90, 0x16);
            this.cb_bautrate.TabIndex = 0xc3;
            this.cb_port.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cb_port.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.cb_port.FormattingEnabled = true;
            this.cb_port.Location = new Point(120, 0x5c);
            this.cb_port.Name = "cb_port";
            this.cb_port.Size = new Size(0x90, 0x16);
            this.cb_port.TabIndex = 0xc2;
            this.cb_scaletype.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cb_scaletype.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.cb_scaletype.FormattingEnabled = true;
            this.cb_scaletype.Items.AddRange(new object[] { "50t", "50t[炼钢]", "80t", "100t", "150t" });
            this.cb_scaletype.Location = new Point(120, 0x21);
            this.cb_scaletype.Name = "cb_scaletype";
            this.cb_scaletype.Size = new Size(0x90, 0x16);
            this.cb_scaletype.TabIndex = 0xc1;
            this.cb_scaletype.SelectedIndexChanged += new EventHandler(this.cb_scaletype_SelectedIndexChanged);
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label9.Location = new Point(0x1aa, 0x120);
            this.label9.Margin = new Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x3f, 14);
            this.label9.TabIndex = 0xc0;
            this.label9.Text = "是否静荷";
            this.txt_scale_status.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_scale_status.Location = new Point(0x1eb, 0xf9);
            this.txt_scale_status.Margin = new Padding(4);
            this.txt_scale_status.Name = "txt_scale_status";
            this.txt_scale_status.ReadOnly = true;
            this.txt_scale_status.Size = new Size(0x91, 0x17);
            this.txt_scale_status.TabIndex = 190;
            this.txt_scale_status.TextAlign = HorizontalAlignment.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label8.Location = new Point(0x1aa, 0xfd);
            this.label8.Margin = new Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x3f, 14);
            this.label8.TabIndex = 0xbd;
            this.label8.Text = "地磅状态";
            this.btn_scale_save.Location = new Point(0xe2, 0x138);
            this.btn_scale_save.Name = "btn_scale_save";
            this.btn_scale_save.Size = new Size(0x72, 0x27);
            this.btn_scale_save.TabIndex = 0xb9;
            this.btn_scale_save.Text = "保存设置";
            this.btn_scale_save.UseVisualStyleBackColor = true;
            this.btn_scale_save.Click += new EventHandler(this.btn_scale_save_Click);
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label7.Location = new Point(0x39, 0x25);
            this.label7.Margin = new Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x3f, 14);
            this.label7.TabIndex = 0xaf;
            this.label7.Text = "地磅类型";
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label5.Location = new Point(0x47, 0xeb);
            this.label5.Margin = new Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x31, 14);
            this.label5.TabIndex = 0xad;
            this.label5.Text = "校验位";
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label4.Location = new Point(0x47, 0xca);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x31, 14);
            this.label4.TabIndex = 0xab;
            this.label4.Text = "停止位";
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label2.Location = new Point(0x47, 0xa9);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x31, 14);
            this.label2.TabIndex = 0xa9;
            this.label2.Text = "数据位";
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label1.Location = new Point(0x47, 0x7f);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x31, 14);
            this.label1.TabIndex = 0xa7;
            this.label1.Text = "波特率";
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label6.Location = new Point(0x55, 0x60);
            this.label6.Margin = new Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x23, 14);
            this.label6.TabIndex = 0xa5;
            this.label6.Text = "端口";
            this.timer1.Interval = 0x3e8;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.aGauge4.BaseArcColor = Color.Gray;
            this.aGauge4.BaseArcRadius = 150;
            this.aGauge4.BaseArcStart = 0xd7;
            this.aGauge4.BaseArcSweep = 110;
            this.aGauge4.BaseArcWidth = 2;
            this.aGauge4.Cap_Idx = 1;
            this.aGauge4.CapColors =new Color[] { Color.Black, Color.Black, Color.Black, Color.Black, Color.Black }; 
            this.aGauge4.CapPosition = new Point(10, 10);
            this.aGauge4.CapsPosition = new Point[] { new Point(10, 10), new Point(10, 10), new Point(10, 10), new Point(10, 10), new Point(10, 10) };
            this.aGauge4.CapsText = new string[] { "", "", "", "", "" };
            this.aGauge4.CapText = "";
            this.aGauge4.Center = new Point(150, 180);
            this.aGauge4.Location = new Point(0x18c, 12);
            this.aGauge4.MaxValue = 80f;
            this.aGauge4.MinValue = 0f;
            this.aGauge4.Name = "aGauge4";
            this.aGauge4.NeedleColor1 = AGauge.NeedleColorEnum.Green;
            this.aGauge4.NeedleColor2 = Color.DimGray;
            this.aGauge4.NeedleRadius = 150;
            this.aGauge4.NeedleType = 0;
            this.aGauge4.NeedleWidth = 2;
            this.aGauge4.Range_Idx = 1;
            this.aGauge4.RangeColor = Color.FromArgb(0xff, 0x80, 0x80);
            this.aGauge4.RangeEnabled = false;
            this.aGauge4.RangeEndValue = 400f;
            this.aGauge4.RangeInnerRadius = 10;
            this.aGauge4.RangeOuterRadius = 40;
            this.aGauge4.RangesColor = new Color[] { Color.LightGreen, Color.FromArgb(0xff, 0x80, 0x80), SystemColors.Control, SystemColors.Control, SystemColors.Control };
            this.aGauge4.RangesEnabled = new bool[5];
            float[] numArray = new float[5];
            numArray[0] = 300f;
            numArray[1] = 400f;
            this.aGauge4.RangesEndValue = numArray;
            this.aGauge4.RangesInnerRadius = new int[] { 70, 10, 70, 70, 70 };
            this.aGauge4.RangesOuterRadius = new int[] { 80, 40, 80, 80, 80 };
            float[] numArray1 = new float[5];
            numArray1[0] = -100f;
            numArray1[1] = 300f;
            this.aGauge4.RangesStartValue = numArray1;
            this.aGauge4.RangeStartValue = 300f;
            this.aGauge4.ScaleLinesInterColor = Color.Red;
            this.aGauge4.ScaleLinesInterInnerRadius = 0x91;
            this.aGauge4.ScaleLinesInterOuterRadius = 150;
            this.aGauge4.ScaleLinesInterWidth = 2;
            this.aGauge4.ScaleLinesMajorColor = Color.Black;
            this.aGauge4.ScaleLinesMajorInnerRadius = 140;
            this.aGauge4.ScaleLinesMajorOuterRadius = 150;
            this.aGauge4.ScaleLinesMajorStepValue = 10f;
            this.aGauge4.ScaleLinesMajorWidth = 2;
            this.aGauge4.ScaleLinesMinorColor = Color.Gray;
            this.aGauge4.ScaleLinesMinorInnerRadius = 0x91;
            this.aGauge4.ScaleLinesMinorNumOf = 9;
            this.aGauge4.ScaleLinesMinorOuterRadius = 150;
            this.aGauge4.ScaleLinesMinorWidth = 1;
            this.aGauge4.ScaleNumbersColor = Color.Black;
            this.aGauge4.ScaleNumbersFormat = null;
            this.aGauge4.ScaleNumbersRadius = 0xa2;
            this.aGauge4.ScaleNumbersRotation = 90;
            this.aGauge4.ScaleNumbersStartScaleLine = 1;
            this.aGauge4.ScaleNumbersStepScaleLines = 2;
            this.aGauge4.Size = new Size(0x129, 0x74);
            this.aGauge4.TabIndex = 240;
            this.aGauge4.Text = "l";
            this.aGauge4.Value = 33f;
            this.bevelLine2.Angle = 0;
            this.bevelLine2.Location = new Point(360, 0x1a);
            this.bevelLine2.Name = "bevelLine2";
            this.bevelLine2.Orientation = Orientation.Vertical;
            this.bevelLine2.Size = new Size(2, 0x13c);
            this.bevelLine2.TabIndex = 0xe8;
            this.lamp_irda2.BackColor = Color.FromArgb(0xd8, 0xe5, 250);
            this.lamp_irda2.BackgroundImage = (Image) resources.GetObject("lamp_irda2.BackgroundImage");
            this.lamp_irda2.ButtonColour = Color.Yellow;
            this.lamp_irda2.ButtonText = "";
            this.lamp_irda2.Enabled = false;
            this.lamp_irda2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5f);
            this.lamp_irda2.FontSize = 10.5f;
            this.lamp_irda2.ForeColor = SystemColors.ActiveCaption;
            this.lamp_irda2.Location = new Point(0x269, 0xb8);
            this.lamp_irda2.Name = "lamp_irda2";
            this.lamp_irda2.Size = new Size(50, 50);
            this.lamp_irda2.TabIndex = 0xea;
            this.lamp_irda2.TextColour = Color.White;
            this.lamp_irda1.BackColor = Color.FromArgb(0xd8, 0xe5, 250);
            this.lamp_irda1.BackgroundImage = (Image) resources.GetObject("lamp_irda1.BackgroundImage");
            this.lamp_irda1.ButtonColour = Color.Yellow;
            this.lamp_irda1.ButtonText = "";
            this.lamp_irda1.Enabled = false;
            this.lamp_irda1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5f);
            this.lamp_irda1.FontSize = 10.5f;
            this.lamp_irda1.ForeColor = SystemColors.ActiveCaption;
            this.lamp_irda1.Location = new Point(0x1ab, 0xb8);
            this.lamp_irda1.Name = "lamp_irda1";
            this.lamp_irda1.Size = new Size(50, 50);
            this.lamp_irda1.TabIndex = 0xe5;
            this.lamp_irda1.TextColour = Color.White;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x2db, 0x1e8);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.Name = "ScalesDeviceSetting";
            base.Padding = new Padding(0, 5, 0, 0);
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ScalesDeviceSetting";
            base.Load += new EventHandler(this.ScalesDeviceSetting_Load);
            base.FormClosing += new FormClosingEventHandler(this.ScalesDeviceSetting_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            base.ResumeLayout(false);
        }

        private void LoadPara()
        {
            this.cb_parity.SelectedIndex = 2;
            this.cb_stopbits.SelectedIndex = 0;
            this.cb_databits.SelectedIndex = 6;
            string str = Regedit.ReadDevicePara("Irda", "InUse");
            string str2 = Regedit.ReadDevicePara("Irda", "DeviceType");
            if (str != null)
            {
                this.checkBox1.Checked = str == "1";
            }
            this.comboBox1.Enabled = this.checkBox1.Checked;
            this.comboBox1.SelectedIndex = (str2 == "1") ? 1 : 0;
            string s = Regedit.ReadDevicePara("Scale", "Type");
            string str4 = Regedit.ReadDevicePara("Scale", "Port");
            string str5 = Regedit.ReadDevicePara("Scale", "BaudRate");
            string str6 = Regedit.ReadDevicePara("Scale", "DataBits");
            string str7 = Regedit.ReadDevicePara("Scale", "StopBits");
            string str8 = Regedit.ReadDevicePara("Scale", "Parity");
            if (s != null)
            {
                this.cb_scaletype.SelectedIndex = int.Parse(s);
            }
            if (str4 != null)
            {
                this.cb_port.Text = "COM" + str4;
            }
            if (str5 != null)
            {
                this.cb_bautrate.Text = str5;
            }
            if (str6 != null)
            {
                this.cb_databits.Text = str6;
            }
            if (str7 != null)
            {
                this.cb_stopbits.SelectedIndex = int.Parse(str7);
            }
            if (str8 != null)
            {
                this.cb_parity.SelectedIndex = int.Parse(str8);
            }
        }

        private void ScalesDeviceSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.btn_scale_close_Click(sender, e);
        }

        private void ScalesDeviceSetting_Load(object sender, EventArgs e)
        {
            this.btn_scale_close.Enabled = false;
            this.FillPorts();
            this.LoadPara();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ScalesAsst.Scale != null)
            {
                if (ScalesAsst.Scale.Excute())
                {
                    this.txt_scale_weigh.ForeColor = ScalesAsst.Scale.ISWhisht ? Color.Lime : Color.Red;
                    this.txt_scale_weigh.Text = ScalesAsst.Scale.Weigh;
                    try
                    {
                        this.aGauge4.Value = float.Parse(ScalesAsst.Scale.WeighEx);
                    }
                    catch
                    {
                    }
                    this.txt_scale_sign.Text = ScalesAsst.Scale.Sign;
                    this.txt_scale_unit.Text = ScalesAsst.Scale.Unit;
                    this.txt_scale_status.Text = Common.ScaleStatusDesc[(int) ScalesAsst.Scale.Status];
                    this.checkBox2.Checked = ScalesAsst.Scale.ISWhisht;
                }
                this.textBox1.Text = DateTime.Now.ToShortTimeString() + "\t" + ScalesAsst.Scale.ErrMsg;
            }
            if ((ScalesAsst.Irda != null) && ScalesAsst.Irda.InUse)
            {
                bool[] flagArray = ScalesAsst.Irda.Excute();
                this.lamp_irda1.ButtonColour = flagArray[0] ? Color.Lime : Color.Red;
                this.lamp_irda2.ButtonColour = flagArray[1] ? Color.Lime : Color.Red;
            }
            else
            {
                this.lamp_irda1.ButtonColour = Color.Yellow;
                this.lamp_irda2.ButtonColour = Color.Yellow;
            }
        }
    }
}

