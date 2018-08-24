Imports DevExpress.ExpressApp.Xpo
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Win
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.ExpressApp

Namespace UnboundListView.Win
    Partial Public Class UnboundListViewWindowsFormsApplication
        Inherits WinApplication

        Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
            args.ObjectSpaceProviders.Add(New XPObjectSpaceProvider(args.ConnectionString, args.Connection))
            args.ObjectSpaceProviders.Add(New NonPersistentObjectSpaceProvider(TypesInfo, Nothing))
        End Sub
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub UnboundListViewWindowsFormsApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles Me.DatabaseVersionMismatch
            e.Updater.Update()
            e.Handled = True
        End Sub
    End Class
End Namespace
