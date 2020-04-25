using Estimating.ProgressReporter.Interfaces.Model;
using Estimating.ProgressReporter.Interfaces.Services;
using Estimating.ProgressReporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Estimating.ProgressReporter.Services
{
    /// <summary>
    /// Manages the ComparatorModel class that holds the key applciation data.
    /// </summary>
    public class ComparatorService : IComparatorService
    {
        public ReportModel _reportModel { get; set; }
        public EstimateModel _estimateModel { get; set; }

        public ComparatorReport Compare(EstimateModel estimateModel, ReportModel reportModel)
        {
            return null;
        }
    }
}
