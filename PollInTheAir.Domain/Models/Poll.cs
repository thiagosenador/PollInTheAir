﻿namespace PollInTheAir.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Poll : Entity
    {
        [MaxLength(128)]
        [Display(Name = "name", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "nameRequired")]
        public string Name { get; set; }

        public Location CreationLocation { get; set; }

        [Display(Name = "range", ResourceType = typeof(Resources.Resources))]
        public float Range { get; set; }

        [Display(Name = "questions", ResourceType = typeof(Resources.Resources))]
        public virtual List<Question> Questions { get; set; }

        [Display(Name = "creationDate", ResourceType = typeof(Resources.Resources))]
        public DateTime CreationDate { get; set; }

        [Display(Name = "expirationDate", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "expirationDateRequired")]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}