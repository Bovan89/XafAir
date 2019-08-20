using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace XafAir.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DeferredDeletion(false)]
    [XafDisplayName("Аэропорты")]
    [Indices("Name")]
    public class Airport : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Airport(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private string _Name;
        [RuleRequiredField]
        [RuleUniqueValue]
        [DevExpress.Xpo.DisplayName("Аэропорт")]
        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                SetPropertyValue<string>(nameof(Name), ref _Name, value);
            }
        }

        [DevExpress.Xpo.Aggregated, Association]
        [DevExpress.Xpo.DisplayName("Самолеты")]
        public XPCollection<Plane> Planes
        {
            get
            {
                return GetCollection<Plane>(nameof(Planes));
            }
        }

        [DevExpress.Xpo.Aggregated, Association]
        [DevExpress.Xpo.DisplayName("Пилоты")]
        public XPCollection<Pilot> Pilots
        {
            get
            {
                return GetCollection<Pilot>(nameof(Pilots));
            }
        }
    }
}