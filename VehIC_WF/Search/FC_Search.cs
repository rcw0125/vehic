namespace VehIC_WF.Search
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FC_Search : UserControl
    {
        private CheckBox chbox_fixveh;
        private IContainer components = null;
        public FC_Search_RFFYD CP_FYD = new FC_Search_RFFYD();
        public FC_Search_Task CP_Task = new FC_Search_Task();
        private GroupBox groupBox3;
        private Label label2;
        private Label label25;
        private Label label4;
        private LabelWithDivider labelWithDivider1;
        private ListBox listBox1;
        private Panel panel1;
        private Panel panel2;
        private RadioButton rb_rffyd;
        private RadioButton rb_task;
        private TextBox textBox1;
        private TextBox txt_icnno;
        private TextBox txt_vehno;

        public FC_Search()
        {
            this.InitializeComponent();
            this.CP_FYD.Dock = DockStyle.Fill;
            this.CP_Task.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(this.CP_FYD);
            this.panel2.Controls.Add(this.CP_Task);
            this.CP_Task.BringToFront();
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
            this.panel1 = new Panel();
            this.panel2 = new Panel();
            this.listBox1 = new ListBox();
            this.chbox_fixveh = new CheckBox();
            this.txt_vehno = new TextBox();
            this.label25 = new Label();
            this.label2 = new Label();
            this.txt_icnno = new TextBox();
            this.label4 = new Label();
            this.textBox1 = new TextBox();
            this.groupBox3 = new GroupBox();
            this.rb_rffyd = new RadioButton();
            this.rb_task = new RadioButton();
            this.labelWithDivider1 = new LabelWithDivider();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            base.SuspendLayout();
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.chbox_fixveh);
            this.panel1.Controls.Add(this.txt_vehno);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_icnno);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labelWithDivider1);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x3fc, 0x41);
            this.panel1.TabIndex = 0xe4;
            this.panel2.Dock = DockStyle.Fill;
            this.panel2.Location = new Point(0, 0x41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x3fc, 0x1ff);
            this.panel2.TabIndex = 0xe5;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new Point(510, 0x26);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBox1.Size = new Size(0x90, 14);
            this.listBox1.TabIndex = 0xeb;
            this.listBox1.Visible = false;
            this.chbox_fixveh.AutoSize = true;
            this.chbox_fixveh.Enabled = false;
            this.chbox_fixveh.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.chbox_fixveh.Location = new Point(0x387, 0x10);
            this.chbox_fixveh.Name = "chbox_fixveh";
            this.chbox_fixveh.Size = new Size(0x5f, 20);
            this.chbox_fixveh.TabIndex = 0xec;
            this.chbox_fixveh.Text = "固定车辆";
            this.chbox_fixveh.UseVisualStyleBackColor = true;
            this.txt_vehno.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.txt_vehno.Location = new Point(510, 15);
            this.txt_vehno.Margin = new Padding(4);
            this.txt_vehno.Name = "txt_vehno";
            this.txt_vehno.Size = new Size(0x90, 0x17);
            this.txt_vehno.TabIndex = 0xe8;
            this.txt_vehno.TextAlign = HorizontalAlignment.Right;
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.label25.Location = new Point(680, 0x13);
            this.label25.Margin = new Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new Size(0x25, 14);
            this.label25.TabIndex = 0xe9;
            this.label25.Text = "车型";
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.label2.Location = new Point(0x1d0, 0x13);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x34, 14);
            this.label2.TabIndex = 0xe7;
            this.label2.Text = "车牌号";
            this.txt_icnno.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_icnno.Location = new Point(0x130, 15);
            this.txt_icnno.Margin = new Padding(4);
            this.txt_icnno.Name = "txt_icnno";
            this.txt_icnno.ReadOnly = true;
            this.txt_icnno.Size = new Size(0x90, 0x17);
            this.txt_icnno.TabIndex = 230;
            this.txt_icnno.TextAlign = HorizontalAlignment.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.label4.Location = new Point(0xff, 0x13);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x35, 14);
            this.label4.TabIndex = 0xe5;
            this.label4.Text = "IC卡号";
            this.textBox1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.textBox1.Location = new Point(0x2ca, 15);
            this.textBox1.Margin = new Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new Size(0x90, 0x17);
            this.textBox1.TabIndex = 0xed;
            this.textBox1.TextAlign = HorizontalAlignment.Right;
            this.groupBox3.Controls.Add(this.rb_rffyd);
            this.groupBox3.Controls.Add(this.rb_task);
            this.groupBox3.Location = new Point(0x12, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0xcc, 40);
            this.groupBox3.TabIndex = 0xee;
            this.groupBox3.TabStop = false;
            this.rb_rffyd.AutoSize = true;
            this.rb_rffyd.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.rb_rffyd.Location = new Point(0x62, 14);
            this.rb_rffyd.Name = "rb_rffyd";
            this.rb_rffyd.Size = new Size(90, 20);
            this.rb_rffyd.TabIndex = 0xaf;
            this.rb_rffyd.Text = "RF发运单";
            this.rb_rffyd.UseVisualStyleBackColor = true;
            this.rb_rffyd.CheckedChanged += new EventHandler(this.rb_rffyd_CheckedChanged);
            this.rb_task.AutoSize = true;
            this.rb_task.Checked = true;
            this.rb_task.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.rb_task.Location = new Point(0x12, 14);
            this.rb_task.Name = "rb_task";
            this.rb_task.Size = new Size(0x4a, 20);
            this.rb_task.TabIndex = 0xae;
            this.rb_task.TabStop = true;
            this.rb_task.Text = "作业单";
            this.rb_task.UseVisualStyleBackColor = true;
            this.labelWithDivider1.Dock = DockStyle.Bottom;
            this.labelWithDivider1.Location = new Point(0, 0x37);
            this.labelWithDivider1.Name = "labelWithDivider1";
            this.labelWithDivider1.Size = new Size(0x3fc, 10);
            this.labelWithDivider1.TabIndex = 0xe4;
            this.labelWithDivider1.TextAlign = ContentAlignment.TopCenter;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.panel2);
            base.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            base.Name = "FC_Search";
            base.Size = new Size(0x3fc, 0x240);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            base.ResumeLayout(false);
        }

        private void rb_rffyd_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rb_rffyd.Checked)
            {
                this.CP_FYD.BringToFront();
            }
            else
            {
                this.CP_Task.BringToFront();
            }
        }
    }
}

