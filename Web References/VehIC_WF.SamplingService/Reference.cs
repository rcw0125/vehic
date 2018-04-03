﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18063
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.18063 版自动生成。
// 
#pragma warning disable 1591

namespace VehIC_WF.SamplingService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SamplingServiceSoap", Namespace="http://www.lfy.com/")]
    public partial class SamplingService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback HaveNectRecOperationCompleted;
        
        private System.Threading.SendOrPostCallback CancelTaskFlowInitRecOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SamplingService() {
            this.Url = global::Properties.Settings.Default.VehIC_WF_VehIC_WF_SamplingService_SamplingService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event HaveNectRecCompletedEventHandler HaveNectRecCompleted;
        
        /// <remarks/>
        public event CancelTaskFlowInitRecCompletedEventHandler CancelTaskFlowInitRecCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.lfy.com/HaveNectRec", RequestNamespace="http://www.lfy.com/", ResponseNamespace="http://www.lfy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool HaveNectRec(string billno, string curitemid, string wpcode) {
            object[] results = this.Invoke("HaveNectRec", new object[] {
                        billno,
                        curitemid,
                        wpcode});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void HaveNectRecAsync(string billno, string curitemid, string wpcode) {
            this.HaveNectRecAsync(billno, curitemid, wpcode, null);
        }
        
        /// <remarks/>
        public void HaveNectRecAsync(string billno, string curitemid, string wpcode, object userState) {
            if ((this.HaveNectRecOperationCompleted == null)) {
                this.HaveNectRecOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHaveNectRecOperationCompleted);
            }
            this.InvokeAsync("HaveNectRec", new object[] {
                        billno,
                        curitemid,
                        wpcode}, this.HaveNectRecOperationCompleted, userState);
        }
        
        private void OnHaveNectRecOperationCompleted(object arg) {
            if ((this.HaveNectRecCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HaveNectRecCompleted(this, new HaveNectRecCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.lfy.com/CancelTaskFlowInitRec", RequestNamespace="http://www.lfy.com/", ResponseNamespace="http://www.lfy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool CancelTaskFlowInitRec(string billno, string curitemid, string wpcode, string operid) {
            object[] results = this.Invoke("CancelTaskFlowInitRec", new object[] {
                        billno,
                        curitemid,
                        wpcode,
                        operid});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void CancelTaskFlowInitRecAsync(string billno, string curitemid, string wpcode, string operid) {
            this.CancelTaskFlowInitRecAsync(billno, curitemid, wpcode, operid, null);
        }
        
        /// <remarks/>
        public void CancelTaskFlowInitRecAsync(string billno, string curitemid, string wpcode, string operid, object userState) {
            if ((this.CancelTaskFlowInitRecOperationCompleted == null)) {
                this.CancelTaskFlowInitRecOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCancelTaskFlowInitRecOperationCompleted);
            }
            this.InvokeAsync("CancelTaskFlowInitRec", new object[] {
                        billno,
                        curitemid,
                        wpcode,
                        operid}, this.CancelTaskFlowInitRecOperationCompleted, userState);
        }
        
        private void OnCancelTaskFlowInitRecOperationCompleted(object arg) {
            if ((this.CancelTaskFlowInitRecCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CancelTaskFlowInitRecCompleted(this, new CancelTaskFlowInitRecCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void HaveNectRecCompletedEventHandler(object sender, HaveNectRecCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HaveNectRecCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HaveNectRecCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void CancelTaskFlowInitRecCompletedEventHandler(object sender, CancelTaskFlowInitRecCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CancelTaskFlowInitRecCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CancelTaskFlowInitRecCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591