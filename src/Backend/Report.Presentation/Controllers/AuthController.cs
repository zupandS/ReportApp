using MediatR;
using Microsoft.AspNetCore.Mvc;
using Report.Contracts;

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
        public async Task<ApiResult<>> CreateAccount(CreateAccountRequest request)
        {
            
        }
    }
}