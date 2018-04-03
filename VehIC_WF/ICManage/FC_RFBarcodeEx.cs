namespace VehIC_WF.ICManage
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using VehIC_WF;
    using VehIC_WF.CommonService;
    using VehIC_WF.ICCardManageService;

    public class FC_RFBarcodeEx : UserControl,ICardMessage
    {
        private Button btn_ok;
        public ICCard card = null;
        private IContainer components = null;
        public VehIC_WF.CommonService.CommonService cs = null;
        public RFFYD FYD = null;
        public VehIC_WF.ICCardManageService.ICCardManageService IC = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label9;
        public string lastrecmsg = string.Empty;
        public long lastrectime = 0L;
        private ListBox listBox1;
        public int timelimit = 20;
        private TextBox txt_billno;
        private TextBox txt_Date;
        private TextBox txt_icno;
        private TextBox txt_status;
        private TextBox txt_vehno;
        private TextBox txt_vehtype;
        private TextBox txt_vendor;

        public FC_RFBarcodeEx()
        {
            this.InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if ((this.FYD != null) && (this.card != null))
            {
                if (this.IC.ISFixVeh(this.FYD.vehno))
                {
                    MessageBox.Show("固定车辆请做多次卡车辆发卡单进行补卡！");
                }
                else
                {
                    try
                    {
                        string code = FrmMain.localinfo.workpoint.Code;
                        string iD = LocalInfo.Current.user.ID;
                        VehIC_WF.CommonService.Result result = this.cs.UpdateFYDBillCard(this.FYD.billno, this.card.ICNo, code, iD);
                        if (!result.Flag)
                        {
                            MessageBox.Show(result.Desc);
                        }
                        else
                        {
                            MessageBox.Show("补卡成功！");
                            this.card = null;
                            this.FYD = null;
                            this.InitForm();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("数据异常，请重试！");
                    }
                }
            }
        }

        public bool CheckCardID(string cardid)
        {
            if ((this.lastrecmsg == cardid) && (((DateTime.Now.Ticks - this.lastrectime) / 0x989680L) < this.timelimit))
            {
                return false;
            }
            this.lastrecmsg = cardid;
            this.lastrectime = DateTime.Now.Ticks;
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FC_RFBarcodeEx_Load(object sender, EventArgs e)
        {
            try
            {
                this.cs = new VehIC_WF.CommonService.CommonService();
                this.IC = new VehIC_WF.ICCardManageService.ICCardManageService();
                if (!FrmMain.Debug)
                {
                    this.cs.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/CommonService.asmx";
                    this.IC.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/ICCardManageService.asmx";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("初始化数据时出错！\r\n" + exception.ToString());
            }
        }

        public bool FillListView(string vehnoex)
        {
            try
            {
                string[] strArray = this.IC.QueryAvailableVehNoOfRFFYD(vehnoex);
                if ((strArray == null) && (strArray.Length == 0))
                {
                    return false;
                }
                for (int i = 0; i < strArray.Length; i++)
                {
                    this.listBox1.Items.Add(strArray[i]);
                }
                if (strArray.Length == 1)
                {
                    this.listBox1.Height = 30;
                }
                else if (strArray.Length < 4)
                {
                    this.listBox1.Height = (this.listBox1.ItemHeight + 1) * strArray.Length;
                }
                else
                {
                    this.listBox1.Height = (this.listBox1.ItemHeight + 1) * 4;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool GetBillInfo()
        {
            try
            {
                string cph = this.txt_vehno.Text.Trim();
                if (cph == string.Empty)
                {
                    return false;
                }
                RFFYD[] rFFYD = this.cs.GetRFFYD(cph);
                if (rFFYD == null)
                {
                    MessageBox.Show("找不到对应的RF发运单！");
                    return false;
                }
                if (rFFYD.Length > 1)
                {
                    MessageBox.Show("存在多个对应的RF发运单！");
                    return false;
                }
                this.FYD = rFFYD[0];
                this.ViewBill();
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("网络处理错误" + exception.ToString());
                return false;
            }
        }

        private void InitForm()
        {
            this.txt_billno.Text = "";
            this.txt_Date.Text = "";
            this.txt_status.Text = "";
            this.txt_icno.Text = "";
            this.txt_vehno.Text = "";
            this.txt_vehtype.Text = "";
            this.txt_vendor.Text = "";
        }

        private void InitializeComponent()
        {
            this.txt_vehtype = new TextBox();
            this.label1 = new Label();
            this.listBox1 = new ListBox();
            this.btn_ok = new Button();
            this.txt_vehno = new TextBox();
            this.label9 = new Label();
            this.txt_icno = new TextBox();
            this.label2 = new Label();
            this.txt_billno = new TextBox();
            this.label3 = new Label();
            this.txt_Date = new TextBox();
            this.label4 = new Label();
            this.txt_status = new TextBox();
            this.label5 = new Label();
            this.txt_vendor = new TextBox();
            this.label6 = new Label();
            base.SuspendLayout();
            this.txt_vehtype.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_vehtype.Location = new Point(0x5d, 0x94);
            this.txt_vehtype.Margin = new Padding(4);
            this.txt_vehtype.Name = "txt_vehtype";
            this.txt_vehtype.ReadOnly = true;
            this.txt_vehtype.Size = new Size(0xbd, 0x17);
            this.txt_vehtype.TabIndex = 0xd8;
            this.txt_vehtype.TextAlign = HorizontalAlignment.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label1.Location = new Point(60, 0x97);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x23, 14);
            this.label1.TabIndex = 0xd7;
            this.label1.Text = "车型";
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new Point(0x5d, 0x74);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBox1.Size = new Size(0xbd, 14);
            this.listBox1.TabIndex = 0xd9;
            this.listBox1.Visible = false;
            this.listBox1.DoubleClick += new EventHandler(this.listBox1_DoubleClick);
            this.listBox1.KeyUp += new KeyEventHandler(this.listBox1_KeyUp);
            this.btn_ok.Location = new Point(0x2ba, 0x31);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new Size(0x66, 0x1d);
            this.btn_ok.TabIndex = 0xd6;
            this.btn_ok.Text = "补卡";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new EventHandler(this.btn_ok_Click);
            this.txt_vehno.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_vehno.Location = new Point(0x5d, 0x5d);
            this.txt_vehno.Margin = new Padding(4);
            this.txt_vehno.Name = "txt_vehno";
            this.txt_vehno.Size = new Size(0xbd, 0x17);
            this.txt_vehno.TabIndex = 0xd5;
            this.txt_vehno.TextAlign = HorizontalAlignment.Right;
            this.txt_vehno.KeyUp += new KeyEventHandler(this.txt_vehno_KeyUp);
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label9.Location = new Point(0x2e, 0x61);
            this.label9.Margin = new Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x31, 14);
            this.label9.TabIndex = 0xd4;
            this.label9.Text = "车牌号";
            this.txt_icno.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_icno.Location = new Point(0x5d, 0x2e);
            this.txt_icno.Margin = new Padding(4);
            this.txt_icno.Name = "txt_icno";
            this.txt_icno.ReadOnly = true;
            this.txt_icno.Size = new Size(0xbd, 0x17);
            this.txt_icno.TabIndex = 0xdb;
            this.txt_icno.TextAlign = HorizontalAlignment.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label2.Location = new Point(0x2e, 50);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x31, 14);
            this.label2.TabIndex = 0xda;
            this.label2.Text = "IC卡号";
            this.txt_billno.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_billno.Location = new Point(0x5d, 0xc1);
            this.txt_billno.Margin = new Padding(4);
            this.txt_billno.Name = "txt_billno";
            this.txt_billno.ReadOnly = true;
            this.txt_billno.Size = new Size(0xbd, 0x17);
            this.txt_billno.TabIndex = 0xdd;
            this.txt_billno.TextAlign = HorizontalAlignment.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label3.Location = new Point(0x2e, 0xc5);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x31, 14);
            this.label3.TabIndex = 220;
            this.label3.Text = "单据号";
            this.txt_Date.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_Date.Location = new Point(0x5d, 0x111);
            this.txt_Date.Margin = new Padding(4);
            this.txt_Date.Name = "txt_Date";
            this.txt_Date.ReadOnly = true;
            this.txt_Date.Size = new Size(0xbd, 0x17);
            this.txt_Date.TabIndex = 0xdf;
            this.txt_Date.TextAlign = HorizontalAlignment.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label4.Location = new Point(0x1f, 0x115);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x3f, 14);
            this.label4.TabIndex = 0xde;
            this.label4.Text = "进厂时间";
            this.txt_status.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_status.Location = new Point(0x5d, 0x13e);
            this.txt_status.Margin = new Padding(4);
            this.txt_status.Name = "txt_status";
            this.txt_status.ReadOnly = true;
            this.txt_status.Size = new Size(0xbd, 0x17);
            this.txt_status.TabIndex = 0xe1;
            this.txt_status.TextAlign = HorizontalAlignment.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label5.Location = new Point(0x3a, 0x142);
            this.label5.Margin = new Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x23, 14);
            this.label5.TabIndex = 0xe0;
            this.label5.Text = "状态";
            this.txt_vendor.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_vendor.Location = new Point(0x5d, 0xe8);
            this.txt_vendor.Margin = new Padding(4);
            this.txt_vendor.Name = "txt_vendor";
            this.txt_vendor.ReadOnly = true;
            this.txt_vendor.Size = new Size(0xbd, 0x17);
            this.txt_vendor.TabIndex = 0xe3;
            this.txt_vendor.TextAlign = HorizontalAlignment.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label6.Location = new Point(0x2e, 0xec);
            this.label6.Margin = new Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x23, 14);
            this.label6.TabIndex = 0xe2;
            this.label6.Text = "客商";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.txt_vendor);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.txt_status);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.txt_Date);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.txt_billno);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.txt_icno);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.txt_vehtype);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.listBox1);
            base.Controls.Add(this.btn_ok);
            base.Controls.Add(this.txt_vehno);
            base.Controls.Add(this.label9);
            base.Name = "FC_RFBarcodeEx";
            base.Size = new Size(0x385, 0x264);
            base.Load += new EventHandler(this.FC_RFBarcodeEx_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex != -1)
            {
                this.txt_vehno.Text = this.listBox1.Text;
                this.listBox1.Visible = false;
                this.txt_vehno.SelectionStart = this.txt_vehno.Text.Length;
                this.txt_vehno.Focus();
                if (!this.GetBillInfo())
                {
                    this.card = null;
                    this.InitForm();
                }
            }
        }

        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    this.txt_vehno.Text = this.listBox1.Text;
                    this.listBox1.Visible = false;
                    this.txt_vehno.SelectionStart = this.txt_vehno.Text.Length;
                    this.txt_vehno.Focus();
                    if (!this.GetBillInfo())
                    {
                        this.card = null;
                        this.InitForm();
                    }
                    break;

                case 0x1b:
                    this.listBox1.Visible = false;
                    this.txt_vehno.Focus();
                    break;
            }
        }

        public void HandleCardMessage(Device.CardReader device, string cardid)
        {
            try
            {
                if (this.CheckCardID(cardid))
                {
                    this.card = this.IC.GetCard(cardid);
                    if (this.card.CardNo == string.Empty)
                    {
                        MessageBox.Show("此卡还没有注册！");
                        this.card = null;
                    }
                    else if (this.card.Status != 0)
                    {
                        MessageBox.Show("卡[" + this.card.CardNo + "]当前状态不允许发卡！");
                        this.card = null;
                    }
                    else
                    {
                        this.txt_icno.Text = this.card.CardNo;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void txt_vehno_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    this.listBox1.Visible = false;
                    if (!this.GetBillInfo())
                    {
                        this.card = null;
                        this.InitForm();
                    }
                    return;

                case 0x1b:
                    if (this.listBox1.Visible)
                    {
                        this.listBox1.Visible = false;
                        this.txt_vehno.Focus();
                    }
                    return;

                case 0x20:
                    this.listBox1.Visible = false;
                    return;

                case 40:
                    if (this.listBox1.Visible)
                    {
                        this.listBox1.Focus();
                        this.listBox1.SetSelected(0, true);
                    }
                    return;
            }
            string vehnoex = this.txt_vehno.Text.Trim();
            if ((vehnoex != "") && (vehnoex.Length > 1))
            {
                this.listBox1.Items.Clear();
                this.listBox1.Visible = this.FillListView(vehnoex);
            }
            else
            {
                this.listBox1.Visible = false;
            }
        }

        public void ViewBill()
        {
            this.txt_billno.Text = this.FYD.fydh;
            this.txt_Date.Text = this.FYD.date;
            this.txt_status.Text = (this.FYD.status == "0") ? "发卡" : "进厂";
            this.txt_vehno.Text = this.FYD.vehno;
            string vehTypeByVehNo = this.IC.GetVehTypeByVehNo(this.FYD.vehno);
            this.txt_vehtype.Text = vehTypeByVehNo;
            this.txt_vendor.Text = this.FYD.Vendor;
        }
    }
}

