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
    /// Manages the ComparatorModel class that holds the key applciation data.
    /// </summary>
    public interface IComparatorService
    { 

        ComparatorReport Compare(EstimateModel estimateModel, ReportModel reportModel);

    }
}
