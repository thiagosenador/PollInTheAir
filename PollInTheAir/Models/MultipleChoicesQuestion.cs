using System.Collections.Generic;

namespace PollInTheAir.Models
{
    public class MultipleChoicesQuestion
    {
        public string Title { get; set; }
        public List<string> Choices { get; set; }
    }
}