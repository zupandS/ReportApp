using System.Security.Claims;
using MediatR;
using Microsoft.Extensions.Options;
using Report.Application.Exceptions;
using Report.Application.Interfaces;
using Report.Contracts.Responses;
using Report.Core.Interfaces.Repositories;
using Report.Core.Options;

namespace Report.Application.Commands.AuthCommands.RefreshCommand
{
    public class RefreshCommandHandler : IRequestHandler<RefreshCommand, RefreshResponse>
    {
        private readonly IUserRepository _userRepository;

        private readonly ITokenService _tokenService;

        private readonly IOptions<TokenOptions> _options;

        public RefreshCommandHandler(
            IUserRepository userRepository,
            ITokenService tokenService,
            IOptions<TokenOptions> options)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _options = options;
        }

        public async Task<RefreshResponse> Handle(RefreshCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByTokenAsync(request.RefreshModel.RefreshToken);

            if (user == null)
                throw new UserNotFoundException("Пользователя с таким токеном не существует");

            var claims = _tokenService.GetClaims(request.RefreshModel.AccessToken);

            var userId = claims.FirstOrDefault(k => k.Type == ClaimTypes.NameIdentifier).Value;

            if (userId == null)
                throw new InvalidTokenException("Невалидный refresh токен");

            if (_tokenService.IsValidToken(request.RefreshModel.AccessToken))
                throw new ValidTokenException("Время жизни токена еще не истекло");

            if (userId != user.Id.ToString())
                throw new InvalidTokenException("Невалидный refresh или access токен");

            var refreshToken = _tokenService.GenerateRefreshToken();

            var accessToken = _tokenService.GenerateAccessToken(new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            });

            user.RefreshToken = refreshToken;

            user.RefreshTokenLifeTime = DateTime.UtcNow.AddDays(_options.Value.RefreshLifeTime);

            user = await _userRepository.UpdateAsync(user);

            return new RefreshResponse(user.Id, refreshToken, accessToken);
        }
    }
}