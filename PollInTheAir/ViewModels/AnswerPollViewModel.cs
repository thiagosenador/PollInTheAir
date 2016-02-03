namespace PollInTheAir.Web.ViewModels
{
    using PollInTheAir.Domain.Models;

    public class AnswerPollViewModel
    {
        private int currentQuestionIndex;

        public Poll Poll { get; set; }

        public Question CurrentQuestion
        {
            get
            {
                Question question = null;

                if (this.currentQuestionIndex < this.Poll.Questions.Count)
                {
                    question = this.Poll.Questions[this.currentQuestionIndex];
                }

                return question;
            }
        }

        public void Increment()
        {
            ++this.currentQuestionIndex;
        }
    }
}