using SportsX.Application.DTOs;
using System.Threading.Tasks;

namespace SportsX.Application.Contracts
{
    public interface IUserService
    {
        Task<UserDTO> AddUser(UserDTO model);
        Task<UserDTO> UpdateUser(UserDTO model);
        Task<bool> DeleteUser(int userId);
        Task<UserDTO[]> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int userId);
    }
}