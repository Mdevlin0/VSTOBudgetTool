using Estimating.ProgressReporter.Interfaces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimating.ProgressReporter.Model
{
    /// <summary>
    /// Represents the data associated with the budget estimate for a single equipment system; this is compared to the "ISystemReport" object for the associated 
    /// equipment system.
    /// </summary>
    /// <remarks>
    /// </remarks>
    public interface ISystemEstimate
    {
        //Holds the identifying system name; the name of the system in the Estimating sheet should always match the name of the system in the prepared 
        //markups on the drawing file.
        string Name { get; set; }
        //Describe the type of system.
        EquipmentSystemType Type { get; set; }
      
        //Lists all the associated phase codes for the system. 
        List<PhaseCode> PhaseCodes { get; set; }

        /// <summary>
        /// Returns the number of phase codes for the equipment system.
        /// </summary>
        /// <remarks>
        /// Is used to measure "completeness" of the system, according to which/how many phase codes are present in the report file.
        /// </remarks>
        /// <returns></returns>
        int GetPhaseCodeCount();
        List<string> GetFullPhaseCodeStrings();
    }
}
