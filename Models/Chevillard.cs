using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abattage_BackEnd.Models
{
    public class Chevillard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nom { get; set; }
        public float? Plafond { get; set; }

        public string Cin { get; set; }
        public string CinImg { get; set; }
        public int AcheteurIntestniId { get; set; }
        public Client AcheteurIntestin { get; set; }
        public int AcheteurPeauId { get; set; }
        public Client AcheteurPeau { get; set; }
        public int AcheteurTeteId { get; set; }
        public Client AcheteurTete { get; set; }
        public int AcheteurAutreId { get; set; }
        public Client AcheteurAutre { get; set; }
        public string Num_carte { get; set; }
        public string Infos { get; set; }
        public string Telephone { get; set; }
        public bool Actif { get; set; }
    }
}