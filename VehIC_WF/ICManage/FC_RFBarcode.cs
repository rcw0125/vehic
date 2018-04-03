namespace VehIC_WF.ICManage
{
    using AxSHDocVw;
    using mshtml;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using VehIC_WF;
    using VehIC_WF.CommonService;
    using VehIC_WF.ICCardManageService;

    public class FC_RFBarcode : UserControl,ICardMessage
    {
        private AxSHDocVw.AxWebBrowser axWebBrowser1;
        private Button button1;
        private Button button3;
        public ICCard card = null;
        public CardList Cards = new CardList();
        private ComboBox cb_vehtype;
        private CheckBox chbox_fixveh;
        private IContainer components = null;
        public VehIC_WF.CommonService.CommonService cs = null;
        public VehIC_WF.ICCardManageService.ICCardManageService IC = null;
        private Label label1;
        private Label label2;
        private Label label25;
        private Label label3;
        private Label label4;
        public string lastrecmsg = string.Empty;
        public long lastrectime = 0L;
        private Panel panel2;
        private Panel panel3;
        public string serverurl = string.Empty;
        public int timelimit = 20;
        private TextBox txt_billno;
        private TextBox txt_icno;
        private TextBox txt_vehno;
        private TextBox txt_vendor;

        public FC_RFBarcode()
        {
            this.InitializeComponent();
        }

        private void axWebBrowser1_NewWindow3(object sender, DWebBrowserEvents2_NewWindow3Event e)
        {
            if (e.bstrUrl.ToLower().Contains("default.aspx"))
            {
                this.axWebBrowser1.Navigate(e.bstrUrl);
                e.cancel = true;
            }
            else
            {
                FrmWebDialog dialog = new FrmWebDialog(e.bstrUrl);
                dialog.ShowDialog();
                e.cancel = true;
                this.InitView(this.GetRFFYDInfo());
                dialog.Text = e.bstrUrl;
            }
        }

        private void axWebBrowser1_WindowClosing(object sender, DWebBrowserEvents2_WindowClosingEvent e)
        {
            e.cancel = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string sourbillno = this.txt_billno.Text.Trim();
                string cph = this.txt_vehno.Text.Trim();
                string vehtype = this.cb_vehtype.Text.Trim();
                string vendor = this.txt_vendor.Text.Trim();
                bool isfix = this.chbox_fixveh.Checked;
                string iCNo = this.card.ICNo;
                string code = FrmMain.localinfo.workpoint.Code;
                string iD = LocalInfo.Current.user.ID;
                AvailableBillInfo[] availableBillInfos = this.IC.GetAvailableBillInfos(cph);
                if (availableBillInfos == null)
                {
                    MessageBox.Show("数据处理错误，请重试！");
                }
                else
                {
                    if (availableBillInfos.Length > 0)
                    {
                        if (availableBillInfos[0].Type == -2)
                        {
                            MessageBox.Show("存在此车辆对应的未完成RF发运作业单，不允许再生成新作业单！");
                            return;
                        }
                        if (availableBillInfos[0].Type == -1)
                        {
                            MessageBox.Show("存在此车辆对应的可用作业单，不允许再生成新作业单！");
                            return;
                        }
                    }
                    if (sourbillno == "")
                    {
                        MessageBox.Show("单据号不能为空！");
                    }
                    else if (vendor == "")
                    {
                        MessageBox.Show("客户不能为空！");
                    }
                    else if ((cph == "") || (vehtype == ""))
                    {
                        MessageBox.Show("请先输入车号并选择车型！");
                    }
                    else if (this.card == null)
                    {
                        MessageBox.Show("请放刷IC卡！");
                    }
                    else
                    {
                        try
                        {
                            Vehic vehicInfo = this.IC.GetVehicInfo(cph);
                            if ((vehicInfo != null) && vehicInfo.InDoor)
                            {
                                MessageBox.Show("车辆状态显示为在厂内，禁止发卡！", "提示");
                                return;
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.ToString());
                            return;
                        }
                        VehIC_WF.ICCardManageService.Result result = this.IC.RFVehCardAssign(iCNo, code, iD, sourbillno, vendor, cph, vehtype, isfix);
                        if (!result.Flag)
                        {
                            MessageBox.Show(result.Desc);
                        }
                        else
                        {
                            this.InitView();
                            this.Cards.Add(new Card(iCNo, DateTime.Now.Ticks));
                            MessageBox.Show("发卡成功，请取走卡！");
                            this.axWebBrowser1.Focus();
                        }
                    }
                }
            }
            catch (Exception exception2)
            {
                MessageBox.Show("数据处理异常！" + exception2.ToString());
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

        private void FC_RFBarcode_Load(object sender, EventArgs e)
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
                string[] vehTypeList = this.IC.GetVehTypeList();
                for (int i = 0; i < vehTypeList.Length; i++)
                {
                    if (!(vehTypeList[i].Trim() == ""))
                    {
                        this.cb_vehtype.Items.Add(vehTypeList[i]);
                    }
                }
                this.cb_vehtype.SelectedIndex = -1;
                this.serverurl = this.cs.GetThridUrl() + "login.aspx?un=0";
                this.axWebBrowser1.Navigate(this.serverurl);
            }
            catch (Exception exception)
            {
                MessageBox.Show("初始化数据时出错！\r\n" + exception.ToString());
            }
        }

        private string[] GetRFFYDInfo()
        {
            string[] strArray = new string[3];
            try
            {
                HTMLDocument document = (HTMLDocument) this.axWebBrowser1.Document;
                if (!document.url.ToLower().Contains("default.aspx"))
                {
                    return null;
                }
                FramesCollection frames = document.parentWindow.frames;
                for (int i = 0; i < frames.length; i++)
                {
                    object pvarIndex = i;
                    mshtml.IHTMLWindow2 window2 = (mshtml.IHTMLWindow2) frames.item(ref pvarIndex);
                    FramesCollection framess2 = window2.frames;
                    string tagName = "";
                    for (int j = 0; j < framess2.length; j++)
                    {
                        object obj3 = j;
                        mshtml.IHTMLWindow2 window3 = (mshtml.IHTMLWindow2) framess2.item(ref obj3);
                        HTMLDocument document2 = window3.document as HTMLDocument;
                        if (document2.url.Contains("InDoor.aspx"))
                        {
                            HTMLTextAreaElement element = document2.getElementById("txtCPH") as HTMLTextAreaElement;
                            HTMLTable table = document2.getElementById("GridView1") as HTMLTable;
                            bool flag = false;
                            foreach (HTMLTableRow row in table.rows)
                            {
                                foreach (HTMLTableCell cell in row.cells)
                                {
                                    foreach (mshtml.IHTMLElement element2 in cell.getElementsByTagName("INPUT"))
                                    {
                                        if ((element2.getAttribute("type", 0).ToString() == "checkbox") && (element2.getAttribute("checked", 0).ToString().ToUpper() == "TRUE"))
                                        {
                                            tagName = cell.tagName;
                                            flag = true;
                                        }
                                    }
                                    if (flag)
                                    {
                                        if (cell.cellIndex == 3)
                                        {
                                            strArray[0] = cell.innerText;
                                        }
                                        if (cell.cellIndex == 1)
                                        {
                                            strArray[1] = cell.innerText;
                                        }
                                        if (cell.cellIndex == 4)
                                        {
                                            strArray[2] = cell.innerText;
                                        }
                                    }
                                }
                                if (flag)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                return strArray;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FC_RFBarcode));
            this.panel3 = new Panel();
            this.chbox_fixveh = new CheckBox();
            this.txt_vendor = new TextBox();
            this.label4 = new Label();
            this.cb_vehtype = new ComboBox();
            this.label25 = new Label();
            this.txt_vehno = new TextBox();
            this.label3 = new Label();
            this.txt_billno = new TextBox();
            this.label2 = new Label();
            this.panel2 = new Panel();
            this.button3 = new Button();
            this.txt_icno = new TextBox();
            this.label1 = new Label();
            this.button1 = new Button();
            this.axWebBrowser1 = new AxSHDocVw.AxWebBrowser();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.axWebBrowser1.BeginInit();
            base.SuspendLayout();
            this.panel3.Controls.Add(this.chbox_fixveh);
            this.panel3.Controls.Add(this.txt_vendor);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cb_vehtype);
            this.panel3.Controls.Add(this.label25);
            this.panel3.Controls.Add(this.txt_vehno);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txt_billno);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.txt_icno);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = DockStyle.Top;
            this.panel3.Location = new Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(0x385, 0x43);
            this.panel3.TabIndex = 170;
            this.chbox_fixveh.AutoSize = true;
            this.chbox_fixveh.Enabled = false;
            this.chbox_fixveh.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.chbox_fixveh.Location = new Point(0x1e1, 0x26);
            this.chbox_fixveh.Name = "chbox_fixveh";
            this.chbox_fixveh.Size = new Size(0x5b, 20);
            this.chbox_fixveh.TabIndex = 0xd4;
            this.chbox_fixveh.Text = "固定车辆";
            this.chbox_fixveh.UseVisualStyleBackColor = true;
            this.txt_vendor.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_vendor.Location = new Point(0x200, 7);
            this.txt_vendor.Margin = new Padding(4);
            this.txt_vendor.Name = "txt_vendor";
            this.txt_vendor.ReadOnly = true;
            this.txt_vendor.Size = new Size(0xc4, 0x17);
            this.txt_vendor.TabIndex = 0xb2;
            this.txt_vendor.TextAlign = HorizontalAlignment.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label4.Location = new Point(0x1de, 11);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x23, 14);
            this.label4.TabIndex = 0xb1;
            this.label4.Text = "客商";
            this.cb_vehtype.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cb_vehtype.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.cb_vehtype.FormattingEnabled = true;
            this.cb_vehtype.Location = new Point(0x36, 0x23);
            this.cb_vehtype.Name = "cb_vehtype";
            this.cb_vehtype.Size = new Size(0x87, 0x16);
            this.cb_vehtype.TabIndex = 0xb0;
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label25.Location = new Point(0x16, 0x27);
            this.label25.Margin = new Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new Size(0x23, 14);
            this.label25.TabIndex = 0xaf;
            this.label25.Text = "车型";
            this.txt_vehno.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_vehno.Location = new Point(0x125, 0x23);
            this.txt_vehno.Margin = new Padding(4);
            this.txt_vehno.Name = "txt_vehno";
            this.txt_vehno.ReadOnly = true;
            this.txt_vehno.Size = new Size(0x87, 0x17);
            this.txt_vehno.TabIndex = 0xae;
            this.txt_vehno.TextAlign = HorizontalAlignment.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label3.Location = new Point(0xf6, 0x27);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x31, 14);
            this.label3.TabIndex = 0xad;
            this.label3.Text = "车牌号";
            this.txt_billno.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_billno.Location = new Point(0x125, 7);
            this.txt_billno.Margin = new Padding(4);
            this.txt_billno.Name = "txt_billno";
            this.txt_billno.ReadOnly = true;
            this.txt_billno.Size = new Size(0x87, 0x17);
            this.txt_billno.TabIndex = 0xac;
            this.txt_billno.TextAlign = HorizontalAlignment.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label2.Location = new Point(0xf6, 11);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x31, 14);
            this.label2.TabIndex = 0xab;
            this.label2.Text = "单据号";
            this.panel2.Controls.Add(this.button3);
            this.panel2.Dock = DockStyle.Right;
            this.panel2.Location = new Point(0x323, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x62, 0x43);
            this.panel2.TabIndex = 170;
            this.button3.Location = new Point(2, 0x11);
            this.button3.Name = "button3";
            this.button3.Size = new Size(0x51, 0x1d);
            this.button3.TabIndex = 0x8e;
            this.button3.Text = "发卡";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click);
            this.txt_icno.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_icno.Location = new Point(0x36, 7);
            this.txt_icno.Margin = new Padding(4);
            this.txt_icno.Name = "txt_icno";
            this.txt_icno.ReadOnly = true;
            this.txt_icno.Size = new Size(0x87, 0x17);
            this.txt_icno.TabIndex = 0xa9;
            this.txt_icno.TextAlign = HorizontalAlignment.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label1.Location = new Point(8, 11);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x31, 14);
            this.label1.TabIndex = 0xa8;
            this.label1.Text = "IC卡号";
            this.button1.Location = new Point(0x11, 0x15a);
            this.button1.Name = "button1";
            this.button1.Size = new Size(100, 0x25);
            this.button1.TabIndex = 0xa7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.axWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWebBrowser1.Enabled = true;
            this.axWebBrowser1.Location = new Point(0, 0x43);
            this.axWebBrowser1.OcxState = (AxHost.State) resources.GetObject("axWebBrowser1.OcxState");
            this.axWebBrowser1.Size = new Size(0x385, 0x221);
            this.axWebBrowser1.TabIndex = 0xab;
            this.axWebBrowser1.NewWindow3 += new DWebBrowserEvents2_NewWindow3EventHandler(this.axWebBrowser1_NewWindow3);
            this.axWebBrowser1.WindowClosing += new DWebBrowserEvents2_WindowClosingEventHandler(this.axWebBrowser1_WindowClosing);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.axWebBrowser1);
            base.Controls.Add(this.panel3);
            base.Name = "FC_RFBarcode";
            base.Size = new Size(0x385, 0x264);
            base.Load += new EventHandler(this.FC_RFBarcode_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.axWebBrowser1.EndInit();
            base.ResumeLayout(false);
        }

        public void InitView()
        {
            this.card = null;
            this.txt_billno.Text = string.Empty;
            this.txt_icno.Text = string.Empty;
            this.txt_vehno.Text = string.Empty;
            this.cb_vehtype.SelectedIndex = -1;
            this.txt_vendor.Text = string.Empty;
            this.chbox_fixveh.Checked = false;
        }

        public void InitView(string[] fields)
        {
            this.InitView();
            if ((((fields != null) && (fields.Length == 3)) && (fields[0].Trim() != string.Empty)) && ((fields[1].Trim() != string.Empty) && (fields[2].Trim() != string.Empty)))
            {
                this.txt_vehno.Text = fields[0].Trim();
                this.txt_billno.Text = fields[1].Trim();
                this.txt_vendor.Text = fields[2].Trim();
                string vehTypeByVehNo = this.IC.GetVehTypeByVehNo(this.txt_vehno.Text.Trim());
                this.cb_vehtype.SelectedIndex = this.cb_vehtype.Items.IndexOf(vehTypeByVehNo);
                if (this.IC.ISFixVeh(fields[0].Trim()))
                {
                    this.chbox_fixveh.Checked = true;
                }
            }
        }

        public void HandleCardMessage(Device.CardReader device, string cardid)
        {
            if (this.CheckCardID(cardid) && this.Cards.CheckCard(cardid))
            {
                string str = this.txt_vehno.Text.Trim();
                if (str == string.Empty)
                {
                    MessageBox.Show("车号为空，请先选发运单，后刷卡！");
                }
                else
                {
                    this.card = null;
                    ICCard tempCard = this.IC.GetCard(cardid);
                    if (tempCard.CardNo == string.Empty)
                    {
                        MessageBox.Show("此卡还没有注册！");
                    }
                    else
                    {
                        RFFYD rFFYDByICID = this.cs.GetRFFYDByICID(cardid);
                        if (((rFFYDByICID != null) && (rFFYDByICID.billno != string.Empty)) && (rFFYDByICID.status == "0"))
                        {
                            FrmRFCancel cancel = new FrmRFCancel(rFFYDByICID, tempCard);
                            if (cancel.ShowDialog() == DialogResult.OK)
                            {
                                this.Cards.DeleteCard(cardid);
                            }
                        }
                        else
                        {
                            if (this.chbox_fixveh.Checked)
                            {
                                if (tempCard.Ictype != 2)
                                {
                                    MessageBox.Show("当前是固定车辆发运单,请刷多次车辆卡进行确认!");
                                    return;
                                }
                                Bill_FixVehCard fixVehCardBillEx = this.IC.GetFixVehCardBillEx(tempCard.DJH.Trim());
                                if (fixVehCardBillEx == null)
                                {
                                    MessageBox.Show("获取多次车辆发卡单失败！\r\nIC卡号：" + tempCard.CardNo);
                                    return;
                                }
                                if (fixVehCardBillEx.VehID != str)
                                {
                                    MessageBox.Show("多次卡的车牌号与单据的车牌号不一致!");
                                    return;
                                }
                            }
                            else if (tempCard.Status != 0)
                            {
                                MessageBox.Show("卡" + tempCard.CardNo + "当前状态不允许发卡！");
                                return;
                            }
                            this.card = tempCard;
                            this.txt_icno.Text = tempCard.CardNo;
                        }
                    }
                }
            }
        }
    }
}

