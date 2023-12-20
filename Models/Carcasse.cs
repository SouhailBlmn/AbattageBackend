namespace Abattage_BackEnd.Models
{
    public class Carcasse
    {
        public int Id { get; set; }
        public string CodeBarre { get; set; }
        public int? OrdreSacrifice { get; set; }
        public int TypeBetailId { get; set; }
        public TypeBetail TypeBetail { get; set; }
        public int StabulationId { get; set; }
        public Stabulation Stabulation { get; set; }
        public DateTime DateGeneration { get; set; }
        public int TypeAbattageId { get; set; }
        public TypeAbattage TypeAbattage { get; set; }
        public int ReceptionId { get; set; }
        public Reception Reception { get; set; }
        public int? AnimalStatusId { get; set; }
        public AnimalStatus Status { get; set; }

    }
}