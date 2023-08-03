namespace AlohaAPIExample.Models
{
    public class PesProgramTierData
    {
        public string tierName { get; set; }
        public int pointsToNextTier { get; set; }
        public string media { get; set; }
        public string message { get; set; }
        public PesLocalizedTextData localizedMessage { get; set; }
    }
}
