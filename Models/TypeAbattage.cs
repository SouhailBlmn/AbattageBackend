using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abattage_BackEnd.Models
{
    public class TypeAbattage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Designation { get; set; }
        public float? Prix { get; set; }
    }

}