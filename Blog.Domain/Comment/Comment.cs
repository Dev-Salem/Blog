using Blog.Domain.Comment.ValueObjects;
using Blog.Domain.Common.Models;
using Blog.Domain.Common.ValueObjects;
using Blog.Domain.User.ValueObjects;

namespace Blog.Domain.Comment
{
    public sealed class Comment : AggregateRoot<CommentId>
    {
        public UserId Author { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }
        private readonly List<CommentId> _replies = [];
        private readonly List<ReactionId> _reactions = [];

        public IReadOnlyList<CommentId> Replies => _replies.AsReadOnly();
        public IReadOnlyList<ReactionId> Reactions => _reactions.AsReadOnly();

        private Comment(
            CommentId id,
            UserId author,
            string content,
            DateTime createdDateTime,
            DateTime updatedDateTime
        )
            : base(id)
        {
            Author = author;
            Content = content;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Comment Create(
            UserId author,
            string content,
            DateTime createdDateTime,
            DateTime updatedDateTime
        )
        {
            return new Comment(
                CommentId.CreateUnique(),
                author,
                content,
                createdDateTime,
                updatedDateTime
            );
        }
    }
}
