using Estimating.ProgressReporter.Interfaces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimating.ProgressReporter.Model
{
    public class PhaseCode : IPhaseCode
    {
        public PhaseCode(string fullPhaseCode)
        {
            FullPhaseCode = fullPhaseCode;
        }

        public string FullPhaseCode { get; set; }
        public string PhaseCodeSuffix { get; set; }
        public PhaseCodeCategory PhaseCodePrefix { get; set; }
        public int EstimatedHours { get; set; }
        public DateTime DateCompleted { get; set; }

        

    }

}
