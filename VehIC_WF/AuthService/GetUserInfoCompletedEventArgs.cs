namespace VehIC_WF.AuthService
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;

    [GeneratedCode("System.Web.Services", "2.0.50727.42"), DebuggerStepThrough, DesignerCategory("code")]
    public class GetUserInfoCompletedEventArgs : AsyncCompletedEventArgs
    {
        private object[] results;

        internal GetUserInfoCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
        {
            this.results = results;
        }

        public UserInfo Result
        {
            get
            {
                base.RaiseExceptionIfNecessary();
                return (UserInfo) this.results[0];
            }
        }
    }
}

