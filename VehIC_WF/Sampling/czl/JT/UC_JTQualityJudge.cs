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
using VehIC_WF.Sampling.Nc;
using DevExpress.XtraTreeList.Nodes;
using Xg.Lab.Sample.View;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using VehIC_WF.Sampling.Sample;

namespace VehIC_WF.Sampling
{
    public partial class UC_JTQualityJudge : UserControl
    {
        public UC_JTQualityJudge()
        {
            InitializeComponent();
            //Binding b = new Binding("Enabled", this.curData_Source, "SampleState", true, DataSourceUpdateMode.Never);
            //b.Format += SampleTypeToBoolean;
            //btnUploadNc.DataBindings.Add(b);
        }

        //void SampleTypeToBoolean(object sender, ConvertEventArgs cevent)
        //{
        //    if (cevent.DesiredType != typeof(bool)) return;
        //    if (cevent.Value is SampleState)
        //    {
        //        if (((SampleState)cevent.Value) == SampleState.NC报检完成)
        //        {
        //            cevent.Value = true;
        //        }
        //        else
        //        {
        //            cevent.Value = false;
        //        }
        //    }
        //    else
        //        cevent.Value = false;
        //}
       
        /// <summary>
        /// 当前用户
        /// </summary>
        public string CurUser
        {
            get
            {
                return LocalInfo.Current.user.ID;
            }
        }
        
        private QC_Sample_Mix _SelectedMixSample=null;
        /// <summary>
        /// 选中的检验单
        /// </summary>
        public QC_Sample_Mix SelectedMixSample
        {
            get { return _SelectedMixSample; }
            set
            {
                this.Cursor = Cursors.WaitCursor;
                if (_SelectedMixSample != value)
                {
                    _SelectedMixSample = value;
                    if (_SelectedMixSample != null)
                    {
                        if (_SelectedMixSample.SampleType == SampleType.抽查样)
                        {
                        
                            this.chouyangPanel.Visible = true;
                            xtraTabPage3.PageVisible = false;
                        }
                        else
                        {
                       
                            this.chouyangPanel.Visible = false;
                            xtraTabPage3.PageVisible = true;
                        }
                        if (_SelectedMixSample.SampleType == SampleType.校验样)
                        {
                            btnReportVal.Visible = false;
                            btnJudge.Visible = false;
                            xtraTabPage3.PageVisible = false;
                        }
                        else
                        {
                            btnReportVal.Visible = true;
                            btnJudge.Visible = true;
                        }



                        curData_Source.DataSource = _SelectedMixSample;

                        DbEntityTable<QC_MatQualityLevel_View> mqlDatas = new DbEntityTable<QC_MatQualityLevel_View>();
                        mqlDatas.LoadDataByWhere("MatNcId=@MatNcId", _SelectedMixSample.MatPK);

                        qCMatQualityLevelView_Source.DataSource = mqlDatas;

                        _SelectedMixSample.LoadDataDetailes();
                       
                    }
                }
                this.Cursor = Cursors.Default;
            }
        }

        private DbEntityTable<QC_Sample_Mix> mixSamples = new DbEntityTable<QC_Sample_Mix>();
        private DbEntityTable<QC_Sample_Mix> zdpdmixSamples = new DbEntityTable<QC_Sample_Mix>();
        private void UC_QualityJudge_Load(object sender, EventArgs e)
        {
            pdyjs.LoadData();
            LoadData();  
            curDataList_Source.DataSource = mixSamples;
          
        }
        
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            pdyjs.LoadData();
            LoadData();
            curDataList_Source.DataSource = mixSamples;
        }

        private void LoadData()
        {
            //
            QC_Sample_Mix.UpdateSampleState();
            //if(FrmMain.localinfo.workpoint.Code=="0075")
           mixSamples.LoadDataByWhere(string.Format("main.SampleState>={0} and main.SampleState<{1} and main.WLLX='焦炭' order by main.ZyRecvTime,main.mix_time", (int)SampleState.开始制样, (int)SampleState.NC报检完成));
           zdpdmixSamples.LoadDataByWhere(string.Format("main.SampleState>={0} and main.SampleState<{1} and main.WLLX='焦炭' and main.mix_time>'{2}' order by main.ZyRecvTime,main.mix_time", (int)SampleState.化验审核完成, (int)SampleState.NC报检完成, DateTime.Now.AddDays(-4).ToString("yyyy-MM-dd HH:mm:ss")));  
            //else if(FrmMain.localinfo.workpoint.Code=="0076")
              //  mixSamples.LoadDataByWhere(string.Format("main.SampleState>={0} and main.SampleState<{1} and main.WLLX='煤' order by main.ZyRecvTime,main.mix_time", (int)SampleState.开始制样, (int)SampleState.NC报检完成));

            // LoadDataByWhere("SampleState>=@BeginSampleState And SampleState<@EndSampleState", SampleState.开始组批, SampleState.上传完成);

            //mixSamples.Sort((s1, s2) =>
            //    {
            //        int result = s1.Riqi.CompareTo(s2.Riqi);
            //        if (result == 0)
            //            result = s1.ZyDanHao.CompareTo(s2.ZyDanHao);
            //        return result;
            //    }
            //    );
        }

