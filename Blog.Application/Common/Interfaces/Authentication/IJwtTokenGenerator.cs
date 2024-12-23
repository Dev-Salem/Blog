namespace Blog.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToke(Guid userId, string firstName, string LastName);
    }
}
