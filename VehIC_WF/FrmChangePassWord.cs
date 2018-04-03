namespace VehIC_WF
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using VehIC_WF.AuthService;

    public class FrmChangePassWord : Form
    {
        private Button btnCancel;
        private Button btnOK;
        private IContainer components = null;
        private Label label1;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;

        public FrmChangePassWord()
        {
            this.InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim() != FrmMain.localinfo.user.Pass)
            {
                MessageBox.Show("旧密码不对！");
                this.textBox1.Focus();
                this.textBox1.SelectAll();
            }
            else
            {
                this.textBox2.Focus();
                this.textBox2.SelectAll();
                if (this.textBox2.Text.Trim() == "")
                {
                    MessageBox.Show("新密码不能为空！");
                    this.textBox2.Focus();
                    this.textBox2.SelectAll();
                }
                else
                {
                    this.textBox3.Focus();
                    this.textBox3.SelectAll();
                    if (this.textBox2.Text.Trim() != this.textBox3.Text.Trim())
                    {
                        MessageBox.Show("新密码不一致！");
                        this.textBox3.Focus();
                        this.textBox3.SelectAll();
                    }
                    else
                    {
                        VehIC_WF.AuthService.AuthService service = new VehIC_WF.AuthService.AuthService();
                        service.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/AuthService.asmx";
                        if (service.ChangePassword(LocalInfo.Current.user.ID, this.textBox3.Text.Trim()) != 1)
                        {
                            MessageBox.Show("操作失败！请重试！");
                        }
                        else
                        {
                            MessageBox.Show("操作成功！");
                            FrmMain.localinfo.user.Pass = this.textBox2.Text.Trim();
                            base.Close();
                        }
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

        private void FrmChangePassWord_Load(object sender, EventArgs e)
        {
            this.textBox1.Focus();
        }

        private void InitializeComponent()
        {
            this.textBox2 = new TextBox();
            this.label4 = new Label();
            this.textBox1 = new TextBox();
            this.label3 = new Label();
            this.btnCancel = new Button();
            this.btnOK = new Button();
            this.textBox3 = new TextBox();
            this.label1 = new Label();
            base.SuspendLayout();
            this.textBox2.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox2.Location = new Point(0x7a, 0x59);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new Size(170, 0x1a);
            this.textBox2.TabIndex = 8;
            this.textBox2.KeyPress += new KeyPressEventHandler(this.textBox2_KeyPress);
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.Location = new Point(70, 0x5c);
            this.label4.Name = "label4";
            this.label4.Size = new Size(60, 0x19);
            this.label4.TabIndex = 12;
            this.label4.Text = "新密码";
            this.textBox1.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox1.Location = new Point(0x7a, 0x31);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new Size(170, 0x1a);
            this.textBox1.TabIndex = 7;
            this.textBox1.KeyPress += new KeyPressEventHandler(this.textBox1_KeyPress);
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(70, 0x35);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x43, 0x19);
            this.label3.TabIndex = 11;
            this.label3.Text = "旧密码";
            this.btnCancel.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btnCancel.Location = new Point(0x127, 0xb9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x59, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnOK.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btnOK.Location = new Point(190, 0xb9);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(0x59, 30);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this.textBox3.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox3.Location = new Point(0x7a, 0x84);
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '*';
            this.textBox3.Size = new Size(170, 0x1a);
            this.textBox3.TabIndex = 13;
            this.textBox3.KeyPress += new KeyPressEventHandler(this.textBox3_KeyPress);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(70, 0x87);
            this.label1.Name = "label1";
            this.label1.Size = new Size(60, 0x19);
            this.label1.TabIndex = 14;
            this.label1.Text = "新密码";
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x198, 0xf7);
            base.Controls.Add(this.textBox3);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.textBox2);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            base.Name = "FrmChangePassWord";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            base.Load += new EventHandler(this.FrmChangePassWord_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                if (this.textBox1.Text.Trim() != FrmMain.localinfo.user.Pass)
                {
                    MessageBox.Show("旧密码不对！");
                    this.textBox1.Focus();
                    this.textBox1.SelectAll();
                }
                else
                {
                    this.textBox2.Focus();
                    this.textBox2.SelectAll();
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                if (this.textBox2.Text.Trim() == "")
                {
                    MessageBox.Show("新密码不能为空！");
                    this.textBox2.Focus();
                    this.textBox2.SelectAll();
                }
                else
                {
                    this.textBox3.Focus();
                    this.textBox3.SelectAll();
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                if (this.textBox2.Text.Trim() != this.textBox3.Text.Trim())
                {
                    MessageBox.Show("新密码不一致！");
                    this.textBox3.Focus();
                    this.textBox3.SelectAll();
                }
                else
                {
                    this.btnOK.Focus();
                }
            }
        }
    }
}

