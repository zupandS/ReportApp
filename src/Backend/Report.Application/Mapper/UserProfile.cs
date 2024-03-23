using AutoMapper;
using Report.Contracts.Requests;
using Report.Core.Entities;

namespace Report.Application.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateAccountRequest, User>()
            .ForMember(
                dest => dest.PasswordHash,
                opt => opt.MapFrom(src => src.Password));
        }
    }
}