using Blog.Application.Common.Interfaces.Persistence;
using Blog.Domain.Entities;

namespace Blog.Infra.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = [];

        public void Add(User User)
        {
            _users.Add(User);
        }

        public User? GetUserByEmail(string Email)
        {
            return _users.SingleOrDefault(u => u.Email == Email);
        }
    }
}
