namespace PollInTheAir.Domain.Models
{
    public abstract class QuestionAnswer : Entity
    {
        public Question Question { get; set; }
    }
}
