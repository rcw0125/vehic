namespace VehIC_WF.Setting
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ICReader : UserControl
    {
        private ComboBox cb_fix;
        private ComboBox cb_fixreader_baud;
        private ComboBox cb_moblie;
        private ComboBox cb_moblie_baud;
        private IContainer components = null;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label6;

        public ICReader()
        {
            this.InitializeComponent();
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
            this.groupBox2 = new GroupBox();
            this.cb_moblie_baud = new ComboBox();
            this.label2 = new Label();
            this.cb_moblie = new ComboBox();
            this.label3 = new Label();
            this.groupBox1 = new GroupBox();
            this.cb_fixreader_baud = new ComboBox();
            this.label1 = new Label();
            this.cb_fix = new ComboBox();
            this.label6 = new Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.groupBox2.Controls.Add(this.cb_moblie_baud);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cb_moblie);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.groupBox2.Location = new Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x236, 0x40);
            this.groupBox2.TabIndex = 0x94;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "移动读卡器";
            this.cb_moblie_baud.Enabled = false;
            this.cb_moblie_baud.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.cb_moblie_baud.FormattingEnabled = true;
            this.cb_moblie_baud.Location = new Point(0x150, 0x16);
            this.cb_moblie_baud.Name = "cb_moblie_baud";
            this.cb_moblie_baud.Size = new Size(0x60, 0x16);
            this.cb_moblie_baud.TabIndex = 0xa7;
            this.cb_moblie_baud.Text = "9600";
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label2.Location = new Point(0x121, 0x1a);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x31, 14);
            this.label2.TabIndex = 0xa8;
            this.label2.Text = "波特率";
            this.cb_moblie.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.cb_moblie.FormattingEnabled = true;
            this.cb_moblie.Location = new Point(170, 0x16);
            this.cb_moblie.Name = "cb_moblie";
            this.cb_moblie.Size = new Size(0x60, 0x16);
            this.cb_moblie.TabIndex = 0xa5;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label3.Location = new Point(0x89, 0x19);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x23, 14);
            this.label3.TabIndex = 0xa6;
            this.label3.Text = "端口";
            this.groupBox1.Controls.Add(this.cb_fixreader_baud);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cb_fix);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Dock = DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.groupBox1.Location = new Point(0, 0x40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x236, 0x3e);
            this.groupBox1.TabIndex = 0x95;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "固定读卡器";
            this.cb_fixreader_baud.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.cb_fixreader_baud.FormattingEnabled = true;
            this.cb_fixreader_baud.Location = new Point(0x150, 0x16);
            this.cb_fixreader_baud.Name = "cb_fixreader_baud";
            this.cb_fixreader_baud.Size = new Size(0x60, 0x16);
            this.cb_fixreader_baud.TabIndex = 0xa2;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label1.Location = new Point(0x121, 0x1a);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x31, 14);
            this.label1.TabIndex = 0xa3;
            this.label1.Text = "波特率";
            this.cb_fix.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.cb_fix.FormattingEnabled = true;
            this.cb_fix.Location = new Point(170, 0x16);
            this.cb_fix.Name = "cb_fix";
            this.cb_fix.Size = new Size(0x60, 0x16);
            this.cb_fix.TabIndex = 160;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label6.Location = new Point(0x89, 0x19);
            this.label6.Margin = new Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x23, 14);
            this.label6.TabIndex = 0xa1;
            this.label6.Text = "端口";
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            base.Name = "ICReader";
            base.Size = new Size(0x236, 0x1d1);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }
    }
}

