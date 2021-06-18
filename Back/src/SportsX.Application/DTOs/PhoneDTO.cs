using System;
using System.ComponentModel.DataAnnotations;

namespace SportsX.Application.DTOs
{
    public class PhoneDTO
    {
        public Guid Id;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid UserId { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "O campo {0} precisa ter 11 caracteres")]
        public string Number { get; set; }

        public UserDTO User { get; set; }
    }
}