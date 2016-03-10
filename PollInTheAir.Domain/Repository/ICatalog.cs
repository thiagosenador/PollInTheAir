﻿namespace PollInTheAir.Domain.Repository
{
    public interface ICatalog
    {
        IPollRepository Polls { get; }

        IPollAnswerRepository PollAnswers { get; }

        INoteRepository Notes { get; }
    }
}