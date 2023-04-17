using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.BaseImpl.EF;

namespace NonPersistentListView.Module {
    [DefaultClassOptions]
    public class Book : BaseObject {

        public virtual string Title { get; set; }
    }
}
