namespace VehIC_WF
{
    using DevExpress.Utils;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using VehIC_WF.CommonService;
    using VehIC_WF.ICCardManageService;
    using VehIC_WF.Properties;
    using VehIC_WF.Utility;

    public class FrmDoorInvAdjust : Form
    {
        public AvailableBillInfo billinfo = null;
        private Button btn_print;
        private Button btn_return;
        private Button button1;
        private Button button2;
        public VehIC_WF.CommonService.CommonService commonservice = null;
        private IContainer components = null;
        private GroupBox groupBox1;
        private ImageList imageList1;
        private Label label7;
        public NoticeItems m_ntitems = null;
        private Panel panel1;
        private Panel panel2;
        private Panel panel5;
        private Panel panel6;
        private Splitter splitter1;
        private TreeListColumn tlc1;
        private TreeListColumn tlc2;
        private TreeListColumn tlc3;
        private TreeListColumn tlc4;
        private TreeListColumn tlc5;
        private TreeList treeList1;
        private TreeList treeList2;
        private TreeListColumn treeListColumn1;
        private TreeListColumn treeListColumn2;
        private TreeListColumn treeListColumn3;
        private TreeListColumn treeListColumn4;

        public FrmDoorInvAdjust(NoticeItems ntitems, AvailableBillInfo info)
        {
            this.InitializeComponent();
            base.DialogResult = DialogResult.Cancel;
            this.m_ntitems = ntitems;
            this.billinfo = info;
            this.commonservice = new VehIC_WF.CommonService.CommonService();
            if (!FrmMain.Debug)
            {
                this.commonservice.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/CommonService.asmx";
            }
            this.InitListTree();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (this.treeList1.Nodes.Count != 0)
            {
                this.treeList1.Print();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (((this.treeList2.Selection != null) && (this.treeList2.Selection.Count <= 1)) && (this.treeList2.Selection.Count != 0))
            {
                int id = this.treeList2.Selection[0].Id;
                if (id != 0)
                {
                    int num2;
                    string[] strArray = new string[this.treeList2.Columns.Count];
                    for (num2 = 1; num2 < this.treeList2.Columns.Count; num2++)
                    {
                        strArray[num2] = this.treeList2.Nodes[id].GetValue(this.treeList2.Columns[num2]).ToString();
                    }
                    for (num2 = 1; num2 < this.treeList2.Columns.Count; num2++)
                    {
                        this.treeList2.Nodes[id].SetValue(this.treeList2.Columns[num2], this.treeList2.Nodes[id - 1].GetValue(this.treeList2.Columns[num2]));
                    }
                    for (num2 = 1; num2 < this.treeList2.Columns.Count; num2++)
                    {
                        this.treeList2.Nodes[id - 1].SetValue(this.treeList2.Columns[num2], strArray[num2]);
                    }
                    int tag = (int) this.treeList2.Nodes[id].Tag;
                    this.treeList2.Nodes[id].Tag = this.treeList2.Nodes[id - 1].Tag;
                    this.treeList2.Nodes[id - 1].Tag = tag;
                    this.treeList2.SetFocusedNode(this.treeList2.Nodes[id - 1]);
                    this.GenRouteS();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (((this.treeList2.Selection != null) && (this.treeList2.Selection.Count <= 1)) && (this.treeList2.Selection.Count != 0))
            {
                int id = this.treeList2.Selection[0].Id;
                if (id != (this.treeList2.Nodes.Count - 1))
                {
                    int num2;
                    string[] strArray = new string[this.treeList2.Columns.Count];
                    for (num2 = 1; num2 < this.treeList2.Columns.Count; num2++)
                    {
                        strArray[num2] = this.treeList2.Nodes[id].GetValue(this.treeList2.Columns[num2]).ToString();
                    }
                    for (num2 = 1; num2 < this.treeList2.Columns.Count; num2++)
                    {
                        this.treeList2.Nodes[id].SetValue(this.treeList2.Columns[num2], this.treeList2.Nodes[id + 1].GetValue(this.treeList2.Columns[num2]));
                    }
                    for (num2 = 1; num2 < this.treeList2.Columns.Count; num2++)
                    {
                        this.treeList2.Nodes[id + 1].SetValue(this.treeList2.Columns[num2], strArray[num2]);
                    }
                    int tag = (int) this.treeList2.Nodes[id].Tag;
                    this.treeList2.Nodes[id].Tag = this.treeList2.Nodes[id + 1].Tag;
                    this.treeList2.Nodes[id + 1].Tag = tag;
                    this.treeList2.SetFocusedNode(this.treeList2.Nodes[id + 1]);
                    this.GenRouteS();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void GenRouteS()
        {
            try
            {
                int num;
                RouteNode[] route;
                this.treeList1.Nodes.Clear();
                RouteNodes nodes = new RouteNodes();
                if (this.billinfo.Type < 3)
                {
                    for (num = 0; num < this.treeList2.Nodes.Count; num++)
                    {
                        int tag = (int) this.treeList2.Nodes[num].Tag;
                        route = this.commonservice.GetRoute(this.m_ntitems[tag].routecode);
                        if (route != null)
                        {
                            for (int i = 0; i < route.Length; i++)
                            {
                                route[i].InvXH = num;
                                route[i].InvCode = this.m_ntitems[tag].invcode;
                                route[i].InvName = this.m_ntitems[tag].invname;
                            }
                            nodes.Add(route);
                        }
                    }
                    nodes.Merge(this.billinfo.NeedWeigh);
                }
                else
                {
                    bool isqtorxh = this.billinfo.Type == 3;
                    route = this.commonservice.GetRouteOfBillType(this.billinfo.BillTypeID, isqtorxh);
                    nodes.Add(route);
                }
                for (num = 0; num < nodes.Count; num++)
                {
                    TreeListNode node = null;
                    node = this.treeList1.AppendNode(new object[] { num + 1, Common.Getwctypedesc(nodes[num].wctype), nodes[num].InvCode, nodes[num].InvName }, -1, 0, 0, 0);
                    for (int j = 0; j < nodes[num].wclist.Length; j++)
                    {
                        this.treeList1.AppendNode(new object[] { "", nodes[num].wclist[j], "", "" }, node.Id, 1, 1, 1);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("生成路线时产生错误！\r\n" + exception.ToString());
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmDoorInvAdjust));
            this.panel1 = new Panel();
            this.groupBox1 = new GroupBox();
            this.label7 = new Label();
            this.panel6 = new Panel();
            this.btn_print = new Button();
            this.btn_return = new Button();
            this.panel2 = new Panel();
            this.treeList1 = new TreeList();
            this.treeListColumn1 = new TreeListColumn();
            this.treeListColumn2 = new TreeListColumn();
            this.treeListColumn3 = new TreeListColumn();
            this.treeListColumn4 = new TreeListColumn();
            this.imageList1 = new ImageList(this.components);
            this.panel5 = new Panel();
            this.button2 = new Button();
            this.button1 = new Button();
            this.splitter1 = new Splitter();
            this.treeList2 = new TreeList();
            this.tlc1 = new TreeListColumn();
            this.tlc2 = new TreeListColumn();
            this.tlc3 = new TreeListColumn();
            this.tlc4 = new TreeListColumn();
            this.tlc5 = new TreeListColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.treeList1.BeginInit();
            this.panel5.SuspendLayout();
            this.treeList2.BeginInit();
            base.SuspendLayout();
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x3d5, 0x71);
            this.panel1.TabIndex = 0;
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Dock = DockStyle.Fill;
            this.groupBox1.Location = new Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x3d5, 0x71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.label7.BackColor = SystemColors.Info;
            this.label7.Dock = DockStyle.Fill;
            this.label7.FlatStyle = FlatStyle.Popup;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label7.Location = new Point(3, 0x11);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x32b, 0x5d);
            this.label7.TabIndex = 0xad;
            this.label7.Text = "作业线路生成规则:\r\n      1.计重类物资路线：对物资路线按序累加再合并(门岗、计量合并，取样、货场不变)。\r\n      2.计件类物资路线：门岗合并、货场作业点间没有顺序。\r\n      3.其他物资、循环物资按对应单据类型设置的路线归类为计重类物资路线、计件类物资路线或者特殊路线。";
            this.label7.TextAlign = ContentAlignment.MiddleLeft;
            this.panel6.Controls.Add(this.btn_print);
            this.panel6.Controls.Add(this.btn_return);
            this.panel6.Dock = DockStyle.Right;
            this.panel6.Location = new Point(0x32e, 0x11);
            this.panel6.Name = "panel6";
            this.panel6.Size = new Size(0xa4, 0x5d);
            this.panel6.TabIndex = 0x92;
            this.btn_print.Location = new Point(0x19, 14);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new Size(0x74, 0x1d);
            this.btn_print.TabIndex = 0x95;
            this.btn_print.Text = "打印路线";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new EventHandler(this.btn_print_Click);
            this.btn_return.Location = new Point(0x19, 0x34);
            this.btn_return.Name = "btn_return";
            this.btn_return.Size = new Size(0x74, 0x1d);
            this.btn_return.TabIndex = 0x94;
            this.btn_return.Text = "返回";
            this.btn_return.UseVisualStyleBackColor = true;
            this.btn_return.Click += new EventHandler(this.button5_Click);
            this.panel2.Controls.Add(this.treeList1);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = DockStyle.Right;
            this.panel2.Location = new Point(0x1ac, 0x71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x229, 0x1b2);
            this.panel2.TabIndex = 1;
            this.treeList1.BackgroundImage = (Image) resources.GetObject("treeList1.BackgroundImage");
            this.treeList1.Columns.AddRange(new TreeListColumn[] { this.treeListColumn1, this.treeListColumn2, this.treeListColumn3, this.treeListColumn4 });
            this.treeList1.Dock = DockStyle.Fill;
            this.treeList1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.treeList1.HorzScrollVisibility = ScrollVisibility.Always;
            this.treeList1.Location = new Point(0x52, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsPrint.PrintAllNodes = true;
            this.treeList1.OptionsPrint.PrintReportFooter = false;
            this.treeList1.OptionsPrint.PrintVertLines = false;
            this.treeList1.OptionsView.ShowFocusedFrame = false;
            this.treeList1.Size = new Size(0x1d7, 0x1b2);
            this.treeList1.StateImageList = this.imageList1;
            this.treeList1.TabIndex = 0x95;
            this.treeList1.TreeLevelWidth = 12;
            this.treeListColumn1.AppearanceCell.BorderColor = Color.Red;
            this.treeListColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.treeListColumn1.AppearanceCell.Options.UseBorderColor = true;
            this.treeListColumn1.AppearanceCell.Options.UseFont = true;
            this.treeListColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn1.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
            this.treeListColumn1.Caption = "序号";
            this.treeListColumn1.FieldName = "状态";
            this.treeListColumn1.MinWidth = 0x40;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.AllowMove = false;
            this.treeListColumn1.OptionsColumn.AllowSort = false;
            this.treeListColumn1.OptionsColumn.ReadOnly = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 0x43;
            this.treeListColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.treeListColumn2.AppearanceCell.Options.UseFont = true;
            this.treeListColumn2.Caption = "作业点类型";
            this.treeListColumn2.FieldName = "物资编码";
            this.treeListColumn2.MinWidth = 30;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            this.treeListColumn2.OptionsColumn.AllowMove = false;
            this.treeListColumn2.OptionsColumn.AllowSort = false;
            this.treeListColumn2.OptionsColumn.ReadOnly = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 110;
            this.treeListColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.treeListColumn3.AppearanceCell.Options.UseFont = true;
            this.treeListColumn3.Caption = "物资编码";
            this.treeListColumn3.FieldName = "物资名称";
            this.treeListColumn3.MinWidth = 40;
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.OptionsColumn.AllowEdit = false;
            this.treeListColumn3.OptionsColumn.AllowMove = false;
            this.treeListColumn3.OptionsColumn.AllowSort = false;
            this.treeListColumn3.OptionsColumn.ReadOnly = true;
            this.treeListColumn3.VisibleIndex = 2;
            this.treeListColumn3.Width = 0x8b;
            this.treeListColumn4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.treeListColumn4.AppearanceCell.Options.UseFont = true;
            this.treeListColumn4.Caption = "物资名称";
            this.treeListColumn4.FieldName = "作业结果";
            this.treeListColumn4.MinWidth = 40;
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.OptionsColumn.AllowEdit = false;
            this.treeListColumn4.OptionsColumn.AllowMove = false;
            this.treeListColumn4.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.treeListColumn4.OptionsColumn.AllowSort = false;
            this.treeListColumn4.OptionsColumn.ReadOnly = true;
            this.treeListColumn4.VisibleIndex = 3;
            this.treeListColumn4.Width = 0x8a;
            this.imageList1.ImageStream = (ImageListStreamer) resources.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "favorites.gif");
            this.imageList1.Images.SetKeyName(1, "point.ico");
            this.panel5.Controls.Add(this.button2);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Dock = DockStyle.Left;
            this.panel5.Location = new Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new Size(0x52, 0x1b2);
            this.panel5.TabIndex = 30;
            this.button2.Image = (Image)resources.GetObject("_2");
            this.button2.Location = new Point(0x12, 0xec);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x2e, 0x5e);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.button1.Image = (Image)resources.GetObject("_1");
            this.button1.Location = new Point(0x12, 0x40);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x2e, 0x5e);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.splitter1.BackColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.splitter1.Cursor = Cursors.VSplit;
            this.splitter1.Dock = DockStyle.Right;
            this.splitter1.Location = new Point(0x1aa, 0x71);
            this.splitter1.MinSize = 150;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new Size(2, 0x1b2);
            this.splitter1.TabIndex = 0x15;
            this.splitter1.TabStop = false;
            this.treeList2.BackgroundImage = (Image) resources.GetObject("treeList2.BackgroundImage");
            this.treeList2.Columns.AddRange(new TreeListColumn[] { this.tlc1, this.tlc2, this.tlc3, this.tlc4, this.tlc5 });
            this.treeList2.Dock = DockStyle.Fill;
            this.treeList2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.treeList2.HorzScrollVisibility = ScrollVisibility.Always;
            this.treeList2.Location = new Point(0, 0x71);
            this.treeList2.Name = "treeList2";
            this.treeList2.OptionsView.ShowFocusedFrame = false;
            this.treeList2.Size = new Size(0x1aa, 0x1b2);
            this.treeList2.TabIndex = 0x94;
            this.treeList2.TreeLevelWidth = 12;
            this.tlc1.AppearanceCell.BorderColor = Color.Red;
            this.tlc1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.tlc1.AppearanceCell.Options.UseBorderColor = true;
            this.tlc1.AppearanceCell.Options.UseFont = true;
            this.tlc1.AppearanceCell.Options.UseTextOptions = true;
            this.tlc1.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
            this.tlc1.Caption = "序号";
            this.tlc1.FieldName = "状态";
            this.tlc1.MinWidth = 40;
            this.tlc1.Name = "tlc1";
            this.tlc1.OptionsColumn.AllowEdit = false;
            this.tlc1.OptionsColumn.AllowMove = false;
            this.tlc1.OptionsColumn.AllowSort = false;
            this.tlc1.OptionsColumn.FixedWidth = true;
            this.tlc1.OptionsColumn.ReadOnly = true;
            this.tlc1.VisibleIndex = 0;
            this.tlc1.Width = 40;
            this.tlc2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.tlc2.AppearanceCell.Options.UseFont = true;
            this.tlc2.Caption = "物资编码";
            this.tlc2.FieldName = "物资编码";
            this.tlc2.MinWidth = 40;
            this.tlc2.Name = "tlc2";
            this.tlc2.OptionsColumn.AllowEdit = false;
            this.tlc2.OptionsColumn.AllowMove = false;
            this.tlc2.OptionsColumn.AllowSort = false;
            this.tlc2.OptionsColumn.ReadOnly = true;
            this.tlc2.VisibleIndex = 1;
            this.tlc2.Width = 40;
            this.tlc3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.tlc3.AppearanceCell.Options.UseFont = true;
            this.tlc3.Caption = "物资名称";
            this.tlc3.FieldName = "物资名称";
            this.tlc3.MinWidth = 40;
            this.tlc3.Name = "tlc3";
            this.tlc3.OptionsColumn.AllowEdit = false;
            this.tlc3.OptionsColumn.AllowMove = false;
            this.tlc3.OptionsColumn.AllowSort = false;
            this.tlc3.OptionsColumn.ReadOnly = true;
            this.tlc3.VisibleIndex = 2;
            this.tlc3.Width = 40;
            this.tlc4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.tlc4.AppearanceCell.Options.UseFont = true;
            this.tlc4.Caption = "规格型号图号";
            this.tlc4.FieldName = "作业结果";
            this.tlc4.MinWidth = 40;
            this.tlc4.Name = "tlc4";
            this.tlc4.OptionsColumn.AllowEdit = false;
            this.tlc4.OptionsColumn.AllowMove = false;
            this.tlc4.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.tlc4.OptionsColumn.AllowSort = false;
            this.tlc4.OptionsColumn.ReadOnly = true;
            this.tlc4.VisibleIndex = 3;
            this.tlc4.Width = 60;
            this.tlc5.Caption = "数量";
            this.tlc5.FieldName = "物资名称";
            this.tlc5.Name = "tlc5";
            this.tlc5.OptionsColumn.AllowEdit = false;
            this.tlc5.OptionsColumn.AllowMove = false;
            this.tlc5.OptionsColumn.AllowSort = false;
            this.tlc5.OptionsColumn.ReadOnly = true;
            this.tlc5.VisibleIndex = 4;
            this.tlc5.Width = 30;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x3d5, 0x223);
            base.Controls.Add(this.treeList2);
            base.Controls.Add(this.splitter1);
            base.Controls.Add(this.panel2);
            base.Controls.Add(this.panel1);
            base.Name = "FrmDoorInvAdjust";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDoorInvAdjust";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.treeList1.EndInit();
            this.panel5.ResumeLayout(false);
            this.treeList2.EndInit();
            base.ResumeLayout(false);
        }

        public void InitListTree()
        {
            if (this.m_ntitems != null)
            {
                this.treeList2.Nodes.Clear();
                for (int i = 0; i < this.m_ntitems.Count; i++)
                {
                    NoticeItem item = this.m_ntitems[i];
                    object[] nodeData = new object[] { i, item.invcode, item.invname, item.spectypegraphid, item.plannum.ToString() };
                    this.treeList2.AppendNode(nodeData, -1, 0, 0, 0).Tag = i;
                }
                this.GenRouteS();
            }
        }
    }
}

