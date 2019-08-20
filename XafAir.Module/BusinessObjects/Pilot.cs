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
using System.IO;
using System.Reflection;
using System.Configuration;

namespace XafAir.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DeferredDeletion(false)]
    [XafDisplayName("Пилоты")]
    [DefaultProperty("Name")]
    [Indices("Name")]
    public class Pilot : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Pilot(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        protected override void OnSaved()
        {           
            base.OnSaved();            
        }

        protected override void OnSaving()
        {
            if (!this.IsDeleted)
            {
                CheckOnSaved();
            }
            base.OnSaving();
        }

        public void CheckOnSaved()
        {
            //string strSomePath = @"AirDLL.dll";
            AppSettingsReader s = new AppSettingsReader();
            string strSomePath = (string)s.GetValue("AirDLLPath", typeof(string));
            string nameSpace = @"AirDLL";
            string className = @"PilotCheck";
            string strMethodName = @"CheckPilotPlanes";
            object classInst;

            string strDllPath = Path.GetFullPath(strSomePath);
            if (File.Exists(strDllPath))
            {                
                Assembly DLL = Assembly.LoadFrom(strDllPath);
                Type classType = DLL.GetType(String.Format("{0}.{1}", nameSpace, className));
                if (classType != null)
                {            
                    classInst = Activator.CreateInstance(classType);
                    MethodInfo methodInfo = classType.GetMethod(strMethodName);
                    if (methodInfo != null)
                    {
                        object result = null;
                        result = methodInfo.Invoke(classInst, new object[] { this.Planes.ToList<Plane>() });                        
                    }
                }
            }
        }

        private string _Name;
        [RuleRequiredField]
        [DevExpress.Xpo.DisplayName("ФИО")]
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
        
        [DevExpress.Xpo.DisplayName("Кол-во самолетов (работает в обоих режимах)")]
        [VisibleInDetailView(false)]
        [PersistentAlias("[Planes].Count()")]
        public int Count
        {
            get
            {
                return Convert.ToInt32(EvaluateAlias("Count"));                
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

        [DataSourceProperty("Airport.Planes")]
        [Association("Plane-Pilot")]
        [DevExpress.Xpo.DisplayName("Самолеты")]
        public XPCollection<Plane> Planes
        {
            get
            {
                return GetCollection<Plane>(nameof(Planes));
            }
        }
    }
}