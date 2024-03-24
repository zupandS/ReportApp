using AutoMapper;
using Report.Contracts.Requests.RecordRequest;
using Report.Core.Entities;

namespace Report.Application.Mapper
{
    public class RecordProfile : Profile
    {
        public RecordProfile()
        {
            CreateMap<AddRecordRequest, Record>();
        }
    }
}