using System.Collections.Generic;

namespace PollInTheAir.Domain.Repository
{
    using PollInTheAir.Domain.Models;

    public interface IQuestionRepository : IRepository<Question>
    {
        List<Question> GetQuestionsOfPoll(long pollId);
    }
}