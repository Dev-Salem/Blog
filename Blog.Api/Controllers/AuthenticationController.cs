using Blog.Application.Services.Authentication;
using Blog.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController(IAuthService service) : ControllerBase
    {
        private readonly IAuthService _service = service;

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = _service.Register(
                FirstName: request.FirstName,
                LastName: request.LastName,
                Email: request.Email,
                Password: request.Password
            );
            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = _service.Login(Email: request.Email, Password: request.Password);
            return Ok(result);
        }
    }
}
