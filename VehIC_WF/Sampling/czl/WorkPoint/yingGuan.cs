using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text.RegularExpressions;
using VehIC_WF.Sampling.Sample;
using Zhc.Data;
using Xg.Lab.Sample;

namespace VehIC_WF.Sampling.czl.WorkPoint
{
    public partial class YingGuang : UserControl
    {

        StringBuilder m_Buffer = null;
        private delegate void getdata();
        getdata getdata1;
        public YingGuang()
        {
            InitializeComponent();
            s.PortName = "COM1";
            s.BaudRate = 9600;
            s.DataBits = 8;
            s.Parity = Parity.None;
            s.StopBits = StopBits.One;

            m_Buffer = new StringBuilder();

            getdata1 = new getdata(dealData);

            opencomm();
        }

        private void opencomm()
        {
            try
            {
                if (!openCom(s))
                {
                    MessageBox.Show("打开串口" + s.PortName + "失败！");

                }
                else
                {

                    MessageBox.Show(s.PortName + "串口设备已打开！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开串口失败！" + ex.Message);
            }

        }



        // 打开设备
        public static Boolean openCom(SerialPort ss)
        {
            if (ss.IsOpen) ss.Close();
            try
            {
                ss.Open();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }

        }
        DbEntityTable<QC_Sample_Jyjg> test = new DbEntityTable<QC_Sample_Jyjg>();
        private void YingGuang_Load(object sender, EventArgs e)
        {

            test.LoadDataByWhere("shangchuan=0 and JYShebei=@JYShebei order by date desc", "荧光");
            this.gridControl1.DataSource = test;
        }

 

        private void s_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //GetCKCS();
                string str = s.ReadExisting();
                this.m_Buffer.Append(str);
                int length = this.m_Buffer.Length;
                for (int i = 0; i < this.m_Buffer.Length; i++)
                {
                    if (this.m_Buffer[i] == '\x0005')    // 05 是请求  回写06  收到通知
                    {
                        this.s.Write('\x0006'.ToString());
                        // this.m_Buffer.Remove(0, i + 1);
                        // return;
                    }
                    if (this.m_Buffer[i] == '\x0003')    //03 正文结束 回写06  收到通知
                    {
                        this.s.Write('\x0006'.ToString());
                        this.Invoke(getdata1);
                    }


                    //if (this.m_Buffer[i] == '\x0006')    //06  收到通知后   文件是否有数据，有则发送正文开始,否则，为数据传输完毕
                    //{
                    //    this.Invoke(sendDataToPort1);

                    //}
                }

                //this.Invoke(getdata1, str);

                //SetTextZl(strQS, 3);
            }
            catch (Exception ex)
            {

            }
        }

        // 获取一个完整的文件正文
        protected string GetTel()
        {
            int num = -1;
            int num2 = -1;
            for (int i = 0; i < this.m_Buffer.Length; i++)
            {
                if (this.m_Buffer[i] == '\x0002')
                {
                    num = i;
                }
                else if ((this.m_Buffer[i] == '\x0003') && (num >= 0))
                {
                    num2 = i;
                    break;
                }
            }
            if ((num >= 0) && (num2 > 0))
            {
                string str = this.m_Buffer.ToString(num + 1, (num2 - num) - 1);
                this.m_Buffer.Remove(0, num2 + 1);
                return str;
            }
            return null;
        }

        public void dealData()
        {
            string elementText = GetTel();
            if (elementText == null)
            {
                return;
            }

            regexString(elementText);

        }


        DbEntityTable<QC_Sample_Jyjg> test01 = new DbEntityTable<QC_Sample_Jyjg>();
        public void regexString(string input)
        {

            try
            {

                string str = "";
                Match match = Regex.Match(input, @"Sample:\s+(?<Sample>[^\r\s\t]+)");
                if ((match != null) && (match.Groups.Count > 0))
                {
                    str = match.Groups["Sample"].Value.Replace(",", "");
                }

                string strTime = "";
                //Date:          17,13 28,07,16
                match = Regex.Match(input, @"Date:\s+(?<Date>[^\r\n]+)");
                if ((match != null) && (match.Groups.Count > 0))
                {
                    string str1 = match.Groups["Date"].Value.Replace(",", "").Trim();

                    strTime = "20" + str1.Substring(9, 2) + "-" + str1.Substring(7, 2) + "-" + str1.Substring(5, 2) + " " + str1.Substring(0, 2) + ":" + str1.Substring(2, 2);
                }

                StringBuilder sb = new StringBuilder();

                for (match = Regex.Match(input, @"(?<Element>MnO|Ni|As|Sn|Sb|S|P|MgO|SiO2|CaO|Al2O3|TFe|R|TiO2|Mo|Cr|K2O|Na2O|Pb|V2O5|Zn|Cu)\s?:\s?(?<Value>[0-9.+-]+)"); (match != null) && match.Success; match = match.NextMatch())
                {
                    QC_Sample_Jyjg t2 = new QC_Sample_Jyjg();
                    t2.CheckItemCode = "";
                    t2.CheckItemName = match.Groups["Element"].Value.ToString();
                    t2.Date = strTime;
                    t2.JYShebei = "荧光";
                    t2.SampleName = str;

                    if (Convert.ToDouble(match.Groups["Value"].Value) < 0.0)
                    {

                        t2.Value = "0";

                    }
                    else
                    {
                        t2.Value = match.Groups["Value"].Value.ToString();
                    }

                    Boolean flag = true;
                    for (int i = 0; i < test.Count && flag; i++)
                    {
                        if (test[i].SampleName == t2.SampleName &&test[i].CheckItemName==t2.CheckItemName)
                        {
                            flag = false;
                            sb.Append("单号：" + test[i].SampleName + "," + "检验项目" + test[i].CheckItemName+"已存在");
                            sb.Append("\r\n");
                        }
                    }
                    if (flag)
                    {
                        test.Add(t2);
                    
                    }


                   

                        
                }

                if ((test.Count > 0) && (str != ""))
                {

                    test.Save();
                   
                  
                }



                test.Clear();
                test.LoadDataByWhere("shangchuan=0 and JYShebei=@JYShebei order by date desc", "荧光");


                if (sb.Length > 1)
                {
                    MessageBox.Show(sb.ToString());
                }


            }
            catch
            {

            }

        }

