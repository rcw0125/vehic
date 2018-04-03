using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xg.Lab.Sample;
using VehIC_WF.Sampling.Sample.View;
using VehIC_WF.Sampling.czl.Class;
using Zhc.Data;
using System.Text.RegularExpressions;

namespace VehIC_WF.Sampling
{
    public partial class UC_VerifSam : UserControl,ICardMessage
    {

        private QC_Sample_Veh curData = new QC_Sample_Veh();
        private QC_Sample_Veh_Table curTable = new QC_Sample_Veh_Table();

        public UC_VerifSam()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(curData.WpCode))
            {
                MessageBox.Show("作业点信息不能为空。");
                return;
            }
            if (string.IsNullOrEmpty(curData.MatPK))
            {
                MessageBox.Show("物料信息不能为空。");
                return;
            }
            if (string.IsNullOrEmpty(curData.CardID))
            {
                MessageBox.Show("请先刷取样卡。");
                return;
            }

            curData.SampleType = SampleType.校验样;
            curData.SAMPLE_TBZD = true;
            curData.Sample_JY = true;
            curData.FetchPerson = LocalInfo.Current.user.ID;
            curData.FetchTime = DateTime.Now;

            if (curData.DataState == DataRowState.Added)
            {
                curData.SupplierCode = DbContext.GetSeq("校验样" + DateTime.Today.ToString("yyyyMMdd"), 2);
                curTable.Insert(0, curData);
            }

