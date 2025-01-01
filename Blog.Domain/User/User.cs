using Blog.Domain.Articles.ValueObjects;
using Blog.Domain.Comment.ValueObjects;
using Blog.Domain.Common.Models;
using Blog.Domain.User.ValueObjects;

namespace Blog.Domain.User
{
    public sealed class User : AggregateRoot<UserId>
    {
        public string Name { get; private set; }
        public string Bio { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public string Profile { get; private set; }
        private readonly List<ArticleId> _articles = [];
        private readonly List<CommentId> _comments = [];
        private readonly List<UserId> _following = [];
        private readonly List<UserId> _followers = [];

        public IReadOnlyCollection<ArticleId> Articles => _articles.AsReadOnly();
        public IReadOnlyCollection<CommentId> Comments => _comments.AsReadOnly();
        public IReadOnlyCollection<UserId> Followings => _following.AsReadOnly();
        public IReadOnlyCollection<UserId> Followers => _followers.AsReadOnly();

        private User(
            UserId id,
            string name,
            string bio,
            string profile,
            DateTime createdAt,
            DateTime updatedAt
        )
            : base(id)
        {
            Id = id;
            Name = name;
            Bio = bio;
            Profile = profile;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static User Create(
            string name,
            string bio,
            string profile,
            DateTime createdAt,
            DateTime updatedAt
        )
        {
            return new User(UserId.CreateUnique(), name, bio, profile, createdAt, updatedAt);
        }
    }
}
