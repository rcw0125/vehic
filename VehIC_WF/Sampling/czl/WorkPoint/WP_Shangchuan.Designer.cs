namespace VehIC_WF.WorkPoint
{
    partial class WP_Shangchuan
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.全选 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.查询 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.上传 = new System.Windows.Forms.Button();
            this.采集 = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.检验编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.检验值 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.检验时间 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.检验项目名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.检验项目编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.检验设备 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.机器编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.全选);
            this.splitContainer1.Panel1.Controls.Add(this.textBox2);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.查询);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.上传);
            this.splitContainer1.Panel1.Controls.Add(this.采集);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1024, 550);
            this.splitContainer1.SplitterDistance = 44;
            this.splitContainer1.TabIndex = 13;
            // 
            // 全选
            // 
            this.全选.Location = new System.Drawing.Point(805, 16);
            this.全选.Name = "全选";
            this.全选.Size = new System.Drawing.Size(75, 23);
            this.全选.TabIndex = 7;
            this.全选.Text = "全选";
            this.全选.UseVisualStyleBackColor = true;
            this.全选.Click += new System.EventHandler(this.全选_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(533, 18);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(484, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "至";
            // 
            // 查询
            // 
            this.查询.Location = new System.Drawing.Point(659, 15);
            this.查询.Name = "查询";
            this.查询.Size = new System.Drawing.Size(76, 26);
            this.查询.TabIndex = 4;
            this.查询.Text = "查询";
            this.查询.UseVisualStyleBackColor = true;
            this.查询.Click += new System.EventHandler(this.查询_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(363, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(282, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "检验单号";
            // 
            // 上传
            // 
            this.上传.Location = new System.Drawing.Point(131, 15);
            this.上传.Name = "上传";
            this.上传.Size = new System.Drawing.Size(76, 26);
            this.上传.TabIndex = 1;
            this.上传.Text = "上传";
            this.上传.UseVisualStyleBackColor = true;
            this.上传.Click += new System.EventHandler(this.上传_Click);
            // 
            // 采集
            // 
            this.采集.Location = new System.Drawing.Point(21, 15);
            this.采集.Name = "采集";
            this.采集.Size = new System.Drawing.Size(79, 26);
            this.采集.TabIndex = 0;
            this.采集.Text = "采集";
            this.采集.UseVisualStyleBackColor = true;
            this.采集.Click += new System.EventHandler(this.采集_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1024, 502);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.检验编码,
            this.检验值,
            this.检验时间,
            this.检验项目名称,
            this.检验项目编码,
            this.检验设备,
            this.机器编码});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "上传";
            this.gridColumn5.FieldName = "Shangchuan";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // 检验编码
            // 
            this.检验编码.Caption = "检验编码";
            this.检验编码.FieldName = "SampleName";
            this.检验编码.Name = "检验编码";
            this.检验编码.OptionsColumn.AllowEdit = false;
            this.检验编码.Visible = true;
            this.检验编码.VisibleIndex = 1;
            // 
            // 检验值
            // 
            this.检验值.Caption = "检验值";
            this.检验值.FieldName = "Value";
            this.检验值.Name = "检验值";
            this.检验值.OptionsColumn.AllowEdit = false;
            this.检验值.Visible = true;
            this.检验值.VisibleIndex = 2;
            // 
            // 检验时间
            // 
            this.检验时间.Caption = "检验时间";
            this.检验时间.FieldName = "Date";
            this.检验时间.Name = "检验时间";
            this.检验时间.OptionsColumn.AllowEdit = false;
            this.检验时间.Visible = true;
            this.检验时间.VisibleIndex = 3;
            // 
            // 检验项目名称
            // 
            this.检验项目名称.Caption = "检验项目名称";
            this.检验项目名称.FieldName = "CheckItemName";
            this.检验项目名称.Name = "检验项目名称";
            this.检验项目名称.OptionsColumn.AllowEdit = false;
            this.检验项目名称.Visible = true;
            this.检验项目名称.VisibleIndex = 4;
            // 
            // 检验项目编码
            // 
            this.检验项目编码.Caption = "检验项目编码";
            this.检验项目编码.FieldName = "CheckItemCode";
            this.检验项目编码.Name = "检验项目编码";
            this.检验项目编码.OptionsColumn.AllowEdit = false;
            this.检验项目编码.Visible = true;
            this.检验项目编码.VisibleIndex = 5;
            // 
            // 检验设备
            // 
            this.检验设备.Caption = "检验设备";
            this.检验设备.FieldName = "JYShebei";
            this.检验设备.Name = "检验设备";
            this.检验设备.OptionsColumn.AllowEdit = false;
            this.检验设备.Visible = true;
            this.检验设备.VisibleIndex = 6;
            // 
            // 机器编码
            // 
            this.机器编码.Caption = "机器编码";
            this.机器编码.FieldName = "JQCode";
            this.机器编码.Name = "机器编码";
            this.机器编码.OptionsColumn.AllowEdit = false;
            this.机器编码.Visible = true;
            this.机器编码.VisibleIndex = 7;
            // 
            // WP_Shangchuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "WP_Shangchuan";
            this.Size = new System.Drawing.Size(1024, 550);
            this.Load += new System.EventHandler(this.WP_Jianyan_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button 上传;
        private System.Windows.Forms.Button 采集;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button 查询;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn 检验编码;
        private DevExpress.XtraGrid.Columns.GridColumn 检验值;
        private DevExpress.XtraGrid.Columns.GridColumn 检验时间;
        private DevExpress.XtraGrid.Columns.GridColumn 检验项目名称;
        private DevExpress.XtraGrid.Columns.GridColumn 检验项目编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn 检验设备;
        private System.Windows.Forms.Button 全选;
        private DevExpress.XtraGrid.Columns.GridColumn 机器编码;
    }
}
