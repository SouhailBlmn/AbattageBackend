using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abattage_BackEnd.Models
{
    public class ArticleTypeBetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ArticleBetailId { get; set; }
        public ArticleBetail ArticleBetail { get; set; }
        public int TypeBetailId { get; set; }
        public TypeBetail TypeBetail { get; set; }
        public int Qte { get; set; }
    }
}