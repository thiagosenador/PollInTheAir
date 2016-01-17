using System.Data.Entity;
using PollInTheAir.Domain.Models;

namespace PollInTheAir.Domain.Abstract
{
    public interface IQuestionRepository
    {
        DbSet<Question> Questions { get; } 
    }
}
