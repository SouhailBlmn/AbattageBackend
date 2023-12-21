using Abattage_BackEnd.Models;
using Abattage_BackEnd.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Abattage_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost("typesBetails")]
        public async Task<IActionResult> AddTypeBetail(TypeBetail typeBetail)
        {
            var newTypeBetail = await _unitOfWork.TypesBetails.AddAsync(typeBetail);
            return Ok(newTypeBetail);

        }

        [HttpPut("typesBetails")]
        public async Task<IActionResult> UpdateTypeBetail(TypeBetail typeBetail)
        {
            var updatedTypeBetail = await _unitOfWork.TypesBetails.UpdateAsync(typeBetail);
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
        public async Task<IActionResult> AddStabulation(Stabulation stabulation)
        {
            var newStabulation = await _unitOfWork.Stabulations.AddAsync(stabulation);
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
        public async Task<IActionResult> AddChevillard(Chevillard chevillard)
        {
            var newChevillard = await _unitOfWork.Chevillards.AddAsync(chevillard);
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
        public async Task<IActionResult> AddClient(Client client)
        {
            var newClient = await _unitOfWork.Clients.AddAsync(client);
            return Ok(newClient);

        }

        [HttpPut("clients")]
        public async Task<IActionResult> UpdateClient(Client client)
        {
            var updatedClient = await _unitOfWork.Clients.UpdateAsync(client);
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





    }
}
