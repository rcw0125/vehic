using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xg.Lab.Sample;
using Zhc.Data;
using VehIC_WF.Sampling.Sample.View;
using VehIC_WF.Sampling.czl.Class;

namespace VehIC_WF.Sampling
{
    /// <summary>
    /// 掺校验样
    /// </summary>
    public partial class UC_VerifSample : UserControl, ICardMessage
    {
        private QC_Sample_Mix currentData = new QC_Sample_Mix();
        private QC_Sample_Mix_Table mixSamples = new QC_Sample_Mix_Table();

        public UC_VerifSample()
        {
            InitializeComponent();
            sourceAllVerifSamples.DataSource = mixSamples;
            this.sourceCurData.DataSource = currentData;
        }
      
        private void UC_VerifSample_Load(object sender, EventArgs e)
        {
            mixSamples.LoadVerifSamples();
        }

        /// <summary>
        /// 查询检验样
        /// </summary>
        private void tsmBtnVSLQuery_Click(object sender, EventArgs e)
        {
            DlgQueryVerifSample dlg = new DlgQueryVerifSample();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.WhereSql != "")
                {
                    mixSamples.LoadVerifSamples(dlg.WhereSql);
                }
            }
        }

        /// <summary>
        /// 查找留存样
        /// </summary>
        private void btnLoadVehData_Click(object sender, EventArgs e)
        {   
            QC_Sample_Mix sample =null;
            DbEntityTable<QC_MixCheckGroup> mixCgrp = new DbEntityTable<QC_MixCheckGroup>();
            mixCgrp.LoadDataByWhere("main.StoreCode=@StoreCode",txtStoreCode.Text.Trim());
            if (mixCgrp.Count > 0)
            {
                sample=QC_Sample_Mix.GetByID(mixCgrp[0].Sample_Mix_ID);
            }
            if (sample != null)
            {
                currentData.CopyData(sample);
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
                    QC_MixCheckItem sv = new QC_MixCheckItem();
                    sv.CheckItemNcId = dlg.SelectedCheckItem.CheckItemNcId;
                    sv.CheckItemCode = dlg.SelectedCheckItem.CheckItemCode;
                    sv.CheckItemName = dlg.SelectedCheckItem.CheckItemName;
                    sv.CheckItemUnit = dlg.SelectedCheckItem.CheckItemUnit;
                    sv.Source = "检验样";
                    currentData.CheckItems.Add(sv);
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
                    currentData.WpName = dlg.SelectedWorkPoint.WCName;
                    currentData.WpCode = dlg.SelectedWorkPoint.WCCode;
                    //txtBtnWp.EditValue = string.Format("({0}){1}", dlg.SelectedWorkPoint.WCBM, dlg.SelectedWorkPoint.WCName);
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
                    currentData.MatPK = dlg.SelectedMaterial.PK_INVBASDOC;
                    currentData.MatCode = dlg.SelectedMaterial.InvCode;
                    currentData.MatName = dlg.SelectedMaterial.InvName;

                    //txtBtnMaterial.EditValue = string.Format("({0}){1}", dlg.SelectedMaterial.InvCode, dlg.SelectedMaterial.InvName);
                }
            }
        }

        /// <summary>
        /// 更新校验样
        /// </summary>
        private void tsmBtnVSLUpdate_Click(object sender, EventArgs e)
        {
            QC_Sample_Mix sampleMix = this.sourceAllVerifSamples.Current as QC_Sample_Mix;
            if (sampleMix != null)
            {
                sampleMix.VehSamples.LoadDataBySampleMixId(sampleMix.Sample_Mix_ID);
                sampleMix.CheckItems.LoadDataBySampleMixId(sampleMix.Sample_Mix_ID);
                currentData.SaveEnable = false;
                currentData = sampleMix;
                this.sourceCurData.DataSource = currentData;
            }
            else
            {
                MessageBox.Show("没有选中的行");
            }

            //int[] selIds = this.gridView1.GetSelectedRows();
            //if (selIds.Length > 0)
            //{
            //    QC_Sample_Mix sampleMix = this.gridView1.GetRow(selIds[0]) as QC_Sample_Mix;
            //    if (sampleMix != null)
            //    {
            //        sampleMix.VehSamples.LoadDataBySampleMixId(sampleMix.Sample_Mix_ID);
            //        sampleMix.CheckItems.LoadDataBySampleMixId(sampleMix.Sample_Mix_ID);
            //        currentData.SaveEnable = false;
            //        currentData = sampleMix;  
            //        this.sourceCurData.DataSource = currentData;

            //    }
            //}
            //else
            //{
            //    MessageBox.Show("没有选中的行");
            //}
        }

        /// <summary>
        /// 删除校验样
        /// </summary>
        private void tsmBtnVSLDelete_Click(object sender, EventArgs e)
        {
            QC_Sample_Mix sampleMix = sourceAllVerifSamples.Current as QC_Sample_Mix;
            if (sampleMix != null)
            {
                if (MessageBox.Show("你确实要删除此数据吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    sampleMix.SaveVehSamples = true;
                    sampleMix.SaveCheckItems = true;
                    mixSamples.Remove(sampleMix);
                    mixSamples.Save();
                }
            }
            else
            {
                MessageBox.Show("没有选中的行");
            }

            //int[] selIds = this.gridView1.GetSelectedRows();
            //if (selIds.Length > 0)
            //{
            //    if (MessageBox.Show("你确实要删除此数据吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //    {
            //        QC_Sample_Mix sampleMix = this.gridView1.GetRow(selIds[0]) as QC_Sample_Mix;
            //        if (sampleMix != null)
            //        {
            //            sampleMix.SaveVehSamples = true;
            //            mixSamples.Remove(sampleMix);
            //            mixSamples.Save();
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("没有选中的行");
            //}
        }


        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentData.WpCode))
            {
                MessageBox.Show("作业点信息不能为空。");
                return;
            }
            if (string.IsNullOrEmpty(currentData.MatPK))
            {
                MessageBox.Show("物料信息不能为空。");
                return;
            }
            if (currentData.VehSamples.Count == 0)
            {
                MessageBox.Show("请先刷取样卡。");
                return;
            }

            currentData.SampleType = SampleType.校验样;

            currentData.ShouTong_User = LocalInfo.Current.user.ID;
            currentData.ShouTong_Time = DateTime.Now;
            currentData.MixPlanCount = currentData.VehSamples.Count;

            if (currentData.DataState == DataRowState.Added)
            {    
                currentData.SupplierCode = DbContext.GetSeq("校验样" + DateTime.Today.ToString("yyyyMMdd"), 2);
                currentData.MixUser = LocalInfo.Current.user.ID;
                currentData.Mix_Time = DateTime.Now;
                mixSamples.Insert(0, currentData);
            }

            currentData.SaveVehSamples = true;
            currentData.SaveCheckItems = true;
            currentData.Save();
            MessageBox.Show("保存成功");

        }

        /// <summary>
        /// 取消
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            currentData.CheckItems.RejectChanges();
            currentData.VehSamples.RejectChanges();
            currentData.RejectChanges();
        }

        /// <summary>
        /// 新建
        /// </summary>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            currentData = new QC_Sample_Mix();
            this.sourceCurData.DataSource = currentData;
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
            foreach (var item in currentData.VehSamples)
            {
                if (item.CardID == cardId)
                {
                    MessageBox.Show("此卡已关联" + item.TempID + "号");
                    return;
                }
            }
            QC_Sample_Veh vsam = new QC_Sample_Veh();
            vsam.CardID = cardId;
            vsam.TempID = currentData.VehSamples.Count + 1;
            vsam.FetchTime = DateTime.Now;
            vsam.IcInfo = card;
            vsam.SaveIcInfo = true;
            vsam.SampleType = SampleType.校验样;
            vsam.Sample_JY = true;
            currentData.VehSamples.Add(vsam);
        }

        private void 删除检验项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QC_MixCheckItem checkVal = checkValsBindingSource.Current as QC_MixCheckItem;
            if (checkVal != null)
            {
                //int[] selIds = this.gridView_CheckVal.GetSelectedRows();
                //if (selIds.Length > 0)
                //{
                if (MessageBox.Show("你确实要删除此数据吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //QC_Sample_Value checkVal = this.gridView_CheckVal.GetRow(selIds[0]) as QC_Sample_Value;
                    //if (checkVal != null)
                    //{
                    this.currentData.CheckItems.Remove(checkVal);
                    //}
                }
            }
            else
            {
                MessageBox.Show("没有选中的行");
            }
        }

        private void txtBtnWp_EditValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 删除刷卡
        /// </summary>
        private void tsmBtnDeleteCard_Click(object sender, EventArgs e)
        {
            int[] selIds = this.gvVehSamples.GetSelectedRows();
            if (selIds.Length > 0)
            {
                QC_Sample_Veh vehSample = this.gridView1.GetRow(selIds[0]) as QC_Sample_Veh;
                if (vehSample != null)
                {
                    currentData.VehSamples.Remove(vehSample);
                }
            }
            else
            {
                MessageBox.Show("没有选中的行");
            }
        }

        private void gridCtl_VerifSamplesList_Click(object sender, EventArgs e)
        {

        }


    }
}
