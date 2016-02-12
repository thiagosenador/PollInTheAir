namespace PollInTheAir.Domain.Repository.Impl
{
    using System;

    public class Catalog : ICatalog, IDisposable
    {
        private readonly AppDbContext context;

        private IPollRepository pollRepository;

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

            if (this.pollAnswerRepository != null)
            {
                this.pollAnswerRepository.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }
}