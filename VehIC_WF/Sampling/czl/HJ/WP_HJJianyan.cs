using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using VehIC_WF.Class;
using Zhc.Data;
using Xg.Lab.Sample;

using VehIC_WF.Sampling.czl.Class;
using Xg.Lab.Sample.View;

namespace VehIC_WF.WorkPoint
{
    public partial class WP_HJJianyan : UserControl, ICardMessage
    {
        private DbEntityTable<QC_Sample_Lab_Jy> lableiji = new DbEntityTable<QC_Sample_Lab_Jy>();
        private QC_Sample_Lab_Jy curLab = null;

        public WP_HJJianyan()
        {
            InitializeComponent();
        }

        private void WP_Jianyan_Load(object sender, EventArgs e)
        {
            lableiji.LoadInfo = "CheckVals";
            this.qCSampleLabBindingSource.DataSource = lableiji;
            lableiji.LoadDataByWhere("main.BillType=@BillType and main.WLLX='合金' order by main.JyTime desc", "开始检验");
            labTable1.LoadDataByWhere("main.labstate='合金' and main.checkgroupname like '化验样%' and  main.maketime>=@maketime and main.WLLX='合金'", DateTime.Today.AddDays(-1));
            //labTable2.LoadDataByWhere("labstate='送检' and checkgroupname like '角质层%' and  maketime>=@maketime", DateTime.Today.AddDays(-1));

            label2.Text = labTable1.Count.ToString();
          //  label4.Text = labTable2.Count.ToString();
        }
        DbEntityTable<QC_Sample_Lab> labTable1 = new DbEntityTable<QC_Sample_Lab>();
        DbEntityTable<QC_Sample_Lab> labTable2 = new DbEntityTable<QC_Sample_Lab>();
        public void HandleCardMessage(Device.CardReader device, string cardId)
        {

            QC_IC_Info icCard = QC_IC_Info.FindByCardId(cardId);
            if (icCard == null)
            {
                MessageBox.Show("此卡未注册");
                return;
            }
            if (!icCard.CardType.StartsWith("CUT_"))
            {
                MessageBox.Show("磁扣类型不对");
                return;
            }
            if (icCard.SampleId <= 0)
            {
                MessageBox.Show("此卡没有业务信息");
                return;
            }

            QC_Sample_Lab_Jy  tempLab=  QC_Sample_Lab_Jy.GetById(icCard.SampleId);
         
            if (tempLab==null) { MessageBox.Show("没有找到单据"); return; }

            if (tempLab.WLLX != "合金") { MessageBox.Show("此样品不是合金"); return; }
            tempLab.JyCode = DbContext.GetSeq("HY" + DateTime.Now.Date.ToString("yyyyMMdd"), 2);
            tempLab.Billtype = "开始检验";
            tempLab.LabState = "开始检验";
            tempLab.JyUser = LocalInfo.Current.user.ID;
            tempLab.JyTime = DateTime.Now;

            icCard.SampleId = 0;

            IDbConnection conn = DbContext.GetDefaultConnection();
            conn.Open();
            IDbTransaction trans = conn.BeginTransaction();
            icCard.Save(trans);
            tempLab.Save(trans);
            trans.Commit();
            conn.Close();

            this.curLab = QC_Sample_Lab_Jy.GetById(tempLab.Sample_Lab_ID);
            lableiji.Add(curLab);

            DbContext.ExeSql("insert into QC_LabLog(zycode,jycode,jytime) values('" + this.curLab.StoreCode + "','" + this.curLab.JyCode + "',getDate())");
            labTable1.LoadDataByWhere("labstate='送检' and checkgroupname like '化验样%' and  maketime>=@maketime and WLLX='合金'", DateTime.Today.AddDays(-1));
          //  labTable2.LoadDataByWhere("labstate='送检' and checkgroupname like '角质层%' and  maketime>=@maketime", DateTime.Today.AddDays(-1));
            label2.Text = labTable1.Count.ToString();
         //   label4.Text = labTable2.Count.ToString();
            SetGridViewFocuse();
            this.printDocument1.Print(); //自动打印
            //this.printPreviewDialog1.ShowDialog();
          
        }

        private void 打印检验单_Click(object sender, EventArgs e)
        {
            this.printPreviewDialog1.ShowDialog();
        }

        private void qCSampleLabBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            this.curLab = qCSampleLabBindingSource.Current as QC_Sample_Lab_Jy;
        }

