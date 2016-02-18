using Microsoft.AspNet.Identity.EntityFramework;
using PollInTheAir.Domain.Models;

namespace PollInTheAir.Domain.Repository
{
    public class IdentityDbContext : IdentityDbContext<User>
    {
        public IdentityDbContext()
            : base("name=InTheAir", false)
        {
        }

        public static IdentityDbContext Create()
        {
            return new IdentityDbContext();
        }
    }
}