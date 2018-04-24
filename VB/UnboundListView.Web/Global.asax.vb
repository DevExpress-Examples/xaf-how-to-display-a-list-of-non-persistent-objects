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
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Web

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Web
Imports UnboundListView.Module
Imports DevExpress.ExpressApp.Xpo

Namespace UnboundListView.Web
    Public Class [Global]
        Inherits System.Web.HttpApplication

        Public Sub New()
            InitializeComponent()
        End Sub
        Protected Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)


#If EASYTEST Then
            DevExpress.ExpressApp.Web.TestScripts.TestScriptsManager.EasyTestEnabled = True
            ConfirmationsHelper.IsConfirmationsEnabled = False
#End If

        End Sub
        Protected Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
            WebApplication.SetInstance(Session, New UnboundListViewAspNetApplication())

#If EASYTEST Then
            If ConfigurationManager.ConnectionStrings("EasyTestConnectionString") IsNot Nothing Then
                WebApplication.Instance.ConnectionString = ConfigurationManager.ConnectionStrings("EasyTestConnectionString").ConnectionString
            End If
#End If
            InMemoryDataStoreProvider.Register()
            WebApplication.Instance.ConnectionString = InMemoryDataStoreProvider.ConnectionString
            WebApplication.Instance.Setup()
            WebApplication.Instance.Start()
        End Sub
        Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
            Dim filePath As String = HttpContext.Current.Request.PhysicalPath
            If Not String.IsNullOrEmpty(filePath) AndAlso (filePath.IndexOf("Images") >= 0) AndAlso Not System.IO.File.Exists(filePath) Then
                HttpContext.Current.Response.End()
            End If
        End Sub
        Protected Sub Application_EndRequest(ByVal sender As Object, ByVal e As EventArgs)
        End Sub
        Protected Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        End Sub
        Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
            ErrorHandling.Instance.ProcessApplicationError()
        End Sub
        Protected Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
            WebApplication.DisposeInstance(Session)
        End Sub
        Protected Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        End Sub
        #Region "Web Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
        End Sub
        #End Region
    End Class
End Namespace
