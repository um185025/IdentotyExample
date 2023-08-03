namespace AlohaAPIExample.Models
{
    public class ExternalPosComp
    {
        public List<ExternalItemSelection> ItemSelections { get; set; }
        public int CompId { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
    }
}
