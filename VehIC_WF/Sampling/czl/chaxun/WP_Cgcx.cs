using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zhc.Data;
using Xg.Lab.Sample;
using VehIC_WF.Sampling.czl.Class;
using VehIC_WF.Class;

namespace VehIC_WF.Sampling.czl.chaxun
{
    public partial class WP_Cgcx : UserControl
    {
        public WP_Cgcx()
        {
            InitializeComponent();
        }
        DbEntityTable<QC_Sample_Lab_Jy> lab = new DbEntityTable<QC_Sample_Lab_Jy>(); DbEntityTable<QC_Sample_Lab_Jy> labzong = new DbEntityTable<QC_Sample_Lab_Jy>();
        DbEntityTable<QC_Shcx> cxs = new DbEntityTable<QC_Shcx>();
        DbEntityTable<QC_MixCheckGroup> mcg = new DbEntityTable<QC_MixCheckGroup>();
        DbEntityTable<QC_MixCheckGroup> mcgzong = new DbEntityTable<QC_MixCheckGroup>();
        DbEntityTable<QC_Sample_Mix> mix = new DbEntityTable<QC_Sample_Mix>();
        DbEntityTable<BD_INVBASDOC> wl = new DbEntityTable<BD_INVBASDOC>();
        DbEntityTable<QC_Sample_Veh> veh = new DbEntityTable<QC_Sample_Veh>();
        private void 查询_Click(object sender, EventArgs e)
        {
            cxs.Clear();
            mix.Clear();
            mcg.Clear();
            mcgzong.Clear();
            lab.Clear();
            labzong.Clear();
            veh.Clear();
            if (comboBox1.Text == "全部" && comboBox2.Text == "全部")
            { mix.LoadDataByWhere("main.mix_time>=@Ksdate and main.mix_time<=@Jsdate and main.wllx='煤'", DateTime.Parse(this.dateEdit1.Text.Trim()), DateTime.Parse(this.dateEdit2.Text.Trim())); }
            else if (comboBox2.Text == "全部")
            { mix.LoadDataByWhere("main.mix_time>=@Ksdate and main.mix_time<=@Jsdate  and supplier.CUSTSHORTNAME=@SupplierName and main.wllx='煤'", DateTime.Parse(this.dateEdit1.Text.Trim()), DateTime.Parse(this.dateEdit2.Text.Trim()), comboBox1.Text); }
            else if (comboBox1.Text == "全部")
            { mix.LoadDataByWhere("main.mix_time>=@Ksdate and main.mix_time<=@Jsdate and mat.INVNAME=@MatName and main.wllx='煤'", DateTime.Parse(this.dateEdit1.Text.Trim()), DateTime.Parse(this.dateEdit2.Text.Trim()), comboBox2.Text); }

            else mix.LoadDataByWhere("main.mix_time>=@Ksdate and main.mix_time<=@Jsdate and supplier.CUSTSHORTNAME=@SupplierName and mat.INVNAME=@MatName and main.wllx='煤'", DateTime.Parse(this.dateEdit1.Text.Trim()), DateTime.Parse(this.dateEdit2.Text.Trim()), comboBox1.Text, comboBox2.Text); 
              
                foreach (var item in mix)
                {
                    mcg.LoadDataByWhere("main.Sample_Mix_ID=@Sample_Mix_ID and checkgroupname='化验样'", item.Sample_Mix_ID);
                
                    mcgzong.Add(mcg[0]);
                }
                foreach (var item in mcgzong)
                {
                    lab.LoadDataByWhere("main.Sample_Lab_ID=@Sample_Lab_ID  and labstate='审核通过' and  billtype='审核通过'", item.Sample_Lab_ID);
                    if(lab.Count>0)
                    labzong.Add(lab[0]);
                }
            
            
            for (int i = 0; i < labzong.Count; i++)
            {
             
                labzong[i].CheckVals.LoadDataByWhere("main.Sample_Lab_ID=@Sample_Lab_ID", labzong[i].Sample_Lab_ID);
                mcg.LoadDataByWhere("main.Sample_Lab_ID=@Sample_Lab_ID", labzong[i].Sample_Lab_ID);
                    mix.LoadDataByWhere("main.Sample_Mix_ID=@Sample_Lab_ID", mcg[0].Sample_Mix_ID);
                    wl.LoadDataByWhere("PK_INVBASDOC=@PK_INVBASDOC", mix[0].MatPK);
                    veh.LoadDataByWhere("Sample_Mix_ID=@Sample_Mix_ID", mcg[0].Sample_Mix_ID);
                   foreach (var item in veh)
                   {
                        QC_Shcx cx = new QC_Shcx();
                      //  cx.Sample_Shcx_ID = i + 1;
                        cx.Yplx = labzong[i].CheckGroupName;
                        cx.Lybm = labzong[i].JyCode;
                        cx.Jyr = labzong[i].JyUser;
                        cx.Jysj = labzong[i].JyTime;
                        cx.Gys = mix[0].SupplierName;
                        if (labzong[i].MatName == "")
                        cx.Wlmc = wl[0].INVNAME;
                        else cx.Wlmc = labzong[i].MatName;
                         cx.Cph = item.VehNo;
                         cx.Qysj = item.FetchTime;
                         for (int j = 0; j < labzong[i].CheckVals.Count; j++)
                         {
                             if (labzong[i].CheckVals[j].CheckItemName.Equals("灰分"))
                             {
                                 cx.Hf = labzong[i].CheckVals[j].CheckVal;
                             }
                             else if (labzong[i].CheckVals[j].CheckItemName.Equals("挥发分"))
                             {
                                 cx.Hff = labzong[i].CheckVals[j].CheckVal;
                             }
                             else if (labzong[i].CheckVals[j].CheckItemName.Equals("S"))
                             {
                                 cx.S = labzong[i].CheckVals[j].CheckVal;
                             }

                             else if (labzong[i].CheckVals[j].CheckItemName.Equals("固定碳"))
                             {
                                 cx.Gdt = labzong[i].CheckVals[j].CheckVal;
                             }
                             else if (labzong[i].CheckVals[j].CheckItemName.Equals("硫分"))
                             {
                                 cx.Lf = labzong[i].CheckVals[j].CheckVal;
                             }
                             else if (labzong[i].CheckVals[j].CheckItemName.Equals("发热量1"))
                             {
                                 cx.Frl = labzong[i].CheckVals[j].CheckVal;
                             }
                         }
                        cxs.Add(cx);
                        this.gridControl1.DataSource = cxs;
                   }
            }
          
        }

        private void gridControl1_Load(object sender, EventArgs e)
        {

            mix.LoadDataByWhere("main.mix_time>@mix_time and main.wllx='煤'", DateTime.Now.AddMonths(-1));
            List<String> gysname = new List<String>();
            List<String> wl = new List<String>();
            gysname.Add("全部");
            wl.Add("全部");
            foreach (var item in mix)
            {
                if (!gysname.Contains(item.SupplierName) && item.SupplierName != "")
                gysname.Add(item.SupplierName);
            }
            comboBox1.DataSource = gysname;
         
            foreach (var item in mix)
            {
                if (!wl.Contains(item.MatName) && item.MatName != "")
                    wl.Add(item.MatName);
            }
            mix.Clear();
            comboBox2.DataSource = wl;
        }
    }
}
