using System;
using System.Threading.Tasks;
using SportsX.Domain;

namespace SportsX.Persistence.Contracts
{
    public interface IPhonePersist
    {
        Task<Phone[]> GetPhonesByUserIdAsync(int userId);
        Task<Phone> GetPhoneByIdsAsync(int userId, int phoneId);
    }
}