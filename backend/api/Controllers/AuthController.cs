using Microsoft.AspNetCore.Mvc;
using api.Models.dto;
using api.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public AuthController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        [Route("login")]        
        public async Task<IActionResult> Login([FromBody] UserDtoLogin dto)
        {
            var result = await _usersService.LoginAsync(dto);
            return StatusCode(result.StatusCode, result);
        }

    }
}
