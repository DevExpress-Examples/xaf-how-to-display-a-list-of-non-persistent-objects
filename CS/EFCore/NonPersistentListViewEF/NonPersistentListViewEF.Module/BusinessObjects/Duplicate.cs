using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp;

namespace NonPersistentListView.Module {
    [DomainComponent]
    public class Duplicate: NonPersistentLiteObject {
        public string Title { get; set; }
        public int Count { get; set; }
    }
    [DomainComponent]
    public class DuplicatesList: NonPersistentLiteObject {
        private BindingList<Duplicate> duplicates;
        public DuplicatesList() {
            duplicates = new BindingList<Duplicate>();
        }
        public BindingList<Duplicate> Duplicates { get { return duplicates; } }
    }
}
