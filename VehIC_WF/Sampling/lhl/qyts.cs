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
    public partial class qyts: Form
    {
        private string leixing = "";
        public string LeiXing
        {
            get { return leixing; }
            set
            {
                if (leixing!= value)
                {
                    leixing = value;
                 }
            }

        }
      
        public qyts(string _lexing)
        {
            InitializeComponent();
            this.leixing = _lexing;
            this.timer1.Enabled = true;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
       
            label1.Text = leixing ;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
