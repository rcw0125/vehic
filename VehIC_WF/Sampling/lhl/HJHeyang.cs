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
namespace VehIC_WF.Sampling.lhl
{
    public partial class HJHeyang : UserControl
    {
        public HJHeyang()
        {
            InitializeComponent();
        }
        DbEntityTable<QC_Sample_Veh> hjvehs = new DbEntityTable<QC_Sample_Veh>();
        DbEntityTable<QC_Sample_Mix> hjmixs = new DbEntityTable<QC_Sample_Mix>();
        private Dictionary<int, List<int>> FenZu(int xtShu, int dtShu)
        {
            List<int> xiaotongHao = new List<int>();
            for (int i = 0; i < xtShu; i++)
            {
                xiaotongHao.Add(i);
            }
            //为每个大桶分配一个小桶
            Dictionary<int, List<int>> result = new Dictionary<int, List<int>>();
            for (int i = 0; i < dtShu; i++)
            {
                Random r = new Random(DateTime.Now.Second + i * 27);
                int idx = r.Next(xiaotongHao.Count);
                List<int> item = new List<int>();
                item.Add(xiaotongHao[idx]);
                result.Add(i, item);
                xiaotongHao.RemoveAt(idx);
            }

            foreach (var xtHao in xiaotongHao)
            {
                Random r = new Random(DateTime.Now.Second + xtHao * 11);
                int idx = r.Next(dtShu);
                result[idx].Add(xtHao);
            }

            return result;
        }
        private void 组批_Click(object sender, EventArgs e)
        {
            this.hjvehs.Save();

            if (MessageBox.Show("确实要组批吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Dictionary<string, List<QC_Sample_Veh>> vehFenzu = new Dictionary<string, List<QC_Sample_Veh>>();

                foreach (var veh in hjvehs)
                {
                    if (veh.zp)
                    {
                        string key = veh.MatPK + "_" + veh.SupplierCode;
                        if (vehFenzu.ContainsKey(key))
                        {
                            vehFenzu[key].Add(veh);
                        }
                        else
                        {
                            vehFenzu.Add(key, new List<QC_Sample_Veh>() { veh });
                        }
                    }
                  
                }

                foreach (var item in vehFenzu)
                {

                    int xiaotongshu = item.Value.Count;
                    int datongshu = 1;
                    QC_Sample_Veh tempVeh = item.Value[0];
                  
                    QC_Material matInfo = QC_Material.GetByCode(tempVeh.MatCode);
                    if (matInfo != null)
                    {
                        if (xiaotongshu <= matInfo.BatchNum)
                            datongshu = 1;
                        else if (xiaotongshu % matInfo.BatchNum == 0)
                            datongshu = item.Value.Count / matInfo.BatchNum;
                        else if (xiaotongshu % matInfo.BatchNum != 0)
                            datongshu = item.Value.Count / matInfo.BatchNum+1;

                    }
                    





                    if (datongshu > xiaotongshu) datongshu = xiaotongshu;

                    Dictionary<int, List<int>> fp = FenZu(xiaotongshu, datongshu);
                    foreach (var fpItem in fp)
                    {
                        List<QC_Sample_Veh> vehs = new List<QC_Sample_Veh>();
                        foreach (var xtHao in fpItem.Value)
                        {
                            QC_Sample_Veh tempVeh2 = item.Value[xtHao];

                            vehs.Add(tempVeh2);
                        
                        }
                        if (vehs.Count > 0)
                        {
                            QC_Sample_Mix mix = new QC_Sample_Mix();
                            mix.WpCode = "0083";
                            mix.MatCode = vehs[0].MatCode;
                            mix.MatPK = vehs[0].MatPK;
                            mix.Mix_Time = DateTime.Now;
                            mix.FangTong_Time = DateTime.Now;
                            mix.ShouTong_Time = DateTime.Now;
                            mix.ShouTong_User= LocalInfo.Current.user.ID;
                            mix.FangTong_User = LocalInfo.Current.user.ID;
                            mix.MixCount = vehs.Count;
                            mix.MixPlanCount = vehs.Count;
                            mix.SupplierCode = vehs[0].SupplierCode;
                            mix.MixUser = LocalInfo.Current.user.ID;
                            mix.SampleState = SampleState.组批完成;
                            mix.SampleType = SampleType.普通样;
                            mix.WLLX = vehs[0].WLLX;
                            mix.CardID = Zhc.Data.DbContext.GetSeq("HB" + DateTime.Now.Date.ToString("yyyyMMdd"), 2);
                            mix.Save();
                            hjmixs.Add(mix);
                            foreach (var veh in vehs)
                            {
                                veh.Sample_Mix_ID = mix.Sample_Mix_ID;
                                veh.Mix_Time = DateTime.Now;
                                veh.SampleState = SampleState.组批完成;
                                veh.Save();
                            }
                            QC_Sample_Mix mixpb = new QC_Sample_Mix();
                            mixpb.MatCode = vehs[0].MatCode;
                            mixpb.MatPK = vehs[0].MatPK;
                            mixpb.WpCode = "0083";
                            mixpb.WLLX = vehs[0].WLLX;
                            mixpb.Mix_Time = DateTime.Now;
                            mixpb.FangTong_Time = DateTime.Now;
                            mixpb.ShouTong_Time = DateTime.Now;
                            mixpb.ShouTong_User = LocalInfo.Current.user.ID;
                            mixpb.FangTong_User = LocalInfo.Current.user.ID;
                            mixpb.MixCount = vehs.Count;
                            mixpb.MixPlanCount = vehs.Count;
                            mixpb.SupplierCode = vehs[0].SupplierCode;
                            mixpb.MixUser = LocalInfo.Current.user.ID;
                            mixpb.CardID = "PB"+mix.CardID.Remove(0,2); 
                            mixpb.MainSampleMixId = mix.Sample_Mix_ID;
                            mixpb.SampleType = SampleType.破包样;
                            mixpb.SampleState = SampleState.组批完成;
                            mixpb.Save();
                        }
                   
                    }
                 
                }

                  PrintZupi();
            }
        
        
        
        
        }

        private void PrintZupi()
        {
            this.printPreviewDialog2.ShowDialog();
        }

        private void 刷新_Click(object sender, EventArgs e)
        {
            hjvehs.LoadDataByWhere("main.SAMPLESTATE=@SAMPLESTATE and WLLX='合金'", SampleState.初始状态);
        }

        private void HJHeyang_Load(object sender, EventArgs e)
        {
            hjvehs.LoadDataByWhere("main.SAMPLESTATE=@SAMPLESTATE and WLLX='合金'", SampleState.初始状态);
            this.qCSampleVehBindingSource.DataSource = hjvehs;
        }
        private int curZupiPrintPage = 1;
        class ZupiData
        {
            private string head = "";

            public string Head
            {
                get { return head; }
                set { head = value; }
            }

            private List<string> zupiItems = new List<string>();

            public List<string> ZupiItems
            {
                get { return zupiItems; }
                set { zupiItems = value; }
            }

            private int beginPage = 0;

            public int BeginPage
            {
                get { return beginPage; }
                set { beginPage = value; }
            }

            public int NeadPage
            {
                get
                {
                    if (zupiItems.Count <= 6)
                    {
                        return 1;
                    }
                    else
                    {
                        return 1 + Convert.ToInt32(Math.Ceiling((ZupiItems.Count - 6) / 10.0));
                    }
                }
            }

            public int EndPage
            {
                get
                {
                    return BeginPage + NeadPage;
                }
            }

            public void Print(Graphics Graphics, int curPage)
            {
                Font f2 = new System.Drawing.Font("宋体", 10f, FontStyle.Bold);
                SizeF bodySize = Graphics.MeasureString(ZupiItems[0], f2);
                Rectangle rect = new Rectangle(9, 3, 112, 94);
                if (curPage == beginPage)
                {
                    Font f1 = new System.Drawing.Font("宋体", 21, FontStyle.Bold);
                    SizeF headSize = Graphics.MeasureString(head, f1);
                    float leftMargin = rect.Left + (rect.Width - headSize.Width) / 2;

                    float height = headSize.Height;

                    List<string> temp = new List<string>();
                    for (int i = 0; i < 6 && i < zupiItems.Count; i += 2)
                    {
                        string prefix = "/";
                        if (i == 0) prefix = "";
                        if (i + 1 < zupiItems.Count)
                            temp.Add(prefix + zupiItems[i] + "/" + zupiItems[i + 1]);
                        else
                            temp.Add(prefix + zupiItems[i]);

                        height += bodySize.Height + 2;
                    }

                    float topMargin = rect.Top + (rect.Height - height) / 2;

                    Graphics.DrawString(head, f1, Brushes.Black, new PointF(leftMargin, topMargin));
                    topMargin += headSize.Height;
                    foreach (var item in temp)
                    {
                        SizeF itemSize = Graphics.MeasureString(item, f2);

                        float leftMargin2 = rect.Left + (rect.Width - itemSize.Width) / 2;
                        Graphics.DrawString(item, f2, Brushes.Black, new PointF(leftMargin2, topMargin));
                        topMargin += itemSize.Height + 2;
                    }
                }
                else
                {
                    int p = curPage - BeginPage;
                    int i = 6 + (p - 1) * 10;
                    int endi = i + 10;
                    float height = 0;
                    List<string> temp = new List<string>();
                    for (; i < endi && i < zupiItems.Count; i += 2)
                    {
                        string prefix = "/";
                        if (i == 0) prefix = "";
                        if (i + 1 < zupiItems.Count)
                            temp.Add(prefix + zupiItems[i] + "/" + zupiItems[i + 1]);
                        else
                            temp.Add(prefix + zupiItems[i]);

                        height += bodySize.Height + 2;
                    }

                    float topMargin = rect.Top + (rect.Height - height) / 2;

                    foreach (var item in temp)
                    {
                        SizeF itemSize = Graphics.MeasureString(item, f2);
                        float leftMargin2 = rect.Left + (rect.Width - itemSize.Width) / 2;
                        Graphics.DrawString(item, f2, Brushes.Black, new PointF(leftMargin2, topMargin));
                        topMargin += itemSize.Height + 2;
                    }
                }
                // e.Graphics.DrawRectangle(Pens.Black, rect);

                //

            }

        }
        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           

            List<ZupiData> printData = new List<ZupiData>();

            foreach (var mix in hjmixs)
            {
                List<string> vehnos = new List<string>();
                DbEntityTable<QC_Sample_Veh> vehs = new DbEntityTable<QC_Sample_Veh>();
                vehs.LoadDataByWhere("main.Sample_Mix_ID=@Sample_Mix_ID", mix.Sample_Mix_ID);
                foreach (var item in vehs)
                {
                    vehnos.Add(QC_Sample_Mix.ShortStoreCode(item.CardID));
               
                }

                if (vehnos.Count > 0)
                {
                    ZupiData zd = new ZupiData();
                    zd.Head = QC_Sample_Mix.ShortStoreCode(mix.CardID);
                    zd.ZupiItems = vehnos;
                    printData.Add(zd);
                    ZupiData pbzd = new ZupiData();
                    pbzd.Head = QC_Sample_Mix.ShortStoreCode("PB" + mix.CardID.Remove(0, 2));
                    pbzd.ZupiItems = vehnos;
                    printData.Add(pbzd);
                }
  
            }
            int totalPage = 1;
            foreach (var item in printData)
            {
                item.BeginPage = totalPage;
                totalPage += item.NeadPage;
            }

            int printPage = totalPage - curZupiPrintPage;

            foreach (var item in printData)
            {
                if (printPage >= item.BeginPage && printPage < item.EndPage)
                {
                    item.Print(e.Graphics, printPage);
                    break;
                }
            }

            if (curZupiPrintPage < totalPage - 1)
            {
                curZupiPrintPage++;
                e.HasMorePages = true;
            }
            else
            {
                curZupiPrintPage = 1;
                e.HasMorePages = false;
            }
        }

        private void 全选_Click(object sender, EventArgs e)
        {
            if (全选.Text == "全选")
            {
                foreach (var item in hjvehs)
                { item.zp = true; }
                全选.Text = "取消全选";
            }
            else
            {
                foreach (var item in hjvehs)
                { item.zp = false; }
                全选.Text = "全选";
            }
        }

        private void 打印组批信息_Click(object sender, EventArgs e)
        {
            this.printDocument2.Print();
        }

        
    }
}
