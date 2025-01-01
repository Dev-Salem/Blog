using Blog.Domain.Articles.ValueObjects;
using Blog.Domain.Comment.ValueObjects;
using Blog.Domain.Common.Models;
using Blog.Domain.Common.ValueObjects;
using Blog.Domain.Tag.ValueObjects;
using Blog.Domain.User.ValueObjects;

namespace Blog.Domain.Article
{
    public sealed class Article : AggregateRoot<ArticleId>
    {
        public UserId User { get; }
        public string Title { get; }
        public string Subtitle { get; }
        public string Content { get; }
        public string CoverImageUrl { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
        private readonly List<TagId> _tags = [];
        private readonly List<CommentId> _comments = [];
        private readonly List<ReactionId> _reactions = [];

        public IReadOnlyList<TagId> Tags => _tags.AsReadOnly();
        public IReadOnlyList<CommentId> Comments => _comments.AsReadOnly();
        public IReadOnlyList<ReactionId> Reactions => _reactions.AsReadOnly();

        private Article(
            ArticleId id,
            string title,
            string subtitle,
            string content,
            UserId user,
            string coverImageUrl,
            DateTime createdDateTime,
            DateTime updatedDateTime
        )
            : base(id)
        {
            Title = title;
            Subtitle = subtitle;
            Content = content;
            User = user;
            CoverImageUrl = coverImageUrl;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Article Create(
            string title,
            string subtitle,
            string content,
            UserId user,
            string coverImageUrl,
            DateTime createdDateTime,
            DateTime updatedDateTime
        )
        {
            return new Article(
                ArticleId.CreateUnique(),
                title,
                subtitle,
                content,
                user,
                coverImageUrl,
                createdDateTime,
                updatedDateTime
            );
        }
    }
}
