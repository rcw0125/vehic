using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using DevExpress.XtraGrid.Views.Base;

namespace VehIC_WF.Sampling
{
    public partial class UC_Zupi : UserControl, ICardMessage
    {
        public UC_Zupi()
        {
            InitializeComponent();
        }

        public void HandleCardMessage(Device.CardReader device, string cardId)
        {
            this.label1.Text = cardId;
        }

        private void UC_Zupi_Load(object sender, EventArgs e)
        {
           
            Nc.ufinterface uf = new Nc.ufinterface();
            string xml=  Nc.TelComm.Serialize<Nc.ufinterface>(uf);
            memoEdit1.Text = xml;
     

            //IDbConnection conn = Zhc.Data.DbContext.GetDefaultConnection();
            //conn.Open();
            //IDbTransaction trans = conn.BeginTransaction();
            //Zhc.Data.DbContext.ExeSql(trans, "insert into QC_Sample_Mix(WpCode) values(@WpCode)", "123");
            //trans.Commit();
            //conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
