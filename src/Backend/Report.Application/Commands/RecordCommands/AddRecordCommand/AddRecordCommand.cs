using MediatR;
using Report.Contracts.Requests.RecordRequest;
using Report.Contracts.Responses.RecordResponses;

namespace Report.Application.Commands.RecordCommands.AddRecordCommand
{
    public class AddRecordCommand : IRequest<AddRecordResponse>
    {
        public Guid UserId { get; set; }
        
        public AddRecordRequest AddRecordModel { get; set; }
    }
}