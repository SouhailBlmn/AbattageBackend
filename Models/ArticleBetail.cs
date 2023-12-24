using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abattage_BackEnd.Models
{
    public class ArticleBetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Designation { get; set; }

        public ICollection<TypeBetail>? Types { get; set; }
        public ICollection<ArticleTypeBetail> ArticleTypeBetails { get; set; }


    }
}
