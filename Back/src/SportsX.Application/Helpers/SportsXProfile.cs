using AutoMapper;
using SportsX.Application.DTOs;
using SportsX.Domain;

namespace SportsX.Application.Helpers
{
    public class SportsXProfile : Profile
    {
        /// <summary>
        /// Mapeamento do Model para DTO e vice versa
        /// </summary>
        public SportsXProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Phone, PhoneDTO>().ReverseMap();
        }
    }
}