﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zhc.Data;
using Xg.Lab.Sample;
using VehIC_WF.Sampling.Sample.View;
using VehIC_WF.Sampling.czl.Class;
using VehIC_WF.Sampling.Sample;
using System.Media;
using DevExpress.XtraGrid.Views.Grid;

namespace VehIC_WF.Sampling.czl.WorkPoint
{
    public partial class WP_WKzupi : UserControl
    {
        public WP_WKzupi()
        {
            InitializeComponent();
        }
    
        DbEntityTable<QC_Sample_Veh> vehs = new DbEntityTable<QC_Sample_Veh>();
        DbEntityTable<QC_Sample_Mix> mixs = new DbEntityTable<QC_Sample_Mix>();
      
        private void WP_Kuaikuangqy_Load(object sender, EventArgs e)
        {
            vehs.LoadDataByWhere("main.WLLX='外矿' and main.SampleState=@SampleState", SampleState.初始状态);
            mixs.LoadDataByWhere("main.WLLX='外矿' and main.SampleState=@SampleState", SampleState.初始状态);
            this.qC_Sample_VehBindingSource.DataSource = vehs;
            this.qCSampleMixBindingSource.DataSource = mixs;
        }
private void timer1_Tick(object sender, EventArgs e)
{
    mixs.LoadDataByWhere("main.WLLX='外矿' and main.SampleState=@SampleState", SampleState.初始状态);
    vehs.LoadDataByWhere("main.WLLX='外矿' and main.SampleState=@SampleState", SampleState.初始状态);
  
    for (int j = 0; j < vehs.Count; j++)
    {
        if (vehs[j].Sample_Mix_ID == 0)
        {
            bool cunzai = false;
            for (int m = 0; m < mixs.Count; m++)
            {
                if (vehs[j].SupplierCode == mixs[m].SupplierCode && vehs[j].MatCode == mixs[m].MatCode && mixs[m].MixPlanCount > mixs[m].MixCount)
                {
                    cunzai = true;
                    vehs[j].Sample_Mix_ID = mixs[m].Sample_Mix_ID;
                    vehs[j].Save();
                    mixs[m].MixCount++;
                    mixs[m].Save();
                }

            }
            if (cunzai == false)
            {
                QC_Material matInfo = QC_Material.GetByID(vehs[j].MatPK);
                QC_Sample_Mix mix = new QC_Sample_Mix();

                mix.WpCode = "0090";
             
                mix.MatCode = vehs[j].MatCode;
                mix.MatPK = vehs[j].MatPK;
                mix.MixCount = 1;
                mix.MixPlanCount = matInfo.BatchNum;
                mix.SupplierCode = vehs[j].SupplierCode;
                mix.MixUser = LocalInfo.Current.user.ID;
                mix.SampleState = SampleState.初始状态;
                mix.SampleType = SampleType.普通样;
                mix.WLLX = vehs[j].WLLX;
                mix.CardID = "WK" + Zhc.Data.DbContext.GetSeq(DateTime.Now.Date.ToString("yyyyMMdd"), 2);
                mix.Save();
                mixs.Add(mix);

                vehs[j].Sample_Mix_ID = mix.Sample_Mix_ID;
                vehs[j].Save();

            }
        }
    }
}



private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
{
    QC_Sample_Mix mix = this.qCSampleMixBindingSource.Current as QC_Sample_Mix;
    if (mix == null)
   { MessageBox.Show("请选择任务单"); }
   else
    {
     
       string qydh = QC_Sample_Mix.ShortStoreCode(mix.CardID);
       string head = qydh;
       string body = mix.MatName;
       string body1 = mix.SupplierName;
       mix.WCDY = true;
       mix.Save();
       Rectangle rect = new Rectangle(9, 3, 112, 94);
       Font f1 = new System.Drawing.Font("宋体", 21, FontStyle.Bold);
       SizeF headSize = e.Graphics.MeasureString(head, f1);
       Font f2 = new System.Drawing.Font("宋体", 12f, FontStyle.Bold);
       SizeF bodySize = e.Graphics.MeasureString(body, f2);
       Font f3 = new System.Drawing.Font("宋体", 12f, FontStyle.Bold);
       SizeF body1Size = e.Graphics.MeasureString(body1, f2);

       float topMargin = rect.Top + (rect.Height - headSize.Height - bodySize.Height - body1Size.Height - 6) / 2;
       float leftMargin = rect.Left + (rect.Width - headSize.Width) / 2;

       e.Graphics.DrawString(head, f1, Brushes.Black, new PointF(leftMargin, topMargin));

       float topMargin2 = topMargin + Math.Max(headSize.Height + 3, 12);
       float leftMargin2 = rect.Left;
       e.Graphics.DrawString(body, f2, Brushes.Black, new PointF(leftMargin2, topMargin2));

       float topMargin3 = topMargin2 + Math.Max(bodySize.Height + 2, 12);
       float leftMargin3 = rect.Left;
       e.Graphics.DrawString(body1, f2, Brushes.Black, new PointF(leftMargin3, topMargin3));
   }
   
}

private void 打印任务单_Click(object sender, EventArgs e)
{
    this.printPreviewDialog1.ShowDialog();
}

private void 完成取样_Click(object sender, EventArgs e)
{
    foreach (var item in mixs)
    {
        if (item.WCQY == true)
        {
            DbEntityTable<QC_Sample_Veh> itemvehs = new DbEntityTable<QC_Sample_Veh>();
            itemvehs.LoadDataByWhere("main.Sample_Mix_ID=@Sample_Mix_ID",item.Sample_Mix_ID);
           
            item.Mix_Time = DateTime.Now;
            item.FangTong_Time = DateTime.Now;
            item.ShouTong_Time = DateTime.Now;
            item.ShouTong_User = LocalInfo.Current.user.ID;
            item.FangTong_User = LocalInfo.Current.user.ID;
            item.MixUser = LocalInfo.Current.user.ID;
            item.SampleState = SampleState.组批完成;
            item.Save();


            foreach (var it in itemvehs)
            {
                it.Mix_Time = DateTime.Now;
                it.SampleState = SampleState.组批完成;
                it.Save();
            }
        }
    }
    vehs.LoadDataByWhere("main.WLLX='外矿' and main.SampleState=@SampleState", SampleState.初始状态);
    mixs.LoadDataByWhere("main.WLLX='外矿' and main.SampleState=@SampleState", SampleState.初始状态);

}

private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
{
    //GridView view = (GridView)sender;
    //QC_Sample_Mix rowOb = view.GetRow(e.RowHandle) as QC_Sample_Mix;
    //if (rowOb != null && rowOb.WCDY)
    //{
    //    e.Appearance.BackColor = Color.Red;
    //}
}
}
}
