using Blog.Application.Common.Interfaces.Persistence;
using Blog.Domain.Article;
using Blog.Domain.User.ValueObjects;
using ErrorOr;
using MediatR;

namespace Blog.Application.Articles.Commands
{
    public class CreateArticleCommandHandler(IArticleRepository ArticleRepository)
        : IRequestHandler<CreateArticleCommand, ErrorOr<Article>>
    {
        private readonly IArticleRepository _articleRepository = ArticleRepository;

        public async Task<ErrorOr<Article>> Handle(
            CreateArticleCommand request,
            CancellationToken cancellationToken
        )
        {
            await Task.CompletedTask;
            Article article = Article.Create(
                request.Title,
                request.Subtitle,
                request.Content,
                UserId.From(request.AuthorId),
                request.CoverImage,
                DateTime.UtcNow,
                DateTime.UtcNow
            );
            _articleRepository.Add(article);
            return article;
        }
    }
}
