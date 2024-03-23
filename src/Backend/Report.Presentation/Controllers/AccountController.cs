using MediatR;
using Microsoft.AspNetCore.Mvc;
using Report.Application.Commands.AccountCommands.CreateAccountCommand;
using Report.Application.Commands.AccountCommands.LoginAccountCommand;
using Report.Contracts;
using Report.Contracts.Requests;
using Report.Contracts.Responses;

namespace Report.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/create")]
        public async Task<ApiResult<CreateAccountResponse>> CreateAccount(CreateAccountRequest request)
        {
            var command = new CreateAccountCommand
            {
                CreateAccountModel = request
            };

            var result = await _mediator.Send(command);

            return ApiResult<CreateAccountResponse>.Success(result);
        }

        [HttpPost("/login")]
        public async Task<ApiResult<LoginAccountResponse>> LoginAccount(LoginAccountRequest request)
        {
            var command = new LoginAccountCommand
            {
                LoginAccountModel = request
            };

            var result = await _mediator.Send(command);

            return ApiResult<LoginAccountResponse>.Success(result);
        }
    }
}