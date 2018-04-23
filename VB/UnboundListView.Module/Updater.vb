Imports System

Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.BaseImpl

Namespace UnboundListView.Module
    Public Class Updater
        Inherits ModuleUpdater

        Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
            MyBase.New(objectSpace, currentDBVersion)
        End Sub
        Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
            MyBase.UpdateDatabaseAfterUpdateSchema()

            Dim bookOne As Book = ObjectSpace.CreateObject(Of Book)()
            bookOne.Title = "A Visitor For Bear"
            bookOne.Save()

            Dim bookTwo As Book = ObjectSpace.CreateObject(Of Book)()
            bookTwo.Title = "Dirt on My Shirt"
            bookTwo.Save()

            Dim bookThree As Book = ObjectSpace.CreateObject(Of Book)()
            bookThree.Title = "Bats at the Library"
            bookThree.Save()

            Dim bookFour As Book = ObjectSpace.CreateObject(Of Book)()
            bookFour.Title = "Fancy Nancy at the Museum"
            bookFour.Save()

            Dim bookFive As Book = ObjectSpace.CreateObject(Of Book)()
            bookFive.Title = "Fancy Nancy at the Museum"
            bookFive.Save()

            Dim bookSix As Book = ObjectSpace.CreateObject(Of Book)()
            bookSix.Title = "Bats at the Library"
            bookSix.Save()

            Dim bookSeven As Book = ObjectSpace.CreateObject(Of Book)()
            bookSeven.Title = "Bats at the Library"
            bookSeven.Save()
        End Sub
    End Class
End Namespace
