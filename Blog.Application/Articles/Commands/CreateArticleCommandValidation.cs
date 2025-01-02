using Blog.Domain.Article;
using Blog.Domain.Articles.ValueObjects;
using FluentValidation;

namespace Blog.Application.Articles.Commands
{
    public class CreateArticleCommandValidation : AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidation()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.CoverImage).NotNull();
            RuleFor(x => x.Subtitle).NotEmpty();
            RuleFor(x => x.CoverImage).NotNull();
            RuleFor(x => x.TagIds).NotNull();
        }
    }
}
