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
            var articlesAnimal = await _unitOfWork.ArticleParAnimals.GetAllAsync(a => a.ArticleType, a => a.Animal, a => a.Status);
            return Ok(articlesAnimal);
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
            var a = new ArticleParAnimal
            {
                AnimalId = articleAnimal.AnimalId,
                StatusId = 2,//Id status en attente de validation
                Designation = articleAnimal.Designation,
                Code_barre = articleAnimal.Code_barre,
                Date_generee = articleAnimal.Date_generee,
                ArticleTypeId = articleAnimal.ArticleTypeId,
                Poid = 0

            };
            var newArticleAnimal = await _unitOfWork.ArticleParAnimals.AddAsync(a);
            newArticleAnimal.Code_barre = newArticleAnimal.Id.ToString();
            await _unitOfWork.ArticleParAnimals.UpdateAsync(newArticleAnimal);
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
                Poid = 0

            };
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
