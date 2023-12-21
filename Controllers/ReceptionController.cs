using Abattage_BackEnd.Data;
using Abattage_BackEnd.Models;
using Abattage_BackEnd.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReceptionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly AppDbContext _context;

        public ReceptionController(IUnitOfWork unitOfWork, AppDbContext context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var result = await _unitOfWork.Receptions.GetAllAsync(r => r.AcheteurPeau, r => r.Chevillard, r => r.AcheteurAutre, r => r.StabulationBovins, r => r.StabulationMoutons, r => r.StabulationVaches, r => r.AcheteurIntestin, r => r.AcheteurTete);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _unitOfWork.Receptions.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reception reception)
        {
            if (ModelState.IsValid)
            {
                var chevillard = await _unitOfWork.Chevillards.GetByIdAsync(reception.Chevillard.Id);
                var stabulationVaches = await _unitOfWork.Stabulations.GetByIdAsync(reception.StabulationVaches.Id);
                var stabulationMoutons = await _unitOfWork.Stabulations.GetByIdAsync(reception.StabulationMoutons.Id);
                var stabulationBovins = await _unitOfWork.Stabulations.GetByIdAsync(reception.StabulationBovins.Id);
                var acheteurIntestin = await _unitOfWork.Clients.GetByIdAsync(reception.AcheteurIntestin.Id);
                var acheteurPeau = await _unitOfWork.Clients.GetByIdAsync(reception.AcheteurPeau.Id);
                var acheteurTete = await _unitOfWork.Clients.GetByIdAsync(reception.AcheteurTete.Id);
                var acheteurAutre = await _unitOfWork.Clients.GetByIdAsync(reception.AcheteurAutre.Id);
                var rec = new Reception
                {
                    Chevillard = chevillard,
                    Tripier = reception.Tripier,
                    Nombre = reception.Nombre,
                    StabulationVaches = stabulationVaches,
                    StabulationMoutons = stabulationMoutons,
                    StabulationBovins = stabulationBovins,
                    NbBovins = reception.NbBovins,
                    NbVaches = reception.NbVaches,
                    NbMoutons = reception.NbMoutons,
                    AcheteurIntestin = acheteurIntestin,
                    AcheteurPeau = acheteurPeau,
                    AcheteurTete = acheteurTete,
                    AcheteurAutre = acheteurAutre

                };
                await _unitOfWork.Receptions.AddAsync(rec);
                // await _unitOfWork.SaveChangesAync();
                return Ok(rec);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Reception>> Put(int id, [FromBody] Reception reception)
        {
            if (ModelState.IsValid && id == reception.Id)
            {
                var chevillard = await _unitOfWork.Chevillards.GetByIdAsync(reception.Chevillard.Id);
                var stabulationVaches = await _unitOfWork.Stabulations.GetByIdAsync(reception.StabulationVaches.Id);
                var stabulationMoutons = await _unitOfWork.Stabulations.GetByIdAsync(reception.StabulationMoutons.Id);
                var stabulationBovins = await _unitOfWork.Stabulations.GetByIdAsync(reception.StabulationBovins.Id);
                var acheteurIntestin = await _unitOfWork.Clients.GetByIdAsync(reception.AcheteurIntestin.Id);
                var acheteurPeau = await _unitOfWork.Clients.GetByIdAsync(reception.AcheteurPeau.Id);
                var acheteurTete = await _unitOfWork.Clients.GetByIdAsync(reception.AcheteurTete.Id);
                var acheteurAutre = await _unitOfWork.Clients.GetByIdAsync(reception.AcheteurAutre.Id);
                var rec = new Reception
                {
                    Id = reception.Id,
                    Chevillard = chevillard,
                    Tripier = reception.Tripier,
                    Nombre = reception.Nombre,
                    StabulationVaches = stabulationVaches,
                    StabulationMoutons = stabulationMoutons,
                    StabulationBovins = stabulationBovins,
                    NbBovins = reception.NbBovins,
                    NbVaches = reception.NbVaches,
                    NbMoutons = reception.NbMoutons,
                    AcheteurIntestin = acheteurIntestin,
                    AcheteurPeau = acheteurPeau,
                    AcheteurTete = acheteurTete,
                    AcheteurAutre = acheteurAutre

                };
                await _unitOfWork.Receptions.UpdateAsync(rec);
                return Ok(reception);
            }
            return BadRequest(ModelState);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Reception>> Delete(int id)
        {
            var reception = await _unitOfWork.Receptions.GetByIdAsync(id);
            if (reception == null)
            {
                return NotFound();
            }
            await _unitOfWork.Receptions.DeleteAsync(id);
            return Ok(reception);
        }
    }

}