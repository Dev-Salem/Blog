using Blog.Application.Services;
using Blog.Application.Services.Authentication;
using Blog.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController(IAuthService service) : ApiController
    {
        private readonly IAuthService _service = service;

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var authResult = _service.Register(
                FirstName: request.FirstName,
                LastName: request.LastName,
                Email: request.Email,
                Password: request.Password
            );
            return authResult.Match(
                value => Ok(MapAuthenticationResult(value)),
                errors => Problem(errors)
            );
        }

        private static AuthenticationResponse MapAuthenticationResult(AuthenticationResult value)
        {
            return new AuthenticationResponse(
                Id: value.User.Id,
                FirstName: value.User.FirstName,
                LastName: value.User.LastName,
                Email: value.User.Email,
                Token: value.Token
            );
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var authResult = _service.Login(Email: request.Email, Password: request.Password);
            return authResult.Match(value => Ok(MapAuthenticationResult(value)), Problem);
        }
    }
}
