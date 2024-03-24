using AutoMapper;
using MediatR;
using Report.Contracts.Responses.RecordResponses;
using Report.Core.Entities;
using Report.Core.Interfaces.Repositories;

namespace Report.Application.Commands.RecordCommands.AddRecordCommand
{
    public class AddRecordCommandHandler : IRequestHandler<AddRecordCommand, AddRecordResponse>
    {
        private readonly IRecordRepository _recordRepository;

        private readonly IMapper _mapper;

        public AddRecordCommandHandler(IRecordRepository recordRepository, IMapper mapper)
        {
            _recordRepository = recordRepository;
            _mapper = mapper;
        }

        public async Task<AddRecordResponse> Handle(AddRecordCommand request, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Record>(request.AddRecordModel);

            record.UserId = request.UserId;

            record = await _recordRepository.AddRecordAsync(record);

            return new AddRecordResponse(record.Id, record.Name, record.Description);
        }
    }
}