namespace Abattage_BackEnd.DTO
{
    public class PlanificationDTO
    {
        public int? Id { get; set; }
        public int? NumLigne { get; set; }
        public DateTime Date { get; set; }
        public string? TypeOrdre { get; set; }
        public int Reception { get; set; }
    }

}