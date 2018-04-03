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
using System.Data.OleDb;
using VehIC_WF.Device;
using VehIC_WF.Sampling.Sample;

namespace VehIC_WF.WorkPoint
{
    public partial class WP_Shangchuan : UserControl
    {
      
        public WP_Shangchuan()
        {
            InitializeComponent();
        }

        private void WP_Jianyan_Load(object sender, EventArgs e)
        {
          //  this.gridView1.OptionsView.ColumnAutoWidth = false;
            test.LoadDataByWhere("shangchuan=0 and JYShebei='" + DeviceConfigManager.Instance.config.Jysb + "' and Date>'" + DateTime.Now.AddHours(-24).ToString("yyyy-MM-dd HH:mm:ss") + "' order by CheckItemCode asc,date desc");
         
            this.gridControl1.DataSource = test;
       //     this.gridView1.OptionsView.ColumnAutoWidth=true;
        }
        DbEntityTable<QC_Sample_Jyjg> test = new DbEntityTable<QC_Sample_Jyjg>();

        private void 采集_Click(object sender, EventArgs e)
        {

            object JQCode = DbContext.ExecuteScalar("select max(JQCode) from QC_Sample_Jyjg where JYShebei='" + DeviceConfigManager.Instance.config.Jysb.ToString() + "'");
           // object time = DbContext.ExecuteScalar("select max(date) from QC_Sample_Jyjg where JYShebei='" + DeviceConfigManager.Instance.config.Jysb.ToString() + "'");
            // 
             string str;
             if (DeviceConfigManager.Instance.config.Jysbsjk.EndsWith("AutoMac.mdb"))
             {
                 if (!(JQCode is DBNull))
                 {
                     str = "SELECT * FROM testresult where SerialNumber>'" + Convert.ToString(JQCode) + "'";

                 }
                 else
                 {
                     str = "SELECT * FROM testresult where date>#" + DateTime.Now.AddHours(-24).ToString() + "#";
                 }
             }
             else
             {
                 if (!(JQCode is DBNull))
                 {
                     str = "SELECT * FROM SDS212 where AutoNmb>'" + Convert.ToString(JQCode)+"'";

                 }
                 else
                 {
                     str = "SELECT * FROM SDS212 where testdate>#" + DateTime.Now.AddHours(-48).ToString() + "#";
                 }
             }

             string password = "";
             if (DeviceConfigManager.Instance.config.Jysbsjk.EndsWith("AutoMac.mdb"))
             {
                 password = "CSKY";
             }
             else
             {
                 password = "service";            
             }
             OleDbConnection cn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + DeviceConfigManager.Instance.config.Jysbsjk + ";Jet OLEDB:Database Password=" + password + ";Persist Security Info=False");
            cn.Open();
          
               OleDbCommand comm = new OleDbCommand(str, cn);
               OleDbDataReader dr = comm.ExecuteReader();
          
            //  test.Clear();

