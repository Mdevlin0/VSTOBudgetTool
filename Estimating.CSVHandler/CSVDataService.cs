using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Estimating.CSVHandler
{
    public class CSVDataService : ICSVDataService
    {
        public List<PhaseCodeRecord> phaseCodeRecords { get; set; }

        public void GetRecords(string filepath)
        {
            using (var reader = new StreamReader(filepath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<PhaseCodeRecord>();
            }
            
            //This is my first note

        }
    }
}
