using Blog.Domain.Common.Models;

namespace Blog.Domain.Comment.ValueObjects
{
    public class CommentId : ValueObject
    {
        public Guid Value { get; }

        private CommentId(Guid value) => Value = value;

        public static CommentId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
