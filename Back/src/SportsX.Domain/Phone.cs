using System;

namespace SportsX.Domain
{
    public class Phone : Entity
    {
        public Guid UserId { get; set; }
        public string Number { get; set; }

        public User User { get; set; }
    }
}