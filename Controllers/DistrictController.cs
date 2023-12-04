using CentricaApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CentricaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistrictController : ControllerBase
    {
        private readonly ILogger<DistrictController> _logger;
        private readonly IDistrictRepository _districtsRepository;

        public DistrictController(ILogger<DistrictController> logger, IDistrictRepository districtsRepository)
        {
            _logger = logger;
            _districtsRepository = districtsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var Districts = await _districtsRepository.GetAll();
                return Ok(Districts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{districtId}")]
        public async Task<IActionResult> GetById(int districtId)
        {
            try
            {
                var district = await _districtsRepository.GetById(districtId);
                if (district == null) return NotFound();
                return Ok(district);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}