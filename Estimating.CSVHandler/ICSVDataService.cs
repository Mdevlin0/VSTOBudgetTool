using System;
using System.Collections.Generic;
using System.Text;

namespace Estimating.CSVHandler
{
   public interface ICSVDataService
    {
        void GetRecords(string filepath);
        List<PhaseCodeRecord> phaseCodeRecords { get; set; }



        





    }
}
