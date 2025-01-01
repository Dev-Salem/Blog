using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("[controller]")]
    public class BlogController : ApiController
    {
        [HttpGet]
        public IActionResult ListBlogs()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
