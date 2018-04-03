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
    public partial class DlgZyInfo : Form
    {
        private string zyType = "";
        private string zyCode = "";
        public DlgZyInfo(string zytype,string zycode)
        {
            InitializeComponent();
            this.zyType = zytype;
            this.zyCode = zycode;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DlgZyInfo_Load(object sender, EventArgs e)
        {
            this.label1.Text = string.Format("{0}({1})完成磁卡绑定", zyType, zyCode);
        }
    }
}
