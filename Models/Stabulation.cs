using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abattage_BackEnd.Models
{
    public class Stabulation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Designation { get; set; }
        public int Capacite { get; set; }
        public int Utilisee { get; set; }
        public int Libre { get; set; }
        public bool EstPlein { get; set; }

    }
}