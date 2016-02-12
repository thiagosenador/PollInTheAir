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

        [Required(ErrorMessage = "please provide a expiration date!")]
        [Display(Name = "expires at")]
        [DataType(DataType.Date, ErrorMessage = "Wrong format !!!!")]
        public DateTime ExpirationDate { get; set; }

        public User User { get; set; }
    }
}