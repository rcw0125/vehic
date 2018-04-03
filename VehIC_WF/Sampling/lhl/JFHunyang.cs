using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Zhc.Data;


using Xg.Lab.Sample;

namespace VehIC_WF.WorkPoint
{
    public partial class JFHunyang : UserControl, ICardMessage
    {
        Boolean isfangtong = false;
        string  CardID = "";
        public JFHunyang()
        {
            InitializeComponent();
        }

        // 接受磁卡信息
        public void HandleCardMessage(Device.CardReader device, string cardId)
        {
            lock (this)
            {
                CardID = cardId;

                DbEntityTable<QC_IC_Info> hycrds = new DbEntityTable<QC_IC_Info>();
                hycrds.LoadDataByWhere("CardID=@CardID and CardType=@CardType ", CardID, "CUT002");

                foreach (var qcic in hycrds)
                {
                    if (qcic.SampleId == 0)
                    {
                        yxcard = true;
                        label3.Text = System.DateTime.Now + "扫卡成功!";

                        label3.ForeColor = Color.Red;
                    }
                    else
                    {
                        label3.Text = System.DateTime.Now + "该卡已经使用!";
                        label3.ForeColor = Color.Red;
                    }
                }
                if (sum <= sjtnum)
                {
                    label2.Text = System.DateTime.Now + "大桶样已经取够!";
                    label2.ForeColor = Color.Red;
                }
                // 开始放小桶样
                bool isxycard = false;
                label4.Text = "放入位置";
                DbEntityTable<QC_IC_Info> xycrds = new DbEntityTable<QC_IC_Info>();
                xycrds.LoadDataByWhere("CardID=@CardID and CardType=@CardType ", CardID, "CUT001");
                foreach (var qcic in xycrds)
                {
                    if (qcic.SampleId > 0)
                    {
                        isxycard = true;

                    }
                }
                int MIX_ID = 0;
                int weizhi = 0;
                int num = 0;
                if (isxycard == true)
                {
                    DbEntityTable<QC_Sample_Veh> vehcrds = new DbEntityTable<QC_Sample_Veh>();
                    vehcrds.LoadDataByWhere("main.CardID=@CardID and main.MIX_TIME is null and WLLX='精粉'", CardID);
                    foreach (var veh in vehcrds)
                    {
                        MIX_ID = veh.Sample_Mix_ID;

                        if (MIX_ID > 0)
                        {
                            DbEntityTable<QC_Sample_Mix> mixcrds = new DbEntityTable<QC_Sample_Mix>();
                            mixcrds.LoadDataByWhere("main.SAMPLE_MIX_ID=@SAMPLE_MIX_ID and main.WLLX='精粉'", MIX_ID);
                            foreach (var mix in mixcrds)
                            {
                                mix.MixCount = mix.MixCount + 1;

                                if (mix.MixCount == mix.MixPlanCount)
                                {
                                    mix.SampleState = SampleState.组批完成;
                                    mix.Mix_Time = System.DateTime.Now;
                                }
                                mix.Save();
                                weizhi = mix.TempID;
                                num = mix.MixCount;
                            }
                        veh.Mix_Time = System.DateTime.Now;
                        veh.Save();
                        }
                    }

                    if (weizhi > 0)
                    {
                        Form3 ts = new Form3(weizhi, num);
                        ts.ShowDialog();
                        label4.Text = "放入位置" + weizhi + "     第" + num + "个小样";
                        label4.ForeColor = Color.Red;
                    }

                    // 更新显示信息
                    DbEntityTable<BC_DT_State> dtwzs = new DbEntityTable<BC_DT_State>();
                    dtwzs.LoadDataByWhere("WpCode='" + wordpointCode + "' and SHOUTONG_TIME IS NULL and WLLX='精粉'");
                    this.bCDTStateBindingSource.DataSource = dtwzs;
                }
            }
        }

        Boolean yxcard = false;
   

