namespace PollInTheAir.Domain.Repository.Impl
{
    using PollInTheAir.Domain.Models;

    public class FileRepository : Repository<File>, IFileRepository
    {
        public FileRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}