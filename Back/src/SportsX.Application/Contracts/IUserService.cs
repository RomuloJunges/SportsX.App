using System;
using System.Threading.Tasks;
using SportsX.Application.DTOs;

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