namespace Blog.Application.Common.Interfaces
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToke(Guid userId, string firstName, string LastName);
    }
}
