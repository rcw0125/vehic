namespace VehIC_WF.AuthService
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

    [GeneratedCode("System.Web.Services", "2.0.50727.42"), WebServiceBinding(Name="AuthServiceSoap", Namespace="http://www.lfy.com/"), DebuggerStepThrough, DesignerCategory("code")]
    public class AuthService : SoapHttpClientProtocol
    {
        private SendOrPostCallback ChangePasswordOperationCompleted;
        private SendOrPostCallback CheckAuthorityOperationCompleted;
        private SendOrPostCallback GetUserIDByCardIDOperationCompleted;
        private SendOrPostCallback GetUserInfoOperationCompleted;
        private bool useDefaultCredentialsSetExplicitly;

        public event ChangePasswordCompletedEventHandler ChangePasswordCompleted;

        public event CheckAuthorityCompletedEventHandler CheckAuthorityCompleted;

        public event GetUserIDByCardIDCompletedEventHandler GetUserIDByCardIDCompleted;

        public event GetUserInfoCompletedEventHandler GetUserInfoCompleted;

        public AuthService()
        {
            this.Url = Settings.Default.VehIC_WF_AuthService_AuthService;
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

        [SoapDocumentMethod("http://www.lfy.com/ChangePassword", RequestNamespace="http://www.lfy.com/", ResponseNamespace="http://www.lfy.com/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public int ChangePassword(string userid, string newpass)
        {
            return (int) base.Invoke("ChangePassword", new object[] { userid, newpass })[0];
        }

        public void ChangePasswordAsync(string userid, string newpass)
        {
            this.ChangePasswordAsync(userid, newpass, null);
        }

        public void ChangePasswordAsync(string userid, string newpass, object userState)
        {
            if (this.ChangePasswordOperationCompleted == null)
            {
                this.ChangePasswordOperationCompleted = new SendOrPostCallback(this.OnChangePasswordOperationCompleted);
            }
            base.InvokeAsync("ChangePassword", new object[] { userid, newpass }, this.ChangePasswordOperationCompleted, userState);
        }

        [SoapDocumentMethod("http://www.lfy.com/CheckAuthority", RequestNamespace="http://www.lfy.com/", ResponseNamespace="http://www.lfy.com/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public string CheckAuthority(string wpcode, string uid, string authname, string billno, bool iszlk)
        {
            return (string) base.Invoke("CheckAuthority", new object[] { wpcode, uid, authname, billno, iszlk })[0];
        }

        public void CheckAuthorityAsync(string wpcode, string uid, string authname, string billno, bool iszlk)
        {
            this.CheckAuthorityAsync(wpcode, uid, authname, billno, iszlk, null);
        }

        public void CheckAuthorityAsync(string wpcode, string uid, string authname, string billno, bool iszlk, object userState)
        {
            if (this.CheckAuthorityOperationCompleted == null)
            {
                this.CheckAuthorityOperationCompleted = new SendOrPostCallback(this.OnCheckAuthorityOperationCompleted);
            }
            base.InvokeAsync("CheckAuthority", new object[] { wpcode, uid, authname, billno, iszlk }, this.CheckAuthorityOperationCompleted, userState);
        }

        [SoapDocumentMethod("http://www.lfy.com/GetUserIDByCardID", RequestNamespace="http://www.lfy.com/", ResponseNamespace="http://www.lfy.com/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public string GetUserIDByCardID(string cardid)
        {
            return (string) base.Invoke("GetUserIDByCardID", new object[] { cardid })[0];
        }

        public void GetUserIDByCardIDAsync(string cardid)
        {
            this.GetUserIDByCardIDAsync(cardid, null);
        }

        public void GetUserIDByCardIDAsync(string cardid, object userState)
        {
            if (this.GetUserIDByCardIDOperationCompleted == null)
            {
                this.GetUserIDByCardIDOperationCompleted = new SendOrPostCallback(this.OnGetUserIDByCardIDOperationCompleted);
            }
            base.InvokeAsync("GetUserIDByCardID", new object[] { cardid }, this.GetUserIDByCardIDOperationCompleted, userState);
        }

        [SoapDocumentMethod("http://www.lfy.com/GetUserInfo", RequestNamespace="http://www.lfy.com/", ResponseNamespace="http://www.lfy.com/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public UserInfo GetUserInfo(string uid)
        {
            return (UserInfo) base.Invoke("GetUserInfo", new object[] { uid })[0];
        }

        public void GetUserInfoAsync(string uid)
        {
            this.GetUserInfoAsync(uid, null);
        }

        public void GetUserInfoAsync(string uid, object userState)
        {
            if (this.GetUserInfoOperationCompleted == null)
            {
                this.GetUserInfoOperationCompleted = new SendOrPostCallback(this.OnGetUserInfoOperationCompleted);
            }
            base.InvokeAsync("GetUserInfo", new object[] { uid }, this.GetUserInfoOperationCompleted, userState);
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

        private void OnChangePasswordOperationCompleted(object arg)
        {
            if (this.ChangePasswordCompleted != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) arg;
                this.ChangePasswordCompleted(this, new ChangePasswordCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnCheckAuthorityOperationCompleted(object arg)
        {
            if (this.CheckAuthorityCompleted != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) arg;
                this.CheckAuthorityCompleted(this, new CheckAuthorityCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnGetUserIDByCardIDOperationCompleted(object arg)
        {
            if (this.GetUserIDByCardIDCompleted != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) arg;
                this.GetUserIDByCardIDCompleted(this, new GetUserIDByCardIDCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
            }
        }

        private void OnGetUserInfoOperationCompleted(object arg)
        {
            if (this.GetUserInfoCompleted != null)
            {
                InvokeCompletedEventArgs args = (InvokeCompletedEventArgs) arg;
                this.GetUserInfoCompleted(this, new GetUserInfoCompletedEventArgs(args.Results, args.Error, args.Cancelled, args.UserState));
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

