namespace VehIC_WF
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.Windows.Forms;
    using VehIC_WF.ICCardManageService;

    public class FrmBillTypeSelect : Form
    {
        public AvailableBillInfo[] ABIs = null;
        private Button button1;
        private Button button3;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private IContainer components = null;
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        public int Result = -1;

        public FrmBillTypeSelect(AvailableBillInfo[] abis)
        {
            this.InitializeComponent();
            for (int i = 0; i < abis.Length; i++)
            {
                int num2 = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[num2].Cells[0].Value = abis[i].TypeDesc;
                this.dataGridView1.Rows[num2].Cells[1].Value = abis[i].BillNum;
                string str = (abis[i].wzlx == 0) ? "入厂" : "出厂";
                if ((abis[i].Type == 0) && (abis[i].wzlx == 1))
                {
                    str = str + "[退货]";
                }
                if ((abis[i].Type == 2) && (abis[i].wzlx == 0))
                {
                    str = str + "[退货]";
                }
                this.dataGridView1.Rows[num2].Cells[2].Value = str;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((this.dataGridView1.SelectedRows.Count != 1) || (this.dataGridView1.SelectedRows.Count > 1))
            {
                MessageBox.Show("请选择一个分类！");
            }
            else
            {
                this.Result = this.dataGridView1.SelectedRows[0].Index;
                base.DialogResult = DialogResult.OK;
                base.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
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
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            this.groupBox1 = new GroupBox();
            this.dataGridView1 = new DataGridView();
            this.button3 = new Button();
            this.button1 = new Button();
            this.Column1 = new DataGridViewTextBoxColumn();
            this.Column2 = new DataGridViewTextBoxColumn();
            this.Column3 = new DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = DockStyle.Top;
            this.groupBox1.Location = new Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x1e2, 0xeb);
            this.groupBox1.TabIndex = 150;
            this.groupBox1.TabStop = false;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            style.BackColor = SystemColors.Info;
            style.FormatProvider = new CultureInfo("en-US");
            this.dataGridView1.AlternatingRowsDefaultCellStyle = style;
            this.dataGridView1.ColumnHeadersHeight = 0x19;
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { this.Column1, this.Column2, this.Column3 });
            style2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style2.BackColor = SystemColors.Window;
            style2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            style2.ForeColor = SystemColors.ControlText;
            style2.FormatProvider = new CultureInfo("en-US");
            style2.SelectionBackColor = SystemColors.Control;
            style2.SelectionForeColor = SystemColors.ControlText;
            style2.WrapMode = DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = style2;
            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.GridColor = Color.PaleGoldenrod;
            this.dataGridView1.Location = new Point(3, 0x11);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 10;
            this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            style3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.dataGridView1.RowsDefaultCellStyle = style3;
            this.dataGridView1.RowTemplate.Height = 20;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(0x1dc, 0xd7);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.Text = "dataGridView1";
            this.button3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.button3.Location = new Point(0x166, 0xfc);
            this.button3.Name = "button3";
            this.button3.Size = new Size(0x66, 30);
            this.button3.TabIndex = 0x95;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click);
            this.button1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.button1.Location = new Point(0xee, 0xfc);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x66, 30);
            this.button1.TabIndex = 0x94;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.Column1.HeaderText = "单据分类";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 130;
            this.Column2.HeaderText = "单据数/进厂通知单号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            this.Column3.HeaderText = "物资流向";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x1e2, 0x12e);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.button3);
            base.Controls.Add(this.button1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.Name = "FrmBillTypeSelect";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "可选的单据分类";
            this.groupBox1.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            base.ResumeLayout(false);
        }
    }
}

