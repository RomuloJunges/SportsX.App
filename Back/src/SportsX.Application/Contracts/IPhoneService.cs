using System;
using System.Threading.Tasks;
using SportsX.Application.DTOs;

namespace SportsX.Application.Contracts
{
    public interface IPhoneService
    {
        Task<PhoneDTO[]> AddPhone(PhoneDTO[] model);
        Task<PhoneDTO> UpdatePhone(PhoneDTO model);
        Task<bool> DeletePhone(Guid phoneId);

        Task<PhoneDTO[]> GetPhonesByUserIdAsync(Guid userId);
    }
}