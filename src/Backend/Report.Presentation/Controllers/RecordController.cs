using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Report.Application.Commands.RecordCommands.AddRecordCommand;
using Report.Contracts;
using Report.Contracts.Requests.RecordRequest;
using Report.Contracts.Responses.RecordResponses;

namespace Report.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class RecordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/addRecord")]
        public async Task<ApiResult<AddRecordResponse>> AddRecord(AddRecordRequest request)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var command = new AddRecordCommand
            {
                UserId = Guid.Parse(userId),
                AddRecordModel = request
            };

            var result = await _mediator.Send(command);

            return ApiResult<AddRecordResponse>.Success(result);
        }

        // [HttpPut("/updateRecord")]
        // public async Task<ApiResult<UpdateRecordResponse>> UpdateRecord(UpdateRecordRequest request)
        // {

        // }

        // [HttpDelete("/deleteRecord")]
        // public async Task<ApiResult<DeleteRecordResponse>> DeleteRecord(DeleteRecordRequest request)
        // {

        // }

        // [HttpGet("/getRecord")]
        // public async Task<ApiResult<GetRecordResponse>> GetRecord(GetRecordRequest request)
        // {

        // }

        // [HttpGet("/getRecords")]
        // public async Task<ApiResult<IEnumerable<GetRecordResponse>>> GetRecords()
        // {

        // }
    }
}