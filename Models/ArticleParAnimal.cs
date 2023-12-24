using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abattage_BackEnd.Models
{
    public class ArticleParAnimal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Designation { get; set; }
        public int? AnimalId { get; set; }
        public Carcasse Animal { get; set; }
        public int? StatusId { get; set; }
        public ArticleStatus Status { get; set; }
        public string Code_barre { get; set; }
        public DateTime Date_generee { get; set; }
        public int? ArticleTypeId { get; set; }
        public ArticleBetail ArticleType { get; set; }
        public int? Poid { get; set; }
        public int? DepotId { get; set; }
        public Depot? Depot { get; set; }
    }
}
