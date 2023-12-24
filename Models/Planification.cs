using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abattage_BackEnd.Models
{
    public class Planification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? NumLigne { get; set; }
        public DateTime Date { get; set; }
        public string? TypeOrdre { get; set; }
        public int ReceptionId { get; set; }
        public Reception Reception { get; set; }
    }
}