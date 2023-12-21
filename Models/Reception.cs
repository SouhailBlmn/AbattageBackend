using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abattage_BackEnd.Models
{
    public class Reception
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ChevillardId { get; set; }
        public Chevillard Chevillard { get; set; }
        public int? Tripier { get; set; }
        public int Nombre { get; set; }
        public int StabulationVachesId { get; set; }
        public Stabulation StabulationVaches { get; set; }
        public int StabulationMoutonsId { get; set; }
        public Stabulation StabulationMoutons { get; set; }
        public int StabulationBovinsId { get; set; }
        public Stabulation StabulationBovins { get; set; }
        public int NbBovins { get; set; }
        public int NbVaches { get; set; }
        public int NbMoutons { get; set; }
        public int AcheteurIntestinId { get; set; }
        public Client AcheteurIntestin { get; set; }
        public int AcheteurPeauId { get; set; }
        public Client AcheteurPeau { get; set; }
        public int AcheteurTeteId { get; set; }
        public Client AcheteurTete { get; set; }
        public int AcheteurAutreId { get; set; }
        public Client AcheteurAutre { get; set; }

    }


}