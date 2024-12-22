using ErrorOr;

namespace Blog.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicateUser =>
                Error.Conflict(
                    code: "User.DuplicateEmail",
                    description: "User email already exists"
                );
        }
    }
}
