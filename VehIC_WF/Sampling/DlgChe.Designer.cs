namespace VehIC_WF.Sampling
{
    partial class DlgChe
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
            this.qCSampleVehBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNoticeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCph = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoticeBodyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNcDhdHeadNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNcDhdBodyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPK_CUBASDOC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCUSTCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCUSTNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPK_INVBASDOC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colINVCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colINVNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaveEnable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.qCNoticeItemDoorViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qCSampleVehBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qCNoticeItemDoorViewBindingSource)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnOk);
            this.splitContainer1.Size = new System.Drawing.Size(871, 424);
            this.splitContainer1.SplitterDistance = 352;
            this.splitContainer1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.qCSampleVehBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(871, 352);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // qCSampleVehBindingSource
            // 
            this.qCSampleVehBindingSource.DataSource = typeof(Xg.Lab.Sample.QC_Sample_Veh);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNoticeId,
            this.colCph,
            this.colNoticeBodyId,
            this.colNcDhdHeadNo,
            this.colNcDhdBodyId,
            this.colPK_CUBASDOC,
            this.colCUSTCODE,
            this.colCUSTNAME,
            this.colPK_INVBASDOC,
            this.colINVCODE,
            this.colINVNAME,
            this.colSaveEnable,
            this.gridColumn1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.btnOk_Click);
            // 
            // colNoticeId
            // 
            this.colNoticeId.Caption = "作业单号";
            this.colNoticeId.FieldName = "NoticeBillId";
            this.colNoticeId.Name = "colNoticeId";
            this.colNoticeId.Visible = true;
            this.colNoticeId.VisibleIndex = 0;
            // 
            // colCph
            // 
            this.colCph.Caption = "车牌号";
            this.colCph.FieldName = "VehNo";
            this.colCph.Name = "colCph";
            this.colCph.Visible = true;
            this.colCph.VisibleIndex = 1;
            // 
            // colNoticeBodyId
            // 
            this.colNoticeBodyId.FieldName = "NoticeBodyId";
            this.colNoticeBodyId.Name = "colNoticeBodyId";
            // 
            // colNcDhdHeadNo
            // 
            this.colNcDhdHeadNo.FieldName = "NcDhdHeadNo";
            this.colNcDhdHeadNo.Name = "colNcDhdHeadNo";
            // 
            // colNcDhdBodyId
            // 
            this.colNcDhdBodyId.FieldName = "NcDhdBodyId";
            this.colNcDhdBodyId.Name = "colNcDhdBodyId";
            // 
            // colPK_CUBASDOC
            // 
            this.colPK_CUBASDOC.FieldName = "PK_CUBASDOC";
            this.colPK_CUBASDOC.Name = "colPK_CUBASDOC";
            // 
            // colCUSTCODE
            // 
            this.colCUSTCODE.Caption = "供应商编码";
            this.colCUSTCODE.FieldName = "SupplierCode";
            this.colCUSTCODE.Name = "colCUSTCODE";
            this.colCUSTCODE.Visible = true;
            this.colCUSTCODE.VisibleIndex = 2;
            // 
            // colCUSTNAME
            // 
            this.colCUSTNAME.Caption = "供应商名称";
            this.colCUSTNAME.FieldName = "SupplierName";
            this.colCUSTNAME.Name = "colCUSTNAME";
            this.colCUSTNAME.Visible = true;
            this.colCUSTNAME.VisibleIndex = 3;
            // 
            // colPK_INVBASDOC
            // 
            this.colPK_INVBASDOC.FieldName = "PK_INVBASDOC";
            this.colPK_INVBASDOC.Name = "colPK_INVBASDOC";
            // 
            // colINVCODE
            // 
            this.colINVCODE.Caption = "物料编码";
            this.colINVCODE.FieldName = "MatCode";
            this.colINVCODE.Name = "colINVCODE";
            this.colINVCODE.Visible = true;
            this.colINVCODE.VisibleIndex = 4;
            // 
            // colINVNAME
            // 
            this.colINVNAME.Caption = "物料名称";
            this.colINVNAME.FieldName = "MatName";
            this.colINVNAME.Name = "colINVNAME";
            this.colINVNAME.Visible = true;
            this.colINVNAME.VisibleIndex = 5;
            // 
            // colSaveEnable
            // 
            this.colSaveEnable.FieldName = "SaveEnable";
            this.colSaveEnable.Name = "colSaveEnable";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "取样时间";
            this.gridColumn1.FieldName = "FetchTime";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(739, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(645, 16);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // qCNoticeItemDoorViewBindingSource
            // 
            this.qCNoticeItemDoorViewBindingSource.DataSource = typeof(Xg.Lab.Sample.View.QC_NoticeItemDoor_View);
            // 
            // DlgChe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 424);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DlgChe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择车辆";
            this.Load += new System.EventHandler(this.DlgChe_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qCSampleVehBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qCNoticeItemDoorViewBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource qCNoticeItemDoorViewBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNoticeId;
        private DevExpress.XtraGrid.Columns.GridColumn colCph;
        private DevExpress.XtraGrid.Columns.GridColumn colNoticeBodyId;
        private DevExpress.XtraGrid.Columns.GridColumn colNcDhdHeadNo;
        private DevExpress.XtraGrid.Columns.GridColumn colNcDhdBodyId;
        private DevExpress.XtraGrid.Columns.GridColumn colPK_CUBASDOC;
        private DevExpress.XtraGrid.Columns.GridColumn colCUSTCODE;
        private DevExpress.XtraGrid.Columns.GridColumn colCUSTNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colPK_INVBASDOC;
        private DevExpress.XtraGrid.Columns.GridColumn colINVCODE;
        private DevExpress.XtraGrid.Columns.GridColumn colINVNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colSaveEnable;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.BindingSource qCSampleVehBindingSource;
    }
}