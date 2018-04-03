using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VehIC_WF.Sampling.rcw
{
    public partial class sampleNum : Form
    {
        public sampleNum()
        {
            InitializeComponent();
        }
        private string Type;

        public DialogResult showDialogEx(string type)
        {
            Type = type;
            return ShowDialog();
        }

        public int autoNum { get; set; }
        public int manuNum { get; set; }
        public int chouNum { get; set; }
        public long vehno { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            autoNum = 0;
            manuNum = 0;
            chouNum = 0;

            if (Type == "ChouQu")
            {
                groupBox1.Visible = true;
                groupBox3.Visible = false;
            }
            else
            {
                groupBox1.Visible = false;
                groupBox3.Visible = true;
            }

            refresh();
        }

        public void refresh()
        {
            textEdit2.Text = autoNum.ToString();
            textEdit1.Text = manuNum.ToString();
            textEdit3.Text = chouNum.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            manuNum++;
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            manuNum--;
            refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            autoNum++;
            refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            autoNum--;
            refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            chouNum++;
            refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            chouNum--;
            refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                vehno = Convert.ToInt64(textBox1.Text.Trim());
            }
            catch
            {
                MessageBox.Show("输入的车号不是有效的数字,请重新输入");
                textBox1.Text = "";
                return;
            }

        }
    }
}
