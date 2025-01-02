using Blog.Domain.Article;

namespace Blog.Application.Common.Interfaces.Persistence
{
    public interface IArticleRepository
    {
        public void Add(Article article);
    }
}
