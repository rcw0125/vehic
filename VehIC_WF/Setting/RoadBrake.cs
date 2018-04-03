namespace VehIC_WF.Setting
{
    using LFY.Windows.Controls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class RoadBrake : UserControl
    {
        private BevelLine bevelLine2;
        private Button btn_scale_close;
        private Button btn_scale_open;
        private Button btn_scale_save;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private IContainer components = null;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private RichTextBox textBoxR;

        public RoadBrake()
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
            this.groupBox1 = new GroupBox();
            this.comboBox1 = new ComboBox();
            this.label1 = new Label();
            this.comboBox2 = new ComboBox();
            this.label2 = new Label();
            this.groupBox2 = new GroupBox();
            this.comboBox3 = new ComboBox();
            this.label3 = new Label();
            this.comboBox4 = new ComboBox();
            this.label4 = new Label();
            this.textBoxR = new RichTextBox();
            this.btn_scale_close = new Button();
            this.btn_scale_open = new Button();
            this.btn_scale_save = new Button();
            this.bevelLine2 = new BevelLine();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.groupBox1.Location = new Point(0x1c, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xd8, 0x6b);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "进门道闸";
            this.comboBox1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new Point(0x60, 0x41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(0x60, 0x16);
            this.comboBox1.TabIndex = 0xac;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label1.Location = new Point(0x31, 0x45);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x31, 14);
            this.label1.TabIndex = 0xad;
            this.label1.Text = "设备号";
            this.comboBox2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new Point(0x60, 30);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new Size(0x60, 0x16);
            this.comboBox2.TabIndex = 170;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label2.Location = new Point(0x3f, 0x21);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x23, 14);
            this.label2.TabIndex = 0xab;
            this.label2.Text = "端口";
            this.groupBox2.Controls.Add(this.comboBox3);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBox4);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.groupBox2.Location = new Point(0x13d, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0xd8, 0x6b);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "出门道闸";
            this.comboBox3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new Point(0x60, 0x41);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new Size(0x60, 0x16);
            this.comboBox3.TabIndex = 0xac;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label3.Location = new Point(0x31, 0x45);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x31, 14);
            this.label3.TabIndex = 0xad;
            this.label3.Text = "设备号";
            this.comboBox4.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new Point(0x60, 30);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new Size(0x60, 0x16);
            this.comboBox4.TabIndex = 170;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label4.Location = new Point(0x3f, 0x21);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x23, 14);
            this.label4.TabIndex = 0xab;
            this.label4.Text = "端口";
            this.textBoxR.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.textBoxR.BackColor = Color.LightGray;
            this.textBoxR.DetectUrls = false;
            this.textBoxR.Font = new System.Drawing.Font("Courier New", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.textBoxR.HideSelection = false;
            this.textBoxR.Location = new Point(0x1c, 0x90);
            this.textBoxR.Name = "textBoxR";
            this.textBoxR.ReadOnly = true;
            this.textBoxR.ShowSelectionMargin = true;
            this.textBoxR.Size = new Size(0x1f8, 0xfc);
            this.textBoxR.TabIndex = 14;
            this.textBoxR.Text = "";
            this.btn_scale_close.Location = new Point(0x1b7, 0x19d);
            this.btn_scale_close.Name = "btn_scale_close";
            this.btn_scale_close.Size = new Size(0x5e, 0x25);
            this.btn_scale_close.TabIndex = 0xcc;
            this.btn_scale_close.Text = "关闭";
            this.btn_scale_close.UseVisualStyleBackColor = true;
            this.btn_scale_open.Location = new Point(0x129, 0x19d);
            this.btn_scale_open.Name = "btn_scale_open";
            this.btn_scale_open.Size = new Size(0x5e, 0x25);
            this.btn_scale_open.TabIndex = 0xcb;
            this.btn_scale_open.Text = "打开";
            this.btn_scale_open.UseVisualStyleBackColor = true;
            this.btn_scale_save.Location = new Point(0x1c, 0x19d);
            this.btn_scale_save.Name = "btn_scale_save";
            this.btn_scale_save.Size = new Size(0x5e, 0x25);
            this.btn_scale_save.TabIndex = 0xca;
            this.btn_scale_save.Text = "保存设置";
            this.btn_scale_save.UseVisualStyleBackColor = true;
            this.bevelLine2.Angle = 90;
            this.bevelLine2.Location = new Point(0x1c, 0x88);
            this.bevelLine2.Name = "bevelLine2";
            this.bevelLine2.Size = new Size(0x1f8, 2);
            this.bevelLine2.TabIndex = 10;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.btn_scale_close);
            base.Controls.Add(this.btn_scale_open);
            base.Controls.Add(this.btn_scale_save);
            base.Controls.Add(this.textBoxR);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.bevelLine2);
            this.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            base.Name = "RoadBrake";
            base.Size = new Size(0x236, 0x1d1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            base.ResumeLayout(false);
        }

        private void InvokeFunction(string s, int t)
        {
            switch (t)
            {
                case 1:
                    this.textBoxR.AppendText(s);
                    this.textBoxR.AppendText("\r\n");
                    break;

                case 2:
                    this.textBoxR.AppendText(s);
                    break;

                case 3:
                {
                    Color selectionColor = this.textBoxR.SelectionColor;
                    this.textBoxR.SelectionColor = Color.Green;
                    this.textBoxR.AppendText("\r\n" + s + "\r\n");
                    this.textBoxR.SelectionColor = selectionColor;
                    break;
                }
            }
        }
    }
}

