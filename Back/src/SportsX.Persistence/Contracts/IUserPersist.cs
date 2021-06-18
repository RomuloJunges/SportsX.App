using System;
using System.Threading.Tasks;
using SportsX.Domain;

namespace SportsX.Persistence.Contracts
{
    public interface IUserPersist
    {
        Task<User[]> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid userId);

    }
}