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

namespace VehIC_WF.Sampling
{
    public partial class UC_SZQualityJudge : UserControl
    {
        public UC_SZQualityJudge()
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
                            gridCol_ValSource.Visible = true;
                            this.chouyangPanel.Visible = true;
                            xtraTabPage3.PageVisible = false;
                        }
                        else
                        {
                            gridCol_ValSource.Visible = false;
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

        private void UC_QualityJudge_Load(object sender, EventArgs e)
        {  
            LoadData();  
            curDataList_Source.DataSource = mixSamples;
          
        }
        
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            curDataList_Source.DataSource = mixSamples;
        }

        private void LoadData()
        {
            //
            QC_Sample_Mix.UpdateSampleState();
            //if(FrmMain.localinfo.workpoint.Code=="0075")
            mixSamples.LoadDataByWhere(string.Format("main.SampleState>={0} and main.SampleState<{1} and main.WLLX='石子' order by main.ZyRecvTime,main.mix_time", (int)SampleState.开始制样, (int)SampleState.NC报检完成));
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
                    mixSamples.LoadDataByWhere(dlg.WhereSql + "and main.wllx='石子'");
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

    }
}
