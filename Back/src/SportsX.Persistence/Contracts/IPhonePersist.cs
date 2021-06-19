using SportsX.Domain;
using System.Threading.Tasks;

namespace SportsX.Persistence.Contracts
{
    public interface IPhonePersist
    {
        Task<Phone[]> GetPhonesByUserIdAsync(int userId);
        Task<Phone> GetPhoneByIdsAsync(int userId, int phoneId);
    }
}