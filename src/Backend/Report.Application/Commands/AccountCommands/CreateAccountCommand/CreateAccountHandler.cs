using AutoMapper;
using MediatR;
using Report.Application.Exceptions;
using Report.Application.Interfaces;
using Report.Contracts.Responses;
using Report.Core.Entities;
using Report.Core.Interfaces.Repositories;

namespace Report.Application.Commands.AccountCommands.CreateAccountCommand
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, CreateAccountResponse>
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        private readonly IPasswordHashService _passwordHashService;

        public CreateAccountHandler(IUserRepository userRepository, IMapper mapper, IPasswordHashService passwordHashService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHashService = passwordHashService;
        }

        public async Task<CreateAccountResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByLoginAsync(request.CreateAccountModel.Login);

            if (user != null)
                throw new UserAlreadyExist("Такой пользователь уже существует");

            user = _mapper.Map<User>(request.CreateAccountModel);

            var passwordHash = _passwordHashService.HashPassword(user.PasswordHash);

            user.PasswordHash = passwordHash;

            user = await _userRepository.AddUserAsync(user);

            return new CreateAccountResponse(user.Login);
        }
    }
}