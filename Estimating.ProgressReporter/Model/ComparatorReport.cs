using Estimating.ProgressReporter.Errors;
using Estimating.ProgressReporter.Model;
using Estimating.PseudoDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estimating.ProgressReporter.Interfaces.Model
{
    /// <summary>
    /// Contains lists of ComparatorResult and EstimateModel objects; Represents the result of the comparison.
    /// </summary>
    public class ComparatorReport
    {
        private EstimateModel _estimateModel;
        private ReportModel _reportModel;
        private Dictionary<string, SystemReport> _reportDictionary;
        
        //Holds a list of comparator results for systems that were reported on in the weekly report. 
        public List<ComparatorResult>ReportedSystems;
        //If a system wasn't included in the weekly report, it will be added to a list of 'UnreportedSystems' to be included in the final report. 
        public List<SystemEstimate>UnreportedSystems;

        //CONSTRUCTOR
        public ComparatorReport(EstimateModel EstimateModel, ReportModel ReportModel)
        {
            _estimateModel = EstimateModel;
            _reportModel = ReportModel;
            _reportDictionary = _reportModel.Systems.ToDictionary(p => p.Name, p => p);
        }

        public void GenerateReport()
        {
            SystemReport reportedSystem;
            foreach(SystemEstimate s in _estimateModel.Systems)
            {
                if (_reportDictionary.TryGetValue(s.Name, out reportedSystem))
                {
                    if(ReportedSystems is null)
                    {
                        ReportedSystems = new List<ComparatorResult>();
                    }
                    ComparatorResult systemCompare = CompareBySystem(s, reportedSystem);
                    ReportedSystems.Add(systemCompare);
                }
                else
                {
                    if(UnreportedSystems is null)
                    {
                        UnreportedSystems = new List<SystemEstimate>();
                    }

                    UnreportedSystems.Add(s);
                }
            }
        }

        /// <summary>
        /// Returns a ComparatorResult object for the two provided systems or null if the comparison cannot be completed.
        /// </summary>
        /// <param name="systemEstimate"></param>
        /// <param name="systemReport"></param>
        /// <returns></returns>
        public ComparatorResult CompareBySystem(SystemEstimate systemEstimate, SystemReport systemReport)
        {
            //Return object
            ComparatorResult comparatorResult = new ComparatorResult();
            
            //If the system object names don't match, abort. 
            if(systemEstimate.Name != systemReport.Name)
            {
                throw new SystemNameMismatchException();
            }
            try
            {
                comparatorResult.SystemName = systemEstimate.Name;
                comparatorResult.IsWorkCompleted = IsSystemComplete(systemEstimate, systemReport);
                comparatorResult.EstimatePhaseCodes = GetEstimatedPhaseCodes(systemEstimate);
                comparatorResult.FinishedPhaseCodes = GetFinishedPhaseCodes(systemReport);
                comparatorResult.UnfinishedPhaseCodes = GetUnfinishedPhaseCodes(systemEstimate, systemReport);
                comparatorResult.PercentComplete = GetPercentComplete(systemEstimate, systemReport);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null; 
            }
            return comparatorResult;
        }

        /// <summary>
        /// Returns a list of PhaseCode objects for phase codes that have been reported as complete. 
        /// </summary>
        /// <param name="systemReport"></param>
        /// <returns></returns>
        private List<PhaseCode> GetFinishedPhaseCodes(SystemReport systemReport)
        {
            //Return the list of reported phase codes.
            return systemReport.PhaseCodes;
        }

        private List<PhaseCode> GetEstimatedPhaseCodes(SystemEstimate systemEstimate)
        {
            return systemEstimate.PhaseCodes;
        }

        /// <summary>
        /// Returns a list of PhaseCode objects for phase codes that have not been reported as complete.
        /// </summary>
        /// <param name="systemEstimate"></param>
        /// <param name="systemReport"></param>
        /// <returns></returns>
        private List<PhaseCode> GetUnfinishedPhaseCodes(SystemEstimate systemEstimate, SystemReport systemReport)
        {
            List<string> reportedFullPhaseCodes = systemReport.GetFullPhaseCodeStrings();

            //Obtain the difference.
            List<PhaseCode> unfinishedPhaseCodes = new List<PhaseCode>();
            foreach(PhaseCode p in systemEstimate.PhaseCodes)
            {
                if(!reportedFullPhaseCodes.Contains(p.FullPhaseCode))
                {
                    unfinishedPhaseCodes.Add(p);
                }
            }
            return unfinishedPhaseCodes; 
        }

        /// <summary>
        /// Returns a rounded double that represents the percentage of phase codes that have been completed.
        /// </summary>
        /// <param name="systemEstimate"></param>
        /// <param name="systemReport"></param>
        /// <returns></returns>
        private double GetPercentComplete(SystemEstimate systemEstimate, SystemReport systemReport)
        {
            //Check if the 
            if (systemEstimate.GetPhaseCodeCount() > 0)
            {
                double percentComplete = ((double)systemReport.GetPhaseCodeCount()) / ((double)systemEstimate.GetPhaseCodeCount());
                return Math.Round((double)percentComplete, 2);
            }
            else
            {
                throw new Exception("There are either no phase codes on record for the system: " + systemEstimate.Name + " or else the estimate failed to populate.");
            }
        }

        /// <summary>
        /// Returns true if all the phase codes associated with the system have been reported as complete.
        /// </summary>
        /// <param name="systemEstimate"></param>
        /// <param name="systemReport"></param>
        /// <returns></returns>
        private bool IsSystemComplete(SystemEstimate systemEstimate, SystemReport systemReport)
        {
            bool completeness = false;

            if(GetPercentComplete(systemEstimate, systemReport) == 1.0)
            {
                completeness = true;
                return completeness;
            }
            else
            {
                return completeness;
            }
        }
    }
}
