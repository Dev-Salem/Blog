namespace Blog.Infra.Authentication
{
    public class JwtSettings
    {
        public const string SectionName = "JwtSettings";
        public string Issuer { get; init; } = null!;
        public string Audience { get; init; } = null!;
        public string Secret { get; init; } = null!;
        public int ExpireMinutes { get; init; }
    }
}
