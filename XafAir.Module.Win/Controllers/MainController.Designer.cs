namespace XafAir.Module.Win.Controllers
{
    partial class MainController
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
            this.actionDBFill = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.actionChangeAccessMode = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // actionDBFill
            // 
            this.actionDBFill.Caption = "Наполнение БД";
            this.actionDBFill.ConfirmationMessage = null;
            this.actionDBFill.Id = "actionDBFill";
            this.actionDBFill.ImageName = "BO_Unknown";
            this.actionDBFill.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.actionDBFill.ToolTip = null;
            this.actionDBFill.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.actionDBFill.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.actionDBFill_Execute);
            // 
            // actionChangeAccessMode
            // 
            this.actionChangeAccessMode.Caption = "Переключить режим Клиент/Сервер";
            this.actionChangeAccessMode.ConfirmationMessage = null;
            this.actionChangeAccessMode.Id = "actionChangeAccessMode";
            this.actionChangeAccessMode.ImageName = "BO_Unknown";
            this.actionChangeAccessMode.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.actionChangeAccessMode.ToolTip = null;
            this.actionChangeAccessMode.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.actionChangeAccessMode.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.actionChangeAccessMode_Execute);
            // 
            // MainController
            // 
            this.Actions.Add(this.actionDBFill);
            this.Actions.Add(this.actionChangeAccessMode);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction actionDBFill;
        private DevExpress.ExpressApp.Actions.SimpleAction actionChangeAccessMode;
    }
}
