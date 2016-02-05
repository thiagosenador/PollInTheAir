namespace PollInTheAir.Domain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MultipleChoicesQuestion")]
    public class MultipleChoicesQuestion : Question
    {
        [Display(Name = "choices")]
        public virtual List<Choice> Choices { get; set; }

        [Display(Name = "can select multiple choices")]
        public bool CanSelectMultiple { get; set; }
    }
}