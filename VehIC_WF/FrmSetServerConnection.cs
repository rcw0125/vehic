namespace VehIC_WF
{
    using Sunisoft.IrisSkin;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using VehIC_WF.CommonService;
    using VehIC_WF.Utility;

    public class FrmSetServerConnection : Form
    {
        private Button btnTest;
        private Button btnOK;
        private IContainer components = null;
        private Label label3;
        private SkinEngine skinEngine1;
        private Button button1;
        private TextBox textBox1;

        public FrmSetServerConnection()
        {
            this.InitializeComponent();
            base.DialogResult = DialogResult.Cancel;
            this.skinEngine1.SkinFile = "MP10.ssk";
            this.textBox1.Text = "192.168.2.33";
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string addressString = this.textBox1.Text.Trim();
            if (addressString != "")
            {
                if (!(!(addressString != "localhost:1263") || Common.IPAddressCheck(addressString)))
                {
                    MessageBox.Show("IP地址不合法！");
                }
                else
                {
                    string str2 = Test(addressString);
                    if ((str2 == string.Empty) || (str2 == null))
                    {
                        MessageBox.Show("连接失败！");
                    }
                    else
                    {
                        MessageBox.Show("连接成功！\r\n" + str2);
                        Regedit.Save("Server", "WebService", addressString);
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string addressString = this.textBox1.Text.Trim();
            if (addressString != "")
            {
                if (!(!(addressString != "localhost:1263") || Common.IPAddressCheck(addressString)))
                {
                    MessageBox.Show("IP地址不合法！");
                }
                else
                {
                    Regedit.Save("Server", "WebService", addressString);
                    string str2 = Test(addressString);
                    if ((str2 == string.Empty) || (str2 == null))
                    {
                        MessageBox.Show("连接失败！退出登录！");
                        base.Close();
                    }
                    else
                    {
                        Regedit.Save("Server", "WebService", addressString);
                        base.DialogResult = DialogResult.OK;
                        base.Close();
                    }
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(77, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(269, 26);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "192.168.27.232";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "服务器地址";
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTest.Location = new System.Drawing.Point(108, 147);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(89, 30);
            this.btnTest.TabIndex = 10;
            this.btnTest.Text = "测试连接";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(224, 147);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(89, 30);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "确定保存";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // skinEngine1
            // 
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(326, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 30);
            this.button1.TabIndex = 12;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmSetServerConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 220);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmSetServerConnection";
            this.Text = "设置应用服务器地址";
            this.Load += new System.EventHandler(this.FrmSetServerConnection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public static string Test(string serveraddr)
        {
            try
            {
                VehIC_WF.CommonService.CommonService service = new VehIC_WF.CommonService.CommonService();
                service.Url = "http://" + serveraddr + "/VehIC_WS/CommonService.asmx";
                return ("服务器时间" + service.Test());
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        private void FrmSetServerConnection_Load(object sender, EventArgs e)
        {
           textBox1.Text= Regedit.Read("Server", "WebService");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

