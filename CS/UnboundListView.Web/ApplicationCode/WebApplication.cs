using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
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
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Web;

namespace UnboundListView.Web {
    public partial class UnboundListViewAspNetApplication : WebApplication {
        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args) {
            args.ObjectSpaceProvider = new XPObjectSpaceProvider(args.ConnectionString, args.Connection);
        }
        private DevExpress.ExpressApp.SystemModule.SystemModule module1;
        private DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule module2;
        private UnboundListView.Module.UnboundListViewModule module3;        
        public UnboundListViewAspNetApplication() {
            InitializeComponent();
        }

        private void UnboundListViewAspNetApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
            e.Updater.Update();
            e.Handled = true;
        }

        private void InitializeComponent() {
            this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
            this.module2 = new DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule();
            this.module3 = new UnboundListView.Module.UnboundListViewModule();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // UnboundListViewAspNetApplication
            // 
            this.ApplicationName = "UnboundListView";
            this.Modules.Add(this.module1);
            this.Modules.Add(this.module2);
            this.Modules.Add(this.module3);
            this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.UnboundListViewAspNetApplication_DatabaseVersionMismatch);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }
}
