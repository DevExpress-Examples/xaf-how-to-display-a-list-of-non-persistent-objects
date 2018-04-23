using System;
using System.Collections.Generic;

using DevExpress.ExpressApp;
using System.Reflection;


namespace UnboundListView.Module {
    public sealed partial class UnboundListViewModule : ModuleBase {
        public UnboundListViewModule() {
            InitializeComponent();
        }
        public override void CustomizeTypesInfo(DevExpress.ExpressApp.DC.ITypesInfo typesInfo) {
            base.CustomizeTypesInfo(typesInfo);
            var typeInfo = typesInfo.FindTypeInfo(typeof(Duplicate)) as DevExpress.ExpressApp.DC.TypeInfo;
            typeInfo.AddKeyMember(typeInfo.FindMember("Id"));
        }
    }
}