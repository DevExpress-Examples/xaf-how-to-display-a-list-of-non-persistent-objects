Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Xpo
' Developer Express Code Central Example:
' How to: Invoke a List View for a Non-Persistent Class
' 
' This example demonstrates how to display a List View for non-persistent data.
' The complete description is available in the How to: Invoke a List View for a
' Non-Persistent Class (ms-help://DevExpress.Xaf/CustomDocument3167.htm) help
' topic.
' 
' See
' Also:
' http://www.devexpress.com/scid=E921
' http://www.devexpress.com/scid=K18117
' http://www.devexpress.com/scid=K18083
' http://www.devexpress.com/scid=E911
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E980

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web

Namespace UnboundListView.Web
    Partial Public Class UnboundListViewAspNetApplication
        Inherits WebApplication

        Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
            args.ObjectSpaceProviders.Add(New XPObjectSpaceProvider(args.ConnectionString, args.Connection))
            args.ObjectSpaceProviders.Add(New NonPersistentObjectSpaceProvider(TypesInfo, Nothing))
        End Sub
        Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
        Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
        Private module3 As UnboundListView.Module.UnboundListViewModule
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub UnboundListViewAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles Me.DatabaseVersionMismatch
            e.Updater.Update()
            e.Handled = True
        End Sub

        Private Sub InitializeComponent()
            Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
            Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
            Me.module3 = New UnboundListView.Module.UnboundListViewModule()
            DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            ' 
            ' UnboundListViewAspNetApplication
            ' 
            Me.ApplicationName = "UnboundListView"
            Me.Modules.Add(Me.module1)
            Me.Modules.Add(Me.module2)
            Me.Modules.Add(Me.module3)
            DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
    End Class
End Namespace
