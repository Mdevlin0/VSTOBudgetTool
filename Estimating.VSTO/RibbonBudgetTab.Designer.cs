namespace Estimating.VSTO
{
    partial class RibbonBudgetTab : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonBudgetTab()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonBudgetTab));
            this.BudgetTab = this.Factory.CreateRibbonTab();
            this.ExportGroup = this.Factory.CreateRibbonGroup();
            this.btnSaveEstimateToDatabase = this.Factory.CreateRibbonButton();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.btnImportFieldReport = this.Factory.CreateRibbonButton();
            this.btnSaveCompletedReport = this.Factory.CreateRibbonButton();
            this.BudgetTab.SuspendLayout();
            this.ExportGroup.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BudgetTab
            // 
            this.BudgetTab.Groups.Add(this.ExportGroup);
            this.BudgetTab.Groups.Add(this.group1);
            this.BudgetTab.Label = "Budget";
            this.BudgetTab.Name = "BudgetTab";
            // 
            // ExportGroup
            // 
            this.ExportGroup.Items.Add(this.btnSaveEstimateToDatabase);
            this.ExportGroup.Label = "Estimate";
            this.ExportGroup.Name = "ExportGroup";
            // 
            // btnSaveEstimateToDatabase
            // 
            this.btnSaveEstimateToDatabase.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnSaveEstimateToDatabase.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveEstimateToDatabase.Image")));
            this.btnSaveEstimateToDatabase.Label = "Save Estimate";
            this.btnSaveEstimateToDatabase.Name = "btnSaveEstimateToDatabase";
            this.btnSaveEstimateToDatabase.ShowImage = true;
            this.btnSaveEstimateToDatabase.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSaveEstimateToDatabase_Click);
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnImportFieldReport);
            this.group1.Items.Add(this.btnSaveCompletedReport);
            this.group1.Label = "Report";
            this.group1.Name = "group1";
            // 
            // btnImportFieldReport
            // 
            this.btnImportFieldReport.Image = ((System.Drawing.Image)(resources.GetObject("btnImportFieldReport.Image")));
            this.btnImportFieldReport.Label = "Select Field Report";
            this.btnImportFieldReport.Name = "btnImportFieldReport";
            this.btnImportFieldReport.ShowImage = true;
            this.btnImportFieldReport.SuperTip = "Upload a Field Report";
            this.btnImportFieldReport.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnImportFieldReport_Click);
            // 
            // btnSaveCompletedReport
            // 
            this.btnSaveCompletedReport.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveCompletedReport.Image")));
            this.btnSaveCompletedReport.Label = "Export Results";
            this.btnSaveCompletedReport.Name = "btnSaveCompletedReport";
            this.btnSaveCompletedReport.ShowImage = true;
            this.btnSaveCompletedReport.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSaveCompletedReport_Click);
            // 
            // RibbonBudgetTab
            // 
            this.Name = "RibbonBudgetTab";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.BudgetTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonBudgetTab_Load);
            this.BudgetTab.ResumeLayout(false);
            this.BudgetTab.PerformLayout();
            this.ExportGroup.ResumeLayout(false);
            this.ExportGroup.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab BudgetTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup ExportGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnImportFieldReport;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSaveEstimateToDatabase;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSaveCompletedReport;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonBudgetTab RibbonBudgetTab
        {
            get { return this.GetRibbon<RibbonBudgetTab>(); }
        }
    }
}
