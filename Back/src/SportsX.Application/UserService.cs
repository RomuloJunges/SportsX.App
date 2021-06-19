using AutoMapper;
using SportsX.Application.Contracts;
using SportsX.Application.DTOs;
using SportsX.Domain;
using SportsX.Persistence.Contracts;
using System;
using System.Threading.Tasks;

namespace SportsX.Application
{
    public class UserService : IUserService
    {
        private readonly IGenericPersist _genericPersist;
        private readonly IUserPersist _userPersist;
        private readonly IMapper _mapper;

        public UserService(IGenericPersist genericPersist, IUserPersist userPersist, IMapper mapper)
        {
            this._genericPersist = genericPersist;
            this._userPersist = userPersist;
            this._mapper = mapper;
        }

        /// <summary>
        /// Metodo para adicionar o User fazendo conversao de DTO para o Domain
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Retorna o User que foi inserido</returns>
        public async Task<UserDTO> AddUser(UserDTO model)
        {
            try
            {
                var user = _mapper.Map<User>(model);
                _genericPersist.Add<User>(user);

                if (await _genericPersist.SaveChangesAsync())
                {
                    var result = await _userPersist.GetUserByIdAsync(user.Id);

                    return _mapper.Map<UserDTO>(result);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Metodo para atualizar o User
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Retorna o User atualizado</returns>
        public async Task<UserDTO> UpdateUser(UserDTO model)
        {
            try
            {
                var user = await _userPersist.GetUserByIdAsync(model.Id);
                if (user == null) return null;

                _mapper.Map(model, user);

                _genericPersist.Update<User>(user);
                if (await _genericPersist.SaveChangesAsync())
                {
                    var result = await _userPersist.GetUserByIdAsync(user.Id);

                    return _mapper.Map<UserDTO>(result);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Metodo para deletar o User com base no parametro de entrada
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Retorna o numero de modificacoes feita no banco de dados</returns>
        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                var user = await _userPersist.GetUserByIdAsync(userId);
                if (user == null) throw new Exception("User to delete not found");

                _genericPersist.Delete<User>(user);
                return await _genericPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Metodo para retornar todos os User
        /// </summary>
        /// <returns>Array de User</returns>
        public async Task<UserDTO[]> GetAllUsersAsync()
        {
            try
            {
                var users = await _userPersist.GetAllUsersAsync();
                if (users == null) return null;

                var result = _mapper.Map<UserDTO[]>(users);

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Metodo para retornar o User com base no ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Retorna o User</returns>
        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            try
            {
                var user = await _userPersist.GetUserByIdAsync(userId);
                if (user == null) return null;

                var result = _mapper.Map<UserDTO>(user);

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}