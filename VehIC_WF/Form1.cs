namespace VehIC_WF
{
    using DevExpress.XtraPrinting;
    using DevExpress.XtraPrinting.BarCode;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    using Xg.Lab.Sample;
    using Zhc.Data;
    using System.Data.Linq;
    using System.Linq;

    public class Form1 : Form
    {
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
        private PrintDialog printDialog1;
        private DevExpress.XtraEditors.BarCodeControl barCodeControl1;
        private Button button1;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label label3;
        private Label label2;
        private Panel panel3;
        private Label label4;
        private Label label5;
        private Panel panel4;
        private Label label6;
        private Label label7;
        private Panel panel5;
        private Label label8;
        private Label label9;
        private Panel panel6;
        private Button button2;
        private Label label10;
        private Label label11;
        private BindingSource qCSampleMixBindingSource;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private DevExpress.XtraGrid.Columns.GridColumn colZyDanHao;
        private DevExpress.XtraGrid.Columns.GridColumn colCardID;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.GridSplitContainer gridSplitContainer1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.BarCodeControl barCodeControl2;
        private IContainer components = null;

        public Form1()
        {
            this.InitializeComponent();
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode4 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode5 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode6 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode7 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode8 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode9 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode10 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode11 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode12 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode13 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode14 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode15 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode16 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode17 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode18 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode19 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode20 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode21 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode22 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode23 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode24 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode25 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode26 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode27 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode28 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode29 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode30 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode31 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode32 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode33 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode34 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode35 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode36 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode37 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode38 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode39 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode40 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DevExpress.XtraPrinting.BarCode.QRCodeGenerator qrCodeGenerator1 = new DevExpress.XtraPrinting.BarCode.QRCodeGenerator();
            DevExpress.XtraPrinting.BarCode.Code39Generator code39Generator1 = new DevExpress.XtraPrinting.BarCode.Code39Generator();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.qCSampleMixBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.colZyDanHao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCardID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.barCodeControl1 = new DevExpress.XtraEditors.BarCodeControl();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.gridSplitContainer1 = new DevExpress.XtraGrid.GridSplitContainer();
            this.barCodeControl2 = new DevExpress.XtraEditors.BarCodeControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qCSampleMixBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1)).BeginInit();
            this.gridSplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.qCSampleMixBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "AddCheckItems";
            gridLevelNode2.RelationName = "VehSamples";
            gridLevelNode3.RelationName = "CheckItems";
            gridLevelNode4.LevelTemplate = this.gridView1;
            gridLevelNode4.RelationName = "CheckVals";
            gridLevelNode6.RelationName = "AddCheckItems";
            gridLevelNode7.RelationName = "VehSamples";
            gridLevelNode8.RelationName = "CheckItems";
            gridLevelNode9.RelationName = "CheckVals";
            gridLevelNode11.RelationName = "AddCheckItems";
            gridLevelNode12.RelationName = "VehSamples";
            gridLevelNode13.RelationName = "CheckItems";
            gridLevelNode14.RelationName = "CheckVals";
            gridLevelNode16.RelationName = "AddCheckItems";
            gridLevelNode17.RelationName = "VehSamples";
            gridLevelNode18.RelationName = "CheckItems";
            gridLevelNode19.RelationName = "CheckVals";
            gridLevelNode21.RelationName = "AddCheckItems";
            gridLevelNode22.RelationName = "VehSamples";
            gridLevelNode23.RelationName = "CheckItems";
            gridLevelNode24.RelationName = "CheckVals";
            gridLevelNode26.RelationName = "AddCheckItems";
            gridLevelNode27.RelationName = "VehSamples";
            gridLevelNode28.RelationName = "CheckItems";
            gridLevelNode29.RelationName = "CheckVals";
            gridLevelNode31.RelationName = "AddCheckItems";
            gridLevelNode32.RelationName = "VehSamples";
            gridLevelNode33.RelationName = "CheckItems";
            gridLevelNode34.RelationName = "CheckVals";
            gridLevelNode36.RelationName = "AddCheckItems";
            gridLevelNode37.RelationName = "VehSamples";
            gridLevelNode38.RelationName = "CheckItems";
            gridLevelNode39.RelationName = "CheckVals";
            gridLevelNode40.RelationName = "InspectSamples";
            gridLevelNode35.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode36,
            gridLevelNode37,
            gridLevelNode38,
            gridLevelNode39,
            gridLevelNode40});
            gridLevelNode35.RelationName = "InspectSamples";
            gridLevelNode30.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode31,
            gridLevelNode32,
            gridLevelNode33,
            gridLevelNode34,
            gridLevelNode35});
            gridLevelNode30.RelationName = "InspectSamples";
            gridLevelNode25.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode26,
            gridLevelNode27,
            gridLevelNode28,
            gridLevelNode29,
            gridLevelNode30});
            gridLevelNode25.RelationName = "InspectSamples";
            gridLevelNode20.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode21,
            gridLevelNode22,
            gridLevelNode23,
            gridLevelNode24,
            gridLevelNode25});
            gridLevelNode20.RelationName = "InspectSamples";
            gridLevelNode15.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode16,
            gridLevelNode17,
            gridLevelNode18,
            gridLevelNode19,
            gridLevelNode20});
            gridLevelNode15.RelationName = "InspectSamples";
            gridLevelNode10.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode11,
            gridLevelNode12,
            gridLevelNode13,
            gridLevelNode14,
            gridLevelNode15});
            gridLevelNode10.RelationName = "InspectSamples";
            gridLevelNode5.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode6,
            gridLevelNode7,
            gridLevelNode8,
            gridLevelNode9,
            gridLevelNode10});
            gridLevelNode5.RelationName = "InspectSamples";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2,
            gridLevelNode3,
            gridLevelNode4,
            gridLevelNode5});
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.cardView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(549, 300);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cardView1,
            this.gridView1});
            // 
            // qCSampleMixBindingSource
            // 
            this.qCSampleMixBindingSource.DataSource = typeof(Xg.Lab.Sample.QC_Sample_Mix);
            // 
            // cardView1
            // 
            this.cardView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colZyDanHao,
            this.colCardID});
            this.cardView1.FocusedCardTopFieldIndex = 0;
            this.cardView1.GridControl = this.gridControl1;
            this.cardView1.Name = "cardView1";
            this.cardView1.OptionsView.ShowViewCaption = true;
            this.cardView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            // 
            // colZyDanHao
            // 
            this.colZyDanHao.Caption = "制样单号";
            this.colZyDanHao.FieldName = "ZyDanHao";
            this.colZyDanHao.Name = "colZyDanHao";
            this.colZyDanHao.Visible = true;
            this.colZyDanHao.VisibleIndex = 0;
            this.colZyDanHao.Width = 200;
            // 
            // colCardID
            // 
            this.colCardID.Caption = "检验项目";
            this.colCardID.FieldName = "CheckItems.CheckItemName";
            this.colCardID.Name = "colCardID";
            this.colCardID.Visible = true;
            this.colCardID.VisibleIndex = 1;
            this.colCardID.Width = 200;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // barCodeControl1
            // 
            this.barCodeControl1.AutoModule = true;
            this.barCodeControl1.Location = new System.Drawing.Point(16, 137);
            this.barCodeControl1.Name = "barCodeControl1";
            this.barCodeControl1.Padding = new System.Windows.Forms.Padding(10, 2, 10, 0);
            this.barCodeControl1.ShowText = false;
            this.barCodeControl1.Size = new System.Drawing.Size(201, 193);
            qrCodeGenerator1.CompactionMode = DevExpress.XtraPrinting.BarCode.QRCodeCompactionMode.Byte;
            qrCodeGenerator1.Version = DevExpress.XtraPrinting.BarCode.QRCodeVersion.Version1;
            this.barCodeControl1.Symbology = qrCodeGenerator1;
            this.barCodeControl1.TabIndex = 0;
            this.barCodeControl1.Text = "B03050101";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.barCodeControl1);
            this.panel1.Location = new System.Drawing.Point(53, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 383);
            this.panel1.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(48, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 29);
            this.label11.TabIndex = 5;
            this.label11.Text = "B0601F";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(40, 345);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(143, 24);
            this.label10.TabIndex = 4;
            this.label10.Text = "灰分/挥发份/S";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(48, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "B0601F";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(13, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(169, 88);
            this.panel2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(15, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "201405/水分/化验/煤研/角质层";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(21, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "B0601";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(13, 210);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(169, 88);
            this.panel3.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(15, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "201405/灰分/挥发份/S";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(21, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 29);
            this.label5.TabIndex = 2;
            this.label5.Text = "B0601F";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(13, 111);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(169, 88);
            this.panel4.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(15, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 24);
            this.label6.TabIndex = 3;
            this.label6.Text = "201405/水分";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(21, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 29);
            this.label7.TabIndex = 2;
            this.label7.Text = "B0601S";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Location = new System.Drawing.Point(13, 309);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(169, 88);
            this.panel5.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(15, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 24);
            this.label8.TabIndex = 3;
            this.label8.Text = "201405/G";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(21, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 24);
            this.label9.TabIndex = 2;
            this.label9.Text = "B0601G_3-1";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Controls.Add(this.panel4);
            this.panel6.Location = new System.Drawing.Point(330, 34);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 411);
            this.panel6.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(144, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gridSplitContainer1
            // 
            this.gridSplitContainer1.Grid = this.gridControl1;
            this.gridSplitContainer1.Location = new System.Drawing.Point(548, 46);
            this.gridSplitContainer1.Name = "gridSplitContainer1";
            this.gridSplitContainer1.Panel1.Controls.Add(this.gridControl1);
            this.gridSplitContainer1.Size = new System.Drawing.Size(549, 300);
            this.gridSplitContainer1.TabIndex = 9;
            // 
            // barCodeControl2
            // 
            this.barCodeControl2.Location = new System.Drawing.Point(602, 380);
            this.barCodeControl2.Name = "barCodeControl2";
            this.barCodeControl2.Padding = new System.Windows.Forms.Padding(10, 2, 10, 0);
            this.barCodeControl2.ShowText = false;
            this.barCodeControl2.Size = new System.Drawing.Size(223, 65);
            code39Generator1.WideNarrowRatio = 3F;
            this.barCodeControl2.Symbology = code39Generator1;
            this.barCodeControl2.TabIndex = 10;
            this.barCodeControl2.Text = "01";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 553);
            this.Controls.Add(this.barCodeControl2);
            this.Controls.Add(this.gridSplitContainer1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qCSampleMixBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1)).EndInit();
            this.gridSplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            QC_Sample_Mix_Table table = new QC_Sample_Mix_Table();
            table.LoadData();
            foreach (var item in table)
            {
                item.CheckItems.LoadDataBySampleMixId(item.Sample_Mix_ID);
            }
            this.qCSampleMixBindingSource.DataSource = table;
          //DbContext db=new DbContext();
          //Table<QC_Log> ta=   db.GetTable<QC_Log>();

          // var a = from log in ta select log;

          // foreach (var item in a)
          // {
          //     Console.Write(item.OperateType);
          // }

            //double dx = Math.PI / 10;
            //double result = 0;
            //for (double x = 0 - Math.PI; x < Math.PI; x+=dx)
            //{
            //    result += Math.Cos(x) * Math.Cos(3 * x) * dx;
            //}

            //MessageBox.Show(result.ToString());
        }
        private void PrintQRCode()
        {
            
        }
        private Bitmap barCodeImage =null;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle rc=new Rectangle ();
        barCodeControl2.DrawToBitmap(barCodeImage, rc );


            for (int i = 0; i < 6; i++)
            {
                string hao = string.Format("B{0}{1}", DateTime.Now.Day.ToString("00"), i.ToString("00"));
                Font f = new System.Drawing.Font("宋体", 26, FontStyle.Bold);
                e.Graphics.DrawString(hao, f, new SolidBrush(Color.Black), new PointF(10, 10 + i * 50));
             
                Font f2 = new System.Drawing.Font("宋体", 10);
                e.Graphics.DrawString("水分", f2, new SolidBrush(Color.Black), new PointF(10, 40 + i * 50));
                
           //     e.Graphics.DrawRectangle(new Pen(Color.Black),new Rectangle(5,5,60,50));
            }


            //  e.Graphics.DrawImage(barCodeImage, new Point(0, 0));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Panel panel = this.panel1;
            NewMethod(panel);
            Graphics g=barCodeControl2.CreateGraphics();
        }

        private void NewMethod(Panel panel)
        {
            this.barCodeImage = new Bitmap(panel.Width, panel.Height);//实例化一个和窗体一样大的bitmap
            Graphics g = Graphics.FromImage(barCodeImage);
            g.CompositingQuality = CompositingQuality.HighQuality;//质量设为最高  
            Point srcLocation = PointToScreen(panel.Location);
            g.CopyFromScreen(srcLocation.X, srcLocation.Y, 0, 0, new Size(panel.Width, panel.Height));//

            this.printPreviewDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Panel panel = this.panel6;
            NewMethod(panel);
        }

    }
   
}

