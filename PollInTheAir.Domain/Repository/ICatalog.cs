namespace PollInTheAir.Domain.Repository
{
    public interface ICatalog
    {
        IPollRepository Polls { get; }

        IQuestionRepository Questions { get; }

        IPollAnswerRepository PollAnswers { get; }

        IChoiceRepository Choices { get; }
    }
}