using Blog.Application.Common.Interfaces.Persistence;
using Blog.Domain.Article;

namespace Blog.Infra.Persistence
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly List<Article> _articles = [];

        public void Add(Article article)
        {
            _articles.Add(article);
        }
    }
}
