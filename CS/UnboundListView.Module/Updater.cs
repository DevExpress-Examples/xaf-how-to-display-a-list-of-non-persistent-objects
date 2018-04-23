using System;

using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl;

namespace UnboundListView.Module {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();

            Book bookOne = ObjectSpace.CreateObject<Book>();
            bookOne.Title = "A Visitor For Bear";
            bookOne.Save();

            Book bookTwo = ObjectSpace.CreateObject<Book>();
            bookTwo.Title = "Dirt on My Shirt";
            bookTwo.Save();

            Book bookThree = ObjectSpace.CreateObject<Book>();
            bookThree.Title = "Bats at the Library";
            bookThree.Save();

            Book bookFour = ObjectSpace.CreateObject<Book>();
            bookFour.Title = "Fancy Nancy at the Museum";
            bookFour.Save();

            Book bookFive = ObjectSpace.CreateObject<Book>();
            bookFive.Title = "Fancy Nancy at the Museum";
            bookFive.Save();

            Book bookSix = ObjectSpace.CreateObject<Book>();
            bookSix.Title = "Bats at the Library";
            bookSix.Save();

            Book bookSeven = ObjectSpace.CreateObject<Book>();
            bookSeven.Title = "Bats at the Library";
            bookSeven.Save();            
        }
    }
}
