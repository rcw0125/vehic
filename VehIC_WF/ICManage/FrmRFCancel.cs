namespace VehIC_WF.ICManage
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using VehIC_WF;
    using VehIC_WF.CommonService;
    using VehIC_WF.ICCardManageService;

    public class FrmRFCancel : Form
    {
        private Button btn_exit;
        private Button btn_update;
        public ICCard card = null;
        private CheckBox chbox_fixveh;
        private IContainer components = null;
        public RFFYD fyd = null;
        public VehIC_WF.ICCardManageService.ICCardManageService IC = null;
        private Label label1;
        private Label label12;
        private Label label15;
        private Label label19;
        private Label label2;
        private Label label24;
        private Label label25;
        private Label label3;
        private TextBox txt_bill_CardNo;
        private TextBox txt_bill_Dept;
        private TextBox txt_bill_SBillID;
        private TextBox txt_bill_TaskID;
        private TextBox txt_bill_TaskStatus;
        private TextBox txt_bill_TaskTime;
        private TextBox txt_bill_VehNo;
        private TextBox txt_bill_VehType;

        public FrmRFCancel(RFFYD fyd, ICCard TempCard)
        {
            this.InitializeComponent();
            this.fyd = fyd;
            this.card = TempCard;
            base.DialogResult = DialogResult.Cancel;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要撤销此作业单吗？", "提示", MessageBoxButtons.OKCancel) != DialogResult.Cancel)
            {
                try
                {
                    string code = FrmMain.localinfo.workpoint.Code;
                    string iD = LocalInfo.Current.user.ID;
                    VehIC_WF.ICCardManageService.Result result2 = this.IC.RFVehCardCancel(this.card.ICNo, this.fyd.billno, code, iD, this.chbox_fixveh.Checked);
                    if (result2.Flag)
                    {
                        MessageBox.Show("操作成功！");
                        base.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("操作失败\n" + result2.Desc + "\n请重试！");
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("操作失败\n" + exception.ToString());
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmRFCancel_Load(object sender, EventArgs e)
        {
            this.IC = new VehIC_WF.ICCardManageService.ICCardManageService();
            if (!FrmMain.Debug)
            {
                this.IC.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/ICCardManageService.asmx";
            }
            this.Init();
        }

        public void Init()
        {
            this.txt_bill_CardNo.Text = this.card.CardNo;
            this.txt_bill_TaskID.Text = this.fyd.billno;
            this.txt_bill_TaskStatus.Text = "发卡";
            this.txt_bill_TaskTime.Text = this.fyd.date;
            this.txt_bill_SBillID.Text = this.fyd.fydh;
            this.txt_bill_VehNo.Text = this.fyd.vehno;
            this.txt_bill_VehType.Text = this.IC.GetVehTypeByVehNo(this.fyd.vehno);
            this.chbox_fixveh.Checked = this.IC.ISFixVeh(this.fyd.vehno);
            this.txt_bill_Dept.Text = this.fyd.Vendor;
        }

        private void InitializeComponent()
        {
            this.txt_bill_Dept = new TextBox();
            this.label25 = new Label();
            this.txt_bill_VehNo = new TextBox();
            this.label24 = new Label();
            this.txt_bill_VehType = new TextBox();
            this.label19 = new Label();
            this.txt_bill_SBillID = new TextBox();
            this.label15 = new Label();
            this.txt_bill_TaskID = new TextBox();
            this.label12 = new Label();
            this.chbox_fixveh = new CheckBox();
            this.txt_bill_CardNo = new TextBox();
            this.label1 = new Label();
            this.txt_bill_TaskStatus = new TextBox();
            this.label2 = new Label();
            this.txt_bill_TaskTime = new TextBox();
            this.label3 = new Label();
            this.btn_exit = new Button();
            this.btn_update = new Button();
            base.SuspendLayout();
            this.txt_bill_Dept.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_bill_Dept.Location = new Point(0x61, 0xf8);
            this.txt_bill_Dept.Margin = new Padding(4);
            this.txt_bill_Dept.Name = "txt_bill_Dept";
            this.txt_bill_Dept.ReadOnly = true;
            this.txt_bill_Dept.Size = new Size(0x281, 0x17);
            this.txt_bill_Dept.TabIndex = 0x177;
            this.txt_bill_Dept.TextAlign = HorizontalAlignment.Right;
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label25.Location = new Point(0x40, 0xfb);
            this.label25.Margin = new Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new Size(0x23, 14);
            this.label25.TabIndex = 0x176;
            this.label25.Text = "单位";
            this.txt_bill_VehNo.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_bill_VehNo.Location = new Point(0x61, 0xd4);
            this.txt_bill_VehNo.Margin = new Padding(4);
            this.txt_bill_VehNo.Name = "txt_bill_VehNo";
            this.txt_bill_VehNo.ReadOnly = true;
            this.txt_bill_VehNo.Size = new Size(0xa4, 0x17);
            this.txt_bill_VehNo.TabIndex = 0x175;
            this.txt_bill_VehNo.TextAlign = HorizontalAlignment.Right;
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label24.Location = new Point(50, 0xd8);
            this.label24.Margin = new Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new Size(0x31, 14);
            this.label24.TabIndex = 0x174;
            this.label24.Text = "车牌号";
            this.txt_bill_VehType.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_bill_VehType.Location = new Point(0x174, 0xd4);
            this.txt_bill_VehType.Margin = new Padding(4);
            this.txt_bill_VehType.Name = "txt_bill_VehType";
            this.txt_bill_VehType.ReadOnly = true;
            this.txt_bill_VehType.Size = new Size(0xa4, 0x17);
            this.txt_bill_VehType.TabIndex = 0x173;
            this.txt_bill_VehType.TextAlign = HorizontalAlignment.Right;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label19.Location = new Point(0x152, 0xd8);
            this.label19.Margin = new Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new Size(0x23, 14);
            this.label19.TabIndex = 370;
            this.label19.Text = "车型";
            this.txt_bill_SBillID.AcceptsReturn = true;
            this.txt_bill_SBillID.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_bill_SBillID.Location = new Point(0x61, 0xb0);
            this.txt_bill_SBillID.Margin = new Padding(4);
            this.txt_bill_SBillID.Name = "txt_bill_SBillID";
            this.txt_bill_SBillID.ReadOnly = true;
            this.txt_bill_SBillID.Size = new Size(0xa4, 0x17);
            this.txt_bill_SBillID.TabIndex = 0x16d;
            this.txt_bill_SBillID.TextAlign = HorizontalAlignment.Right;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label15.Location = new Point(0x24, 180);
            this.label15.Margin = new Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new Size(0x3f, 14);
            this.label15.TabIndex = 0x16c;
            this.label15.Text = "源单据号";
            this.txt_bill_TaskID.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_bill_TaskID.Location = new Point(0x61, 0x40);
            this.txt_bill_TaskID.Margin = new Padding(4);
            this.txt_bill_TaskID.Name = "txt_bill_TaskID";
            this.txt_bill_TaskID.ReadOnly = true;
            this.txt_bill_TaskID.Size = new Size(0xa4, 0x17);
            this.txt_bill_TaskID.TabIndex = 0x169;
            this.txt_bill_TaskID.TextAlign = HorizontalAlignment.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label12.Location = new Point(0x24, 0x44);
            this.label12.Margin = new Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x3f, 14);
            this.label12.TabIndex = 360;
            this.label12.Text = "作业单号";
            this.chbox_fixveh.AutoSize = true;
            this.chbox_fixveh.Enabled = false;
            this.chbox_fixveh.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.chbox_fixveh.Location = new Point(0x287, 0xd5);
            this.chbox_fixveh.Name = "chbox_fixveh";
            this.chbox_fixveh.Size = new Size(0x5b, 20);
            this.chbox_fixveh.TabIndex = 0x17a;
            this.chbox_fixveh.Text = "固定车辆";
            this.chbox_fixveh.UseVisualStyleBackColor = true;
            this.txt_bill_CardNo.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_bill_CardNo.Location = new Point(0x61, 0x1b);
            this.txt_bill_CardNo.Margin = new Padding(4);
            this.txt_bill_CardNo.Name = "txt_bill_CardNo";
            this.txt_bill_CardNo.ReadOnly = true;
            this.txt_bill_CardNo.Size = new Size(0xa4, 0x17);
            this.txt_bill_CardNo.TabIndex = 380;
            this.txt_bill_CardNo.TextAlign = HorizontalAlignment.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label1.Location = new Point(50, 0x1f);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x31, 14);
            this.label1.TabIndex = 0x17b;
            this.label1.Text = "IC卡号";
            this.txt_bill_TaskStatus.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_bill_TaskStatus.Location = new Point(0x61, 0x65);
            this.txt_bill_TaskStatus.Margin = new Padding(4);
            this.txt_bill_TaskStatus.Name = "txt_bill_TaskStatus";
            this.txt_bill_TaskStatus.ReadOnly = true;
            this.txt_bill_TaskStatus.Size = new Size(0xa4, 0x17);
            this.txt_bill_TaskStatus.TabIndex = 0x17e;
            this.txt_bill_TaskStatus.TextAlign = HorizontalAlignment.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label2.Location = new Point(0x15, 0x69);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x4d, 14);
            this.label2.TabIndex = 0x17d;
            this.label2.Text = "作业单状态";
            this.txt_bill_TaskTime.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_bill_TaskTime.Location = new Point(0x61, 0x8a);
            this.txt_bill_TaskTime.Margin = new Padding(4);
            this.txt_bill_TaskTime.Name = "txt_bill_TaskTime";
            this.txt_bill_TaskTime.ReadOnly = true;
            this.txt_bill_TaskTime.Size = new Size(0xa4, 0x17);
            this.txt_bill_TaskTime.TabIndex = 0x180;
            this.txt_bill_TaskTime.TextAlign = HorizontalAlignment.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label3.Location = new Point(0x23, 0x8e);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x3f, 14);
            this.label3.TabIndex = 0x17f;
            this.label3.Text = "单据时间";
            this.btn_exit.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.btn_exit.Location = new Point(0x1f5, 0x153);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new Size(100, 0x21);
            this.btn_exit.TabIndex = 0x184;
            this.btn_exit.Text = "返回";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new EventHandler(this.btn_exit_Click);
            this.btn_update.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.btn_update.Location = new Point(0x27e, 0x153);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new Size(100, 0x21);
            this.btn_update.TabIndex = 0x183;
            this.btn_update.Text = "撤销发卡";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new EventHandler(this.btn_update_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x303, 0x1a9);
            base.Controls.Add(this.btn_exit);
            base.Controls.Add(this.btn_update);
            base.Controls.Add(this.txt_bill_TaskTime);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.txt_bill_TaskStatus);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.txt_bill_CardNo);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.chbox_fixveh);
            base.Controls.Add(this.txt_bill_Dept);
            base.Controls.Add(this.label25);
            base.Controls.Add(this.txt_bill_VehNo);
            base.Controls.Add(this.label24);
            base.Controls.Add(this.txt_bill_VehType);
            base.Controls.Add(this.label19);
            base.Controls.Add(this.txt_bill_SBillID);
            base.Controls.Add(this.label15);
            base.Controls.Add(this.txt_bill_TaskID);
            base.Controls.Add(this.label12);
            base.Name = "FrmRFCancel";
            this.Text = "RF作业单撤销发卡";
            base.Load += new EventHandler(this.FrmRFCancel_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

