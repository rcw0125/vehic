using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VehIC_WF
{
    public partial class Form3 : Form
    {
        private int weizhi = 0;
        public int WeiZhi
        {
            get { return weizhi; }
            set
            {
                if (weizhi != value)
                {
                    weizhi = value;
                 }
            }

        }
     
        private int geshu = 0;
        public int GeShu
        {
            get { return geshu; }
            set
            {
                if (geshu != value)
                {
                    geshu = value;
                }
            }

        }
      
        public Form3(int _weizhi,int _geshu)
        {
            InitializeComponent();
            this.weizhi = _weizhi;
            this.geshu = _geshu;
            this.timer1.Enabled = true;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            lblWeizhi.Text = WeiZhi.ToString();
            label1.Text = " 此桶第" + geshu + "个小样";
        }
    }
}
