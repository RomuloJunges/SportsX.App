using Newtonsoft.Json;
using SportsX.Application.DTOs.Extensions;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SportsX.Application.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} tem um máximo de 100 caracteres")]
        public string FullName { get; set; }

        [StringLength(100, ErrorMessage = "O campo {0} tem um máximo de 100 caracteres")]
        public string CompanyName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DefaultValue("")]
        [Document(ErrorMessage = "O campo {0} é inválido, coloque no formato CPF ou CNPJ")]
        public string Document { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O {0} precisa ser válido")]
        public string Email { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DefaultValue("")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "O campo {0} precisa ter 8 caracteres")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Classification { get; set; }

        public IEnumerable<PhoneDTO> Phones { get; set; }
    }
}