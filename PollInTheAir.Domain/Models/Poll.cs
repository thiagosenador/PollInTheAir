namespace PollInTheAir.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Poll : Entity
    {
        [Required]
        [MaxLength(128)]
        [Display(Name = "name")]
        public string Name { get; set; }

        [Required]
        public Location CreationLocation { get; set; }

        [Required]
        public float Range { get; set; }

        [Required]
        [Display(Name = "questions")]
        public List<Question> Questions { get; set; }

        [Required]
        [Display(Name = "created at")]
        public DateTime CreationDate { get; set; }

        [Required]
        [Display(Name = "expires at")]
        public DateTime ExpirationDate { get; set; }

        public User User { get; set; }
    }
}