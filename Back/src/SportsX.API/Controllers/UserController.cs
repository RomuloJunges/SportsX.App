using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsX.Application.Contracts;
using SportsX.Application.DTOs;
using System;
using System.Threading.Tasks;

namespace SportsX.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                if (users == null) return NoContent();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar users. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null) return NoContent();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar user pelo id. Erro: {ex.Message}");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            try
            {
                var user = await _userService.AddUser(userDTO);
                if (user == null) return BadRequest();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar user. Erro: {ex.Message}");
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UserDTO userDTO)
        {
            try
            {
                var user = await _userService.UpdateUser(userDTO);

                if (user == null) return BadRequest();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar user. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null) return NoContent();

                return await _userService.DeleteUser(id)
                        ? Ok(new { message = "Deletado" })
                        : throw new Exception("Ocorreu um erro ao tentar deletar o user");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar user. Erro: {ex.Message}");
            }
        }
    }
}