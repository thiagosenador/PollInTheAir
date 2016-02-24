namespace PollInTheAir.Domain.Models
{
    using System;
    using System.Collections.Generic;

    public class PollAnswer : Entity
    {
        public long PollId { get; set; }

        public virtual Poll Poll { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public DateTime AnswerDate { get; set; }

        public virtual List<QuestionAnswer> QuestionAnswers { get; set; }
    }
}