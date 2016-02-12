using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PollInTheAir.Domain.Models
{
    [NotMapped]
    public class PollResultsSummary
    {
        public Poll Poll { get; set; }

        public int AnswersCount { get; set; }

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
        public IOrderedEnumerable<ChoiceSummary> ChoicesSummary { get; set; }
    }

    public class ChoiceSummary
    {
        public string Choice { get; set; }

        public int Total { get; set; }


    }
}
