namespace VehIC_WF.Setting
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class Setting : Form
    {
        public Common common = null;
        private IContainer components = null;
        public ICReader icreader = null;
        private Panel panel1;
        public RoadBrake roadbrake = null;
        public ScaleDevice scaledevice = null;
        private TabControl tabControl1;
        private TabPage tabPage1;
        public TaskItemView taskview = null;
        private TreeView treeView1;

        public Setting()
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
            TreeNode node = new TreeNode("通用");
            TreeNode node2 = new TreeNode("道闸");
            TreeNode node3 = new TreeNode("读卡器");
            TreeNode node4 = new TreeNode("地磅");
            TreeNode node5 = new TreeNode("设备", new TreeNode[] { node, node2, node3, node4 });
            TreeNode node6 = new TreeNode("作业单条目");
            TreeNode node7 = new TreeNode("显示", new TreeNode[] { node6 });
            this.tabControl1 = new TabControl();
            this.tabPage1 = new TabPage();
            this.treeView1 = new TreeView();
            this.panel1 = new Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            base.SuspendLayout();
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = DockStyle.Left;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.tabControl1.Location = new Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(0xc5, 470);
            this.tabControl1.TabIndex = 2;
            this.tabPage1.Controls.Add(this.treeView1);
            this.tabPage1.Location = new Point(4, 0x17);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new Padding(3);
            this.tabPage1.Size = new Size(0xbd, 0x1bb);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "项目";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.treeView1.BackColor = SystemColors.ControlLightLight;
            this.treeView1.Dock = DockStyle.Left;
            this.treeView1.Location = new Point(3, 3);
            this.treeView1.Name = "treeView1";
            node.Name = "节点1";
            node.Tag = "Common";
            node.Text = "通用";
            node2.Name = "节点1";
            node2.Tag = "RoadBrake";
            node2.Text = "道闸";
            node3.Name = "节点2";
            node3.Tag = "ICReader";
            node3.Text = "读卡器";
            node4.Name = "节点3";
            node4.Tag = "ScaleDevice";
            node4.Text = "地磅";
            node5.Name = "节点0";
            node5.Text = "设备";
            node6.Name = "节点6";
            node6.Tag = "TaskView";
            node6.Text = "作业单条目";
            node7.Name = "节点5";
            node7.Text = "显示";
            this.treeView1.Nodes.AddRange(new TreeNode[] { node5, node7 });
            this.treeView1.Size = new Size(0xc0, 0x1b5);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new TreeViewEventHandler(this.treeView1_AfterSelect);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(0xc5, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x234, 470);
            this.panel1.TabIndex = 3;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x2f9, 470);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.tabControl1);
            base.Name = "Setting";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统设置";
            base.Load += new EventHandler(this.Setting_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            this.treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if ((e.Node != null) && (e.Node.Tag != null))
            {
                string str = e.Node.Tag.ToString();
                if (str != null)
                {
                    if (!(str == "ICReader"))
                    {
                        if (str == "Common")
                        {
                            if (this.common == null)
                            {
                                this.common = new Common();
                                this.common.Dock = DockStyle.Fill;
                                this.panel1.Controls.Add(this.common);
                            }
                            this.common.BringToFront();
                        }
                        else if (str == "RoadBrake")
                        {
                            if (this.roadbrake == null)
                            {
                                this.roadbrake = new RoadBrake();
                                this.roadbrake.Dock = DockStyle.Fill;
                                this.panel1.Controls.Add(this.roadbrake);
                            }
                            this.roadbrake.BringToFront();
                        }
                        else if (str == "ScaleDevice")
                        {
                            if (this.scaledevice == null)
                            {
                                this.scaledevice = new ScaleDevice();
                                this.scaledevice.Dock = DockStyle.Fill;
                                this.panel1.Controls.Add(this.scaledevice);
                            }
                            this.scaledevice.BringToFront();
                        }
                        else if (str == "TaskView")
                        {
                            if (this.taskview == null)
                            {
                                this.taskview = new TaskItemView();
                                this.taskview.Dock = DockStyle.Fill;
                                this.panel1.Controls.Add(this.taskview);
                            }
                            this.taskview.BringToFront();
                        }
                    }
                    else
                    {
                        if (this.icreader == null)
                        {
                            this.icreader = new ICReader();
                            this.icreader.Dock = DockStyle.Fill;
                            this.panel1.Controls.Add(this.icreader);
                        }
                        this.icreader.BringToFront();
                    }
                }
            }
        }
    }
}

