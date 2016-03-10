using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace PollInTheAir.Domain.Models
{
    public class Note : Entity
    {
        [MaxLength(128)]
        [Display(Name = "description", ResourceType = typeof(Resources.Resources))]
        public string Description { get; set; }

        [Required]
        public DbGeography CreationLocation { get; set; }

        [MaxLength(128)]
        [Display(Name = "image", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "imageRequired")]
        public byte[] Image { get; set; }

        [Display(Name = "range", ResourceType = typeof(Resources.Resources))]
        public float Range { get; set; }

        [Display(Name = "creationDate", ResourceType = typeof(Resources.Resources))]
        public DateTime CreationDate { get; set; }

        public virtual List<NoteComment> Comments { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
