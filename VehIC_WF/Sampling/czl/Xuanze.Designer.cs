namespace VehIC_WF.Sampling.czl
{
    partial class Xuanze
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
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.qCDhdnoticeItemViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colNoticeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCph = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colINVNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCUSTNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qCDhdnoticeItemViewBindingSource)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.gridControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnOk);
            this.splitContainer1.Size = new System.Drawing.Size(839, 439);
            this.splitContainer1.SplitterDistance = 343;
            this.splitContainer1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.qCDhdnoticeItemViewBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(839, 343);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNoticeId,
            this.colCph,
            this.colINVNAME,
            this.colCUSTNAME});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(680, 41);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(586, 41);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // qCDhdnoticeItemViewBindingSource
            // 
            this.qCDhdnoticeItemViewBindingSource.DataSource = typeof(Xg.Lab.Sample.QC_NoticeDhdItem_View);
            // 
            // colNoticeId
            // 
            this.colNoticeId.Caption = "作业单号";
            this.colNoticeId.FieldName = "NoticeId";
            this.colNoticeId.Name = "colNoticeId";
            this.colNoticeId.Visible = true;
            this.colNoticeId.VisibleIndex = 0;
            // 
            // colCph
            // 
            this.colCph.Caption = "车牌号";
            this.colCph.FieldName = "Cph";
            this.colCph.Name = "colCph";
            this.colCph.Visible = true;
            this.colCph.VisibleIndex = 1;
            // 
            // colINVNAME
            // 
            this.colINVNAME.Caption = "物料名称";
            this.colINVNAME.FieldName = "INVNAME";
            this.colINVNAME.Name = "colINVNAME";
            this.colINVNAME.Visible = true;
            this.colINVNAME.VisibleIndex = 2;
            // 
            // colCUSTNAME
            // 
            this.colCUSTNAME.Caption = "供应商名称";
            this.colCUSTNAME.FieldName = "CUSTNAME";
            this.colCUSTNAME.Name = "colCUSTNAME";
            this.colCUSTNAME.Visible = true;
            this.colCUSTNAME.VisibleIndex = 3;
            // 
            // Xuanze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 439);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Xuanze";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qCDhdnoticeItemViewBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.BindingSource qCDhdnoticeItemViewBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNoticeId;
        private DevExpress.XtraGrid.Columns.GridColumn colCph;
        private DevExpress.XtraGrid.Columns.GridColumn colINVNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colCUSTNAME;

    }
}