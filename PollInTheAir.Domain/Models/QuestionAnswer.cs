namespace PollInTheAir.Domain.Models
{
    using System.Collections.Generic;

    public class QuestionAnswer : Entity
    {
        public Question Question { get; set; }

        public List<Choice> Answers { get; set; }
    }
}
