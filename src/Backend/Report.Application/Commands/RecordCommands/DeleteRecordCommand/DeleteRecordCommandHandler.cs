using AutoMapper;
using MediatR;
using Report.Application.Exceptions;
using Report.Contracts.Responses.RecordResponses;
using Report.Core.Interfaces.Repositories;

namespace Report.Application.Commands.RecordCommands.DeleteRecordCommand
{
    public class DeleteRecordCommandHandler : IRequestHandler<DeleteRecordCommand, DeleteRecordResponse>
    {
        private readonly IRecordRepository _recordRepository;

        public DeleteRecordCommandHandler(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public async Task<DeleteRecordResponse> Handle(DeleteRecordCommand request, CancellationToken cancellationToken)
        {
            var record = await _recordRepository.GetRecordAsync(request.DeleteRecordModel.RecordId);

            if (record == null)
                throw new RecordNotFoundException("Запись с таким id не найдена");

            record = await _recordRepository.DeleteRecordAsync(record);

            return new DeleteRecordResponse(record.Id, record.Name, record.Description);
        }
    }
}