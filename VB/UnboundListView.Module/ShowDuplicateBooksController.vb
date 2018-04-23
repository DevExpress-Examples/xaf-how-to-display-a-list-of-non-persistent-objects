Imports System
Imports System.Collections.Generic
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions

Namespace UnboundListView.Module
    Public Class ShowDuplicateBooksController
        Inherits ObjectViewController(Of ListView, Book)

        Public Sub New()
            Dim showDuplicatesAction As New PopupWindowShowAction(Me, "ShowDuplicateBooks", "View")
            AddHandler showDuplicatesAction.CustomizePopupWindowParams, AddressOf showDuplicatesAction_CustomizePopupWindowParams
        End Sub

        Private Sub showDuplicatesAction_CustomizePopupWindowParams(ByVal sender As Object, ByVal e As CustomizePopupWindowParamsEventArgs)
            Dim dictionary As New Dictionary(Of String, Integer)()
            For Each book As Book In View.CollectionSource.List
                If Not String.IsNullOrEmpty(book.Title) Then
                    If dictionary.ContainsKey(book.Title) Then
                        dictionary(book.Title) += 1
                    Else
                        dictionary.Add(book.Title, 1)
                    End If
                End If
            Next book
            Dim duplicateList As New DuplicatesList()
            Dim duplicateId As Integer = 0
            For Each record As KeyValuePair(Of String, Integer) In dictionary
                If record.Value > 1 Then
                    duplicateList.Duplicates.Add(New Duplicate() With {.Id = duplicateId, .Title = record.Key, .Count = record.Value})
                    duplicateId += 1
                End If
            Next record
            e.View = Application.CreateDetailView(Application.CreateObjectSpace(), duplicateList)
            e.DialogController.SaveOnAccept = False
            e.DialogController.CancelAction.Active("NothingToCancel") = False
        End Sub
    End Class
End Namespace
