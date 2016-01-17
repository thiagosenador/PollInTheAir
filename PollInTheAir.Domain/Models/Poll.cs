using System;
using System.Collections.Generic;

namespace PollInTheAir.Domain.Models
{
    public class Poll
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime ExpiresAt { get; set; }

        public List<Question> Questions { get; set; }
    }
}