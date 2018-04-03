namespace VehIC_WF.Sampling.czl.WorkPoint
{
    partial class QC_Gys
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.右键菜单 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加供应商 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除供应商 = new System.Windows.Forms.ToolStripMenuItem();
            this.qCBDCUBASDOCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.取消 = new System.Windows.Forms.Button();
            this.确定 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.右键菜单.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qCBDCUBASDOCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.右键菜单;
            this.gridControl1.DataSource = this.qCBDCUBASDOCBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(831, 456);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // 右键菜单
            // 
            this.右键菜单.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加供应商,
            this.删除供应商});
            this.右键菜单.Name = "contextMenuStrip2";
            this.右键菜单.Size = new System.Drawing.Size(137, 48);
            // 
            // 添加供应商
            // 
            this.添加供应商.Name = "添加供应商";
            this.添加供应商.Size = new System.Drawing.Size(136, 22);
            this.添加供应商.Text = "添加供应商";
            this.添加供应商.Click += new System.EventHandler(this.添加供应商_Click);
            // 
            // 删除供应商
            // 
            this.删除供应商.Name = "删除供应商";
            this.删除供应商.Size = new System.Drawing.Size(136, 22);
            this.删除供应商.Text = "删除供应商";
            this.删除供应商.Click += new System.EventHandler(this.删除供应商_Click);
            // 
            // qCBDCUBASDOCBindingSource
            // 
            this.qCBDCUBASDOCBindingSource.DataSource = typeof(VehIC_WF.Sampling.czl.Class.QC_BD_CUBASDOC);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "供应商编码";
            this.gridColumn1.FieldName = "CUSTCODE";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "供应商名称";
            this.gridColumn2.FieldName = "CUSTSHORTNAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
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
            this.splitContainer1.Panel1.Controls.Add(this.gridControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.取消);
            this.splitContainer1.Panel2.Controls.Add(this.确定);
            this.splitContainer1.Size = new System.Drawing.Size(831, 528);
            this.splitContainer1.SplitterDistance = 456;
            this.splitContainer1.TabIndex = 1;
            // 
            // 取消
            // 
            this.取消.Location = new System.Drawing.Point(545, 16);
            this.取消.Name = "取消";
            this.取消.Size = new System.Drawing.Size(75, 23);
            this.取消.TabIndex = 1;
            this.取消.Text = "取消";
            this.取消.UseVisualStyleBackColor = true;
            this.取消.Click += new System.EventHandler(this.取消_Click);
            // 
            // 确定
            // 
            this.确定.Location = new System.Drawing.Point(368, 16);
            this.确定.Name = "确定";
            this.确定.Size = new System.Drawing.Size(75, 23);
            this.确定.TabIndex = 0;
            this.确定.Text = "确定";
            this.确定.UseVisualStyleBackColor = true;
            this.确定.Click += new System.EventHandler(this.确定_Click);
            // 
            // QC_Gys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 528);
            this.Controls.Add(this.splitContainer1);
            this.Name = "QC_Gys";
            this.Text = "QC_Gys";
            this.Load += new System.EventHandler(this.QC_Gys_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.右键菜单.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qCBDCUBASDOCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.BindingSource qCBDCUBASDOCBindingSource;
        private System.Windows.Forms.ContextMenuStrip 右键菜单;
        private System.Windows.Forms.ToolStripMenuItem 添加供应商;
        private System.Windows.Forms.ToolStripMenuItem 删除供应商;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button 取消;
        private System.Windows.Forms.Button 确定;
    }
}