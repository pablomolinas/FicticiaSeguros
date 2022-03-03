using api.Interfaces;
using api.Models.dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Authorize]
    [Route("persons")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsService _personsService;
        public PersonsController(IPersonsService personsService)
        {
            _personsService = personsService;   
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _personsService.GetAll();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _personsService.GetById(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonDtoForRegister dto)
        {
            var result = await _personsService.Insert(dto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PersonDtoForRegister dto)
        {
            var result = await _personsService.Update(id, dto);
            return StatusCode(result.StatusCode, result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _personsService.Delete(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
