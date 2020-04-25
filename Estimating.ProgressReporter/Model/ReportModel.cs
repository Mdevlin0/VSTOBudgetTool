using Estimating.ProgressReporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimating.ProgressReporter.Interfaces.Model
{
    public class ReportModel : ISystemModel<SystemReport>
    {
        public string JobNumber { get; set; }
        public string JobName { get; set; }
        public List<SystemReport> Systems { get; set; }
        
        //Constructors
        public ReportModel(string jobNumber)
        {
            JobNumber = jobNumber;
            //Initialize the list so that the caller can add to it.
            Systems = new List<SystemReport>();
        }

        public ReportModel(string jobNumber, List<SystemReport> reportedSystems)
        {
            JobNumber = JobNumber;
            Systems = reportedSystems;
        }


    }
}
