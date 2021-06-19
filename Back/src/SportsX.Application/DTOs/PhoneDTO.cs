using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SportsX.Application.DTOs
{
    public class PhoneDTO
    {
        public int Id;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int UserId { get; set; }

        [StringLength(11, MinimumLength = 10, ErrorMessage = "O campo {0} precisa ter entre 10 a 11 caracteres")]
        public string Number { get; set; }
    }
}