using Blog.Domain.Common.Models;

namespace Blog.Domain.Articles.ValueObjects
{
    public class ArticleId : ValueObject
    {
        public Guid Value { get; }

        private ArticleId(Guid value) => Value = value;

        public static ArticleId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