        private DbEntityTable<QC_Sample_Lab_Jy> hyy = new DbEntityTable<QC_Sample_Lab_Jy>();
        // private DbEntityTable<QC_Sample_Lab_Jy> hyysc = new DbEntityTable<QC_Sample_Lab_Jy>();
        private DbEntityTable<QC_Sample_Value> vals = new DbEntityTable<QC_Sample_Value>();
        private void 上传_Click(object sender, EventArgs e)
        {

            int i = 0;  
            StringBuilder sb = new StringBuilder();
            try
            {
              
               
                foreach (var item in test)
                {
                    if (item.Shangchuan)
                    {
                        hyy.LoadDataByWhere("JyCode=@JyCode", QC_Sample_Mix.FullStoreCode(item.SampleName));

                        if (hyy.Count > 0)
                        {
                            vals.LoadDataByWhere("main.Sample_Lab_ID=@Sample_Lab_ID", hyy[0].Sample_Lab_ID);

                            if (vals.Count > 0)
                            {
                                foreach (var it in vals)
                                {
                                    if (it.CheckItemName == item.CheckItemName && (it.CheckVal == "" || it.CheckVal == null))
                                    {
                                        it.CheckVal = item.Value;

                                        item.Shangchuan = true;
                                        i++;
                                        sb.Append("单号：" + item.SampleName + "," + "检验项目" + item.CheckItemName + "上传成功");
                                        sb.Append("\r\n");
                                    }

                                }

                                vals.Save();
                            }

                        }
                    }


                }

                test.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

          

            if (i > 0)
            {
                MessageBox.Show(i.ToString() + "条数据上传完成" + "\r\n" + sb.ToString());
            }
            else
            {

                MessageBox.Show("没有可匹配项目");
            }

            reloadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (var item in test)
            {    
           
                    hyy.LoadDataByWhere("JyCode=@JyCode", QC_Sample_Mix.FullStoreCode(item.SampleName));

                    if (hyy.Count > 0)
                    { 
                        vals.LoadDataByWhere("main.Sample_Lab_ID=@Sample_Lab_ID", hyy[0].Sample_Lab_ID);

                        if (vals.Count > 0)
                        {
                            foreach (var it in vals)
                            {
                                if (it.CheckItemName == item.CheckItemName && (it.CheckVal == "" || it.CheckVal == null))
                                {
                                    it.CheckVal = item.Value;

                                    item.Shangchuan = true;
                                    i++;
                                    sb.Append("单号：" + item.SampleName + "," + "检验项目" + item.CheckItemName + "上传成功");
                                    sb.Append("\r\n");
                                }

                            }

                            vals.Save();
                        }

                    }                                  
                item.Shangchuan = true; 

           
            }

            test.Save();

            if (i > 0)
            {
                MessageBox.Show(i.ToString() + "条数据上传完成" + "\r\n" + sb.ToString());
            }
            else
            { 
             
                MessageBox.Show("没有可匹配项目");
            }

            reloadData();
               
           
        }

        private void reloadData()
        {

            test.Clear();
            test.LoadDataByWhere("shangchuan=0 and JYShebei=@JYShebei order by date desc", "荧光");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var item in test)
            {

                item.Shangchuan = true;
            }
            test.Save();


            test.Clear();
            test.LoadDataByWhere("shangchuan=0 and JYShebei=@JYShebei order by date desc", "荧光");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            portConfig pc = new portConfig();
            if (pc.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (s.IsOpen) s.Close();
                    s.PortName = pc.PortName;
                    s.BaudRate = Convert.ToInt16(pc.BaudRate);
                    s.DataBits = Convert.ToInt16(pc.DataBits);
                    if (pc.Parity == "None")
                    {
                        s.Parity = Parity.None;
                    }
                    else if (pc.Parity == "Even")
                    {
                        s.Parity = Parity.Even;
                    }
                    else if (pc.Parity == "Mark")
                    {
                        s.Parity = Parity.Mark;
                    }
                    else if (pc.Parity == "Odd")
                    {
                        s.Parity = Parity.Odd;
                    }
                    else if (pc.Parity == "Space")
                    {
                        s.Parity = Parity.Space;
                    }
                    if (pc.StopBits == "None")
                    {
                        s.StopBits = StopBits.None;
                    }
                    else if (pc.StopBits == "One")
                    {
                        s.StopBits = StopBits.One;
                    }
                    else if (pc.StopBits == "OnePointFive")
                    {
                        s.StopBits = StopBits.OnePointFive;
                    }
                    else if (pc.StopBits == "Two")
                    {
                        s.StopBits = StopBits.Two;
                    }
                    opencomm();   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                        
                   
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach (var item in test)
            {
                item.Shangchuan = true;
            }
        }
    }
}
