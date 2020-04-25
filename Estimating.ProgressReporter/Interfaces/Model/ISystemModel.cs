using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimating.ProgressReporter.Interfaces.Model
{
    /// <summary>
    /// Represents the required interface for the two master model objects, EstimateModel and ReportModel. 
    /// </summary>
     public interface ISystemModel<T> 
    {
        string JobNumber { get; set; }
        string JobName { get; set; }
        List<T> Systems { get; set; }

    }
}
