using Estimating.ProgressReporter.Interfaces.Model;
using Estimating.ProgressReporter.Model;
using Estimating.ProgressReporter.Services;
using Estimating.PseudoDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebuggerControl
{
    /// <summary>
    /// A simple console app to run simulations on the main project
    /// </summary>
    /// <remarks>
    /// 4/22/20
    /// NOTES: Below is a completed test of the comparison and reporting functionality.  Please reference the VSTO diagram illustrating the core 
    /// functionality titled "VSTOBudgetTracker", located in the Documentation folder of 'Estimating.VSTO'.  Here's a quick summary of what's shown
    /// in that document: 
    ///     
    ///     1. The information for each equipment system is stored in a "SystemEstimate" object that is kept in the database.  
    ///     2. A report is received from the field and contains information about the field work performed on the equipment systems.  This report 
    ///        could cover all the systems for the project or only a few.  For each system that is reported on, the information is stored in a 
    ///        "SystemReport" object.  At this point, there will be two data object for the same system - one "SystemEstimate" and 
    ///        one "SystemReport".
    ///     3. Once SystemReport objects have been created for every system included in the report, all the SystemReports are gathered together in 
    ///        the "ReportModel".  The EstimateModel is also created at this time; it holds a SystemEstimate object for each system.
    ///     4. Both Models are sent to ModelReportingService, whose job is to perform the desired data comparisons and make those results available 
    ///        to the user.
    ///     5. The ModelReportingService presents the results as Lists of system objects, each of which can be queried further for its specific 
    ///        information.
    ///     6. There are two types of object lists returned by the ModelReportingService and they correspond with two categories of equipment 
    ///        system: those that are included in the field report and those that are not.  For those NOT included, no data checking occurs and
    ///        they are returned by the ModelReportingService via a List of "SystemEstimate" objects (since nothing changed).  For those that 
    ///        WERE included, the ModelReportingService returns the results via a list of "ComparatorResult" objects.  Please see the class 
    ///        definition of ComparatorResult for a list of what information it contains. 
    ///   
    /// The test code below will simulate this process.  
    /// 
    /// </remarks>
    public class Program
    {
         static void Main(string[] args)
        {
            //SYSTEM ESTIMATE OBJECTS
            //Start by assuming that an estimate already exists and has been stored in the database.  We will pretend that we have imported the 
            //following SystemEstimate objects into the program (please note that all the code for creating the objects is hidden inside the import
            //program, and you will never see it in practice.  In fact, you won't ever have to worry about the SystemEstimates..your job is to write 
            //the code to populate the SystemReports (more info below)): 
            
            //GARAGE EXHAUST FANS
            SystemEstimate GarageFans = new SystemEstimate("GF-1")
            {
                PhaseCodes = new List<PhaseCode>()
                {
                    new PhaseCode("0001-0701"),
                    new PhaseCode("0001-0601"),
                    new PhaseCode("0001-0401")
                },

                Type=EquipmentSystemType.GarageExhaust
            };

            //EAST BUILDING TRASH EXHAUST
            SystemEstimate EASTTrashExhaust = new SystemEstimate("T-E")
            {
                PhaseCodes = new List<PhaseCode>()
                {
                    new PhaseCode("0001-0701"),
                    new PhaseCode("0001-0601"),
                    new PhaseCode("0001-0501"),
                    new PhaseCode("0001-0401")
                },

                Type = EquipmentSystemType.TrashExhaust
            };

            //WEST BUILDING TRASH EXHAUST
            SystemEstimate WESTTrashExhaust = new SystemEstimate("T-W")
            {
                PhaseCodes = new List<PhaseCode>()
                {
                    new PhaseCode("0001-0701"),
                    new PhaseCode("0001-0401")
                },

                Type = EquipmentSystemType.TrashExhaust
            };

            //EAST CORRIDOR SUPPLY
            SystemEstimate EASTCorridorSupply = new SystemEstimate("RTU-1")
            {
                PhaseCodes = new List<PhaseCode>()
                {
                    new PhaseCode("0001-0701"),
                    new PhaseCode("0001-0401")
                },

                Type = EquipmentSystemType.CorridorSystem
            };

            //WEST CORRIDOR SUPPLY
            SystemEstimate WESTCorridorSupply = new SystemEstimate("rtu-2")
            {
                PhaseCodes = new List<PhaseCode>()
                {
                    new PhaseCode("0001-0701"),
                    new PhaseCode("0001-0501"),
                    new PhaseCode("0001-0401")
                },

                Type = EquipmentSystemType.CorridorSystem
            };


            //ESTIMATE MODEL
            //With the individual SystemEstimate objects populated, we now send them all to the EstimateModel.  Again, all this functionality will
            //be hidden in practice.  All you'll see is the completed EstimateModel.  Note that both the EstimateModel and ReportModel require a 
            //job number in order to be created.
            
            //IMPORTANT:  The way to create and populate the EstimateModel is the same as for the ReportModel, so what you see below is very similar
            //to how you'll actually populate the ReportModel when it comes time to do that. 
            EstimateModel estimateModel = new EstimateModel("2170507");
            //Add the SystemEstimate objects to the "Systems" list of the EstimateModel.  The ReportModel also has a "Systems" list to hold its 
            //SystemReport objects. 
            estimateModel.Systems.Add(GarageFans);
            estimateModel.Systems.Add(EASTTrashExhaust);
            estimateModel.Systems.Add(EASTCorridorSupply);
            estimateModel.Systems.Add(WESTCorridorSupply);
            estimateModel.Systems.Add(WESTTrashExhaust);

            //The EstimateModel is now ready to be sent to the ModelReportingService, which we will do shortly.  The ModelReportingService 
            //requires both an EstimateModel and a ReportModel in order to work.  This is the point where you come in; your code should grab 
            //the data from the field report and use it to populate a SystemReport object for each reported system, just like we did above for 
            //the five SystemEstimate objects.  Once the SystemReport objects are populated, you will send them to ReportModel, just like we did
            //for the EstimateModel.  The ReportModel is the missing half of what the ModelReportingService needs to complete its job, and this 
            //is your primary deliverable. 

            //A quick word about assumptions - it is assumed that the system names in the field report match the system names of the estimate data. 
            //Though we can't always guarantee this, we can go a long way toward reducing the probability that they conflict.  The design itself can 
            //play a role here; by choosing to commit estimate data to the database, we can add checks to prevent duplicate system names.  Also, 
            //since the system names that will come back in the field report are created when "preparing" the drawings with Spaces, the burden of 
            //ensuring accuracy falls on you and the Estimating department, which is better than leaving it open-ended.  Finally, we can safely 
            //assume that if a system name in a field report DOESN'T match with anything in the estimate record, it probably matches something very
            //closely and is only off by a letter, a Capitalized/Uncapitalized letter, a hypHen, etc.  and we can easily add simple validation 
            //checks to detect and correct these issues.  


            //REPORT MODEL
            //The ReportModel will be your primary code deliverable, so your main code class should have a method to return a "ReportModel" object
            //to the caller.  To create the ReportModel, you will first need to create the SystemReport objects from the field report.

            //SYSTEM REPORT OBJECTS
            //To demonstrate a variety of scenarios, we created an EstimateModel for five equipment systems: GarageExhaust, EASTTrashExhaust, 
            //WESTTrashExhaust, EASTCorridorSupply, and WESTCorridorSupply.  I mixed the PhaseCode contents of these objects so that we have a 
            //mix or results. 

            //Assume that work is being done on the EAST building and that a field report comes back to us with the following statements true: 
            //
            //      1.  No work has been done on the WEST trash exhaust or corridor supply systems, so there are no phase codes shown in the 
            //          markups for those systems. 
            //      2.  The GarageExhaust has been completed, so all the phase codes that were included for that system are shown in the 
            //          markup data. 
            //      3.  The EAST TrashExhaust is in the process of being completed.  Phase codes 0701, 0601, and 0501 appear in the markups for this
            //          system, but code 0401 (the remaining code for that system estimate) does not.  
            //      4.  The EAST CorridorSupply is also in process.  Phase code 0701 appears in the markups, but the remaining code (0401) does
            //          not.  

            //Based on that field report, the following SystemReport objects would be created by your code: 
            
            //Garage system is complete; all phase codes in the estimate are represented. 
            SystemReport garagefans = new SystemReport("GF-1")
            {
                PhaseCodes = new List<PhaseCode>()
                {
                    new PhaseCode("0001-0701"),
                    new PhaseCode("0001-0601"),
                    new PhaseCode("0001-0401")
                }
            };

            //Partially complete; there were four phase codes in the estimate, but only two of them are being reported.
            SystemReport ETrashExhaust = new SystemReport("T-E")
            {
                PhaseCodes = new List<PhaseCode>()
                {
                    new PhaseCode("0001-0701"),
                    new PhaseCode("0001-0601"),
                    new PhaseCode("0001-0501")
                },

            };

            //Partially complete; there were two phase codes in the estimate, but only one of them is being reported.
            SystemReport ECorridorSupply = new SystemReport("RTU-1")
            {
                PhaseCodes = new List<PhaseCode>()
                {
                    new PhaseCode("0001-0701"),
                },

            };

            //No SystemReport created for the WEST building systems.

            //Create the ReportModel 
            ReportModel reportModel = new ReportModel("2170507");
            reportModel.Systems.Add(garagefans);
            reportModel.Systems.Add(ETrashExhaust);
            reportModel.Systems.Add(ECorridorSupply);


            //MODELREPORTINGSERVICE
            //With both the ReportModel and EstimateModel complete, we can run the reporting tool by creating the ModelReportingService.  Upon
            //creation, the ModelReportingService will run the data comparisons and everything will be ready to be queried. 
            ModelReportingService modelReportingService = new ModelReportingService(estimateModel, reportModel);

            //We can now query the objects contained in the modelReportingService.  The following information is available: 
            //  List<SystemEstimate> GetUnreportedSystems() - a list of systems for which there were no phase codes in the field report.
            //  List<ComparatorResult> GetReportedSystems() - a list of systems for which phase codes were found in the report.

            //  List<ComparatorResult> GetFinishedSystems() - a list of systems for which all phase codes were found in the field report.
            //  List<ComparatorResult> GetPartiallyFinishedSystems() - a list of systems for which some, but not all, of the phase codes were found
            //  in the report.

            //The contents of these lists are objects that can be further queried.  For example, the ComparatorResult contains the following
            //information: 
            //   string SystemName - Name of the equipment system; should match the name of the system in the Estimating sheet.
            //   bool IsWorkCompleted - if all the phase codes for the system appear in the report, this is TRUE.  Otherwise, it's FALSE.
            //   double PercentComplete - number between 0.00 and 1.00 representing the percentage of phase codes completed.
            //   List<PhaseCode> EstimatePhaseCodes - full list of phase codes that were estimated for the system.
            //   List<PhaseCode> FinishedPhaseCodes - list of phase codes appearing in the field report for the system.
            //   List<PhaseCode> UnfinishedPhaseCodes - list of phase codes NOT appearing in the field report for the system.
            //
            // The PhaseCode object also contains additional information.  You're familiar with SystemEstimate object already, so I won't 
            // repeat it here.  You get the idea. 

            // To report on all this information, we basically just choose the List(s) we want and iterate through them.  If we want information
            // from an object inside the List, it's easy to access. Below, I'll try to create the kind of report (using the Console window) 
            // that people will probably want to see.

            List<ComparatorResult> reportedSystems = modelReportingService.GetReportedSystems();

            Console.WriteLine("*****************************************************");
            Console.WriteLine("**************** BEGIN REPORT ***********************");
            Console.WriteLine("");
            
            //Start with the systems being reported. 
            Console.WriteLine(" REPORTED SYSTEMS: ");
            foreach(ComparatorResult c in modelReportingService.GetReportedSystems())
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("System: " + c.SystemName);
                Console.WriteLine("PercentComplete: " + (100 * c.PercentComplete) + "%");
                
                //Get information from inside the ComparatorResult Object
                //Start with the finished phase codes.
                Console.WriteLine("    " + "Finished Phase Codes");
                foreach(PhaseCode p in c.FinishedPhaseCodes)
                {
                    Console.WriteLine("    " + p.FullPhaseCode);
                }

                //Print the unfinished phase codes if there are any.
                if (c.PercentComplete != 1.00)
                {
                    Console.WriteLine("    " + "Unfinished Phase Codes");
                    foreach (PhaseCode p in c.UnfinishedPhaseCodes)
                    {
                        Console.WriteLine("    " + p.FullPhaseCode);
                    }
                }
            };
            Console.WriteLine("****************** END REPORT ***********************");

            //According to our hypothetical field report, we should see the following: 
            //  GF-1 shows 100% complete
            //  T-E  shows 75% complete, phase code 0401 shown as unfinished.
            //  RTU-1 show 50% complete, phase code 0401 shown as unfinished. 

            //Obviously, there are many other reports that can created out of the information contained in the ModelReportingService. 
            //Also, as a programming tip, notice how we can add/delete/modify the fields contained in the base objects (SystemEstimate, SystemReport)
            //without impacting the ability of the ModelReportingService to do its job.  In fact, there is only one location in the program 
            //where a change in the basic data models needs to be registered.  Point is, the ability to extend or change the application is built-in.


            //END OF DEMONSTRATION
            //If you'd like to explore the program more, I suggest putting breakpoints in this code module, then running the program.  While it's 
            //running, you can hover over objects to see their current contents.  
            //Try changing some of the SystemReport and SystemEstimate data to see how the changes will filter down into the final report.  


            List<PhaseCode> phaseCodes = new List<PhaseCode>();
            PhaseCode ductwork = new PhaseCode("0001-0801");
            PhaseCode equipment = new PhaseCode("0001-0901");
            PhaseCode GRDs = new PhaseCode("0001-0401");

            phaseCodes.Add(ductwork);
            phaseCodes.Add(equipment);
            phaseCodes.Add(GRDs);

            //We now have our populated list

            //Assume phase code lists are different for different systems.  This is just for fun.
            SystemReport myreport1 = new SystemReport("EF-1", phaseCodes);
            SystemReport myreport2 = new SystemReport("EF-2", phaseCodes);
            SystemReport myreport3 = new SystemReport("GEF-2", phaseCodes);
            SystemReport myreport4 = new SystemReport("GEF-2", phaseCodes);

            ReportModel mymodel = new ReportModel("2170508");
            mymodel.Systems.Add(myreport1);
            mymodel.Systems.Add(myreport2);
            mymodel.Systems.Add(myreport3);
            mymodel.Systems.Add(myreport4);






            Console.ReadLine();
        }
    }
}
