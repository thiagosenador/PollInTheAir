namespace PollInTheAir.Domain.Repository.Impl
{
    using PollInTheAir.Domain.Models;

    public class ChoiceRepository : Repository<Choice>, IChoiceRepository
    {
        public ChoiceRepository(AppDbContext context) : base(context)
        {
        }
    }
}