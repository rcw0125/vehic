using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zhc.Data;
using Xg.Lab.Sample;
using Xg.Lab.Sample.View;
using VehIC_WF.Sampling.Sample.View;

namespace VehIC_WF.Sampling
{
    public partial class UC_ICReg : UserControl, ICardMessage
    {
        public UC_ICReg()
        {
            InitializeComponent();
        }
         
        private  DbEntityTable<QC_IC_Info> icInfoDatas = new DbEntityTable<QC_IC_Info>();
        private DbEntityTable<QC_CardUseType> cardUseType = null;

        public void HandleCardMessage(Device.CardReader device, string cardId)
        {
            QC_IC_Info card = icInfoDatas.FirstOrDefault<QC_IC_Info>((ic) => (ic.CardID == cardId));
            if (card == null)
            {
                Tb_IC ic = Tb_IC.GetByICNo(cardId);
                if (ic != null)
                {
                    MessageBox.Show(string.Format("此卡为车辆卡,不能注册"));
                    return;
                }
                else
                {
                    txtCardId.Text = cardId;
                }
            }
            else
            {
                gridView_IC_Info.ActiveFilter.Clear();
                gridView_IC_Info.ActiveFilter.Add(gridView_IC_Info.Columns["CardID"], new DevExpress.XtraGrid.Columns.ColumnFilterInfo("[CardID]='" + cardId + "'"));
            }
        }

        /// <summary>
        /// 注册磁扣信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            string cardId = txtCardId.Text.Trim();
            QC_CardUseType useType= cmbCardType.SelectedItem as QC_CardUseType;
            if (useType == null)
            {
                MessageBox.Show("使用类型不能为空");
                return;
            }
            string cardType = useType.CUTCode;
            if (string.IsNullOrEmpty(cardId))
            {
                MessageBox.Show("卡号不能为空");
                return;
            }
            if (string.IsNullOrEmpty(cardType))
            {
                MessageBox.Show("使用类型不能为空");
                return;
            }

            QC_IC_Info card = QC_IC_Info.FindByCardId(txtCardId.Text.Trim());
            if (card != null)
            {
                MessageBox.Show(string.Format("卡号{0}已经注册，不能重复注册。", cardId));
                return;
            }

            QC_IC_Info icCard = new QC_IC_Info();
            icCard.CardID = cardId;
            icCard.CardType = cardType;
            icCard.RegUser = FrmMain.localinfo.user.Name;
            icCard.RegTime = DateTime.Now;
            icCard.Save();

            icInfoDatas.Insert(0, icCard);
            txtCardId.Text = "";
            //if (this.cmbCardType.Properties.Items.Count > 0)
            //{
            //    cmbCardType.SelectedIndex = 0;
            //}
           // MessageBox.Show("注册完成");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            cardUseType = QC_CardUseType.LoadCardUseType();
            this.cmbCardType.Properties.Items.Clear();
            foreach (var item in cardUseType)
            {
                this.cmbCardType.Properties.Items.Add(item);
            }

            this.cmbCardType.SelectedIndex = 0;
            //reposCardUseType.DataSource = cardUseType;
            this.repositoryItemGridLookUpEdit1.DataSource = cardUseType;
            icInfoDatas.LoadData();
        }

        private void UC_ICReg_Load(object sender, EventArgs e)
        {
            cardUseType = QC_CardUseType.LoadCardUseType();
            this.cmbCardType.Properties.Items.Clear();
            foreach (var item in cardUseType)
            {
                this.cmbCardType.Properties.Items.Add(item);
            }

            this.cmbCardType.SelectedIndex = 0;
            //reposCardUseType.DataSource = cardUseType;
            this.repositoryItemGridLookUpEdit1.DataSource = cardUseType;

            this.gridCtl_IC_Info.DataSource = icInfoDatas;
            icInfoDatas.LoadData();



            foreach (var useType in cardUseType)
            {
                ToolStripMenuItem tsmBtnItem = new ToolStripMenuItem();
                tsmBtnItem.Name = useType.CUTCode;
                tsmBtnItem.Size = new Size(0x98, 0x16);
                tsmBtnItem.Text = useType.CUTName;
                tsmBtnItem.Tag = useType;

                this.tsmBtnGroup_UseType.DropDownItems.Add(tsmBtnItem);
                tsmBtnItem.Click += new EventHandler(tsmBtn_ChgUseType_Click);
            }
        }
        
        /// <summary>
        /// 解除单据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmBtn_UnbindBill_Click(object sender, EventArgs e)
        {
            QC_IC_Info bill = getSelectedBill();
            if (bill == null)
            {
                MessageBox.Show("没有选定数据");
                return;
            }
            if (bill.SampleId < 1)
            {
                MessageBox.Show("没有单据需要解除绑定");
                return;
            }
            if (MessageBox.Show("您确实要解除绑定吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                bill.SampleId = 0;
                bill.Save();
                MessageBox.Show("解除绑定完成");
            }
        }

        public QC_IC_Info getSelectedBill()
        {
            int[] selIds = this.gridView_IC_Info.GetSelectedRows();
            if (selIds == null || selIds.Length < 1)
            {
                return null;
            }
            int selId = selIds[0];
            QC_IC_Info result = this.gridView_IC_Info.GetRow(selId) as QC_IC_Info;
            return result;

        }
        /// <summary>
        /// 删除磁扣信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmBtn_DeleteCard_Click(object sender, EventArgs e)
        {
            QC_IC_Info bill = getSelectedBill();
            if (bill == null)
            {
                MessageBox.Show("没有选定数据");
                return;
            }
            if (bill.SampleId > 0)
            {
                MessageBox.Show("磁扣已经绑定数据，需要先解除绑定，才能删除。");
                return;
            }
            if (MessageBox.Show("您确实要删除数据吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                icInfoDatas.Remove(bill);
                icInfoDatas.Save();
                MessageBox.Show("删除数据完成");
            }
        }

        /// <summary>
        /// 修改使用类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmBtn_ChgUseType_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsm = sender as ToolStripMenuItem;
            
            QC_IC_Info bill = getSelectedBill();
            if (bill == null)
            {
                MessageBox.Show("没有选定数据");
                return;
            }

            if (bill.SampleId > 0)
            {
                MessageBox.Show("磁扣已经绑定数据，需要先解除绑定，才能更改使用类型。");
                return;
            }
            if (MessageBox.Show("您确实要更改使用类型吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                bill.CardType = tsm.Name;
                icInfoDatas.Save();
                tsm.Enabled = false;
                MessageBox.Show("使用类型已修改。");
            }
        }

        private void gridView_IC_Info_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            QC_IC_Info bill = getSelectedBill();
            if (bill != null)
            {
                foreach (var item in  this.tsmBtnGroup_UseType.DropDownItems)
                {
                    ToolStripMenuItem tsm = item as ToolStripMenuItem;
                    if (tsm != null)
                    {
                        if (tsm.Name == bill.CardType)
                        {
                            tsm.Enabled = false;
                        }
                        else
                        {
                            tsm.Enabled = true;
                        }
                    }
                }
            }
        }

        private void gridCtl_IC_Info_Click(object sender, EventArgs e)
        {

        }

        private void gridView_IC_Info_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    
    }
}
