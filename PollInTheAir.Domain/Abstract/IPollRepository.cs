using System.Data.Entity;
using PollInTheAir.Domain.Models;

namespace PollInTheAir.Domain.Abstract
{
    public interface IPollRepository
    {
        DbSet<Poll> Polls { get; }
    }
}
