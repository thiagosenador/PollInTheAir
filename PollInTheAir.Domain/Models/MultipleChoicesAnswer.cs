namespace PollInTheAir.Domain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MultipleChoicesAnswer")]
    public class MultipleChoicesAnswer : QuestionAnswer
    {
        public virtual List<Choice> SelectedChoices { get; set; }
    }
}