namespace VehIC_WF.Setting
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using VehIC_WF.Properties;

    public class TaskItemView : UserControl
    {
        private Button btn_down;
        private Button btn_scale_save;
        private Button btn_up;
        private CheckBox checkBox1;
        private ColumnHeader columnHeader1;
        private IContainer components = null;
        private Label label1;
        private Label label12;
        private Label label2;
        private Label label3;
        private Label label4;
        private ListView listView1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox txt_billno;

        public TaskItemView()
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(TaskItemView));
            this.textBox3 = new TextBox();
            this.label3 = new Label();
            this.textBox2 = new TextBox();
            this.label2 = new Label();
            this.textBox1 = new TextBox();
            this.label1 = new Label();
            this.txt_billno = new TextBox();
            this.label12 = new Label();
            this.checkBox1 = new CheckBox();
            this.btn_down = new Button();
            this.btn_up = new Button();
            this.listView1 = new ListView();
            this.columnHeader1 = new ColumnHeader();
            this.btn_scale_save = new Button();
            this.textBox4 = new TextBox();
            this.label4 = new Label();
            base.SuspendLayout();
            this.textBox3.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox3.Location = new Point(0x3b, 0x48);
            this.textBox3.Margin = new Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new Size(0xbf, 0x1a);
            this.textBox3.TabIndex = 0xce;
            this.textBox3.TextAlign = HorizontalAlignment.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label3.Location = new Point(0x15, 0x4d);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(40, 0x10);
            this.label3.TabIndex = 0xcd;
            this.label3.Text = "序号";
            this.textBox2.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox2.Location = new Point(0x3b, 0x6f);
            this.textBox2.Margin = new Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new Size(0xbf, 0x1a);
            this.textBox2.TabIndex = 0xcc;
            this.textBox2.TextAlign = HorizontalAlignment.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label2.Location = new Point(0x15, 0x74);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(40, 0x10);
            this.label2.TabIndex = 0xcb;
            this.label2.Text = "名称";
            this.textBox1.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox1.Location = new Point(0x3b, 0xe9);
            this.textBox1.Margin = new Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0xbf, 0x61);
            this.textBox1.TabIndex = 0xca;
            this.textBox1.TextAlign = HorizontalAlignment.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label1.Location = new Point(0x15, 0xec);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(40, 0x10);
            this.label1.TabIndex = 0xc9;
            this.label1.Text = "描述";
            this.txt_billno.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_billno.Location = new Point(0x3b, 0x97);
            this.txt_billno.Margin = new Padding(4);
            this.txt_billno.Name = "txt_billno";
            this.txt_billno.Size = new Size(0xbf, 0x1a);
            this.txt_billno.TabIndex = 200;
            this.txt_billno.TextAlign = HorizontalAlignment.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label12.Location = new Point(0x15, 0x9b);
            this.label12.Margin = new Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new Size(40, 0x10);
            this.label12.TabIndex = 0xc7;
            this.label12.Text = "别名";
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.checkBox1.Location = new Point(0x3b, 0x27);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(0x3b, 20);
            this.checkBox1.TabIndex = 0xc6;
            this.checkBox1.Text = "显示";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.btn_down.Image = (Image)resources.GetObject("_2");
            this.btn_down.Location = new Point(0x111, 270);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new Size(40, 0x60);
            this.btn_down.TabIndex = 4;
            this.btn_down.UseVisualStyleBackColor = true;
            this.btn_up.Image = (Image)resources.GetObject("_1");
            this.btn_up.Location = new Point(0x111, 0x48);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new Size(40, 0x60);
            this.btn_up.TabIndex = 3;
            this.btn_up.UseVisualStyleBackColor = true;
            this.listView1.Columns.AddRange(new ColumnHeader[] { this.columnHeader1 });
            this.listView1.Dock = DockStyle.Right;
            this.listView1.Location = new Point(0x148, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new Size(0xee, 0x1d1);
            this.listView1.TabIndex = 0xd0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = View.Details;
            this.columnHeader1.Text = "字段名称";
            this.columnHeader1.Width = 180;
            this.btn_scale_save.Location = new Point(0x3b, 0x16c);
            this.btn_scale_save.Name = "btn_scale_save";
            this.btn_scale_save.Size = new Size(0x5e, 0x25);
            this.btn_scale_save.TabIndex = 0xff;
            this.btn_scale_save.Text = "保存设置";
            this.btn_scale_save.UseVisualStyleBackColor = true;
            this.textBox4.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox4.Location = new Point(0x3b, 190);
            this.textBox4.Margin = new Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Size(0xbf, 0x1a);
            this.textBox4.TabIndex = 0x101;
            this.textBox4.TextAlign = HorizontalAlignment.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label4.Location = new Point(0x15, 0xc2);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(40, 0x10);
            this.label4.TabIndex = 0x100;
            this.label4.Text = "列宽";
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.textBox4);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.btn_scale_save);
            base.Controls.Add(this.listView1);
            base.Controls.Add(this.textBox3);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.textBox2);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.txt_billno);
            base.Controls.Add(this.label12);
            base.Controls.Add(this.checkBox1);
            base.Controls.Add(this.btn_down);
            base.Controls.Add(this.btn_up);
            this.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            base.Name = "TaskItemView";
            base.Size = new Size(0x236, 0x1d1);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

