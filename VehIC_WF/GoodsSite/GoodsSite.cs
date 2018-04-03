namespace VehIC_WF.GoodsSite
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Web.Services;
    using System.Web.Services.Description;
    using System.Web.Services.Protocols;
    using VehIC_WF.Properties;

    [WebServiceBinding(Name="GoodsSiteSoap", Namespace="http://www.lfy.com/"), DebuggerStepThrough, DesignerCategory("code"), GeneratedCode("System.Web.Services", "2.0.50727.1433")]
    public class GoodsSite : SoapHttpClientProtocol
    {
        private SendOrPostCallback CancelTaskFlowInitRecOperationCompleted;
        private SendOrPostCallback HaveNectRecOperationCompleted;
        private bool useDefaultCredentialsSetExplicitly;

        public event CancelTaskFlowInitRecCompletedEventHandler CancelTaskFlowInitRecCompleted;

        public event HaveNectRecCompletedEventHandler HaveNectRecCompleted;

        public GoodsSite()
        {
            this.Url = Settings.Default.VehIC_WF_GoodsSite_GoodsSite;
            if (this.IsLocalFileSystemWebService(this.Url))
            {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else
            {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }

        public void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }

        [SoapDocumentMethod("http://www.lfy.com/CancelTaskFlowInitRec", RequestNamespace="http://www.lfy.com/", ResponseNamespace="http://www.lfy.com/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public bool CancelTaskFlowInitRec(string billno, string curitemid, string wpcode, string operid)
        {
            return (bool) base.Invoke("CancelTaskFlowInitRec", new object[] { billno, curitemid, wpcode, operid })[0];
        }

        public void CancelTaskFlowInitRecAsync(string billno, string curitemid, string wpcode, string operid)
        {
            this.CancelTaskFlowInitRecAsync(billno, curitemid, wpcode, operid, null);
        }

        public void CancelTaskFlowInitRecAsync(string billno, string curitemid, string wpcode, string operid, object userState)
        {
            if (this.CancelTaskFlowInitRecOperationCompleted == null)
            {
                this.CancelTaskFlowInitRecOperationCompleted = new SendOrPostCallback(this.OnCancelTaskFlowInitRecOperationCompleted);
            }
            base.InvokeAsync("CancelTaskFlowInitRec", new object[] { billno, curitemid, wpcode, operid }, this.CancelTaskFlowInitRecOperationCompleted, userState);
        }

        [SoapDocumentMethod("http://www.lfy.com/HaveNectRec", RequestNamespace="http://www.lfy.com/", ResponseNamespace="http://www.lfy.com/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public bool HaveNectRec(string billno, string curitemid, string wpcode)
        {
            return (bool) base.Invoke("HaveNectRec", new object[] { billno, curitemid, wpcode })[0];
        }

        public void HaveNectRecAsync(string billno, string curitemid, string wpcode)
        {
            this.HaveNectRecAsync(billno, curitemid, wpcode, null);
        }

        public void HaveNectRecAsync(string billno, string curitemid, string wpcode, object userState)
        {
            if (this.HaveNectRecOperationCompleted == null)
            {
                this.HaveNectRecOperationCompleted = new SendOrPostCallback(this.OnHaveNectRecOperationCompleted);
            }
            base.InvokeAsync("HaveNectRec", new object[] { billno, curitemid, wpcode }, this.HaveNectRecOperationCompleted, userState);
        }

        private bool IsLocalFileSystemWebService(string url)
        {
            if ((url == null) || (url == string.Empty))
            {
                return false;
            }
            Uri uri = new Uri(url);
            return ((uri.Port >= 0x400) && (string.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0));
        }

        private void OnCancelTaskFlowInitRecOperationCompleted(object arg)
        {
            if (this.CancelTaskFlowInitRecCompleted != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) arg;
                this.CancelTaskFlowInitRecCompleted(this, new CancelTaskFlowInitRecCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnHaveNectRecOperationCompleted(object arg)
        {
            if (this.HaveNectRecCompleted != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) arg;
                this.HaveNectRecCompleted(this, new HaveNectRecCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        public string Url
        {
            get
            {
                return base.Url;
            }
            set
            {
                if (!((!this.IsLocalFileSystemWebService(base.Url) || this.useDefaultCredentialsSetExplicitly) || this.IsLocalFileSystemWebService(value)))
                {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }

        public bool UseDefaultCredentials
        {
            get
            {
                return base.UseDefaultCredentials;
            }
            set
            {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
    }
}

