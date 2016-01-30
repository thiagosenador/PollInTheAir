namespace PollInTheAir.Domain.Models
{
    using System.Collections.Generic;

    public class MultipleChoicesQuestionAnswer : QuestionAnswer
    {
        public List<Choice> SelectedChoices { get; set; }
    }
}
