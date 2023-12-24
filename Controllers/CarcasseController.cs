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
    public class CarcasseController : ControllerBase
    {
        //Caracasse CRUD
        private readonly IUnitOfWork _unitOfWork;

        public CarcasseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var carcasses = await _unitOfWork.Carcasses.GetAllAsync(c => c.Stabulation, c => c.Reception, c => c.Status, c => c.TypeBetail, c => c.TypeAbattage);
            return Ok(carcasses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var carcasse = await _unitOfWork.Carcasses.GetByIdAsync(id, c => c.Stabulation, c => c.Reception, c => c.Status, c => c.TypeBetail, c => c.TypeAbattage);
            return Ok(carcasse);
        }

        [HttpPost]
        public async Task<ActionResult<Carcasse>> AddCarcasse(CarcasseDTO carcasse)
        {
            var c = new Carcasse();
            c.StabulationId = carcasse.StabulationId;
            c.ReceptionId = carcasse.ReceptionId;
            c.AnimalStatusId = carcasse.AnimalStatusId;
            c.TypeBetailId = carcasse.TypeBetailId;
            c.TypeAbattageId = carcasse.TypeAbattageId;
            c.CodeBarre = carcasse.CodeBarre;
            c.OrdreSacrifice = carcasse.OrdreSacrifice;
            c.DateGeneration = carcasse.DateGeneration;
            var newCarcasse = await _unitOfWork.Carcasses.AddAsync(c);
            return Ok(newCarcasse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Carcasse>> UpdateCarcasse(int id, [FromBody] CarcasseDTO carcasse)
        {
            var c = new Carcasse();
            c.Id = id;
            c.StabulationId = carcasse.StabulationId;
            c.ReceptionId = carcasse.ReceptionId;
            c.AnimalStatusId = carcasse.AnimalStatusId;
            c.TypeBetailId = carcasse.TypeBetailId;
            c.TypeAbattageId = carcasse.TypeAbattageId;
            c.CodeBarre = carcasse.CodeBarre;
            c.OrdreSacrifice = carcasse.OrdreSacrifice;
            c.DateGeneration = carcasse.DateGeneration;


            var updatedCarcasse = await _unitOfWork.Carcasses.UpdateAsync(c);
            return Ok(updatedCarcasse);
        }



    }
}
