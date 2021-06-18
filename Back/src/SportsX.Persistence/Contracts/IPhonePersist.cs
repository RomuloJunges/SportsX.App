using System;
using System.Threading.Tasks;
using SportsX.Domain;

namespace SportsX.Persistence.Contracts
{
    public interface IPhonePersist
    {
        Task<Phone[]> GetPhonesByUserAsync(Guid userId);
        Task<Phone> GetPhoneByIdAsync(Guid phoneId);
    }
}