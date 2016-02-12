namespace PollInTheAir.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FreeTextAnswer")]
    public class FreeTextAnswer : QuestionAnswer
    {
        [Required(ErrorMessage = "please enter a comment!")]
        [MaxLength(128)]
        public string Comment { get; set; }
    }
}