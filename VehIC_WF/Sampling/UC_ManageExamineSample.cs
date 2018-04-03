using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace VehIC_WF.Sampling
{
    public partial class UC_ManageExamineSample : DevExpress.XtraEditors.XtraUserControl, ICardMessage
    {
        public UC_ManageExamineSample()
        {
            InitializeComponent();
            this.uC_ExamineSample1.Cylx = "管理抽样";
        }

        private void uC_ExamineSample1_Load(object sender, EventArgs e)
        {

        }

        public void HandleCardMessage(Device.CardReader device, string cardId)
        {
            this.uC_ExamineSample1.HandleCardMessage(device, cardId);
        }
    }
}
