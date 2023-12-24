namespace Abattage_BackEnd.DTO
{
    public class CarcasseDTO
    {
        public int Id { get; set; }
        public string CodeBarre { get; set; }
        public int? OrdreSacrifice { get; set; }
        public int TypeBetailId { get; set; }
        public int StabulationId { get; set; }
        public DateTime DateGeneration { get; set; }
        public int TypeAbattageId { get; set; }
        public int ReceptionId { get; set; }
        public int? AnimalStatusId { get; set; }
    }

}