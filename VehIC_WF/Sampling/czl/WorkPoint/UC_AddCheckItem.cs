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
using VehIC_WF.Sampling.czl.Class;
namespace VehIC_WF.Sampling.czl
{
    public partial class UC_AddCheckItem : UserControl
    {
        private DbEntityTable<QC_Sample_Mix> mixSamples = new DbEntityTable<QC_Sample_Mix>();
        private QC_Sample_Mix GetCurData()
        {
            QC_Sample_Mix curData = qCSampleMixBindingSource.Current as QC_Sample_Mix;
            return curData;
        }
        public UC_AddCheckItem()
        {
            InitializeComponent();
            this.qCSampleMixBindingSource.DataSource = mixSamples;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool cunzai = false;
            QC_Sample_Mix curData = GetCurData();
            if (curData != null && textBox1.Text != null && textBox2.Text!= null)
            {
                QC_MixCheckItem a = new QC_MixCheckItem();
                a.CheckItemCode = textBox2.Text;
                a.CheckItemName = textBox1.Text;
                a.Sample_Mix_ID = curData.Sample_Mix_ID;
                a.Source = "特殊添加";
                a.CheckItemNcId = textBox3.Text;
                a.CheckItemUnit = textBox4.Text;

                foreach (var item in curData.AddCheckItems)
                {
                    if (item.CheckItemCode == textBox2.Text)
                        cunzai = true;
                }
                if (cunzai == true)
                {
                    MessageBox.Show("该检验项目已经存在");
                }
                else if (a.CheckItemCode != null && a.CheckItemCode != "" && a.CheckItemName != null && a.CheckItemName != "")
                {
                    curData.AddCheckItems.Add(a);
                    curData.AddCheckItems.Save();
                }
                textBox1.Text = null;
                textBox2.Text = null;
            }
        }

        private void UC_AddCheckItem_Load(object sender, EventArgs e)
        {
            mixSamples.LoadDataByWhere("main.SampleState=@SampleState", 2);
       
        }

        private void qCSampleMixBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            QC_Sample_Mix curData = GetCurData();
            curData.AddCheckItems.LoadDataByWhere("Sample_Mix_ID=@Sample_Mix_ID", curData.Sample_Mix_ID);
        }

        private void 添加检验项目_Click(object sender, EventArgs e)
        {
            AddCheckItem tj = new AddCheckItem();
            if (GetCurData() != null)
            { tj.MatNcId = GetCurData().MatPK; }
            if (tj.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = tj.SelectedCheckItem.CheckItemName;
                textBox2.Text = tj.SelectedCheckItem.CheckItemCode;
                textBox3.Text = tj.SelectedCheckItem.CheckItemNcId;
                textBox4.Text = tj.SelectedCheckItem.CheckItemUnit;
            }
        }
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            int hand = e.RowHandle;
            if (hand < 0) return;
            QC_Sample_Mix mix = (QC_Sample_Mix)gridView1.GetRow(hand);
            DbEntityTable<QC_Sample_Mix> mixs = new DbEntityTable<QC_Sample_Mix>();

            mixs.LoadDataByWhere("main.SupplierCode=@SupplierCode and Month(main.Mix_Time)=@Mix_Time and Year(main.Mix_Time)=@year and main.MatCode=@MatCode order by Mix_Time", mix.SupplierCode, mix.Mix_Time.Value.Month,mix.Mix_Time.Value.Year, mix.MatCode);
            if (mixs.Count > 0)
            {

                if (mix.Sample_Mix_ID == mixs[0].Sample_Mix_ID)
                {
                    e.Appearance.ForeColor = Color.Red;

                }

            }
        }

        private void 刷新_Click(object sender, EventArgs e)
        {
            mixSamples.LoadDataByWhere("SampleState=@SampleState",2);
        }

      
     
      

      
    }
}
