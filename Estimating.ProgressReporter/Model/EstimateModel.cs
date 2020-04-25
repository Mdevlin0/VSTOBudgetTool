using Estimating.ProgressReporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimating.ProgressReporter.Interfaces.Model
{
    public class EstimateModel : ISystemModel<SystemEstimate>
    {
        public string JobNumber { get; set; }
        public string JobName { get; set; }
        public List<SystemEstimate> Systems { get; set; }
       
        //Constructors
        public EstimateModel(string jobNumber)
        {
            JobNumber = jobNumber;
            //Initialize the Systems list so that it isn't NULL and so that objects can be added by the caller.
            Systems = new List<SystemEstimate>();
        }

        public EstimateModel(string jobNumber, List<SystemEstimate> systemEstimates)
        {
            JobNumber = jobNumber;
            Systems = systemEstimates;
        }
    }
}
