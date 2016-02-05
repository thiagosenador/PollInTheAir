namespace PollInTheAir.Web.ViewModel
{
    using PollInTheAir.Domain.Models;

    public class AnswerPollViewModel
    {
        public string PollName { get; set; }

        public Question CurrentQuestion { get; set; }
    }
}