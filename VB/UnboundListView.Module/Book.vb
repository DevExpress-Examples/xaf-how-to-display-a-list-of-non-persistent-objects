Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace UnboundListView.Module
    <DefaultClassOptions> _
    Public Class Book
        Inherits BaseObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Property Title() As String
            Get
                Return GetPropertyValue(Of String)("Title")
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Title", value)
            End Set
        End Property
    End Class
End Namespace
