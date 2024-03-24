using MediatR;
using Report.Contracts.Requests.RecordRequest;
using Report.Contracts.Responses.RecordResponses;

namespace Report.Application.Commands.RecordCommands.DeleteRecordCommand
{
    public class DeleteRecordCommand : IRequest<DeleteRecordResponse>
    {
        public Guid UserId { get; set; }
        
        public DeleteRecordRequest DeleteRecordModel { get; set; }
    }
}