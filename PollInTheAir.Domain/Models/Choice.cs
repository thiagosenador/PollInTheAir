namespace PollInTheAir.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Choice : Entity
    {
        [MaxLength(128)]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "choiceRequired")]
        public string Text { get; set; }

        [NotMapped]
        public bool Selected { get; set; }
    }
}
