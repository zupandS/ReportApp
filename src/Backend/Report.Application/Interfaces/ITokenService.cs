using System.Security.Claims;

namespace Report.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateRefreshToken();

        string GenerateAccessToken(IEnumerable<Claim> claims);
    }
}