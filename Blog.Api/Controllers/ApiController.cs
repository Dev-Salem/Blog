using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Api.Controllers
{
    [Authorize]
    [ApiController]
    public class ApiController : ControllerBase
    {
        [Route("exception")]
        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Count == 0)
            {
                return Problem();
            }
            if (errors.All(error => error.Type == ErrorType.Validation))
            {
                return ValidationProblem(errors);
            }
            HttpContext.Items["errors"] = errors;

            return Problem(errors[0]);
        }

        private IActionResult Problem(Error error)
        {
            int statusCode = error.Type switch
            {
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                ErrorType.Forbidden => StatusCodes.Status403Forbidden,
                _ => StatusCodes.Status500InternalServerError,
            };
            return Problem(statusCode: statusCode, title: error.Description);
        }

        private IActionResult ValidationProblem(List<Error> errors)
        {
            var modelStateDict = new ModelStateDictionary();
            foreach (var error in errors)
            {
                modelStateDict.AddModelError(error.Code, error.Description);
            }
            return ValidationProblem();
        }
    }
}
