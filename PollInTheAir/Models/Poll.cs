namespace PollInTheAir.Models
{
    public class Poll
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Question[] Questions { get; set; }
    }
}