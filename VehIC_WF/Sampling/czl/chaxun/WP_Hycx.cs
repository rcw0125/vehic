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

namespace VehIC_WF.Sampling.czl.WorkPoint
{
    public partial class WP_Hycx : UserControl
    {
        public WP_Hycx()
        {
            InitializeComponent();
            
        }
        DbEntityTable<QC_Sample_Lab_Jy> lab = new DbEntityTable<QC_Sample_Lab_Jy>();
        DbEntityTable<QC_Shcx> cxs = new DbEntityTable<QC_Shcx>();
        DbEntityTable<QC_MixCheckGroup> mcg = new DbEntityTable<QC_MixCheckGroup>();
        DbEntityTable<QC_Sample_Mix> mix = new DbEntityTable<QC_Sample_Mix>();
        DbEntityTable<BD_INVBASDOC> wl = new DbEntityTable<BD_INVBASDOC>();
        DbEntityTable<QC_CheckGroup> cg = new DbEntityTable<QC_CheckGroup>();
        private void 查询检验单_Click(object sender, EventArgs e)
        {
            cxs.Clear();
            if (comboBox1.Text == "全部")
            { lab.LoadDataByWhere("main.JyTime>=@Ksdate and  main.JyTime<=@Jsdate order by main.JyCode ", DateTime.Parse(this.dateEdit1.Text.Trim()), DateTime.Parse(this.dateEdit2.Text.Trim())); }
            else  lab.LoadDataByWhere("main.JyTime>=@Ksdate and  main.JyTime<=@Jsdate and main.CheckGroupName=@CheckGroupName order by main.JyCode ", DateTime.Parse(this.dateEdit1.Text.Trim()), DateTime.Parse(this.dateEdit2.Text.Trim()), comboBox1.Text);

        
            
            for (int i = 0; i < lab.Count; i++)
            {   QC_Shcx cx = new QC_Shcx();
                lab[i].CheckVals.LoadDataByWhere("main.Sample_Lab_ID=@Sample_Lab_ID", lab[i].Sample_Lab_ID);
                cx.Sample_Shcx_ID = i + 1;
                cx.Yplx = lab[i].CheckGroupName;
                cx.Lybm = lab[i].JyCode;
                cx.Jyr = lab[i].JyUser;
                cx.Jysj = lab[i].JyTime;
              
                for (int j = 0; j < lab[i].CheckVals.Count; j++)
                {
                    if (lab[i].CheckVals[j].CheckUser != "")
                    {
                        cx.Fxry = lab[i].CheckVals[j].CheckUser;
                        cx.Fxsj = lab[i].CheckVals[j].CheckTime;
                    }
                    if(lab[i].CheckVals[j].CheckItemName.Equals("灰分"))
                    {
                      cx.Hf=lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("挥发分"))
                    {
                        cx.Hff=lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("S"))
                    {
                        cx.S = lab[i].CheckVals[j].CheckVal;
                    }
                
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("固定碳"))
                    {
                        cx.Gdt = lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("G"))
                    {
                        cx.G = lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("Y"))
                    {
                        cx.Y = lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("P"))
                    {
                        cx.P = lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("MgO"))
                    {
                        cx.MgO = lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("SiO2"))
                    {
                        cx.SiO2 = lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("CaO"))
                    {
                        cx.CaO = lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("Al2O3"))
                    {
                        cx.Al2O3 = lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("TFe"))
                    {
                        cx.TFe = lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("TiO2"))
                    {
                        cx.TiO2 = lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("Cu")) 
                    {
                        cx.Cu = lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("MnO"))
                    {
                        cx.MnO = lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("K2O"))
                    {
                        cx.K2O = lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("Na2O"))
                    {
                        cx.Na2O = lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("V2O5"))
                    {
                        cx.V2O5 = lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("Pb"))
                    {
                        cx.Pb = lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("Zn"))
                    {
                        cx.Zn = lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("As"))
                    {
                        cx.As = lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("Sn"))
                    {
                        cx.Sn = lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("Sb"))
                    {
                        cx.Sb = lab[i].CheckVals[j].CheckVal;
                    }
                    else if (lab[i].CheckVals[j].CheckItemName.Equals("硫分"))
                    {
                        cx.Lf = lab[i].CheckVals[j].CheckVal;
                    }
                }
                bool cunzai = false;
                foreach (var item in cxs)
                {
                    if (item.Sample_Shcx_ID == cx.Sample_Shcx_ID)
                    {
                        cunzai = true;
                    }
                }
                if (cunzai == false)
                { cxs.Add(cx); }
            }
            this.gridControl1.DataSource = cxs;
        }

        private void WP_Shcx_Load(object sender, EventArgs e)
        {
            cg.LoadData();
            List<String> cgname = new List<String>();
            List<String> wl = new List<String>();
            cgname.Add("全部");
            wl.Add("全部");
            foreach (var item in cg)
            {
                cgname.Add(item.CheckGroupName);
            }
            comboBox1.DataSource = cgname;
          
        }

        private void 导出ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.gridView1.Export(DevExpress.XtraPrinting.ExportTarget.Xls, saveFileDialog1.FileName);
            }
        }

        
    }
}
