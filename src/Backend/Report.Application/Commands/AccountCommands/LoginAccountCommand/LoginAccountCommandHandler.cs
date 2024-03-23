
using System.Runtime.InteropServices;
using System.Security.Claims;
using AutoMapper;
using MediatR;
using Report.Application.Exceptions;
using Report.Application.Interfaces;
using Report.Contracts.Responses;
using Report.Core.Interfaces.Repositories;

namespace Report.Application.Commands.AccountCommands.LoginAccountCommand
{
    public class LoginAccountCommandHandler : IRequestHandler<LoginAccountCommand, LoginAccountResponse>
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        private readonly IPasswordHashService _passwordHashService;

        private readonly ITokenService _tokenService;

        public LoginAccountCommandHandler(IUserRepository userRepository, IMapper mapper, IPasswordHashService passwordHashService, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHashService = passwordHashService;
            _tokenService = tokenService;
        }
        
        public async Task<LoginAccountResponse> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByLoginAsync(request.LoginAccountModel.Login);

            if (user == null)
                throw new UserNotFoundException("Пользователь не найден");

            if (!_passwordHashService.IsCorrect(request.LoginAccountModel.Password, user.PasswordHash))
                throw new IncorrectPasswordException("Неверный пароль");

            var refreshToken = _tokenService.GenerateRefreshToken();

            var accessToken = _tokenService.GenerateAccessToken(new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            });

            user.RefreshToken = refreshToken;

            user = await _userRepository.UpdateAsync(user);

            return new LoginAccountResponse(user.Id, user.RefreshToken, accessToken);
        }
    }
}