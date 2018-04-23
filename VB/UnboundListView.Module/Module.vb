Imports System
Imports System.Collections.Generic

Imports DevExpress.ExpressApp
Imports System.Reflection


Namespace UnboundListView.Module
    Public NotInheritable Partial Class UnboundListViewModule
        Inherits ModuleBase

        Public Sub New()
            InitializeComponent()
        End Sub
        Public Overrides Sub CustomizeTypesInfo(ByVal typesInfo As DevExpress.ExpressApp.DC.ITypesInfo)
            MyBase.CustomizeTypesInfo(typesInfo)
            Dim typeInfo = TryCast(typesInfo.FindTypeInfo(GetType(Duplicate)), DevExpress.ExpressApp.DC.TypeInfo)
            typeInfo.AddKeyMember(typeInfo.FindMember("Id"))
        End Sub
    End Class
End Namespace