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

    }
}
