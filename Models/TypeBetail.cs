namespace Abattage_BackEnd.Models
{
    public class TypeBetail
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public ICollection<ArticleBetail> Articles { get; set; }
    }

}