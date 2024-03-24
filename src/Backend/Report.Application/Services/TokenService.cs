using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Report.Application.Interfaces;
using Report.Core.Options;

namespace Report.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IOptions<TokenOptions> _options;

        public TokenService(IOptions<TokenOptions> options)
        {
            _options = options;
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken(_options.Value.Issuer, _options.Value.Audience, claims, null, DateTime.UtcNow.AddMinutes(_options.Value.JwtLifeTime), credentials);
            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }


        public string GenerateRefreshToken()
        {
            byte[] randomNumbers = new byte[32];
            using var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(randomNumbers);
            return Convert.ToBase64String(randomNumbers);
        }

        public IEnumerable<Claim> GetClaims(string accessToken)
        {
            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);

            if (jwtToken == null)
                throw new ArgumentNullException("Невалидный токен");

            return jwtToken.Claims;
        }

        public bool IsValidToken(string accessToken)
        {
            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);

            if (jwtToken == null)
                throw new ArgumentNullException("Невалидный токен");

            if (jwtToken.ValidTo < DateTime.UtcNow)
                return false;

            return true;
        }
    }
}