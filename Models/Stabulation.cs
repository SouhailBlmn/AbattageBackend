namespace Abattage_BackEnd.Models
{
    public class Stabulation
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public int Capacite { get; set; }
        public int Utilisee { get; set; }
        public int Libre { get; set; }
        public bool EstPlein { get; set; }

    }
}