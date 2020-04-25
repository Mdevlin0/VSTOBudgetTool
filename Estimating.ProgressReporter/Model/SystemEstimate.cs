using Estimating.ProgressReporter.Interfaces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimating.ProgressReporter.Model
{
    public enum EquipmentSystemType
    {
        Duct,
        SmallFans, 
        LargeFans,
        ERV, 
        TrashExhaust,
        GarageExhaust,
        CorridorSystem
    }
    public class SystemEstimate : ISystemEstimate
    {
        public string Name { get; set; }
        public EquipmentSystemType Type { get; set; }
        public List<PhaseCode> PhaseCodes { get; set; }
       
        public SystemEstimate(string name)
        {
            Name = name;
        }

        public int GetPhaseCodeCount()
        {
            if(PhaseCodes != null)
            {
                return PhaseCodes.Count();
            }
            else
            {
                return 0;
            }
        }

        public List<string> GetFullPhaseCodeStrings()
        {
            List<string> fullPhaseCodeStrings = new List<string>();
            foreach (PhaseCode p in PhaseCodes)
            {
                fullPhaseCodeStrings.Add(p.FullPhaseCode);
            }
            return fullPhaseCodeStrings;
        }
    }
}
