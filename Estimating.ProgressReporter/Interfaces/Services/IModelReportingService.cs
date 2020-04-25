using Estimating.ProgressReporter.Interfaces.Model;
using Estimating.ProgressReporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimating.ProgressReporter.Interfaces.Services
{
    /// <summary>
    /// Performs the model comparison and returns the finished result.
    /// </summary>
    public interface IModelReportingService
    {
        EstimateModel _estimateModel { get; set; }
        ReportModel _reportModel { get; set; }

        List<ComparatorResult> GetFinishedSystems();
        List<ComparatorResult> GetPartiallyFinishedSystems();
        List<ComparatorResult> GetReportedSystems();
        List<SystemEstimate> GetUnreportedSystems();

    }
}
