using System;
using System.ComponentModel.DataAnnotations;

namespace PollInTheAir.Domain.Models
{
    public class NoteComment : Entity
    {
        public string Comment { get; set; }

        public DateTime CommentDate { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public long NoteId { get; set; }

        public virtual Note Note { get; set; }
    }
}
