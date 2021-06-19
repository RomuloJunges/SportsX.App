using SportsX.Domain.Enums;
using System.Collections.Generic;

namespace SportsX.Domain
{
    public class User : Entity
    {
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public EClassification Classification { get; set; }

        public IEnumerable<Phone> Phones { get; set; }
    }
}