            curData.SaveIcInfo = true;
            curData.SaveCheckItems = true;
            curData.Save();
            btnUnBindCard.Visible = false;
            CreateSampleVeh();
            txtStoreCode.Text = "";
            MessageBox.Show("保存成功");
        }

        /// <summary>
        /// 处理读卡
        /// </summary>
        public void HandleCardMessage(Device.CardReader device, string cardId)
        {
            QC_IC_Info card = QC_IC_Info.FindByCardId(cardId);
            if (card == null)
            {
                Tb_IC ic = Tb_IC.GetByICNo(cardId);
                if (ic != null)
                {
                    MessageBox.Show(string.Format("此卡为车辆卡"));
                    return;
                }
                else
                {
                    MessageBox.Show(string.Format("此卡没有注册"));
                    return;
                }
            }
            if (card.CardType != QC_IC_Info.CardUseType_Veh)
            {
                MessageBox.Show("卡的类型不对");
                return;
            }

            if (card.SampleId > 0)
            {
                MessageBox.Show("此卡正在使用");
                return;
            }

            if (!string.IsNullOrEmpty(curData.CardID))
            {
                MessageBox.Show("已经绑定磁卡");
                return;
            }

            curData.CardID = cardId;
            curData.FetchTime = DateTime.Now;
            curData.IcInfo = card;
            btnUnBindCard.Visible = true;

        }

        /// <summary>
        /// 查找留存样
        /// </summary>
        private void btnLoadVehData_Click(object sender, EventArgs e)
        {
            string code = txtStoreCode.Text.Trim();
            if (string.IsNullOrEmpty(code))
            {
                MessageBox.Show("不能为空");
                return;
            }

            string dh = QC_Sample_Mix.GetZyDanHao(code);

            if (dh == "")
            {
                MessageBox.Show("对不起，不认识您录入的字符串格式");
                return;
            }

            QC_Sample_Mix sample = QC_Sample_Mix.GetByZydh(dh);

            if (sample != null)
            {
                curData.CopyData(sample);
            }
            else
            {
                MessageBox.Show("没有找到");
            }
        }

        /// <summary>
        /// 添加检验项目
        /// </summary>
        private void tsmBtnAddCheckItem_Click(object sender, EventArgs e)
        {
            DlgCheckItem dlg = new DlgCheckItem();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.SelectedCheckItem != null)
                {
                    var ck = from c in curData.CheckItems
                             where c.CheckItemCode == dlg.SelectedCheckItem.CheckItemNcId
                             select c;
                    if (ck.Count<QC_MixCheckItem>() > 0)
                    {
                        MessageBox.Show("已有此检验项目");
                        return;
                    }

                    QC_MixCheckItem sv = new QC_MixCheckItem();
                    sv.CheckItemNcId = dlg.SelectedCheckItem.CheckItemNcId;
                    sv.CheckItemCode = dlg.SelectedCheckItem.CheckItemCode;
                    sv.CheckItemName = dlg.SelectedCheckItem.CheckItemName;
                    sv.CheckItemUnit = dlg.SelectedCheckItem.CheckItemUnit;
                    sv.Source = "检验样";
                    curData.CheckItems.Add(sv);
                }
            }
        }

        /// <summary>
        /// 作业点选择
        /// </summary>
        private void txtBtnWp_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DlgWorkPoint dlg = new DlgWorkPoint();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.SelectedWorkPoint != null)
                {
                    curData.WpCode = dlg.SelectedWorkPoint.WCCode;
                    curData.WpName = dlg.SelectedWorkPoint.WCName;
                }
            }
        }

        /// <summary>
        /// 物料选择
        /// </summary>
        private void txtBtnMaterial_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DlgMaterial dlg = new DlgMaterial();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.SelectedMaterial != null)
                {
                    curData.MatPK = dlg.SelectedMaterial.PK_INVBASDOC;
                    curData.MatCode = dlg.SelectedMaterial.InvCode;
                    curData.MatName = dlg.SelectedMaterial.InvName;
                }
            }
        }

        private void 删除检验项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("你确实要删除此数据吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //{
                checkItemsBindingSource.RemoveCurrent();
            //}
            //QC_MixCheckItem checkItem = curDataSource.Current as QC_MixCheckItem;
            //if (checkItem != null)
            //{
            //    allCheckItem.Add(checkItem);
            //    curData.CheckItems.Remove(checkItem);
            //}
        }

        private void UC_VerifSam_Load(object sender, EventArgs e)
        {
            curTable.LoadVerifSamples();
            this.curDataSource.DataSource = curData;
            this.curTableSource.DataSource = curTable;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (curData.DataState == DataRowState.Added)
            {
                CreateSampleVeh();
            }
            else
            {
                curData.RejectChanges();
            }
        }

        private void tsmBtnVSLDelete_Click(object sender, EventArgs e)
        {
            QC_Sample_Veh veh = curTableSource.Current as QC_Sample_Veh;
            if (veh != null)
            {
                int sampleState = Convert.ToInt32(DbContext.ExecuteScalar("Select SampleState From QC_Sample_Veh where Sample_Veh_ID=" + veh.Sample_Veh_ID));
                if (sampleState > 0)
                {
                    MessageBox.Show("已经组批不能再删除");
                    return;
                }
                if (MessageBox.Show("你确实要删除此数据吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (veh == curData)
                    {
                        CreateSampleVeh();
                    }
                    veh.SaveIcInfo = true;
                    veh.SaveCheckItems = true;
                    curTableSource.RemoveCurrent();
                    curTable.Save();
                }
            }
        }

        private void btnUnBindCard_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.curData.CardID))
            {
                this.curData.CardID = "";
                this.curData.FetchTime = null;
                this.curData.IcInfo = null;
                btnUnBindCard.Visible = false;
            }
        }

        private void tsmBtnVSLUpdate_Click(object sender, EventArgs e)
        {
            QC_Sample_Veh veh = curTableSource.Current as QC_Sample_Veh;
            if (veh != null)
            {
                veh.CheckItems.LoadDataBySampleVehId(veh.Sample_Veh_ID);
                veh.SaveEnable = false;
                curData = veh;
                this.curDataSource.DataSource = curData; 
                btnUnBindCard.Visible = false;
            }
            else
            {
                MessageBox.Show("没有选中的行");
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateSampleVeh();
        }

        private void CreateSampleVeh()
        {
            curData = new QC_Sample_Veh();
            this.curDataSource.DataSource = curData;
            btnUnBindCard.Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            curTable.LoadVerifSamples();
        }

    }
}
