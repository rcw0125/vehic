namespace VehIC_WF
{
    using Sunisoft.IrisSkin;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using VehIC_BL;
    using VehIC_Device;
    using VehIC_WF.AuthService;
    using VehIC_WF.CommonService;
    using VehIC_WF.Device;
    using VehIC_WF.ICCardManageService;
    using VehIC_WF.Utility;

    public class FrmLogin : Form,ICardMessage
    {
        private Button btnCancel;
        private Button btnOK;
        private IContainer components = null;
        public VehIC_WF.CommonService.CommonService cs;
        public VehIC_WF.ICCardManageService.ICCardManageService ic;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        public string lastrecmsg = string.Empty;
        public long lastrectime = 0L;
        // public InvokeDelegate OnMsg;
        private FixRFIDReader Reader1 = null;
        private MoblieReader Reader2 = null;
       // private bool result1 = false;
       // private bool result2 = false;
        private SkinEngine skinEngine1;
        private bool sklogin = false;
        private TextBox textBox1;
        private TextBox textBox2;
        public int timelimit = 10;
        private PictureBox pictureBox1;
        private Timer timer1;

        public FrmLogin()
        {
            this.InitializeComponent();
            this.skinEngine1.SkinFile = "MP10.ssk";
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Login();
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
            try
            {
                this.Reader1.Dispose();
            }
            catch
            {
            }
            try
            {
                this.Reader2.Dispose();
            }
            catch
            {
            }
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.cs = new VehIC_WF.CommonService.CommonService();
            this.ic = new VehIC_WF.ICCardManageService.ICCardManageService();
            this.cs.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/CommonService.asmx";
            this.ic.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/ICCardManageService.asmx";
            //this.sklogin = this.cs.GetSystemPara("LoginByIc") == "1";
            // this.OnMsg = new InvokeDelegate(this.HandleMessage);
            //if (this.sklogin && this.LoadDevice())
            // if (this.sklogin && FrmMain.localinfo.device_reader_status)
            //if (this.sklogin && DeviceManager.Instance.HaveAvailableCardReader())
            //{
            //    this.textBox1.ReadOnly = true;
            //    this.OnMsg = new InvokeDelegate(this.HandleMessage);
            //    this.timer1.Start();
            //}
            //else
            //{
            this.textBox1.Focus();
            //}
        }

        public void HandleCardMessage(CardReader cardReader,string cardid)
        {
            if (cardReader.UseType == CardReaderUseType.室内)
            {
                if (this.CheckCardID(cardid))
                {
                    VehIC_WF.ICCardManageService.ICCard card = this.ic.GetCard(cardid);
                    if (card.CardNo != string.Empty)
                    {
                        if (card.Status != 1)
                        {
                            MessageBox.Show("磁卡不在使用状态！");
                        }
                        else if (card.Ictype < 4)
                        {
                            MessageBox.Show("磁卡不在使用类型！");
                        }
                        else
                        {
                            this.textBox1.Text = card.UID;
                            this.textBox2.Focus();
                        }
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(143, 93);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(143, 136);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(170, 26);
            this.textBox2.TabIndex = 2;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(211, 197);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(89, 30);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(316, 197);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "用户编码";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(104, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "密码";
            // 
            // skinEngine1
            // 
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(84, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 50);
            this.label1.TabIndex = 9;
            this.label1.Text = "邢钢检化验系统";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(351, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "XG V1.0";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::Properties.Resources.huayan;
            this.pictureBox1.Location = new System.Drawing.Point(11, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 239);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void Login()
        {
            string uid = this.textBox1.Text.Trim();
            string str2 = this.textBox2.Text.Trim();
            if (uid == string.Empty)
            {
                MessageBox.Show("用户ID不允许为空！");
                this.textBox1.SelectAll();
                this.textBox1.Focus();
            }
            else if (str2 == string.Empty)
            {
                MessageBox.Show("用户密码不允许为空！");
                this.textBox2.SelectAll();
                this.textBox2.Focus();
            }
            else if (FrmMain.localinfo.ISLocked)
            {
                if (uid != LocalInfo.Current.user.ID)
                {
                    MessageBox.Show("用户名错误！");
                }
                else if (FrmMain.localinfo.user.Pass != str2)
                {
                    MessageBox.Show("用户密码不对！");
                }
                else
                {
                    base.DialogResult = DialogResult.OK;
                    base.Close();
                }
            }
            else
            {
                VehIC_WF.AuthService.AuthService service = new VehIC_WF.AuthService.AuthService();
                service.Url = "http://" + FrmMain.localinfo.ServerUrl + "/VehIC_WS/AuthService.asmx";
                VehIC_WF.AuthService.UserInfo userInfo = service.GetUserInfo(uid);
                if (userInfo == null)
                {
                    MessageBox.Show("不存在此用户！");
                }
                else if (userInfo.PassWord != str2)
                {
                    MessageBox.Show("用户密码不对！");
                }
                else if (!userInfo.Enable)
                {
                    MessageBox.Show("此用户已经被禁用！");
                }
                else
                {
                    FrmMain.localinfo.user = new VehIC_WF.UserInfo();
                    FrmMain.localinfo.user.authority = new AuthorityList(userInfo.authoritylist);
                    FrmMain.localinfo.user.workpointlist = new WorkPointList(userInfo.workpointlist);
                    FrmMain.localinfo.user.Dept = userInfo.Dept;
                    FrmMain.localinfo.user.Enable = userInfo.Enable;
                    FrmMain.localinfo.user.ICCardID = userInfo.ICCardID;
                    FrmMain.localinfo.user.ICCardNo = userInfo.ICCardNo;
                    FrmMain.localinfo.user.ICCardStatus = userInfo.ICCardStatus;
                    LocalInfo.Current.user.ID = userInfo.ID;
                    FrmMain.localinfo.user.Name = userInfo.Name;
                    FrmMain.localinfo.user.Pass = userInfo.PassWord;
                    base.DialogResult = DialogResult.OK;
                    base.Close();
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                if (this.textBox1.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("用户ID不允许为空！");
                    this.textBox1.SelectAll();
                    this.textBox1.Focus();
                }
                else
                {
                    this.textBox2.Focus();
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.Login();
            }
        }

        public delegate void InvokeDelegate(string data);

        private void btnSysConfig_Click(object sender, EventArgs e)
        {
            FrmSetServerConnection connection = new FrmSetServerConnection();
            if (DialogResult.OK == connection.ShowDialog())
            {
                connection.Dispose();
                MessageBox.Show("设置完成，系统即将关闭，请重新启动。");
                base.Close();
            }
        }
    }
}

