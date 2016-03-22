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

            return this.Context.Notes.Include(n => n.User).Include(n => n.Comments).Include("Comments.User")
                .Where(p => p.CreationLocation.Distance(myLocation) < p.Range).ToList();
        }

        public IEnumerable<Note> RetrieveUserNotes(User currentUser)
        {
            var notes = this.Context.Notes.Where(p => p.UserId.Equals(currentUser.Id)).Select(n => new
            {
                Note = n,
                CommentCount = n.Comments.Count
            }).ToList();

            notes.ForEach(n =>
            {
                n.Note.CommentsNumber = n.CommentCount;
            });

            return notes.Select(x => x.Note);
        }
    }
}