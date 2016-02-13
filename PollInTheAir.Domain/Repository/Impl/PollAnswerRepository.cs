namespace PollInTheAir.Domain.Repository.Impl
{
    using System.Collections.Generic;
    using System.Linq;

    using PollInTheAir.Domain.Models;

    public class PollAnswerRepository : Repository<PollAnswer>, IPollAnswerRepository
    {
        public PollAnswerRepository(AppDbContext context) : base(context)
        {
        }

        public void AddPollAnswer(PollAnswer pollAnswer)
        {
            foreach (var questionAnswer in pollAnswer.QuestionAnswers)
            {
                if (questionAnswer is MultipleChoicesAnswer)
                {
                    var attachedChoices = new List<Choice>();

                    var multipleChoicesAnswer = (MultipleChoicesAnswer)questionAnswer;

                    foreach (var selectedChoice in multipleChoicesAnswer.SelectedChoices)
                    {
                        var attachedChoice = this.Context.Choice.Attach(selectedChoice);

                        attachedChoices.Add(attachedChoice);
                    }

                    multipleChoicesAnswer.SelectedChoices = attachedChoices;
                }
            }

            this.Create(pollAnswer);
        }

        public PollResultsSummary GetPollResults(long pollId)
        {
            var answersList = new List<QuestionResultsSummary>();
            answersList.AddRange(this.CreateFreeTextAnswersSummaries(pollId));
            answersList.AddRange(this.CreateMultipleChoicesAnswersSummaries(pollId));

            answersList.Sort((x, y) => x.Question.Id.CompareTo(y.Question.Id));

            var pollResults = new PollResultsSummary
            {
                QuestionResultsSummaries = answersList,
                Poll = this.Context.Polls.Find(pollId),
                AnswersCount = this.GetTotalPollAnswers(pollId)
            };

            return pollResults;
        }

        private List<FreeTextQuestionResultsSummary> CreateFreeTextAnswersSummaries(long pollId)
        {
            return
                this.Context.PollAnswers
                    .Where(p => p.PollId.Equals(pollId))
                    .SelectMany(q => q.QuestionAnswers).OfType<FreeTextAnswer>()
                    .GroupBy(q => q.Question)
                    .Select(k => new FreeTextQuestionResultsSummary
                    {
                        Question = k.Key,
                        Comments = (List<string>)k.Select(c => c.Comment)
                    })
                    .ToList();
        }

        private List<MultipleChoicesQuestionResultsSummary> CreateMultipleChoicesAnswersSummaries(long pollId)
        {
            return
                this.Context.PollAnswers
                    .Where(p => p.PollId.Equals(pollId))
                    .SelectMany(q => q.QuestionAnswers).OfType<MultipleChoicesAnswer>()
                    .GroupBy(q => q.Question)
                    .Select(k => new MultipleChoicesQuestionResultsSummary
                    {
                        Question = k.Key,
                        ChoicesSummary = k.SelectMany(c => c.SelectedChoices).GroupBy(i => i.Text)
                            .Select(t => new ChoiceSummary
                            {
                                Choice = t.Key,
                                Total = t.Count()
                            }).OrderByDescending(t => t.Total)
                    })
                    .ToList();
        }

        private int GetTotalPollAnswers(long pollId)
        {
            return this.Context.PollAnswers.Count(p => p.PollId.Equals(pollId));
        }
    }
}