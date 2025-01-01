using Blog.Domain.Common.Models;

namespace Blog.Domain.Tag.ValueObjects
{
    public class TagId : ValueObject
    {
        public Guid Value { get; }

        private TagId(Guid value) => Value = value;

        public static TagId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
