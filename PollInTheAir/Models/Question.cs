namespace PollInTheAir.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string Statement { get; set; }

        public QuestionType Type { get; set; }

        public string[] Options { get; set; }
    }
}