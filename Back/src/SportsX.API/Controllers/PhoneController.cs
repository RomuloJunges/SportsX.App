using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsX.Application.Contracts;
using SportsX.Application.DTOs;

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
        public async Task<IActionResult> GetByUserId(Guid userid)
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
                    $"Erro ao tentar recuperar phone pelo userid. Erro: {ex.Message}");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(PhoneDTO[] phoneDTO)
        {
            try
            {
                var phones = await _phoneService.AddPhone(phoneDTO);
                if (phones == null) return BadRequest();

                return Ok(phones);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar registrar phone. Erro: {ex.Message}");
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(PhoneDTO[] phoneDTO)
        {
            try
            {
                var phones = await _phoneService.UpdatePhone(phoneDTO);
                if (phones == null) return BadRequest();

                return Ok(phones);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar phone. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id){
            try
            {
                var phone = await _phoneService.GetPhoneByIdAsync(id);
                if (phone == null) return NoContent();

                return await _phoneService.DeletePhone(id)
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