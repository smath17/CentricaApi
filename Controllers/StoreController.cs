using CentricaApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CentricaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly ILogger<StoreController> _logger;
        private readonly IStoreRepository _storesRepository;

        public StoreController(ILogger<StoreController> logger, IStoreRepository storesRepository)
        {
            _logger = logger;
            _storesRepository = storesRepository;
        }

        [HttpGet]
        [Route("{districtId}")]
        public async Task<IActionResult> GetAllByDistrict(int districtId)
        {
            try
            {
                var StoresByDistrict = await _storesRepository.GetAllByDistrict(districtId);
                return Ok(StoresByDistrict);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
