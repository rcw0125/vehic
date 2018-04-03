using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xg.Lab.Sample;
using VehIC_WF.Sampling.czl.Class;
using VehIC_WF.Sampling.Sample.View;
using Zhc.Data;
using VehIC_WF.Sampling.Sample;

namespace VehIC_WF.Sampling
{
    public partial class UC_ReCheck : UserControl,ICardMessage
    {
        private QC_Sample_Mix curData = new QC_Sample_Mix();
        private QC_Sample_Mix_Table Samples = new QC_Sample_Mix_Table();
        private DbEntityTable<QC_MixCheckGroup> mixgroups = new DbEntityTable<QC_MixCheckGroup>();
        public UC_ReCheck()
        {
            InitializeComponent();
        }

        private void btnLoadVehData_Click(object sender, EventArgs e)
        {
            string code = txtStoreCode.Text.Trim();
            if (string.IsNullOrEmpty(code))
            {
                MessageBox.Show("不能为空");
                return;
            }

            string dh = QC_Sample_Mix.GetZyDanHao(code);
           
            if (dh != "")
            {   Samples.LoadDataByWhere("main.ZyDanHao=@ZyDanHao", dh);
                mixgroups.LoadDataByWhere("main.Sample_mix_id=@Sample_mix_id and main.checkgroupname='角质层Y'", Samples[0].Sample_Mix_ID);
                if (mixgroups.Count > 0)
                {
                    int labid = mixgroups[0].Sample_Lab_ID;
                    mixgroups.LoadDataByWhere("main.Sample_lab_id=@Sample_lab_id and main.checkgroupname='角质层Y'", labid);
                    this.qCMixCheckGroupBindingSource.DataSource = mixgroups;
                }



                DbEntityTable<QC_Sample_Mix> curDatalist = new DbEntityTable<QC_Sample_Mix>();
                curDatalist.LoadDataByWhere("parent.ZyDanHao=@MainSampleZyDanHao and main.Sampletype=@Sampletype", dh, SampleType.复检样);
          
                if (curDatalist.Count>0) 
                 this.curData = curDatalist[0];
                this.curData.CheckItems.LoadDataBySampleMixId(this.curData.Sample_Mix_ID);
                this.sourceCurData.DataSource = curData;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(this.curData.CardID))
            {
                MessageBox.Show("还没有刷卡。");
                return;
            }         
            this.curData.Save();

            fjdhs1.LoadDataByWhere("fjdh=@fjdh and wc='否'", QC_Sample_Mix.GetZyDanHao(txtStoreCode.Text.Trim()));
            fjdhs1[0].wc = "是";
            fjdhs1.Save();
            fjdhs.LoadDataByWhere("wc=@wc", "否");
            btnUnBindCard.Visible = false;

            

            MessageBox.Show("保存完成");
        }


        DbEntityTable<QC_Xyfjdh> fjdhs = new DbEntityTable<QC_Xyfjdh>();
        DbEntityTable<QC_Xyfjdh> fjdhs1 = new DbEntityTable<QC_Xyfjdh>();
       
     

        /// <summary>
        /// 扫卡
        /// </summary>
        public void HandleCardMessage(Device.CardReader device, string cardId)
        {
            if (curData.MainSampleMixId == 0)
            {
                MessageBox.Show(string.Format("请先获取留存样"));
                return;
            }

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
            if (card.CardType != QC_IC_Info.CardUseType_Mix)
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
                MessageBox.Show("已关联磁卡");
                return;
            }
            curData.FangTong_User = LocalInfo.Current.user.ID;
            curData.FangTong_Time = DateTime.Now;
            curData.CardID = cardId;
            curData.SaveIcInfo = true;
            curData.IcInfo = card;
         //   btnUnBindCard.Visible = true;
        }

        ///// <summary>
        ///// 解除磁卡绑定
        ///// </summary>
        //private void btnUnBindCard_Click(object sender, EventArgs e)
        //{
        //    curData.FangTong_User = "";
        //    curData.FangTong_Time = null;
        //    curData.CardID = "";
        //    if (curData.IcInfo != null)
        //    {
        //        curData.IcInfo.SampleId = 0;
        //    }
        //    btnUnBindCard.Visible = false;
        //}

        //private void 添加检验项目ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (this.curData != null)
        //    {
        //        List<string> filterIds = new List<string>();
        //        foreach (var item in curData.CheckItems)
        //        {
        //            filterIds.Add(item.CheckItemNcId);
        //        }
        //        DlgCheckItem dlg = null;
        //        if (string.IsNullOrEmpty(this.curData.MatPK))
        //            dlg = new DlgCheckItem(filterIds);
        //        else
        //            dlg = new DlgCheckItem(filterIds, this.curData.MatPK);
        //        if (dlg.ShowDialog() == DialogResult.OK)
        //        {
        //            if (dlg.SelectedCheckItem != null)
        //            {
        //                QC_MixCheckItem qrc = new QC_MixCheckItem();
        //                qrc.CheckItemNcId = dlg.SelectedCheckItem.CheckItemNcId;
        //                qrc.CheckItemCode = dlg.SelectedCheckItem.CheckItemCode;
        //                qrc.CheckItemName = dlg.SelectedCheckItem.CheckItemName;
        //                qrc.CheckItemUnit = dlg.SelectedCheckItem.CheckItemUnit;
        //                qrc.CheckGroupCode = dlg.SelectedCheckItem.CheckGroupCode;
        //                qrc.SetDataStateAsAdded();
        //                this.curData.CheckItems.Add(qrc);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("没有选中数据", "提示");
        //    }
        //}

        //private void 删除检验项目ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    QC_MixCheckItem selData = this.checkItemsBindingSource.Current as QC_MixCheckItem;
        //    if (selData != null)
        //    {
        //        if (MessageBox.Show("确实要删除吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
        //        {
        //            this.checkItemsBindingSource.RemoveCurrent();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("没有选中数据", "提示");
        //    }
        //}

     

        private void UC_ReCheck_Load(object sender, EventArgs e)
        {
            
            this.sourceCurData.DataSource = curData;
          this.qCXyfjdhBindingSource.DataSource = fjdhs;
          fjdhs.LoadDataByWhere("wc=@wc", "否");
        }

        private void 刷新_Click(object sender, EventArgs e)
        {
            fjdhs.LoadDataByWhere("wc=@wc", "否");
        }

     

       

      
    }
}
