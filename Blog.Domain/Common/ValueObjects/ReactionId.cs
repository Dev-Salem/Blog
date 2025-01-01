using Blog.Domain.Common.Models;

namespace Blog.Domain.Common.ValueObjects
{
    public class ReactionId : ValueObject
    {
        public Guid Value { get; }

        private ReactionId(Guid value) => Value = value;

        public static ReactionId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
