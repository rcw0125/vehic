namespace VehIC_WF.AuthService
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable, GeneratedCode("System.Xml", "2.0.50727.42"), XmlType(Namespace="http://www.lfy.com/"), DebuggerStepThrough, DesignerCategory("code")]
    public class UserInfo
    {
        private string authoritylistField;
        private string deptField;
        private bool enableField;
        private string iCCardIDField;
        private string iCCardNoField;
        private int iCCardStatusField;
        private string idField;
        private string nameField;
        private string passWordField;
        private string roleField;
        private string workpointlistField;

        public string authoritylist
        {
            get
            {
                return this.authoritylistField;
            }
            set
            {
                this.authoritylistField = value;
            }
        }

        public string Dept
        {
            get
            {
                return this.deptField;
            }
            set
            {
                this.deptField = value;
            }
        }

        public bool Enable
        {
            get
            {
                return this.enableField;
            }
            set
            {
                this.enableField = value;
            }
        }

        public string ICCardID
        {
            get
            {
                return this.iCCardIDField;
            }
            set
            {
                this.iCCardIDField = value;
            }
        }

        public string ICCardNo
        {
            get
            {
                return this.iCCardNoField;
            }
            set
            {
                this.iCCardNoField = value;
            }
        }

        public int ICCardStatus
        {
            get
            {
                return this.iCCardStatusField;
            }
            set
            {
                this.iCCardStatusField = value;
            }
        }

        public string ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        public string PassWord
        {
            get
            {
                return this.passWordField;
            }
            set
            {
                this.passWordField = value;
            }
        }

        public string Role
        {
            get
            {
                return this.roleField;
            }
            set
            {
                this.roleField = value;
            }
        }

        public string workpointlist
        {
            get
            {
                return this.workpointlistField;
            }
            set
            {
                this.workpointlistField = value;
            }
        }
    }
}

