using System.ComponentModel.DataAnnotations;

namespace PollInTheAir.Domain.Models
{
    public class File : Entity
    {
        [MaxLength(128)]
        public string FileName { get; set; }

        [MaxLength(64)]
        public string ContentType { get; set; }

        public byte[] Content { get; set; }
    }
}
