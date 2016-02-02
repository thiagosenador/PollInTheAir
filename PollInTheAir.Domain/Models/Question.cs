namespace PollInTheAir.Domain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Question : Entity
    {
        [Required]
        [MaxLength(128)]
        [Display(Name = "statement")]
        public string Statement { get; set; }

        public QuestionType? Type { get; set; }

        [Display(Name = "choices")]
        public List<Choice> Choices { get; set; }

        [Required]
        [Display(Name = "can select multiple choices")]
        public bool CanSelectMultiple { get; set; }
    }
}