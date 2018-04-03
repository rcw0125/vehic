using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VehIC_WF.Sampling.czl.Class;
using Xg.Lab.Sample;
using Zhc.Data;
namespace VehIC_WF.Sampling
{
    public partial class DlgQuerySample : Form
    {
        public DlgQuerySample()
        {
            InitializeComponent();
        }

        private string result = "";

        public string WhereSql
        {
            get { return result; }
            set { result = value; }
        }
       
    
        private DbEntityTable<QC_MixCheckGroup> CheckGroups = new DbEntityTable<QC_MixCheckGroup>();
        private void btnOk_Click(object sender, EventArgs e)
        {
            

            string matCode = txtMatCode.Text.Trim();
            string matName = txtMatName.Text.Trim();
            string supplierCode = txtSupplierCode.Text.Trim();
            string supplierName = txtSupplierName.Text.Trim();
            string vehno = txtVehNo.Text.Trim();

            string sampleType = cmbSampleTypes.Text.Trim();
            string sampleState = cmbSampleStates.Text.Trim();
            string zydanhao = txtZyDanHao.Text.Trim();
            string jydanhao = txtJyDanHao.Text.Trim();

            if (!string.IsNullOrEmpty(matCode))
            {
                result = "mat.INVCODE like '%" + matCode + "%'";
            }
            if (!string.IsNullOrEmpty(matName))
            {
                if (result != "")
                    result += " AND ";

                result += " mat.INVNAME like '%" + matName + "%'";
            }

            if (!string.IsNullOrEmpty(zydanhao))
            {
                if (result != "")
                    result += " AND ";

                result += " (main.ZyDanHao like '%" + zydanhao + "%' or exists (select * from qc_sample_lab lab11 inner join qc_mixcheckgroup mkg11 on mkg11.sample_lab_id=lab11.sample_lab_id where mkg11.sample_mix_id= main.sample_mix_id and (lab11.storecode like '%" + zydanhao + "%' or mkg11.storecode like '%" + zydanhao + "%'))) ";

      
            }

            if (!string.IsNullOrEmpty(jydanhao))
            {
                if (result != "")
                    result += " AND ";

                result += " exists (select * from qc_sample_lab lab11 inner join qc_mixcheckgroup mkg11 on mkg11.sample_lab_id=lab11.sample_lab_id where mkg11.sample_mix_id= main.sample_mix_id and lab11.jycode like '%" + jydanhao + "%') ";
            }

            if (!string.IsNullOrEmpty(sampleType))
            {
                if (result != "")
                    result += " AND ";

                SampleType st = SampleType.普通样;

                if (Enum.TryParse<SampleType>(sampleType, out st))
                {
                    result += " main.SampleType = " + Convert.ToInt32(st).ToString() + " ";
                }
                else
                {
                    MessageBox.Show("检验类型格式不对");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(sampleState))
            {
                if (result != "")
                    result += " AND ";

                SampleState st = SampleState.初始状态;

                if (Enum.TryParse<SampleState>(sampleState, out st))
                {
                    result += " main.SampleState = " + Convert.ToInt32(st).ToString() + " ";
                }
                else
                {
                    MessageBox.Show("检验状态格式不对");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(supplierCode))
            {
                if (result != "")
                    result += " AND ";

                result += " main.SupplierCode like '%" + supplierCode + "%'";
            }

            if (!string.IsNullOrEmpty(supplierName))
            {
                if (result != "")
                    result += " AND ";

                result += " supplier.CUSTNAME like '%" + supplierName + "%'";
            }

            if (!string.IsNullOrEmpty(vehno))
            {
                if (result != "")
                    result += " AND ";

                result += " main.VehNo like '%" + vehno + "%'";
            }

            if (!string.IsNullOrEmpty(this.dateEdit_Begin.Text.Trim()))
            {
                if (result != "")
                    result += " AND ";
                result += " main.Mix_Time >= CONVERT(datetime,'" + this.dateEdit_Begin.Text.Trim() + "',20)";
            }

            if (!string.IsNullOrEmpty(this.dateEdit_End.Text.Trim()))
            {
                if (result != "")
                    result += " AND ";

                result += " main.Mix_Time <= CONVERT(datetime,'" + this.dateEdit_End.Text.Trim() + "',20)";
            }

            if (!string.IsNullOrEmpty(this.dateEdit_nc_Begin.Text.Trim()))
            {
                if (result != "")
                    result += " AND ";
                result += " main.UploadNcTime >= CONVERT(datetime,'" + this.dateEdit_nc_Begin.Text.Trim() + "',20)";
            }

            if (!string.IsNullOrEmpty(this.dateEdit_nc_End.Text.Trim()))
            {
                if (result != "")
                    result += " AND ";

                result += " main.UploadNcTime <= CONVERT(datetime,'" + this.dateEdit_nc_End.Text.Trim() + "',20)";
            }

            if (!string.IsNullOrEmpty(this.textMYYDH.Text.Trim()))
            {


                CheckGroups.LoadDataByWhere("main.ZupiHao like '%" + this.textMYYDH.Text.Trim() + "%' order by main.Sample_Mix_ID desc");
                if (CheckGroups.Count > 0)
                {
                
                 if (result != "")
                    result += " AND ";

                 result += "  main.Sample_Mix_ID='" + CheckGroups[0].Sample_Mix_ID + "'";
                
                
                }
            
            
            }
        }

        private void DlgQuerySample_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetNames(typeof(SampleType)))
            {
                this.cmbSampleTypes.Properties.Items.Add(item);
            }
            foreach (var item in Enum.GetNames(typeof(SampleState)))
            {
                this.cmbSampleStates.Properties.Items.Add(item);
            }
        }
    }
}
