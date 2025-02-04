using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp;

namespace NonPersistentListView.Module {
    [DomainComponent]
    public class Duplicate: NonPersistentBaseObject {
        public string Title { get; set; }
        public int Count { get; set; }
    }
    [DomainComponent]
    public class DuplicatesList: NonPersistentBaseObject {
        private BindingList<Duplicate> duplicates;
        public DuplicatesList() {
            duplicates = new BindingList<Duplicate>();
        }
        public BindingList<Duplicate> Duplicates { get { return duplicates; } }
    }
}
