namespace PollInTheAir.Domain.Models
{
    using System;

    public class User : Entity
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string CreatedBy { get; set; }
    }
}
