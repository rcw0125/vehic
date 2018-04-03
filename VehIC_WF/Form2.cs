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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void tabbedView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
        
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Sampling.UC_Zupi c1 = new Sampling.UC_Zupi();
            var doc = tabbedView1.AddDocument(c1);
            doc.ControlName = "doc1";
            doc.Caption = "组批";
            Sampling.UC_Zupi c2 = new Sampling.UC_Zupi();
            var doc2 = tabbedView1.AddDocument(c2);
            doc2.ControlName = "doc2";
            doc2.Caption = "组批";
            tabbedView1.ActivateDocument(c2);
          
        }
    }
}
