using System;
using System.ComponentModel.DataAnnotations;

namespace SportsX.Application.DTOs
{
    public class PhoneDTO
    {
        public Guid Id;

        public Guid UserId { get; set; }
        
        [StringLength(11, MinimumLength = 11, ErrorMessage = "The field {0} must have 11 characters")]
        public string Number { get; set; }

        public UserDTO User { get; set; }
    }
}