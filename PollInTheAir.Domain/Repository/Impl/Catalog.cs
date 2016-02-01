namespace PollInTheAir.Domain.Repository.Impl
{
    using System;

    public class Catalog : ICatalog, IDisposable
    {
        private readonly AppDbContext context;

        private IPollRepository pollRepository;

        private IQuestionRepository questionRepository;

        private IChoiceRepository choiceRepository;

        private IPollAnswerRepository pollAnswerRepository;

        public Catalog()
        {
            this.context = new AppDbContext();
        }

        public IPollRepository Polls
        {
            get
            {
                return this.pollRepository ?? (this.pollRepository = new PollRepository(this.context));
            }
        }

        public IQuestionRepository Questions
        {
            get
            {
                return this.questionRepository ?? (this.questionRepository = new QuestionRepository(this.context));
            }
        }

        public IChoiceRepository Choices
        {
            get
            {
                return this.choiceRepository ?? (this.choiceRepository = new ChoiceRepository(this.context));
            }
        }

        public IPollAnswerRepository PollAnswers
        {
            get
            {
                return this.pollAnswerRepository ?? (this.pollAnswerRepository = new PollAnswerRepository(this.context));
            }
        }

        public void Dispose()
        {
            if (this.pollRepository != null)
            {
                this.pollRepository.Dispose();
            }

            if (this.questionRepository != null)
            {
                this.questionRepository.Dispose();
            }

            if (this.choiceRepository != null)
            {
                this.choiceRepository.Dispose();
            }

            if (this.pollAnswerRepository != null)
            {
                this.pollAnswerRepository.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }
}