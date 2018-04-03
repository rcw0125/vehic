namespace VehIC_WF.ICManage
{
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using VehIC_WF;
    using VehIC_WF.CommonService;
    using VehIC_WF.ICCardManageService;
    using VehIC_WF.Utility;

    public class FC_MatVehCard : UserControl,ICardMessage
    {
        public Bill_Available[] Bills = null;
        private Button button1;
        private Button button4;
        public ICCard card = null;
        private ComboBox cb_vehtype;
        private CheckBox chbox_fixveh;
        private IContainer components = null;
        public VehIC_WF.CommonService.CommonService cs = null;
        public AvailableBillInfo CurBillInfo = null;
        public bool fixveh = false;
        public VehIC_WF.ICCardManageService.ICCardManageService IC = null;
        private ImageList imageList1;
        private bool insertqtxhsl = false;
        private Label label1;
        private Label label2;
        private Label label22;
        private Label label25;
        private Label label3;
        private Label label4;
        public string lastrecmsg = string.Empty;
        public long lastrectime = 0L;
        public string LastVehNo = string.Empty;
        private ListBox listBox1;
        public NoticeItems NTItems = null;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private RepositoryItemCheckEdit repositoryItemCheckEdit1;
        public int timelimit = 20;
        private TreeListColumn tlc1;
        private TreeListColumn tlc2;
        private TreeListColumn tlc3;
        private TreeListColumn tlc4;
        private TreeListColumn tlc5;
        private TreeListColumn tlc6;
        private TreeListColumn tlc7;
        private TreeListColumn tlc8;
        private ToolTip toolTip1;
        private TreeList treeList1;
        private TextBox txt_billType;
        private TextBox txt_icnno;
        private TextBox txt_remark;
        private TextBox txt_vehno;
        private TextBox txt_wzlx;

        public FC_MatVehCard()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (((this.Bills != null) && (this.CurBillInfo != null)) && (this.txt_vehno.Text.Trim() != string.Empty))
            {
                try
                {
                    Vehic vehicInfo = this.IC.GetVehicInfo(this.txt_vehno.Text.Trim());
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
                bool needweigh = false;
                if (this.card == null)
                {
                    MessageBox.Show("请放好IC卡！");
                }
                else if (this.txt_vehno.Text.Trim() != this.LastVehNo)
                {
                    MessageBox.Show("作业员输入的车牌号与单据对应车牌号不一致！\n请重新输入车牌号调单【注意调完单据后不能手工修改车牌号】！");
                }
                else if (this.CheckSelected(ref needweigh))
                {
                    if (!FrmMain.Debug && !this.CheckGenLimite())
                    {
                        MessageBox.Show("本作业点不能生成作业单，请查看路线，到指定门岗进行操作！");
                    }
                    else if (this.cb_vehtype.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("请输入车型！");
                    }
                    else
                    {
                        int num2;
                        int num3;
                        int num = 0;
                        for (num2 = 0; num2 < this.treeList1.Nodes.Count; num2++)
                        {
                            num3 = 0;
                            while (num3 < this.treeList1.Nodes[num2].Nodes.Count)
                            {
                                if ((bool) this.treeList1.Nodes[num2].Nodes[num3].GetValue(this.tlc8))
                                {
                                    num++;
                                }
                                num3++;
                            }
                        }
                        if (num == 0)
                        {
                            MessageBox.Show("请选择作业条目！");
                        }
                        else
                        {
                            string[] items = new string[num];
                            int index = 0;
                            for (num2 = 0; num2 < this.treeList1.Nodes.Count; num2++)
                            {
                                TreeListNode node = this.treeList1.Nodes[num2];
                                for (num3 = 0; num3 < node.Nodes.Count; num3++)
                                {
                                    if ((bool) node.Nodes[num3].GetValue(this.tlc8))
                                    {
                                        Bill_Available available = this.Bills[num2];
                                        if (this.CurBillInfo.Type < 3)
                                        {
                                            items[index] = available.BillNo + "\t" + available.Items[num3].RowID + "\t" + available.Items[num3].property.routecode;
                                        }
                                        else if (this.insertqtxhsl)
                                        {
                                            items[index] = available.BillNo + "\t" + available.Items[num3].RowID + "\t" + node.Nodes[num3].GetValue(this.tlc6).ToString();
                                        }
                                        else
                                        {
                                            items[index] = available.BillNo + "\t" + available.Items[num3].RowID + "\t ";
                                        }
                                        index++;
                                    }
                                }
                            }
                            try
                            {
                                string str = this.txt_vehno.Text.Trim();
                                string str2 = this.cb_vehtype.Text.Trim();
                                string str3 = (this.card.Ictype == 2) ? "1" : "0";
                                string[] vehinfo = new string[] { str, str2, str3 };
                                string iD = LocalInfo.Current.user.ID;
                                string text = this.txt_remark.Text;
                                string code = FrmMain.localinfo.workpoint.Code;
                                string str7 = this.IC.GenNoticeBill(items, iD, this.card.ICNo, vehinfo, this.CurBillInfo, text, code);
                                if (str7 == "OK")
                                {
                                    if (this.card.Ictype == 2)
                                    {
                                        MessageBox.Show("已生成作业单！请取走IC卡！");
                                    }
                                    else
                                    {
                                        MessageBox.Show("发卡成功！请取走IC卡！");
                                    }
                                    this.InitMember();
                                    this.InitForm();
                                }
                                else
                                {
                                    MessageBox.Show("数据处理失败！请重试！" + str7);
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("操作失败，请重新尝试！");
                            }
                        }
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((this.CurBillInfo != null) && (this.Bills != null))
            {
                bool needweigh = false;
                if (this.CheckSelected(ref needweigh))
                {
                    this.NTItems = new NoticeItems();
                    int num = 1;
                    for (int i = 0; i < this.treeList1.Nodes.Count; i++)
                    {
                        TreeListNode node = this.treeList1.Nodes[i];
                        for (int j = 0; j < node.Nodes.Count; j++)
                        {
                            if ((bool) node.Nodes[j].GetValue(this.tlc8))
                            {
                                NoticeItem sigle = new NoticeItem();
                                sigle.billid = this.Bills[i].BillNo;
                                sigle.invcode = this.Bills[i].Items[j].InvCode;
                                sigle.invname = this.Bills[i].Items[j].InvName;
                                sigle.rowid = this.Bills[i].Items[j].RowID;
                                sigle.plannum = this.Bills[i].Items[j].PlanNum;
                                if (this.CurBillInfo.Type < 3)
                                {
                                    sigle.routecode = this.Bills[i].Items[j].property.routecode;
                                }
                                sigle.rowno = num;
                                sigle.spectypegraphid = this.Bills[i].Items[j].SpecTypeGraphID;
                                sigle.unit = this.Bills[i].Items[j].Unit;
                                this.NTItems.Add(sigle);
                                num++;
                            }
                        }
                    }
                    new FrmDoorInvAdjust(this.NTItems, this.CurBillInfo).ShowDialog();
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

        public bool CheckGenLimite()
        {
            RouteNode[] routeOfBillType;
            RouteNodes nodes;
            if (this.CurBillInfo.Type < 3)
            {
                for (int i = 0; i < this.treeList1.Nodes.Count; i++)
                {
                    TreeListNode node = this.treeList1.Nodes[i];
                    for (int j = 0; j < node.Nodes.Count; j++)
                    {
                        if ((bool) node.Nodes[j].GetValue(this.tlc8))
                        {
                            routeOfBillType = this.cs.GetRoute_Code(this.Bills[i].Items[j].property.routecode);
                            nodes = new RouteNodes();
                            nodes.Add(routeOfBillType);
                            if (nodes.ContainCurDoorWorkPoint(FrmMain.localinfo.workpoint.Code))
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            bool isqtorxh = this.CurBillInfo.Type == 3;
            routeOfBillType = this.cs.GetRouteOfBillType(this.CurBillInfo.BillTypeID, isqtorxh);
            nodes = new RouteNodes();
            nodes.Add(routeOfBillType);
            return nodes.ContainCurDoorWorkPoint(FrmMain.localinfo.workpoint.Code);
        }

        private bool CheckSelected(ref bool needweigh)
        {
            int num2;
            int num3;
            bool flag;
            bool flag2;
            TreeListNode node;
            string dHTime;
            this.insertqtxhsl = false;
            string str = string.Empty;
            int num = 0;
            for (num2 = 0; num2 < this.treeList1.Nodes.Count; num2++)
            {
                num3 = 0;
                while (num3 < this.treeList1.Nodes[num2].Nodes.Count)
                {
                    if ((bool) this.treeList1.Nodes[num2].Nodes[num3].GetValue(this.tlc8))
                    {
                        num++;
                    }
                    num3++;
                }
            }
            if (num == 0)
            {
                MessageBox.Show("请选择作业条目！");
                return false;
            }
            if (this.CurBillInfo.Type >= 3)
            {
                flag = false;
                flag2 = false;
                for (num2 = 0; num2 < this.treeList1.Nodes.Count; num2++)
                {
                    node = this.treeList1.Nodes[num2];
                    for (num3 = 0; num3 < node.Nodes.Count; num3++)
                    {
                        if ((bool) node.Nodes[num3].GetValue(this.tlc8))
                        {
                            if (str != string.Empty)
                            {
                                dHTime = this.Bills[num2].DHTime;
                                if (str != dHTime)
                                {
                                    MessageBox.Show("选择的条目存在不同天的执行日期，无效！");
                                    return false;
                                }
                            }
                            if (str == string.Empty)
                            {
                                str = this.Bills[num2].DHTime;
                            }
                            if (node.Nodes[num3].GetValue(this.tlc7).ToString() == "是")
                            {
                                flag = true;
                            }
                            if (node.Nodes[num3].GetValue(this.tlc7).ToString() == "否")
                            {
                                flag2 = true;
                            }
                        }
                    }
                }
                if (flag && flag2)
                {
                    MessageBox.Show("计件，记重物资不允许混装！");
                    return false;
                }
                needweigh = this.Bills[0].needweigh;
                bool isqtorxh = this.CurBillInfo.Type == 3;
                RouteNodes nodes = new RouteNodes();
                nodes.Add(this.cs.GetRouteOfBillType(this.CurBillInfo.BillTypeID, isqtorxh));
                if (!(!needweigh || nodes.ContainWeigh()))
                {
                    MessageBox.Show("单据路线错误！请联系管理员！");
                    return false;
                }
                if (!(needweigh || nodes.ContainGoodsSite()))
                {
                    this.insertqtxhsl = true;
                }
            }
            else
            {
                int[] numArray = new int[this.treeList1.Nodes.Count];
                for (num2 = 0; num2 < this.treeList1.Nodes.Count; num2++)
                {
                    numArray[num2] = 0;
                }
                int num4 = 0;
                flag = false;
                flag2 = false;
                bool flag3 = false;
                for (num2 = 0; num2 < this.treeList1.Nodes.Count; num2++)
                {
                    node = this.treeList1.Nodes[num2];
                    for (num3 = 0; num3 < node.Nodes.Count; num3++)
                    {
                        if ((bool) node.Nodes[num3].GetValue(this.tlc8))
                        {
                            if (str != string.Empty)
                            {
                                dHTime = this.Bills[num2].DHTime;
                                if (str != dHTime)
                                {
                                    MessageBox.Show("选择的条目存在不同天的执行日期，无效！");
                                    return false;
                                }
                            }
                            if (str == string.Empty)
                            {
                                str = this.Bills[num2].DHTime;
                            }
                            numArray[num2] = 1;
                            if (!this.Bills[num2].Items[num3].property.available)
                            {
                                MessageBox.Show("存在不可用的单据条目，原因是没有找到条目对应的物资路线，计量属性！");
                                return false;
                            }
                            if (this.Bills[num2].Items[num3].property.needweigh)
                            {
                                flag = true;
                            }
                            if (!this.Bills[num2].Items[num3].property.needweigh)
                            {
                                flag2 = true;
                            }
                            if (!this.Bills[num2].Items[num3].property.allowmix)
                            {
                                flag3 = true;
                            }
                            num4++;
                        }
                    }
                }
                if (flag && flag2)
                {
                    MessageBox.Show("计件，记重物资不允许混装！");
                    return false;
                }
                if (flag3 && (num4 > 1))
                {
                    MessageBox.Show("不允许混装！");
                    return false;
                }
                if (this.CurBillInfo.Type == 2)
                {
                    int num5 = 0;
                    for (num2 = 0; num2 < this.treeList1.Nodes.Count; num2++)
                    {
                        num5 += numArray[num2];
                    }
                    if (num5 > 1)
                    {
                        MessageBox.Show("发运单只能选择一个单据，并且必须全选！");
                        return false;
                    }
                    for (num2 = 0; num2 < this.treeList1.Nodes.Count; num2++)
                    {
                        if (numArray[num2] == 1)
                        {
                            num5 = num2;
                            break;
                        }
                    }
                    node = this.treeList1.Nodes[num5];
                    for (num3 = 0; num3 < node.Nodes.Count; num3++)
                    {
                        if (!((bool) node.Nodes[num3].GetValue(this.tlc8)))
                        {
                            MessageBox.Show("发运单只能选择一个单据，并且必须全选！");
                            return false;
                        }
                    }
                }
                needweigh = flag;
            }
            this.CurBillInfo.NeedWeigh = needweigh;
            return true;
        }

        public void ClearForm()
        {
            this.txt_icnno.Text = string.Empty;
            this.txt_billType.Text = string.Empty;
            this.txt_wzlx.Text = string.Empty;
            this.txt_remark.Text = string.Empty;
            this.cb_vehtype.SelectedIndex = -1;
            this.treeList1.Nodes.Clear();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FC_MatVehCard_Load(object sender, EventArgs e)
        {
            try
            {
                this.cs = new VehIC_WF.CommonService.CommonService();
                this.IC = new VehIC_WF.ICCardManageService.ICCardManageService();
                if (!FrmMain.Debug)
                {
                    this.IC.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/ICCardManageService.asmx";
                    this.cs.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/CommonService.asmx";
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
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        public bool FillListView(string vehnoex)
        {
            try
            {
                string[] availableVehNo = this.IC.GetAvailableVehNo(vehnoex);
                if ((availableVehNo == null) && (availableVehNo.Length == 0))
                {
                    return false;
                }
                for (int i = 0; i < availableVehNo.Length; i++)
                {
                    this.listBox1.Items.Add(availableVehNo[i]);
                }
                if (availableVehNo.Length == 1)
                {
                    this.listBox1.Height = 30;
                }
                else if (availableVehNo.Length < 7)
                {
                    this.listBox1.Height = (this.listBox1.ItemHeight + 1) * availableVehNo.Length;
                }
                else
                {
                    this.listBox1.Height = 90;
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
                this.insertqtxhsl = false;
                this.ClearForm();
                this.Bills = null;
                this.NTItems = null;
                this.CurBillInfo = null;
                string cph = this.txt_vehno.Text.Trim();
                if (cph == string.Empty)
                {
                    return false;
                }
                AvailableBillInfo[] availableBillInfos = this.IC.GetAvailableBillInfos(cph);
                if (availableBillInfos == null)
                {
                    this.txt_icnno.Focus();
                    MessageBox.Show("数据处理错误，请重试！");
                    return false;
                }
                if (availableBillInfos.Length == 0)
                {
                    this.txt_icnno.Focus();
                    MessageBox.Show("没有可用的单据！");
                    return false;
                }
                if (availableBillInfos.Length == 1)
                {
                    this.CurBillInfo = availableBillInfos[0];
                    if (this.CurBillInfo.Type == -2)
                    {
                        MessageBox.Show("存在此车辆对应的未完成RF发运作业单，不允许再生成新作业单！");
                        this.CurBillInfo = null;
                        return false;
                    }
                    if (this.CurBillInfo.Type == -1)
                    {
                        MessageBox.Show("存在此车辆对应的可用作业单，不允许再生成作业单！");
                        this.CurBillInfo = null;
                        return false;
                    }
                }
                else
                {
                    FrmBillTypeSelect select = new FrmBillTypeSelect(availableBillInfos);
                    select.ShowDialog();
                    if (select.Result == -1)
                    {
                        this.txt_vehno.SelectionStart = this.txt_vehno.Text.Length;
                        this.txt_vehno.Focus();
                        return false;
                    }
                    this.CurBillInfo = availableBillInfos[select.Result];
                }
                switch (this.CurBillInfo.Type)
                {
                    case 0:
                        this.Bills = this.IC.GetBill_Arrives(cph, this.CurBillInfo.wzlx.ToString());
                        break;

                    case 1:
                        this.Bills = this.IC.GetBill_ArrivesEx(cph, this.CurBillInfo.BillNum);
                        break;

                    case 2:
                        this.Bills = this.IC.GetBill_FYD(cph, this.CurBillInfo.wzlx.ToString());
                        break;

                    case 3:
                        this.Bills = this.IC.GetBill_QTWZ(cph, this.CurBillInfo.BillTypeID, this.CurBillInfo.NeedWeigh);
                        break;

                    case 4:
                        this.Bills = this.IC.GetBill_XHWZ(cph, this.CurBillInfo.BillTypeID, this.CurBillInfo.NeedWeigh);
                        break;
                }
                if ((this.Bills == null) || (this.Bills.Length == 0))
                {
                    this.txt_icnno.Focus();
                    MessageBox.Show("没有找到可用的单据，或者数据访问失败！");
                    return false;
                }
                this.InitBillView();
                this.LastVehNo = cph;
                string vehTypeByVehNo = this.IC.GetVehTypeByVehNo(cph);
                this.cb_vehtype.SelectedIndex = this.cb_vehtype.Items.IndexOf(vehTypeByVehNo);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
                return false;
            }
        }

        public void InitBillView()
        {
            this.treeList1.Nodes.Clear();
            if ((this.Bills != null) && (this.CurBillInfo != null))
            {
                this.txt_billType.Text = this.CurBillInfo.TypeDesc;
                this.txt_wzlx.Text = (this.CurBillInfo.wzlx == 0) ? "入厂" : "出厂";
                for (int i = 0; i < this.Bills.Length; i++)
                {
                    TreeListNode node = null;
                    string billNo = this.Bills[i].BillNo;
                    string dHTime = this.Bills[i].DHTime;
                    string vendor = this.Bills[i].Vendor;
                    string dept = this.Bills[i].Dept;
                    node = this.treeList1.AppendNode(new object[] { billNo, dHTime, vendor, dept, "", "", "", "" }, -1, 0, 0, 0);
                    for (int j = 0; j < this.Bills[i].Items.Length; j++)
                    {
                        int num3;
                        string rowNo = this.Bills[i].Items[j].RowNo;
                        string invCode = this.Bills[i].Items[j].InvCode;
                        string invName = this.Bills[i].Items[j].InvName;
                        string specTypeGraphID = this.Bills[i].Items[j].SpecTypeGraphID;
                        string unit = this.Bills[i].Items[j].Unit;
                        string str10 = this.Bills[i].Items[j].PlanNum.ToString();
                        string str11 = (this.CurBillInfo.Type < 3) ? (this.Bills[i].Items[j].property.needweigh ? "是" : "否") : (this.Bills[i].needweigh ? "是" : "否");
                        if (this.CurBillInfo.Type < 3)
                        {
                            num3 = this.Bills[i].Items[j].property.available ? 1 : 2;
                            this.treeList1.AppendNode(new object[] { rowNo, invCode, invName, specTypeGraphID, unit, str10, str11, false }, node.Id, num3, num3, num3);
                        }
                        else
                        {
                            num3 = 1;
                            this.treeList1.AppendNode(new object[] { rowNo, invCode, invName, specTypeGraphID, unit, str10, str11, false }, node.Id, num3, num3, num3);
                        }
                    }
                }
                this.treeList1.ExpandAll();
            }
            else
            {
                this.InitForm();
            }
        }

        private void InitForm()
        {
            this.treeList1.Nodes.Clear();
            this.txt_icnno.Text = string.Empty;
            this.txt_vehno.Text = string.Empty;
            this.txt_billType.Text = string.Empty;
            this.txt_wzlx.Text = string.Empty;
            this.txt_remark.Text = string.Empty;
            this.cb_vehtype.SelectedIndex = -1;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FC_MatVehCard));
            this.imageList1 = new ImageList(this.components);
            this.panel1 = new Panel();
            this.listBox1 = new ListBox();
            this.txt_remark = new TextBox();
            this.label3 = new Label();
            this.chbox_fixveh = new CheckBox();
            this.txt_vehno = new TextBox();
            this.cb_vehtype = new ComboBox();
            this.label25 = new Label();
            this.panel3 = new Panel();
            this.button4 = new Button();
            this.button1 = new Button();
            this.txt_wzlx = new TextBox();
            this.label22 = new Label();
            this.txt_billType = new TextBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.txt_icnno = new TextBox();
            this.label4 = new Label();
            this.treeList1 = new TreeList();
            this.tlc1 = new TreeListColumn();
            this.tlc2 = new TreeListColumn();
            this.tlc3 = new TreeListColumn();
            this.tlc4 = new TreeListColumn();
            this.tlc5 = new TreeListColumn();
            this.tlc6 = new TreeListColumn();
            this.tlc7 = new TreeListColumn();
            this.tlc8 = new TreeListColumn();
            this.repositoryItemCheckEdit1 = new RepositoryItemCheckEdit();
            this.panel2 = new Panel();
            this.toolTip1 = new ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.treeList1.BeginInit();
            this.repositoryItemCheckEdit1.BeginInit();
            base.SuspendLayout();
            this.imageList1.ImageStream = (ImageListStreamer) resources.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "favorites.gif");
            this.imageList1.Images.SetKeyName(1, "feed.gif");
            this.imageList1.Images.SetKeyName(2, "cancel.ico");
            this.imageList1.Images.SetKeyName(3, "18.ico");
            this.imageList1.Images.SetKeyName(4, "head.ico");
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.txt_remark);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chbox_fixveh);
            this.panel1.Controls.Add(this.txt_vehno);
            this.panel1.Controls.Add(this.cb_vehtype);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.txt_wzlx);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.txt_billType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_icnno);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Margin = new Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x385, 0x81);
            this.panel1.TabIndex = 3;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new Point(0x22e, 0x22);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBox1.Size = new Size(0x90, 14);
            this.listBox1.TabIndex = 210;
            this.listBox1.Visible = false;
            this.listBox1.DoubleClick += new EventHandler(this.listBox1_DoubleClick);
            this.listBox1.KeyUp += new KeyEventHandler(this.listBox1_KeyUp);
            this.txt_remark.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_remark.Location = new Point(0x51, 0x45);
            this.txt_remark.Margin = new Padding(4);
            this.txt_remark.Multiline = true;
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.Size = new Size(0x26d, 0x33);
            this.txt_remark.TabIndex = 0xd5;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label3.Location = new Point(0x30, 0x48);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x23, 14);
            this.label3.TabIndex = 0xd4;
            this.label3.Text = "说明";
            this.chbox_fixveh.AutoSize = true;
            this.chbox_fixveh.Enabled = false;
            this.chbox_fixveh.Font = new System.Drawing.Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.chbox_fixveh.Location = new Point(0x202, 0x29);
            this.chbox_fixveh.Name = "chbox_fixveh";
            this.chbox_fixveh.Size = new Size(0x5b, 20);
            this.chbox_fixveh.TabIndex = 0xd3;
            this.chbox_fixveh.Text = "固定车辆";
            this.chbox_fixveh.UseVisualStyleBackColor = true;
            this.txt_vehno.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_vehno.Location = new Point(0x22e, 11);
            this.txt_vehno.Margin = new Padding(4);
            this.txt_vehno.Name = "txt_vehno";
            this.txt_vehno.Size = new Size(0x90, 0x17);
            this.txt_vehno.TabIndex = 0x7b;
            this.txt_vehno.TextAlign = HorizontalAlignment.Right;
            this.txt_vehno.KeyUp += new KeyEventHandler(this.txt_vehno_KeyUp);
            this.cb_vehtype.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cb_vehtype.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.cb_vehtype.FormattingEnabled = true;
            this.cb_vehtype.Location = new Point(0x147, 11);
            this.cb_vehtype.Name = "cb_vehtype";
            this.cb_vehtype.Size = new Size(0x90, 0x16);
            this.cb_vehtype.TabIndex = 0x97;
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label25.Location = new Point(0x124, 14);
            this.label25.Margin = new Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new Size(0x23, 14);
            this.label25.TabIndex = 150;
            this.label25.Text = "车型";
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = DockStyle.Right;
            this.panel3.Location = new Point(750, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(0x95, 0x7f);
            this.panel3.TabIndex = 0x92;
            this.button4.Location = new Point(0x17, 0x48);
            this.button4.Name = "button4";
            this.button4.Size = new Size(0x69, 0x24);
            this.button4.TabIndex = 0x8f;
            this.button4.Text = "查看路线";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new EventHandler(this.button4_Click);
            this.button1.Location = new Point(0x17, 0x16);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x69, 0x24);
            this.button1.TabIndex = 0x8e;
            this.button1.Text = "生成作业单";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.txt_wzlx.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_wzlx.Location = new Point(0x147, 40);
            this.txt_wzlx.Margin = new Padding(4);
            this.txt_wzlx.Name = "txt_wzlx";
            this.txt_wzlx.ReadOnly = true;
            this.txt_wzlx.Size = new Size(0x90, 0x17);
            this.txt_wzlx.TabIndex = 0x91;
            this.txt_wzlx.TextAlign = HorizontalAlignment.Right;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label22.Location = new Point(0x10a, 0x2c);
            this.label22.Margin = new Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new Size(0x3f, 14);
            this.label22.TabIndex = 0x90;
            this.label22.Text = "物资流向";
            this.txt_billType.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_billType.Location = new Point(0x51, 40);
            this.txt_billType.Margin = new Padding(4);
            this.txt_billType.Name = "txt_billType";
            this.txt_billType.ReadOnly = true;
            this.txt_billType.Size = new Size(0x90, 0x17);
            this.txt_billType.TabIndex = 0x8f;
            this.txt_billType.TextAlign = HorizontalAlignment.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label1.Location = new Point(20, 0x2c);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x3f, 14);
            this.label1.TabIndex = 0x8e;
            this.label1.Text = "单据类型";
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label2.Location = new Point(0x1ff, 0x10);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x31, 14);
            this.label2.TabIndex = 0x79;
            this.label2.Text = "车牌号";
            this.txt_icnno.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.txt_icnno.Location = new Point(0x51, 11);
            this.txt_icnno.Margin = new Padding(4);
            this.txt_icnno.Name = "txt_icnno";
            this.txt_icnno.ReadOnly = true;
            this.txt_icnno.Size = new Size(0x90, 0x17);
            this.txt_icnno.TabIndex = 120;
            this.txt_icnno.TextAlign = HorizontalAlignment.Right;
            this.txt_icnno.KeyUp += new KeyEventHandler(this.txt_icnno_KeyUp);
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label4.Location = new Point(0x22, 15);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x31, 14);
            this.label4.TabIndex = 0x77;
            this.label4.Text = "IC卡号";
            this.treeList1.BackgroundImage = (Image) resources.GetObject("treeList1.BackgroundImage");
            this.treeList1.Columns.AddRange(new TreeListColumn[] { this.tlc1, this.tlc2, this.tlc3, this.tlc4, this.tlc5, this.tlc6, this.tlc7, this.tlc8 });
            this.treeList1.Dock = DockStyle.Fill;
            this.treeList1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.treeList1.HorzScrollVisibility = ScrollVisibility.Always;
            this.treeList1.Location = new Point(0, 0x81);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsView.ShowFocusedFrame = false;
            this.treeList1.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemCheckEdit1 });
            this.treeList1.Size = new Size(0x385, 0x16d);
            this.treeList1.StateImageList = this.imageList1;
            this.treeList1.TabIndex = 9;
            this.treeList1.TreeLevelWidth = 12;
            this.treeList1.MouseMove += new MouseEventHandler(this.treeList1_MouseMove);
            this.tlc1.Caption = "单据号/行号";
            this.tlc1.FieldName = "单据号/行号";
            this.tlc1.MinWidth = 0x2c;
            this.tlc1.Name = "tlc1";
            this.tlc1.OptionsColumn.AllowEdit = false;
            this.tlc1.OptionsColumn.AllowMove = false;
            this.tlc1.OptionsColumn.AllowSort = false;
            this.tlc1.OptionsColumn.ReadOnly = true;
            this.tlc1.OptionsColumn.ShowInCustomizationForm = false;
            this.tlc1.VisibleIndex = 0;
            this.tlc1.Width = 0x61;
            this.tlc2.Caption = "到货[发货]日期/存货编码";
            this.tlc2.FieldName = "进厂日期/存货编码";
            this.tlc2.Name = "tlc2";
            this.tlc2.OptionsColumn.AllowEdit = false;
            this.tlc2.OptionsColumn.AllowMove = false;
            this.tlc2.OptionsColumn.AllowSort = false;
            this.tlc2.OptionsColumn.ReadOnly = true;
            this.tlc2.VisibleIndex = 1;
            this.tlc2.Width = 140;
            this.tlc3.Caption = "客商/存货名称";
            this.tlc3.FieldName = "客商/存货名称";
            this.tlc3.Name = "tlc3";
            this.tlc3.OptionsColumn.AllowEdit = false;
            this.tlc3.OptionsColumn.AllowMove = false;
            this.tlc3.OptionsColumn.AllowSort = false;
            this.tlc3.VisibleIndex = 2;
            this.tlc3.Width = 140;
            this.tlc4.Caption = "部门/型号规格图号";
            this.tlc4.FieldName = "型号规格图号";
            this.tlc4.Name = "tlc4";
            this.tlc4.OptionsColumn.AllowEdit = false;
            this.tlc4.OptionsColumn.AllowMove = false;
            this.tlc4.OptionsColumn.AllowSort = false;
            this.tlc4.VisibleIndex = 3;
            this.tlc4.Width = 140;
            this.tlc5.Caption = "计量单位";
            this.tlc5.FieldName = "部门/计量单位";
            this.tlc5.Name = "tlc5";
            this.tlc5.OptionsColumn.AllowEdit = false;
            this.tlc5.OptionsColumn.AllowMove = false;
            this.tlc5.OptionsColumn.AllowSort = false;
            this.tlc5.VisibleIndex = 4;
            this.tlc5.Width = 50;
            this.tlc6.Caption = "计划数量";
            this.tlc6.FieldName = "计划数量";
            this.tlc6.Name = "tlc6";
            this.tlc6.OptionsColumn.AllowEdit = false;
            this.tlc6.OptionsColumn.AllowMove = false;
            this.tlc6.OptionsColumn.AllowSort = false;
            this.tlc6.VisibleIndex = 5;
            this.tlc6.Width = 50;
            this.tlc7.Caption = "是否记重";
            this.tlc7.FieldName = "是否记重";
            this.tlc7.Name = "tlc7";
            this.tlc7.OptionsColumn.AllowEdit = false;
            this.tlc7.OptionsColumn.AllowMove = false;
            this.tlc7.OptionsColumn.AllowSort = false;
            this.tlc7.VisibleIndex = 6;
            this.tlc7.Width = 50;
            this.tlc8.Caption = "选择";
            this.tlc8.ColumnEdit = this.repositoryItemCheckEdit1;
            this.tlc8.FieldName = "选择";
            this.tlc8.Name = "tlc8";
            this.tlc8.OptionsColumn.AllowMove = false;
            this.tlc8.OptionsColumn.AllowSort = false;
            this.tlc8.VisibleIndex = 7;
            this.tlc8.Width = 40;
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.panel2.Dock = DockStyle.Fill;
            this.panel2.Location = new Point(0, 0x81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x385, 0x16d);
            this.panel2.TabIndex = 10;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.treeList1);
            base.Controls.Add(this.panel2);
            base.Controls.Add(this.panel1);
            base.Name = "FC_MatVehCard";
            base.Size = new Size(0x385, 0x1ee);
            base.Load += new EventHandler(this.FC_MatVehCard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.treeList1.EndInit();
            this.repositoryItemCheckEdit1.EndInit();
            base.ResumeLayout(false);
        }

        private void InitMember()
        {
            this.CurBillInfo = null;
            this.Bills = null;
            this.NTItems = null;
            this.card = null;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex != -1)
            {
                this.txt_vehno.Text = this.listBox1.Text;
                this.listBox1.Visible = false;
                this.txt_vehno.SelectionStart = this.txt_vehno.Text.Length;
                this.txt_vehno.Focus();
                if (this.IC.ISFixVeh(this.txt_vehno.Text.Trim()))
                {
                    MessageBox.Show("固定车辆请刷卡调单！");
                }
                else
                {
                    this.chbox_fixveh.Checked = false;
                    if (!this.GetBillInfo())
                    {
                        this.card = null;
                        this.ClearForm();
                        this.Bills = null;
                        this.CurBillInfo = null;
                    }
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
                    if (this.IC.ISFixVeh(this.txt_vehno.Text.Trim()))
                    {
                        MessageBox.Show("固定车辆请刷卡调单！");
                    }
                    else
                    {
                        this.chbox_fixveh.Checked = false;
                        if (!this.GetBillInfo())
                        {
                            this.card = null;
                            this.ClearForm();
                            this.Bills = null;
                            this.CurBillInfo = null;
                        }
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
                    else if ((this.card.Status == 1) && (this.card.Ictype == 2))
                    {
                        this.chbox_fixveh.Checked = false;
                        Bill_FixVehCard fixVehCardBillEx = this.IC.GetFixVehCardBillEx(this.card.DJH);
                        this.cb_vehtype.SelectedIndex = this.cb_vehtype.Items.IndexOf(fixVehCardBillEx.VehType);
                        this.txt_icnno.Text = this.card.CardNo;
                        this.txt_vehno.Text = fixVehCardBillEx.VehID;
                        if (!this.GetBillInfo())
                        {
                            this.card = null;
                            this.ClearForm();
                            this.Bills = null;
                            this.CurBillInfo = null;
                        }
                        else
                        {
                            this.chbox_fixveh.Checked = true;
                            this.cb_vehtype.SelectedIndex = this.cb_vehtype.Items.IndexOf(fixVehCardBillEx.VehType);
                            this.txt_icnno.Text = this.card.CardNo;
                        }
                    }
                    else if (this.card.Status != 0)
                    {
                        MessageBox.Show("卡[" + this.card.CardNo + "]当前状态不允许发卡！");
                        this.card = null;
                    }
                    else
                    {
                        this.txt_icnno.Text = this.card.CardNo;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void treeList1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void txt_icnno_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.txt_vehno.SelectionStart = this.txt_vehno.Text.Length;
                this.txt_vehno.Focus();
            }
        }

        private void txt_vehno_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    this.listBox1.Visible = false;
                    if (this.IC.ISFixVeh(this.txt_vehno.Text.Trim()))
                    {
                        MessageBox.Show("固定车辆请刷卡调单！");
                    }
                    else
                    {
                        this.chbox_fixveh.Checked = false;
                        if (!this.GetBillInfo())
                        {
                            this.card = null;
                            this.ClearForm();
                            this.Bills = null;
                            this.CurBillInfo = null;
                        }
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
    }
}

