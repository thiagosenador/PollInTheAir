using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace PollInTheAir.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Choice : Entity
    {
        [MaxLength(128)]
        public string Text { get; set; }

        [NotMapped]
        public bool Selected { get; set; }
    }
}
