namespace VehIC_WF
{
    using Sunisoft.IrisSkin;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using VehIC_Device;
    using VehIC_WF.CommonService;
    using VehIC_WF.Utility;

    public class FrmWorkPointRegistry : Form
    {
        private Button btnCancel;
        private Button btnOK;
        private ComboBox comboBox2;
        private ComboBox comboBox4;
        private IContainer components;
        private GroupBox groupBox1;
        private Label label10;
        private Label label2;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private bool sdwefdef;
        private SkinEngine skinEngine1;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private KeyValue workpoints;
        private KeyValue workpointtypes;
        private string wpcode;

        public FrmWorkPointRegistry()
        {
            this.workpointtypes = new KeyValue();
            this.workpoints = new KeyValue();
            this.sdwefdef = false;
            this.wpcode = string.Empty;
            this.components = null;
            this.InitializeComponent();
            this.skinEngine1.SkinFile = "MP10.ssk";
            base.DialogResult = DialogResult.Cancel;
        }

        public FrmWorkPointRegistry(bool flag)
        {
            this.workpointtypes = new KeyValue();
            this.workpoints = new KeyValue();
            this.sdwefdef = false;
            this.wpcode = string.Empty;
            this.components = null;
            this.InitializeComponent();
            this.sdwefdef = true;
            this.skinEngine1.SkinFile = "MP10.ssk";
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.textBox3.Text != "")
            {
                string text = this.textBox4.Text;
                string regcode = this.textBox5.Text;
                if (text == "")
                {
                    MessageBox.Show("IP地址无效！");
                }
                else
                {
                    if (regcode == "")
                    {
                        MessageBox.Show("注册码无效！");
                    }
                    if (this.wpcode == "")
                    {
                        MessageBox.Show("选择的作业点无效！");
                    }
                    VehIC_WF.CommonService.CommonService service = new VehIC_WF.CommonService.CommonService();
                    if (!FrmMain.Debug)
                    {
                        service.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/CommonService.asmx";
                    }
                    if (!service.WorkPointRegistry(this.wpcode, regcode, text))
                    {
                        MessageBox.Show("注册失败！请重试！");
                    }
                    else
                    {
                        MessageBox.Show("注册完毕！等待审核！");
                        if (!this.sdwefdef)
                        {
                            base.DialogResult = DialogResult.OK;
                            base.Close();
                        }
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = this.workpointtypes[this.comboBox2.SelectedIndex].Key;
            VehIC_WF.CommonService.CommonService service = new VehIC_WF.CommonService.CommonService();
            if (!FrmMain.Debug)
            {
                service.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/CommonService.asmx";
            }
            string[] distinctAvailableWorkPoint = service.GetDistinctAvailableWorkPoint(key);
            if (distinctAvailableWorkPoint != null)
            {
                int num;
                this.workpoints.Clear();
                this.comboBox4.Items.Clear();
                for (num = 0; num < distinctAvailableWorkPoint.Length; num++)
                {
                    this.workpoints.Add(new KeyValueItem(distinctAvailableWorkPoint[num]));
                }
                for (num = 0; num < distinctAvailableWorkPoint.Length; num++)
                {
                    this.comboBox4.Items.Add(this.workpoints[num].Value);
                }
                this.textBox3.Text = string.Empty;
                this.wpcode = string.Empty;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.wpcode = this.workpoints[this.comboBox4.SelectedIndex].Key;
            this.textBox3.Text = this.workpoints[this.comboBox4.SelectedIndex].ValueEx;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmWorkPointRegistry_Load(object sender, EventArgs e)
        {
            VehIC_WF.Device.HardwareInfo info = new VehIC_WF.Device.HardwareInfo();
            this.textBox4.Text = info.GetHostIPAddress();
            this.textBox5.Text = info.GetMacAddress();
            VehIC_WF.CommonService.CommonService service = new VehIC_WF.CommonService.CommonService();
            if (!FrmMain.Debug)
            {
                service.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/CommonService.asmx";
            }
            string[] distinctAvailableWorkPointType = service.GetDistinctAvailableWorkPointType();
            if (distinctAvailableWorkPointType != null)
            {
                int num;
                for (num = 0; num < distinctAvailableWorkPointType.Length; num++)
                {
                    this.workpointtypes.Add(new KeyValueItem(distinctAvailableWorkPointType[num]));
                }
                for (num = 0; num < distinctAvailableWorkPointType.Length; num++)
                {
                    this.comboBox2.Items.Add(this.workpointtypes[num].Value);
                }
            }
        }

        private void InitializeComponent()
        {
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(133, 144);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(146, 22);
            this.comboBox2.TabIndex = 167;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(58, 148);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 166;
            this.label6.Text = "作业点类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(57, 224);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 162;
            this.label2.Text = "做业点编码";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.Location = new System.Drawing.Point(133, 220);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(146, 23);
            this.textBox3.TabIndex = 171;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Info;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(473, 54);
            this.label7.TabIndex = 172;
            this.label7.Text = "  　作业点注册:\r\n\r\n        您可以先选择可用的作业点，然后点击注册按钮。";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 70);
            this.groupBox1.TabIndex = 173;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "本机信息";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox5.Location = new System.Drawing.Point(308, 29);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(146, 23);
            this.textBox5.TabIndex = 175;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(260, 32);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 14);
            this.label9.TabIndex = 174;
            this.label9.Text = "注册码";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox4.Location = new System.Drawing.Point(74, 29);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(136, 23);
            this.textBox4.TabIndex = 173;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(26, 32);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 172;
            this.label8.Text = "IP地址";
            // 
            // comboBox4
            // 
            this.comboBox4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(133, 183);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(146, 22);
            this.comboBox4.TabIndex = 175;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(57, 186);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 174;
            this.label10.Text = "作业点名称";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(350, 245);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 30);
            this.btnCancel.TabIndex = 178;
            this.btnCancel.Text = "退出";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(350, 191);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(89, 30);
            this.btnOK.TabIndex = 177;
            this.btnOK.Text = "注册";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // skinEngine1
            // 
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // FrmWorkPointRegistry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 305);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWorkPointRegistry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "作业点注册";
            this.Load += new System.EventHandler(this.FrmWorkPointRegistry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}

