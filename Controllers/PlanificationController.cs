using Abattage_BackEnd.DTO;
using Abattage_BackEnd.Models;
using Abattage_BackEnd.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanificationController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public PlanificationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetPlanifications()
        {
            var planifications = await _unitOfWork.Planifications.GetAllAsync(p => p.Reception);
            return Ok(planifications);
        }

        //get by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlanificationById(int id)
        {
            var planification = await _unitOfWork.Planifications.GetByIdAsync(id, p => p.Reception);
            return Ok(planification);
        }


        [HttpPost]
        public async Task<IActionResult> AddPlanification(PlanificationDTO planification)
        {
            var planif = new Planification
            {
                Date = planification.Date,
                NumLigne = planification.NumLigne,
                TypeOrdre = planification.TypeOrdre,
                ReceptionId = planification.Reception
            };
            await _unitOfWork.Planifications.AddAsync(planif);
            planif.Reception = await _unitOfWork.Receptions.GetByIdAsync(planification.Reception);
            return Ok(planif);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlanification(int id, PlanificationDTO planification)
        {
            var planif = await _unitOfWork.Planifications.GetByIdAsync(id);
            if (planif == null)
            {
                return NotFound();
            }
            var reception = await _unitOfWork.Receptions.GetByIdAsync(planification.Reception);
            planif.Date = planification.Date;
            planif.NumLigne = planification.NumLigne;
            planif.TypeOrdre = planification.TypeOrdre;
            planif.ReceptionId = reception.Id;
            return Ok(planif);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanification(int id)
        {
            var planif = await _unitOfWork.Planifications.GetByIdAsync(id);
            if (planif == null)
            {
                return NotFound();
            }
            await _unitOfWork.Planifications.DeleteAsync(id);
            return Ok(planif);


        }
    }
}
