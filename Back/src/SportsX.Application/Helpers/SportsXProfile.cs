using AutoMapper;
using SportsX.Application.DTOs;
using SportsX.Domain;

namespace SportsX.Application.Helpers
{
    public class SportsXProfile : Profile
    {
        public SportsXProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Phone, PhoneDTO>().ReverseMap();
        }
    }
}