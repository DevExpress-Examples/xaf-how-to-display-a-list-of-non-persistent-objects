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
            Dim nonPersistentOS = Application.CreateObjectSpace(GetType(DuplicatesList))
            Dim duplicateList = nonPersistentOS.CreateObject(Of DuplicatesList)()
            Dim duplicateId As Integer = 0
            For Each record As KeyValuePair(Of String, Integer) In dictionary
                If record.Value > 1 Then
                    Dim dup = nonPersistentOS.CreateObject(Of Duplicate)()
                    dup.Id = duplicateId
                    dup.Title = record.Key
                    dup.Count = record.Value
                    duplicateList.Duplicates.Add(dup)
                    duplicateId += 1
                End If
            Next record
            nonPersistentOS.CommitChanges()
            e.View = Application.CreateDetailView(nonPersistentOS, duplicateList)
            e.DialogController.SaveOnAccept = False
            e.DialogController.CancelAction.Active("NothingToCancel") = False
        End Sub
    End Class
End Namespace
