namespace VehIC_WF.BaseData
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.Windows.Forms;
    using VehIC_WF;
    using VehIC_WF.ScaleService;

    public class FrmMaterial : Form
    {
        private Button btn_delete;
        private Button btn_new;
        private Button btn_newsave;
        private Button btn_search;
        private Button btn_update;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private IContainer components = null;
        public Material curmt;
        private DataGridView dataGridView1;
        private GroupBox groupBox4;
        private Label label1;
        private Label label11;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        public Material[] mts;
        private Panel pa;
        private Panel panel2;
        public VehIC_WF.ScaleService.ScaleService SCALE;
        private TextBox txt_code;
        private TextBox txt_edit_code;
        private TextBox txt_edit_ID;
        private TextBox txt_edit_material;
        private TextBox txt_edit_remark;
        private TextBox txt_material;

        public FrmMaterial()
        {
            this.InitializeComponent();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (this.curmt != null)
            {
                int num2;
                int index = -1;
                for (num2 = 0; num2 < this.mts.Length; num2++)
                {
                    if (this.mts[num2].Code == this.curmt.Code)
                    {
                        index = num2;
                        break;
                    }
                }
                if (index != -1)
                {
                    try
                    {
                        string str = this.SCALE.TurnOver_MaterialDelete(this.curmt);
                        if (str != "OK")
                        {
                            MessageBox.Show("服务器数据处理异常！\r\n" + str);
                        }
                        else
                        {
                            this.dataGridView1.Rows.RemoveAt(index);
                            if (this.mts.Length == 1)
                            {
                                this.mts = null;
                            }
                            else
                            {
                                Material[] materialArray = new Material[this.mts.Length - 1];
                                for (num2 = 0; num2 < (this.mts.Length - 1); num2++)
                                {
                                    if (num2 < index)
                                    {
                                        materialArray[num2] = this.mts[num2];
                                    }
                                    else if (num2 > index)
                                    {
                                        materialArray[num2 - 1] = this.mts[num2];
                                    }
                                }
                                this.mts = materialArray;
                            }
                            this.curmt = null;
                            this.txt_edit_code.Text = string.Empty;
                            this.txt_edit_material.Text = string.Empty;
                            this.txt_edit_remark.Text = string.Empty;
                            this.txt_edit_ID.Text = string.Empty;
                            this.btn_newsave.Enabled = true;
                            this.btn_update.Enabled = false;
                            this.btn_delete.Enabled = false;
                            MessageBox.Show("删除成功！");
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.ToString());
                    }
                }
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            this.txt_edit_code.Text = string.Empty;
            this.txt_edit_material.Text = string.Empty;
            this.txt_edit_remark.Text = string.Empty;
            this.txt_edit_ID.Text = string.Empty;
            this.btn_newsave.Enabled = true;
            this.btn_update.Enabled = false;
            this.btn_delete.Enabled = false;
        }

        private void btn_newsave_Click(object sender, EventArgs e)
        {
            string name = this.txt_edit_material.Text.Trim();
            string bm = this.txt_edit_code.Text.Trim();
            string remark = this.txt_edit_remark.Text.Trim();
            if (name == string.Empty)
            {
                MessageBox.Show("名称不能为空！");
            }
            else
            {
                try
                {
                    string str4 = this.SCALE.TurnOver_NewMaterialSave(name, bm, remark);
                    if (str4 != "OK")
                    {
                        MessageBox.Show("服务器数据处理异常！\r\n" + str4);
                    }
                    else
                    {
                        MessageBox.Show("保存成功！");
                        this.txt_edit_code.Text = string.Empty;
                        this.txt_edit_material.Text = string.Empty;
                        this.txt_edit_remark.Text = string.Empty;
                        this.txt_edit_ID.Text = string.Empty;
                        this.btn_newsave.Enabled = false;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            this.mts = this.SCALE.TurnOver_MaterialSearch(this.txt_material.Text.Trim(), this.txt_code.Text.Trim());
            if (this.mts != null)
            {
                for (int i = 0; i < this.mts.Length; i++)
                {
                    int num2 = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[num2].Cells[0].Value = this.mts[i].Code.ToString();
                    this.dataGridView1.Rows[num2].Cells[1].Value = this.mts[i].BM;
                    this.dataGridView1.Rows[num2].Cells[2].Value = this.mts[i].Name;
                    this.dataGridView1.Rows[num2].Cells[3].Value = this.mts[i].Remark;
                }
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (this.curmt != null)
            {
                string newbm = this.txt_edit_code.Text.Trim();
                string name = this.txt_edit_material.Text.Trim();
                string remark = this.txt_edit_remark.Text.Trim();
                if (name == string.Empty)
                {
                    MessageBox.Show("名称不能为空！");
                }
                else if ((name == this.curmt.Name) && (remark == this.curmt.Remark))
                {
                    MessageBox.Show("没有内容变化，保存无效！");
                }
                else
                {
                    try
                    {
                        string str4 = this.SCALE.TurnOver_MaterialUpdate(this.curmt, name, newbm, remark);
                        if (str4 != "OK")
                        {
                            MessageBox.Show("服务器数据处理异常！\r\n" + str4);
                        }
                        else
                        {
                            MessageBox.Show("保存成功！");
                            this.curmt.BM = newbm;
                            this.curmt.Name = name;
                            this.curmt.Remark = remark;
                            this.UpdateGridView();
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.ToString());
                    }
                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                this.curmt = this.mts[this.dataGridView1.SelectedRows[0].Index];
                this.txt_edit_ID.Text = this.curmt.Code.ToString();
                this.txt_edit_code.Text = this.curmt.BM;
                this.txt_edit_material.Text = this.curmt.Name;
                this.txt_edit_remark.Text = this.curmt.Remark;
                this.btn_update.Enabled = true;
                this.btn_delete.Enabled = true;
                this.btn_newsave.Enabled = false;
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

        private void FrmMaterial_Load(object sender, EventArgs e)
        {
            this.btn_delete.Enabled = this.btn_update.Enabled = this.btn_newsave.Enabled = false;
            this.SCALE = new VehIC_WF.ScaleService.ScaleService();
            this.SCALE.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/ScaleService.asmx";
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            DataGridViewCellStyle style4 = new DataGridViewCellStyle();
            DataGridViewCellStyle style5 = new DataGridViewCellStyle();
            this.pa = new Panel();
            this.txt_edit_ID = new TextBox();
            this.label5 = new Label();
            this.btn_new = new Button();
            this.btn_newsave = new Button();
            this.btn_update = new Button();
            this.txt_edit_remark = new TextBox();
            this.label4 = new Label();
            this.txt_edit_material = new TextBox();
            this.label3 = new Label();
            this.txt_edit_code = new TextBox();
            this.label2 = new Label();
            this.panel2 = new Panel();
            this.dataGridView1 = new DataGridView();
            this.Column1 = new DataGridViewTextBoxColumn();
            this.Column2 = new DataGridViewTextBoxColumn();
            this.Column3 = new DataGridViewTextBoxColumn();
            this.Column4 = new DataGridViewTextBoxColumn();
            this.groupBox4 = new GroupBox();
            this.txt_code = new TextBox();
            this.label1 = new Label();
            this.txt_material = new TextBox();
            this.label11 = new Label();
            this.btn_search = new Button();
            this.btn_delete = new Button();
            this.pa.SuspendLayout();
            this.panel2.SuspendLayout();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            this.groupBox4.SuspendLayout();
            base.SuspendLayout();
            this.pa.Controls.Add(this.btn_delete);
            this.pa.Controls.Add(this.txt_edit_ID);
            this.pa.Controls.Add(this.label5);
            this.pa.Controls.Add(this.btn_new);
            this.pa.Controls.Add(this.btn_newsave);
            this.pa.Controls.Add(this.btn_update);
            this.pa.Controls.Add(this.txt_edit_remark);
            this.pa.Controls.Add(this.label4);
            this.pa.Controls.Add(this.txt_edit_material);
            this.pa.Controls.Add(this.label3);
            this.pa.Controls.Add(this.txt_edit_code);
            this.pa.Controls.Add(this.label2);
            this.pa.Dock = DockStyle.Right;
            this.pa.Location = new Point(0x21f, 0);
            this.pa.Margin = new Padding(4);
            this.pa.Name = "pa";
            this.pa.Size = new Size(0x123, 0x1f2);
            this.pa.TabIndex = 0xb5;
            this.txt_edit_ID.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.txt_edit_ID.Location = new Point(0x4e, 0x24);
            this.txt_edit_ID.Margin = new Padding(4);
            this.txt_edit_ID.Name = "txt_edit_ID";
            this.txt_edit_ID.ReadOnly = true;
            this.txt_edit_ID.Size = new Size(180, 0x17);
            this.txt_edit_ID.TabIndex = 0xcb;
            this.txt_edit_ID.TextAlign = HorizontalAlignment.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label5.Location = new Point(0x2d, 40);
            this.label5.Margin = new Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x15, 14);
            this.label5.TabIndex = 0xca;
            this.label5.Text = "ID";
            this.btn_new.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btn_new.Location = new Point(0x4e, 0xf5);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new Size(0x9d, 0x26);
            this.btn_new.TabIndex = 0xc9;
            this.btn_new.Text = "新增";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new EventHandler(this.btn_new_Click);
            this.btn_newsave.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btn_newsave.Location = new Point(0x4e, 0x121);
            this.btn_newsave.Name = "btn_newsave";
            this.btn_newsave.Size = new Size(0x9d, 0x26);
            this.btn_newsave.TabIndex = 200;
            this.btn_newsave.Text = "新增保存";
            this.btn_newsave.UseVisualStyleBackColor = true;
            this.btn_newsave.Click += new EventHandler(this.btn_newsave_Click);
            this.btn_update.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btn_update.Location = new Point(0x4e, 0x165);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new Size(0x9d, 0x26);
            this.btn_update.TabIndex = 0xc7;
            this.btn_update.Text = "修改保存";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new EventHandler(this.btn_update_Click);
            this.txt_edit_remark.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.txt_edit_remark.Location = new Point(0x4e, 0xa4);
            this.txt_edit_remark.Margin = new Padding(4);
            this.txt_edit_remark.Multiline = true;
            this.txt_edit_remark.Name = "txt_edit_remark";
            this.txt_edit_remark.Size = new Size(180, 0x3f);
            this.txt_edit_remark.TabIndex = 0xc6;
            this.txt_edit_remark.TextAlign = HorizontalAlignment.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label4.Location = new Point(0x2d, 0xa9);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x23, 14);
            this.label4.TabIndex = 0xc5;
            this.label4.Text = "说明";
            this.txt_edit_material.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.txt_edit_material.Location = new Point(0x4e, 0x77);
            this.txt_edit_material.Margin = new Padding(4);
            this.txt_edit_material.Name = "txt_edit_material";
            this.txt_edit_material.Size = new Size(180, 0x17);
            this.txt_edit_material.TabIndex = 0xc4;
            this.txt_edit_material.TextAlign = HorizontalAlignment.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label3.Location = new Point(0x11, 0x7c);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x3f, 14);
            this.label3.TabIndex = 0xc3;
            this.label3.Text = "物资名称";
            this.txt_edit_code.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.txt_edit_code.Location = new Point(0x4e, 0x48);
            this.txt_edit_code.Margin = new Padding(4);
            this.txt_edit_code.Name = "txt_edit_code";
            this.txt_edit_code.Size = new Size(180, 0x17);
            this.txt_edit_code.TabIndex = 0xc2;
            this.txt_edit_code.TextAlign = HorizontalAlignment.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label2.Location = new Point(0x2d, 0x4c);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x23, 14);
            this.label2.TabIndex = 0xc1;
            this.label2.Text = "编码";
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Dock = DockStyle.Fill;
            this.panel2.Location = new Point(0, 0);
            this.panel2.Margin = new Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x21f, 0x1f2);
            this.panel2.TabIndex = 0xb6;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            style.BackColor = SystemColors.Info;
            style.FormatProvider = new CultureInfo("en-US");
            this.dataGridView1.AlternatingRowsDefaultCellStyle = style;
            style2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style2.BackColor = SystemColors.Control;
            style2.Font = new System.Drawing.Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            style2.ForeColor = SystemColors.WindowText;
            style2.SelectionBackColor = SystemColors.Highlight;
            style2.SelectionForeColor = SystemColors.HighlightText;
            style2.WrapMode = DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = style2;
            this.dataGridView1.ColumnHeadersHeight = 0x19;
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { this.Column1, this.Column2, this.Column3, this.Column4 });
            style3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style3.BackColor = SystemColors.Window;
            style3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            style3.ForeColor = SystemColors.ControlText;
            style3.FormatProvider = new CultureInfo("en-US");
            style3.SelectionBackColor = SystemColors.Control;
            style3.SelectionForeColor = SystemColors.ControlText;
            style3.WrapMode = DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = style3;
            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.GridColor = Color.PaleGoldenrod;
            this.dataGridView1.Location = new Point(0, 0x3b);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            style4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style4.BackColor = SystemColors.Control;
            style4.Font = new System.Drawing.Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            style4.ForeColor = SystemColors.WindowText;
            style4.SelectionBackColor = SystemColors.Highlight;
            style4.SelectionForeColor = SystemColors.HighlightText;
            style4.WrapMode = DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = style4;
            this.dataGridView1.RowHeadersWidth = 10;
            this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            style5.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.dataGridView1.RowsDefaultCellStyle = style5;
            this.dataGridView1.RowTemplate.Height = 20;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(0x21f, 0x1b7);
            this.dataGridView1.TabIndex = 0xbd;
            this.dataGridView1.Text = "dataGridView1";
            this.dataGridView1.DoubleClick += new EventHandler(this.dataGridView1_DoubleClick);
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            this.Column2.HeaderText = "编码";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 0x6f;
            this.Column3.HeaderText = "物资名称";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 260;
            this.Column4.HeaderText = "说明";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.groupBox4.Controls.Add(this.txt_code);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txt_material);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.btn_search);
            this.groupBox4.Dock = DockStyle.Top;
            this.groupBox4.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.groupBox4.Location = new Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(0x21f, 0x3b);
            this.groupBox4.TabIndex = 0xbc;
            this.groupBox4.TabStop = false;
            this.txt_code.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.txt_code.Location = new Point(0x37, 0x16);
            this.txt_code.Margin = new Padding(4);
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new Size(0x63, 0x17);
            this.txt_code.TabIndex = 0xc0;
            this.txt_code.TextAlign = HorizontalAlignment.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label1.Location = new Point(0x16, 0x1a);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x23, 14);
            this.label1.TabIndex = 0xbf;
            this.label1.Text = "编码";
            this.txt_material.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.txt_material.Location = new Point(230, 0x16);
            this.txt_material.Margin = new Padding(4);
            this.txt_material.Name = "txt_material";
            this.txt_material.Size = new Size(0x86, 0x17);
            this.txt_material.TabIndex = 190;
            this.txt_material.TextAlign = HorizontalAlignment.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label11.Location = new Point(0xa8, 0x1b);
            this.label11.Margin = new Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x3f, 14);
            this.label11.TabIndex = 0xbd;
            this.label11.Text = "物资名称";
            this.btn_search.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btn_search.Location = new Point(0x189, 0x13);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new Size(0x66, 0x1d);
            this.btn_search.TabIndex = 0xbc;
            this.btn_search.Text = "查询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new EventHandler(this.btn_search_Click);
            this.btn_delete.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btn_delete.Location = new Point(0x4e, 0x191);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new Size(0x9d, 0x26);
            this.btn_delete.TabIndex = 0xcc;
            this.btn_delete.Text = "删除";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new EventHandler(this.btn_delete_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x342, 0x1f2);
            base.Controls.Add(this.panel2);
            base.Controls.Add(this.pa);
            base.Name = "FrmMaterial";
            this.Text = "FrmMaterial";
            base.Load += new EventHandler(this.FrmMaterial_Load);
            this.pa.ResumeLayout(false);
            this.pa.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            base.ResumeLayout(false);
        }

        private void UpdateGridView()
        {
            int num = -1;
            for (int i = 0; i < this.mts.Length; i++)
            {
                if (this.mts[i].Code == this.curmt.Code)
                {
                    num = i;
                    break;
                }
            }
            if (num != -1)
            {
                this.dataGridView1.Rows[num].Cells[1].Value = this.curmt.BM;
                this.dataGridView1.Rows[num].Cells[2].Value = this.curmt.Name;
                this.dataGridView1.Rows[num].Cells[3].Value = this.curmt.Remark;
            }
        }
    }
}

