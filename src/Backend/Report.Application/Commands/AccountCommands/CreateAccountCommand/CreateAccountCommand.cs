using MediatR;
using Report.Contracts.Requests;
using Report.Contracts.Responses;

namespace Report.Application.Commands.AccountCommands.CreateAccountCommand
{
    public class CreateAccountCommand : IRequest<CreateAccountResponse>
    {
        public CreateAccountRequest CreateAccountModel { get; set; }
    }
}