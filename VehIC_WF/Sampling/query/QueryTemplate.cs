using System;
using System.ComponentModel;
using System.Data;
using Zhc.Data;

namespace LTZN.Query
{
    public partial class Querytemplate : DbEntity
    {
   
        private string _ENTITYNAME = "";
        private string _TEMPLATENAME = "";
        private string _XMLTEXT = "";
        //ConStr 



        public string ENTITYNAME
        {
            get
            {
                return this._ENTITYNAME;
            }
            set
            {
                if (!_ENTITYNAME.Equals(value))
                {
                    _ENTITYNAME = value;
                    RaisePropertyChanged("ENTITYNAME", true);
                }

            }
        }
        public string TEMPLATENAME
        {
            get
            {
                return this._TEMPLATENAME;
            }
            set
            {
                if (!_TEMPLATENAME.Equals(value))
                {
                    _TEMPLATENAME = value;
                    RaisePropertyChanged("TEMPLATENAME", true);
                }

            }
        }
        public string XMLTEXT
        {
            get
            {
                return this._XMLTEXT;
            }
            set
            {
                if (!_XMLTEXT.Equals(value))
                {
                    _XMLTEXT = value;
                    RaisePropertyChanged("XMLTEXT", true);
                }

            }
        }

    }
    public partial class QuerytemplateTable : DbEntityTable<Querytemplate>
    {
        public void LoadByEntityName(string entityName)
        {
            LoadDataByWhere("ENTITYNAME=@ENTITYNAME", entityName);
        }

        public Querytemplate GetByTemplateName(string templateName)
        {
            foreach (var item in this)
            {
                if (item.TEMPLATENAME == templateName)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
