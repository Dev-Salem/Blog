using Blog.Domain.Articles.ValueObjects;
using Blog.Domain.Common.Models;
using Blog.Domain.Tag.ValueObjects;

namespace Blog.Domain.Tag
{
    public class Tag : AggregateRoot<TagId>
    {
        public string Name { get; }

        public string Description { get; }
        private readonly List<ArticleId> _articles = [];
        public IReadOnlyList<ArticleId> Articles => _articles.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Tag(
            TagId id,
            string name,
            string description,
            DateTime createdDateTime,
            DateTime updatedDateTime
        )
            : base(id)
        {
            Name = name;
            Description = description;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Tag Create(
            string name,
            string description,
            DateTime createdDateTime,
            DateTime updatedDateTime
        )
        {
            return new Tag(
                TagId.CreateUnique(),
                name,
                description,
                createdDateTime,
                updatedDateTime
            );
        }
    }
}
