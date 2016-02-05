namespace PollInTheAir.Domain.Models
{
    public abstract class QuestionAnswer : Entity
    {
        public long QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
