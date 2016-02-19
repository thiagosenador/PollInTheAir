using Microsoft.AspNet.Identity.EntityFramework;

namespace PollInTheAir.Domain.Models.Identity
{
    public class ApplicationRole : IdentityRole<string, ApplicationUserRole>
    {
    }
}
