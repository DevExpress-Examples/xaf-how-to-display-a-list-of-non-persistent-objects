// Developer Express Code Central Example:
// How to: Invoke a List View for a Non-Persistent Class
// 
// This example demonstrates how to display a List View for non-persistent data.
// The complete description is available in the How to: Invoke a List View for a
// Non-Persistent Class (ms-help://DevExpress.Xaf/CustomDocument3167.htm) help
// topic.
// 
// See
// Also:
// http://www.devexpress.com/scid=E921
// http://www.devexpress.com/scid=K18117
// http://www.devexpress.com/scid=K18083
// http://www.devexpress.com/scid=E911
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E980

using System;
using System.Configuration;
using System.Web.Configuration;
using System.Web;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Web;
using UnboundListView.Module;
using DevExpress.ExpressApp.Xpo;

namespace UnboundListView.Web {
    public class Global : System.Web.HttpApplication {
        public Global() {
            InitializeComponent();
        }
        protected void Application_Start(Object sender, EventArgs e) {
            

#if EASYTEST
			DevExpress.ExpressApp.Web.TestScripts.TestScriptsManager.EasyTestEnabled = true;
			ConfirmationsHelper.IsConfirmationsEnabled = false;
#endif

        }
        protected void Session_Start(Object sender, EventArgs e) {
            WebApplication.SetInstance(Session, new UnboundListViewAspNetApplication());
            
#if EASYTEST
			if(ConfigurationManager.ConnectionStrings["EasyTestConnectionString"] != null) {
				WebApplication.Instance.ConnectionString = ConfigurationManager.ConnectionStrings["EasyTestConnectionString"].ConnectionString;
			}
#endif
            InMemoryDataStoreProvider.Register();
            WebApplication.Instance.ConnectionString = InMemoryDataStoreProvider.ConnectionString;
            WebApplication.Instance.Setup();
            WebApplication.Instance.Start();
        }
        protected void Application_BeginRequest(Object sender, EventArgs e) {
            string filePath = HttpContext.Current.Request.PhysicalPath;
            if(!string.IsNullOrEmpty(filePath)
                && (filePath.IndexOf("Images") >= 0) && !System.IO.File.Exists(filePath)) {
                HttpContext.Current.Response.End();
            }
        }
        protected void Application_EndRequest(Object sender, EventArgs e) {
        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e) {
        }
        protected void Application_Error(Object sender, EventArgs e) {
            ErrorHandling.Instance.ProcessApplicationError();
        }
        protected void Session_End(Object sender, EventArgs e) {
            WebApplication.DisposeInstance(Session);
        }
        protected void Application_End(Object sender, EventArgs e) {
        }
        #region Web Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
        }
        #endregion
    }
}
