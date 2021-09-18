using AutoMapper;
using Registration.Api.Dto;
using Registration.Api.Entities;

namespace Registration.Api.MappingProfile
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<UserRegistrationForm, UserRegistrationDto>().ReverseMap();
        }

    }
}
