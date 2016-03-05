namespace PollInTheAir.Domain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MultipleChoicesQuestion")]
    public class MultipleChoicesQuestion : Question
    {
        [Display(Name = "choices", ResourceType = typeof(Resources.Resources))]
        public virtual List<Choice> Choices { get; set; }

        [Display(Name = "answersAllowed", ResourceType = typeof(Resources.Resources))]
        public bool CanSelectMultiple { get; set; }
    }
}