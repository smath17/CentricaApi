using CentricaApi.Data.Repositories;
using CentricaApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CentricaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalespersonController : ControllerBase
    {
        private readonly ILogger<SalespersonController> _logger;
        private readonly ISalespersonRepository _salespersonsRepository;

        public SalespersonController(ILogger<SalespersonController> logger, ISalespersonRepository salespersonsRepository)
        {
            _logger = logger;
            _salespersonsRepository = salespersonsRepository;
        }

        [HttpGet]
        [Route("{districtId}")]
        public async Task<IActionResult> GetAllByDistrict(int districtId)
        {
            try
            {
                var SalespersonsByDistrict = await _salespersonsRepository.GetAllByDistrict(districtId);
                return Ok(SalespersonsByDistrict);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var Salespersons = await _salespersonsRepository.GetAll();
                return Ok(Salespersons);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
