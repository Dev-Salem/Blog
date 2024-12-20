using Blog.Domain.Entities;

namespace Blog.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        public void Add(User User);
        public User? GetUserByEmail(string Email);
    }
}
