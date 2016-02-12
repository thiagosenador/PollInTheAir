namespace PollInTheAir.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Poll : Entity
    {
        [MaxLength(128)]
        [Required(ErrorMessage = "please enter the poll name!")]
        [Display(Name = "name")]
        public string Name { get; set; }

        public Location CreationLocation { get; set; }

        public float Range { get; set; }

        [Display(Name = "questions")]
        public virtual List<Question> Questions { get; set; }

        [Display(Name = "created at")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "expires at")]
        public DateTime ExpirationDate { get; set; }

        public User User { get; set; }
    }
}