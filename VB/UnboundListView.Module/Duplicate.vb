Imports System
Imports System.ComponentModel
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp.DC

Namespace UnboundListView.Module
    <DomainComponent> _
    Public Class Duplicate
        <Browsable(False)> _
        Public Id As Integer
        Public Property Title() As String
        Public Property Count() As Integer
    End Class
    <DomainComponent> _
    Public Class DuplicatesList

        Private duplicates_Renamed As BindingList(Of Duplicate)
        Public Sub New()
            duplicates_Renamed = New BindingList(Of Duplicate)()
        End Sub
        Public ReadOnly Property Duplicates() As BindingList(Of Duplicate)
            Get
                Return duplicates_Renamed
            End Get
        End Property
    End Class
End Namespace
