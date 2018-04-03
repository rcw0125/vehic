namespace VehIC_WF.Utility
{
    using FastReport;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Runtime.InteropServices;

    public class FrxDataTable : DataTable
    {
        private DataTable m_ChildTable;
        private TfrxUserDataSetClass m_ds;
        private int nItem;

        public FrxDataTable(DataTable t)
        {
            this.constructor(t.TableName);
            string str = null;
            foreach (DataColumn column in t.Columns)
            {
                str = str + column.Caption + "\n";
            }
            this.m_ds.Fields = str;
            this.m_ChildTable = t;
        }

        public FrxDataTable(string name)
        {
            this.constructor(name);
        }

        public void AssignToDataBand(string BandName, TfrxReportClass report)
        {
            IfrxComponent component;
            ((IfrxComponent) report).FindObject(BandName, out component);
            ((IfrxDataBand) component).DataSet = (IfrxDataSet) this.m_ds;
        }

        public void AssignToReport(bool Enable, TfrxReportClass report)
        {
            report.SelectDataset(Enable, this.m_ds);
        }

        private void ColumnsCollection_Changed(object sender, CollectionChangeEventArgs e)
        {
            DataColumnCollection columns = (DataColumnCollection) sender;
            string str = null;
            foreach (DataColumn column in columns)
            {
                str = str + column.Caption + "\n";
            }
            this.m_ds.Fields = str;
        }

        private void constructor(string name)
        {
            this.m_ChildTable = null;
            this.m_ds = new TfrxUserDataSetClass();
            this.m_ds.OnCheckEOF += new IfrxUserDataSetEvents_OnCheckEOFEventHandler(this.OnCheckEOFEventHandler);
            this.m_ds.OnGetValue+=new IfrxUserDataSetEvents_OnGetValueEventHandler(this.OnGetValueHandler);
            this.m_ds.OnFirst+=new IfrxUserDataSetEvents_OnFirstEventHandler(this.OnFirstEventHandler);
            this.m_ds.OnNext+=new IfrxUserDataSetEvents_OnNextEventHandler(this.OnNextEventHandler);
            this.m_ds.OnPrior+=new IfrxUserDataSetEvents_OnPriorEventHandler(this.OnPriorEventHandler);
            this.m_ds.Name = name;
            base.Columns.CollectionChanged += new CollectionChangeEventHandler(this.ColumnsCollection_Changed);
        }

        private void OnCheckEOFEventHandler(out bool eof)
        {
            if (this.m_ChildTable == null)
            {
                eof = this.nItem >= base.Rows.Count;
            }
            else
            {
                eof = this.nItem >= this.m_ChildTable.Rows.Count;
            }
        }

        private void OnFirstEventHandler()
        {
            this.nItem = 0;
        }

        private void OnGetValueHandler(object VarName, out object Val)
        {
            if (this.m_ChildTable == null)
            {
                Val = base.Rows[this.nItem][VarName.ToString()];
            }
            else
            {
                Val = this.m_ChildTable.Rows[this.nItem][VarName.ToString()];
            }
            if (Val is decimal)
            {
                Val = decimal.ToInt32((decimal) Val);
            }
        }

        private void OnNextEventHandler()
        {
            this.nItem++;
        }

        private void OnPriorEventHandler()
        {
            this.nItem--;
        }

        public IfrxDataSet FrxTable
        {
            get
            {
                return (this.m_ds as IfrxDataSet);
            }
        }

        public string TableName
        {
            get
            {
                return this.m_ds.Name;
            }
        }
    }
}

