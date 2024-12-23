using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Blog.Application.Common.Interfaces.Authentication;
using Blog.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Infra.Authentication
{
    public class JwtTokenGenerator(
        IDateTimeProvider dateTimeProvider,
        IOptions<JwtSettings> jwtOptions
    ) : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateProvider = dateTimeProvider;
        private readonly JwtSettings _jwtSettings = jwtOptions.Value;

        public string GenerateToke(Guid userId, string firstName, string LastName)
        {
            List<Claim> claims =
            [
                new Claim(JwtRegisteredClaimNames.GivenName, firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            ];
            var signingCreds = new SigningCredentials(
                algorithm: SecurityAlgorithms.HmacSha256,
                key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret))
            );
            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                claims: claims,
                audience: _jwtSettings.Audience,
                expires: _dateProvider.UtcNow.AddMinutes(_jwtSettings.ExpireMinutes),
                signingCredentials: signingCreds
            );
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
