using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PollInTheAir.Domain.Models
{
    public class File : Entity
    {
        [MaxLength(128)]
        public string FileName { get; set; }

        [MaxLength(64)]
        public string ContentType { get; set; }

        public byte[] Content { get; set; }

        [NotMapped]
        public string FileString
        {
            get
            {
                return "data:image/png;base64," + Convert.ToBase64String(this.Content);
            }
        }
    }
}
