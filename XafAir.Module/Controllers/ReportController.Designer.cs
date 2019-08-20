namespace XafAir.Module.Controllers
{
    partial class ReportController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.actionReportPilots = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // actionReportPilots
            // 
            this.actionReportPilots.Caption = "Отчет \"Пилоты\"";
            this.actionReportPilots.ConfirmationMessage = null;
            this.actionReportPilots.Id = "actionReportPilots";
            this.actionReportPilots.ImageName = "BO_Unknown";
            this.actionReportPilots.TargetViewId = "Pilot_ListView;Pilot_DetailView";
            this.actionReportPilots.ToolTip = null;
            this.actionReportPilots.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.actionReportPilots_Execute);
            // 
            // ReportController
            // 
            this.Actions.Add(this.actionReportPilots);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction actionReportPilots;
    }
}
