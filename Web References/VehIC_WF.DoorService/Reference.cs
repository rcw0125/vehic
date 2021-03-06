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

namespace VehIC_WF.DoorService {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="DoorServiceSoap", Namespace="http://www.lfy.com/")]
    public partial class DoorService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback HelloWorldOperationCompleted;
        
        private System.Threading.SendOrPostCallback ExcuteEnterOperationCompleted;
        
        private System.Threading.SendOrPostCallback SteelDoor_OutOperationCompleted;
        
        private System.Threading.SendOrPostCallback SteelDoor_EnterOperationCompleted;
        
        private System.Threading.SendOrPostCallback TaskCancelOperationCompleted;
        
        private System.Threading.SendOrPostCallback CheckAuthCodeOperationCompleted;
        
        private System.Threading.SendOrPostCallback SteelDoor_EnterCheckOperationCompleted;
        
        private System.Threading.SendOrPostCallback Door_DirectionCheckOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public DoorService() {
            this.Url = global::Properties.Settings.Default.VehIC_WF_VehIC_WF_DoorService_DoorService;
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
        public event HelloWorldCompletedEventHandler HelloWorldCompleted;
        
        /// <remarks/>
        public event ExcuteEnterCompletedEventHandler ExcuteEnterCompleted;
        
        /// <remarks/>
        public event SteelDoor_OutCompletedEventHandler SteelDoor_OutCompleted;
        
        /// <remarks/>
        public event SteelDoor_EnterCompletedEventHandler SteelDoor_EnterCompleted;
        
        /// <remarks/>
        public event TaskCancelCompletedEventHandler TaskCancelCompleted;
        
        /// <remarks/>
        public event CheckAuthCodeCompletedEventHandler CheckAuthCodeCompleted;
        
        /// <remarks/>
        public event SteelDoor_EnterCheckCompletedEventHandler SteelDoor_EnterCheckCompleted;
        
        /// <remarks/>
        public event Door_DirectionCheckCompletedEventHandler Door_DirectionCheckCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.lfy.com/HelloWorld", RequestNamespace="http://www.lfy.com/", ResponseNamespace="http://www.lfy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HelloWorldAsync() {
            this.HelloWorldAsync(null);
        }
        
        /// <remarks/>
        public void HelloWorldAsync(object userState) {
            if ((this.HelloWorldOperationCompleted == null)) {
                this.HelloWorldOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHelloWorldOperationCompleted);
            }
            this.InvokeAsync("HelloWorld", new object[0], this.HelloWorldOperationCompleted, userState);
        }
        
        private void OnHelloWorldOperationCompleted(object arg) {
            if ((this.HelloWorldCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HelloWorldCompleted(this, new HelloWorldCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.lfy.com/ExcuteEnter", RequestNamespace="http://www.lfy.com/", ResponseNamespace="http://www.lfy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool ExcuteEnter(string billno, int billtype, string billtypecode, string vehno, string icid, string wpcode, string operid, bool needweigh) {
            object[] results = this.Invoke("ExcuteEnter", new object[] {
                        billno,
                        billtype,
                        billtypecode,
                        vehno,
                        icid,
                        wpcode,
                        operid,
                        needweigh});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void ExcuteEnterAsync(string billno, int billtype, string billtypecode, string vehno, string icid, string wpcode, string operid, bool needweigh) {
            this.ExcuteEnterAsync(billno, billtype, billtypecode, vehno, icid, wpcode, operid, needweigh, null);
        }
        
        /// <remarks/>
        public void ExcuteEnterAsync(string billno, int billtype, string billtypecode, string vehno, string icid, string wpcode, string operid, bool needweigh, object userState) {
            if ((this.ExcuteEnterOperationCompleted == null)) {
                this.ExcuteEnterOperationCompleted = new System.Threading.SendOrPostCallback(this.OnExcuteEnterOperationCompleted);
            }
            this.InvokeAsync("ExcuteEnter", new object[] {
                        billno,
                        billtype,
                        billtypecode,
                        vehno,
                        icid,
                        wpcode,
                        operid,
                        needweigh}, this.ExcuteEnterOperationCompleted, userState);
        }
        
        private void OnExcuteEnterOperationCompleted(object arg) {
            if ((this.ExcuteEnterCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ExcuteEnterCompleted(this, new ExcuteEnterCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.lfy.com/SteelDoor_Out", RequestNamespace="http://www.lfy.com/", ResponseNamespace="http://www.lfy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SteelDoor_Out(string billno, string vehno, string icid, string wpcode, string operid) {
            object[] results = this.Invoke("SteelDoor_Out", new object[] {
                        billno,
                        vehno,
                        icid,
                        wpcode,
                        operid});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void SteelDoor_OutAsync(string billno, string vehno, string icid, string wpcode, string operid) {
            this.SteelDoor_OutAsync(billno, vehno, icid, wpcode, operid, null);
        }
        
        /// <remarks/>
        public void SteelDoor_OutAsync(string billno, string vehno, string icid, string wpcode, string operid, object userState) {
            if ((this.SteelDoor_OutOperationCompleted == null)) {
                this.SteelDoor_OutOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSteelDoor_OutOperationCompleted);
            }
            this.InvokeAsync("SteelDoor_Out", new object[] {
                        billno,
                        vehno,
                        icid,
                        wpcode,
                        operid}, this.SteelDoor_OutOperationCompleted, userState);
        }
        
        private void OnSteelDoor_OutOperationCompleted(object arg) {
            if ((this.SteelDoor_OutCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SteelDoor_OutCompleted(this, new SteelDoor_OutCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.lfy.com/SteelDoor_Enter", RequestNamespace="http://www.lfy.com/", ResponseNamespace="http://www.lfy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SteelDoor_Enter(string billno, string vehno, string icid, string wpcode) {
            object[] results = this.Invoke("SteelDoor_Enter", new object[] {
                        billno,
                        vehno,
                        icid,
                        wpcode});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void SteelDoor_EnterAsync(string billno, string vehno, string icid, string wpcode) {
            this.SteelDoor_EnterAsync(billno, vehno, icid, wpcode, null);
        }
        
        /// <remarks/>
        public void SteelDoor_EnterAsync(string billno, string vehno, string icid, string wpcode, object userState) {
            if ((this.SteelDoor_EnterOperationCompleted == null)) {
                this.SteelDoor_EnterOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSteelDoor_EnterOperationCompleted);
            }
            this.InvokeAsync("SteelDoor_Enter", new object[] {
                        billno,
                        vehno,
                        icid,
                        wpcode}, this.SteelDoor_EnterOperationCompleted, userState);
        }
        
        private void OnSteelDoor_EnterOperationCompleted(object arg) {
            if ((this.SteelDoor_EnterCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SteelDoor_EnterCompleted(this, new SteelDoor_EnterCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.lfy.com/TaskCancel", RequestNamespace="http://www.lfy.com/", ResponseNamespace="http://www.lfy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string TaskCancel(string billno, string wpcode, string operid) {
            object[] results = this.Invoke("TaskCancel", new object[] {
                        billno,
                        wpcode,
                        operid});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void TaskCancelAsync(string billno, string wpcode, string operid) {
            this.TaskCancelAsync(billno, wpcode, operid, null);
        }
        
        /// <remarks/>
        public void TaskCancelAsync(string billno, string wpcode, string operid, object userState) {
            if ((this.TaskCancelOperationCompleted == null)) {
                this.TaskCancelOperationCompleted = new System.Threading.SendOrPostCallback(this.OnTaskCancelOperationCompleted);
            }
            this.InvokeAsync("TaskCancel", new object[] {
                        billno,
                        wpcode,
                        operid}, this.TaskCancelOperationCompleted, userState);
        }
        
        private void OnTaskCancelOperationCompleted(object arg) {
            if ((this.TaskCancelCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.TaskCancelCompleted(this, new TaskCancelCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.lfy.com/CheckAuthCode", RequestNamespace="http://www.lfy.com/", ResponseNamespace="http://www.lfy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool CheckAuthCode(string wpcode) {
            object[] results = this.Invoke("CheckAuthCode", new object[] {
                        wpcode});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void CheckAuthCodeAsync(string wpcode) {
            this.CheckAuthCodeAsync(wpcode, null);
        }
        
        /// <remarks/>
        public void CheckAuthCodeAsync(string wpcode, object userState) {
            if ((this.CheckAuthCodeOperationCompleted == null)) {
                this.CheckAuthCodeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCheckAuthCodeOperationCompleted);
            }
            this.InvokeAsync("CheckAuthCode", new object[] {
                        wpcode}, this.CheckAuthCodeOperationCompleted, userState);
        }
        
        private void OnCheckAuthCodeOperationCompleted(object arg) {
            if ((this.CheckAuthCodeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CheckAuthCodeCompleted(this, new CheckAuthCodeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.lfy.com/SteelDoor_EnterCheck", RequestNamespace="http://www.lfy.com/", ResponseNamespace="http://www.lfy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Result SteelDoor_EnterCheck(string billno, string wpcode) {
            object[] results = this.Invoke("SteelDoor_EnterCheck", new object[] {
                        billno,
                        wpcode});
            return ((Result)(results[0]));
        }
        
        /// <remarks/>
        public void SteelDoor_EnterCheckAsync(string billno, string wpcode) {
            this.SteelDoor_EnterCheckAsync(billno, wpcode, null);
        }
        
        /// <remarks/>
        public void SteelDoor_EnterCheckAsync(string billno, string wpcode, object userState) {
            if ((this.SteelDoor_EnterCheckOperationCompleted == null)) {
                this.SteelDoor_EnterCheckOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSteelDoor_EnterCheckOperationCompleted);
            }
            this.InvokeAsync("SteelDoor_EnterCheck", new object[] {
                        billno,
                        wpcode}, this.SteelDoor_EnterCheckOperationCompleted, userState);
        }
        
        private void OnSteelDoor_EnterCheckOperationCompleted(object arg) {
            if ((this.SteelDoor_EnterCheckCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SteelDoor_EnterCheckCompleted(this, new SteelDoor_EnterCheckCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.lfy.com/Door_DirectionCheck", RequestNamespace="http://www.lfy.com/", ResponseNamespace="http://www.lfy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Result Door_DirectionCheck(string billno, string vehno, string ywdesc, string wpcode, bool toin) {
            object[] results = this.Invoke("Door_DirectionCheck", new object[] {
                        billno,
                        vehno,
                        ywdesc,
                        wpcode,
                        toin});
            return ((Result)(results[0]));
        }
        
        /// <remarks/>
        public void Door_DirectionCheckAsync(string billno, string vehno, string ywdesc, string wpcode, bool toin) {
            this.Door_DirectionCheckAsync(billno, vehno, ywdesc, wpcode, toin, null);
        }
        
        /// <remarks/>
        public void Door_DirectionCheckAsync(string billno, string vehno, string ywdesc, string wpcode, bool toin, object userState) {
            if ((this.Door_DirectionCheckOperationCompleted == null)) {
                this.Door_DirectionCheckOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDoor_DirectionCheckOperationCompleted);
            }
            this.InvokeAsync("Door_DirectionCheck", new object[] {
                        billno,
                        vehno,
                        ywdesc,
                        wpcode,
                        toin}, this.Door_DirectionCheckOperationCompleted, userState);
        }
        
        private void OnDoor_DirectionCheckOperationCompleted(object arg) {
            if ((this.Door_DirectionCheckCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Door_DirectionCheckCompleted(this, new Door_DirectionCheckCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.lfy.com/")]
    public partial class Result {
        
        private bool flagField;
        
        private string descField;
        
        /// <remarks/>
        public bool Flag {
            get {
                return this.flagField;
            }
            set {
                this.flagField = value;
            }
        }
        
        /// <remarks/>
        public string Desc {
            get {
                return this.descField;
            }
            set {
                this.descField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void HelloWorldCompletedEventHandler(object sender, HelloWorldCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HelloWorldCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HelloWorldCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ExcuteEnterCompletedEventHandler(object sender, ExcuteEnterCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ExcuteEnterCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ExcuteEnterCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void SteelDoor_OutCompletedEventHandler(object sender, SteelDoor_OutCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SteelDoor_OutCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SteelDoor_OutCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void SteelDoor_EnterCompletedEventHandler(object sender, SteelDoor_EnterCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SteelDoor_EnterCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SteelDoor_EnterCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void TaskCancelCompletedEventHandler(object sender, TaskCancelCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TaskCancelCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal TaskCancelCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void CheckAuthCodeCompletedEventHandler(object sender, CheckAuthCodeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CheckAuthCodeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CheckAuthCodeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void SteelDoor_EnterCheckCompletedEventHandler(object sender, SteelDoor_EnterCheckCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SteelDoor_EnterCheckCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SteelDoor_EnterCheckCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Result Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Result)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void Door_DirectionCheckCompletedEventHandler(object sender, Door_DirectionCheckCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Door_DirectionCheckCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Door_DirectionCheckCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Result Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Result)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591