using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abattage_BackEnd.Models
{
    public class TypeBetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Designation { get; set; }
        public ICollection<ArticleBetail>? Articles { get; set; }
        public ICollection<ArticleTypeBetail> ArticleTypeBetails { get; set; }

    }

}