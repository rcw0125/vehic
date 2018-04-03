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

namespace VehIC_WF.AuthService {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="AuthServiceSoap", Namespace="http://www.lfy.com/")]
    public partial class AuthService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetUserInfoOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetUserIDByCardIDOperationCompleted;
        
        private System.Threading.SendOrPostCallback ChangePasswordOperationCompleted;
        
        private System.Threading.SendOrPostCallback CheckAuthorityOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public AuthService() {
            this.Url = global::Properties.Settings.Default.VehIC_WF_VehIC_WF_AuthService_AuthService;
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
        public event GetUserInfoCompletedEventHandler GetUserInfoCompleted;
        
        /// <remarks/>
        public event GetUserIDByCardIDCompletedEventHandler GetUserIDByCardIDCompleted;
        
        /// <remarks/>
        public event ChangePasswordCompletedEventHandler ChangePasswordCompleted;
        
        /// <remarks/>
        public event CheckAuthorityCompletedEventHandler CheckAuthorityCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.lfy.com/GetUserInfo", RequestNamespace="http://www.lfy.com/", ResponseNamespace="http://www.lfy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public UserInfo GetUserInfo(string uid) {
            object[] results = this.Invoke("GetUserInfo", new object[] {
                        uid});
            return ((UserInfo)(results[0]));
        }
        
        /// <remarks/>
        public void GetUserInfoAsync(string uid) {
            this.GetUserInfoAsync(uid, null);
        }
        
        /// <remarks/>
        public void GetUserInfoAsync(string uid, object userState) {
            if ((this.GetUserInfoOperationCompleted == null)) {
                this.GetUserInfoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetUserInfoOperationCompleted);
            }
            this.InvokeAsync("GetUserInfo", new object[] {
                        uid}, this.GetUserInfoOperationCompleted, userState);
        }
        
        private void OnGetUserInfoOperationCompleted(object arg) {
            if ((this.GetUserInfoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetUserInfoCompleted(this, new GetUserInfoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.lfy.com/GetUserIDByCardID", RequestNamespace="http://www.lfy.com/", ResponseNamespace="http://www.lfy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetUserIDByCardID(string cardid) {
            object[] results = this.Invoke("GetUserIDByCardID", new object[] {
                        cardid});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetUserIDByCardIDAsync(string cardid) {
            this.GetUserIDByCardIDAsync(cardid, null);
        }
        
        /// <remarks/>
        public void GetUserIDByCardIDAsync(string cardid, object userState) {
            if ((this.GetUserIDByCardIDOperationCompleted == null)) {
                this.GetUserIDByCardIDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetUserIDByCardIDOperationCompleted);
            }
            this.InvokeAsync("GetUserIDByCardID", new object[] {
                        cardid}, this.GetUserIDByCardIDOperationCompleted, userState);
        }
        
        private void OnGetUserIDByCardIDOperationCompleted(object arg) {
            if ((this.GetUserIDByCardIDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetUserIDByCardIDCompleted(this, new GetUserIDByCardIDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.lfy.com/ChangePassword", RequestNamespace="http://www.lfy.com/", ResponseNamespace="http://www.lfy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int ChangePassword(string userid, string newpass) {
            object[] results = this.Invoke("ChangePassword", new object[] {
                        userid,
                        newpass});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void ChangePasswordAsync(string userid, string newpass) {
            this.ChangePasswordAsync(userid, newpass, null);
        }
        
        /// <remarks/>
        public void ChangePasswordAsync(string userid, string newpass, object userState) {
            if ((this.ChangePasswordOperationCompleted == null)) {
                this.ChangePasswordOperationCompleted = new System.Threading.SendOrPostCallback(this.OnChangePasswordOperationCompleted);
            }
            this.InvokeAsync("ChangePassword", new object[] {
                        userid,
                        newpass}, this.ChangePasswordOperationCompleted, userState);
        }
        
        private void OnChangePasswordOperationCompleted(object arg) {
            if ((this.ChangePasswordCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ChangePasswordCompleted(this, new ChangePasswordCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.lfy.com/CheckAuthority", RequestNamespace="http://www.lfy.com/", ResponseNamespace="http://www.lfy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CheckAuthority(string wpcode, string uid, string authname, string billno, bool iszlk) {
            object[] results = this.Invoke("CheckAuthority", new object[] {
                        wpcode,
                        uid,
                        authname,
                        billno,
                        iszlk});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void CheckAuthorityAsync(string wpcode, string uid, string authname, string billno, bool iszlk) {
            this.CheckAuthorityAsync(wpcode, uid, authname, billno, iszlk, null);
        }
        
        /// <remarks/>
        public void CheckAuthorityAsync(string wpcode, string uid, string authname, string billno, bool iszlk, object userState) {
            if ((this.CheckAuthorityOperationCompleted == null)) {
                this.CheckAuthorityOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCheckAuthorityOperationCompleted);
            }
            this.InvokeAsync("CheckAuthority", new object[] {
                        wpcode,
                        uid,
                        authname,
                        billno,
                        iszlk}, this.CheckAuthorityOperationCompleted, userState);
        }
        
        private void OnCheckAuthorityOperationCompleted(object arg) {
            if ((this.CheckAuthorityCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CheckAuthorityCompleted(this, new CheckAuthorityCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public partial class UserInfo {
        
        private string idField;
        
        private string nameField;
        
        private string roleField;
        
        private bool enableField;
        
        private string passWordField;
        
        private string deptField;
        
        private string iCCardIDField;
        
        private string iCCardNoField;
        
        private int iCCardStatusField;
        
        private string workpointlistField;
        
        private string authoritylistField;
        
        /// <remarks/>
        public string ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string Role {
            get {
                return this.roleField;
            }
            set {
                this.roleField = value;
            }
        }
        
        /// <remarks/>
        public bool Enable {
            get {
                return this.enableField;
            }
            set {
                this.enableField = value;
            }
        }
        
        /// <remarks/>
        public string PassWord {
            get {
                return this.passWordField;
            }
            set {
                this.passWordField = value;
            }
        }
        
        /// <remarks/>
        public string Dept {
            get {
                return this.deptField;
            }
            set {
                this.deptField = value;
            }
        }
        
        /// <remarks/>
        public string ICCardID {
            get {
                return this.iCCardIDField;
            }
            set {
                this.iCCardIDField = value;
            }
        }
        
        /// <remarks/>
        public string ICCardNo {
            get {
                return this.iCCardNoField;
            }
            set {
                this.iCCardNoField = value;
            }
        }
        
        /// <remarks/>
        public int ICCardStatus {
            get {
                return this.iCCardStatusField;
            }
            set {
                this.iCCardStatusField = value;
            }
        }
        
        /// <remarks/>
        public string workpointlist {
            get {
                return this.workpointlistField;
            }
            set {
                this.workpointlistField = value;
            }
        }
        
        /// <remarks/>
        public string authoritylist {
            get {
                return this.authoritylistField;
            }
            set {
                this.authoritylistField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void GetUserInfoCompletedEventHandler(object sender, GetUserInfoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetUserInfoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetUserInfoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public UserInfo Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((UserInfo)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void GetUserIDByCardIDCompletedEventHandler(object sender, GetUserIDByCardIDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetUserIDByCardIDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetUserIDByCardIDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void ChangePasswordCompletedEventHandler(object sender, ChangePasswordCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ChangePasswordCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ChangePasswordCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void CheckAuthorityCompletedEventHandler(object sender, CheckAuthorityCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CheckAuthorityCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CheckAuthorityCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
}

#pragma warning restore 1591