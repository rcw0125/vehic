using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VehIC_WF.Sampling.czl.Class;
using VehIC_WF.Sampling.Sample;
using Xg.Lab.Sample;

namespace VehIC_WF.Sampling
{
    public partial class ReCheck : Form
    {  
        public string zyzydh = "";
        public ReCheck(string zydh)
        {
            zyzydh = zydh;
            InitializeComponent();
        }

        private void 删除检验项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QC_MixCheckItem selData = this.checkItemsBindingSource.Current as QC_MixCheckItem;
            if (selData != null)
            {
                if (MessageBox.Show("确实要删除吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.checkItemsBindingSource.RemoveCurrent();
                }
            }
            else
            {
                MessageBox.Show("没有选中数据", "提示");
            }
        }

        private void 确定_Click(object sender, EventArgs e)
        {
            if (this.curData != null)
            {
                QC_Xyfjdh fjdh = new QC_Xyfjdh();
                fjdh.fjdh = zyzydh;
                fjdh.wc = "否";
                fjdh.Save();
                curData.Fjdyr = LocalInfo.Current.user.Name;
                this.curData.SampleType = SampleType.复检样;
                this.curData.MixCount = 1;
                this.curData.MixPlanCount = 1;

                this.curData.SampleState = SampleState.组批完成;
                this.curData.Sample_TBZD = true;
               
                this.curData.ShouTong_User = LocalInfo.Current.user.ID;
                this.curData.ShouTong_Time = DateTime.Now;

                this.curData.MixUser = LocalInfo.Current.user.ID;
                this.curData.Mix_Time = DateTime.Now;

                this.curData.SaveCheckItems = true;

                this.curData.Save();
                MessageBox.Show("复检信息生成成功");
                this.Close();
            }
        }

        private void 取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private QC_Sample_Mix curData = new QC_Sample_Mix();
        private void ReCheck_Load(object sender, EventArgs e)
        {
            this.sourceCurData.DataSource = curData;
            label2.Text = zyzydh;
            if (zyzydh != "")
            {
                QC_Sample_Mix sample = QC_Sample_Mix.GetByZydh(zyzydh);

                if (sample != null)
                {
                    if (curData.CheckItems.Count == 0)
                        curData.CopyData(sample);
                   
                    curData.SupplierCode = sample.SupplierCode;
                    curData.SupplierName = sample.SupplierName;
                    curData.SampleType = SampleType.复检样;
                    curData.SampleState = SampleState.组批完成;
                    curData.WLLX = sample.WLLX;
                }
            }

        }
    }
}
