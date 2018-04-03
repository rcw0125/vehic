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
    public partial class DlgQueryMaterial : Form
    {
        public DlgQueryMaterial()
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
                result = "INVCODE like '%" + matCode + "%'";
            }
            if (!string.IsNullOrEmpty(matName))
            {
                if (result != "")
                    result += " AND ";

                result += " INVNAME like '%" + matName + "%'";
            }

        }
    }
}
