namespace VehIC_WF.Sampling
{
    partial class DlgCheckGroup
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.qCCheckGroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvCheckGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol_CheckItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CheckItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CheckItemUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CheckGroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemPopupContainerEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qCCheckGroupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCheckGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.gridControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(515, 391);
            this.splitContainer1.SplitterDistance = 330;
            this.splitContainer1.TabIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.qCCheckGroupBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gvCheckGroup;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPopupContainerEdit1,
            this.repositoryItemGridLookUpEdit1});
            this.gridControl1.Size = new System.Drawing.Size(515, 330);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCheckGroup});
            // 
            // qCCheckGroupBindingSource
            // 
            this.qCCheckGroupBindingSource.DataSource = typeof(Xg.Lab.Sample.QC_CheckGroup);
            // 
            // gvCheckGroup
            // 
            this.gvCheckGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol_CheckItemCode,
            this.gridCol_CheckItemName,
            this.gridCol_CheckItemUnit,
            this.gridCol_CheckGroupCode});
            this.gvCheckGroup.GridControl = this.gridControl1;
            this.gvCheckGroup.Name = "gvCheckGroup";
            this.gvCheckGroup.OptionsView.ShowGroupPanel = false;
            // 
            // gridCol_CheckItemCode
            // 
            this.gridCol_CheckItemCode.Caption = "样品分类编码";
            this.gridCol_CheckItemCode.FieldName = "CheckGroupCode";
            this.gridCol_CheckItemCode.Name = "gridCol_CheckItemCode";
            this.gridCol_CheckItemCode.OptionsColumn.AllowEdit = false;
            this.gridCol_CheckItemCode.Visible = true;
            this.gridCol_CheckItemCode.VisibleIndex = 0;
            // 
            // gridCol_CheckItemName
            // 
            this.gridCol_CheckItemName.Caption = "样品分类名称";
            this.gridCol_CheckItemName.FieldName = "CheckGroupName";
            this.gridCol_CheckItemName.Name = "gridCol_CheckItemName";
            this.gridCol_CheckItemName.OptionsColumn.AllowEdit = false;
            this.gridCol_CheckItemName.Visible = true;
            this.gridCol_CheckItemName.VisibleIndex = 1;
            // 
            // gridCol_CheckItemUnit
            // 
            this.gridCol_CheckItemUnit.Caption = "样品分类类型";
            this.gridCol_CheckItemUnit.FieldName = "CheckGroupType";
            this.gridCol_CheckItemUnit.Name = "gridCol_CheckItemUnit";
            this.gridCol_CheckItemUnit.OptionsColumn.AllowEdit = false;
            this.gridCol_CheckItemUnit.Visible = true;
            this.gridCol_CheckItemUnit.VisibleIndex = 2;
            // 
            // gridCol_CheckGroupCode
            // 
            this.gridCol_CheckGroupCode.Caption = "样品分类标志";
            this.gridCol_CheckGroupCode.ColumnEdit = this.repositoryItemGridLookUpEdit1;
            this.gridCol_CheckGroupCode.FieldName = "ShortWord";
            this.gridCol_CheckGroupCode.Name = "gridCol_CheckGroupCode";
            this.gridCol_CheckGroupCode.Visible = true;
            this.gridCol_CheckGroupCode.VisibleIndex = 3;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.DisplayMember = "CheckGroupName";
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.ValueMember = "CheckGroupCode";
            this.repositoryItemGridLookUpEdit1.View = this.gridView2;
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemPopupContainerEdit1
            // 
            this.repositoryItemPopupContainerEdit1.AutoHeight = false;
            this.repositoryItemPopupContainerEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemPopupContainerEdit1.Name = "repositoryItemPopupContainerEdit1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(315, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 57);
            this.panel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(106, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(9, 20);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // DlgCheckGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 391);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DlgCheckGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "样品分类";
            this.Load += new System.EventHandler(this.DlgCheckGroup_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qCCheckGroupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCheckGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource qCCheckGroupBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCheckGroup;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CheckItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CheckItemName;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CheckItemUnit;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CheckGroupCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}