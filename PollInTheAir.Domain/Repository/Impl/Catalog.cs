﻿namespace PollInTheAir.Domain.Repository.Impl
{
    using System;

    public class Catalog : ICatalog, IDisposable
    {
        private readonly AppDbContext context;

        private IPollRepository pollRepository;

        private IPollAnswerRepository pollAnswerRepository;

        private INoteRepository noteRepository;

        private IFileRepository fileRepository;

        private INoteCommentRepository noteCommentRepository;

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

        public INoteRepository Notes
        {
            get
            {
                return this.noteRepository ?? (this.noteRepository = new NoteRepository(this.context));
            }
        }

        public IFileRepository Files
        {
            get
            {
                return this.fileRepository ?? (this.fileRepository = new FileRepository(this.context));
            }
        }

        public INoteCommentRepository NoteComments
        {
            get
            {
                return this.noteCommentRepository ?? (this.noteCommentRepository = new NoteCommentRepository(this.context));
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