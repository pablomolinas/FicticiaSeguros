using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("diseases")]
    [ApiController]
    [Authorize]
    public class DiseasesController : ControllerBase
    {
        private readonly IDiseasesService _diseasesService;

        public DiseasesController(IDiseasesService diseasesService)
        {
            _diseasesService = diseasesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _diseasesService.GetAll();
            return StatusCode(result.StatusCode, result);
        }               
    }
}
