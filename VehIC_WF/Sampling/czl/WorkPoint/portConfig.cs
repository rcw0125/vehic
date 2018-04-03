using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VehIC_WF.Sampling.czl.WorkPoint
{
    public partial class portConfig : Form
    {
        public portConfig()
        {
            InitializeComponent();
        }

       public  string PortName, BaudRate, DataBits, Parity, StopBits;

        private void button1_Click(object sender, EventArgs e)
        {
            PortName = comboBox1.Text;
            BaudRate = cmb_btl.Text;
            DataBits = cbm_data.Text;
            Parity = cbm_jo.Text;
            StopBits = cmb_stop.Text;
            DialogResult = DialogResult.OK;
            this.Close();
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void portConfig_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "COM1";
            cmb_btl.Text = "9600";
            cbm_data.Text = "8";
            cbm_jo.Text = "None";
            cmb_stop.Text = "One";
        }
    }
}
