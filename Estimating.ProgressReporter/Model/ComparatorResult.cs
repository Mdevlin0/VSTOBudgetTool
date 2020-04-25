using Estimating.ProgressReporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimating.ProgressReporter.Interfaces.Model
{
    public class ComparatorResult
    {
        public string SystemName { get; set; }
        public bool IsWorkCompleted { get; set; }
        public double PercentComplete { get; set; }

        //The user might want a full picture of the estimated phase codes for the system.  Provide it here for reference.
        //In this context, "EstimatePhaseCodes = FinishedPhaseCodes + UnfinishedPhaseCodes"
        public List<PhaseCode> EstimatePhaseCodes { get; set; }
        public List<PhaseCode> FinishedPhaseCodes { get; set; }
        public List<PhaseCode> UnfinishedPhaseCodes { get; set; }
    }
}
