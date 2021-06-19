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
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneService _phoneService;
        public PhoneController(IPhoneService phoneService)
        {
            this._phoneService = phoneService;
        }

        [HttpGet("{userid}")]
        public async Task<IActionResult> GetByUserId(int userid)
        {
            try
            {
                var phones = await _phoneService.GetPhonesByUserIdAsync(userid);
                if (phones == null) return NoContent();

                return Ok(phones);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar phones pelo userid. Erro: {ex.Message}");
            }
        }

        [HttpPut("update/{userId}")]
        public async Task<IActionResult> Save(int userId, PhoneDTO[] phoneDTOs)
        {
            try
            {
                var phones = await _phoneService.SavePhone(userId, phoneDTOs);
                if (phones == null) return NoContent();

                return Ok(phones);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar salvar phone. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{userId}/{phoneId}")]
        public async Task<IActionResult> Delete(int userId, int phoneId)
        {
            try
            {
                var phone = await _phoneService.GetPhoneByIdsAsync(userId, phoneId);
                if (phone == null) return NoContent();

                return await _phoneService.DeletePhone(phone.UserId, phone.Id)
                        ? Ok(new { message = "Deletado" })
                        : throw new Exception("Ocorreu um erro ao tentar deletar o phone");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar phone. Erro: {ex.Message}");
            }
        }
    }
}