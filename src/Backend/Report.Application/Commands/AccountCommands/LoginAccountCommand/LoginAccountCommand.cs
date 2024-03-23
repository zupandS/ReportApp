using MediatR;
using Report.Contracts.Requests;
using Report.Contracts.Responses;

namespace Report.Application.Commands.AccountCommands.LoginAccountCommand
{
    public class LoginAccountCommand : IRequest<LoginAccountResponse>
    {
        public LoginAccountRequest LoginAccountModel { get; set; }
    }
}