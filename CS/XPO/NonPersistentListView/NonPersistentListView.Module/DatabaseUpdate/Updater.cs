using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using System.Xml.Linq;

namespace NonPersistentListView.Module.DatabaseUpdate;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
public class Updater : ModuleUpdater {
    public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
        base(objectSpace, currentDBVersion) {
    }
    public override void UpdateDatabaseAfterUpdateSchema() {
        base.UpdateDatabaseAfterUpdateSchema();
        //string name = "MyName";
        //DomainObject1 theObject = ObjectSpace.FirstOrDefault<DomainObject1>(u => u.Name == name);
        //if(theObject == null) {
        //    theObject = ObjectSpace.CreateObject<DomainObject1>();
        //    theObject.Name = name;
        //}

        var cnt = ObjectSpace.GetObjectsCount(typeof(Book), null);
        if(cnt>0) {
            return;
        }

        Book bookOne = ObjectSpace.CreateObject<Book>();
        bookOne.Title = "A Visitor For Bear";

        Book bookTwo = ObjectSpace.CreateObject<Book>();
        bookTwo.Title = "Dirt on My Shirt";

        Book bookThree = ObjectSpace.CreateObject<Book>();
        bookThree.Title = "Bats at the Library";

        Book bookFour = ObjectSpace.CreateObject<Book>();
        bookFour.Title = "Fancy Nancy at the Museum";

        Book bookFive = ObjectSpace.CreateObject<Book>();
        bookFive.Title = "Fancy Nancy at the Museum";

        Book bookSix = ObjectSpace.CreateObject<Book>();
        bookSix.Title = "Bats at the Library";

        Book bookSeven = ObjectSpace.CreateObject<Book>();
        bookSeven.Title = "Bats at the Library";
        ObjectSpace.CommitChanges(); //Uncomment this line to persist created object(s).
    }
    public override void UpdateDatabaseBeforeUpdateSchema() {
        base.UpdateDatabaseBeforeUpdateSchema();
        //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
        //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
        //}
    }
}
