using System.Collections.Generic;

namespace PollInTheAir.Domain.Models
{
    public class MultipleChoicesQuestion : Question
    {
        public List<string> Choices { get; set; }

        public bool CanSelectMultiple { get; set; }
    }
}