namespace VehIC_WF.Sampling
{
    partial class UC_ICReg
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnInsert = new System.Windows.Forms.Button();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbCardType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtCardId = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.gridCtl_IC_Info = new DevExpress.XtraGrid.GridControl();
            this.gridCtl_IC_Info_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmBtn_UnbindBill = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBtn_DeleteCard = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBtnGroup_UseType = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView_IC_Info = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCardType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardId.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCtl_IC_Info)).BeginInit();
            this.gridCtl_IC_Info_ContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_IC_Info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnInsert);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainer1.Panel1.Controls.Add(this.cmbCardType);
            this.splitContainer1.Panel1.Controls.Add(this.txtCardId);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridCtl_IC_Info);
            this.splitContainer1.Size = new System.Drawing.Size(805, 374);
            this.splitContainer1.SplitterDistance = 82;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(437, 44);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(63, 25);
            this.btnInsert.TabIndex = 0;
            this.btnInsert.Text = "注册";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(300, 48);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "类型";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(133, 48);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "扣号";
            // 
            // cmbCardType
            // 
            this.cmbCardType.Location = new System.Drawing.Point(330, 47);
            this.cmbCardType.Name = "cmbCardType";
            this.cmbCardType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCardType.Size = new System.Drawing.Size(100, 20);
            this.cmbCardType.TabIndex = 5;
            // 
            // txtCardId
            // 
            this.txtCardId.Location = new System.Drawing.Point(163, 47);
            this.txtCardId.Name = "txtCardId";
            this.txtCardId.Size = new System.Drawing.Size(114, 20);
            this.txtCardId.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "磁扣注册";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(654, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(151, 82);
            this.panel1.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(44, 29);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(80, 25);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "刷新";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // gridCtl_IC_Info
            // 
            this.gridCtl_IC_Info.ContextMenuStrip = this.gridCtl_IC_Info_ContextMenuStrip;
            this.gridCtl_IC_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCtl_IC_Info.Location = new System.Drawing.Point(0, 0);
            this.gridCtl_IC_Info.MainView = this.gridView_IC_Info;
            this.gridCtl_IC_Info.Name = "gridCtl_IC_Info";
            this.gridCtl_IC_Info.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit1});
            this.gridCtl_IC_Info.Size = new System.Drawing.Size(805, 288);
            this.gridCtl_IC_Info.TabIndex = 0;
            this.gridCtl_IC_Info.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_IC_Info});
            this.gridCtl_IC_Info.Click += new System.EventHandler(this.gridCtl_IC_Info_Click);
            // 
            // gridCtl_IC_Info_ContextMenuStrip
            // 
            this.gridCtl_IC_Info_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmBtn_UnbindBill,
            this.tsmBtn_DeleteCard,
            this.tsmBtnGroup_UseType});
            this.gridCtl_IC_Info_ContextMenuStrip.Name = "gridCtl_IC_Info_ContextMenuStrip";
            this.gridCtl_IC_Info_ContextMenuStrip.Size = new System.Drawing.Size(149, 70);
            // 
            // tsmBtn_UnbindBill
            // 
            this.tsmBtn_UnbindBill.Name = "tsmBtn_UnbindBill";
            this.tsmBtn_UnbindBill.Size = new System.Drawing.Size(148, 22);
            this.tsmBtn_UnbindBill.Text = "解除单据绑定";
            this.tsmBtn_UnbindBill.Click += new System.EventHandler(this.tsmBtn_UnbindBill_Click);
            // 
            // tsmBtn_DeleteCard
            // 
            this.tsmBtn_DeleteCard.Name = "tsmBtn_DeleteCard";
            this.tsmBtn_DeleteCard.Size = new System.Drawing.Size(148, 22);
            this.tsmBtn_DeleteCard.Text = "删除磁扣信息";
            this.tsmBtn_DeleteCard.Click += new System.EventHandler(this.tsmBtn_DeleteCard_Click);
            // 
            // tsmBtnGroup_UseType
            // 
            this.tsmBtnGroup_UseType.Name = "tsmBtnGroup_UseType";
            this.tsmBtnGroup_UseType.Size = new System.Drawing.Size(148, 22);
            this.tsmBtnGroup_UseType.Text = "更改使用类型";
            // 
            // gridView_IC_Info
            // 
            this.gridView_IC_Info.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridView_IC_Info.GridControl = this.gridCtl_IC_Info;
            this.gridView_IC_Info.IndicatorWidth = 40;
            this.gridView_IC_Info.Name = "gridView_IC_Info";
            this.gridView_IC_Info.OptionsBehavior.Editable = false;
            this.gridView_IC_Info.OptionsView.ShowGroupPanel = false;
            this.gridView_IC_Info.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView_IC_Info_CustomDrawRowIndicator);
            this.gridView_IC_Info.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_IC_Info_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "卡号";
            this.gridColumn1.FieldName = "CardID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CardID", "共计:{0}条")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "使用类型";
            this.gridColumn2.ColumnEdit = this.repositoryItemGridLookUpEdit1;
            this.gridColumn2.FieldName = "CardType";
            this.gridColumn2.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.DisplayMember = "CUTName";
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.ValueMember = "CUTCode";
            this.repositoryItemGridLookUpEdit1.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "注册人";
            this.gridColumn3.FieldName = "RegUser";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "注册时间";
            this.gridColumn4.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn4.FieldName = "RegTime";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "是否绑定单据";
            this.gridColumn5.FieldName = "IsBingingBill";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "单据号";
            this.gridColumn6.FieldName = "SampleId";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // UC_ICReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UC_ICReg";
            this.Size = new System.Drawing.Size(805, 374);
            this.Load += new System.EventHandler(this.UC_ICReg_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbCardType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardId.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCtl_IC_Info)).EndInit();
            this.gridCtl_IC_Info_ContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView_IC_Info)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnInsert;
        private DevExpress.XtraGrid.GridControl gridCtl_IC_Info;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_IC_Info;
        private DevExpress.XtraEditors.ComboBoxEdit cmbCardType;
        private DevExpress.XtraEditors.TextEdit txtCardId;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ContextMenuStrip gridCtl_IC_Info_ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmBtn_UnbindBill;
        private System.Windows.Forms.ToolStripMenuItem tsmBtn_DeleteCard;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.ToolStripMenuItem tsmBtnGroup_UseType;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}
