using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

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
