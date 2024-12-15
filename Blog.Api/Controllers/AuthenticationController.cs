using Blog.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            return Ok(request);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(RegisterRequest request)
        {
            return Ok(request);
        }
    }
}
