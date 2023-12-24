namespace Abattage_BackEnd.DTOa;
public class ArticleParAnimalDTO
{
    public int? Id { get; set; }
    public int AnimalId { get; set; }
    public int StatusId { get; set; }
    public string Designation { get; set; }
    public string Code_barre { get; set; }
    public DateTime Date_generee { get; set; }
    public int ArticleTypeId { get; set; }
    public int? Poid { get; set; }
    public int Depot { get; set; }


}