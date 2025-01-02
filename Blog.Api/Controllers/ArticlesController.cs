using Blog.Application.Articles.Commands;
using Blog.Contracts.Articles;
using Blog.Contracts.Articles.Blog.Contracts.Articles;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("users/{userId}/articles")]
    public class ArticlesController(IMapper mapper, ISender meditator) : ApiController
    {
        private readonly IMapper _mapper = mapper;
        private readonly ISender _meditator = meditator;

        [HttpPost]
        public async Task<IActionResult> CreateArticle(string userId, CreateArticleRequest request)
        {
            var createCommand = _mapper.Map<CreateArticleCommand>((userId, request));
            var result = await _meditator.Send(createCommand);
            return result.Match(
                result => Ok(_mapper.Map<CreateArticleResponse>(result)),
                errors => Problem(errors)
            );
        }
    }
}
