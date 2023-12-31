using Abattage_BackEnd.DTO;
using Abattage_BackEnd.Models;
using Abattage_BackEnd.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Abattage_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConfigController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConfigController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("typesBetails")]
        public async Task<IActionResult> GetTypesBetails()
        {
            var typesBetails = await _unitOfWork.TypesBetails.GetAllAsync();
            return Ok(typesBetails);
        }

        //get by id
        [HttpGet("typesBetails/{id}")]
        public async Task<IActionResult> GetTypeBetailById(int id)
        {
            var typeBetail = await _unitOfWork.TypesBetails.GetByIdAsync(id);
            return Ok(typeBetail);
        }

        [HttpPost("typesBetails")]
        public async Task<IActionResult> AddTypeBetail(TypeBetailDTO typeBetail)
        {
            var t = new TypeBetail
            {
                Designation = typeBetail.Designation
            };
            var newTypeBetail = await _unitOfWork.TypesBetails.AddAsync(t);
            return Ok(newTypeBetail);

        }

        [HttpPut("typesBetails")]
        public async Task<IActionResult> UpdateTypeBetail(TypeBetailDTO typeBetail)
        {
            var t = new TypeBetail
            {
                Id = typeBetail.Id ?? 0,
                Designation = typeBetail.Designation
            };
            var updatedTypeBetail = await _unitOfWork.TypesBetails.UpdateAsync(t);
            return Ok(updatedTypeBetail);
        }

        [HttpDelete("typesBetails/{id}")]
        public async Task<IActionResult> DeleteTypeBetail(int id)
        {
            var deletedTypeBetail = await _unitOfWork.TypesBetails.DeleteAsync(id);
            return Ok(deletedTypeBetail);
        }


        //CRUD for Stabulation
        [HttpGet("stabulations")]
        public async Task<IActionResult> GetStabulations()
        {
            var stabulations = await _unitOfWork.Stabulations.GetAllAsync();
            return Ok(stabulations);
        }

        [HttpPost("stabulations")]
        public async Task<IActionResult> AddStabulation(StabulationDTO stabulation)
        {
            var s = new Stabulation
            {
                Designation = stabulation.Designation,
                Capacite = stabulation.Capacite ?? 0,
                EstPlein = stabulation.EstPlein ?? false,
                Libre = stabulation.Libre ?? (stabulation.Capacite ?? 0),
                Utilisee = stabulation.Utilisee ?? 0
            };
            var newStabulation = await _unitOfWork.Stabulations.AddAsync(s);
            return Ok(newStabulation);

        }

        [HttpPut("stabulations")]
        public async Task<IActionResult> UpdateStabulation(Stabulation stabulation)
        {
            var updatedStabulation = await _unitOfWork.Stabulations.UpdateAsync(stabulation);
            return Ok(updatedStabulation);
        }

        [HttpDelete("stabulations/{id}")]
        public async Task<IActionResult> DeleteStabulation(int id)
        {
            var deletedStabulation = await _unitOfWork.Stabulations.DeleteAsync(id);
            return Ok(deletedStabulation);
        }


        //CRUD for TypeAbattage 
        [HttpGet("typesAbattage")]
        public async Task<IActionResult> GetTypesAbattage()
        {
            var typesAbattage = await _unitOfWork.TypeAbattages.GetAllAsync();
            return Ok(typesAbattage);
        }

        [HttpPost("typesAbattage")]
        public async Task<IActionResult> AddTypeAbattage(TypeAbattage typeAbattage)
        {
            var newTypeAbattage = await _unitOfWork.TypeAbattages.AddAsync(typeAbattage);
            return Ok(newTypeAbattage);

        }

        [HttpPut("typesAbattage")]
        public async Task<IActionResult> UpdateTypeAbattage(TypeAbattage typeAbattage)
        {
            var updatedTypeAbattage = await _unitOfWork.TypeAbattages.UpdateAsync(typeAbattage);
            return Ok(updatedTypeAbattage);
        }

        [HttpDelete("typesAbattage/{id}")]

        public async Task<IActionResult> DeleteTypeAbattage(int id)
        {
            var deletedTypeAbattage = await _unitOfWork.TypeAbattages.DeleteAsync(id);
            return Ok(deletedTypeAbattage);
        }

        //CRUD for chevillard with get by id
        [HttpGet("chevillards")]
        public async Task<IActionResult> GetChevillards()
        {
            var chevillards = await _unitOfWork.Chevillards.GetAllAsync(ch => ch.AcheteurAutre, ch => ch.AcheteurIntestin, ch => ch.AcheteurPeau, ch => ch.AcheteurTete);
            return Ok(chevillards);
        }

        [HttpGet("chevillards/{id}")]
        public async Task<IActionResult> GetChevillardById(int id)
        {
            var chevillard = await _unitOfWork.Chevillards.GetByIdAsync(id);
            return Ok(chevillard);
        }

        [HttpPost("chevillards")]
        public async Task<IActionResult> AddChevillard(ChevillardDTO chevillard)
        {

            var c = new Chevillard
            {
                Nom = chevillard.Nom,
                Plafond = chevillard.Plafond ?? 0,
                Cin = chevillard.Cin,
                CinImg = chevillard.CinImg,
                AcheteurAutreId = chevillard.AcheteurAutreId,
                AcheteurIntestinId = 1,
                AcheteurPeauId = chevillard.AcheteurPeauId,
                AcheteurTeteId = chevillard.AcheteurTeteId,
                AcheteurIntestniId = 1,
                Num_carte = chevillard.Num_carte,
                Infos = chevillard.Infos,
                Telephone = chevillard.Telephone,
                Actif = chevillard.Actif
            };

            var newChevillard = await _unitOfWork.Chevillards.AddAsync(c);
            return Ok(newChevillard);

        }

        [HttpPut("chevillards")]
        public async Task<IActionResult> UpdateChevillard(Chevillard chevillard)
        {
            var updatedChevillard = await _unitOfWork.Chevillards.UpdateAsync(chevillard);
            return Ok(updatedChevillard);
        }

        [HttpDelete("chevillards/{id}")]
        public async Task<IActionResult> DeleteChevillard(int id)
        {
            var deletedChevillard = await _unitOfWork.Chevillards.DeleteAsync(id);
            return Ok(deletedChevillard);
        }


        //CRUD for Client
        [HttpGet("clients")]
        public async Task<IActionResult> GetClients()
        {
            var clients = await _unitOfWork.Clients.GetAllAsync();
            return Ok(clients);
        }

        [HttpPost("clients")]
        public async Task<IActionResult> AddClient(ClientDTO client)
        {
            var c = new Client
            {
                Nom = client.Nom,
                Plafond = client.Plafond,
            };
            var newClient = await _unitOfWork.Clients.AddAsync(c);
            return Ok(newClient);

        }

        [HttpPut("clients")]
        public async Task<IActionResult> UpdateClient(ClientDTO client)
        {
            var c = new Client
            {
                Id = client.Id,
                Nom = client.Nom,
                Plafond = client.Plafond,
            };
            var updatedClient = await _unitOfWork.Clients.UpdateAsync(c);
            return Ok(updatedClient);
        }

        [HttpDelete("clients/{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var deletedClient = await _unitOfWork.Clients.DeleteAsync(id);
            return Ok(deletedClient);
        }

        //get client by id
        [HttpGet("clients/{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var client = await _unitOfWork.Clients.GetByIdAsync(id);
            return Ok(client);
        }



        //CRUD for animalstatus
        [HttpGet("animalStatus")]
        public async Task<IActionResult> GetAnimalStatus()
        {
            var animalStatus = await _unitOfWork.AnimalStatuses.GetAllAsync();
            return Ok(animalStatus);
        }

        [HttpPost("animalStatus")]
        public async Task<IActionResult> AddAnimalStatus(AnimalStatus animalStatus)
        {
            var newAnimalStatus = await _unitOfWork.AnimalStatuses.AddAsync(animalStatus);
            return Ok(newAnimalStatus);

        }

        [HttpPut("animalStatus")]
        public async Task<IActionResult> UpdateAnimalStatus(AnimalStatus animalStatus)
        {
            var updatedAnimalStatus = await _unitOfWork.AnimalStatuses.UpdateAsync(animalStatus);
            return Ok(updatedAnimalStatus);
        }

        [HttpDelete("animalStatus/{id}")]
        public async Task<IActionResult> DeleteAnimalStatus(int id)
        {
            var deletedAnimalStatus = await _unitOfWork.AnimalStatuses.DeleteAsync(id);
            return Ok(deletedAnimalStatus);
        }



        //article betail CRUD

        [HttpGet("articlesBetail")]
        public async Task<IActionResult> GetArticlesBetail()
        {
            var articlesBetail = await _unitOfWork.ArticlesBetails.GetAllAsync();
            return Ok(articlesBetail);
        }

        [HttpPost("articlesBetail")]
        public async Task<IActionResult> AddArticleBetail(ArticleBetail articleBetail)
        {
            var newArticleBetail = await _unitOfWork.ArticlesBetails.AddAsync(articleBetail);
            return Ok(newArticleBetail);

        }

        [HttpPut("articlesBetail")]
        public async Task<IActionResult> UpdateArticleBetail(ArticleBetail articleBetail)
        {
            var updatedArticleBetail = await _unitOfWork.ArticlesBetails.UpdateAsync(articleBetail);
            return Ok(updatedArticleBetail);
        }

        [HttpDelete("articlesBetail/{id}")]
        public async Task<IActionResult> DeleteArticleBetail(int id)
        {
            var deletedArticleBetail = await _unitOfWork.ArticlesBetails.DeleteAsync(id);
            return Ok(deletedArticleBetail);
        }



        //article status CRUD

        [HttpGet("articlesStatus")]
        public async Task<IActionResult> GetArticlesStatus()
        {
            var articlesStatus = await _unitOfWork.ArticleStatuses.GetAllAsync();
            return Ok(articlesStatus);
        }

        [HttpPost("articlesStatus")]
        public async Task<IActionResult> AddArticleStatus(ArticleStatus articleStatus)
        {
            var newArticleStatus = await _unitOfWork.ArticleStatuses.AddAsync(articleStatus);
            return Ok(newArticleStatus);

        }

        [HttpPut("articlesStatus")]
        public async Task<IActionResult> UpdateArticleStatus(ArticleStatus articleStatus)
        {
            var updatedArticleStatus = await _unitOfWork.ArticleStatuses.UpdateAsync(articleStatus);
            return Ok(updatedArticleStatus);
        }

        [HttpDelete("articlesStatus/{id}")]

        public async Task<IActionResult> DeleteArticleStatus(int id)
        {
            var deletedArticleStatus = await _unitOfWork.ArticleStatuses.DeleteAsync(id);
            return Ok(deletedArticleStatus);
        }



        //Depot CRUD

        [HttpGet("depots")]
        public async Task<IActionResult> GetDepots()
        {
            var depots = await _unitOfWork.Depots.GetAllAsync();
            return Ok(depots);
        }

        [HttpPost("depots")]

        public async Task<IActionResult> AddDepot(DepotDTO depot)
        {
            var d = new Depot
            {
                Adresse = depot.Adresse,
                Nom = depot.Nom,
            };
            var newDepot = await _unitOfWork.Depots.AddAsync(d);
            return Ok(newDepot);

        }

        [HttpPut("depots")]

        public async Task<IActionResult> UpdateDepot(DepotDTO depot)
        {
            var d = new Depot
            {
                Id = depot.Id ?? 0,
                Adresse = depot.Adresse,
                Nom = depot.Nom,
            };
            var updatedDepot = await _unitOfWork.Depots.UpdateAsync(d);
            return Ok(updatedDepot);
        }


        [HttpDelete("depots/{id}")]

        public async Task<IActionResult> DeleteDepot(int id)
        {
            var deletedDepot = await _unitOfWork.Depots.DeleteAsync(id);
            return Ok(deletedDepot);



        }




    }
}
