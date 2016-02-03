﻿namespace PollInTheAir.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Choice : Entity
    {
        [Required]
        [MaxLength(128)]
        public string Text { get; set; }
    }
}