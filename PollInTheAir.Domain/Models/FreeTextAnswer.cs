namespace PollInTheAir.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FreeTextAnswer")]
    public class FreeTextAnswer : QuestionAnswer
    {
        [MaxLength(128)]
        public string Comment { get; set; }
    }
}