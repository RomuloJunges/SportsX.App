using System;

namespace SportsX.Domain
{
    public class Phone : Entity
    {
        public int UserId { get; set; }
        public string Number { get; set; }

        public User User { get; set; }
    }
}