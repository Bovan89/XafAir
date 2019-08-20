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
using DevExpress.ExpressApp.ConditionalAppearance;

namespace XafAir.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DeferredDeletion(false)]
    [XafDisplayName("Самолеты")]
    [Indices("Name")]
    public class Plane : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Plane(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Appearance("CodeHasA", TargetItems = "*", Context = "ListView", FontColor = "Green")]
        public bool CodeHasA()
        {
            if (Code != null && Code.ToUpper().Contains('А'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string _Code;
        [RuleRequiredField]
        [ImmediatePostData]
        [DevExpress.Xpo.DisplayName("Код")]
        public string Code
        {
            get
            {
                return _Code;
            }

            set
            {
                SetPropertyValue<string>(nameof(Code), ref _Code, value);
            }
        }

        private string _Name;
        [RuleRequiredField]
        [Size(200)]
        [DevExpress.Xpo.DisplayName("Обозначение")]
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

        private Airport _Airport;

        [Association]
        [DevExpress.Xpo.DisplayName("Прикрепление")]
        public Airport Airport
        {
            get { return _Airport; }
            set
            {
                SetPropertyValue<Airport>(nameof(Airport), ref _Airport, value);
            }
        }


        [DataSourceProperty("Airport.Pilots")]
        [Association("Plane-Pilot")]
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