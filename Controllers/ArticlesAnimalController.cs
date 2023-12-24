using Abattage_BackEnd.DTOa;
using Abattage_BackEnd.Models;
using Abattage_BackEnd.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesAnimalController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public ArticlesAnimalController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetArticlesAnimal()
        {
            var articlesAnimal = await _unitOfWork.ArticleParAnimals.GetAllAsync(a => a.ArticleType, a => a.Animal, a => a.Status, a => a.Depot);
            return Ok(articlesAnimal);
        }

        [HttpGet("viandes")]
        public async Task<IActionResult> GetViandes()
        {
            var articlesAnimal = await _unitOfWork.ArticleParAnimals.GetAllAsync(a => a.ArticleType, a => a.Animal, a => a.Status);
            var viandes = articlesAnimal.Where(a => a.ArticleType.Designation.Contains("Viande") || a.ArticleType.Designation.Contains("viande"));
            return Ok(viandes);
        }

        //get by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticleAnimalById(int id)
        {
            var articleAnimal = await _unitOfWork.ArticleParAnimals.GetByIdAsync(id);
            return Ok(articleAnimal);
        }

        [HttpPost]
        public async Task<IActionResult> AddArticleAnimal(ArticleParAnimalDTO articleAnimal)
        {

            var animal = await _unitOfWork.Carcasses.GetByIdAsync(articleAnimal.AnimalId, a => a.TypeBetail);

            int qteOfPart = _unitOfWork.ArticlesTypeBetails.GetAllAsync().Result.Where(ab => ab.TypeBetailId == animal.TypeBetailId && ab.ArticleBetailId == articleAnimal.ArticleTypeId).FirstOrDefault().Qte;


            List<ArticleParAnimal> articlesToInsert = [];


            for (int i = 0; i < qteOfPart; i++)
            {
                articlesToInsert.Add(new ArticleParAnimal
                {
                    AnimalId = articleAnimal.AnimalId,
                    StatusId = articleAnimal.StatusId,
                    Designation = articleAnimal.Designation,
                    Code_barre = articleAnimal.Code_barre,
                    Date_generee = articleAnimal.Date_generee,
                    ArticleTypeId = articleAnimal.ArticleTypeId,
                    Poid = articleAnimal.Poid ?? 0
                });
            }

            var newArticleAnimal = await _unitOfWork.ArticleParAnimals.AddRangeAsync(articlesToInsert);

            foreach (var article in newArticleAnimal)
            {
                article.Code_barre = article.Id.ToString();
            }

            await _unitOfWork.ArticleParAnimals.UpdateRangeAsync(newArticleAnimal);
            return Ok(newArticleAnimal);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateArticleAnimal(ArticleParAnimalDTO articleAnimal)
        {
            var a = new ArticleParAnimal
            {
                Id = articleAnimal.Id ?? 0,
                AnimalId = articleAnimal.AnimalId,
                StatusId = articleAnimal.StatusId,
                Designation = articleAnimal.Designation,
                Code_barre = articleAnimal.Code_barre,
                Date_generee = articleAnimal.Date_generee,
                ArticleTypeId = articleAnimal.ArticleTypeId,
                Poid = articleAnimal.Poid ?? 0,

            };
            if (articleAnimal.Depot != 0)
            {
                a.DepotId = articleAnimal.Depot;
            }

            var updatedArticleAnimal = await _unitOfWork.ArticleParAnimals.UpdateAsync(a);
            return Ok(updatedArticleAnimal);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticleAnimal(int id)
        {
            var deletedArticleAnimal = await _unitOfWork.ArticleParAnimals.DeleteAsync(id);
            return Ok(deletedArticleAnimal);
        }



    }
}
