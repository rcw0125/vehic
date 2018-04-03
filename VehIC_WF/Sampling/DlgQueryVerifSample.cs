using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VehIC_WF.Sampling
{
    public partial class DlgQueryVerifSample : Form
    {
        public DlgQueryVerifSample()
        {
            InitializeComponent();
        }

        private string result = "";

        public string WhereSql
        {
            get { return result; }
            set { result = value; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string matCode = txtMatCode.Text.Trim();
            string matName = txtMatName.Text.Trim();
         
            if (!string.IsNullOrEmpty(matCode))
            {
                result = "MatCode like '%" + matCode + "%'";
            }
            if (!string.IsNullOrEmpty(matName))
            {
                if (result != "")
                    result += " AND ";

                result += " MatName like '%" + matName + "%'";
            }
           
            if (!string.IsNullOrEmpty(this.dateEdit_Begin.Text.Trim()))
            {
                if (result != "")
                    result += " AND ";

                result += " ShouTong_Time >= CONVERT(datetime,'" + this.dateEdit_Begin.Text.Trim() + "',20)";
            }

            if (!string.IsNullOrEmpty(this.dateEdit_End.Text.Trim()))
            {
                if (result != "")
                    result += " AND ";

                result += " ShouTong_Time <= CONVERT(datetime,'" + this.dateEdit_End.Text.Trim() + "',20)";
            }
        }

    }
}
