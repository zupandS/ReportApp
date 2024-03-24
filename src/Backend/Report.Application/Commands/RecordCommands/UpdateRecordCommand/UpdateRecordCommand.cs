using MediatR;
using Report.Contracts.Requests.RecordRequest;
using Report.Contracts.Responses.RecordResponses;

namespace Report.Application.Commands.RecordCommands.UpdateRecordCommand
{
    public class UpdateRecordCommand : IRequest<UpdateRecordResponse>
    {
        public Guid UserId { get; set; }

        public UpdateRecordRequest UpdateRecordModel { get; set; }
    }
}