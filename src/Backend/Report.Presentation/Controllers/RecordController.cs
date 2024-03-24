using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Report.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecordController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}