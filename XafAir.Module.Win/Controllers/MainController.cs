using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Win;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using XafAir.Module.BusinessObjects;

namespace XafAir.Module.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class MainController : ViewController
    {
        public MainController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        void refresh()
        {
            foreach (WinWindow win in (Application.ShowViewStrategy as DevExpress.ExpressApp.Win.MdiShowViewStrategy).Windows.ToArray())
            {
                if (win.View != null)
                {
                    if (win.View.Model is IModelDetailView)
                        //.GetType().Name == "DetailView")
                    {
                        win.Close();
                    }
                    else
                    {
                        win.View.RefreshDataSource();
                    }
                }
            }
        }

        //void closeOther()
        //{
        //    foreach (WinWindow win in (Application.ShowViewStrategy as DevExpress.ExpressApp.Win.MdiShowViewStrategy).Windows.ToArray())
        //    {
        //        if (!win.IsMain)
        //        {
        //            win.Close();
        //        }
        //    }
        //}

        Airport createAirport(string name)
        {
            Airport a = View.ObjectSpace.CreateObject<Airport>();
            a.Name = name;
            a.Save();
            return a;
        }

        Plane createPlane(string code, string name, Airport a)
        {
            Plane p = View.ObjectSpace.CreateObject<Plane>();
            p.Code = code;
            p.Name = name;
            p.Save();

            a.Planes.Add(p);

            return p;
        }

        Pilot createPilot(string name, Airport a, params Plane[] p)
        {
            Pilot pil = View.ObjectSpace.CreateObject<Pilot>();
            pil.Name = name;
            pil.Save();

            a.Pilots.Add(pil);

            foreach (var pl in p)
            {
                pil.Planes.Add(pl);
            }

            return pil;
        }

        void fillDB()
        {
            //Очистить
            View.ObjectSpace.Delete(View.ObjectSpace.GetObjects<Plane>());
            View.ObjectSpace.Delete(View.ObjectSpace.GetObjects<Pilot>());
            View.ObjectSpace.Delete(View.ObjectSpace.GetObjects<Airport>());
            View.ObjectSpace.CommitChanges();            

            //Создать
            Airport a;
            Plane p, p1, p2;      

            a = createAirport("Big Savino");
            p = createPlane("SAM1", "TU-154", a);
            p1 = createPlane("SAM2", "MIG-31", a);
            createPilot("Ivanov", a, p);
            createPilot("Kojedub", a, p, p1);

            a = createAirport("Domodedovo");
            p = createPlane("1", "TU-154", a);
            p1 = createPlane("2", "Boeing-123", a);
            p2 = createPlane("3", "Boeing-321", a);
            createPilot("Semenov", a, p);
            createPilot("Monetkin", a, p, p1, p2);
            createPilot("Lopatina", a, p2);
            createPilot("Gushin", a, p);
            createPilot("Utkin", a, p);
            createPilot("Proklov", a, p);
            createPilot("Titov", a, p);
            createPilot("Konev", a, p);
            createPilot("Janichar", a, p);
            createPilot("Ushliy", a, p);
            createPilot("Del Piero", a, p);
            createPilot("Vasja", a, p);

            a = createAirport("Froli");
            p = createPlane("F1", "SU-11", a);            
            createPilot("Jankovich", a, p);            

            View.ObjectSpace.CommitChanges();      
            refresh();
        }


        private void actionDBFill_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            fillDB();

            refresh();            
        }

        private void actionChangeAccessMode_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            IModelListView m = (IModelListView)View.Model;
            if (m.DataAccessMode == CollectionSourceDataAccessMode.Server)
            {
                m.DataAccessMode = CollectionSourceDataAccessMode.Client;
            }
            else
            {
                m.DataAccessMode = CollectionSourceDataAccessMode.Server;
            }            
        }
    }
}
