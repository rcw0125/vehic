using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xg.Lab.Sample;
using Xg.Tools;

namespace VehIC_WF.Sampling
{
    public partial class DlgUpdateCheckVal : Form
    {
        private QC_Sample_Value curData = null;
        private string valType = "";

        public DlgUpdateCheckVal(QC_Sample_Value selData,string valType)
        {
            InitializeComponent();
            this.curData = selData;
            this.valType = valType;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (curData != null)
            {
                QC_Sample_Value_log log = new QC_Sample_Value_log();
                log.Sample_Value_Id = curData.Sample_Value_ID;
                log.ValType = this.valType;
                log.OldVal = curData.CheckVal;
                double? val = StringTool.FNumVal(txtNewVal.Text);
                log.NewVal =(val==null?"":val.ToString());
                log.Reason = txtReason.Text;
                log.Modifier = LocalInfo.Current.user.ID;
                log.ModifyTime = DateTime.Now;
                if (valType == "检验值")
                {
                    curData.CheckVal = log.NewVal;
                }
                else if (valType == "报检值")
                {
                    curData.ReportVal = log.NewVal;
                    curData.ActualVal = log.OldVal;
                }
                log.Save();
                curData.Save();
            }
            this.Close();
        }

        private void DlgUpdateCheckVal_Load(object sender, EventArgs e)
        {
            if (valType == "检验值")
            {
                this.Text = "修改检验值";
                lblOldVal.Text = "原检验值";
                lblNewVal.Text = "新检验值";
                txtOldVal.Text = curData.CheckVal;
              
            }
            else if (valType == "报检值")
            {
                this.Text = "修改报检值";
                lblOldVal.Text = "原报检值";
                lblNewVal.Text = "新报检值";
                txtOldVal.Text = curData.ReportVal;
            }
            txtCheckItemCode.Text = curData.CheckItemCode;
            txtCheckItemName.Text = curData.CheckItemName;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNewVal_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
             double? val = StringTool.FNumVal(txtNewVal.Text);
             e.Value = val;
        }
    }
}
