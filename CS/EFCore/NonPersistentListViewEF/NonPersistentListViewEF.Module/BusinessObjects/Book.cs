using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;

namespace NonPersistentListView.Module {
    [DefaultClassOptions]
    public class Book : BaseObject {
        public virtual string Title { get; set; }
    }
}
