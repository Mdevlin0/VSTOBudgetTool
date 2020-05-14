using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;

namespace Estimating.VSTO
{
    public partial class RibbonBudgetTab
    {
        private void RibbonBudgetTab_Load(object sender, RibbonUIEventArgs e)
        {
        }

        /// <summary>
        /// Opens a file dialog window for the user to select the CSV Field Report that will processed.
        /// </summary>
        /// <remarks>
        /// Uses CSV filter because validation of file extensions has not currently been implemented in the processing
        /// methods.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportFieldReport_Click(object sender, RibbonControlEventArgs e)
        {
            OpenFileDialog ImportFieldReportDialog = new OpenFileDialog()
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Select a Field Report"
            };

            DialogResult importResult = ImportFieldReportDialog.ShowDialog();
            if(importResult == DialogResult.OK)
            {
                string selectedFile = ImportFieldReportDialog.FileName;
                //TODO: insert the report processing codes here OR call the main processing method using the captured filepath.
            }
        }

        /// <summary>
        /// Opens a SaveFileDialog to save the current worksheet.
        /// </summary>
        /// <remarks>
        /// Should save the results shown in the current worksheet.  The intended use is for outputting the results that are automatically generated 
        /// when the user uploads a Field Report (the report is automatically run and the results are printed and formatted in a worksheet inside the 
        /// active workbook.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveCompletedReport_Click(object sender, RibbonControlEventArgs e)
        {
            SaveFileDialog SaveCurrentWeeklyReport = new SaveFileDialog()
            {
                Filter = "Excel file (*.xlsx)|*.xlsx",
                Title = "Save As"
            };

            DialogResult saveResult = SaveCurrentWeeklyReport.ShowDialog();
            if(saveResult == DialogResult.OK)
            {
                Globals.ThisAddIn.Application.ActiveWorkbook.SaveCopyAs(SaveCurrentWeeklyReport.FileName);
            }



        }

        /// <summary>
        /// Creates an Estimate record in the database.
        /// </summary>
        /// <remarks>
        /// DATE: 5/14/20
        /// AUTHOR: Noah B
        /// The data from the current estimate sheet must be formatted into the required interface before being committed to the database.  For now, the 
        /// only requirements will be the (minimal) data necessary to run the field report comparisons (see ProgressReporter utility for implementation)
        /// but this will be expanded later to accomodate future data needs.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveEstimateToDatabase_Click(object sender, RibbonControlEventArgs e)
        {
            MessageBox.Show("Saving Estimate Data");
            //TODO: Insert processing methods here OR call to the main processing method.  
        }
    }
}
