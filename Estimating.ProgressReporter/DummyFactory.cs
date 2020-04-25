using Estimating.ProgressReporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimating.PseudoDataLayer
{
    public class DummyFactory
    {
        public static List<PhaseCode> DummyPhaseCodeList()
        {
            return new List<PhaseCode>()
            {
                new PhaseCode("0001-0901"),
                new PhaseCode("0001-0801"),
                new PhaseCode("0001-0501"),
                new PhaseCode("0001-0401")
            };
        }

        public static List<PhaseCode> DummyEstimatePhaseCodeList()
        {
            return new List<PhaseCode>()
            {
                new PhaseCode("0001-0901"),
                new PhaseCode("0001-0801"),
                new PhaseCode("0001-0601"),
                new PhaseCode("0001-0501"),
                new PhaseCode("0001-0401")
            };
        }

        public static List<PhaseCode> DummyReportedPhaseCodeList()
        {
            return new List<PhaseCode>()
            {
                new PhaseCode("0001-0901"),
                new PhaseCode("0001-0501"),
            };
        }

        public static SystemEstimate DummySystemEstimate(string systemName)
        {
            return new SystemEstimate(systemName) {

                PhaseCodes = DummyEstimatePhaseCodeList()
            };


        }

        public static SystemReport DummySystemReport(string systemName)
        {
            return new SystemReport(systemName)
            {
                PhaseCodes = DummyReportedPhaseCodeList()
            };
        }


    }
}
