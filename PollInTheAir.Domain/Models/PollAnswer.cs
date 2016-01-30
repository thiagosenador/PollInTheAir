namespace PollInTheAir.Domain.Models
{
    using System.Collections.Generic;

    public class PollAnswer : Entity
    {
        public Poll Poll { get; set; }

        public User User { get; set; }

        public List<QuestionAnswer> QuestionAnswers { get; set; }
    }
}