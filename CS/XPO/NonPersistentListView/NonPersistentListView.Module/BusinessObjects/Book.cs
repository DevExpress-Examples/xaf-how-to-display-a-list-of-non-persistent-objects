using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace NonPersistentListView.Module {
    [DefaultClassOptions]
    public class Book :BaseObject {
        public Book(Session session) : base(session) { }
        public string Title {
            get { return GetPropertyValue<string>(nameof(Title)); }
            set { SetPropertyValue<string>(nameof(Title), value); }
        }
    }
}
