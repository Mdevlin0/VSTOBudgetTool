using Estimating.ProgressReporter.Interfaces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimating.ProgressReporter.Model
{
    public class SystemReport : ISystemReport
    {

        public string Name { get; set; }
        public List<PhaseCode> PhaseCodes { get; set; }

        //Constructors

        public SystemReport(string name, List<PhaseCode> phaseCodes)
        {
            Name = name;
            PhaseCodes = phaseCodes;
        }


        public SystemReport(string name)
        {
            Name = name;
        }
        
        public SystemReport()
        {
            //Do nothing
        }

        public int GetPhaseCodeCount()
        {
            return PhaseCodes.Count();
        }

        public List<string> GetFullPhaseCodeStrings()
        {
            List<string> fullPhaseCodeStrings = new List<string>();
            foreach(PhaseCode p in PhaseCodes)
            {
                fullPhaseCodeStrings.Add(p.FullPhaseCode);
            }
            return fullPhaseCodeStrings;
        }
    }
}
