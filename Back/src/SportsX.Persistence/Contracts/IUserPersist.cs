using SportsX.Domain;
using System.Threading.Tasks;

namespace SportsX.Persistence.Contracts
{
    public interface IUserPersist
    {
        Task<User[]> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
    }
}