namespace Blog.Contracts.Articles
{
    namespace Blog.Contracts.Articles
    {
        public record CreateArticleRequest(
            string Title,
            string Subtitle,
            string Content,
            string CoverImage,
            List<string> TagIds
        );
    }
}
