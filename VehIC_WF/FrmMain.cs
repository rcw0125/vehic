namespace VehIC_WF
{
    using Sunisoft.IrisSkin;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Windows.Forms;
    using Tools;
    using VehIC_BL;
    using VehIC_Device;
    using VehIC_WF.CommonService;
    using VehIC_WF.Device;
    using VehIC_WF.DoorService;
    using VehIC_WF.ICManage;
    using VehIC_WF.Properties;
    using VehIC_WF.Sampling;
    using VehIC_WF.Sampling.czl.WorkPoint;
    using VehIC_WF.Sampling.lhl;
    using VehIC_WF.Search;
    using VehIC_WF.Utility;
    using VehIC_WF.WorkPoint;
   
    using Xg.Lab.Sample;
    using Zhc.Data;

    public delegate void CardReaderDelegate(CardReader device, string data);

    public class FrmMain : Form
    {
        private Dictionary<Page, Type> pnl_Types = new Dictionary<Page, Type>() 
        { 
           {Page.Head,typeof(FC_Head)},
           {Page.Locked,typeof(FC_Locked)},
           {Page.DeviceManage,typeof(UC_DeviceManage)},
           {Page.RFBarcode,typeof(FC_RFBarcode)},
           {Page.RFBarcodeEx,typeof(FC_RFBarcodeEx)} ,
           {Page.ICCard_Registry,typeof(FC_CardRegistry)},
           {Page.ICCard_Oper,typeof(FC_OperaterCard)},
           {Page.ICCard_MatVeh,typeof(FC_MatVehCard)},
           {Page.ICCard_MatVehEx,typeof(FC_MatVehCardEx)},
           {Page.ICCard_Multi,typeof(FC_FixVehCard)} ,
          
          
           {Page.WP_Sampling,typeof(WP_Sampling)},
           {Page.WP_JFSampling,typeof(WP_JFSampling)},
        
           {Page.Search,typeof(FC_Search)},  
           {Page.WP_ZuPi,typeof(Hunyang)},
                    {Page.WP_JFZuPi,typeof(JFHunyang)},
           {Page.SP_CheckGroup,typeof(Sampling.UC_CheckGroup)},
           {Page.SP_CheckItem,typeof(Sampling.UC_CheckItem)},
           {Page.SP_MatStandard,typeof(Sampling.UC_MatCheckStandard)},
           {Page.SP_QualityRule,typeof(Sampling.UC_Zupi)},
           {Page.SP_ICReg,typeof(Sampling.UC_ICReg)},
           {Page.SP_ExamineSample,typeof(Sampling.UC_ExamineSample)},
           {Page.SP_ManageExamineSample,typeof(VehIC_WF.Sampling.UC_ManageExamineSample)},
           {Page.SP_QualityJudge,typeof(Sampling.UC_QualityJudge)},
              {Page.SP_JFQualityJudge,typeof(Sampling.UC_JFQualityJudge)},
                  {Page.SP_WKQualityJudge,typeof(Sampling.UC_WKQualityJudge)},
           {Page.SP_VerifSample,typeof(Sampling.UC_VerifSam)},
           {Page.WP_ZhiYang,typeof(VehIC_WF.WorkPoint.WP_Zhiyang)},
           {Page.WP_HuaYan,typeof(VehIC_WF.WorkPoint.WP_Jianyan)},
            {Page.WP_JFHuaYan,typeof(VehIC_WF.WorkPoint.WP_JFJianyan)},
               {Page.WP_WKHuaYan,typeof(VehIC_WF.WorkPoint.WP_WKJianyan)},
             {Page.WP_JFZhiYang,typeof(VehIC_WF.WorkPoint.WP_JFZhiyang)},
           {Page.zpgz,typeof(VehIC_WF.Sampling.WP_Tbzd)},
           {Page.WP_HuaYanShenHe,typeof(VehIC_WF.WorkPoint.WP_Shenhe)},
             {Page.WP_JFHuaYanShenHe,typeof(VehIC_WF.WorkPoint.WP_JFShenhe)},
             {Page.WP_WKHuaYanShenHe,typeof(VehIC_WF.WorkPoint.WP_WKShenhe)},
           {Page.SP_WpRoute,typeof(Sampling.UC_WpRoute)}, 
           {Page.SP_AddCheckItem,typeof(VehIC_WF.Sampling.czl.UC_AddCheckItem)},
           {Page.SP_ReCheck,typeof(Sampling.UC_ReCheck)},
           {Page.WP_Tbzd,typeof(Sampling.WP_Tbzd)},
              {Page.WP_Hcqy,typeof(Sampling.WP_Hcqy)},
           {Page.SR_Manage,typeof(Sampling.glcx)},
           {Page.SR_Xiugai,typeof(Sampling.xgcx)},
           {Page.SR_QuYang,typeof(Sampling.WP_ChaXun)},
           {Page.SR_ZhiYang,typeof(VehIC_WF.Sampling.czl.WorkPoint.WP_Zycx)},
           {Page.SR_HuaYan,typeof(VehIC_WF.Sampling.czl.WorkPoint.WP_Hycx)},
           {Page.SR_ShenHe,typeof(VehIC_WF.Sampling.czl.WorkPoint.WP_Shcx)},
           {Page.SR_Caigou,typeof(VehIC_WF.Sampling.czl.chaxun.WP_Cgcx)},
           {Page.SR_ZongHeKe,typeof(VehIC_WF.Sampling.czl.WorkPoint.WP_Zhkcx)},
           {Page.WP_WKzupi,typeof(VehIC_WF.Sampling.czl.WorkPoint.WP_WKzupi)},
            {Page.WP_WKZhiYang,typeof( VehIC_WF.WorkPoint.WP_WKZhiyang)},
           {Page.SR_YingGuang,typeof(VehIC_WF.Sampling.czl.WorkPoint.YingGuang)},
           {Page.SR_Shangchuan,typeof(VehIC_WF.WorkPoint.WP_Shangchuan)},
           //火运取样
           {Page.WP_HYSampling,typeof(VehIC_WF.Sampling.rcw.trainGouDui)},
           //火运制样
           {Page.WP_HYZYSampling,typeof(VehIC_WF.WorkPoint.WP_HYZhiyang)},
           //火运化验
           {Page.WP_HYHuaYanShenHe,typeof(VehIC_WF.WorkPoint.WP_HYShenhe)},
           {Page.WP_HYHuaYan,typeof(VehIC_WF.Sampling.rcw.WP_HYJianyan)},
           {Page.SR_Pdyj,typeof(VehIC_WF.Sampling.czl.WorkPoint.UC_Zdpdyj)},
                {Page.SR_Hbcx,typeof(VehIC_WF.Sampling.czl.WorkPoint.WP_hbcx)},
                {Page.SR_Qyxx,typeof(VehIC_WF.Sampling.DlgQyxx)},
                {Page.SR_QYCX,typeof(VehIC_WF.Sampling.czl.WorkPoint.WP_SCNCcx)},
                {Page.WP_HJZuPi,typeof(HJHeyang)},
                {Page.WP_HJZhiYang,typeof(WP_HJZhiyang)},
                {Page.WP_HJHuaYan,typeof(WP_HJJianyan)},
                {Page.WP_HJHuaYanShenHe,typeof(WP_HJShenhe)},
                {Page.SP_HJQualityJudge,typeof(UC_HJQualityJudge)},
                  {Page.WP_SZZuPi,typeof(WP_SZzupi)},
                  {Page.WP_SZZhiYang,typeof(WP_SZZhiyang)},
                  {Page.SP_SZQualityJudge,typeof(UC_SZQualityJudge)},
                   {Page.WP_RJZuPi,typeof(WP_RJzupi)},
                    {Page.WP_RJZhiYang,typeof(WP_RJZhiyang)},
                   {Page.SP_RJQualityJudge,typeof(UC_RJQualityJudge)},
                    {Page.WP_JTZuPi,typeof(WP_JTzupi)},
                    {Page.WP_JTZhiYang,typeof(WP_JTZhiyang)},
                   {Page.SP_JTQualityJudge,typeof(UC_JTQualityJudge)}, 
                   {Page.SP_HYQualityJudge,typeof(UC_HYQualityJudge)}

        };

        private Dictionary<Page, UserControl> pnl_Cache = new Dictionary<Page, UserControl>();

        // private MouseKeyHook mouseKeyHook1=new MouseKeyHook();

        private FC_Head pnl_head
        {
            get
            {
                if (pnl_Cache.ContainsKey(Page.Head))
                    return pnl_Cache[Page.Head] as FC_Head;
                else
                    return null;
            }
        }
      

        private Page CurPage = Page.Head;


        private IContainer components = null;
        public static CardReaderDelegate DisptachMessage;
        public static ViewPage showpage = null;

        public bool ISRfBarcodeOpened = false;
        public Page LastPage;
        private FrmLogin login = null;

        public static LocalInfo localinfo = new LocalInfo();
        public static bool SimulationCom = false;
        public static bool Debug = false;

        private Panel mainPanel;
        private ImageList imageList1;
        private SkinEngine skinEngine1;
        private StatusStrip statusStrip1;
        private Timer timer1;
        private ToolStripButton tsBtnWpReg;
        private ToolStripSplitButton tsBtn_WpSelect;
        private ToolStrip toolStrip1;
        private ToolStripButton tsBtnGetDeviceAuth;
        private ToolStripButton tsBtnLock;
        private ToolStripButton tsBtnCardReg;
        private ToolStripButton tsBtnQuit;
        private ToolStripButton tsBtnHelp;
        private ToolStripButton tsBtnChgPsw;
        private ToolStripButton tsBtnNoticeBillQuery;
        private ToolStripButton tsBtnBack;
        private ToolStripButton tsBtnDeviceManage;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripMenuItem tsmBtnDckFk;
        private ToolStripMenuItem tsmBtnLskFk;
        private ToolStripMenuItem tsmBtnLskBk;
        private ToolStripMenuItem tsmBtnXccFk;
        private ToolStripMenuItem tsmBtnXccBk;
        private ToolStripMenuItem tsmBtnCzyFk;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripButton tsBtnLogin;
        private ToolStripSplitButton btn_Jhy;
        private ToolStripMenuItem btnJyfl;
        private ToolStripMenuItem btnJyxm;
        private ToolStripMenuItem btnJybz;
        private ToolStripMenuItem btnExamine;
        private ToolStripMenuItem tsmBtnVerifSample;
        private ToolStripMenuItem tsmBtnICReg;
        private ToolStripButton tsBtnInOutDoor;
        private ToolStripMenuItem tsmBtn_QualityJudge;
        private ToolStripMenuItem 化验数据菜单;
        private ToolStripMenuItem 化验审核ToolStripMenuItem;
        private ToolStripButton tsmSysConfig;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem 特别指定菜单;
        private ToolStripMenuItem 检验路径ToolStripMenuItem;
        private Timer timer2;
        private ToolStripMenuItem 管理抽样ToolStripMenuItem;
        private ToolStripMenuItem 复检ToolStripMenuItem;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem 管理查询ToolStripMenuItem;
        private ToolStripMenuItem 精煤化验ToolStripMenuItem;
        private ToolStripMenuItem 精粉化验ToolStripMenuItem;
        private ToolStripMenuItem 检验数据上传ToolStripMenuItem;
        private ToolStripMenuItem 精粉化验审核ToolStripMenuItem;
        private ToolStripMenuItem 荧光仪数据ToolStripMenuItem;
        private ToolStripMenuItem 自动判定依据ToolStripMenuItem;
        private ToolStripMenuItem 回传取样信息ToolStripMenuItem;
        private ToolStripMenuItem 制样查询ToolStripMenuItem;
        private ToolStripMenuItem 化验查询ToolStripMenuItem;
        private ToolStripMenuItem 审核查询ToolStripMenuItem;
        private ToolStripMenuItem 采购查询ToolStripMenuItem;
        private ToolStripMenuItem 取样查询ToolStripMenuItem;
        private ToolStripMenuItem 修改查询ToolStripMenuItem;
        private ToolStripMenuItem 取样机采集信息修改ToolStripMenuItem;
        private ToolStripMenuItem 外矿化验ToolStripMenuItem;
        private ToolStripMenuItem 外矿化验审核ToolStripMenuItem;
        private ToolStripMenuItem 取用查询ToolStripMenuItem;
        private ToolStripMenuItem 合金化验ToolStripMenuItem;
        private ToolStripMenuItem 合金化验审核ToolStripMenuItem;
        private ToolStripMenuItem 火运化验ToolStripMenuItem;
        private ToolStripMenuItem 火运化验审核ToolStripMenuItem;

        private FC_Loading pnl_loading = new FC_Loading();
        public FrmMain()
        {
            this.InitializeComponent();
            SimulationCom = Debug;
            showpage = new ViewPage(this.ShowPage);
            pnl_loading.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(pnl_loading);

            //foreach (var item in Tools.USB.AllUsbDevices)
            //{
            //    if (item.Name == "HID Keyboard Device")
            //        Console.WriteLine(item.ToString());
            //}

            //DisptachMessage = new CardReaderDelegate(this.HandleMessage);
            //mouseKeyHook1.KeyDown += mouseKeyHook1_KeyDown;
        }
        //private StringBuilder sb = new StringBuilder();
        //DateTime t1old;
        //DateTime t1new;
        //string teamstr = "";

        //void mouseKeyHook1_KeyDown(object sender, KeyEventArgs e)
        //{

        //     t1new = t1old;
        //    t1old = System.DateTime.Now;

        //    switch (e.KeyCode)
        //    {
        //        case Keys.D0:

        //            if (Math.Abs(t1new.Millisecond - t1old.Millisecond) < 399)
        //            {
        //                sb.Append(teamstr);
        //                teamstr = "";
        //                sb.Append("0");
        //                e.Handled = true;
        //            }
        //            else
        //            {
        //                sb.Append("0");
        //                SendKeys.Send(sb.ToString());
        //                teamstr = sb.ToString();
        //                sb.Clear();
        //            }
        //            e.Handled = true;
        //             break;
        //        case Keys.D1:
        //            if (Math.Abs(t1new.Millisecond - t1old.Millisecond) < 399)
        //            {
        //                sb.Append(teamstr);
        //                teamstr = "";
        //                sb.Append("1");
        //                e.Handled = true;
        //            }
        //            else
        //            {
        //                sb.Append("1");

        //                    SendKeys.Send(sb.ToString());
        //                teamstr = sb.ToString();
        //                sb.Clear();
        //            }

        //             e.Handled = true;
        //            break;
        //        case Keys.D2:
        //               if (Math.Abs(t1new.Millisecond - t1old.Millisecond) < 399)
        //            {
        //                sb.Append(teamstr);
        //                teamstr = "";
        //                sb.Append("2");
        //                e.Handled = true;
        //            }
        //            else
        //            {
        //                sb.Append("2");
        //                SendKeys.Send(sb.ToString());
        //                teamstr = sb.ToString();
        //                sb.Clear();
        //            }
        //            e.Handled = true;
        //            break;
        //        case Keys.D3:
        //           if (Math.Abs(t1new.Millisecond - t1old.Millisecond) < 399)
        //            {
        //                sb.Append(teamstr);
        //                teamstr = "";
        //                sb.Append("3");
        //                e.Handled = true;
        //            }
        //            else
        //            {
        //                sb.Append("3");
        //                SendKeys.Send(sb.ToString());
        //                teamstr = sb.ToString();
        //                sb.Clear();
        //            }
        //            e.Handled = true;
        //            break;
        //        case Keys.D4:
        //             if (Math.Abs(t1new.Millisecond - t1old.Millisecond) < 399)
        //            {
        //                sb.Append(teamstr);
        //                teamstr = "";
        //                sb.Append("4");
        //                e.Handled = true;
        //            }
        //            else
        //            {
        //                sb.Append("4");
        //                SendKeys.Send(sb.ToString());
        //                teamstr = sb.ToString();
        //                sb.Clear();
        //            }
        //            e.Handled = true;
        //            break;
        //        case Keys.D5:
        //                if (Math.Abs(t1new.Millisecond - t1old.Millisecond) < 399)
        //            {
        //                sb.Append(teamstr);
        //                teamstr = "";
        //                sb.Append("5");
        //                e.Handled = true;
        //            }
        //            else
        //            {
        //                sb.Append("5");
        //                SendKeys.Send(sb.ToString());
        //                teamstr = sb.ToString();
        //                sb.Clear();
        //            }
        //            e.Handled = true;
        //            break;
        //        case Keys.D6:
        //                if (Math.Abs(t1new.Millisecond - t1old.Millisecond) < 399)
        //            {
        //                sb.Append(teamstr);
        //                teamstr = "";
        //                sb.Append("6");
        //                e.Handled = true;
        //            }
        //            else
        //            {
        //                sb.Append("6");
        //                SendKeys.Send(sb.ToString());
        //                teamstr = sb.ToString();
        //                sb.Clear();
        //            }
        //            e.Handled = true;
        //            break;
        //        case Keys.D7:
        //               if (Math.Abs(t1new.Millisecond - t1old.Millisecond) < 399)
        //            {
        //                sb.Append(teamstr);
        //                teamstr = "";
        //                sb.Append("7");
        //                e.Handled = true;
        //            }
        //            else
        //            {
        //                sb.Append("7");
        //                SendKeys.Send(sb.ToString());
        //                teamstr = sb.ToString();
        //                sb.Clear();
        //            }
        //            e.Handled = true;
        //            break;
        //        case Keys.D8:
        //             if (Math.Abs(t1new.Millisecond - t1old.Millisecond) < 399)
        //            {
        //                sb.Append(teamstr);
        //                teamstr = "";
        //                sb.Append("8");
        //                e.Handled = true;
        //            }
        //            else
        //            {
        //                sb.Append("8");
        //                SendKeys.Send(sb.ToString());
        //                teamstr = sb.ToString();
        //                sb.Clear();
        //            }
        //            e.Handled = true;
        //            break;
        //        case Keys.D9:
        //              if (Math.Abs(t1new.Millisecond - t1old.Millisecond) < 399)
        //            {
        //                sb.Append(teamstr);
        //                teamstr = "";
        //                sb.Append("9");
        //                e.Handled = true;
        //            }
        //            else
        //            {
        //                sb.Append("9");
        //                SendKeys.Send(sb.ToString());
        //                teamstr = sb.ToString();
        //                sb.Clear();
        //            }
        //            e.Handled = true;
        //            break;
        //        case Keys.A:
        //               if (Math.Abs(t1new.Millisecond - t1old.Millisecond) < 399)
        //            {
        //                sb.Append(teamstr);
        //                teamstr = "";
        //                sb.Append("A");
        //                e.Handled = true;
        //            }
        //            else
        //            {
        //                sb.Append("A");
        //                SendKeys.Send(sb.ToString());
        //                teamstr = sb.ToString();
        //                sb.Clear();
        //            }
        //            e.Handled = true;
        //            break;
        //        case Keys.B:
        //              if (Math.Abs(t1new.Millisecond - t1old.Millisecond) < 399)
        //            {
        //                sb.Append(teamstr);
        //                teamstr = "";
        //                sb.Append("B");
        //                e.Handled = true;
        //            }
        //            else
        //            {
        //                sb.Append("B");
        //                SendKeys.Send(sb.ToString());
        //                teamstr = sb.ToString();
        //                sb.Clear();
        //            }
        //            e.Handled = true;
        //            break;
        //        case Keys.C:
        //               if (Math.Abs(t1new.Millisecond - t1old.Millisecond) < 399)
        //            {
        //                sb.Append(teamstr);
        //                teamstr = "";
        //                sb.Append("C");
        //                e.Handled = true;
        //            }
        //            else
        //            {
        //                sb.Append("C");
        //                SendKeys.Send(sb.ToString());
        //                teamstr = sb.ToString();
        //                sb.Clear();
        //            }
        //            e.Handled = true;
        //            break;
        //        case Keys.D:
        //               if (Math.Abs(t1new.Millisecond - t1old.Millisecond) < 399)
        //            {
        //                sb.Append(teamstr);
        //                teamstr = "";
        //                sb.Append("D");
        //                e.Handled = true;
        //            }
        //            else
        //            {
        //                sb.Append("D");
        //                    teamstr = "";
        //                SendKeys.Send(sb.ToString());
        //                teamstr = sb.ToString();
        //                sb.Clear();
        //            }
        //            e.Handled = true;
        //            break; 
        //        case Keys.E:
        //               if (Math.Abs(t1new.Millisecond - t1old.Millisecond) < 399)
        //            {
        //                sb.Append(teamstr);
        //                teamstr = "";
        //                sb.Append("E");
        //                e.Handled = true;
        //            }
        //            else
        //            {
        //                sb.Append("E");
        //                SendKeys.Send(sb.ToString());
        //                teamstr = sb.ToString();
        //                sb.Clear();
        //            }
        //            e.Handled = true;
        //            break;
        //        case Keys.F:
        //               if (Math.Abs(t1new.Millisecond - t1old.Millisecond) < 399)
        //            {
        //                sb.Append(teamstr);
        //                teamstr = "";
        //                sb.Append("F");
        //                e.Handled = true;
        //            }
        //            else
        //            {
        //                sb.Append("F");
        //                SendKeys.Send(sb.ToString());
        //                teamstr = sb.ToString();
        //                sb.Clear();
        //            }
        //            e.Handled = true;
        //            break;
        //        case Keys.Return:

        //            if (sb.Length == 8)
        //            {
        //                StringBuilder cardid = new StringBuilder();
        //                cardid.Append(sb[6]);
        //                cardid.Append(sb[7]);
        //                cardid.Append(sb[4]);
        //                cardid.Append(sb[5]);
        //                cardid.Append(sb[2]);
        //                cardid.Append(sb[3]);
        //                cardid.Append(sb[0]);
        //                cardid.Append(sb[1]);
        //                sb.Clear();
        //                e.Handled = true;
        //                CardReader cr = new CardReader();
        //                cr.PortDeviceType = PortDeviceType.Usb;
        //                this.Invoke(DisptachMessage, cr, cardid.ToString());

        //            }


        //            break;
        //        case Keys.RShiftKey:
        //            break;
        //        default:
        //            break;
        //    }
        //}

        private void timer2_Tick(object sender, EventArgs e)
        {
            //SendKeys.Send(sb.ToString());
            //sb.Clear();
        }

        public bool CheckRight(string AuthCode)
        {
            if (!localinfo.user.authority.HaveAuth(AuthCode))
            {
                this.ShowPage(Page.Head);
                this.pnl_head.ShowMsg("您没有操作权限！请联系管理员！", true);
                //this.pnl_head.ErrorInfo = "您没有操作权限！请联系管理员！";
                // this.pnl_head.ShowErrorMsg = true;
                return false;
            }
            return true;
        }

        public bool CheckRightWorkPoint(VehIC_BL.RouteNodeType type)
        {
            bool flag = localinfo.workpoint.type == type;
            if (!flag)
            {

                this.ShowPage(Page.Head);
                this.pnl_head.ShowMsg("请先选择正确的作业点！", true);
                //this.pnl_head.ErrorInfo = "请先选择正确的作业点！";
                //this.pnl_head.ShowErrorMsg = true;
            }
            return flag;
        }

        public bool CheckWorkPoint()
        {
            if (localinfo.workpoint != null)
            {
                if (localinfo.user.workpointlist.indexof(localinfo.workpoint.Code) == -1)
                {
                    // this.pnl_head.ErrorInfo = "您没有作业点[" + localinfo.workpoint.Name + "]的操作权限！";
                    // this.pnl_head.ShowErrorMsg = true;
                    this.ShowPage(Page.Head);
                    this.pnl_head.ShowMsg("您没有作业点[" + localinfo.workpoint.Name + "]的操作权限！", true);
                    return false;
                }
            }
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                DeviceManager.Instance.CloseAllDevice();
            }
            catch (Exception)
            {
            }
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = localinfo.ISLocked;
            try
            {
                if (localinfo.workpoint.type == VehIC_BL.RouteNodeType.scales)
                {
                    ScalesAsst.Dispose();
                }
            }
            catch
            {
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Zhc.Data.DbContext.Create<QC_MatAllCheckItem>(false);
            //string key = Zhc.Data.DbContext.GetSeq("LAB"+DateTime.Today.AddDays(1).ToString("yyyyMMdd"), 3);
            //MessageBox.Show(key);
            //DbEntityTable<QC_QualityRule> table = new DbEntityTable<QC_QualityRule>();
            //table.LoadData();
            //foreach (var item in table)
            //{
            //    if (item.RuleContents.Count == 0 && item.RuleContent != "")
            //    {
            //        item.RuleStr2Contents();
            //    }
            //}
            //table.Save();
            this.LoginCheck();
        }

        private Page GetUserMainPage()
        {
            if (localinfo == null) return Page.None;
            if (localinfo.workpoint == null) return Page.None;

            switch (localinfo.workpoint.type)
            {
                case VehIC_BL.RouteNodeType.door:
                    return Page.WP_Door;
                case VehIC_BL.RouteNodeType.sampling:
                    return Page.WP_Sampling;
                case VehIC_BL.RouteNodeType.scales:
                    return Page.WP_Scales;
                case VehIC_BL.RouteNodeType.goodssite:
                    return Page.WP_GoodsSiteEx;
                default:
                    return Page.None;
            }
        }

        private void HandleMessage(CardReader device, string str)
        {
            System.Media.SystemSounds.Beep.Play();

            Page mainPage = GetUserMainPage();
            if (mainPage == Page.WP_Door)
            {
                switch (device.UseType)
                {
                  
                    case CardReaderUseType.室内:
                        if (SimulationCom && (this.CurPage == Page.WP_Door))
                        {
                            
                        }
                        break;
                }
            }

            if (this.CurPage != mainPage)
            {
                if (mainPage != Page.WP_ZuPi && mainPage != Page.WP_Sampling && mainPage != Page.WP_ZhiYang)
                    SendCardMessageToPage(mainPage, device, str);
            }

            switch (device.UseType)
            {
                case CardReaderUseType.室内:
                    SendCardMessageToPage(this.CurPage, device, str);
                    break;
            }
        }

        private void SendCardMessageToPage(Page page, CardReader device, string cardId)
        {
            if (page == Page.Login)
            {
                if (this.login != null)
                    this.login.HandleCardMessage(device, cardId);
            }
            else if (pnl_Cache.ContainsKey(page))
            {
                ICardMessage cardHandleControl = pnl_Cache[page] as ICardMessage;
                if (cardHandleControl != null)
                {
                    cardHandleControl.HandleCardMessage(device, cardId);
                }
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnLogin = new System.Windows.Forms.ToolStripButton();
            this.tsBtnChgPsw = new System.Windows.Forms.ToolStripButton();
            this.tsBtnLock = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnBack = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDeviceManage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnWpReg = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCardReg = new System.Windows.Forms.ToolStripButton();
            this.tsBtn_WpSelect = new System.Windows.Forms.ToolStripSplitButton();
            this.btn_Jhy = new System.Windows.Forms.ToolStripSplitButton();
            this.化验数据菜单 = new System.Windows.Forms.ToolStripMenuItem();
            this.精煤化验ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.精粉化验ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.外矿化验ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.合金化验ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.火运化验ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.检验数据上传ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.荧光仪数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.化验审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.精粉化验审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.外矿化验审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.合金化验审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBtn_QualityJudge = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.特别指定菜单 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExamine = new System.Windows.Forms.ToolStripMenuItem();
            this.管理抽样ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBtnVerifSample = new System.Windows.Forms.ToolStripMenuItem();
            this.复检ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmBtnICReg = new System.Windows.Forms.ToolStripMenuItem();
            this.btnJyfl = new System.Windows.Forms.ToolStripMenuItem();
            this.btnJyxm = new System.Windows.Forms.ToolStripMenuItem();
            this.btnJybz = new System.Windows.Forms.ToolStripMenuItem();
            this.检验路径ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动判定依据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.回传取样信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取样机采集信息修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.管理查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.制样查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.化验查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.审核查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.采购查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取样查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取用查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmBtnCzyFk = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBtnDckFk = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBtnLskFk = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBtnLskBk = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBtnXccFk = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBtnXccBk = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnNoticeBillQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnInOutDoor = new System.Windows.Forms.ToolStripButton();
            this.tsBtnGetDeviceAuth = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnQuit = new System.Windows.Forms.ToolStripButton();
            this.tsBtnHelp = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsmSysConfig = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.mainPanel = new System.Windows.Forms.Panel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.火运化验审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(921, 27);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // skinEngine1
            // 
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 37);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 642);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1086, 32);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(150, 27);
            this.toolStripStatusLabel2.Text = "V1.1.1.15";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnLogin,
            this.tsBtnChgPsw,
            this.tsBtnLock,
            this.toolStripSeparator3,
            this.tsBtnBack,
            this.tsBtnDeviceManage,
            this.toolStripSeparator2,
            this.tsBtnWpReg,
            this.tsBtnCardReg,
            this.tsBtn_WpSelect,
            this.btn_Jhy,
            this.toolStripDropDownButton1,
            this.toolStripSplitButton1,
            this.toolStripSeparator4,
            this.tsBtnNoticeBillQuery,
            this.toolStripSeparator5,
            this.tsBtnInOutDoor,
            this.tsBtnGetDeviceAuth,
            this.toolStripSeparator6,
            this.tsBtnQuit,
            this.tsBtnHelp,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.tsmSysConfig});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1086, 29);
            this.toolStrip1.TabIndex = 15;
            // 
            // tsBtnLogin
            // 
            this.tsBtnLogin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnLogin.Image = global::Properties.Resources.tsBtnLogin;
            this.tsBtnLogin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnLogin.Name = "tsBtnLogin";
            this.tsBtnLogin.Size = new System.Drawing.Size(28, 26);
            this.tsBtnLogin.Text = "用户登录";
            this.tsBtnLogin.ToolTipText = "用户登录";
            this.tsBtnLogin.Click += new System.EventHandler(this.tsBtnLogin_Click);
            // 
            // tsBtnChgPsw
            // 
            this.tsBtnChgPsw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnChgPsw.Image = global::Properties.Resources.tsBtnChgPsw;
            this.tsBtnChgPsw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnChgPsw.Name = "tsBtnChgPsw";
            this.tsBtnChgPsw.Size = new System.Drawing.Size(28, 26);
            this.tsBtnChgPsw.Text = "修该密码";
            this.tsBtnChgPsw.ToolTipText = "修该密码";
            this.tsBtnChgPsw.Click += new System.EventHandler(this.tsBtnChgPsw_Click);
            // 
            // tsBtnLock
            // 
            this.tsBtnLock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnLock.Image = global::Properties.Resources.tsBtnLock;
            this.tsBtnLock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnLock.Name = "tsBtnLock";
            this.tsBtnLock.Size = new System.Drawing.Size(28, 26);
            this.tsBtnLock.Text = "锁定";
            this.tsBtnLock.ToolTipText = "锁定";
            this.tsBtnLock.Click += new System.EventHandler(this.tsBtnLock_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // tsBtnBack
            // 
            this.tsBtnBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnBack.Image = global::Properties.Resources.tsBtnBack;
            this.tsBtnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnBack.Name = "tsBtnBack";
            this.tsBtnBack.Size = new System.Drawing.Size(28, 26);
            this.tsBtnBack.Text = "返回";
            this.tsBtnBack.ToolTipText = "返回";
            this.tsBtnBack.Click += new System.EventHandler(this.tsBtnBack_Click);
            // 
            // tsBtnDeviceManage
            // 
            this.tsBtnDeviceManage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnDeviceManage.Image = global::Properties.Resources.tsBtnDeviceManage;
            this.tsBtnDeviceManage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDeviceManage.Name = "tsBtnDeviceManage";
            this.tsBtnDeviceManage.Size = new System.Drawing.Size(28, 26);
            this.tsBtnDeviceManage.Text = "设备管理";
            this.tsBtnDeviceManage.ToolTipText = "设备管理";
            this.tsBtnDeviceManage.Click += new System.EventHandler(this.tsBtnDeviceManage_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // tsBtnWpReg
            // 
            this.tsBtnWpReg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnWpReg.Image = global::Properties.Resources.tsBtnWpReg;
            this.tsBtnWpReg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnWpReg.Name = "tsBtnWpReg";
            this.tsBtnWpReg.Size = new System.Drawing.Size(28, 26);
            this.tsBtnWpReg.Text = "作业点注册";
            this.tsBtnWpReg.Click += new System.EventHandler(this.tsBtnWpReg_Click);
            // 
            // tsBtnCardReg
            // 
            this.tsBtnCardReg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnCardReg.Image = global::Properties.Resources.tsBtnCardReg;
            this.tsBtnCardReg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCardReg.Name = "tsBtnCardReg";
            this.tsBtnCardReg.Size = new System.Drawing.Size(28, 26);
            this.tsBtnCardReg.Text = "IC卡注册";
            this.tsBtnCardReg.ToolTipText = "IC卡注册";
            this.tsBtnCardReg.Click += new System.EventHandler(this.tsBtnCardReg_Click);
            // 
            // tsBtn_WpSelect
            // 
            this.tsBtn_WpSelect.Image = global::Properties.Resources.tsBtn_WpSelect;
            this.tsBtn_WpSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtn_WpSelect.Name = "tsBtn_WpSelect";
            this.tsBtn_WpSelect.Size = new System.Drawing.Size(108, 26);
            this.tsBtn_WpSelect.Text = "作业点选择";
            this.tsBtn_WpSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Jhy
            // 
            this.btn_Jhy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.化验数据菜单,
            this.检验数据上传ToolStripMenuItem,
            this.荧光仪数据ToolStripMenuItem,
            this.化验审核ToolStripMenuItem,
            this.精粉化验审核ToolStripMenuItem,
            this.外矿化验审核ToolStripMenuItem,
            this.合金化验审核ToolStripMenuItem,
            this.火运化验审核ToolStripMenuItem,
            this.tsmBtn_QualityJudge,
            this.toolStripSeparator7,
            this.特别指定菜单,
            this.btnExamine,
            this.管理抽样ToolStripMenuItem,
            this.tsmBtnVerifSample,
            this.复检ToolStripMenuItem,
            this.toolStripSeparator8,
            this.tsmBtnICReg,
            this.btnJyfl,
            this.btnJyxm,
            this.btnJybz,
            this.检验路径ToolStripMenuItem,
            this.自动判定依据ToolStripMenuItem,
            this.回传取样信息ToolStripMenuItem,
            this.取样机采集信息修改ToolStripMenuItem});
            this.btn_Jhy.Image = global::Properties.Resources.huayan;
            this.btn_Jhy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Jhy.Name = "btn_Jhy";
            this.btn_Jhy.Size = new System.Drawing.Size(84, 26);
            this.btn_Jhy.Text = "检化验";
            this.btn_Jhy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // 化验数据菜单
            // 
            this.化验数据菜单.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.精煤化验ToolStripMenuItem,
            this.精粉化验ToolStripMenuItem,
            this.外矿化验ToolStripMenuItem,
            this.合金化验ToolStripMenuItem,
            this.火运化验ToolStripMenuItem});
            this.化验数据菜单.Name = "化验数据菜单";
            this.化验数据菜单.Size = new System.Drawing.Size(184, 22);
            this.化验数据菜单.Text = "化验数据";
            // 
            // 精煤化验ToolStripMenuItem
            // 
            this.精煤化验ToolStripMenuItem.Name = "精煤化验ToolStripMenuItem";
            this.精煤化验ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.精煤化验ToolStripMenuItem.Text = "精煤化验";
            this.精煤化验ToolStripMenuItem.Click += new System.EventHandler(this.精煤化验ToolStripMenuItem_Click);
            // 
            // 精粉化验ToolStripMenuItem
            // 
            this.精粉化验ToolStripMenuItem.Name = "精粉化验ToolStripMenuItem";
            this.精粉化验ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.精粉化验ToolStripMenuItem.Text = "精粉化验";
            this.精粉化验ToolStripMenuItem.Click += new System.EventHandler(this.精粉化验ToolStripMenuItem_Click);
            // 
            // 外矿化验ToolStripMenuItem
            // 
            this.外矿化验ToolStripMenuItem.Name = "外矿化验ToolStripMenuItem";
            this.外矿化验ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.外矿化验ToolStripMenuItem.Text = "外矿化验";
            this.外矿化验ToolStripMenuItem.Click += new System.EventHandler(this.外矿化验ToolStripMenuItem_Click);
            // 
            // 合金化验ToolStripMenuItem
            // 
            this.合金化验ToolStripMenuItem.Name = "合金化验ToolStripMenuItem";
            this.合金化验ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.合金化验ToolStripMenuItem.Text = "合金化验";
            this.合金化验ToolStripMenuItem.Click += new System.EventHandler(this.合金化验ToolStripMenuItem_Click);
            // 
            // 火运化验ToolStripMenuItem
            // 
            this.火运化验ToolStripMenuItem.Name = "火运化验ToolStripMenuItem";
            this.火运化验ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.火运化验ToolStripMenuItem.Text = "火运化验";
            this.火运化验ToolStripMenuItem.Click += new System.EventHandler(this.火运化验ToolStripMenuItem_Click);
            // 
            // 检验数据上传ToolStripMenuItem
            // 
            this.检验数据上传ToolStripMenuItem.Name = "检验数据上传ToolStripMenuItem";
            this.检验数据上传ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.检验数据上传ToolStripMenuItem.Text = "检验数据上传";
            this.检验数据上传ToolStripMenuItem.Click += new System.EventHandler(this.检验数据上传ToolStripMenuItem_Click);
            // 
            // 荧光仪数据ToolStripMenuItem
            // 
            this.荧光仪数据ToolStripMenuItem.Name = "荧光仪数据ToolStripMenuItem";
            this.荧光仪数据ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.荧光仪数据ToolStripMenuItem.Text = "荧光仪数据上传";
            this.荧光仪数据ToolStripMenuItem.Click += new System.EventHandler(this.荧光仪数据ToolStripMenuItem_Click);
            // 
            // 化验审核ToolStripMenuItem
            // 
            this.化验审核ToolStripMenuItem.Name = "化验审核ToolStripMenuItem";
            this.化验审核ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.化验审核ToolStripMenuItem.Text = "精煤化验审核";
            this.化验审核ToolStripMenuItem.Click += new System.EventHandler(this.化验审核ToolStripMenuItem_Click);
            // 
            // 精粉化验审核ToolStripMenuItem
            // 
            this.精粉化验审核ToolStripMenuItem.Name = "精粉化验审核ToolStripMenuItem";
            this.精粉化验审核ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.精粉化验审核ToolStripMenuItem.Text = "精粉化验审核";
            this.精粉化验审核ToolStripMenuItem.Click += new System.EventHandler(this.精粉化验审核ToolStripMenuItem_Click);
            // 
            // 外矿化验审核ToolStripMenuItem
            // 
            this.外矿化验审核ToolStripMenuItem.Name = "外矿化验审核ToolStripMenuItem";
            this.外矿化验审核ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.外矿化验审核ToolStripMenuItem.Text = "外矿化验审核";
            this.外矿化验审核ToolStripMenuItem.Click += new System.EventHandler(this.外矿化验审核ToolStripMenuItem_Click);
            // 
            // 合金化验审核ToolStripMenuItem
            // 
            this.合金化验审核ToolStripMenuItem.Name = "合金化验审核ToolStripMenuItem";
            this.合金化验审核ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.合金化验审核ToolStripMenuItem.Text = "合金化验审核";
            this.合金化验审核ToolStripMenuItem.Click += new System.EventHandler(this.合金化验审核ToolStripMenuItem_Click);
            // 
            // tsmBtn_QualityJudge
            // 
            this.tsmBtn_QualityJudge.Name = "tsmBtn_QualityJudge";
            this.tsmBtn_QualityJudge.Size = new System.Drawing.Size(184, 22);
            this.tsmBtn_QualityJudge.Text = "质量判定";
            this.tsmBtn_QualityJudge.Click += new System.EventHandler(this.tsmBtn_QualityJudge_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(181, 6);
            // 
            // 特别指定菜单
            // 
            this.特别指定菜单.Name = "特别指定菜单";
            this.特别指定菜单.Size = new System.Drawing.Size(184, 22);
            this.特别指定菜单.Text = "特别指定";
            this.特别指定菜单.Click += new System.EventHandler(this.特别指定菜单_Click);
            // 
            // btnExamine
            // 
            this.btnExamine.Name = "btnExamine";
            this.btnExamine.Size = new System.Drawing.Size(184, 22);
            this.btnExamine.Text = "抽样";
            this.btnExamine.Click += new System.EventHandler(this.btnExamine_Click);
            // 
            // 管理抽样ToolStripMenuItem
            // 
            this.管理抽样ToolStripMenuItem.Name = "管理抽样ToolStripMenuItem";
            this.管理抽样ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.管理抽样ToolStripMenuItem.Text = "管理抽样";
            this.管理抽样ToolStripMenuItem.Click += new System.EventHandler(this.管理抽样ToolStripMenuItem_Click);
            // 
            // tsmBtnVerifSample
            // 
            this.tsmBtnVerifSample.Name = "tsmBtnVerifSample";
            this.tsmBtnVerifSample.Size = new System.Drawing.Size(184, 22);
            this.tsmBtnVerifSample.Text = "掺假样";
            this.tsmBtnVerifSample.Click += new System.EventHandler(this.tsmBtnVerifSample_Click);
            // 
            // 复检ToolStripMenuItem
            // 
            this.复检ToolStripMenuItem.Name = "复检ToolStripMenuItem";
            this.复检ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.复检ToolStripMenuItem.Text = "复检";
            this.复检ToolStripMenuItem.Click += new System.EventHandler(this.复检ToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(181, 6);
            // 
            // tsmBtnICReg
            // 
            this.tsmBtnICReg.Name = "tsmBtnICReg";
            this.tsmBtnICReg.Size = new System.Drawing.Size(184, 22);
            this.tsmBtnICReg.Text = "磁扣注册";
            this.tsmBtnICReg.Click += new System.EventHandler(this.tsmBtnICReg_Click);
            // 
            // btnJyfl
            // 
            this.btnJyfl.Name = "btnJyfl";
            this.btnJyfl.Size = new System.Drawing.Size(184, 22);
            this.btnJyfl.Text = "样品分类";
            this.btnJyfl.Click += new System.EventHandler(this.btnJyfl_Click);
            // 
            // btnJyxm
            // 
            this.btnJyxm.Name = "btnJyxm";
            this.btnJyxm.Size = new System.Drawing.Size(184, 22);
            this.btnJyxm.Text = "检验项目";
            this.btnJyxm.Click += new System.EventHandler(this.btnJyxm_Click);
            // 
            // btnJybz
            // 
            this.btnJybz.Name = "btnJybz";
            this.btnJybz.Size = new System.Drawing.Size(184, 22);
            this.btnJybz.Text = "检验规则";
            this.btnJybz.Click += new System.EventHandler(this.btnJybz_Click);
            // 
            // 检验路径ToolStripMenuItem
            // 
            this.检验路径ToolStripMenuItem.Name = "检验路径ToolStripMenuItem";
            this.检验路径ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.检验路径ToolStripMenuItem.Text = "检验路径";
            this.检验路径ToolStripMenuItem.Click += new System.EventHandler(this.检验路径菜单_Click);
            // 
            // 自动判定依据ToolStripMenuItem
            // 
            this.自动判定依据ToolStripMenuItem.Name = "自动判定依据ToolStripMenuItem";
            this.自动判定依据ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.自动判定依据ToolStripMenuItem.Text = "自动判定依据";
            this.自动判定依据ToolStripMenuItem.Click += new System.EventHandler(this.自动判定依据ToolStripMenuItem_Click);
            // 
            // 回传取样信息ToolStripMenuItem
            // 
            this.回传取样信息ToolStripMenuItem.Name = "回传取样信息ToolStripMenuItem";
            this.回传取样信息ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.回传取样信息ToolStripMenuItem.Text = "回传取样信息";
            this.回传取样信息ToolStripMenuItem.Click += new System.EventHandler(this.回传取样信息ToolStripMenuItem_Click);
            // 
            // 取样机采集信息修改ToolStripMenuItem
            // 
            this.取样机采集信息修改ToolStripMenuItem.Name = "取样机采集信息修改ToolStripMenuItem";
            this.取样机采集信息修改ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.取样机采集信息修改ToolStripMenuItem.Text = "取样机采集信息修改";
            this.取样机采集信息修改ToolStripMenuItem.Click += new System.EventHandler(this.取样机采集信息修改ToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.管理查询ToolStripMenuItem,
            this.制样查询ToolStripMenuItem,
            this.化验查询ToolStripMenuItem,
            this.审核查询ToolStripMenuItem,
            this.采购查询ToolStripMenuItem,
            this.取样查询ToolStripMenuItem,
            this.修改查询ToolStripMenuItem,
            this.取用查询ToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(105, 26);
            this.toolStripDropDownButton1.Text = "检化验查询";
            // 
            // 管理查询ToolStripMenuItem
            // 
            this.管理查询ToolStripMenuItem.Name = "管理查询ToolStripMenuItem";
            this.管理查询ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.管理查询ToolStripMenuItem.Text = "管理查询";
            this.管理查询ToolStripMenuItem.Click += new System.EventHandler(this.管理查询ToolStripMenuItem_Click);
            // 
            // 制样查询ToolStripMenuItem
            // 
            this.制样查询ToolStripMenuItem.Name = "制样查询ToolStripMenuItem";
            this.制样查询ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.制样查询ToolStripMenuItem.Text = "制样查询";
            this.制样查询ToolStripMenuItem.Click += new System.EventHandler(this.取样查询ToolStripMenuItem_Click);
            // 
            // 化验查询ToolStripMenuItem
            // 
            this.化验查询ToolStripMenuItem.Name = "化验查询ToolStripMenuItem";
            this.化验查询ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.化验查询ToolStripMenuItem.Text = "化验查询";
            this.化验查询ToolStripMenuItem.Click += new System.EventHandler(this.化验查询ToolStripMenuItem_Click);
            // 
            // 审核查询ToolStripMenuItem
            // 
            this.审核查询ToolStripMenuItem.Name = "审核查询ToolStripMenuItem";
            this.审核查询ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.审核查询ToolStripMenuItem.Text = "审核查询";
            this.审核查询ToolStripMenuItem.Click += new System.EventHandler(this.审核查询ToolStripMenuItem_Click);
            // 
            // 采购查询ToolStripMenuItem
            // 
            this.采购查询ToolStripMenuItem.Name = "采购查询ToolStripMenuItem";
            this.采购查询ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.采购查询ToolStripMenuItem.Text = "采购查询";
            this.采购查询ToolStripMenuItem.Click += new System.EventHandler(this.采购查询ToolStripMenuItem_Click);
            // 
            // 取样查询ToolStripMenuItem
            // 
            this.取样查询ToolStripMenuItem.Name = "取样查询ToolStripMenuItem";
            this.取样查询ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.取样查询ToolStripMenuItem.Text = "取样查询";
            this.取样查询ToolStripMenuItem.Click += new System.EventHandler(this.取样查询ToolStripMenuItem_Click);
            // 
            // 修改查询ToolStripMenuItem
            // 
            this.修改查询ToolStripMenuItem.Name = "修改查询ToolStripMenuItem";
            this.修改查询ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.修改查询ToolStripMenuItem.Text = "修改查询";
            this.修改查询ToolStripMenuItem.Click += new System.EventHandler(this.修改查询ToolStripMenuItem_Click);
            // 
            // 取用查询ToolStripMenuItem
            // 
            this.取用查询ToolStripMenuItem.Name = "取用查询ToolStripMenuItem";
            this.取用查询ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.取用查询ToolStripMenuItem.Text = "取用查询";
            this.取用查询ToolStripMenuItem.Click += new System.EventHandler(this.取用查询ToolStripMenuItem_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmBtnCzyFk,
            this.tsmBtnDckFk,
            this.tsmBtnLskFk,
            this.tsmBtnLskBk,
            this.tsmBtnXccFk,
            this.tsmBtnXccBk});
            this.toolStripSplitButton1.Image = global::Properties.Resources.faka;
            this.toolStripSplitButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(96, 26);
            this.toolStripSplitButton1.Text = "发卡补卡";
            this.toolStripSplitButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripSplitButton1.ToolTipText = "发卡补卡业务";
            // 
            // tsmBtnCzyFk
            // 
            this.tsmBtnCzyFk.Name = "tsmBtnCzyFk";
            this.tsmBtnCzyFk.Size = new System.Drawing.Size(136, 22);
            this.tsmBtnCzyFk.Text = "操作员发卡";
            this.tsmBtnCzyFk.Click += new System.EventHandler(this.tsmBtnCzyFk_Click);
            // 
            // tsmBtnDckFk
            // 
            this.tsmBtnDckFk.Name = "tsmBtnDckFk";
            this.tsmBtnDckFk.Size = new System.Drawing.Size(136, 22);
            this.tsmBtnDckFk.Text = "多次卡发卡";
            this.tsmBtnDckFk.Click += new System.EventHandler(this.tsmBtnDckFk_Click);
            // 
            // tsmBtnLskFk
            // 
            this.tsmBtnLskFk.Name = "tsmBtnLskFk";
            this.tsmBtnLskFk.Size = new System.Drawing.Size(136, 22);
            this.tsmBtnLskFk.Text = "临时卡发卡";
            this.tsmBtnLskFk.Click += new System.EventHandler(this.tsmBtnLskFk_Click);
            // 
            // tsmBtnLskBk
            // 
            this.tsmBtnLskBk.Name = "tsmBtnLskBk";
            this.tsmBtnLskBk.Size = new System.Drawing.Size(136, 22);
            this.tsmBtnLskBk.Text = "临时卡补卡";
            this.tsmBtnLskBk.Click += new System.EventHandler(this.tsmBtnLskBk_Click);
            // 
            // tsmBtnXccFk
            // 
            this.tsmBtnXccFk.Name = "tsmBtnXccFk";
            this.tsmBtnXccFk.Size = new System.Drawing.Size(136, 22);
            this.tsmBtnXccFk.Text = "线材车发卡";
            this.tsmBtnXccFk.Click += new System.EventHandler(this.tsmBtnXccFk_Click);
            // 
            // tsmBtnXccBk
            // 
            this.tsmBtnXccBk.Name = "tsmBtnXccBk";
            this.tsmBtnXccBk.Size = new System.Drawing.Size(136, 22);
            this.tsmBtnXccBk.Text = "线材车补卡";
            this.tsmBtnXccBk.Click += new System.EventHandler(this.tsmBtnXccBk_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 29);
            // 
            // tsBtnNoticeBillQuery
            // 
            this.tsBtnNoticeBillQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnNoticeBillQuery.Image = global::Properties.Resources.tsBtnNoticeBillQuery;
            this.tsBtnNoticeBillQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNoticeBillQuery.Name = "tsBtnNoticeBillQuery";
            this.tsBtnNoticeBillQuery.Size = new System.Drawing.Size(28, 26);
            this.tsBtnNoticeBillQuery.Text = "作业单查询";
            this.tsBtnNoticeBillQuery.ToolTipText = "作业单查询";
            this.tsBtnNoticeBillQuery.Click += new System.EventHandler(this.tsBtnNoticeBillQuery_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 29);
            // 
            // tsBtnInOutDoor
            // 
            this.tsBtnInOutDoor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnInOutDoor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnInOutDoor.Name = "tsBtnInOutDoor";
            this.tsBtnInOutDoor.Size = new System.Drawing.Size(36, 26);
            this.tsBtnInOutDoor.Text = "进门";
            this.tsBtnInOutDoor.ToolTipText = "出入门类别";
            this.tsBtnInOutDoor.Click += new System.EventHandler(this.tsBtnInOutDoor_Click);
            // 
            // tsBtnGetDeviceAuth
            // 
            this.tsBtnGetDeviceAuth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnGetDeviceAuth.Image = global::Properties.Resources.tsBtnGetDeviceAuth;
            this.tsBtnGetDeviceAuth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnGetDeviceAuth.Name = "tsBtnGetDeviceAuth";
            this.tsBtnGetDeviceAuth.Size = new System.Drawing.Size(28, 26);
            this.tsBtnGetDeviceAuth.Text = "获取设备启用授权";
            this.tsBtnGetDeviceAuth.ToolTipText = "获取设备启用授权";
            this.tsBtnGetDeviceAuth.Click += new System.EventHandler(this.tsBtnGetDeviceAuth_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 29);
            // 
            // tsBtnQuit
            // 
            this.tsBtnQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnQuit.Image = global::Properties.Resources.tsBtnQuit;
            this.tsBtnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnQuit.Name = "tsBtnQuit";
            this.tsBtnQuit.Size = new System.Drawing.Size(28, 26);
            this.tsBtnQuit.Text = "退出系统";
            this.tsBtnQuit.ToolTipText = "退出系统";
            this.tsBtnQuit.Click += new System.EventHandler(this.tsBtnQuit_Click);
            // 
            // tsBtnHelp
            // 
            this.tsBtnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnHelp.Image = global::Properties.Resources.tsBtnHelp;
            this.tsBtnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnHelp.Name = "tsBtnHelp";
            this.tsBtnHelp.Size = new System.Drawing.Size(28, 26);
            this.tsBtnHelp.Text = "帮助";
            this.tsBtnHelp.ToolTipText = "帮助";
            this.tsBtnHelp.Click += new System.EventHandler(this.tsBtnHelp_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Navy;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 26);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripLabel2.ForeColor = System.Drawing.Color.Navy;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(0, 26);
            // 
            // tsmSysConfig
            // 
            this.tsmSysConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmSysConfig.Image = ((System.Drawing.Image)(resources.GetObject("tsmSysConfig.Image")));
            this.tsmSysConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmSysConfig.Name = "tsmSysConfig";
            this.tsmSysConfig.Size = new System.Drawing.Size(60, 26);
            this.tsmSysConfig.Text = "系统设置";
            this.tsmSysConfig.Visible = false;
            this.tsmSysConfig.Click += new System.EventHandler(this.tsmSysConfig_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // mainPanel
            // 
            this.mainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 29);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1086, 613);
            this.mainPanel.TabIndex = 21;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // timer2
            // 
            this.timer2.Interval = 3000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // 火运化验审核ToolStripMenuItem
            // 
            this.火运化验审核ToolStripMenuItem.Name = "火运化验审核ToolStripMenuItem";
            this.火运化验审核ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.火运化验审核ToolStripMenuItem.Text = "火运化验审核";
            this.火运化验审核ToolStripMenuItem.Click += new System.EventHandler(this.火运化验审核ToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 674);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "邢钢检化验系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmMain_KeyPress);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        public static bool KZ(int inOut)
        {
            if (inOut == 1)
            {
                return DeviceManager.Instance.InDoor();
            }
            else
            {
                return DeviceManager.Instance.OutDoor();
            }
        }

        /// <summary>
        /// 启动检查
        /// </summary>
        private void LoginCheck()
        {
            base.Hide();

            VehIC_WF.Device.HardwareInfo info = new VehIC_WF.Device.HardwareInfo();

            if (info.GetHostIPAddress() == string.Empty)
            {
                MessageBox.Show("本地网络连接不通，将退出登录！");
                base.Close();
                return;
            }

            //if (string.IsNullOrEmpty(FrmSetServerConnection.Test(Regedit.Read("Server", "WebService"))))
            //{
            //    SysServerConfig();
            //}

            localinfo.ServerUrl = DbContext.WebService;// Regedit.Read("Server", "WebService");



            this.login = new FrmLogin();
            this.CurPage = Page.Login;
            LoadDevices();
            if (login.ShowDialog() != DialogResult.OK)
            {
                this.CurPage = Page.None;
                login.Dispose();
                this.login = null;
                base.Close();
            }
            else
            {
                this.CurPage = Page.None;
                login.Dispose();
                this.login = null;
                // localinfo.workpointlist = GetRegedWorkPoint(info);
                localinfo.workpointlist = localinfo.user.workpointlist;
                for (int i = 0; i < localinfo.user.workpointlist.Count; i++)
                {
                    WorkPointInfo wpInfo = localinfo.user.workpointlist[i];
                    string code = wpInfo.Code;

                    wpInfo.SH = true;
                    wpInfo.Enable = true;
                    //wpInfo.Enable = false;

                    //for (int j = 0; j < localinfo.workpointlist.Count; j++)
                    //{
                    //    WorkPointInfo wpInfo2=localinfo.workpointlist[j];
                    //    if (wpInfo2.Code == code)
                    //    {
                    //        wpInfo.Enable = wpInfo2.Enable;
                    //        wpInfo.SH = wpInfo2.SH;
                    //        break;
                    //    }
                    //}

                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Name = "TSMI_" + code;
                    item.Size = new Size(0x98, 0x16);
                    item.Text = wpInfo.Name;
                    item.Tag = code;
                    item.Enabled = wpInfo.Available();
                    this.tsBtn_WpSelect.DropDownItems.Add(item);
                    item.Click += new EventHandler(this.WPSelect_Click);
                }

                localinfo.workpoint = localinfo.workpointlist.GetFirstAvailableWP();

                this.SettingUI();
                base.Show();
                if (localinfo.workpoint != null)
                {
                    if (localinfo.workpoint.Name != "制卡中心")
                    {
                        if (localinfo.workpoint.type == VehIC_BL.RouteNodeType.door)
                        {
                            if (!(DeviceManager.Instance.HaveAvailableCardReader() && DeviceManager.Instance.HaveAvailableInRoadBrake() && DeviceManager.Instance.HaveAvailableOutRoadBrake()))
                            {
                                MessageBox.Show("存在不可用的设备，请进行参数设置或检查设备！");
                            }
                        }
                        else if (!DeviceManager.Instance.HaveAvailableCardReader())
                        {
                            MessageBox.Show("没有可用的设备，请进行参数设置！");
                        }
                    }
                }
                else
                {
                    ShowPage(Page.Head);
                }
            }
        }

        private WorkPointList GetRegedWorkPoint(VehIC_WF.Device.HardwareInfo info)
        {
            string[] data = null;
            try
            {
                VehIC_WF.CommonService.CommonService service = new VehIC_WF.CommonService.CommonService();
                service.Url = "http://" + localinfo.ServerUrl + "/VehIC_WS/CommonService.asmx";
                string ip = info.GetHostIPAddress();
                string regCode = info.GetMacAddress();
                data = service.WorkPointCheck(ip, regCode);
                //data = new string[] { "1\tTrue\t001\tTest\t00\tTest" };

            }
            catch (Exception)
            {
                MessageBox.Show("网络连接错误，请重新登陆设置！");
                base.Close();
            }
            if (data == null)
            {
                MessageBox.Show("网络连接错误或数据处理异常，请重新登陆设置！");
                base.Close();
            }
            return new WorkPointList(data);
        }

        private void WpReg()
        {
            FrmWorkPointRegistry registry = new FrmWorkPointRegistry();
            if (DialogResult.OK == registry.ShowDialog())
            {
                MessageBox.Show("注册完毕，等待审核！");
            }
            registry.Dispose();
            base.Close();
        }

        private void SysServerConfig()
        {
            FrmSetServerConnection connection = new FrmSetServerConnection();
            if (DialogResult.OK == connection.ShowDialog())
            {
                connection.Dispose();
                MessageBox.Show("设置完成，系统即将关闭，请重新启动。");
                base.Close();
            }
        }

        public void LoadDevices()
        {
            // DisptachMessage = new CardReaderDelegate(this.HandleMessage);
            DeviceManager.Instance.Init();
            DeviceManager.Instance.OpenAllDevice();
            this.timer1.Enabled = true;
        }

        public void SettingUI()
        {
            this.skinEngine1.SkinFile = "MP10.ssk";
            ChgWorkPoint();
        }

        public void ShowMsg(string msg)
        {
            string str = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
            this.toolStripStatusLabel1.Text = str + "\t" + msg;
        }

        public void ShowMsgEx(string msg)
        {
            this.toolStripStatusLabel2.Text = msg;
        }

        public void ShowPage(Page page)
        {
            if (page != Page.Locked)
            {
                this.LastPage = page;
            }

            if (pnl_Types.ContainsKey(page))
            {
                if (!pnl_Cache.ContainsKey(page))
                {
                    pnl_loading.BringToFront();
                    // pnl_loading.Play();
                    this.mainPanel.Refresh();
                    UserControl pnlControl = Activator.CreateInstance(pnl_Types[page]) as UserControl;
                    pnlControl.Dock = DockStyle.Fill;
                    this.mainPanel.Controls.Add(pnlControl);
                    pnl_Cache.Add(page, pnlControl);
                    //  pnl_loading.Stop();   
                    // var doc=  tabbedView1.AddDocument(pnlControl);
                    // doc.ControlName = page.ToString();

                }
                pnl_Cache[page].BringToFront();
                this.CurPage = page;
            }
            mainPanel.BringToFront();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var cardReader in DeviceManager.Instance.CardReaders)
            {
                try
                {
                    string data = cardReader.Excute();
                    if (data != string.Empty && data != "771BB242")
                    {
                        HandleMessage(cardReader, data);
                    }
                }
                catch (UnauthorizedAccessException ex2)
                {
                    //端口被其它程序占用
                    //对端口的访问被拒绝。
                    cardReader.CanUse = false;
                }
                catch (InvalidOperationException ex3)
                {
                    //open() SerialPort 的当前实例上的指定端口已经打开。
                    //read() write 指定的端口未打开。
                    //cardReader.CanUse = false;
                    MessageBox.Show("端口被占用");
                }
                catch (TimeoutException ex4)
                {
                    //该操作未在超时时间到期之前完成。
                    cardReader.CanUse = false;
                }
                catch (IOException ioex)
                {
                    Console.WriteLine(ioex.Message);
                    cardReader.CanUse = false;
                }



            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnLogin_Click(object sender, EventArgs e)
        {
            if (localinfo.ISLocked)
            {
                login = new FrmLogin();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    localinfo.ISLocked = false;
                    this.ShowPage(this.LastPage);
                    login.Dispose();
                }
                else
                {
                    login.Dispose();
                }
            }
        }


        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnChgPsw_Click(object sender, EventArgs e)
        {
            if (!localinfo.ISLocked)
            {
                new FrmChangePassWord().ShowDialog();
            }
        }

        /// <summary>
        /// 锁定(退出登录)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnLock_Click(object sender, EventArgs e)
        {
            localinfo.ISLocked = true;
            this.ShowPage(Page.Locked);
        }

        /// <summary>
        /// 返回（主页）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnBack_Click(object sender, EventArgs e)
        {
            if (!localinfo.ISLocked && this.CheckWorkPoint())
            {
                if (localinfo.workpoint != null)
                {
                    switch (localinfo.workpoint.type)
                    {
                        case VehIC_BL.RouteNodeType.door:
                            if (this.CheckRightWorkPoint(VehIC_BL.RouteNodeType.door))
                            {
                                if (this.CheckWorkPoint())
                                {
                                    this.ShowPage(Page.WP_Door);
                                }
                                break;
                            }
                            break;

                        case VehIC_BL.RouteNodeType.sampling:
                            if (this.CheckRightWorkPoint(VehIC_BL.RouteNodeType.sampling) && this.CheckWorkPoint())
                            {
                                this.ShowPage(Page.WP_Sampling);
                            }
                            break;

                       

                        case VehIC_BL.RouteNodeType.goodssite:
                            if (this.CheckRightWorkPoint(VehIC_BL.RouteNodeType.goodssite) && this.CheckWorkPoint())
                            {
                                this.ShowPage(Page.WP_GoodsSiteEx);
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 设备管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnDeviceManage_Click(object sender, EventArgs e)
        {
            if (Debug || ((!localinfo.ISLocked && this.CheckWorkPoint()) && this.CheckRight("W_Door_Device")))
            {
                this.ShowPage(Page.DeviceManage);
            }
        }

        /// <summary>
        /// 作业点注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnWpReg_Click(object sender, EventArgs e)
        {
            if (!localinfo.ISLocked)
            {
                FrmWorkPointRegistry registry = new FrmWorkPointRegistry(true);
                registry.ShowDialog();
                registry.Dispose();
            }
        }
        /// <summary>
        /// IC卡注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnCardReg_Click(object sender, EventArgs e)
        {
            if (Debug || (!localinfo.ISLocked && this.CheckRight("W_Door_RegCard")))
            {
                this.ShowPage(Page.ICCard_Registry);
            }
        }

        /// <summary>
        /// 操作员发卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmBtnCzyFk_Click(object sender, EventArgs e)
        {
            if (Debug || ((!localinfo.ISLocked && this.CheckRightWorkPoint(VehIC_BL.RouteNodeType.door)) && (this.CheckWorkPoint() && this.CheckRight("W_Door_OperCard"))))
            {
                this.ShowPage(Page.ICCard_Oper);
            }
        }

        /// <summary>
        /// 多次卡发卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmBtnDckFk_Click(object sender, EventArgs e)
        {
            if (Debug || ((!localinfo.ISLocked && this.CheckRightWorkPoint(VehIC_BL.RouteNodeType.door)) && (this.CheckWorkPoint() && this.CheckRight("W_Door_VehCard"))))
            {
                this.ShowPage(Page.ICCard_Multi);
            }
        }

        /// <summary>
        /// 临时卡发卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmBtnLskFk_Click(object sender, EventArgs e)
        {
            if (Debug || ((!localinfo.ISLocked && this.CheckRightWorkPoint(VehIC_BL.RouteNodeType.door)) && (this.CheckWorkPoint() && this.CheckRight("W_Door_VehCard"))))
            {
                this.ShowPage(Page.ICCard_MatVeh);
            }
        }

        /// <summary>
        /// 临时卡补卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmBtnLskBk_Click(object sender, EventArgs e)
        {
            if (Debug || ((!localinfo.ISLocked && this.CheckRightWorkPoint(VehIC_BL.RouteNodeType.door)) && (this.CheckWorkPoint() && this.CheckRight("W_Door_VehCard"))))
            {
                this.ShowPage(Page.ICCard_MatVehEx);
            }
        }

        /// <summary>
        /// 线材车发卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmBtnXccFk_Click(object sender, EventArgs e)
        {
            if (Debug || ((!localinfo.ISLocked && this.CheckRightWorkPoint(VehIC_BL.RouteNodeType.door)) && (this.CheckWorkPoint() && this.CheckRight("W_Door_RF"))))
            {
                this.ShowPage(Page.RFBarcode);
            }
        }

        /// <summary>
        /// 线材车补卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmBtnXccBk_Click(object sender, EventArgs e)
        {
            if (Debug || ((!localinfo.ISLocked && this.CheckRightWorkPoint(VehIC_BL.RouteNodeType.door)) && (this.CheckWorkPoint() && this.CheckRight("W_Door_RF"))))
            {
                this.ShowPage(Page.RFBarcodeEx);
            }
        }

        /// <summary>
        /// 作业单查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnNoticeBillQuery_Click(object sender, EventArgs e)
        {
            new FrmTaskSearch(this).ShowDialog();
        }

        /// <summary>
        /// 进出门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnInOutDoor_Click(object sender, EventArgs e)
        {
            if (this.tsBtnInOutDoor.Text == "进门")
            {
                this.tsBtnInOutDoor.Text = "出门";
            }
            else
            {
                this.tsBtnInOutDoor.Text = "进门";
            }
        }

        /// <summary>
        /// 获取设备启用授权
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnGetDeviceAuth_Click(object sender, EventArgs e)
        {
            try
            {
                if (localinfo.workpoint != null)
                {
                    if (localinfo.workpoint.type == VehIC_BL.RouteNodeType.door)
                    {
                        VehIC_WF.DoorService.DoorService service = new VehIC_WF.DoorService.DoorService();
                        if (!Debug)
                        {
                            service.Url = "http://" + localinfo.ServerUrl + "/VehIC_WS/DoorService.asmx";
                        }
                        SimulationCom = service.CheckAuthCode(localinfo.workpoint.Code);
                        if (!SimulationCom)
                        {
                            MessageBox.Show("没有授权！");
                        }
                        else
                        {
                            MessageBox.Show("授权成功！");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("没有作业点！");
                }
            }
            catch (Exception exception)
            {
                SimulationCom = false;
                MessageBox.Show(exception.ToString());
            }
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnQuit_Click(object sender, EventArgs e)
        {
            if (!localinfo.ISLocked)
            {
                base.Close();
            }
        }

        /// <summary>
        /// 帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnHelp_Click(object sender, EventArgs e)
        {
            try
            {
                VehIC_WF.CommonService.CommonService service = new VehIC_WF.CommonService.CommonService();
                if (!Debug)
                {
                    service.Url = "http://" + localinfo.ServerUrl + "/VehIC_WS/CommonService.asmx";
                }
                Process process = new Process();
                process.StartInfo.FileName = service.GetSystemPara("HelpFileAddr");
                process.Start();
            }
            catch
            {
            }
        }

        /// <summary>
        /// 作业点选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WPSelect_Click(object sender, EventArgs e)
        {
            if (!localinfo.ISLocked)
            {
                string code = ((ToolStripMenuItem)sender).Tag.ToString();
                localinfo.workpoint = localinfo.workpointlist[localinfo.workpointlist.indexof(code)];
                ChgWorkPoint();
            }
        }

        /// <summary>
        /// 作业点选择
        /// </summary>
        private void ChgWorkPoint()
        {
            this.toolStripLabel1.Text = localinfo.user.Name;
            if (localinfo.workpoint != null)
            {
                this.toolStripLabel2.Text = localinfo.workpoint.TypeDesc + "-" + localinfo.workpoint.Name;

                if (this.CheckWorkPoint())
                {
                    switch (localinfo.workpoint.type)
                    {
                        case VehIC_BL.RouteNodeType.door: //门岗
                            this.ShowPage(Page.WP_Door);
                            break;

                        case VehIC_BL.RouteNodeType.sampling:
                           
                            if (localinfo.workpoint.Code == "JFQY")
                            {
                               
                                this.ShowPage(Page.WP_JFSampling);
                            }
                                //火运取样
                            else if (localinfo.workpoint.Code == "0097")
                            {
                                this.ShowPage(Page.WP_HYSampling);
                            }
                            else
                            {
                                this.ShowPage(Page.WP_Sampling);
                            }
                               
                            break;

                        case VehIC_BL.RouteNodeType.scales:
                            this.ShowPage(Page.WP_Scales);
                            break;

                        case VehIC_BL.RouteNodeType.goodssite://货场
                            this.ShowPage(Page.WP_GoodsSiteEx);
                            break;
                        default:
                            switch (localinfo.workpoint.TypeCode)
                            {
                                case "21": //组批
                                    if (localinfo.workpoint.Code == "0067")
                                        this.ShowPage(Page.WP_ZuPi);
                                    else if (localinfo.workpoint.Code == "0090")
                                        this.ShowPage(Page.WP_WKzupi);
                                    else if (localinfo.workpoint.Code == "0073")
                                        this.ShowPage(Page.WP_JFZuPi);
                                    else if (localinfo.workpoint.Code == "0083")
                                        this.ShowPage(Page.WP_HJZuPi);
                                    else if (localinfo.workpoint.Code == "0091")
                                        this.ShowPage(Page.WP_SZZuPi);
                                    else if (localinfo.workpoint.Code == "0092")
                                        this.ShowPage(Page.WP_JTZuPi);
                                    else if (localinfo.workpoint.Code == "0087")
                                        this.ShowPage(Page.WP_RJZuPi);
                                    break;
                                case "22": //制样
                                    if (localinfo.workpoint.Code == "0068")
                                    this.ShowPage(Page.WP_ZhiYang);
                                    else if (localinfo.workpoint.Code == "0074")
                                        this.ShowPage(Page.WP_JFZhiYang);
                                    else if (localinfo.workpoint.Code == "0080")
                                        this.ShowPage(Page.WP_WKZhiYang);
                                    else if (localinfo.workpoint.Code == "0084")
                                        this.ShowPage(Page.WP_HJZhiYang);
                                    else if (localinfo.workpoint.Code == "0093")
                                        this.ShowPage(Page.WP_SZZhiYang);
                                    else if (localinfo.workpoint.Code == "0094")
                                        this.ShowPage(Page.WP_JTZhiYang);
                                    else if (localinfo.workpoint.Code == "0088")
                                        this.ShowPage(Page.WP_RJZhiYang);
                                    else if (localinfo.workpoint.Code == "0098")
                                        this.ShowPage(Page.WP_HYZYSampling);
                                    break;
                                case "23": //化验
                                    this.ShowPage(Page.WP_WKHuaYan);
                                    break;
                                case "24": //化验审核
                                    if (localinfo.workpoint.Code == "0078")
                                        this.ShowPage(Page.WP_HuaYanShenHe);
                                    else if (localinfo.workpoint.Code == "0077")
                                        this.ShowPage(Page.WP_JFHuaYanShenHe);
                                    else if (localinfo.workpoint.Code == "0081")
                                        this.ShowPage(Page.WP_WKHuaYanShenHe);
                                    break;
                                case "25": //判定
                                    if (localinfo.workpoint.Code == "0076")
                                    this.ShowPage(Page.SP_QualityJudge);
                                    else if (localinfo.workpoint.Code == "0075")
                                        this.ShowPage(Page.SP_JFQualityJudge);
                                    else if (localinfo.workpoint.Code == "0082")
                                        this.ShowPage(Page.SP_WKQualityJudge);
                                    else if (localinfo.workpoint.Code == "0086")
                                        this.ShowPage(Page.SP_HJQualityJudge);
                                    else if (localinfo.workpoint.Code == "0089")
                                        this.ShowPage(Page.SP_RJQualityJudge);
                                    else if (localinfo.workpoint.Code == "0095")
                                        this.ShowPage(Page.SP_SZQualityJudge);
                                    else if (localinfo.workpoint.Code == "0096")
                                        this.ShowPage(Page.SP_JTQualityJudge);
                                    else if (localinfo.workpoint.Code == "0099")
                                        this.ShowPage(Page.SP_HYQualityJudge);
                                    break;
                                default:
                                    this.ShowPage(Page.Head);
                                    break;
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 样品分类
        /// </summary>
        private void btnJyfl_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_CheckGroup"))
            {
                this.ShowPage(Page.SP_CheckGroup);
            }
        }

        /// <summary>
        /// 检验项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJyxm_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_CheckItem"))
            {
                this.ShowPage(Page.SP_CheckItem);
            }
        }

        /// <summary>
        /// 检验标准
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJybz_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_MatStd"))
            {
                this.ShowPage(Page.SP_MatStandard);
            }
        }

        /// <summary>
        /// 磁扣注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmBtnICReg_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_RegCard"))
            {
                this.ShowPage(Page.SP_ICReg);
            }
        }
        /// <summary>
        /// 抽样
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExamine_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_ExamineSample"))
            {
                this.ShowPage(Page.SP_ExamineSample);
            }
        }

        /// <summary>
        /// 质量判定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmBtn_QualityJudge_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_Judge"))
            {
                this.ShowPage(Page.SP_QualityJudge);
            }
        }

        private StringBuilder mnCardId = new StringBuilder();

        private void FrmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (toolStripButton1.Text == "停止模拟磁卡")
            //{
            //    if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= '0' && e.KeyChar <= '9'))
            //    {
            //        mnCardId.Append(e.KeyChar);
            //    }
            //    else
            //    {
            //        this.HandleMessage(new CardReader(), mnCardId.ToString());
            //        mnCardId.Clear();
            //    }
            //}
        }

        /// <summary>
        /// 掺假样
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmBtnVerifSample_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_VerifSample"))
            {
                this.ShowPage(Page.SP_VerifSample);
            }
        }

      

        private void tsmSysConfig_Click(object sender, EventArgs e)
        {
            SysServerConfig();
        }

        private void 化验审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_Audit"))
            {
                this.ShowPage(Page.WP_HuaYanShenHe);
            }
        }

        private void 添加检验项目菜单_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_AddCheckItem"))
            {
                this.ShowPage(Page.SP_AddCheckItem);
            }
        }

        private void 特别指定菜单_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_Tbzd"))
            {
                this.ShowPage(Page.WP_Tbzd);
            }
        }

        private void 检验路径菜单_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_Road"))
            {
                this.ShowPage(Page.SP_WpRoute);
            }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 管理抽样ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_ManageExamineSample"))
            {
                this.ShowPage(Page.SP_ManageExamineSample);
            }
        }

        private void 复检ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_ReCheck"))
            {
                this.ShowPage(Page.SP_ReCheck);
            }
        }

        private void 管理查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {


         //   this.ShowPage(Page.SR_Hbcx);



            if (this.CheckRight("QC_SR_gl"))
            {
                this.ShowPage(Page.SR_Manage);
            }
        }

        private void 修改查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_SR_gl"))
            {
                this.ShowPage(Page.SR_Xiugai);
            }
        }

        private void 取样查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_SR_qy"))
            {
                this.ShowPage(Page.SR_QuYang);
            }
        }
       
        private void 制样查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_SR_zy"))
            {
                this.ShowPage(Page.SR_ZhiYang);
            }
        }

        private void 化验查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_SR_hy"))
            {
                this.ShowPage(Page.SR_HuaYan);
            }
        }

        private void 审核查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_SR_sh"))
            {
                this.ShowPage(Page.SR_ShenHe);
            }
        }

        private void 综合科查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_SR_zhk"))
            {
                this.ShowPage(Page.SR_ZongHeKe);
            }
        }

        private void 采购查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_SR_cg"))
            {
                this.ShowPage(Page.SR_Caigou);
            }
        }

        private void 精煤化验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_CheckVal"))
            {
                this.ShowPage(Page.WP_HuaYan);
            }
        }

        private void 精粉化验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_CheckVal"))
            {
                this.ShowPage(Page.WP_JFHuaYan);
            }
        }

        private void 检验数据上传ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_CheckVal"))
            {
                this.ShowPage(Page.SR_Shangchuan);
            }
        }

        private void 精粉化验审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_Audit"))
            {
                this.ShowPage(Page.WP_JFHuaYanShenHe);
            }
        }

        private void 荧光仪数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_CheckVal"))
            {
                this.ShowPage(Page.SR_YingGuang);
            }
        }

        private void 自动判定依据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_ZDPD"))
            {
                this.ShowPage(Page.SR_Pdyj);
            }
          
        }

        private void 回传取样信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowPage(Page.WP_Hcqy);
        }

        private void 取样机采集信息修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_SR_qy"))
            {
                DlgQyxx qyxx = new DlgQyxx();
                qyxx.Show();
            }
        }

        private void 外矿化验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_CheckVal"))
            {
                this.ShowPage(Page.WP_WKHuaYan);
            }
        }

        private void 外矿化验审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_Audit"))
            {
                this.ShowPage(Page.WP_WKHuaYanShenHe);
            }
        }

        private void 取用查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowPage(Page.SR_QYCX);
        }

        private void 合金化验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_CheckVal"))
            {
                this.ShowPage(Page.WP_HJHuaYan);
            }
        }

        private void 合金化验审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_Audit"))
            {
                this.ShowPage(Page.WP_HJHuaYanShenHe);
            }
        }

        private void 火运化验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckRight("QC_CheckVal"))
            {
                this.ShowPage(Page.WP_HYHuaYan);
            }
        }

        private void 火运化验审核ToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            if (this.CheckRight("QC_Audit"))
            {
                this.ShowPage(Page.WP_HYHuaYanShenHe);
            }
            
        }



    }

}

