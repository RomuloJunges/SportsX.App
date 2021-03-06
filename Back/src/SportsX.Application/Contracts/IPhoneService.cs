using SportsX.Application.DTOs;
using System.Threading.Tasks;

namespace SportsX.Application.Contracts
{
    public interface IPhoneService
    {
        Task<PhoneDTO[]> SavePhone(int userId, PhoneDTO[] models);
        Task<bool> DeletePhone(int userId, int phoneId);

        Task<PhoneDTO[]> GetPhonesByUserIdAsync(int userId);
        Task<PhoneDTO> GetPhoneByIdsAsync(int userId, int phoneId);
    }
}