using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.XtraReports.UI;
using XafAir.Module.BusinessObjects;

namespace XafAir.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ReportController : ViewController
    {
        public ReportController()
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

        private void actionReportPilots_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            IObjectSpace objectSpace = ReportDataProvider.ReportObjectSpaceProvider.CreateObjectSpace(typeof(ReportDataV2));
            IReportDataV2 reportData = objectSpace.FindObject<ReportDataV2>(CriteriaOperator.Parse("[DisplayName] = 'Пилоты самолеты'"));
            string handle = ReportDataProvider.ReportsStorage.GetReportContainerHandle(reportData);
            ReportServiceController controller = Frame.GetController<ReportServiceController>();

            CriteriaOperator criteriaId = null;
            if (View.Id == "Pilot_DetailView" && View.SelectedObjects.Count == 1)
            {                
                criteriaId = CriteriaOperator.Parse("[Oid] = ?", ((Pilot)View.SelectedObjects[0]).Oid.ToString());                
            }
            
            if (controller != null)
            {
                controller.ShowPreview(handle, criteriaId);
            }
        }
    }
}
