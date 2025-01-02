using Blog.Domain.Article;
using ErrorOr;
using MediatR;

namespace Blog.Application.Articles.Commands
{
    public record CreateArticleCommand(
        string Title,
        string AuthorId,
        string Subtitle,
        string Content,
        string CoverImage,
        List<string> TagIds
    ) : IRequest<ErrorOr<Article>>;
}