               bool tuichu = true;
               int i = 0;
               foreach (var item in System.Diagnostics.Process.GetProcesses())
               {
                   if (item.ProcessName.StartsWith("AutoMac"))
                   {
                       tuichu = false;
                       MessageBox.Show("请先退出工业分析仪程序");
                       return;

                   } else if (item.ProcessName.StartsWith("SDS"))
                   {
                       tuichu = false;
                       MessageBox.Show("请先退出硫分仪程序");
                       return;
                   }

               }
               if (tuichu)
               {
                   while (dr.Read())
                   {

                       if (DeviceConfigManager.Instance.config.Jysbsjk.EndsWith("AutoMac.mdb"))
                       {
                           QC_Sample_Jyjg t = new QC_Sample_Jyjg();
                           t.CheckItemCode = "10011";
                           t.CheckItemName = "灰分";
                           t.JQCode = dr["SerialNumber"].ToString();
                           t.Date = Convert.ToDateTime(dr["Date"]).ToString("yyyy-MM-dd HH:mm:ss");
                           t.JYShebei = DeviceConfigManager.Instance.config.Jysb;
                           t.SampleName = dr["SampleName"].ToString();
                           t.Value = dr["Ad"].ToString();

                           QC_Sample_Jyjg t1 = new QC_Sample_Jyjg();
                           t1.CheckItemCode = "10012";
                           t1.CheckItemName = "挥发分";
                           t1.JQCode = dr["SerialNumber"].ToString();
                           t1.Date = Convert.ToDateTime(dr["Date"]).ToString("yyyy-MM-dd HH:mm:ss");
                           t1.JYShebei = DeviceConfigManager.Instance.config.Jysb;
                           t1.SampleName = dr["SampleName"].ToString();
                           t1.Value = Convert.ToDecimal(dr["Vdaf"]).ToString("0.0");

                           QC_Sample_Jyjg t2 = new QC_Sample_Jyjg();
                           t2.CheckItemCode = "10016";
                           t2.CheckItemName = "固定碳";
                           t2.JQCode = dr["SerialNumber"].ToString();
                           t2.Date = Convert.ToDateTime(dr["Date"]).ToString("yyyy-MM-dd HH:mm:ss");
                           t2.JYShebei = DeviceConfigManager.Instance.config.Jysb;
                           t2.SampleName = dr["SampleName"].ToString();
                           t2.Value = dr["Fcad"].ToString();
                           test.Add(t);
                           test.Add(t1);
                           test.Add(t2);
                           i += 3;
                       }
                       else
                       {
                          
                           QC_Sample_Jyjg t = new QC_Sample_Jyjg();
                           t.CheckItemCode = "10002";
                           t.CheckItemName = "S";
                           t.JQCode = dr["AutoNmb"].ToString();
                           t.Date = Convert.ToDateTime(dr["TestDate"]).ToString("yyyy-MM-dd") + " " + Convert.ToDateTime(dr["TestTime"]).ToString("HH:mm:ss");
                           t.JYShebei = DeviceConfigManager.Instance.config.Jysb;
                           t.SampleName = dr["Name"].ToString();
                           t.Value = dr["Stad"].ToString();
                           test.Add(t);
                           i++;
                       }
                   }
               }
            test.Save();
            cn.Close();
            test.LoadDataByWhere("shangchuan=0 and JYShebei='"+ DeviceConfigManager.Instance.config.Jysb+"' and Date>'" + DateTime.Now.AddHours(-24).ToString("yyyy-MM-dd HH:mm:ss") + "' order by CheckItemCode asc,date desc");
            MessageBox.Show(i.ToString()+"条数据采集完成");
           this.gridControl1.DataSource = test;
        }
        private DbEntityTable<QC_Sample_Lab_Jy> hyy = new DbEntityTable<QC_Sample_Lab_Jy>();
        private DbEntityTable<QC_Sample_Value> vals = new DbEntityTable<QC_Sample_Value>();
        private void 上传_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var item in test)
            {
                
                if (item.Shangchuan)

                {
                    hyy.LoadDataByWhere("JyCode=@JyCode",QC_Sample_Mix.FullStoreCode(item.SampleName));
                    if (hyy.Count > 0)
                    { vals.LoadDataByWhere("main.Sample_Lab_ID=@Sample_Lab_ID", hyy[0].Sample_Lab_ID); }
                    else
                    {
                        vals.Clear();
                    }

                    if (vals.Count > 0)
                    {
                        foreach (var it in vals)
                        {
                            if ((it.CheckItemCode == item.CheckItemCode || (it.CheckItemCode == "10120" && item.CheckItemCode=="10002")) && (it.CheckVal == "" || it.CheckVal == null))
                            {
                                it.CheckVal = item.Value;
                                item.Shangchuan = true;
                                i++;
                            }

                        }

                    }
                    else
                    { item.Shangchuan = false; }
                }
               
                vals.Save();
            }
          
            test.Save();
            if (i > 0)
                MessageBox.Show(i.ToString() + "条数据上传完成");
            else MessageBox.Show("没有可匹配项目");
        }

        private void 查询_Click(object sender, EventArgs e)
        {
            test.LoadDataByWhere("SampleName>=@SampleName and SampleName<=@SampleName1 and JYShebei='" + DeviceConfigManager.Instance.config.Jysb + "' and Date>'" + DateTime.Now.AddMonths(-1).AddHours(24).ToString("yyyy-MM-dd HH:mm:ss") + "' order by  CheckItemCode asc,SampleName asc,date desc", textBox1.Text, textBox2.Text);
        }

        private void 全选_Click(object sender, EventArgs e)
        {
            if (this.全选.Text == "全选")
            {
                foreach (var item in test)
                {
                    item.Shangchuan = true;
                }
                this.全选.Text = "取消";
            }
            else if (this.全选.Text == "取消")
            {
                foreach (var item in test)
                {
                    item.Shangchuan = false;
                }
                this.全选.Text = "全选";
            }
        }
        
       
            
        
    }
}
    

