namespace VehIC_WF.Device
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO.Ports;
    using System.Windows.Forms;
    using VehIC_BL;
    using VehIC_Device;
    using VehIC_WF;
    using VehIC_WF.Utility;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;
    public class UC_DeviceManage : UserControl, ICardMessage
    {
        private Button btnSave;
        private ComboBox cb_port_1;
        private ComboBox cb_baud_1;
        private IContainer components = null;
        private GroupBox grpFixReader;
        private GroupBox grpRoadBrake1;
        private Label label1;
        private Label label6;
        private Label label7;
        private System.Windows.Forms.Panel panel1;// = new System.Windows.Forms.Panel();
        private Panel panel2;
        private Panel panel3;
        private Panel panel5;
        private ComboBox cb_usetype_1;
        private Label label19;
        private ComboBox cb_controlid_1;
        private Label label20;
        private Label label21;
        private ComboBox cb_devicetype_1;
        private Label label22;
        private ComboBox cb_devicetype_4;
        private CheckBox chk_inuse_4;
        private ComboBox cb_controlid_4;
        private Label label23;
        private ComboBox cb_usetype_4;
        private Label label24;
        private ComboBox cb_baud_4;
        private Label label25;
        private ComboBox cb_port_4;
        private Label label26;
        private Label label13;
        private ComboBox cb_devicetype_3;
        private CheckBox chk_inuse_3;
        private ComboBox cb_controlid_3;
        private Label label14;
        private ComboBox cb_usetype_3;
        private Label label15;
        private ComboBox cb_baud_3;
        private Label label16;
        private ComboBox cb_port_3;
        private Label label17;
        private Label label2;
        private ComboBox cb_devicetype_2;
        private CheckBox chk_inuse_2;
        private ComboBox cb_controlid_2;
        private Label label3;
        private ComboBox cb_usetype_2;
        private Label label10;
        private ComboBox cb_baud_2;
        private Label label11;
        private ComboBox cb_port_2;
        private Label label12;
        private Label label4;
        private ComboBox cb_devicetype_7;
        private ComboBox cb_controlid_7;
        private Label label5;
        private ComboBox cb_baud_7;
        private Label label37;
        private ComboBox cb_port_7;
        private Label label38;
        private Label label32;
        private ComboBox cb_devicetype_6;
        private CheckBox chk_inuse_6;
        private ComboBox cb_controlid_6;
        private Label label33;
        private ComboBox cb_usetype_6;
        private Label label34;
        private ComboBox cb_baud_6;
        private Label label35;
        private ComboBox cb_port_6;
        private Label label36;
        private Label label27;
        private ComboBox cb_devicetype_5;
        private CheckBox chk_inuse_5;
        private ComboBox cb_controlid_5;
        private Label label28;
        private ComboBox cb_usetype_5;
        private Label label29;
        private ComboBox cb_baud_5;
        private Label label30;
        private ComboBox cb_port_5;
        private Label label31;
        private GroupBox groupBox1;
        private ComboBox cb_port_8;
        private Label label43;
        private Label label42;
        private ComboBox cb_baud_8;
        private Label label40;
        private ComboBox cb_controlid_8;
        private ComboBox cb_devicetype_8;
        private Label label39;
        private ComboBox cb_addr_8;
        private Label label9;
        private ComboBox cb_addr_7;
        private Label label8;
        private CheckBox chk_inuse_8;
        private CheckBox chk_inuse_7;
        private TextBox testInfo;
        private CheckBox chk_test_roadbrake;
        private CheckBox chk_test;
        private GroupBox groupBox2;
        private Label label46;
        private Label label45;
        private Label label44;
        private ComboBox cb_jg;
        private Label label41;
        private ComboBox cb_sj;
        private Label label18;
        private ComboBox cb_sendcount;
        private GroupBox groupBox3;
        private RadioButton rdNew;
        private RadioButton rdOriginal;
        private GroupBox 检验设备参数;
        private TextBox jysbsjk;
        private ComboBox jysb;
        private CheckBox chk_inuse_1;

        public UC_DeviceManage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                DeviceInfo deviceInfo = DeviceConfigManager.Instance.GetDeviceInfo(i);
               
                deviceInfo.Port = cb_port[i, 0].Text.Trim();
                deviceInfo.Baudrate = int.Parse(cb_port[i, 1].Text.Trim());
                deviceInfo.ControlId = int.Parse(cb_port[i, 2].Text.Trim());
                deviceInfo.DeviceType = cb_port[i, 3].Text.Trim();
                deviceInfo.UseType = cb_port[i, 4].Text.Trim();
                deviceInfo.InUse = chk_inuse[i].Checked;
            }

            DeviceInfo inDoorDevice = DeviceConfigManager.Instance.GetDeviceInfo(6);
            inDoorDevice.FuncType = "RoadBrake";
            inDoorDevice.Port = cb_port_7.Text.Trim();
            inDoorDevice.Baudrate = int.Parse(cb_baud_7.Text.Trim());
            inDoorDevice.ControlId = int.Parse(cb_controlid_7.Text.Trim());
            inDoorDevice.Addr = int.Parse(cb_addr_7.Text.Trim());
            inDoorDevice.DeviceType = cb_devicetype_7.Text.Trim();
            inDoorDevice.UseType = "进门";
            inDoorDevice.InUse = chk_inuse_7.Checked;

            DeviceInfo outDoorDevice = DeviceConfigManager.Instance.GetDeviceInfo(7);
            outDoorDevice.FuncType = "RoadBrake";
            outDoorDevice.Port = cb_port_8.Text.Trim();
            outDoorDevice.Baudrate = int.Parse(cb_baud_8.Text.Trim());
            outDoorDevice.ControlId = int.Parse(cb_controlid_8.Text.Trim());
            outDoorDevice.Addr = int.Parse(cb_addr_8.Text.Trim());
            outDoorDevice.DeviceType = cb_devicetype_8.Text.Trim();
            outDoorDevice.UseType = "出门";
            outDoorDevice.InUse = chk_inuse_8.Checked;

            DeviceConfigManager.Instance.config.Jysb = jysb.Text.ToString();
            DeviceConfigManager.Instance.config.Jysbsjk = jysbsjk.Text.ToString();
            DeviceConfigManager.Instance.config.SyrisKZCount = int.Parse(cb_sendcount.Text.Trim());
            DeviceConfigManager.Instance.config.SyrisKZTime = int.Parse(cb_sj.Text.Trim());
            DeviceConfigManager.Instance.config.SyrisKZInterval = int.Parse(cb_jg.Text.Trim());
            DeviceConfigManager.Instance.config.PrintType = rdOriginal.Checked ? 0 : 1;
            DeviceConfigManager.Instance.Save();
            MessageBox.Show("保存成功,重新启动程序后参数有效！");
        }

        private bool ChechPort(string str, bool isport)
        {
            string s = str;
            if (isport)
            {
                s = str.Trim().Substring(3);
            }
            try
            {
                int num = int.Parse(s);
                return true;
            }
            catch (Exception)
            {
                return false;
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.检验设备参数 = new System.Windows.Forms.GroupBox();
            this.jysbsjk = new System.Windows.Forms.TextBox();
            this.jysb = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdNew = new System.Windows.Forms.RadioButton();
            this.rdOriginal = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.cb_jg = new System.Windows.Forms.ComboBox();
            this.label41 = new System.Windows.Forms.Label();
            this.cb_sj = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cb_sendcount = new System.Windows.Forms.ComboBox();
            this.chk_test_roadbrake = new System.Windows.Forms.CheckBox();
            this.chk_test = new System.Windows.Forms.CheckBox();
            this.testInfo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_inuse_8 = new System.Windows.Forms.CheckBox();
            this.cb_addr_8 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_port_8 = new System.Windows.Forms.ComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.cb_baud_8 = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.cb_controlid_8 = new System.Windows.Forms.ComboBox();
            this.cb_devicetype_8 = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpRoadBrake1 = new System.Windows.Forms.GroupBox();
            this.chk_inuse_7 = new System.Windows.Forms.CheckBox();
            this.cb_addr_7 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_devicetype_7 = new System.Windows.Forms.ComboBox();
            this.cb_controlid_7 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_baud_7 = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.cb_port_7 = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.grpFixReader = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.cb_devicetype_5 = new System.Windows.Forms.ComboBox();
            this.chk_inuse_5 = new System.Windows.Forms.CheckBox();
            this.cb_controlid_5 = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.cb_usetype_5 = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cb_baud_5 = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.cb_port_5 = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cb_devicetype_4 = new System.Windows.Forms.ComboBox();
            this.chk_inuse_4 = new System.Windows.Forms.CheckBox();
            this.cb_controlid_4 = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cb_usetype_4 = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cb_baud_4 = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cb_port_4 = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cb_devicetype_3 = new System.Windows.Forms.ComboBox();
            this.chk_inuse_3 = new System.Windows.Forms.CheckBox();
            this.cb_controlid_3 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cb_usetype_3 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cb_baud_3 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cb_port_3 = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_devicetype_6 = new System.Windows.Forms.ComboBox();
            this.cb_devicetype_2 = new System.Windows.Forms.ComboBox();
            this.chk_inuse_6 = new System.Windows.Forms.CheckBox();
            this.chk_inuse_2 = new System.Windows.Forms.CheckBox();
            this.cb_controlid_6 = new System.Windows.Forms.ComboBox();
            this.cb_controlid_2 = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_usetype_6 = new System.Windows.Forms.ComboBox();
            this.cb_usetype_2 = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cb_baud_6 = new System.Windows.Forms.ComboBox();
            this.cb_baud_2 = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cb_port_6 = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.cb_port_2 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cb_devicetype_1 = new System.Windows.Forms.ComboBox();
            this.chk_inuse_1 = new System.Windows.Forms.CheckBox();
            this.cb_controlid_1 = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cb_usetype_1 = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cb_baud_1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_port_1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.检验设备参数.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.grpRoadBrake1.SuspendLayout();
            this.grpFixReader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(901, 70);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Info;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(899, 68);
            this.label7.TabIndex = 173;
            this.label7.Text = "  　设备参数设置:\r\n         1.门岗需要设置读卡器、进出门道闸设备的参数。\r\n         2.取样、计量、货场之需要设置读卡器参数。\r\n   " +
    "      3.不同设备可以使用同一端口，但同一端口只使用第一个波特率和设备类型。";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(901, 554);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.检验设备参数);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.chk_test_roadbrake);
            this.panel3.Controls.Add(this.chk_test);
            this.panel3.Controls.Add(this.testInfo);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.grpRoadBrake1);
            this.panel3.Controls.Add(this.grpFixReader);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.panel3.Size = new System.Drawing.Size(899, 552);
            this.panel3.TabIndex = 0;
            // 
            // 检验设备参数
            // 
            this.检验设备参数.Controls.Add(this.jysbsjk);
            this.检验设备参数.Controls.Add(this.jysb);
            this.检验设备参数.Location = new System.Drawing.Point(-1, 474);
            this.检验设备参数.Name = "检验设备参数";
            this.检验设备参数.Size = new System.Drawing.Size(900, 44);
            this.检验设备参数.TabIndex = 153;
            this.检验设备参数.TabStop = false;
            this.检验设备参数.Text = "检验设备参数";
            // 
            // jysbsjk
            // 
            this.jysbsjk.Location = new System.Drawing.Point(188, 13);
            this.jysbsjk.Name = "jysbsjk";
            this.jysbsjk.Size = new System.Drawing.Size(168, 21);
            this.jysbsjk.TabIndex = 162;
            // 
            // jysb
            // 
            this.jysb.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jysb.FormattingEnabled = true;
            this.jysb.Items.AddRange(new object[] {
            "硫分仪",
            "煤质仪2",
            "煤质仪3",
            "煤质仪4"});
            this.jysb.Location = new System.Drawing.Point(76, 13);
            this.jysb.Name = "jysb";
            this.jysb.Size = new System.Drawing.Size(80, 22);
            this.jysb.TabIndex = 161;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdNew);
            this.groupBox3.Controls.Add(this.rdOriginal);
            this.groupBox3.Location = new System.Drawing.Point(250, 329);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(163, 127);
            this.groupBox3.TabIndex = 152;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "周转单打印类型";
            // 
            // rdNew
            // 
            this.rdNew.AutoSize = true;
            this.rdNew.Location = new System.Drawing.Point(34, 62);
            this.rdNew.Name = "rdNew";
            this.rdNew.Size = new System.Drawing.Size(71, 16);
            this.rdNew.TabIndex = 1;
            this.rdNew.TabStop = true;
            this.rdNew.Text = "单据打印";
            this.rdNew.UseVisualStyleBackColor = true;
            // 
            // rdOriginal
            // 
            this.rdOriginal.AutoSize = true;
            this.rdOriginal.Checked = true;
            this.rdOriginal.Location = new System.Drawing.Point(34, 34);
            this.rdOriginal.Name = "rdOriginal";
            this.rdOriginal.Size = new System.Drawing.Size(47, 16);
            this.rdOriginal.TabIndex = 0;
            this.rdOriginal.TabStop = true;
            this.rdOriginal.Text = "原有";
            this.rdOriginal.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label46);
            this.groupBox2.Controls.Add(this.label45);
            this.groupBox2.Controls.Add(this.label44);
            this.groupBox2.Controls.Add(this.cb_jg);
            this.groupBox2.Controls.Add(this.label41);
            this.groupBox2.Controls.Add(this.cb_sj);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.cb_sendcount);
            this.groupBox2.Location = new System.Drawing.Point(20, 326);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 130);
            this.groupBox2.TabIndex = 151;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "玺瑞道闸控制指令参数";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label46.Location = new System.Drawing.Point(142, 91);
            this.label46.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(35, 14);
            this.label46.TabIndex = 260;
            this.label46.Text = "毫秒";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label45.Location = new System.Drawing.Point(141, 63);
            this.label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(21, 14);
            this.label45.TabIndex = 259;
            this.label45.Text = "秒";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label44.Location = new System.Drawing.Point(28, 91);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(35, 14);
            this.label44.TabIndex = 258;
            this.label44.Text = "间隔";
            // 
            // cb_jg
            // 
            this.cb_jg.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_jg.FormattingEnabled = true;
            this.cb_jg.Location = new System.Drawing.Point(75, 87);
            this.cb_jg.Name = "cb_jg";
            this.cb_jg.Size = new System.Drawing.Size(60, 22);
            this.cb_jg.TabIndex = 257;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label41.Location = new System.Drawing.Point(28, 63);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(35, 14);
            this.label41.TabIndex = 256;
            this.label41.Text = "持续";
            // 
            // cb_sj
            // 
            this.cb_sj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_sj.FormattingEnabled = true;
            this.cb_sj.Location = new System.Drawing.Point(75, 59);
            this.cb_sj.Name = "cb_sj";
            this.cb_sj.Size = new System.Drawing.Size(60, 22);
            this.cb_sj.TabIndex = 255;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(28, 35);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 14);
            this.label18.TabIndex = 254;
            this.label18.Text = "次数";
            // 
            // cb_sendcount
            // 
            this.cb_sendcount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_sendcount.FormattingEnabled = true;
            this.cb_sendcount.Location = new System.Drawing.Point(75, 31);
            this.cb_sendcount.Name = "cb_sendcount";
            this.cb_sendcount.Size = new System.Drawing.Size(60, 22);
            this.cb_sendcount.TabIndex = 253;
            // 
            // chk_test_roadbrake
            // 
            this.chk_test_roadbrake.AutoSize = true;
            this.chk_test_roadbrake.Location = new System.Drawing.Point(557, 323);
            this.chk_test_roadbrake.Name = "chk_test_roadbrake";
            this.chk_test_roadbrake.Size = new System.Drawing.Size(72, 16);
            this.chk_test_roadbrake.TabIndex = 150;
            this.chk_test_roadbrake.Text = "测试道闸";
            this.chk_test_roadbrake.UseVisualStyleBackColor = true;
            this.chk_test_roadbrake.Visible = false;
            // 
            // chk_test
            // 
            this.chk_test.AutoSize = true;
            this.chk_test.Location = new System.Drawing.Point(499, 323);
            this.chk_test.Name = "chk_test";
            this.chk_test.Size = new System.Drawing.Size(48, 16);
            this.chk_test.TabIndex = 149;
            this.chk_test.Text = "测试";
            this.chk_test.UseVisualStyleBackColor = true;
            this.chk_test.CheckedChanged += new System.EventHandler(this.chk_test_CheckedChanged);
            // 
            // testInfo
            // 
            this.testInfo.Location = new System.Drawing.Point(488, 345);
            this.testInfo.Multiline = true;
            this.testInfo.Name = "testInfo";
            this.testInfo.Size = new System.Drawing.Size(214, 123);
            this.testInfo.TabIndex = 148;
            this.testInfo.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_inuse_8);
            this.groupBox1.Controls.Add(this.cb_addr_8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cb_port_8);
            this.groupBox1.Controls.Add(this.label43);
            this.groupBox1.Controls.Add(this.label42);
            this.groupBox1.Controls.Add(this.cb_baud_8);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Controls.Add(this.cb_controlid_8);
            this.groupBox1.Controls.Add(this.cb_devicetype_8);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 265);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(899, 52);
            this.groupBox1.TabIndex = 147;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "出门道闸";
            // 
            // chk_inuse_8
            // 
            this.chk_inuse_8.AutoSize = true;
            this.chk_inuse_8.Location = new System.Drawing.Point(813, 26);
            this.chk_inuse_8.Name = "chk_inuse_8";
            this.chk_inuse_8.Size = new System.Drawing.Size(54, 18);
            this.chk_inuse_8.TabIndex = 258;
            this.chk_inuse_8.Text = "使用";
            this.chk_inuse_8.UseVisualStyleBackColor = true;
            // 
            // cb_addr_8
            // 
            this.cb_addr_8.Enabled = false;
            this.cb_addr_8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_addr_8.FormattingEnabled = true;
            this.cb_addr_8.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cb_addr_8.Location = new System.Drawing.Point(488, 22);
            this.cb_addr_8.Name = "cb_addr_8";
            this.cb_addr_8.Size = new System.Drawing.Size(60, 22);
            this.cb_addr_8.TabIndex = 256;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(456, 27);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 14);
            this.label9.TabIndex = 257;
            this.label9.Text = "地址";
            // 
            // cb_port_8
            // 
            this.cb_port_8.Enabled = false;
            this.cb_port_8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_port_8.FormattingEnabled = true;
            this.cb_port_8.Location = new System.Drawing.Point(88, 22);
            this.cb_port_8.Name = "cb_port_8";
            this.cb_port_8.Size = new System.Drawing.Size(80, 22);
            this.cb_port_8.TabIndex = 245;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label43.Location = new System.Drawing.Point(55, 26);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(35, 14);
            this.label43.TabIndex = 246;
            this.label43.Text = "端口";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label42.Location = new System.Drawing.Point(184, 26);
            this.label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(49, 14);
            this.label42.TabIndex = 248;
            this.label42.Text = "波特率";
            // 
            // cb_baud_8
            // 
            this.cb_baud_8.Enabled = false;
            this.cb_baud_8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_baud_8.FormattingEnabled = true;
            this.cb_baud_8.Location = new System.Drawing.Point(231, 22);
            this.cb_baud_8.Name = "cb_baud_8";
            this.cb_baud_8.Size = new System.Drawing.Size(80, 22);
            this.cb_baud_8.TabIndex = 247;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label40.Location = new System.Drawing.Point(333, 26);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(49, 14);
            this.label40.TabIndex = 252;
            this.label40.Text = "设备号";
            // 
            // cb_controlid_8
            // 
            this.cb_controlid_8.Enabled = false;
            this.cb_controlid_8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_controlid_8.FormattingEnabled = true;
            this.cb_controlid_8.Location = new System.Drawing.Point(380, 22);
            this.cb_controlid_8.Name = "cb_controlid_8";
            this.cb_controlid_8.Size = new System.Drawing.Size(60, 22);
            this.cb_controlid_8.TabIndex = 251;
            // 
            // cb_devicetype_8
            // 
            this.cb_devicetype_8.Enabled = false;
            this.cb_devicetype_8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_devicetype_8.FormattingEnabled = true;
            this.cb_devicetype_8.Location = new System.Drawing.Point(605, 22);
            this.cb_devicetype_8.Name = "cb_devicetype_8";
            this.cb_devicetype_8.Size = new System.Drawing.Size(157, 22);
            this.cb_devicetype_8.TabIndex = 254;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label39.Location = new System.Drawing.Point(568, 26);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(35, 14);
            this.label39.TabIndex = 255;
            this.label39.Text = "类型";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnSave);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 515);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(899, 37);
            this.panel5.TabIndex = 146;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(726, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 29);
            this.btnSave.TabIndex = 147;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpRoadBrake1
            // 
            this.grpRoadBrake1.Controls.Add(this.chk_inuse_7);
            this.grpRoadBrake1.Controls.Add(this.cb_addr_7);
            this.grpRoadBrake1.Controls.Add(this.label8);
            this.grpRoadBrake1.Controls.Add(this.label4);
            this.grpRoadBrake1.Controls.Add(this.cb_devicetype_7);
            this.grpRoadBrake1.Controls.Add(this.cb_controlid_7);
            this.grpRoadBrake1.Controls.Add(this.label5);
            this.grpRoadBrake1.Controls.Add(this.cb_baud_7);
            this.grpRoadBrake1.Controls.Add(this.label37);
            this.grpRoadBrake1.Controls.Add(this.cb_port_7);
            this.grpRoadBrake1.Controls.Add(this.label38);
            this.grpRoadBrake1.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRoadBrake1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpRoadBrake1.Location = new System.Drawing.Point(0, 212);
            this.grpRoadBrake1.Name = "grpRoadBrake1";
            this.grpRoadBrake1.Size = new System.Drawing.Size(899, 53);
            this.grpRoadBrake1.TabIndex = 7;
            this.grpRoadBrake1.TabStop = false;
            this.grpRoadBrake1.Text = "进门道闸";
            // 
            // chk_inuse_7
            // 
            this.chk_inuse_7.AutoSize = true;
            this.chk_inuse_7.Location = new System.Drawing.Point(813, 17);
            this.chk_inuse_7.Name = "chk_inuse_7";
            this.chk_inuse_7.Size = new System.Drawing.Size(54, 18);
            this.chk_inuse_7.TabIndex = 247;
            this.chk_inuse_7.Text = "使用";
            this.chk_inuse_7.UseVisualStyleBackColor = true;
            // 
            // cb_addr_7
            // 
            this.cb_addr_7.Enabled = false;
            this.cb_addr_7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_addr_7.FormattingEnabled = true;
            this.cb_addr_7.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cb_addr_7.Location = new System.Drawing.Point(488, 15);
            this.cb_addr_7.Name = "cb_addr_7";
            this.cb_addr_7.Size = new System.Drawing.Size(60, 22);
            this.cb_addr_7.TabIndex = 245;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(456, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 246;
            this.label8.Text = "地址";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(568, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 244;
            this.label4.Text = "类型";
            // 
            // cb_devicetype_7
            // 
            this.cb_devicetype_7.Enabled = false;
            this.cb_devicetype_7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_devicetype_7.FormattingEnabled = true;
            this.cb_devicetype_7.Location = new System.Drawing.Point(605, 15);
            this.cb_devicetype_7.Name = "cb_devicetype_7";
            this.cb_devicetype_7.Size = new System.Drawing.Size(157, 22);
            this.cb_devicetype_7.TabIndex = 243;
            // 
            // cb_controlid_7
            // 
            this.cb_controlid_7.Enabled = false;
            this.cb_controlid_7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_controlid_7.FormattingEnabled = true;
            this.cb_controlid_7.Location = new System.Drawing.Point(380, 15);
            this.cb_controlid_7.Name = "cb_controlid_7";
            this.cb_controlid_7.Size = new System.Drawing.Size(60, 22);
            this.cb_controlid_7.TabIndex = 240;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(333, 19);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 241;
            this.label5.Text = "设备号";
            // 
            // cb_baud_7
            // 
            this.cb_baud_7.Enabled = false;
            this.cb_baud_7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_baud_7.FormattingEnabled = true;
            this.cb_baud_7.Location = new System.Drawing.Point(231, 16);
            this.cb_baud_7.Name = "cb_baud_7";
            this.cb_baud_7.Size = new System.Drawing.Size(80, 22);
            this.cb_baud_7.TabIndex = 236;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label37.Location = new System.Drawing.Point(184, 20);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(49, 14);
            this.label37.TabIndex = 237;
            this.label37.Text = "波特率";
            // 
            // cb_port_7
            // 
            this.cb_port_7.Enabled = false;
            this.cb_port_7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_port_7.FormattingEnabled = true;
            this.cb_port_7.Location = new System.Drawing.Point(88, 16);
            this.cb_port_7.Name = "cb_port_7";
            this.cb_port_7.Size = new System.Drawing.Size(80, 22);
            this.cb_port_7.TabIndex = 234;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label38.Location = new System.Drawing.Point(55, 20);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(35, 14);
            this.label38.TabIndex = 235;
            this.label38.Text = "端口";
            // 
            // grpFixReader
            // 
            this.grpFixReader.Controls.Add(this.label27);
            this.grpFixReader.Controls.Add(this.cb_devicetype_5);
            this.grpFixReader.Controls.Add(this.chk_inuse_5);
            this.grpFixReader.Controls.Add(this.cb_controlid_5);
            this.grpFixReader.Controls.Add(this.label28);
            this.grpFixReader.Controls.Add(this.cb_usetype_5);
            this.grpFixReader.Controls.Add(this.label29);
            this.grpFixReader.Controls.Add(this.cb_baud_5);
            this.grpFixReader.Controls.Add(this.label30);
            this.grpFixReader.Controls.Add(this.cb_port_5);
            this.grpFixReader.Controls.Add(this.label31);
            this.grpFixReader.Controls.Add(this.label22);
            this.grpFixReader.Controls.Add(this.cb_devicetype_4);
            this.grpFixReader.Controls.Add(this.chk_inuse_4);
            this.grpFixReader.Controls.Add(this.cb_controlid_4);
            this.grpFixReader.Controls.Add(this.label23);
            this.grpFixReader.Controls.Add(this.cb_usetype_4);
            this.grpFixReader.Controls.Add(this.label24);
            this.grpFixReader.Controls.Add(this.cb_baud_4);
            this.grpFixReader.Controls.Add(this.label25);
            this.grpFixReader.Controls.Add(this.cb_port_4);
            this.grpFixReader.Controls.Add(this.label26);
            this.grpFixReader.Controls.Add(this.label13);
            this.grpFixReader.Controls.Add(this.cb_devicetype_3);
            this.grpFixReader.Controls.Add(this.chk_inuse_3);
            this.grpFixReader.Controls.Add(this.cb_controlid_3);
            this.grpFixReader.Controls.Add(this.label14);
            this.grpFixReader.Controls.Add(this.cb_usetype_3);
            this.grpFixReader.Controls.Add(this.label15);
            this.grpFixReader.Controls.Add(this.cb_baud_3);
            this.grpFixReader.Controls.Add(this.label16);
            this.grpFixReader.Controls.Add(this.cb_port_3);
            this.grpFixReader.Controls.Add(this.label17);
            this.grpFixReader.Controls.Add(this.label32);
            this.grpFixReader.Controls.Add(this.label2);
            this.grpFixReader.Controls.Add(this.cb_devicetype_6);
            this.grpFixReader.Controls.Add(this.cb_devicetype_2);
            this.grpFixReader.Controls.Add(this.chk_inuse_6);
            this.grpFixReader.Controls.Add(this.chk_inuse_2);
            this.grpFixReader.Controls.Add(this.cb_controlid_6);
            this.grpFixReader.Controls.Add(this.cb_controlid_2);
            this.grpFixReader.Controls.Add(this.label33);
            this.grpFixReader.Controls.Add(this.label3);
            this.grpFixReader.Controls.Add(this.cb_usetype_6);
            this.grpFixReader.Controls.Add(this.cb_usetype_2);
            this.grpFixReader.Controls.Add(this.label34);
            this.grpFixReader.Controls.Add(this.label10);
            this.grpFixReader.Controls.Add(this.cb_baud_6);
            this.grpFixReader.Controls.Add(this.cb_baud_2);
            this.grpFixReader.Controls.Add(this.label35);
            this.grpFixReader.Controls.Add(this.label11);
            this.grpFixReader.Controls.Add(this.cb_port_6);
            this.grpFixReader.Controls.Add(this.label36);
            this.grpFixReader.Controls.Add(this.cb_port_2);
            this.grpFixReader.Controls.Add(this.label12);
            this.grpFixReader.Controls.Add(this.label21);
            this.grpFixReader.Controls.Add(this.cb_devicetype_1);
            this.grpFixReader.Controls.Add(this.chk_inuse_1);
            this.grpFixReader.Controls.Add(this.cb_controlid_1);
            this.grpFixReader.Controls.Add(this.label20);
            this.grpFixReader.Controls.Add(this.cb_usetype_1);
            this.grpFixReader.Controls.Add(this.label19);
            this.grpFixReader.Controls.Add(this.cb_baud_1);
            this.grpFixReader.Controls.Add(this.label1);
            this.grpFixReader.Controls.Add(this.cb_port_1);
            this.grpFixReader.Controls.Add(this.label6);
            this.grpFixReader.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFixReader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpFixReader.Location = new System.Drawing.Point(0, 12);
            this.grpFixReader.Name = "grpFixReader";
            this.grpFixReader.Size = new System.Drawing.Size(899, 200);
            this.grpFixReader.TabIndex = 5;
            this.grpFixReader.TabStop = false;
            this.grpFixReader.Text = "读卡器";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(460, 140);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(35, 14);
            this.label27.TabIndex = 222;
            this.label27.Text = "类型";
            // 
            // cb_devicetype_5
            // 
            this.cb_devicetype_5.Enabled = false;
            this.cb_devicetype_5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_devicetype_5.FormattingEnabled = true;
            this.cb_devicetype_5.Location = new System.Drawing.Point(498, 136);
            this.cb_devicetype_5.Name = "cb_devicetype_5";
            this.cb_devicetype_5.Size = new System.Drawing.Size(141, 22);
            this.cb_devicetype_5.TabIndex = 221;
            // 
            // chk_inuse_5
            // 
            this.chk_inuse_5.AutoSize = true;
            this.chk_inuse_5.Location = new System.Drawing.Point(813, 138);
            this.chk_inuse_5.Name = "chk_inuse_5";
            this.chk_inuse_5.Size = new System.Drawing.Size(54, 18);
            this.chk_inuse_5.TabIndex = 220;
            this.chk_inuse_5.Text = "使用";
            this.chk_inuse_5.UseVisualStyleBackColor = true;
            // 
            // cb_controlid_5
            // 
            this.cb_controlid_5.Enabled = false;
            this.cb_controlid_5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_controlid_5.FormattingEnabled = true;
            this.cb_controlid_5.Location = new System.Drawing.Point(380, 137);
            this.cb_controlid_5.Name = "cb_controlid_5";
            this.cb_controlid_5.Size = new System.Drawing.Size(60, 22);
            this.cb_controlid_5.TabIndex = 218;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.Location = new System.Drawing.Point(333, 141);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(49, 14);
            this.label28.TabIndex = 219;
            this.label28.Text = "设备号";
            // 
            // cb_usetype_5
            // 
            this.cb_usetype_5.Enabled = false;
            this.cb_usetype_5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_usetype_5.FormattingEnabled = true;
            this.cb_usetype_5.Items.AddRange(new object[] {
            "室内",
            "室外进门",
            "室外出门"});
            this.cb_usetype_5.Location = new System.Drawing.Point(694, 136);
            this.cb_usetype_5.Name = "cb_usetype_5";
            this.cb_usetype_5.Size = new System.Drawing.Size(96, 22);
            this.cb_usetype_5.TabIndex = 217;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.Location = new System.Drawing.Point(652, 140);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(35, 14);
            this.label29.TabIndex = 216;
            this.label29.Text = "用途";
            // 
            // cb_baud_5
            // 
            this.cb_baud_5.Enabled = false;
            this.cb_baud_5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_baud_5.FormattingEnabled = true;
            this.cb_baud_5.Location = new System.Drawing.Point(231, 135);
            this.cb_baud_5.Name = "cb_baud_5";
            this.cb_baud_5.Size = new System.Drawing.Size(80, 22);
            this.cb_baud_5.TabIndex = 214;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(184, 139);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(49, 14);
            this.label30.TabIndex = 215;
            this.label30.Text = "波特率";
            // 
            // cb_port_5
            // 
            this.cb_port_5.Enabled = false;
            this.cb_port_5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_port_5.FormattingEnabled = true;
            this.cb_port_5.Location = new System.Drawing.Point(88, 136);
            this.cb_port_5.Name = "cb_port_5";
            this.cb_port_5.Size = new System.Drawing.Size(80, 22);
            this.cb_port_5.TabIndex = 212;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.Location = new System.Drawing.Point(55, 140);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(35, 14);
            this.label31.TabIndex = 213;
            this.label31.Text = "端口";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(460, 112);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 14);
            this.label22.TabIndex = 211;
            this.label22.Text = "类型";
            // 
            // cb_devicetype_4
            // 
            this.cb_devicetype_4.Enabled = false;
            this.cb_devicetype_4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_devicetype_4.FormattingEnabled = true;
            this.cb_devicetype_4.Location = new System.Drawing.Point(498, 108);
            this.cb_devicetype_4.Name = "cb_devicetype_4";
            this.cb_devicetype_4.Size = new System.Drawing.Size(141, 22);
            this.cb_devicetype_4.TabIndex = 210;
            // 
            // chk_inuse_4
            // 
            this.chk_inuse_4.AutoSize = true;
            this.chk_inuse_4.Location = new System.Drawing.Point(813, 110);
            this.chk_inuse_4.Name = "chk_inuse_4";
            this.chk_inuse_4.Size = new System.Drawing.Size(54, 18);
            this.chk_inuse_4.TabIndex = 209;
            this.chk_inuse_4.Text = "使用";
            this.chk_inuse_4.UseVisualStyleBackColor = true;
            // 
            // cb_controlid_4
            // 
            this.cb_controlid_4.Enabled = false;
            this.cb_controlid_4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_controlid_4.FormattingEnabled = true;
            this.cb_controlid_4.Location = new System.Drawing.Point(380, 109);
            this.cb_controlid_4.Name = "cb_controlid_4";
            this.cb_controlid_4.Size = new System.Drawing.Size(60, 22);
            this.cb_controlid_4.TabIndex = 207;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(333, 113);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(49, 14);
            this.label23.TabIndex = 208;
            this.label23.Text = "设备号";
            // 
            // cb_usetype_4
            // 
            this.cb_usetype_4.Enabled = false;
            this.cb_usetype_4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_usetype_4.FormattingEnabled = true;
            this.cb_usetype_4.Items.AddRange(new object[] {
            "室内",
            "室外进门",
            "室外出门"});
            this.cb_usetype_4.Location = new System.Drawing.Point(694, 108);
            this.cb_usetype_4.Name = "cb_usetype_4";
            this.cb_usetype_4.Size = new System.Drawing.Size(96, 22);
            this.cb_usetype_4.TabIndex = 206;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(652, 112);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(35, 14);
            this.label24.TabIndex = 205;
            this.label24.Text = "用途";
            // 
            // cb_baud_4
            // 
            this.cb_baud_4.Enabled = false;
            this.cb_baud_4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_baud_4.FormattingEnabled = true;
            this.cb_baud_4.Location = new System.Drawing.Point(231, 107);
            this.cb_baud_4.Name = "cb_baud_4";
            this.cb_baud_4.Size = new System.Drawing.Size(80, 22);
            this.cb_baud_4.TabIndex = 203;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(184, 111);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(49, 14);
            this.label25.TabIndex = 204;
            this.label25.Text = "波特率";
            // 
            // cb_port_4
            // 
            this.cb_port_4.Enabled = false;
            this.cb_port_4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_port_4.FormattingEnabled = true;
            this.cb_port_4.Location = new System.Drawing.Point(88, 108);
            this.cb_port_4.Name = "cb_port_4";
            this.cb_port_4.Size = new System.Drawing.Size(80, 22);
            this.cb_port_4.TabIndex = 201;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(55, 112);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(35, 14);
            this.label26.TabIndex = 202;
            this.label26.Text = "端口";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(460, 84);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 14);
            this.label13.TabIndex = 200;
            this.label13.Text = "类型";
            // 
            // cb_devicetype_3
            // 
            this.cb_devicetype_3.Enabled = false;
            this.cb_devicetype_3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_devicetype_3.FormattingEnabled = true;
            this.cb_devicetype_3.Location = new System.Drawing.Point(498, 80);
            this.cb_devicetype_3.Name = "cb_devicetype_3";
            this.cb_devicetype_3.Size = new System.Drawing.Size(141, 22);
            this.cb_devicetype_3.TabIndex = 199;
            // 
            // chk_inuse_3
            // 
            this.chk_inuse_3.AutoSize = true;
            this.chk_inuse_3.Location = new System.Drawing.Point(813, 82);
            this.chk_inuse_3.Name = "chk_inuse_3";
            this.chk_inuse_3.Size = new System.Drawing.Size(54, 18);
            this.chk_inuse_3.TabIndex = 198;
            this.chk_inuse_3.Text = "使用";
            this.chk_inuse_3.UseVisualStyleBackColor = true;
            // 
            // cb_controlid_3
            // 
            this.cb_controlid_3.Enabled = false;
            this.cb_controlid_3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_controlid_3.FormattingEnabled = true;
            this.cb_controlid_3.Location = new System.Drawing.Point(380, 81);
            this.cb_controlid_3.Name = "cb_controlid_3";
            this.cb_controlid_3.Size = new System.Drawing.Size(60, 22);
            this.cb_controlid_3.TabIndex = 196;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(333, 85);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 14);
            this.label14.TabIndex = 197;
            this.label14.Text = "设备号";
            // 
            // cb_usetype_3
            // 
            this.cb_usetype_3.Enabled = false;
            this.cb_usetype_3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_usetype_3.FormattingEnabled = true;
            this.cb_usetype_3.Items.AddRange(new object[] {
            "室内",
            "室外进门",
            "室外出门"});
            this.cb_usetype_3.Location = new System.Drawing.Point(694, 80);
            this.cb_usetype_3.Name = "cb_usetype_3";
            this.cb_usetype_3.Size = new System.Drawing.Size(96, 22);
            this.cb_usetype_3.TabIndex = 195;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(652, 84);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 14);
            this.label15.TabIndex = 194;
            this.label15.Text = "用途";
            // 
            // cb_baud_3
            // 
            this.cb_baud_3.Enabled = false;
            this.cb_baud_3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_baud_3.FormattingEnabled = true;
            this.cb_baud_3.Location = new System.Drawing.Point(231, 79);
            this.cb_baud_3.Name = "cb_baud_3";
            this.cb_baud_3.Size = new System.Drawing.Size(80, 22);
            this.cb_baud_3.TabIndex = 192;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(184, 83);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 14);
            this.label16.TabIndex = 193;
            this.label16.Text = "波特率";
            // 
            // cb_port_3
            // 
            this.cb_port_3.Enabled = false;
            this.cb_port_3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_port_3.FormattingEnabled = true;
            this.cb_port_3.Location = new System.Drawing.Point(88, 80);
            this.cb_port_3.Name = "cb_port_3";
            this.cb_port_3.Size = new System.Drawing.Size(80, 22);
            this.cb_port_3.TabIndex = 190;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(55, 84);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 14);
            this.label17.TabIndex = 191;
            this.label17.Text = "端口";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.Location = new System.Drawing.Point(460, 168);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(35, 14);
            this.label32.TabIndex = 233;
            this.label32.Text = "类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(460, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 189;
            this.label2.Text = "类型";
            // 
            // cb_devicetype_6
            // 
            this.cb_devicetype_6.Enabled = false;
            this.cb_devicetype_6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_devicetype_6.FormattingEnabled = true;
            this.cb_devicetype_6.Location = new System.Drawing.Point(498, 164);
            this.cb_devicetype_6.Name = "cb_devicetype_6";
            this.cb_devicetype_6.Size = new System.Drawing.Size(141, 22);
            this.cb_devicetype_6.TabIndex = 232;
            // 
            // cb_devicetype_2
            // 
            this.cb_devicetype_2.Enabled = false;
            this.cb_devicetype_2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_devicetype_2.FormattingEnabled = true;
            this.cb_devicetype_2.Location = new System.Drawing.Point(498, 52);
            this.cb_devicetype_2.Name = "cb_devicetype_2";
            this.cb_devicetype_2.Size = new System.Drawing.Size(141, 22);
            this.cb_devicetype_2.TabIndex = 188;
            // 
            // chk_inuse_6
            // 
            this.chk_inuse_6.AutoSize = true;
            this.chk_inuse_6.Location = new System.Drawing.Point(813, 166);
            this.chk_inuse_6.Name = "chk_inuse_6";
            this.chk_inuse_6.Size = new System.Drawing.Size(54, 18);
            this.chk_inuse_6.TabIndex = 231;
            this.chk_inuse_6.Text = "使用";
            this.chk_inuse_6.UseVisualStyleBackColor = true;
            // 
            // chk_inuse_2
            // 
            this.chk_inuse_2.AutoSize = true;
            this.chk_inuse_2.Location = new System.Drawing.Point(813, 54);
            this.chk_inuse_2.Name = "chk_inuse_2";
            this.chk_inuse_2.Size = new System.Drawing.Size(54, 18);
            this.chk_inuse_2.TabIndex = 187;
            this.chk_inuse_2.Text = "使用";
            this.chk_inuse_2.UseVisualStyleBackColor = true;
            // 
            // cb_controlid_6
            // 
            this.cb_controlid_6.Enabled = false;
            this.cb_controlid_6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_controlid_6.FormattingEnabled = true;
            this.cb_controlid_6.Location = new System.Drawing.Point(380, 165);
            this.cb_controlid_6.Name = "cb_controlid_6";
            this.cb_controlid_6.Size = new System.Drawing.Size(60, 22);
            this.cb_controlid_6.TabIndex = 229;
            // 
            // cb_controlid_2
            // 
            this.cb_controlid_2.Enabled = false;
            this.cb_controlid_2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_controlid_2.FormattingEnabled = true;
            this.cb_controlid_2.Location = new System.Drawing.Point(380, 53);
            this.cb_controlid_2.Name = "cb_controlid_2";
            this.cb_controlid_2.Size = new System.Drawing.Size(60, 22);
            this.cb_controlid_2.TabIndex = 185;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.Location = new System.Drawing.Point(333, 169);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(49, 14);
            this.label33.TabIndex = 230;
            this.label33.Text = "设备号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(333, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 186;
            this.label3.Text = "设备号";
            // 
            // cb_usetype_6
            // 
            this.cb_usetype_6.Enabled = false;
            this.cb_usetype_6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_usetype_6.FormattingEnabled = true;
            this.cb_usetype_6.Items.AddRange(new object[] {
            "室内",
            "室外进门",
            "室外出门"});
            this.cb_usetype_6.Location = new System.Drawing.Point(694, 164);
            this.cb_usetype_6.Name = "cb_usetype_6";
            this.cb_usetype_6.Size = new System.Drawing.Size(96, 22);
            this.cb_usetype_6.TabIndex = 228;
            // 
            // cb_usetype_2
            // 
            this.cb_usetype_2.Enabled = false;
            this.cb_usetype_2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_usetype_2.FormattingEnabled = true;
            this.cb_usetype_2.Items.AddRange(new object[] {
            "室内",
            "室外进门",
            "室外出门"});
            this.cb_usetype_2.Location = new System.Drawing.Point(694, 52);
            this.cb_usetype_2.Name = "cb_usetype_2";
            this.cb_usetype_2.Size = new System.Drawing.Size(96, 22);
            this.cb_usetype_2.TabIndex = 184;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label34.Location = new System.Drawing.Point(652, 168);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(35, 14);
            this.label34.TabIndex = 227;
            this.label34.Text = "用途";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(652, 56);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 14);
            this.label10.TabIndex = 183;
            this.label10.Text = "用途";
            // 
            // cb_baud_6
            // 
            this.cb_baud_6.Enabled = false;
            this.cb_baud_6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_baud_6.FormattingEnabled = true;
            this.cb_baud_6.Location = new System.Drawing.Point(231, 163);
            this.cb_baud_6.Name = "cb_baud_6";
            this.cb_baud_6.Size = new System.Drawing.Size(80, 22);
            this.cb_baud_6.TabIndex = 225;
            // 
            // cb_baud_2
            // 
            this.cb_baud_2.Enabled = false;
            this.cb_baud_2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_baud_2.FormattingEnabled = true;
            this.cb_baud_2.Location = new System.Drawing.Point(231, 51);
            this.cb_baud_2.Name = "cb_baud_2";
            this.cb_baud_2.Size = new System.Drawing.Size(80, 22);
            this.cb_baud_2.TabIndex = 181;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(184, 167);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(49, 14);
            this.label35.TabIndex = 226;
            this.label35.Text = "波特率";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(184, 55);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 14);
            this.label11.TabIndex = 182;
            this.label11.Text = "波特率";
            // 
            // cb_port_6
            // 
            this.cb_port_6.Enabled = false;
            this.cb_port_6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_port_6.FormattingEnabled = true;
            this.cb_port_6.Location = new System.Drawing.Point(88, 164);
            this.cb_port_6.Name = "cb_port_6";
            this.cb_port_6.Size = new System.Drawing.Size(80, 22);
            this.cb_port_6.TabIndex = 223;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label36.Location = new System.Drawing.Point(55, 168);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(35, 14);
            this.label36.TabIndex = 224;
            this.label36.Text = "端口";
            // 
            // cb_port_2
            // 
            this.cb_port_2.Enabled = false;
            this.cb_port_2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_port_2.FormattingEnabled = true;
            this.cb_port_2.Location = new System.Drawing.Point(88, 52);
            this.cb_port_2.Name = "cb_port_2";
            this.cb_port_2.Size = new System.Drawing.Size(80, 22);
            this.cb_port_2.TabIndex = 179;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(55, 56);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 14);
            this.label12.TabIndex = 180;
            this.label12.Text = "端口";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(460, 28);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 14);
            this.label21.TabIndex = 178;
            this.label21.Text = "类型";
            // 
            // cb_devicetype_1
            // 
            this.cb_devicetype_1.Enabled = false;
            this.cb_devicetype_1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_devicetype_1.FormattingEnabled = true;
            this.cb_devicetype_1.Location = new System.Drawing.Point(498, 24);
            this.cb_devicetype_1.Name = "cb_devicetype_1";
            this.cb_devicetype_1.Size = new System.Drawing.Size(141, 22);
            this.cb_devicetype_1.TabIndex = 177;
            // 
            // chk_inuse_1
            // 
            this.chk_inuse_1.AutoSize = true;
            this.chk_inuse_1.Location = new System.Drawing.Point(813, 26);
            this.chk_inuse_1.Name = "chk_inuse_1";
            this.chk_inuse_1.Size = new System.Drawing.Size(54, 18);
            this.chk_inuse_1.TabIndex = 176;
            this.chk_inuse_1.Text = "使用";
            this.chk_inuse_1.UseVisualStyleBackColor = true;
            // 
            // cb_controlid_1
            // 
            this.cb_controlid_1.Enabled = false;
            this.cb_controlid_1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_controlid_1.FormattingEnabled = true;
            this.cb_controlid_1.Location = new System.Drawing.Point(380, 25);
            this.cb_controlid_1.Name = "cb_controlid_1";
            this.cb_controlid_1.Size = new System.Drawing.Size(60, 22);
            this.cb_controlid_1.TabIndex = 174;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(333, 29);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 14);
            this.label20.TabIndex = 175;
            this.label20.Text = "设备号";
            // 
            // cb_usetype_1
            // 
            this.cb_usetype_1.Enabled = false;
            this.cb_usetype_1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_usetype_1.FormattingEnabled = true;
            this.cb_usetype_1.Items.AddRange(new object[] {
            "室内",
            "室外进门",
            "室外出门"});
            this.cb_usetype_1.Location = new System.Drawing.Point(694, 24);
            this.cb_usetype_1.Name = "cb_usetype_1";
            this.cb_usetype_1.Size = new System.Drawing.Size(96, 22);
            this.cb_usetype_1.TabIndex = 172;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(652, 28);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 14);
            this.label19.TabIndex = 171;
            this.label19.Text = "用途";
            // 
            // cb_baud_1
            // 
            this.cb_baud_1.Enabled = false;
            this.cb_baud_1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_baud_1.FormattingEnabled = true;
            this.cb_baud_1.Location = new System.Drawing.Point(231, 23);
            this.cb_baud_1.Name = "cb_baud_1";
            this.cb_baud_1.Size = new System.Drawing.Size(80, 22);
            this.cb_baud_1.TabIndex = 162;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(184, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 163;
            this.label1.Text = "波特率";
            // 
            // cb_port_1
            // 
            this.cb_port_1.Enabled = false;
            this.cb_port_1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_port_1.FormattingEnabled = true;
            this.cb_port_1.Location = new System.Drawing.Point(88, 24);
            this.cb_port_1.Name = "cb_port_1";
            this.cb_port_1.Size = new System.Drawing.Size(80, 22);
            this.cb_port_1.TabIndex = 160;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(55, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 161;
            this.label6.Text = "端口";
            // 
            // UC_DeviceManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UC_DeviceManage";
            this.Size = new System.Drawing.Size(901, 624);
            this.Load += new System.EventHandler(this.UC_DeviceManage_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.检验设备参数.ResumeLayout(false);
            this.检验设备参数.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.grpRoadBrake1.ResumeLayout(false);
            this.grpRoadBrake1.PerformLayout();
            this.grpFixReader.ResumeLayout(false);
            this.grpFixReader.PerformLayout();
            this.ResumeLayout(false);

        }

        private void LoadPara()
        {
            for (int i = 0; i < 6; i++)
            {
                DeviceInfo deviceInfo = DeviceConfigManager.Instance.GetDeviceInfo(i);
                cb_port[i, 0].Text = deviceInfo.Port;
                cb_port[i, 1].Text = deviceInfo.Baudrate.ToString();
                cb_port[i, 2].Text = deviceInfo.ControlId.ToString();
                cb_port[i, 3].Text = deviceInfo.DeviceType;
                cb_port[i, 4].Text = deviceInfo.UseType;
                chk_inuse[i].Checked = deviceInfo.InUse;
                deviceInfo.FuncType = "CardReader";
            }
            DeviceInfo inDoorDevice = DeviceConfigManager.Instance.GetDeviceInfo(6);
            inDoorDevice.FuncType = "RoadBrake";
            cb_port_7.Text = inDoorDevice.Port;
            cb_baud_7.Text = inDoorDevice.Baudrate.ToString();
            cb_controlid_7.Text = inDoorDevice.ControlId.ToString();
            cb_addr_7.Text = inDoorDevice.Addr.ToString();
            cb_devicetype_7.Text = inDoorDevice.DeviceType;
            inDoorDevice.UseType = "进门";
            chk_inuse_7.Checked = inDoorDevice.InUse;

            DeviceInfo outDoorDevice = DeviceConfigManager.Instance.GetDeviceInfo(7);
            outDoorDevice.FuncType = "RoadBrake";
            cb_port_8.Text = outDoorDevice.Port;
            cb_baud_8.Text = outDoorDevice.Baudrate.ToString();
            cb_controlid_8.Text = outDoorDevice.ControlId.ToString();
            cb_addr_8.Text = outDoorDevice.Addr.ToString();
            cb_devicetype_8.Text = outDoorDevice.DeviceType;
            outDoorDevice.UseType = "出门";
            chk_inuse_8.Checked = inDoorDevice.InUse;

            cb_sendcount.Text = DeviceConfigManager.Instance.config.SyrisKZCount.ToString();
            cb_sj.Text = DeviceConfigManager.Instance.config.SyrisKZTime.ToString();
            cb_jg.Text = DeviceConfigManager.Instance.config.SyrisKZInterval.ToString();
            jysb.Text = DeviceConfigManager.Instance.config.Jysb;
            jysbsjk.Text = DeviceConfigManager.Instance.config.Jysbsjk;
            this.rdOriginal.Checked = DeviceConfigManager.Instance.config.PrintType == 0;
            this.rdNew.Checked = !this.rdOriginal.Checked;
        }
        
        private ComboBox[,] cb_port = null;
        private CheckBox[] chk_inuse = null;

        private void UC_DeviceManage_Load(object sender, EventArgs e)
        {
            cb_port = new ComboBox[,]{
                 {cb_port_1,cb_baud_1,cb_controlid_1,cb_devicetype_1,cb_usetype_1}
                ,{cb_port_2,cb_baud_2,cb_controlid_2,cb_devicetype_2,cb_usetype_2}
                ,{cb_port_3,cb_baud_3,cb_controlid_3,cb_devicetype_3,cb_usetype_3}
                ,{cb_port_4,cb_baud_4,cb_controlid_4,cb_devicetype_4,cb_usetype_4}
                ,{cb_port_5,cb_baud_5,cb_controlid_5,cb_devicetype_5,cb_usetype_5}
                ,{cb_port_6,cb_baud_6,cb_controlid_6,cb_devicetype_6,cb_usetype_6}
                 ,{cb_port_7,cb_baud_7,cb_controlid_7,cb_devicetype_7,cb_addr_7}
                  ,{cb_port_8,cb_baud_8,cb_controlid_8,cb_devicetype_8,cb_addr_8}
            };
            chk_inuse = new CheckBox[] { chk_inuse_1, chk_inuse_2, chk_inuse_3, chk_inuse_4, chk_inuse_5, chk_inuse_6, chk_inuse_7, chk_inuse_8 };

            foreach (var item in chk_inuse)
            {
                item.CheckedChanged += item_CheckedChanged;
            }

            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            string[] baudrates = new string[] { "4800", "7200", "9600", "14400", "19200", "38400", "57600", "115200", "128000" };

            for (int i = 0; i < cb_port.GetLength(0); i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    cb_port[i, j].Items.Clear();
                }
                cb_port[i, 0].Items.AddRange(ports);
                cb_port[i, 0].SelectedIndex = cb_port_1.Items.Count > 0 ? 0 : -1;
                cb_port[i, 1].Items.AddRange(baudrates);
                cb_port[i, 1].Text = "9600";

                for (int num = 1; num < 0x10; num++)
                {
                    cb_port[i, 2].Items.Add(num.ToString());
                    cb_port[i, 2].Text = "1";
                }
            }

            for (int i = 0; i < cb_port.GetLength(0) - 2; i++)
            {
                cb_port[i, 3].Items.Add("固定读卡器");
                cb_port[i, 3].Items.Add("移动读卡器");
                cb_port[i, 3].Items.Add("道闸读卡器");
                cb_port[i, 3].Items.Add("玺瑞道闸读卡器");
                cb_port[i, 3].Items.Add("玺瑞独立读卡器");
                cb_port[i, 3].Text = "固定读卡器";

                cb_port[i, 4].Items.Add("室内");
                cb_port[i, 4].Items.Add("进门");
                cb_port[i, 4].Items.Add("出门");
                cb_port[i, 4].Text = "室内";
            }

            for (int i = 1; i <=4; i++)
            {
                cb_addr_7.Items.Add(i);
                cb_addr_8.Items.Add(i);
            }
            cb_devicetype_7.Items.Add("原有道闸控制器");
            cb_devicetype_7.Items.Add("玺瑞道闸控制器");
            cb_devicetype_8.Items.Add("原有道闸控制器");
            cb_devicetype_8.Items.Add("玺瑞道闸控制器");

            LoadPara();

        }

        void item_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chk_inuse.Length; i++)
            {
                if (chk_inuse[i] == (CheckBox)sender)
                {
                    for (int j = 0; j < cb_port.GetLength(1); j++)
                    {
                        cb_port[i, j].Enabled = chk_inuse[i].Checked;
                    }
                }
            }
        }

        public void HandleCardMessage(CardReader device, string cardId)
        {
            if (!chk_test.Checked) return;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(device.PortDeviceType.ToString());
            sb.AppendLine("端口: COM" + device.Portid);
            sb.AppendLine("波特率: " + device.Baudrate);
            sb.AppendLine("设备号: " + device.Controlid);
            sb.AppendLine("用途: " + device.UseType.ToString());
            sb.AppendLine("CardID:" + cardId);
            sb.AppendLine("时间:" + DateTime.Now.ToString());
            testInfo.Text = sb.ToString();

            if (chk_test_roadbrake.Checked)
            {
                if (device.UseType == CardReaderUseType.出门)
                {
                    DeviceManager.Instance.OutDoor();
                }
                else if (device.UseType == CardReaderUseType.进门)
                {
                    DeviceManager.Instance.InDoor();
                }
                else if (device.UseType == CardReaderUseType.室内)
                {
                    DeviceManager.Instance.InDoor();
                    DeviceManager.Instance.OutDoor();
                }
            }
        }

        private void chk_test_CheckedChanged(object sender, EventArgs e)
        {
            chk_test_roadbrake.Visible = chk_test.Checked;
            testInfo.Visible = chk_test.Checked;
        }

    }

}

