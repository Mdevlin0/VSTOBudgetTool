using Estimating.ProgressReporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimating.ProgressReporter.Interfaces.Model
{
    /// <summary>
    /// Represents the total markup information for a single EquipmentSystem; the ISystemReport for a single system is compared to the "IEquipmentSystem" object
    /// for the associated system. 
    /// </summary>
    /// <remarks>
    /// </remarks>
    public interface ISystemReport
    {
        //The specific name of the equipment system. 
        string Name { get; set; }
       
        //List of all the phase codes contained in the report that are associated with the equipment system.  If the work is 100% done, then the list of phase
        //codes reported will completely match the list of phase codes contained in the Estimating sheet for the corresponding system.
        List<PhaseCode> PhaseCodes { get; set; }

        /// <summary>
        /// Returns the number of reported phase codes for the equipment system.
        /// </summary>
        /// <returns></returns>        
        int GetPhaseCodeCount();
        List<string> GetFullPhaseCodeStrings();

    }
}