        private int curPrintPage = 1;
      
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (this.curLab != null)
            {

                string head = QC_Sample_Mix.ShortStoreCode(this.curLab.JyCode);
              
                StringBuilder dyxm = new StringBuilder();
                foreach (var item in this.curLab.CheckVals)
                {
                    if (dyxm.Length > 0)
                        dyxm.Append(",");
                    dyxm.Append(item.CheckItemName);
                }
                dyxm.Append("("+this.curLab.MatName+")");

                Rectangle rect = new Rectangle(9, 3, 112, 94);
         
                Font f2 = new System.Drawing.Font("宋体", 10.5f);
                SizeF bodySize = e.Graphics.MeasureString(dyxm.ToString(), f2);

                List<string> temp = new List<string>();
 
                StringBuilder line = new StringBuilder();
                for (int i = 0; i < dyxm.Length; i++)
                {
                    if (line.Length < 10)
                    {
                        line.Append(dyxm[i]);
                    }
                    else
                    {
                        SizeF lineSize = e.Graphics.MeasureString(line.ToString(), f2);
                        if (lineSize.Width < rect.Width - 8)
                        {
                            line.Append(dyxm[i]);
                            continue;
                        }
                        temp.Add(line.ToString());
                        line = new StringBuilder();
                    }
                }
                if (line.Length > 0)
                {
                    temp.Add(line.ToString());
                }

                int totalPages=1;
                if (temp.Count > 3)
                {
                    totalPages = Convert.ToInt32(Math.Ceiling((temp.Count - 3) / 5.0)) + 1;
                }

                int printPage = totalPages - curPrintPage + 1;
                if (printPage <= 0)
                {
                    e.HasMorePages = false;
                    curPrintPage = 1;
                }
                else if (printPage == 1)
                {
                    Font f1 = new System.Drawing.Font("宋体", 20, FontStyle.Bold);
                    SizeF headSize = e.Graphics.MeasureString(head, f1);
                    float leftMargin = rect.Left + (rect.Width - headSize.Width) / 2;

                    float height = headSize.Height;

                    for (int i = 0; i < 3 && i < temp.Count; i++)
                    {
                        height += bodySize.Height + 2;
                    }

                    float topMargin = rect.Top + (rect.Height - height) / 2;

                    e.Graphics.DrawString(head, f1, Brushes.Black, new PointF(leftMargin, topMargin));
                    topMargin += headSize.Height;

                    int row = 0;
                    for (; row < 3 && row < temp.Count; row++)
                    {
                        e.Graphics.DrawString(temp[row], f2, Brushes.Black, new PointF(4, topMargin));
                        topMargin += bodySize.Height + 2;
                    }

                    e.HasMorePages = false;
                    curPrintPage = 1;

                }
                else
                {
                    int p = printPage;
                    int i = 3 + (p - 2) * 5;
                    int endi = i + 5;
                    int row = i;

                    float height = 0;

                    for (; i < endi && i < temp.Count; i++)
                    {
                        height += bodySize.Height + 2;
                    }

                    float topMargin = rect.Top + (rect.Height - height) / 2;

                    for (; row < endi && row < temp.Count; row++)
                    {
                        e.Graphics.DrawString(temp[row], f2, Brushes.Black, new PointF(4, topMargin));
                        topMargin += bodySize.Height + 2;
                    }

                    e.HasMorePages = true;
                    curPrintPage++;

                }
            }
        }

        private void 查询_Click(object sender, EventArgs e)
        {
            string storecode = textBox1.Text.Trim();
            if (!string.IsNullOrEmpty(storecode))
            {
                bool find = false;
                string jydh = QC_Sample_Mix.FullStoreCode(storecode);
                foreach (var item in this.lableiji)
                {
                    if (item.JyCode == jydh)
                    {
                        this.curLab = item;
                        find = true;
                        break;
                    }
                }
                if (find == false)
                {
                    MessageBox.Show("未查到数据");
                }
               // curLab.CheckVals.LoadDataByWhere("main.Sample_Lab_ID=@Sample_Lab_ID", curLab.Sample_Lab_ID);
                SetGridViewFocuse();
            }
        }

        private void SetGridViewFocuse()
        {
            if (this.curLab != null)
            {
                int idx = this.lableiji.IndexOf(this.curLab);
                if (idx >= 0)
                    this.gridView1.FocusedRowHandle = this.gridView1.GetRowHandle(idx);
            }
        }

        private void 保存_Click(object sender, EventArgs e)
        {
            bool keyitijiao = true;
            if (curLab != null)
            {
                curLab.SaveCheckVals = true;
                foreach (var item in curLab.CheckVals)
                {
                    if (item.CheckVal == null)
                    {
                        keyitijiao = false;
                        MessageBox.Show("请填完项目再提交");//20151225
                    }
                    else item.JianYan();
                }
                if (keyitijiao == true)
                {
                    curLab.Billtype = "检验完成";
                    curLab.LabState = "检验完成";
                    curLab.Save();
                    lableiji.LoadDataByWhere("main.BillType=@BillType order by JyTime desc", "开始检验");
                    MessageBox.Show("检验完成");
                }
            }
            else
            {
                MessageBox.Show("没有选中数据");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (curLab != null)
            {
                curLab.SaveCheckVals = true;
                foreach (var item in curLab.CheckVals)
                {
                    item.JianYan();
                }
                curLab.Save();
                MessageBox.Show("保存完成");

            }
            else
            {
                MessageBox.Show("没有选中数据");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lableiji.LoadDataByWhere("main.BillType=@BillType order by JyTime desc", "开始检验");
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lableiji.LoadInfo = "CheckVals";
            this.qCSampleLabBindingSource.DataSource = lableiji;
            lableiji.LoadDataByWhere("main.BillType=@BillType and main.WLLX='合金' order by JyTime desc", "开始检验");
            labTable1.LoadDataByWhere("main.labstate='送检' and main.checkgroupname like '化验样%' and  main.maketime>=@maketime and main.WLLX='合金'", DateTime.Today.AddDays(-1));
            //labTable2.LoadDataByWhere("labstate='送检' and checkgroupname like '角质层%' and  maketime>=@maketime", DateTime.Today.AddDays(-1));

            label2.Text = labTable1.Count.ToString();
        }

        
    }
}
    

