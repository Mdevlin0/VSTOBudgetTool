using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimating.ProgressReporter.Repository
{
    /// <summary>
    /// Populated at initialization of a report comparison; re-initialized when the project number is renewed while the instance of Excel is still running.
    /// </summary>
    /// <remarks>
    /// Since the application essentially works with 'readonly' data, the repository is kept in 'one-way' mode by providing Lists (instead of other dynamic
    /// equivalents) to the caller.  If interactive data classes are needed (like serialized logging objects), they should be implemented elsewhere.  The 
    /// primary client of the repository is the "IServiceModeler" object, which is the Interface for the ReportModeler and EstimateModeler classes.
    /// </remarks>
    public interface IDataRepository
    {
         



    }
}
