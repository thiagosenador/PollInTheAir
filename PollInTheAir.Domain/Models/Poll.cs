using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PollInTheAir.Domain.Models
{
    public class Poll
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(128)]
        [Display(Name = "title")]
        public string Title { get; set; }

        [Required]
        public Location CreationLocation { get; set; }

        [Required]
        public float Range { get; set; }

        [Required]
        [Display(Name = "questions")]
        public List<Question> Questions { get; set; }

        [Required]
        [Display(Name = "created at")]
        public DateTime? CreatedAt { get; set; }

        [Required]
        [Display(Name = "expires at")]
        public DateTime? ExpiresAt { get; set; }
    }
}