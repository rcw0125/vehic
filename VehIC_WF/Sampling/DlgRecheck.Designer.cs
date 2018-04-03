namespace VehIC_WF.Sampling
{
    partial class DlgRecheck
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gridCtlExamineSampleList = new DevExpress.XtraGrid.GridControl();
            this.qCSampleMixBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewExamineSampleList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCtl_CheckVal = new DevExpress.XtraGrid.GridControl();
            this.checkValsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView_CheckVal = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCtlExamineSampleList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qCSampleMixBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExamineSampleList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCtl_CheckVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkValsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_CheckVal)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnOk);
            this.splitContainer1.Size = new System.Drawing.Size(807, 554);
            this.splitContainer1.SplitterDistance = 486;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gridCtlExamineSampleList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gridCtl_CheckVal);
            this.splitContainer2.Size = new System.Drawing.Size(807, 486);
            this.splitContainer2.SplitterDistance = 252;
            this.splitContainer2.TabIndex = 0;
            // 
            // gridCtlExamineSampleList
            // 
            this.gridCtlExamineSampleList.DataSource = this.qCSampleMixBindingSource;
            this.gridCtlExamineSampleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCtlExamineSampleList.Location = new System.Drawing.Point(0, 0);
            this.gridCtlExamineSampleList.MainView = this.gridViewExamineSampleList;
            this.gridCtlExamineSampleList.Name = "gridCtlExamineSampleList";
            this.gridCtlExamineSampleList.Size = new System.Drawing.Size(807, 252);
            this.gridCtlExamineSampleList.TabIndex = 1;
            this.gridCtlExamineSampleList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewExamineSampleList});
            // 
            // qCSampleMixBindingSource
            // 
            this.qCSampleMixBindingSource.DataSource = typeof(Xg.Lab.Sample.QC_Sample_Mix);
            // 
            // gridViewExamineSampleList
            // 
            this.gridViewExamineSampleList.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridViewExamineSampleList.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewExamineSampleList.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewExamineSampleList.Appearance.FocusedCell.Options.UseFont = true;
            this.gridViewExamineSampleList.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridViewExamineSampleList.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewExamineSampleList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewExamineSampleList.Appearance.FocusedRow.Options.UseFont = true;
            this.gridViewExamineSampleList.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridViewExamineSampleList.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewExamineSampleList.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridViewExamineSampleList.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridViewExamineSampleList.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridViewExamineSampleList.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewExamineSampleList.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewExamineSampleList.Appearance.SelectedRow.Options.UseFont = true;
            this.gridViewExamineSampleList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn15,
            this.gridColumn2});
            this.gridViewExamineSampleList.GridControl = this.gridCtlExamineSampleList;
            this.gridViewExamineSampleList.Name = "gridViewExamineSampleList";
            this.gridViewExamineSampleList.OptionsBehavior.Editable = false;
            this.gridViewExamineSampleList.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewExamineSampleList.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "正样单号";
            this.gridColumn5.FieldName = "MainSampleZyDanHao";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 73;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "供应商编码";
            this.gridColumn6.FieldName = "SupplierCode";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "供应商名称";
            this.gridColumn7.FieldName = "SupplierName";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "物料编码";
            this.gridColumn8.FieldName = "MatCode";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "物料名称";
            this.gridColumn9.FieldName = "MatName";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "备注";
            this.gridColumn15.FieldName = "Memo";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 6;
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "ZyDanHao";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridCtl_CheckVal
            // 
            this.gridCtl_CheckVal.DataSource = this.checkValsBindingSource;
            this.gridCtl_CheckVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCtl_CheckVal.Location = new System.Drawing.Point(0, 0);
            this.gridCtl_CheckVal.MainView = this.gridView_CheckVal;
            this.gridCtl_CheckVal.Name = "gridCtl_CheckVal";
            this.gridCtl_CheckVal.Size = new System.Drawing.Size(807, 230);
            this.gridCtl_CheckVal.TabIndex = 1;
            this.gridCtl_CheckVal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_CheckVal});
            // 
            // checkValsBindingSource
            // 
            this.checkValsBindingSource.DataMember = "CheckVals";
            this.checkValsBindingSource.DataSource = this.qCSampleMixBindingSource;
            // 
            // gridView_CheckVal
            // 
            this.gridView_CheckVal.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.gridView_CheckVal.Appearance.EvenRow.BackColor2 = System.Drawing.Color.White;
            this.gridView_CheckVal.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView_CheckVal.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridView_CheckVal.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_CheckVal.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView_CheckVal.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView_CheckVal.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gridView_CheckVal.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn1,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn35});
            this.gridView_CheckVal.GridControl = this.gridCtl_CheckVal;
            this.gridView_CheckVal.Name = "gridView_CheckVal";
            this.gridView_CheckVal.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridView_CheckVal.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView_CheckVal.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView_CheckVal.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "检验项编码";
            this.gridColumn11.FieldName = "CheckItemCode";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "检验项名称";
            this.gridColumn12.FieldName = "CheckItemName";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "检验值";
            this.gridColumn13.FieldName = "CheckVal";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 2;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "计量单位";
            this.gridColumn14.FieldName = "CheckItemUnit";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 3;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "检验人编码";
            this.gridColumn1.FieldName = "CheckUser";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "检验人名称";
            this.gridColumn16.FieldName = "CheckUserName";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 5;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "检验时间";
            this.gridColumn17.FieldName = "CheckTime";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 6;
            // 
            // gridColumn35
            // 
            this.gridColumn35.AppearanceCell.BackColor = System.Drawing.Color.Azure;
            this.gridColumn35.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn35.FieldName = "ReportVal";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.OptionsColumn.AllowEdit = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(696, 26);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 26);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(593, 26);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(82, 26);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // DlgRecheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 554);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DlgRecheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择复检值";
            this.Load += new System.EventHandler(this.DlgRecheck_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCtlExamineSampleList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qCSampleMixBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExamineSampleList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCtl_CheckVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkValsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_CheckVal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private DevExpress.XtraGrid.GridControl gridCtlExamineSampleList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewExamineSampleList;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.GridControl gridCtl_CheckVal;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_CheckVal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private System.Windows.Forms.BindingSource qCSampleMixBindingSource;
        private System.Windows.Forms.BindingSource checkValsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}