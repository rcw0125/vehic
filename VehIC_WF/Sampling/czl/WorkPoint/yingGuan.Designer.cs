namespace VehIC_WF.Sampling.czl.WorkPoint
{
    partial class YingGuang
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
            this.s = new System.IO.Ports.SerialPort(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.检验编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.检验值 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.检验时间 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.检验项目名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.检验项目编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.检验设备 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.上传 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // s
            // 
            this.s.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.s_DataReceived);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1024, 477);
            this.gridControl1.TabIndex = 1;
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
            this.检验设备});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
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
            this.检验编码.Visible = true;
            this.检验编码.VisibleIndex = 1;
            // 
            // 检验值
            // 
            this.检验值.Caption = "检验值";
            this.检验值.FieldName = "Value";
            this.检验值.Name = "检验值";
            this.检验值.Visible = true;
            this.检验值.VisibleIndex = 2;
            // 
            // 检验时间
            // 
            this.检验时间.Caption = "检验时间";
            this.检验时间.FieldName = "Date";
            this.检验时间.Name = "检验时间";
            this.检验时间.Visible = true;
            this.检验时间.VisibleIndex = 3;
            // 
            // 检验项目名称
            // 
            this.检验项目名称.Caption = "检验项目名称";
            this.检验项目名称.FieldName = "CheckItemName";
            this.检验项目名称.Name = "检验项目名称";
            this.检验项目名称.Visible = true;
            this.检验项目名称.VisibleIndex = 4;
            // 
            // 检验项目编码
            // 
            this.检验项目编码.Caption = "检验项目编码";
            this.检验项目编码.FieldName = "CheckItemCode";
            this.检验项目编码.Name = "检验项目编码";
            // 
            // 检验设备
            // 
            this.检验设备.Caption = "检验设备";
            this.检验设备.FieldName = "JYShebei";
            this.检验设备.Name = "检验设备";
            this.检验设备.Visible = true;
            this.检验设备.VisibleIndex = 5;
            // 
            // 上传
            // 
            this.上传.BackColor = System.Drawing.Color.DarkOrange;
            this.上传.Location = new System.Drawing.Point(131, 20);
            this.上传.Name = "上传";
            this.上传.Size = new System.Drawing.Size(77, 30);
            this.上传.TabIndex = 7;
            this.上传.Text = "上传";
            this.上传.UseVisualStyleBackColor = false;
            this.上传.Click += new System.EventHandler(this.上传_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(226, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 29);
            this.button2.TabIndex = 8;
            this.button2.Text = "清空";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Gold;
            this.button3.Location = new System.Drawing.Point(721, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 27);
            this.button3.TabIndex = 9;
            this.button3.Text = "全部上传";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(307, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(103, 30);
            this.button4.TabIndex = 10;
            this.button4.Text = "配置串口参数";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.button4);
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.上传);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1024, 550);
            this.splitContainer1.SplitterDistance = 69;
            this.splitContainer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(50, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 11;
            this.button1.Text = "全选";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // YingGuang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "YingGuang";
            this.Size = new System.Drawing.Size(1024, 550);
            this.Load += new System.EventHandler(this.YingGuang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort s;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn 检验编码;
        private DevExpress.XtraGrid.Columns.GridColumn 检验值;
        private DevExpress.XtraGrid.Columns.GridColumn 检验时间;
        private DevExpress.XtraGrid.Columns.GridColumn 检验项目名称;
        private DevExpress.XtraGrid.Columns.GridColumn 检验项目编码;
        private DevExpress.XtraGrid.Columns.GridColumn 检验设备;
        private System.Windows.Forms.Button 上传;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
    }
}
