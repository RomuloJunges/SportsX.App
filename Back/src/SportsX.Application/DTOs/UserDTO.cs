using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsX.Application.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field {0} must have a maximum of 100 characters")]
        public string FullName { get; set; }

        [StringLength(100, ErrorMessage = "The field {0} must have a maximum of 100 characters")]
        public string CompanyName { get; set; }

        public string Document { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [EmailAddress(ErrorMessage = "Must be a valid email")]
        public string Email { get; set; }

        public string CEP { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int Classification { get; set; }

        public IEnumerable<PhoneDTO> Phones { get; set; }
    }
}