using Blog.Domain.Common.Models;

namespace Blog.Domain.User.ValueObjects
{
    public class UserId : ValueObject
    {
        public Guid Value { get; }

        private UserId(Guid value) => Value = value;

        public static UserId CreateUnique() => new(Guid.NewGuid());

        public static UserId From(string id) => new(Guid.Parse(id));

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