        private bool isNumberic(string var)
        {
            try
            {
                int a = Convert.ToInt32(var);
                return true;
            }
            catch
            {
                return false;
            }
        }

        int dtgs = 0;
        int sum = 0;
        public void jsdtgs()
        {
            dtgs = 0;
            int fzcs = 0;
            //组抽样的
            DbEntityTable<cheshu> cheshucy = new DbEntityTable<cheshu>();
            cheshucy.LoadDataBySql("select SUPPLIERCODE as cj,MATCODE as wl,WPCODE as dd,COUNT(*) as num from QC_Sample_Veh where sample_mix_id=0 and sample_tbzd=1 and SampleState=@SampleState and WLLX='精粉' group by SUPPLIERCODE,MATCODE,WPCODE", SampleState.初始状态);
            foreach (var x in cheshucy)
            {
               
                dtgs =  dtgs +x.num;
               
            }
         
            DbEntityTable<cheshu> cheshufl = new DbEntityTable<cheshu>();
            cheshufl.LoadDataBySql("select SUPPLIERCODE as cj,MATCODE as wl,WPCODE as dd,COUNT(*) as num from QC_Sample_Veh where sample_mix_id=0 and (sample_jy is null or sample_jy<>1) and sample_tbzd<>1 and SampleState=@SampleState and WLLX='精粉' group by SUPPLIERCODE,MATCODE,WPCODE", SampleState.初始状态);
            foreach (var x in cheshufl)
            {
                fzcs = 0;
                QC_Material matInfo = QC_Material.GetByCode(x.wl);
                if (matInfo != null)
                {
                  //  if (matInfo.InUse)
                 //   {

                    DbEntityTable<QC_MixRule> labrule = new DbEntityTable<QC_MixRule>();
                    labrule.LoadDataByWhere("MatNcId=@MatNcId and (CustCode=@CustCode or CustCode='' or CustCode is null) and VehNumber<=@VehNumber", matInfo.MatNcId, x.cj, x.num);
                    if (labrule.Count > 0)
                    {
                        if (labrule[0].PlanMixCount > 0)
                        {
                            fzcs = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(x.num) / labrule[0].PlanMixCount));
                        }
                    }
                        if (fzcs > 0)
                        {
                            dtgs = fzcs + dtgs;
                        }
                        else
                        {
                            dtgs = dtgs + Convert.ToInt32(Math.Ceiling(Convert.ToDouble(x.num) / matInfo.BatchNum));
                        }
                //    }
                }
            }
        }



        public void jsdtgs1()
        {
            dtgs = 0;
            int fzcs = 0;
            //组抽样的
            DbEntityTable<cheshu> cheshucy = new DbEntityTable<cheshu>();
            cheshucy.LoadDataBySql("select SUPPLIERCODE as cj,MATCODE as wl,WPCODE as dd,COUNT(*) as num from QC_Sample_Veh where sample_mix_id=0 and sample_tbzd=1 and SampleState=@SampleState and WLLX='精粉' group by SUPPLIERCODE,MATCODE,WPCODE", SampleState.开始组批);
            foreach (var x in cheshucy)
            {

                dtgs = dtgs + x.num;

            }

            DbEntityTable<cheshu> cheshufl = new DbEntityTable<cheshu>();
            cheshufl.LoadDataBySql("select SUPPLIERCODE as cj,MATCODE as wl,WPCODE as dd,COUNT(*) as num from QC_Sample_Veh where sample_mix_id=0 and (sample_jy is null or sample_jy<>1) and sample_tbzd<>1 and SampleState=@SampleState and WLLX='精粉' group by SUPPLIERCODE,MATCODE,WPCODE", SampleState.开始组批);
            foreach (var x in cheshufl)
            {
                fzcs = 0;
                QC_Material matInfo = QC_Material.GetByCode(x.wl);
                if (matInfo != null)
                {
                  //  if (matInfo.InUse)
                  //  {

                        DbEntityTable<QC_MixRule> labrule = new DbEntityTable<QC_MixRule>();
                        labrule.LoadDataByWhere("MatNcId=@MatNcId and (CustCode=@CustCode or CustCode='' or CustCode is null) and VehNumber<=@VehNumber", matInfo.MatNcId, x.cj, x.num);
                        if (labrule.Count > 0)
                        {
                            if (labrule[0].PlanMixCount > 0)
                            {
                                fzcs = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(x.num) / labrule[0].PlanMixCount));
                            }
                        }
                        if (fzcs > 0)
                        {
                            dtgs = fzcs + dtgs;
                        }
                        else
                        {
                            dtgs = dtgs + Convert.ToInt32(Math.Ceiling(Convert.ToDouble(x.num) / matInfo.BatchNum));
                        }
                  //  }
                }
            }
        }
        Int32 sjtnum = 0;
        string wordpointCode = "0067";
        private void Hunyang_Load(object sender, EventArgs e)
        {
         
            isfangtong = false;
         
            DbEntityTable<BC_DT_State> dtwzs = new DbEntityTable<BC_DT_State>();
            dtwzs.LoadDataByWhere("WpCode='" + wordpointCode + "' and SHOUTONG_TIME IS NULL and WLLX='精粉'");
            this.bCDTStateBindingSource.DataSource = dtwzs;
           


        }

        public void zupi()
        {

            //按厂家，地点，物料分类
            int dtmax = 0;

            //组抽样的
            DbEntityTable<cheshu> cheshucy = new DbEntityTable<cheshu>();
            cheshucy.LoadDataBySql("select SUPPLIERCODE as cj,MATCODE as wl,WPCODE as dd  from QC_Sample_Veh where sample_mix_id=0 and sample_tbzd=1 and SampleState=@SampleState and WLLX='精粉'", SampleState.开始组批);
            foreach (var x in cheshucy)
            {
                dtmax = 1;
                zupiduoche(x.cj, x.wl, x.dd, dtmax,"抽样");
            }

            DbEntityTable<cheshu> cheshufl = new DbEntityTable<cheshu>();
            cheshufl.LoadDataBySql("select SUPPLIERCODE as cj,MATCODE as wl,WPCODE as dd,COUNT(*) as num from QC_Sample_Veh where sample_mix_id=0 and (sample_jy is null or sample_jy<>1) and sample_tbzd<>1 and SampleState=@SampleState and WLLX='精粉' group by SUPPLIERCODE,MATCODE,WPCODE ", SampleState.开始组批);
        
            foreach (var x in cheshufl)
            {

                //判定是否有车数比较多

                QC_Material matInfo = QC_Material.GetByCode(x.wl);
                if (matInfo != null)
                {
//                    if (matInfo.InUse)
  //                  {
                        dtmax = matInfo.BatchNum;
                        DbEntityTable<QC_MixRule> labrule = new DbEntityTable<QC_MixRule>();
                        labrule.LoadDataByWhere("MatNcId=@MatNcId and (CustCode=@CustCode or CustCode='' or CustCode is null) and VehNumber<=@VehNumber", matInfo.MatNcId, x.cj, x.num);
                        if (labrule.Count > 0)
                        {
                            if (labrule[0].PlanMixCount > 0)
                            {
                                dtmax = labrule[0].PlanMixCount;
                            }
                        }
                       
  //                  }
                }
                zupiduoche(x.cj, x.wl, x.dd, dtmax,"正常样");
            }
        }

        private void zupiduoche(string cj, String wl, string zyd, int dtmax,string type)
        {
            int k = 0;
            int dyid = 0;
         
            DbEntityTable<QC_Sample_Veh> xks = new DbEntityTable<QC_Sample_Veh>();

            string zpwpcode = "";

          
           
                zpwpcode ="0067";             //NC到货单
            
            if (type == "抽样")
            {
                xks.LoadDataBySql("select * from QC_Sample_Veh where SUPPLIERCODE=@SUPPLIERCODE and MATCODE=@MATCODE and WPCODE=@WPCODE and sample_mix_id=0 and sample_tbzd=1 and SAMPLESTATE=@SAMPLESTATE and WLLX='精粉'", cj, wl, zyd, SampleState.开始组批);
            }

            if (type == "正常样")
            {
                xks.LoadDataByWhere("main.SUPPLIERCODE=@SUPPLIERCODE and main.MATCODE=@MATCODE and main.WPCODE=@WPCODE and main.sample_mix_id=0 and (main.sample_jy is null or main.sample_jy<>1) and main.sample_tbzd<>1  and main.SAMPLESTATE=@SAMPLESTATE and WLLX='精粉'", cj, wl, zyd, SampleState.开始组批);
                // xks.LoadDataBySql("select * from QC_Sample_Veh where SUPPLIERCODE=@SUPPLIERCODE and MATCODE=@MATCODE and WPCODE=@WPCODE and sample_mix_id=0 and (sample_jy is null or sample_jy<>1) and sample_tbzd<>1  and SAMPLESTATE=@SAMPLESTATE ", cj, wl, zyd, SampleState.开始组批);
                xks.Sort((v1, v2) => v1.Pxsl.CompareTo(v2.Pxsl));
            }

            

            foreach (var xk in xks)
            {
                k = k + 1;
                if ((k + dtmax - 1) % dtmax == 0 && wl == xk.MatCode && cj == xk.SupplierCode && zyd == xk.WpCode)
                {
                    DbEntityTable<QC_Sample_Mix> dty = new DbEntityTable<QC_Sample_Mix>();
                    dty.LoadDataByWhere("main.SampleState=@SampleState and main.WpCode=@WpCode and main.WLLX='精粉'", SampleState.初始状态, zpwpcode);
                    int cishu = 1;
                    if (dty.Count == 0)
                    {
                        label6.Text = "大桶不够了";
                        return;
                    }
                    foreach (var hy in dty)
                    {
                        //只取一个大桶
                        cishu = cishu + 1;
                        if (cishu == 2)
                        {
                            hy.MatPK = xk.MatPK;                      //物料主键
                            hy.Mix_Time = System.DateTime.Now;        //混样时间
                            hy.SupplierCode = xk.SupplierCode;        //供应商
                            hy.MatCode = xk.MatCode;                  //物料编码
                            hy.MixUser = LocalInfo.Current.user.ID;   //混样人
                            hy.Sample_TBZD = xk.SAMPLE_TBZD;
                            hy.SampleType = xk.SampleType;        //样品类型
                            hy.SampleState = SampleState.开始组批;    //样品状态
                            hy.Save();
                            dyid = hy.Sample_Mix_ID;
                        }
                    }
                }
                if(dyid>0)
                {
                xk.Sample_Mix_ID = dyid;
                xk.SampleState = SampleState.组批完成;
                xk.Save();
                label6.Text = "组批完成";
                }
                DbEntityTable<QC_Sample_Mix> jhplans = new DbEntityTable<QC_Sample_Mix>();
                jhplans.LoadDataByWhere("main.sample_mix_id=@sample_mix_id", dyid);
                foreach (var hy in jhplans)
                {
                   object result1 = DbContext.ExecuteScalar("select count(*) as num from QC_Sample_Veh where sample_mix_id=@sample_mix_id", hy.Sample_Mix_ID);
                   if (result1 != null && result1 != DBNull.Value)
                   {
                       hy.MixPlanCount = Convert.ToInt32(result1);             //桶个数
                   }
                   hy.Save();
                }
            }
            isfangtong = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)        {
            zupi();
            // 更新显示信息
            DbEntityTable<BC_DT_State> dtwzs = new DbEntityTable<BC_DT_State>();
            dtwzs.LoadDataByWhere("WpCode='" + wordpointCode + "' and SHOUTONG_TIME IS NULL and WLLX='精粉'");
            this.bCDTStateBindingSource.DataSource = dtwzs;
            QC_Sample_Mix.UpdateInspectMainSample();
            qyts ts = new qyts("组批成功！下一步放小样！");
            ts.ShowDialog(); 

        }

        //放桶
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //放桶
            if (CardID == "")
            {
                MessageBox.Show("请刷卡");
                return;
            }
            yxcard = false;
            DbEntityTable<BC_DT_State> dtwzs = new DbEntityTable<BC_DT_State>();
            DbEntityTable<QC_IC_Info> hycrds = new DbEntityTable<QC_IC_Info>();
            hycrds.LoadDataByWhere("CardID=@CardID and CardType=@CardType ", CardID, "CUT002");
            foreach (var qcic in hycrds)
            {
                if (qcic.SampleId == 0)
                {
                    yxcard = true;
                    label3.Text = System.DateTime.Now + "扫卡成功";
                    label3.ForeColor = Color.Red;
                }
                else
                {
                    MessageBox.Show("该卡已经使用");
                    return;    //该卡已经注册
                }
            }
            if (yxcard == true)   //是有效卡
            {
                if (sum > sjtnum)
                {
                    sjtnum = sjtnum + 1;
                    dtgs = dtgs - 1;
                    if (dtgs > 0)
                    {
                        label5.Text = "需要" + dtgs + "个大桶!";
                        qyts ts = new qyts(label5.Text);

                        ts.ShowDialog();
                    }
                    else
                    {
                        label5.Text = "大桶已经放好!";
                        qyts ts = new qyts(label5.Text);
                        ts.ShowDialog();

                    }
                    int a = sjtnum + 1;
                    label2.Text = "选择位置" + a;
                    label2.ForeColor = Color.Red;
                }
                else
                {
                    isfangtong = false;
                    label5.Text = "大桶已经放好!";
                    qyts ts = new qyts(label5.Text);
                    ts.ShowDialog();
                    dtwzs.LoadDataByWhere("WpCode='" + wordpointCode + "' and SHOUTONG_TIME IS NULL and WLLX='精粉'");
                    this.bCDTStateBindingSource.DataSource = dtwzs;
                    return;
                }
                QC_Sample_Mix hy = new QC_Sample_Mix();

                object result = DbContext.ExecuteScalar("select max(TempID) from QC_Sample_Mix where SampleState=" + Convert.ToInt32(SampleState.初始状态) + " and WpCode='" + wordpointCode + "' and WLLX='精粉'");
                if (result != null && result != DBNull.Value)
                {
                    hy.TempID = Convert.ToInt32(result) + 1;             //目前有的大桶个数
                }
                else
                {
                    hy.TempID = 1;
                }
           
                hy.SampleState = SampleState.初始状态;
                hy.WpCode = wordpointCode;
                hy.WLLX="精粉";
                hy.CardID = CardID;
                hy.FangTong_Time = System.DateTime.Now;
             
                hy.Save();
              
                if(isfangtong == false)
                {
                    DbEntityTable<QC_Sample_Veh> sxks = new DbEntityTable<QC_Sample_Veh>();
                    sxks.LoadDataByWhere("main.SAMPLESTATE=@SAMPLESTATE and WLLX='精粉'", SampleState.初始状态);
                   foreach (var sxk in sxks)
                   {
                       sxk.SampleState = SampleState.开始组批;
                       sxk.Save();
                   }

                }
                
                isfangtong = true;    //正在放大桶
                DbEntityTable<QC_IC_Info> qcics = new DbEntityTable<QC_IC_Info>();
                qcics.LoadDataByWhere("CardID=@CardID and CardType=@CardType ", hy.CardID, "CUT002");
                foreach (var qcic in qcics)
                {
                    qcic.SampleId = hy.Sample_Mix_ID;
                    qcic.Save();
                    label3.Text = System.DateTime.Now + "保存成功";
                    label3.ForeColor = Color.Red;
                }
                if (sum <= sjtnum)
                {
                    label5.Text = "大桶已经放好";
                    label2.Text = "";
                    isfangtong = false;
                    dtwzs.LoadDataByWhere("WpCode='" + wordpointCode + "' and SHOUTONG_TIME IS NULL and WLLX='精粉'");
                    this.bCDTStateBindingSource.DataSource = dtwzs;
                    return;
                }
                CardID = "";
            }

            dtwzs.LoadDataByWhere("WpCode='" + wordpointCode + "' and SHOUTONG_TIME IS NULL and WLLX='精粉'");
            this.bCDTStateBindingSource.DataSource = dtwzs;
        }
        
        //收桶
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DbEntityTable<QC_Sample_Mix> qcvhs = new DbEntityTable<QC_Sample_Mix>();
            qcvhs.LoadDataByWhere("main.WpCode='" + wordpointCode + "' and main.SampleState =@SampleState and main.ShouTong_Time is null and main.WLLX='精粉'", SampleState.组批完成);
            foreach (var qcvh in qcvhs)
            {
                // qcvh.TempID = 0;
                qcvh.ShouTong_Time = System.DateTime.Now;
                //  qcvh.SampleState = SampleState.开始制样;
                qcvh.Save();

                //解绑小卡
                DbEntityTable<QC_Sample_Veh> vehcrds = new DbEntityTable<QC_Sample_Veh>();
                vehcrds.LoadDataByWhere("main.SAMPLE_MIX_ID=@SAMPLE_MIX_ID and WLLX='精粉'", qcvh.Sample_Mix_ID);
                foreach (var veh in vehcrds)
                {
                    DbEntityTable<QC_IC_Info> hycrds = new DbEntityTable<QC_IC_Info>();
                    hycrds.LoadDataByWhere("CARDID=@CARDID", veh.CardID);
                    foreach (var qcic in hycrds)
                    {
                        qcic.SampleId = 0;
                        qcic.Save();
                    }
                }
              }
            // 更新显示信息
            DbEntityTable<BC_DT_State> dtwzs = new DbEntityTable<BC_DT_State>();
            dtwzs.LoadDataByWhere("WpCode='" + wordpointCode + "' and SHOUTONG_TIME IS NULL and WLLX='精粉'");
            this.bCDTStateBindingSource.DataSource = dtwzs;
            qyts ts = new qyts("收桶成功！可以送去制样！");
            ts.ShowDialog();
            }

        //查询大桶个数
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (isfangtong == false)
            {
                sjtnum = 0;
                jsdtgs1();
                if (dtgs == 0)
                {
                    jsdtgs();
                }
                DbEntityTable<QC_Sample_Mix> dty = new DbEntityTable<QC_Sample_Mix>();
                object result = DbContext.ExecuteScalar("select max(TempID) from QC_Sample_Mix where SampleState=" + Convert.ToInt32(SampleState.初始状态) + " and WpCode='" + wordpointCode + "' and WLLX='精粉'");
                if (result != null && result != DBNull.Value)
                {
                    sjtnum = Convert.ToInt32(result);             //目前有的大桶个数

                }
                if (sjtnum >= dtgs)
                {
                    label5.Text = "大桶已经放好";
                }
                else
                {
                    sum = dtgs;
                    dtgs = dtgs - sjtnum;
                    label5.Text = "需要" + dtgs + "个大桶";
                    int a = sjtnum + 1;
                    label2.Text = "选择位置" + a;

                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            int hand = e.RowHandle;
            if (hand < 0) return;

            BC_DT_State jh = (BC_DT_State)gridView1.GetRow(hand);

            if (jh != null)
            {
                if (jh.MixPlanCount != jh.MixCount)
                {
                    e.Appearance.ForeColor = Color.Red;// 改变行字体颜色
                }
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         

        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
        }
    }
}
