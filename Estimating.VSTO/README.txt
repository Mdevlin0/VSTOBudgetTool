DATE: 4/20/20
AUTHORS: Noah B, Mike D
ABSTRACT: Contains notes and specifications for the Budget Tracking VSTO project. 

OVERVIEW: 

	1.  The users receives a weekly report from the field OR produces the report themselves by exporting markup data from Bluebeam into a CSV/Excel object.  This is the entry point for the BudgetTracker.
	2.  The critical fields in the weekly report are: 
															PhaseCode
															SystemName

	3.  A separate data object will be composed from the existing Estimate for the project, of which the VSTO will be aware. The critical data from the Estimate sheet include the same data from the
		weekly report. 
	4.  The values of the Estimate object are compared to the values of the WeeklyReport object to determine the following: 
							
															PercentComplete (by equipment system)
															CompletedHours (by phase code)

	5.  The results of the comparison are used as inputs to the SummaryReport created by the Estimating department. 
	6.  BudgetTracker prints the report, updates any data stores that we might wish to update, and logs the report summary into two areas: the local computer and a secure location on the network (or some
		other place where the data has the potential to be analyzed in the future).

USAGE: 


	ESTIMATING DEPARTMENT 
	
	The role of the estimating department is to commit the estimate sheet to the database.  This can happen once, or it can happen each time there's a change.  No matter what, it needs to happen before 
	any weekly report is processed, since the data record is what the report will be compared to.  Once the data has been committed, the role of the estimating person is optional for any subsequent
	process. 


	PM/APM TEAM

	The role of the team is to procure and process the weekly report in Excel.  Whether the field sends the report or it is exported from the Bluebeam markups should be irrelevant.  Also, the tool 
	should be equally capable of handling CSV and any common Excel file type (.xlsx, .xlsm).  The PM/APM person will open the report, navigate to the VSTO ribbon, and push the button to begin the process.

	If the proces uses a dialogue with the user (suggested), then the user proceeds through the steps until all the validation requirements are met and the report can be processed.  The output of the 
	report is undecided at this time.  Several good suggestions exist and it is likely that the final output will be a combination of some of these.  


NOTES: 

	The architecture has been outlined in the project document titled 'Use Cases of the Budget Tracking Tool'.  

	DEPLOYMENT
	Google "Microsoft Visual Studio Tools for the Office System Power Tools".  Download and install the 'VSTO_PT.exe' file. 

	When preparing the drawings with the systems, it is very important that the system names match.  When they DON'T match, a feature must be included to update the 
	database source (via the Estimating sheet) to correct the error.  
