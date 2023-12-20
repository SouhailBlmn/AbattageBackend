using Abattage_BackEnd.Models;
using Abattage_BackEnd.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReceptionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var result = await _unitOfWork.Receptions.GetAllAsync(r => r.AcheteurPeau, r => r.Chevillard, r => r.AcheteurAutre);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _unitOfWork.Receptions.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Reception reception)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Receptions.AddAsync(reception);
                return Ok(reception);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Reception reception)
        {
            if (ModelState.IsValid && id == reception.Id)
            {
                _unitOfWork.Receptions.UpdateAsync(reception);
                return Ok(reception);
            }
            return BadRequest(ModelState);
        }
    }
}
