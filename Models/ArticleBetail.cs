namespace Abattage_BackEnd.Models
{
    public class ArticleBetail
    {
        public int Id { get; set; }
        public string Designation { get; set; }

        public ICollection<TypeBetail> Types { get; set; }

    }
}
