namespace VehIC_WF.ICManage
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using VehIC_BL;
    using VehIC_WF;
    using VehIC_WF.ICCardManageService;

    public class FC_CardRegistry : UserControl,ICardMessage
    {
        private Button btn_init;
        private Button btn_lose;
        private Button btn_new;
        private Button btn_out;
        private Button button1;
        private Button button6;
        public UIDUNAMES CardOwner = null;
        private CheckBox ck1;
        private CheckBox ck11;
        private CheckBox ck12;
        private CheckBox ck13;
        private CheckBox ck14;
        private CheckBox ck15;
        private CheckBox ck16;
        private CheckBox ck2;
        private CheckBox ck3;
        private CheckBox ck4;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private IContainer components = null;
        public VehIC_BL.ICCard CurCard = null;
        private DataGridView dataGridView1;
        private DateTimePicker dateTimePicker3;
        private DateTimePicker dateTimePicker4;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        public VehIC_WF.ICCardManageService.ICCardManageService iccardmanageservice = null;
        public VehIC_WF.ICCardManageService.ICCard[] ICCards = null;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        public string lastrecmsg = string.Empty;
        public long lastrectime = 0L;
        public ICCardCollection NewCars = null;
        private Panel panel1;
        private Panel panel3;
        private RadioButton rb1;
        private RadioButton rb11;
        private RadioButton rb12;
        private RadioButton rb13;
        private RadioButton rb14;
        private RadioButton rb15;
        private RadioButton rb16;
        private RadioButton rb2;
        private RadioButton rb3;
        private RadioButton rb4;
        public UIDUNAMES RegOpers = null;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        public int timelimit = 20;

        public FC_CardRegistry()
        {
            this.InitializeComponent();
            this.RegOpers = new UIDUNAMES();
            this.CardOwner = new UIDUNAMES();
            try
            {
                int num;
                this.iccardmanageservice = new VehIC_WF.ICCardManageService.ICCardManageService();
                if (!FrmMain.Debug)
                {
                    this.iccardmanageservice.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/ICCardManageService.asmx";
                }
                string[] regOperList = this.iccardmanageservice.GetRegOperList();
                if (regOperList != null)
                {
                    for (num = 0; num < regOperList.Length; num++)
                    {
                        string[] field = Regex.Split(regOperList[num], "\t", RegexOptions.IgnoreCase);
                        this.RegOpers.Add(new UIDUNAME(field));
                        this.comboBox4.Items.Add(field[1]);
                    }
                }
                if (this.RegOpers.IndexOf(LocalInfo.Current.user.ID) == -1)
                {
                    this.RegOpers.Add(new UIDUNAME(new string[] { LocalInfo.Current.user.ID, FrmMain.localinfo.user.Name }));
                }
                regOperList = this.iccardmanageservice.GetCardOwnerList();
                if (regOperList != null)
                {
                    for (num = 0; num < regOperList.Length; num++)
                    {
                        if (!(regOperList[num].Trim() == ""))
                        {
                            this.CardOwner.Add(new UIDUNAME(new string[] { regOperList[num], "" }));
                            this.comboBox3.Items.Add(regOperList[num]);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("初始化数据时出错！\r\n" + exception.ToString());
            }
        }

        public void AppendGrid()
        {
            if (this.CurCard != null)
            {
                this.dataGridView1.Rows.Insert(0, 1);
                this.dataGridView1.Rows[0].Cells[0].Value = this.dataGridView1.Rows.Count.ToString();
                this.dataGridView1.Rows[0].Cells[1].Value = this.CurCard.ICNo;
                this.dataGridView1.Rows[0].Cells[2].Value = this.CurCard.CardNo;
                this.dataGridView1.Rows[0].Cells[3].Value = this.CurCard.Reguser;
                this.dataGridView1.Rows[0].Cells[4].Value = this.CurCard.Regtime;
                this.dataGridView1.Rows[0].Cells[5].Value = VehIC_BL.ICCard.GetStatusDesc(this.CurCard.Status);
                this.dataGridView1.Rows[0].Cells[6].Value = VehIC_BL.ICCard.GetTypeDesc(this.CurCard.Ictype);
                this.dataGridView1.Rows[0].Cells[7].Value = this.CurCard.UName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                string icid = this.textBox2.Text.Trim();
                if (this.iccardmanageservice.TTCardInit(icid))
                {
                    MessageBox.Show("操作成功！");
                }
                else
                {
                    MessageBox.Show("操作失败！");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((this.CurCard != null) && (this.tabControl1.SelectedIndex == 0))
            {
                string id = this.textBox2.Text.Trim();
                string s = this.textBox1.Text.Trim();
                int num = 0;
                try
                {
                    num = int.Parse(s);
                }
                catch (Exception)
                {
                    MessageBox.Show("输入的卡号无效！");
                    return;
                }
                if (s == string.Empty)
                {
                    MessageBox.Show("IC卡号不能为空！");
                }
                else
                {
                    VehIC_WF.ICCardManageService.ICCard cardEx = this.iccardmanageservice.GetCardEx(s);
                    if ((cardEx != null) && (cardEx.ICNo != string.Empty))
                    {
                        MessageBox.Show("卡号已经存在,请修改卡号！");
                    }
                    else if (this.CurCard.CardNo == "")
                    {
                        this.CurCard.ICNo = id;
                        this.CurCard.CardNo = s;
                        this.CurCard.Reguser = FrmMain.localinfo.user.Name;
                        this.CurCard.Regtime = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
                        if (this.iccardmanageservice.RegistryCard(id, s, LocalInfo.Current.user.ID) != 1)
                        {
                            MessageBox.Show("保存失败！");
                        }
                        else
                        {
                            if (this.ICCards != null)
                            {
                                this.dataGridView1.Rows.Clear();
                                this.ICCards = null;
                            }
                            this.AppendGrid();
                            if (this.NewCars == null)
                            {
                                this.NewCars = new ICCardCollection();
                            }
                            this.NewCars.Add(this.CurCard);
                            this.CurCard = null;
                            this.textBox2.Text = string.Empty;
                        }
                    }
                    else
                    {
                        this.CurCard.CardNo = s;
                        if (this.iccardmanageservice.UpdateCardNo(id, s, LocalInfo.Current.user.ID) != 1)
                        {
                            MessageBox.Show("保存失败！");
                        }
                        else
                        {
                            MessageBox.Show("更新成功！");
                            this.UpdateCurCard();
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                if (this.CurCard != null)
                {
                    if (this.CurCard.ICNo == string.Empty)
                    {
                        MessageBox.Show("新卡不允许注销！");
                    }
                    else
                    {
                        MessageBox.Show("不允许存在卡的时候进行挂失操作！");
                    }
                }
            }
            else if (this.ICCards != null)
            {
                if (this.CurCard == null)
                {
                    MessageBox.Show("请先双击选择要操作的卡！");
                }
                else if (this.CurCard.Status == 3)
                {
                    MessageBox.Show("当前选择要操作的卡已经是挂失状态！");
                }
                else if (this.CurCard.Status == 4)
                {
                    MessageBox.Show("注销的卡不允许挂失！");
                }
                else if (this.iccardmanageservice.RegistryLost(this.CurCard.ICNo, LocalInfo.Current.user.ID) == -1)
                {
                    MessageBox.Show("操作失败！");
                }
                else
                {
                    MessageBox.Show("操作成功！");
                    this.CurCard.Status = 3;
                    int num2 = -1;
                    for (int i = 0; i < this.ICCards.Length; i++)
                    {
                        if (this.ICCards[i].ICNo == this.CurCard.ICNo)
                        {
                            this.ICCards[i].Status = 2;
                            num2 = i;
                            break;
                        }
                    }
                    if (num2 != -1)
                    {
                        this.dataGridView1.Rows[num2].Cells[5].Value = VehIC_BL.ICCard.GetStatusDesc(this.CurCard.Status);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                if (this.CurCard != null)
                {
                    if (this.CurCard.ICNo == string.Empty)
                    {
                        MessageBox.Show("新卡不允许注销！");
                    }
                    else if (this.CurCard.Status == 4)
                    {
                        MessageBox.Show("注销状态的卡不允许注销操作！");
                    }
                    else if (this.iccardmanageservice.RegistryOut(this.CurCard.ICNo, LocalInfo.Current.user.ID) == -1)
                    {
                        MessageBox.Show("操作失败！");
                    }
                    else
                    {
                        MessageBox.Show("操作成功！");
                        this.CurCard.Status = 4;
                    }
                }
            }
            else if (this.ICCards != null)
            {
                if (this.CurCard == null)
                {
                    MessageBox.Show("请先双击选择要操作的卡！");
                }
                else if (this.CurCard.Status == 4)
                {
                    MessageBox.Show("注销状态的卡不允许注销操作！");
                }
                else if (this.iccardmanageservice.RegistryOut(this.CurCard.ICNo, LocalInfo.Current.user.ID) == -1)
                {
                    MessageBox.Show("操作失败！");
                }
                else
                {
                    MessageBox.Show("操作成功！");
                    this.CurCard.Status = 4;
                    this.CurCard.UName = "";
                    this.CurCard.Ictype = 0;
                    int num2 = -1;
                    for (int i = 0; i < this.ICCards.Length; i++)
                    {
                        if (this.ICCards[i].ICNo == this.CurCard.ICNo)
                        {
                            this.ICCards[i].Status = 4;
                            this.ICCards[i].UName = "";
                            this.ICCards[i].Ictype = 0;
                            num2 = i;
                            break;
                        }
                    }
                    if (num2 != -1)
                    {
                        this.dataGridView1.Rows[num2].Cells[5].Value = VehIC_BL.ICCard.GetStatusDesc(this.CurCard.Status);
                        this.dataGridView1.Rows[num2].Cells[6].Value = VehIC_BL.ICCard.GetTypeDesc(this.CurCard.Ictype);
                        this.dataGridView1.Rows[num2].Cells[7].Value = "";
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                if (this.CurCard != null)
                {
                    if (this.CurCard.ICNo == string.Empty)
                    {
                        MessageBox.Show("新卡不允许初始化！");
                    }
                    else if (this.CurCard.Status == 0)
                    {
                        MessageBox.Show("未使用状态的卡不允许初始操作！");
                    }
                    else if (this.CurCard.Status == 1)
                    {
                        MessageBox.Show("使用中状态的卡挂失后才允许初始操作！");
                    }
                    else if (this.iccardmanageservice.CardInit(this.CurCard.ICNo, LocalInfo.Current.user.ID) == -1)
                    {
                        MessageBox.Show("操作失败！");
                    }
                    else
                    {
                        MessageBox.Show("操作成功！");
                    }
                }
            }
            else
            {
                MessageBox.Show("必须有卡才能进行初始化操作！");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int num2;
            this.dataGridView1.Rows.Clear();
            this.ICCards = null;
            string begintime = string.Format("{0:yyyy-MM-dd}", this.dateTimePicker4.Value) + " 00:00:01";
            string endtime = string.Format("{0:yyyy-MM-dd}", this.dateTimePicker3.Value) + " 23:59:59";
            string regoper = string.Empty;
            if (((this.comboBox4.SelectedIndex < this.RegOpers.Count) && (this.comboBox4.SelectedIndex > -1)) && (this.comboBox4.Text.Trim() != ""))
            {
                regoper = this.RegOpers[this.comboBox4.SelectedIndex].UID;
            }
            string cardno = this.textBox3.Text.Trim();
            string ownerid = string.Empty;
            if (((this.comboBox3.SelectedIndex < this.CardOwner.Count) && (this.comboBox3.SelectedIndex > -1)) && (this.comboBox3.Text.Trim() != ""))
            {
                ownerid = this.CardOwner[this.comboBox3.SelectedIndex].UID;
            }
            int num = 0;
            if (this.ck1.Checked)
            {
                num++;
            }
            if (this.ck2.Checked)
            {
                num++;
            }
            if (this.ck3.Checked)
            {
                num++;
            }
            if (this.ck4.Checked)
            {
                num++;
            }
            int[] astatus = null;
            if (num > 0)
            {
                astatus = new int[num];
                num2 = 0;
                if (this.ck1.Checked)
                {
                    astatus[num2] = 0;
                    num2++;
                }
                if (this.ck2.Checked)
                {
                    astatus[num2] = 1;
                    num2++;
                }
                if (this.ck3.Checked)
                {
                    astatus[num2] = 2;
                    num2++;
                }
                if (this.ck4.Checked)
                {
                    astatus[num2] = 3;
                    num2++;
                }
            }
            num = 0;
            if (this.ck11.Checked)
            {
                num++;
            }
            if (this.ck12.Checked)
            {
                num++;
            }
            if (this.ck13.Checked)
            {
                num++;
            }
            if (this.ck14.Checked)
            {
                num++;
            }
            if (this.ck15.Checked)
            {
                num++;
            }
            if (this.ck16.Checked)
            {
                num++;
            }
            int[] atype = null;
            if (num > 0)
            {
                atype = new int[num];
                num2 = 0;
                if (this.ck11.Checked)
                {
                    atype[num2] = 0;
                    num2++;
                }
                if (this.ck12.Checked)
                {
                    atype[num2] = 1;
                    num2++;
                }
                if (this.ck13.Checked)
                {
                    atype[num2] = 2;
                    num2++;
                }
                if (this.ck14.Checked)
                {
                    atype[num2] = 3;
                    num2++;
                }
                if (this.ck15.Checked)
                {
                    atype[num2] = 4;
                    num2++;
                }
                if (this.ck16.Checked)
                {
                    atype[num2] = 5;
                    num2++;
                }
            }
            this.ICCards = this.iccardmanageservice.QueryCardEx(regoper, cardno, begintime, endtime, ownerid, astatus, atype);
            this.InitGrid();
        }

        public bool CheckCardID(string cardid)
        {
            if ((this.lastrecmsg == cardid) && (((DateTime.Now.Ticks - this.lastrectime) / 0x989680L) < this.timelimit))
            {
                return false;
            }
            if (this.lastrecmsg == cardid)
            {
                return false;
            }
            this.lastrecmsg = cardid;
            this.lastrectime = DateTime.Now.Ticks;
            return true;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                int index = this.dataGridView1.SelectedRows[0].Index;
                if (this.tabControl1.SelectedIndex == 1)
                {
                    VehIC_WF.ICCardManageService.ICCard card = this.ICCards[index];
                    this.CurCard = new VehIC_BL.ICCard(card.ICNo, card.CardNo, card.Reguser, card.Regtime, card.Status, card.Ictype, card.UID, card.UName);
                    this.InitViewEx();
                }
                else
                {
                    this.CurCard = this.NewCars[(this.NewCars.Count - index) - 1];
                    this.InitView();
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

        public void InitGrid()
        {
            this.dataGridView1.Rows.Clear();
            if (this.ICCards != null)
            {
                for (int i = 0; i < this.ICCards.Length; i++)
                {
                    int num2 = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[num2].Cells[0].Value = i.ToString();
                    this.dataGridView1.Rows[num2].Cells[1].Value = this.ICCards[i].ICNo;
                    this.dataGridView1.Rows[num2].Cells[2].Value = this.ICCards[i].CardNo;
                    this.dataGridView1.Rows[num2].Cells[3].Value = this.ICCards[i].Reguser;
                    this.dataGridView1.Rows[num2].Cells[4].Value = this.ICCards[i].Regtime;
                    this.dataGridView1.Rows[num2].Cells[5].Value = VehIC_BL.ICCard.GetStatusDesc(this.ICCards[i].Status);
                    this.dataGridView1.Rows[num2].Cells[6].Value = VehIC_BL.ICCard.GetTypeDesc(this.ICCards[i].Ictype);
                    this.dataGridView1.Rows[num2].Cells[7].Value = this.ICCards[i].UName;
                }
            }
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            this.panel1 = new Panel();
            this.tabControl1 = new TabControl();
            this.tabPage1 = new TabPage();
            this.textBox6 = new TextBox();
            this.textBox5 = new TextBox();
            this.textBox4 = new TextBox();
            this.label6 = new Label();
            this.groupBox1 = new GroupBox();
            this.rb16 = new RadioButton();
            this.rb15 = new RadioButton();
            this.rb14 = new RadioButton();
            this.rb13 = new RadioButton();
            this.rb12 = new RadioButton();
            this.rb11 = new RadioButton();
            this.groupBox3 = new GroupBox();
            this.rb3 = new RadioButton();
            this.rb4 = new RadioButton();
            this.rb2 = new RadioButton();
            this.rb1 = new RadioButton();
            this.label3 = new Label();
            this.label1 = new Label();
            this.textBox2 = new TextBox();
            this.label2 = new Label();
            this.textBox1 = new TextBox();
            this.label4 = new Label();
            this.tabPage2 = new TabPage();
            this.button6 = new Button();
            this.comboBox3 = new ComboBox();
            this.label7 = new Label();
            this.groupBox2 = new GroupBox();
            this.ck16 = new CheckBox();
            this.ck15 = new CheckBox();
            this.ck14 = new CheckBox();
            this.ck13 = new CheckBox();
            this.ck12 = new CheckBox();
            this.ck11 = new CheckBox();
            this.groupBox4 = new GroupBox();
            this.ck3 = new CheckBox();
            this.ck4 = new CheckBox();
            this.ck2 = new CheckBox();
            this.ck1 = new CheckBox();
            this.label8 = new Label();
            this.dateTimePicker3 = new DateTimePicker();
            this.dateTimePicker4 = new DateTimePicker();
            this.label9 = new Label();
            this.comboBox4 = new ComboBox();
            this.label10 = new Label();
            this.textBox3 = new TextBox();
            this.label11 = new Label();
            this.panel3 = new Panel();
            this.button1 = new Button();
            this.btn_new = new Button();
            this.btn_init = new Button();
            this.btn_out = new Button();
            this.btn_lose = new Button();
            this.dataGridView1 = new DataGridView();
            this.Column1 = new DataGridViewTextBoxColumn();
            this.Column2 = new DataGridViewTextBoxColumn();
            this.Column3 = new DataGridViewTextBoxColumn();
            this.Column4 = new DataGridViewTextBoxColumn();
            this.Column5 = new DataGridViewTextBoxColumn();
            this.Column6 = new DataGridViewTextBoxColumn();
            this.Column7 = new DataGridViewTextBoxColumn();
            this.Column8 = new DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Margin = new Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x385, 180);
            this.panel1.TabIndex = 3;
            this.tabControl1.Alignment = TabAlignment.Right;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.tabControl1.Location = new Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(0x2e9, 0xb2);
            this.tabControl1.TabIndex = 0x93;
            this.tabControl1.SelectedIndexChanged += new EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabPage1.BackColor = SystemColors.Control;
            this.tabPage1.Controls.Add(this.textBox6);
            this.tabPage1.Controls.Add(this.textBox5);
            this.tabPage1.Controls.Add(this.textBox4);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new Padding(3);
            this.tabPage1.Size = new Size(0x2cc, 170);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "读卡操作";
            this.textBox6.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox6.Location = new Point(0x14b, 0x27);
            this.textBox6.Margin = new Padding(4);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new Size(0x90, 0x17);
            this.textBox6.TabIndex = 0xb3;
            this.textBox6.TextAlign = HorizontalAlignment.Right;
            this.textBox5.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox5.Location = new Point(0x4a, 0x27);
            this.textBox5.Margin = new Padding(4);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new Size(0x90, 0x17);
            this.textBox5.TabIndex = 0xb2;
            this.textBox5.TextAlign = HorizontalAlignment.Right;
            this.textBox4.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox4.Location = new Point(0x14b, 8);
            this.textBox4.Margin = new Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new Size(0x90, 0x17);
            this.textBox4.TabIndex = 0xb1;
            this.textBox4.TextAlign = HorizontalAlignment.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label6.Location = new Point(0xf2, 0x2b);
            this.label6.Margin = new Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x5b, 14);
            this.label6.TabIndex = 0xaf;
            this.label6.Text = "所属人或车号";
            this.groupBox1.Controls.Add(this.rb16);
            this.groupBox1.Controls.Add(this.rb15);
            this.groupBox1.Controls.Add(this.rb14);
            this.groupBox1.Controls.Add(this.rb13);
            this.groupBox1.Controls.Add(this.rb12);
            this.groupBox1.Controls.Add(this.rb11);
            this.groupBox1.Enabled = false;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.groupBox1.Location = new Point(15, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x2aa, 0x2a);
            this.groupBox1.TabIndex = 0xae;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "  IC卡类型";
            this.rb16.AutoSize = true;
            this.rb16.Location = new Point(0x24b, 0x12);
            this.rb16.Name = "rb16";
            this.rb16.Size = new Size(0x43, 0x12);
            this.rb16.TabIndex = 0xad;
            this.rb16.Text = "指令卡";
            this.rb16.UseVisualStyleBackColor = true;
            this.rb15.AutoSize = true;
            this.rb15.Location = new Point(0x1e9, 0x12);
            this.rb15.Name = "rb15";
            this.rb15.Size = new Size(0x51, 0x12);
            this.rb15.TabIndex = 0xac;
            this.rb15.Text = "操作员卡";
            this.rb15.UseVisualStyleBackColor = true;
            this.rb14.AutoSize = true;
            this.rb14.Location = new Point(0x189, 0x12);
            this.rb14.Name = "rb14";
            this.rb14.Size = new Size(0x43, 0x12);
            this.rb14.TabIndex = 0xab;
            this.rb14.Text = "一次卡";
            this.rb14.UseVisualStyleBackColor = true;
            this.rb13.AutoSize = true;
            this.rb13.Location = new Point(0x129, 0x12);
            this.rb13.Name = "rb13";
            this.rb13.Size = new Size(0x43, 0x12);
            this.rb13.TabIndex = 170;
            this.rb13.Text = "多次卡";
            this.rb13.UseVisualStyleBackColor = true;
            this.rb12.AutoSize = true;
            this.rb12.Location = new Point(0xc9, 0x12);
            this.rb12.Name = "rb12";
            this.rb12.Size = new Size(0x43, 0x12);
            this.rb12.TabIndex = 0xa9;
            this.rb12.Text = "临时卡";
            this.rb12.UseVisualStyleBackColor = true;
            this.rb11.AutoSize = true;
            this.rb11.Checked = true;
            this.rb11.Location = new Point(0x69, 0x12);
            this.rb11.Name = "rb11";
            this.rb11.Size = new Size(0x43, 0x12);
            this.rb11.TabIndex = 0xa8;
            this.rb11.TabStop = true;
            this.rb11.Text = "未指定";
            this.rb11.UseVisualStyleBackColor = true;
            this.groupBox3.Controls.Add(this.rb3);
            this.groupBox3.Controls.Add(this.rb4);
            this.groupBox3.Controls.Add(this.rb2);
            this.groupBox3.Controls.Add(this.rb1);
            this.groupBox3.Enabled = false;
            this.groupBox3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.groupBox3.Location = new Point(15, 0x47);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x2aa, 0x2a);
            this.groupBox3.TabIndex = 0xad;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "  IC卡状态";
            this.rb3.AutoSize = true;
            this.rb3.Location = new Point(0x129, 20);
            this.rb3.Name = "rb3";
            this.rb3.Size = new Size(0x43, 0x12);
            this.rb3.TabIndex = 0xa9;
            this.rb3.TabStop = true;
            this.rb3.Text = "已过期";
            this.rb3.UseVisualStyleBackColor = true;
            this.rb4.AutoSize = true;
            this.rb4.Location = new Point(0x189, 20);
            this.rb4.Name = "rb4";
            this.rb4.Size = new Size(0x43, 0x12);
            this.rb4.TabIndex = 0xa7;
            this.rb4.TabStop = true;
            this.rb4.Text = "已注销";
            this.rb4.UseVisualStyleBackColor = true;
            this.rb2.AutoSize = true;
            this.rb2.Location = new Point(0xc9, 20);
            this.rb2.Name = "rb2";
            this.rb2.Size = new Size(0x43, 0x12);
            this.rb2.TabIndex = 0xa6;
            this.rb2.Text = "使用中";
            this.rb2.UseVisualStyleBackColor = true;
            this.rb1.AutoSize = true;
            this.rb1.Checked = true;
            this.rb1.Location = new Point(0x69, 20);
            this.rb1.Name = "rb1";
            this.rb1.Size = new Size(0x43, 0x12);
            this.rb1.TabIndex = 0xa5;
            this.rb1.TabStop = true;
            this.rb1.Text = "未使用";
            this.rb1.UseVisualStyleBackColor = true;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label3.Location = new Point(12, 0x2b);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x3f, 14);
            this.label3.TabIndex = 0xa9;
            this.label3.Text = "注册时间";
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label1.Location = new Point(0x11d, 12);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x31, 14);
            this.label1.TabIndex = 0xa7;
            this.label1.Text = "注册人";
            this.textBox2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.textBox2.Location = new Point(0x4a, 8);
            this.textBox2.Margin = new Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new Size(0x90, 0x17);
            this.textBox2.TabIndex = 0xa6;
            this.textBox2.TextAlign = HorizontalAlignment.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label2.Location = new Point(12, 12);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x3f, 14);
            this.label2.TabIndex = 0xa5;
            this.label2.Text = "IC序列号";
            this.textBox1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.textBox1.Location = new Point(0x229, 8);
            this.textBox1.Margin = new Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x90, 0x17);
            this.textBox1.TabIndex = 0xa4;
            this.textBox1.TextAlign = HorizontalAlignment.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label4.Location = new Point(0x1fa, 12);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x31, 14);
            this.label4.TabIndex = 0xa3;
            this.label4.Text = "IC卡号";
            this.tabPage2.BackColor = SystemColors.Control;
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.comboBox3);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.dateTimePicker3);
            this.tabPage2.Controls.Add(this.dateTimePicker4);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.comboBox4);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Location = new Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new Padding(3);
            this.tabPage2.Size = new Size(0x2cc, 170);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "查询操作";
            this.button6.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.button6.Location = new Point(0x25b, 0x16);
            this.button6.Name = "button6";
            this.button6.Size = new Size(0x66, 0x1d);
            this.button6.TabIndex = 0xac;
            this.button6.Text = "查询";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new EventHandler(this.button6_Click);
            this.comboBox3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new Point(0x1be, 10);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new Size(0x90, 0x16);
            this.comboBox3.TabIndex = 0xab;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label7.Location = new Point(0x165, 14);
            this.label7.Margin = new Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x5b, 14);
            this.label7.TabIndex = 170;
            this.label7.Text = "所属人或车号";
            this.groupBox2.Controls.Add(this.ck16);
            this.groupBox2.Controls.Add(this.ck15);
            this.groupBox2.Controls.Add(this.ck14);
            this.groupBox2.Controls.Add(this.ck13);
            this.groupBox2.Controls.Add(this.ck12);
            this.groupBox2.Controls.Add(this.ck11);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.groupBox2.Location = new Point(14, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x279, 0x2a);
            this.groupBox2.TabIndex = 0xa9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "  IC卡类型";
            this.ck16.AutoSize = true;
            this.ck16.ForeColor = Color.FromArgb(0, 0xc0, 0);
            this.ck16.Location = new Point(0x220, 0x11);
            this.ck16.Name = "ck16";
            this.ck16.Size = new Size(0x44, 0x12);
            this.ck16.TabIndex = 0xa7;
            this.ck16.Text = "指令卡";
            this.ck16.UseVisualStyleBackColor = true;
            this.ck15.AutoSize = true;
            this.ck15.ForeColor = Color.FromArgb(0, 0xc0, 0);
            this.ck15.Location = new Point(0x1ba, 0x11);
            this.ck15.Name = "ck15";
            this.ck15.Size = new Size(0x52, 0x12);
            this.ck15.TabIndex = 0xa6;
            this.ck15.Text = "操作员卡";
            this.ck15.UseVisualStyleBackColor = true;
            this.ck14.AutoSize = true;
            this.ck14.ForeColor = Color.Blue;
            this.ck14.Location = new Point(0x162, 0x11);
            this.ck14.Name = "ck14";
            this.ck14.Size = new Size(0x44, 0x12);
            this.ck14.TabIndex = 0xa5;
            this.ck14.Text = "一次卡";
            this.ck14.UseVisualStyleBackColor = true;
            this.ck13.AutoSize = true;
            this.ck13.ForeColor = Color.Blue;
            this.ck13.Location = new Point(0x10a, 0x11);
            this.ck13.Name = "ck13";
            this.ck13.Size = new Size(0x44, 0x12);
            this.ck13.TabIndex = 0xa4;
            this.ck13.Text = "多次卡";
            this.ck13.UseVisualStyleBackColor = true;
            this.ck12.AutoSize = true;
            this.ck12.ForeColor = Color.Blue;
            this.ck12.Location = new Point(0xb2, 0x11);
            this.ck12.Name = "ck12";
            this.ck12.Size = new Size(0x44, 0x12);
            this.ck12.TabIndex = 0xa3;
            this.ck12.Text = "临时卡";
            this.ck12.UseVisualStyleBackColor = true;
            this.ck11.AutoSize = true;
            this.ck11.Checked = true;
            this.ck11.CheckState = CheckState.Checked;
            this.ck11.Location = new Point(90, 0x11);
            this.ck11.Name = "ck11";
            this.ck11.Size = new Size(0x44, 0x12);
            this.ck11.TabIndex = 0xa2;
            this.ck11.Text = "未指定";
            this.ck11.UseVisualStyleBackColor = true;
            this.groupBox4.Controls.Add(this.ck3);
            this.groupBox4.Controls.Add(this.ck4);
            this.groupBox4.Controls.Add(this.ck2);
            this.groupBox4.Controls.Add(this.ck1);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.groupBox4.Location = new Point(14, 0x45);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(0x279, 0x2a);
            this.groupBox4.TabIndex = 0xa8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "  IC卡状态";
            this.ck3.AutoSize = true;
            this.ck3.ForeColor = Color.Red;
            this.ck3.Location = new Point(0x10a, 0x11);
            this.ck3.Name = "ck3";
            this.ck3.Size = new Size(0x44, 0x12);
            this.ck3.TabIndex = 0xa5;
            this.ck3.Text = "已过期";
            this.ck3.UseVisualStyleBackColor = true;
            this.ck4.AutoSize = true;
            this.ck4.ForeColor = Color.Red;
            this.ck4.Location = new Point(0x162, 0x11);
            this.ck4.Name = "ck4";
            this.ck4.Size = new Size(0x44, 0x12);
            this.ck4.TabIndex = 0xa3;
            this.ck4.Text = "已注销";
            this.ck4.UseVisualStyleBackColor = true;
            this.ck2.AutoSize = true;
            this.ck2.Checked = true;
            this.ck2.CheckState = CheckState.Checked;
            this.ck2.ForeColor = Color.FromArgb(0, 0xc0, 0);
            this.ck2.Location = new Point(0xb2, 0x11);
            this.ck2.Name = "ck2";
            this.ck2.Size = new Size(0x44, 0x12);
            this.ck2.TabIndex = 0xa2;
            this.ck2.Text = "使用中";
            this.ck2.UseVisualStyleBackColor = true;
            this.ck1.AutoSize = true;
            this.ck1.Checked = true;
            this.ck1.CheckState = CheckState.Checked;
            this.ck1.Location = new Point(90, 0x11);
            this.ck1.Name = "ck1";
            this.ck1.Size = new Size(0x44, 0x12);
            this.ck1.TabIndex = 0xa1;
            this.ck1.Text = "未使用";
            this.ck1.UseVisualStyleBackColor = true;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label8.Location = new Point(0xda, 0x2a);
            this.label8.Margin = new Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x15, 14);
            this.label8.TabIndex = 0xa7;
            this.label8.Text = "至";
            this.dateTimePicker3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.dateTimePicker3.Location = new Point(0xef, 0x25);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new Size(0x8f, 0x17);
            this.dateTimePicker3.TabIndex = 0xa6;
            this.dateTimePicker4.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.dateTimePicker4.Location = new Point(0x49, 0x25);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new Size(0x8f, 0x17);
            this.dateTimePicker4.TabIndex = 0xa5;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label9.Location = new Point(11, 0x29);
            this.label9.Margin = new Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x3f, 14);
            this.label9.TabIndex = 0xa4;
            this.label9.Text = "注册时间";
            this.comboBox4.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new Point(0x49, 10);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new Size(0x90, 0x16);
            this.comboBox4.TabIndex = 0xa3;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label10.Location = new Point(0x19, 14);
            this.label10.Margin = new Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x31, 14);
            this.label10.TabIndex = 0xa2;
            this.label10.Text = "注册人";
            this.textBox3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.textBox3.Location = new Point(0x1be, 0x25);
            this.textBox3.Margin = new Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Size(0x90, 0x17);
            this.textBox3.TabIndex = 0xa1;
            this.textBox3.TextAlign = HorizontalAlignment.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label11.Location = new Point(0x18f, 0x2a);
            this.label11.Margin = new Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x31, 14);
            this.label11.TabIndex = 160;
            this.label11.Text = "IC卡号";
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btn_new);
            this.panel3.Controls.Add(this.btn_init);
            this.panel3.Controls.Add(this.btn_out);
            this.panel3.Controls.Add(this.btn_lose);
            this.panel3.Dock = DockStyle.Right;
            this.panel3.Location = new Point(0x2e9, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(0x9a, 0xb2);
            this.panel3.TabIndex = 0x92;
            this.button1.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.button1.Location = new Point(0x20, 0x70);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x5d, 0x30);
            this.button1.TabIndex = 0x93;
            this.button1.Text = "初始卡关闭单据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.btn_new.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btn_new.ImageAlign = ContentAlignment.MiddleLeft;
            this.btn_new.Location = new Point(0x1b, 0x10);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new Size(0x66, 0x1d);
            this.btn_new.TabIndex = 0x8f;
            this.btn_new.Text = "注册新卡";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new EventHandler(this.button2_Click);
            this.btn_init.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btn_init.Location = new Point(0x1b, 0x3f);
            this.btn_init.Name = "btn_init";
            this.btn_init.Size = new Size(0x66, 0x1d);
            this.btn_init.TabIndex = 0x92;
            this.btn_init.Text = "初始化";
            this.btn_init.UseVisualStyleBackColor = true;
            this.btn_init.Click += new EventHandler(this.button5_Click);
            this.btn_out.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btn_out.Location = new Point(0x1b, 0x3f);
            this.btn_out.Name = "btn_out";
            this.btn_out.Size = new Size(0x66, 0x1d);
            this.btn_out.TabIndex = 0x91;
            this.btn_out.Text = "注销";
            this.btn_out.UseVisualStyleBackColor = true;
            this.btn_out.Visible = false;
            this.btn_out.Click += new EventHandler(this.button4_Click);
            this.btn_lose.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btn_lose.Location = new Point(0x1b, 0x10);
            this.btn_lose.Name = "btn_lose";
            this.btn_lose.Size = new Size(0x66, 0x1d);
            this.btn_lose.TabIndex = 0x90;
            this.btn_lose.Text = "挂失";
            this.btn_lose.UseVisualStyleBackColor = true;
            this.btn_lose.Visible = false;
            this.btn_lose.Click += new EventHandler(this.button3_Click);
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            style.BackColor = SystemColors.Info;
            style.FormatProvider = new CultureInfo("en-US");
            this.dataGridView1.AlternatingRowsDefaultCellStyle = style;
            this.dataGridView1.ColumnHeadersHeight = 0x19;
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { this.Column1, this.Column2, this.Column3, this.Column4, this.Column5, this.Column6, this.Column7, this.Column8 });
            style2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style2.BackColor = SystemColors.Window;
            style2.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            style2.ForeColor = SystemColors.ControlText;
            style2.FormatProvider = new CultureInfo("en-US");
            style2.SelectionBackColor = SystemColors.Control;
            style2.SelectionForeColor = SystemColors.ControlText;
            style2.WrapMode = DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = style2;
            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.GridColor = Color.PaleGoldenrod;
            this.dataGridView1.Location = new Point(0, 180);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 10;
            this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            style3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.dataGridView1.RowsDefaultCellStyle = style3;
            this.dataGridView1.RowTemplate.Height = 20;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(0x385, 0x1b0);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.Text = "dataGridView1";
            this.dataGridView1.DoubleClick += new EventHandler(this.dataGridView1_DoubleClick);
            this.Column1.HeaderText = "行号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 40;
            this.Column2.HeaderText = "IC序列号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 110;
            this.Column3.HeaderText = "IC卡号";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 110;
            this.Column4.HeaderText = "注册人";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column5.HeaderText = "注册时间";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 180;
            this.Column6.HeaderText = "磁卡类型";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 0x4b;
            this.Column7.HeaderText = "磁卡状态";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 0x4b;
            this.Column8.HeaderText = "所属人或车";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 150;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.dataGridView1);
            base.Controls.Add(this.panel1);
            base.Name = "FC_CardRegistry";
            base.Size = new Size(0x385, 0x264);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            base.ResumeLayout(false);
        }

        public void InitView()
        {
            if (this.CurCard != null)
            {
                if (this.CurCard.CardNo == "")
                {
                    string s = this.textBox1.Text.Trim();
                    int num = 0;
                    try
                    {
                        num = int.Parse(s);
                    }
                    catch (Exception)
                    {
                    }
                    if (num != 0)
                    {
                        num++;
                        this.textBox1.Text = num.ToString("D8");
                    }
                    this.textBox4.Text = this.CurCard.Reguser;
                    this.textBox5.Text = this.CurCard.Regtime;
                    this.textBox6.Text = this.CurCard.UName;
                    this.btn_new.Text = "注册新卡";
                    this.btn_init.Enabled = false;
                    this.btn_lose.Enabled = false;
                    this.btn_out.Enabled = false;
                }
                else
                {
                    this.textBox1.Text = this.CurCard.CardNo;
                    this.textBox4.Text = this.CurCard.Reguser;
                    this.textBox5.Text = this.CurCard.Regtime;
                    this.textBox6.Text = this.CurCard.UName;
                    this.btn_new.Text = "更新卡号";
                }
                switch (this.CurCard.Status)
                {
                    case 0:
                        this.rb1.Checked = true;
                        break;

                    case 1:
                        this.rb2.Checked = true;
                        break;

                    case 2:
                        this.rb3.Checked = true;
                        break;

                    case 3:
                        this.rb4.Checked = true;
                        break;
                }
                if (this.rb4.Checked)
                {
                    this.btn_init.Enabled = true;
                }
                switch (this.CurCard.Ictype)
                {
                    case 0:
                        this.rb11.Checked = true;
                        break;

                    case 1:
                        this.rb12.Checked = true;
                        break;

                    case 2:
                        this.rb13.Checked = true;
                        break;

                    case 3:
                        this.rb14.Checked = true;
                        break;

                    case 4:
                        this.rb15.Checked = true;
                        break;

                    case 5:
                        this.rb16.Checked = true;
                        break;
                }
                this.textBox1.Focus();
            }
        }

        public void InitViewEx()
        {
            if (this.CurCard != null)
            {
                this.ck1.Checked = false;
                this.ck2.Checked = false;
                this.ck3.Checked = false;
                this.ck4.Checked = false;
                this.ck11.Checked = false;
                this.ck12.Checked = false;
                this.ck13.Checked = false;
                this.ck14.Checked = false;
                this.ck15.Checked = false;
                this.ck16.Checked = false;
                this.comboBox4.Text = this.CurCard.Reguser;
                this.comboBox3.Text = this.CurCard.UName;
                this.textBox3.Text = this.CurCard.CardNo;
                this.btn_new.Text = "更新卡号";
                switch (this.CurCard.Status)
                {
                    case 0:
                        this.ck1.Checked = true;
                        break;

                    case 1:
                        this.ck2.Checked = true;
                        break;

                    case 2:
                        this.ck3.Checked = true;
                        break;

                    case 3:
                        this.ck4.Checked = true;
                        break;
                }
                switch (this.CurCard.Ictype)
                {
                    case 0:
                        this.ck11.Checked = true;
                        break;

                    case 1:
                        this.ck12.Checked = true;
                        break;

                    case 2:
                        this.ck13.Checked = true;
                        break;

                    case 3:
                        this.ck14.Checked = true;
                        break;

                    case 4:
                        this.ck15.Checked = true;
                        break;

                    case 5:
                        this.ck16.Checked = true;
                        break;
                }
                this.textBox3.Focus();
            }
        }

        public void HandleCardMessage(Device.CardReader device, string cardid)
        {
            if ((this.tabControl1.SelectedIndex == 0) && this.CheckCardID(cardid))
            {
                VehIC_WF.ICCardManageService.ICCard card = this.iccardmanageservice.GetCard(cardid);
                if (card == null)
                {
                    MessageBox.Show("获取卡信息失败！");
                    this.textBox2.Text = string.Empty;
                }
                else
                {
                    this.textBox2.Text = cardid;
                    this.CurCard = new VehIC_BL.ICCard(card.ICNo, card.CardNo, card.Reguser, card.Regtime, card.Status, card.Ictype, card.UID, card.UName);
                    this.InitView();
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            this.CurCard = null;
            this.ICCards = null;
            this.NewCars = null;
            this.btn_init.Enabled = this.btn_lose.Enabled = this.btn_new.Enabled = this.btn_out.Enabled = true;
            if (this.tabControl1.SelectedIndex == 0)
            {
                this.btn_lose.Enabled = false;
            }
            else
            {
                this.btn_new.Enabled = false;
            }
        }

        public void UpdateCurCard()
        {
            if (this.CurCard != null)
            {
                int index;
                if (this.tabControl1.SelectedIndex != 1)
                {
                    if (this.NewCars != null)
                    {
                        index = this.NewCars.IndexOf(this.CurCard.ICNo);
                        this.NewCars[index].CardNo = this.CurCard.CardNo;
                        this.dataGridView1.Rows[(this.dataGridView1.Rows.Count - index) - 1].Cells[2].Value = this.CurCard.CardNo;
                    }
                }
                else if (this.ICCards != null)
                {
                    index = -1;
                    for (int i = 0; i < this.ICCards.Length; i++)
                    {
                        if (this.ICCards[i].ICNo == this.CurCard.ICNo)
                        {
                            index = i;
                            break;
                        }
                    }
                    if (index != -1)
                    {
                        this.ICCards[index].CardNo = this.CurCard.CardNo;
                        this.dataGridView1.Rows[index].Cells[2].Value = this.CurCard.CardNo;
                    }
                }
            }
        }

    }
}