        /// <summary>
        /// 上传NC
        /// </summary>
        private void btnUploadNc_Click(object sender, EventArgs e)
        {
            if (this.SelectedMixSample != null)
            {
               
                    //this.SelectedMixSample.SampleState = SampleState.处理完成;
                    //this.SelectedMixSample.Save();
                if (this.SelectedMixSample.FinishCommand == "处理")
                {
                    if (this.SelectedMixSample.SampleState >= SampleState.化验审核完成)
                    {
                        this.SelectedMixSample.SampleState = SampleState.处理完成;
                        this.SelectedMixSample.Save();
                    }
                    else
                    {
                        MessageBox.Show("化验审核完成后才能处理");
                    }
                }
                else
                {
                    try
                    {
                        if (this.SelectedMixSample.SampleState >= SampleState.质量判定完成)
                        {
                            if (SelectedMixSample.UploadToNc())
                            {
                                MessageBox.Show(string.Format("发送数据成功!"));
                            }
                        }
                        else
                        {
                            MessageBox.Show("质量判定完成后才能上传NC");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
             
            }
            else
            {
                MessageBox.Show("没有选择数据");
            }
        }

        /// <summary>
        ///判定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJudge_Click(object sender, EventArgs e)
        {
            if (SelectedMixSample != null)
            {
                if (this.SelectedMixSample.SampleState >= SampleState.报检数据生成)
                {
                    bool judge = SelectedMixSample.JudgeQuality();
                    if (judge)
                    {
                        this.SelectedMixSample.SaveVehSamples = true;
                        this.SelectedMixSample.SaveCheckVals = false;
                        this.SelectedMixSample.Save();
                        MessageBox.Show("判定成功！");
                    }
                    else
                    {
                        MessageBox.Show("找不到判定条件！");
                    }
                }
                else
                {
                    MessageBox.Show("报检数据生成后才能判定");
                }
           
            }
            else
            {
                MessageBox.Show("没有选中数据");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSample();
        }

        private void SaveSample()
        {
            if (this.SelectedMixSample != null)
            {
                this.SelectedMixSample.SaveVehSamples = true;
                this.SelectedMixSample.SaveCheckVals = false;
                this.SelectedMixSample.Save();
                MessageBox.Show("保存完成");
            }
            else
            {
                MessageBox.Show("没有选中数据");
            }
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (SelectedMixSample!=null && SelectedMixSample.DataState != DataRowState.Unchanged)
            {
                DialogResult result = MessageBox.Show("当前数据已修改,是否保存?", "询问", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveSample();
                }
                else if (result == DialogResult.No)
                {
                    this.SelectedMixSample.VehSamples.RejectChanges();
                    this.SelectedMixSample.CheckVals.RejectChanges();
                    this.SelectedMixSample.RejectChanges();
                }
                else
                    return;
            }
            SelectedMixSample = e.Row as QC_Sample_Mix;
            if (SelectedMixSample != null)
            {

                DbEntityTable<QC_QualityRule_View> quality = new DbEntityTable<QC_QualityRule_View>();
                    quality.LoadDataByWhere("MATNCID=@MATNCID and LocalQcLevel='一级'", SelectedMixSample.MatPK);
                if (quality.Count == 0)
                {
                    quality.LoadDataByWhere("MATNCID=@MATNCID and QualityLevelName='合格'", SelectedMixSample.MatPK);

                }
                foreach (var it in SelectedMixSample.CheckVals)
                {

                    DbEntityTable<QC_QualityRule_View> qualityhege = new DbEntityTable<QC_QualityRule_View>();
                    if (it.CheckVal != "")
                    {
                        foreach (var item in quality)
                        {

                            if (item.CheckItemCode == it.CheckItemCode)
                            {
                                qualityhege.Add(item);
                            }
                        }
                        if (qualityhege.Count == 1 && !GetBool(it.CheckVal + qualityhege[0].Relation + qualityhege[0].ConstraintVal))
                        {
                            it.VisIdx = 100000;
                        }
                        else if (qualityhege.Count == 2 && (!GetBool(it.CheckVal + qualityhege[0].Relation + qualityhege[0].ConstraintVal) || !GetBool(it.CheckVal + qualityhege[1].Relation + qualityhege[1].ConstraintVal)))
                        {
                            it.VisIdx = 100000;

                        }
                    }
                }
            }
        }
        bool GetBool(string s)
        {
            return Convert.ToBoolean(new DataTable().Compute(s, ""));
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.SelectedMixSample != null)
            {
                this.SelectedMixSample.VehSamples.RejectChanges();
                this.SelectedMixSample.CheckVals.RejectChanges();
                this.SelectedMixSample.RejectChanges();
            }
            else
            {
                MessageBox.Show("没有选中数据");
            }
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DlgQuerySample dlg = new DlgQuerySample();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.WhereSql != "")
                {
                    mixSamples.LoadDataByWhere(dlg.WhereSql + "and main.wllx='焦炭'");
                }
            }
        }
        /// <summary>
        /// 生成报检值
        /// </summary>
        private void btnSum_Click(object sender, EventArgs e)
        {
           // QC_Sample_Mix.UpdateReportValue();
          //  mixSamples.LoadData();
            //if (this.SelectedMixSample != null)
            //{
            //    double koushui = 0;
            //    double kouza = 0;
            //    foreach (var item in this.SelectedMixSample.VehSamples)
            //    {
            //        koushui += (item.KouShui ?? 0);
            //        kouza += (item.KouZa ?? 0);
            //    }
            //    this.SelectedMixSample.KouShui = koushui;
            //    this.SelectedMixSample.KouZa = kouza;
            //}
            //else
            //{
            //    MessageBox.Show("没有选中数据");
            //}
          //  MessageBox.Show("处理完成!");
        }

        /// <summary>
        /// 全部判定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllJudge_Click(object sender, EventArgs e)
        {

            if (SelectedMixSample != null)
            {
                string otherbc = "";
                foreach (var veh in SelectedMixSample.VehSamples)
                {
                    string sql = string.Format("select distinct b.vcheckbillcode from qc_checkbill_b1 b1 inner join qc_checkbill b on b.ccheckbillid=b1.ccheckbillid where b1.vdef1='{0}' and b1.vdef2='{1}' and b1.vdef7='{2}' and b1.vdef4='{3}' and b1.vdef8='{4}'",veh.VehNo, veh.T1.Split(' ')[0], veh.T1.Split(' ')[1], veh.T2.Split(' ')[0], veh.T2.Split(' ')[1]);
                    object batchcode = DbContext.DsExecuteScalar("ncdb", sql);
                    if (batchcode != null)
                    {
                        string bc = Convert.ToString(batchcode);
                        if (!string.IsNullOrEmpty(bc))
                        {
                            if (otherbc != "" && otherbc != bc)
                            {
                                MessageBox.Show(otherbc + "," + bc);
                                return;
                            }
                            otherbc = bc;
                            if (!string.IsNullOrEmpty(otherbc))
                            {
                                this.SelectedMixSample.NcQcBillNo = otherbc;
                                this.SelectedMixSample.SampleState = SampleState.NC报检完成;
                                this.SelectedMixSample.Save();
                            }
                            break;
                        }
                    }
                }

            }

            //QC_Sample_Mix_Table table = new QC_Sample_Mix_Table();
            //table.LoadDataByWhere(string.Format("main.SampleState={0}", (int)SampleState.化验审核完成));
            //foreach (var item in table)
            //{
            //    item.LoadCheckVals();
            //    item.JudgeQuality();
            //}
            //table.Save();
            //mixSamples.LoadData();

            MessageBox.Show("判定完成!");
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            //GridView view = (GridView)sender;
            //QC_Sample_Mix rowOb = view.GetRow(e.RowHandle) as QC_Sample_Mix;
            //if (rowOb!=null && rowOb.IndependentReport)
            //{
            //    e.Appearance.BackColor = Color.AliceBlue;
            //}
     
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void btnReportVal_Click(object sender, EventArgs e)
        {
            if (SelectedMixSample != null)
            {
                if (this.SelectedMixSample.SampleState >= SampleState.化验审核完成)
                {
                    try
                    {
                        bool judge = SelectedMixSample.CreateReportVal();
                        this.SelectedMixSample.SaveVehSamples = true;
                        this.SelectedMixSample.SaveCheckVals = true;
                        this.SelectedMixSample.Save();
                        MessageBox.Show("报检数据处理成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("出现问题：" + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("化验审核完成,才能生成报检值");
                }
            }
            else
            {
                MessageBox.Show("没有选中数据！");
            }
        }

        private void btnQuaRule_Click(object sender, EventArgs e)
        {
            if (SelectedMixSample != null)
            {
                DlgQualityRule dlg = new DlgQualityRule(SelectedMixSample);
                dlg.ShowDialog();
            }
        }

        private void gridView_CheckVal_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
           GridView gv=sender as GridView;
           if (gv != null && e.RowHandle >= 0 && e.Column.FieldName=="ReportVal")
           {
               QC_Sample_Value sv = gv.GetRow(e.RowHandle) as QC_Sample_Value;
               if (sv != null)
               {
                   if (sv.ReportValSource == "人工")
                   {
                       e.Appearance.BackColor = Color.GreenYellow;
                   }
               }
           }
           if (gv != null && e.RowHandle >= 0 && e.Column.FieldName == "CheckVal")
           {
               QC_Sample_Value sv = gv.GetRow(e.RowHandle) as QC_Sample_Value;
               if (sv != null)
               {
                   if (sv.VisIdx == 100000)
                   {
                       e.Appearance.BackColor = Color.Yellow;
                   }
               }

           }
        }

        private void 修改检验值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if (this.gridView_CheckVal.FocusedRowHandle >= 0)
           {
               QC_Sample_Value val = this.gridView_CheckVal.GetRow(this.gridView_CheckVal.FocusedRowHandle) as QC_Sample_Value;
               string valType = "";
               if (this.gridView_CheckVal.FocusedColumn.FieldName == "CheckVal")
               {
                   MessageBox.Show("检验值不允许修改");
               }
               if (this.gridView_CheckVal.FocusedColumn.FieldName == "ReportVal")
               {
                   valType = "报检值";
               }
               if (valType != "")
               {
                   DlgUpdateCheckVal dlg = new DlgUpdateCheckVal(val, valType);
                   dlg.ShowDialog();
               }
           }
        }

        private void btnRecheck_Click(object sender, EventArgs e)
        {
            if(this.SelectedMixSample!=null)
            {
                DlgRecheck dlg = new DlgRecheck(this.SelectedMixSample.Sample_Mix_ID);

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    foreach (var item in dlg.SelectedSample.CheckVals)
                    {
                       QC_Sample_Value selectItem= this.SelectedMixSample.CheckVals.FirstOrDefault<QC_Sample_Value>(sam => sam.CheckItemCode == item.CheckItemCode);
                       if (selectItem != null)
                       {
                           selectItem.ReportVal = item.CheckVal;
                           selectItem.ReportValSource = "复检值";
                       }
                    }
                }

            }
        }

        private void 清理_Click(object sender, EventArgs e)
        {
            if (this.SelectedMixSample.JudgeTime != null)
            {
            DateTime t = Convert.ToDateTime(this.SelectedMixSample.JudgeTime);

                if ((DateTime.Now - t).Days > 7)
                {
                    this.SelectedMixSample.SampleState = SampleState.处理完成;
                    this.SelectedMixSample.Save();

                    LoadData();
                    curDataList_Source.DataSource = mixSamples;
                   
                    gridView1.RefreshData();
                   
                }
                else
                {
                    MessageBox.Show("7天以内单据不能处理");
                }
            }
       }
        DbEntityTable<QC_Sample_zdpdyj> pdyjs = new DbEntityTable<QC_Sample_zdpdyj>();
        private void 自动判定上传_Click(object sender, EventArgs e)
        {
            zdpdmixSamples.LoadDataByWhere(string.Format("main.SampleState>={0} and main.SampleState<{1} and main.WLLX='精粉' and main.mix_time>'{2}' order by main.ZyRecvTime,main.mix_time", (int)SampleState.化验审核完成, (int)SampleState.NC报检完成, DateTime.Now.AddDays(-4).ToString("yyyy-MM-dd HH:mm:ss")));
            foreach (var mixSample in zdpdmixSamples)
            {
                mixSample.LoadDataDetailes();
                if (mixSample.SampleState == SampleState.化验审核完成)
                {
                    bool judge = mixSample.ZdCreateReportVal();
                    if (judge)
                    {
                        mixSample.SaveVehSamples = true;
                        mixSample.SaveCheckVals = true;
                        mixSample.Save();
                    }
                }
            }

            foreach (var mixSample in zdpdmixSamples)
            {
                if (mixSample.SampleState == SampleState.报检数据生成)
                {
                    if (mixSample.SampleType == SampleType.抽查样)
                    {
                        DbEntityTable<QC_Sample_Mix> mixs = new DbEntityTable<QC_Sample_Mix>();
                        mixs.LoadDataByWhere("main.sample_mix_id=@sample_mix_id", mixSample.MainSampleMixId);
                        if (mixs[0].SampleState < SampleState.报检数据生成 || mixs[0].SampleState == SampleState.NC报检完成)
                        { break; }
                    }
                    bool judge = mixSample.JudgeQuality();
                    if (judge)
                    {
                        mixSample.SaveVehSamples = true;
                        mixSample.SaveCheckVals = false;
                        mixSample.Save();
                    }
                }
            }
            cysc();
            zysc();
            MessageBox.Show("自动报检完成");
        }
        private void cysc()
        {
            foreach (var mixSample in zdpdmixSamples)
            {

                if (mixSample.SampleState == SampleState.质量判定完成 && mixSample.SampleType == SampleType.抽查样)
                {
                    double cypdfwS = 0; double cypdfwhTFe = 0; double cypdfwSiO2 = 0; double cypdfwP = 0; double cypdfwCu = 0; double cypdfwZn = 0;


                    // mixSample.LoadDataDetailes();
                    DbEntityTable<QC_Sample_Mix> mixs = new DbEntityTable<QC_Sample_Mix>();
                    mixs.LoadDataByWhere("main.sample_mix_id=@sample_mix_id", mixSample.MainSampleMixId);
                    if (mixs[0].SampleState < SampleState.报检数据生成 || mixs[0].SampleState == SampleState.NC报检完成)
                    { break; }
                    mixs[0].LoadDataDetailes();
                    bool scwc = false;
                    foreach (var item in mixSample.CheckVals)
                    {
                        if (item.CheckItemCode == "10001" && item.CheckItemName == "水分" && item.ValSource == "抽样")
                        {
                            foreach (var it in mixs[0].CheckVals)
                            {
                                if (it.CheckItemCode == "10001" && it.CheckItemName == "水分" && it.ValSource == "正样")
                                {
                                    if (Convert.ToDouble(item.ReportVal) > Convert.ToDouble(it.ReportVal))
                                    {
                                        mixSample.IndependentReport = true;
                                        mixSample.ZdUploadToNc();
                                        scwc = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (scwc == true)
                        {

                            break;

                        }
                        if (item.CheckItemCode == "10008" && item.CheckItemName == "TFe" && item.ValSource == "抽样")
                        {
                            foreach (var it in mixs[0].CheckVals)
                            {
                                if (it.CheckItemCode == "10008" && it.CheckItemName == "TFe" && it.ValSource == "正样")
                                {
                                    foreach (var i in pdyjs)
                                    {

                                        if (i.type == "精粉抽样判定范围")
                                        {
                                            cypdfwhTFe = Convert.ToDouble(i.TFe);
                                        }
                                    }
                                    if ((Convert.ToDouble(item.ReportVal) - Convert.ToDouble(it.ReportVal)) > cypdfwhTFe)
                                    {
                                        mixSample.IndependentReport = true;
                                        mixSample.ZdUploadToNc();
                                        scwc = true;
                                        break;
                                    }


                                }
                            }
                        }
                        if (scwc == true)
                        {

                            break;

                        }
                        if (item.CheckItemCode == "10005" && item.CheckItemName == "SiO2" && item.ValSource == "抽样")
                        {

                            foreach (var it in mixs[0].CheckVals)
                            {
                                if (it.CheckItemCode == "10005" && it.CheckItemName == "SiO2" && it.ValSource == "正样")
                                {
                                    foreach (var i in pdyjs)
                                    {

                                        if (i.type == "精粉抽样判定范围")
                                        {
                                            cypdfwSiO2 = Convert.ToDouble(i.SiO2);
                                        }
                                    }
                                    if ((Convert.ToDouble(item.ReportVal) - Convert.ToDouble(it.ReportVal)) > cypdfwSiO2)
                                    {
                                        mixSample.IndependentReport = true;
                                        mixSample.ZdUploadToNc();
                                        scwc = true;
                                        break;
                                    }
                                }
                            }

                        }
                        if (scwc == true)
                        {

                            break;

                        }
                        if (item.CheckItemCode == "10002" && item.CheckItemName == "S" && item.ValSource == "抽样")
                        {
                            foreach (var it in mixs[0].CheckVals)
                            {
                                if (it.CheckItemCode == "10002" && it.CheckItemName == "S" && it.ValSource == "正样")
                                {
                                    foreach (var i in pdyjs)
                                    {

                                        if (i.type == "精粉抽样判定范围")
                                        {
                                            cypdfwS = Convert.ToDouble(i.sf);
                                        }
                                    }
                                    if (Convert.ToDouble(item.ReportVal) - (Convert.ToDouble(it.ReportVal)) > cypdfwS)
                                    {
                                        mixSample.IndependentReport = true;
                                        mixSample.ZdUploadToNc();
                                        scwc = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (scwc == true)
                        {

                            break;

                        }
                        if (item.CheckItemCode == "10120" && item.CheckItemName == "硫分" && item.ValSource == "抽样")
                        {
                            foreach (var it in mixs[0].CheckVals)
                            {
                                if (it.CheckItemCode == "10120" && it.CheckItemName == "硫分" && it.ValSource == "正样")
                                {
                                    foreach (var i in pdyjs)
                                    {

                                        if (i.type == "精粉抽样判定范围")
                                        {
                                            cypdfwS = Convert.ToDouble(i.sf);
                                        }
                                    }
                                    if (Convert.ToDouble(item.ReportVal) - (Convert.ToDouble(it.ReportVal)) > cypdfwS)
                                    {
                                        mixSample.IndependentReport = true;
                                        mixSample.ZdUploadToNc();
                                        scwc = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (scwc == true)
                        {

                            break;

                        }
                        if (item.CheckItemCode == "10003" && item.CheckItemName == "P" && item.ValSource == "抽样")
                        {
                            foreach (var it in mixs[0].CheckVals)
                            {
                                if (it.CheckItemCode == "10003" && it.CheckItemName == "P" && it.ValSource == "正样")
                                {
                                    foreach (var i in pdyjs)
                                    {

                                        if (i.type == "精粉抽样判定范围")
                                        {
                                            cypdfwP= Convert.ToDouble(i.P);
                                        }
                                    }
                                    if ((Convert.ToDouble(it.ReportVal) - Convert.ToDouble(item.ReportVal)) > cypdfwP)
                                    {
                                        mixSample.IndependentReport = true;
                                        mixSample.ZdUploadToNc();
                                        scwc = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (scwc == true)
                        {

                            break;

                        }
                        if (item.CheckItemCode == "10037" && item.CheckItemName == "Cu" && item.ValSource == "抽样")
                        {

                            foreach (var it in mixs[0].CheckVals)
                            {
                                if (it.CheckItemCode == "10037" && it.CheckItemName == "Cu" && it.ValSource == "正样")
                                {
                                    foreach (var i in pdyjs)
                                    {

                                        if (i.type == "精粉抽样判定范围")
                                        {
                                            cypdfwCu = Convert.ToDouble(i.Cu);
                                        }
                                    }
                                    if ((Convert.ToDouble(it.ReportVal) - Convert.ToDouble(item.ReportVal)) > cypdfwCu)
                                    {
                                        mixSample.IndependentReport = true;
                                        mixSample.ZdUploadToNc();
                                        scwc = true;
                                        break;
                                    }
                                }
                            }

                        }
                        if (item.CheckItemCode == "10063" && item.CheckItemName == "Zn" && item.ValSource == "抽样")
                        {

                            foreach (var it in mixs[0].CheckVals)
                            {
                                if (it.CheckItemCode == "10063" && it.CheckItemName == "Zn" && it.ValSource == "正样")
                                {
                                    foreach (var i in pdyjs)
                                    {

                                        if (i.type == "精粉抽样判定范围")
                                        {
                                            cypdfwZn = Convert.ToDouble(i.Zn);
                                        }
                                    }
                                    if ((Convert.ToDouble(it.ReportVal) - Convert.ToDouble(item.ReportVal)) > cypdfwZn)
                                    {
                                        mixSample.IndependentReport = true;
                                        mixSample.ZdUploadToNc();
                                        scwc = true;
                                        break;
                                    }
                                }
                            }

                        }
                        if (scwc == true)
                        {
                            break;
                        }
                    }
                    if (scwc == false)
                    {
                        mixSample.SampleState = SampleState.处理完成;
                        mixSample.Save();
                    }




                }
            }

        }
        private void zysc()
        {
            foreach (var mixSample in zdpdmixSamples)
            {

                if (mixSample.SampleState == SampleState.质量判定完成 && mixSample.SampleType == SampleType.普通样)
                {
                    // mixSample.LoadDataDetailes();
                    bool wc = false;
                    foreach (var item in mixSample.InspectSamples)
                    {
                        if (item.SampleState < SampleState.报检数据生成)
                            wc = true;
                        break;
                    }
                    if (wc == true)
                        continue;
                    double zypdfwS = 0; double zypdfwTFe = 0; double zypdfwSiO2 = 0; double zypdfwP = 0; double zypdfwCu = 0; double zypdfwZn = 0;

                    double haozypdfwS = 0; double haozypdfwTFe = 0; double haozypdfwSiO2 = 0; double haozypdfwP = 0; double haozypdfwCu = 0; double haozypdfwZn = 0;
                    DbEntityTable<QC_QualityRule> mixSample_QualityRules = new DbEntityTable<QC_QualityRule>();
                    mixSample_QualityRules.LoadDataByWhere("MatNcId=@MatNcId", mixSample.MatPK);



                    Zhc.CalFramework.CalUtility calUtil = new Zhc.CalFramework.CalUtility(mixSample_QualityRules[mixSample_QualityRules.Count - 1].RuleContent.Replace("并且", "&&").Replace("或者", "||"));

                    // if (calUtil.DoCal(mixSample.CheckVals) > 0)
                    //{ 
                    //    mixSample.ZdUploadToNc();
                    //    continue;
                    //}
                    //  else
                    {
                        if (mixSample.CheckVals.Count > 0)
                        {
                            bool chaochufanwei = false;
                            foreach (var i in mixSample.CheckVals)
                            {
                                if (i.CheckItemCode == "10008" && i.CheckItemName == "TFe" && i.ValSource == "正样")
                                {

                                    foreach (var it in mixSample_QualityRules[mixSample_QualityRules.Count - 1].RuleContents)
                                    {
                                        if (it.CheckItemCode == "10008" && it.CheckItemName == "TFe")
                                        {
                                            foreach (var pdfw in pdyjs)
                                            {
                                                if (pdfw.type == "精粉正样劣于标准范围")
                                                {
                                                    if (pdfw.TFe != "")
                                                    {
                                                        zypdfwTFe = Convert.ToDouble(pdfw.TFe);
                                                        if (Convert.ToDouble(i.ReportVal) < Convert.ToDouble(it.ConstraintVal) && (it.Relation == ">" || it.Relation == ">=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > zypdfwTFe)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }
                                                        if (Convert.ToDouble(i.ReportVal) > Convert.ToDouble(it.ConstraintVal) && (it.Relation == "<" || it.Relation == "<=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > zypdfwTFe)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }
                                                    }
                                                }
                                                if (pdfw.type == "精粉正样优于标准范围")
                                                {
                                                    if (pdfw.TFe != "")
                                                    {
                                                        haozypdfwTFe = Convert.ToDouble(pdfw.TFe);
                                                        if (Convert.ToDouble(i.ReportVal) > Convert.ToDouble(it.ConstraintVal) && (it.Relation == ">" || it.Relation == ">=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > haozypdfwTFe)
                                                        {
                                                            chaochufanwei = true;
                                                            break;

                                                        }

                                                        if (Convert.ToDouble(i.ReportVal) < Convert.ToDouble(it.ConstraintVal) && (it.Relation == "<" || it.Relation == "<=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > haozypdfwTFe)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }
                                                    }
                                                }
                                            }

                                          
                                          
                                        }

                                    }
                                    if (chaochufanwei)
                                    { break; }

                                }
                                if (i.CheckItemCode == "10005" && i.CheckItemName == "SiO2" && i.ValSource == "正样")
                                {

                                    foreach (var it in mixSample_QualityRules[mixSample_QualityRules.Count - 1].RuleContents)
                                    {
                                        if (it.CheckItemCode == "10005" && it.CheckItemName == "SiO2")
                                        {
                                            foreach (var pdfw in pdyjs)
                                            {
                                                if (pdfw.type == "精粉正样劣于标准范围")
                                                {
                                                    if (pdfw.SiO2 != "")
                                                    {
                                                        zypdfwSiO2 = Convert.ToDouble(pdfw.SiO2);
                                                        if (Convert.ToDouble(i.ReportVal) < Convert.ToDouble(it.ConstraintVal) && (it.Relation == ">" || it.Relation == ">=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > zypdfwSiO2)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }
                                                        if (Convert.ToDouble(i.ReportVal) > Convert.ToDouble(it.ConstraintVal) && (it.Relation == "<" || it.Relation == "<=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > zypdfwSiO2)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }
                                                    }
                                                }
                                                if (pdfw.type == "精粉正样优于标准范围")
                                                {
                                                    if (pdfw.SiO2 != "")
                                                    {
                                                        haozypdfwSiO2 = Convert.ToDouble(pdfw.SiO2);
                                                        if (Convert.ToDouble(i.ReportVal) > Convert.ToDouble(it.ConstraintVal) && (it.Relation == ">" || it.Relation == ">=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > haozypdfwSiO2)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }

                                                        if (Convert.ToDouble(i.ReportVal) < Convert.ToDouble(it.ConstraintVal) && (it.Relation == "<" || it.Relation == "<=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > haozypdfwSiO2)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }
                                                    }
                                                }
                                            }

                                    
                                           
                                        }

                                    }
                                    if (chaochufanwei)
                                    { break; }

                                }
                                if (i.CheckItemCode == "10002" && i.CheckItemName == "S" && i.ValSource == "正样")
                                {

                                    foreach (var it in mixSample_QualityRules[mixSample_QualityRules.Count - 1].RuleContents)
                                    {
                                        if (it.CheckItemCode == "10002" && it.CheckItemName == "S")
                                        {
                                            foreach (var pdfw in pdyjs)
                                            {
                                                if (pdfw.type == "精粉正样劣于标准范围")
                                                {
                                                    if (pdfw.sf != "")
                                                    {
                                                        zypdfwS = Convert.ToDouble(pdfw.sf);
                                                        if (Convert.ToDouble(i.ReportVal) < Convert.ToDouble(it.ConstraintVal) && (it.Relation == ">" || it.Relation == ">=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > zypdfwS)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }
                                                        if (Convert.ToDouble(i.ReportVal) > Convert.ToDouble(it.ConstraintVal) && (it.Relation == "<" || it.Relation == "<=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > zypdfwS)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }
                                                    }
                                                }
                                                if (pdfw.type == "精粉正样优于标准范围")
                                                {
                                                    if (pdfw.sf != "")
                                                    {
                                                        haozypdfwS = Convert.ToDouble(pdfw.sf);
                                                        if (Convert.ToDouble(i.ReportVal) > Convert.ToDouble(it.ConstraintVal) && (it.Relation == ">" || it.Relation == ">=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > haozypdfwS)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }

                                                        if (Convert.ToDouble(i.ReportVal) < Convert.ToDouble(it.ConstraintVal) && (it.Relation == "<" || it.Relation == "<=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > haozypdfwS)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }
                                                    }
                                                }
                                            }

                                          
                                         
                                        }

                                    }
                                    if (chaochufanwei)
                                    { break; }

                                }
                                if (i.CheckItemCode == "10120" && i.CheckItemName == "硫分" && i.ValSource == "正样")
                                {

                                    foreach (var it in mixSample_QualityRules[mixSample_QualityRules.Count - 1].RuleContents)
                                    {
                                        if (it.CheckItemCode == "10120" && it.CheckItemName == "硫分")
                                        {
                                            foreach (var pdfw in pdyjs)
                                            {
                                                if (pdfw.type == "精粉正样劣于标准范围")
                                                {
                                                    if (pdfw.sf != "")
                                                    {
                                                        zypdfwS = Convert.ToDouble(pdfw.sf);
                                                        if (Convert.ToDouble(i.ReportVal) < Convert.ToDouble(it.ConstraintVal) && (it.Relation == ">" || it.Relation == ">=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > zypdfwS)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }
                                                        if (Convert.ToDouble(i.ReportVal) > Convert.ToDouble(it.ConstraintVal) && (it.Relation == "<" || it.Relation == "<=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > zypdfwS)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }
                                                    }
                                                }
                                                if (pdfw.type == "精粉正样优于标准范围")
                                                {
                                                    if (pdfw.sf != "")
                                                    {
                                                        haozypdfwS = Convert.ToDouble(pdfw.sf);
                                                        if (Convert.ToDouble(i.ReportVal) > Convert.ToDouble(it.ConstraintVal) && (it.Relation == ">" || it.Relation == ">=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > haozypdfwS)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }

                                                        if (Convert.ToDouble(i.ReportVal) < Convert.ToDouble(it.ConstraintVal) && (it.Relation == "<" || it.Relation == "<=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > haozypdfwS)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }
                                                    }
                                                }
                                            }

                                           
                                          
                                        }

                                    }
                                    if (chaochufanwei)
                                    { break; }

                                }
                                if (i.CheckItemCode == "10003" && i.CheckItemName == "P" && i.ValSource == "正样")
                                {

                                    foreach (var it in mixSample_QualityRules[mixSample_QualityRules.Count - 1].RuleContents)
                                    {
                                        if (it.CheckItemCode == "10003" && it.CheckItemName == "P")
                                        {
                                            foreach (var pdfw in pdyjs)
                                            {
                                               
                                               
                                                    if (pdfw.type == "精粉正样劣于标准范围")
                                                    {
                                                        if (pdfw.P != "")
                                                        {
                                                            zypdfwP = Convert.ToDouble(pdfw.P);
                                                            if (Convert.ToDouble(i.ReportVal) < Convert.ToDouble(it.ConstraintVal) && (it.Relation == ">" || it.Relation == ">=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > zypdfwP)
                                                            {
                                                                chaochufanwei = true;
                                                                break;


                                                            }
                                                            if (Convert.ToDouble(i.ReportVal) > Convert.ToDouble(it.ConstraintVal) && (it.Relation == "<" || it.Relation == "<=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > zypdfwP)
                                                            {
                                                                chaochufanwei = true;
                                                                break;


                                                            }
                                                        }
                                                     }
                                                if (pdfw.type == "精粉正样优于标准范围")
                                                {
                                                    if (pdfw.P != "")
                                                    {
                                                        haozypdfwP = Convert.ToDouble(pdfw.P);
                                                        if (Convert.ToDouble(i.ReportVal) > Convert.ToDouble(it.ConstraintVal) && (it.Relation == ">" || it.Relation == ">=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > haozypdfwP)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }

                                                        if (Convert.ToDouble(i.ReportVal) < Convert.ToDouble(it.ConstraintVal) && (it.Relation == "<" || it.Relation == "<=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > haozypdfwP)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }
                                                    }
                                                }
                                            }

                                           
                                           
                                        }

                                    }
                                    if (chaochufanwei)
                                    { break; }

                                }
                                if (i.CheckItemCode == "10037" && i.CheckItemName == "Cu" && i.ValSource == "正样")
                                {

                                    foreach (var it in mixSample_QualityRules[mixSample_QualityRules.Count - 1].RuleContents)
                                    {
                                        if (it.CheckItemCode == "10037" && it.CheckItemName == "Cu")
                                        {
                                            foreach (var pdfw in pdyjs)
                                            {
                                                if (pdfw.type == "精粉正样劣于标准范围")
                                                {
                                                    if (pdfw.Cu != "")
                                                    {
                                                        zypdfwCu = Convert.ToDouble(pdfw.Cu);
                                                        if (Convert.ToDouble(i.ReportVal) < Convert.ToDouble(it.ConstraintVal) && (it.Relation == ">" || it.Relation == ">=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > zypdfwCu)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }
                                                        if (Convert.ToDouble(i.ReportVal) > Convert.ToDouble(it.ConstraintVal) && (it.Relation == "<" || it.Relation == "<=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > zypdfwCu)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }
                                                    }
                                                }
                                                if (pdfw.type == "精粉正样优于标准范围")
                                                {
                                                    if (pdfw.Cu != "")
                                                    {
                                                        haozypdfwCu = Convert.ToDouble(pdfw.Cu);
                                                        if (Convert.ToDouble(i.ReportVal) > Convert.ToDouble(it.ConstraintVal) && (it.Relation == ">" || it.Relation == ">=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > haozypdfwCu)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }

                                                        if (Convert.ToDouble(i.ReportVal) < Convert.ToDouble(it.ConstraintVal) && (it.Relation == "<" || it.Relation == "<=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > haozypdfwCu)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }
                                                    }
                                                }
                                            }

                                          
                                     
                                        }

                                    }
                                    if (chaochufanwei)
                                    { break; }

                                }
                                if (i.CheckItemCode == "10063" && i.CheckItemName == "Zn" && i.ValSource == "正样")
                                {

                                    foreach (var it in mixSample_QualityRules[mixSample_QualityRules.Count - 1].RuleContents)
                                    {
                                        if (it.CheckItemCode == "10063" && it.CheckItemName == "Zn")
                                        {
                                            foreach (var pdfw in pdyjs)
                                            {
                                                if (pdfw.type == "精粉正样劣于标准范围")
                                                {
                                                    if (pdfw.Zn != "")
                                                    {
                                                        zypdfwZn = Convert.ToDouble(pdfw.Zn);
                                                        if (Convert.ToDouble(i.ReportVal) < Convert.ToDouble(it.ConstraintVal) && (it.Relation == ">" || it.Relation == ">=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > zypdfwZn)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }
                                                        if (Convert.ToDouble(i.ReportVal) > Convert.ToDouble(it.ConstraintVal) && (it.Relation == "<" || it.Relation == "<=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > zypdfwZn)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }
                                                    }
                                                }
                                                if (pdfw.type == "精粉正样优于标准范围")
                                                {
                                                    if (pdfw.Zn != "")
                                                    {
                                                        haozypdfwZn = Convert.ToDouble(pdfw.Zn);
                                                        if (Convert.ToDouble(i.ReportVal) > Convert.ToDouble(it.ConstraintVal) && (it.Relation == ">" || it.Relation == ">=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > haozypdfwZn)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }

                                                        if (Convert.ToDouble(i.ReportVal) < Convert.ToDouble(it.ConstraintVal) && (it.Relation == "<" || it.Relation == "<=") && Math.Abs(Convert.ToDouble(i.ReportVal) - Convert.ToDouble(it.ConstraintVal)) > haozypdfwZn)
                                                        {
                                                            chaochufanwei = true;
                                                            break;


                                                        }
                                                    }
                                                }
                                            }

                                          
                                        
                                        }

                                    }
                                    if (chaochufanwei)
                                    { break; }

                                }
                            }
                            if (!chaochufanwei)
                            { mixSample.ZdUploadToNc(); }
                        }
                    }




                }
                //if (mixSample.SampleState == SampleState.质量判定完成 && mixSample.SampleType == SampleType.复检样)
                //{
                //    // mixSample.LoadDataDetailes();
                //    double fjypdfwS = 0; double fjypdfwhf = 0; double fjypdfwhff = 0; double fjypdfwY = 0; double fjypdfwG = 0;

                //    DbEntityTable<QC_Sample_Mix> mixs = new DbEntityTable<QC_Sample_Mix>();
                //    mixs.LoadDataByWhere("main.sample_mix_id=@sample_mix_id", mixSample.MainSampleMixId);
                //    if (mixs[0].SampleState < SampleState.报检数据生成 || mixs[0].SampleState == SampleState.NC报检完成)
                //    { break; }
                //    mixs[0].LoadDataDetailes();
                //    bool scwc = false;
                //    foreach (var item in mixSample.CheckVals)
                //    {
                //        if (item.CheckItemCode == "10011" && item.CheckItemName == "灰分" && item.ValSource == "复检样")
                //        {
                //            foreach (var it in mixs[0].CheckVals)
                //            {
                //                if (it.CheckItemCode == "10011" && it.CheckItemName == "灰分" && it.ValSource == "正样")
                //                {
                //                    foreach (var i in pdyjs)
                //                    {

                //                        if (i.type == "复检样判定范围")
                //                        {
                //                            fjypdfwhf = Convert.ToDouble(i.hf);
                //                        }
                //                    }
                //                    if (Math.Abs(Convert.ToDouble(it.ReportVal) - Convert.ToDouble(item.ReportVal)) > fjypdfwhf)
                //                    {
                //                        mixSample.IndependentReport = true;
                //                        mixSample.ZdUploadToNc();
                //                        scwc = true;
                //                        break;
                //                    }


                //                }


                //            }


                //        }
                //        if (scwc == true)
                //        {
                //            scwc = false;
                //            break;

                //        }
                //        if (item.CheckItemCode == "10012" && item.CheckItemName == "挥发分" && item.ValSource == "复检样")
                //        {

                //            foreach (var it in mixs[0].CheckVals)
                //            {
                //                if (it.CheckItemCode == "10012" && it.CheckItemName == "挥发分" && it.ValSource == "正样")
                //                {
                //                    foreach (var i in pdyjs)
                //                    {

                //                        if (i.type == "复检样判定范围")
                //                        {
                //                            fjypdfwhff = Convert.ToDouble(i.hff);
                //                        }
                //                    }
                //                    if (Math.Abs(Convert.ToDouble(it.ReportVal) - Convert.ToDouble(item.ReportVal)) > fjypdfwhff)
                //                    {
                //                        mixSample.IndependentReport = true;
                //                        mixSample.ZdUploadToNc();
                //                        scwc = true;
                //                        break;
                //                    }


                //                }


                //            }

                //        }
                //        if (scwc == true)
                //        {
                //            scwc = false;
                //            break;

                //        }
                //        if (item.CheckItemCode == "10002" && item.CheckItemName == "S" && item.ValSource == "复检样")
                //        {
                //            foreach (var it in mixs[0].CheckVals)
                //            {
                //                if (it.CheckItemCode == "10002" && it.CheckItemName == "S" && it.ValSource == "正样")
                //                {
                //                    foreach (var i in pdyjs)
                //                    {

                //                        if (i.type == "复检样判定范围")
                //                        {
                //                            fjypdfwS = Convert.ToDouble(i.sf);
                //                        }
                //                    }
                //                    if (Math.Abs(Convert.ToDouble(it.ReportVal) - Convert.ToDouble(item.ReportVal)) > fjypdfwS)
                //                    {
                //                        mixSample.IndependentReport = true;
                //                        mixSample.ZdUploadToNc();
                //                        scwc = true;
                //                        break;
                //                    }


                //                }


                //            }


                //        }
                //        if (scwc == true)
                //        {
                //            scwc = false;
                //            break;

                //        }
                //        if (item.CheckItemCode == "10120" && item.CheckItemName == "硫分" && item.ValSource == "复检样")
                //        {
                //            foreach (var it in mixs[0].CheckVals)
                //            {
                //                if (it.CheckItemCode == "10120" && it.CheckItemName == "硫分" && it.ValSource == "正样")
                //                {
                //                    foreach (var i in pdyjs)
                //                    {

                //                        if (i.type == "复检样判定范围")
                //                        {
                //                            fjypdfwS = Convert.ToDouble(i.sf);
                //                        }
                //                    }
                //                    if (Math.Abs(Convert.ToDouble(it.ReportVal) - Convert.ToDouble(item.ReportVal)) > fjypdfwS)
                //                    {
                //                        mixSample.IndependentReport = true;
                //                        mixSample.ZdUploadToNc();
                //                        scwc = true;
                //                        break;
                //                    }


                //                }


                //            }


                //        }
                //        if (scwc == true)
                //        {
                //            scwc = false;
                //            break;

                //        }
                //        if (item.CheckItemCode == "10014" && item.CheckItemName == "Y" && item.ValSource == "复检样")
                //        {
                //            foreach (var it in mixs[0].CheckVals)
                //            {
                //                if (it.CheckItemCode == "10014" && it.CheckItemName == "Y" && it.ValSource == "正样")
                //                {
                //                    foreach (var i in pdyjs)
                //                    {

                //                        if (i.type == "复检样判定范围")
                //                        {
                //                            fjypdfwY = Convert.ToDouble(i.Y);
                //                        }
                //                    }
                //                    if (Math.Abs(Convert.ToDouble(it.ReportVal) - Convert.ToDouble(item.ReportVal)) > fjypdfwY)
                //                    {
                //                        mixSample.IndependentReport = true;
                //                        mixSample.ZdUploadToNc();
                //                        scwc = true;
                //                        break;
                //                    }


                //                }


                //            }


                //        }
                //        if (scwc == true)
                //        {
                //            scwc = false;
                //            break;

                //        }
                //        if (item.CheckItemCode == "10015" && item.CheckItemName == "G" && item.ValSource == "复检样")
                //        {

                //            foreach (var it in mixs[0].CheckVals)
                //            {
                //                if (it.CheckItemCode == "10015" && it.CheckItemName == "G" && it.ValSource == "正样")
                //                {
                //                    foreach (var i in pdyjs)
                //                    {

                //                        if (i.type == "复检样判定范围")
                //                        {
                //                            fjypdfwG = Convert.ToDouble(i.G);
                //                        }
                //                    }
                //                    if (Math.Abs(Convert.ToDouble(it.ReportVal) - Convert.ToDouble(item.ReportVal)) > fjypdfwG)
                //                    {
                //                        mixSample.IndependentReport = true;
                //                        mixSample.ZdUploadToNc();
                //                        scwc = true;
                //                        break;
                //                    }


                //                }


                //            }

                //        }
                //        if (scwc == true)
                //        {
                //            scwc = false;
                //            break;

                //        }
                //        mixs[0].ZdUploadToNc();





                //    }
               // }
            }
        }

        private void textEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
