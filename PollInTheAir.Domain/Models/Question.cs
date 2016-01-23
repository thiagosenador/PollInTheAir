﻿using System.ComponentModel.DataAnnotations;

namespace PollInTheAir.Domain.Models
{
    public class Question
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(128)]
        [Display(Name = "statement")]
        public string Statement { get; set; }
    }
}