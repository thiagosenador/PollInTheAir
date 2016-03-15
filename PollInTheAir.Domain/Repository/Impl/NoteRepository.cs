namespace PollInTheAir.Domain.Repository.Impl
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using PollInTheAir.Domain.Models;
    using Service;
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        public NoteRepository(AppDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Note> RetrieveAvailableNotes(Location location)
        {
            var myLocation = LocationUtil.ParseLocation(location);

            return this.Context.Notes.Include(n => n.User).Include(n => n.File)
                .Where(p => p.CreationLocation.Distance(myLocation) < p.Range).ToList();
        }
    }
}