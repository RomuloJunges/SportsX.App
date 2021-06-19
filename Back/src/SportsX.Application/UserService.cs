using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SportsX.Application.Contracts;
using SportsX.Application.DTOs;
using SportsX.Domain;
using SportsX.Persistence.Contracts;

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


        //Método para adicionar o user fazendo a conversão do DTO que foi recebido da Controller para o Domain
        //Após salvar as mudanças do context retorna o usuário inserido mapeado para DTO
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

        //Método para atualizar o user com base no UserDTO passado pelo modelo
        //Após salvar as mudanças no banco ele retorna o mesmo usuário atualizado
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

        //Realiza o Delete do user com base no id informado pela Controller
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


        //Retorna todos os Users
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

        //Retorna o User com base no ID informado
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