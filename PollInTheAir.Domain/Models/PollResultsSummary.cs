using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PollInTheAir.Domain.Models
{
    [NotMapped]
    public class PollResultsSummary
    {
        public Poll Poll { get; set; }

        public List<QuestionResultsSummary> QuestionResultsSummaries { get; set; }
    }

    public abstract class QuestionResultsSummary
    {
        public Question Question { get; set; }
    }

    public class FreeTextQuestionResultsSummary : QuestionResultsSummary
    {
        public List<string> Comments { get; set; }
    }

    public class MultipleChoicesQuestionResultsSummary : QuestionResultsSummary
    {
        public Dictionary<Choice, int> ChoicesSummary { get; set; }
    }
}
