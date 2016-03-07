namespace PollInTheAir.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Question : Entity
    {
        [MaxLength(128)]
        [Display(Name = "statement", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "statementRequired")]
        public string Statement { get; set; }

        public short Order { get; set; }

        [Required]
        public QuestionType? Type { get; set; }

        public long PollId { get; set; }

        public virtual Poll Poll { get; set; }
    }
}