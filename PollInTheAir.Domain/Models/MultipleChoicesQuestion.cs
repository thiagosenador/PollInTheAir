﻿namespace PollInTheAir.Domain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class MultipleChoicesQuestion : Question
    {
        [Display(Name = "choices")]
        public List<Choice> Choices { get; set; }

        [Required]
        [Display(Name = "can select multiple choices")]
        public bool CanSelectMultiple { get; set; }
    }
}