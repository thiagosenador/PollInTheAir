namespace PollInTheAir.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Question : Entity
    {
        [MaxLength(128)]
        [Display(Name = "statement")]
        public string Statement { get; set; }

        public QuestionType? Type { get; set; }

        public long PollId { get; set; }

        public virtual Poll Poll { get; set; }
    }
}