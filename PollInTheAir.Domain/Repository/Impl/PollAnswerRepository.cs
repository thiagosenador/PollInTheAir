using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PollInTheAir.Domain.Repository.Impl
{
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

                    var multipleChoicesAnswer = (MultipleChoicesAnswer) questionAnswer;

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
            var pollAnswer = this.Context.PollAnswers.Include(p => p.Poll).Include(p => p.QuestionAnswers).First(p => p.PollId.Equals(pollId));

            var summary = new PollResultsSummary
            {
                Poll = pollAnswer.Poll,
                QuestionResultsSummaries = new List<QuestionResultsSummary>()
            };

            foreach (var questionAnswer in pollAnswer.QuestionAnswers)
            {
                
            }

            return null;
        }
    }
}