namespace PollInTheAir.Domain.Models
{
    using System.Collections.Generic;

    public class MultipleChoicesAnswer : QuestionAnswer
    {
        public List<Choice> SelectedChoices { get; set; }
    }
}