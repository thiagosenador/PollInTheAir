using System.ComponentModel.DataAnnotations;

namespace PollInTheAir.Domain.Models
{
    public class Choice
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Text { get; set; }
    }
}
