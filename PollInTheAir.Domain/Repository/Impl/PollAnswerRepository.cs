using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

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
    }
}