using MediatR;
using Microsoft.AspNetCore.Mvc;
using Report.Application.Commands.AuthCommands.RefreshCommand;
using Report.Contracts;
using Report.Contracts.Requests;
using Report.Contracts.Responses;

namespace Report.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/refresh")]
        public async Task<ApiResult<RefreshResponse>> Refresh(RefreshRequest request)
        {
            var command = new RefreshCommand
            {
                RefreshModel = request
            };

            var result = await _mediator.Send(command);

            return ApiResult<RefreshResponse>.Success(result);
        }
    }
}