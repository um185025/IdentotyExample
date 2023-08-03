using static IdentotyExample.Enums.Enums;

namespace AlohaAPIExample.Models
{
    public class PesProgramBalanceData
    {
        public int programId { get; set; }
        public PesProgramType programType { get; set; }
        public string programName { get; set; }
        public List<PesLocalizedTextData> localizedProgramName { get; set; }
        public double openingBalance { get; set; }
        public double closingBalance { get; set; }
        public double earnedPoints { get; set; }
        public double burnedPoints { get; set; }
        public PesProgramTierData programTier { get; set; }
    }
}
