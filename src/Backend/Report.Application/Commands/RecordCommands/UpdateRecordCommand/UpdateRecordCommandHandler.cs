using AutoMapper;
using MediatR;
using Report.Contracts.Responses.RecordResponses;
using Report.Core.Entities;
using Report.Core.Interfaces.Repositories;

namespace Report.Application.Commands.RecordCommands.UpdateRecordCommand
{
    public class UpdateRecordCommandHandler : IRequestHandler<UpdateRecordCommand, UpdateRecordResponse>
    {
        private readonly IRecordRepository _recordRepository;

        private readonly IMapper _mapper;

        public UpdateRecordCommandHandler(IRecordRepository recordRepository, IMapper mapper)
        {
            _recordRepository = recordRepository;
            _mapper = mapper;
        }
        
        public async Task<UpdateRecordResponse> Handle(UpdateRecordCommand request, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Record>(request.UpdateRecordModel);

            record.UserId = request.UserId;

            record = await _recordRepository.UpdateRecordAsync(record);

            return new UpdateRecordResponse(record.Id, record.Name, record.Description);
        }
    }
}