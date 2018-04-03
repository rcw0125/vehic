namespace VehIC_WF.GoodsSite
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;

    [DebuggerStepThrough, GeneratedCode("System.Web.Services", "2.0.50727.1433"), DesignerCategory("code")]
    public class HaveNectRecCompletedEventArgs : AsyncCompletedEventArgs
    {
        private object[] results;

        internal HaveNectRecCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
        {
            this.results = results;
        }

        public bool Result
        {
            get
            {
                base.RaiseExceptionIfNecessary();
                return (bool) this.results[0];
            }
        }
    }
}

