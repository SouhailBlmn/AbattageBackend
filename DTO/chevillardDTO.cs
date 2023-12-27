namespace Abattage_BackEnd.DTO
{
    public class ChevillardDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public float? Plafond { get; set; }
        public string Cin { get; set; }
        public string CinImg { get; set; }
        public int AcheteurIntestinId { get; set; }
        public int AcheteurIntestniId { get; set; }
        public int AcheteurPeauId { get; set; }
        public int AcheteurTeteId { get; set; }
        public int AcheteurAutreId { get; set; }
        public string Num_carte { get; set; }
        public string Infos { get; set; }
        public string Telephone { get; set; }
        public bool Actif { get; set; }
    }

}