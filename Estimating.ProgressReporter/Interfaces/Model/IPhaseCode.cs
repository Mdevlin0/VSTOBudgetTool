using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimating.ProgressReporter.Interfaces.Model
{
    //TODO: Complete the list of acceptable phase code types and categories.
    public enum PhaseCodeType
    {
        Equipment, 
        SpecialTeams, 
        GRD
    }

    public enum PhaseCodeCategory
    {
        //    0001,
        Normal,
        //    0009
        Extra
    }

    /// <summary>
    /// Represents the information associated with a single phase code with respect to an equipment system.
    /// </summary>
    /// <remarks>
    /// While the Equipment System is broken into 'Estimate' and 'Report' classes, the IPhaseCode object is used by both ends of the process;  in other words, 
    /// when populating active application data, there is only one phasecode object available to the Estimate and Report processes.
    /// </remarks>
    public interface IPhaseCode
    {
        string FullPhaseCode { get; set; }
        string PhaseCodeSuffix { get; set; }
        PhaseCodeCategory PhaseCodePrefix { get; set; }
        int EstimatedHours { get; set; }
        DateTime DateCompleted { get; set; }

    }
}
