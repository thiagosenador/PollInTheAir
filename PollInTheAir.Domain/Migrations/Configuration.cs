namespace PollInTheAir.Domain.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    using PollInTheAir.Domain.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Repository.AppDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Repository.AppDbContext context)
        {
            this.CreatePoll(context);

            this.CreateAnswer(context);
        }

        private void CreatePoll(Repository.AppDbContext context)
        {
            var multiple = new MultipleChoicesQuestion
            {
                Type = QuestionType.MultipleChoices,
                Statement = "multiple choices",
                CanSelectMultiple = true,
                Choices =
                                       new List<Choice>
                                           {
                                               new Choice { Text = "11111" },
                                               new Choice { Text = "22222" },
                                               new Choice { Text = "33333" }
                                           }
            };

            var freeText = new Question { Statement = "free text", Type = QuestionType.FreeText };

            var poll = new Poll
            {
                Name = "agora vai",
                Range = 50,
                CreationDate = DateTime.Now,
                ExpirationDate = new DateTime(2020, 01, 01),
                CreationLocation = new Location { Latitude = 90.0f, Longitude = 50.0f },
                Questions = new List<Question> { multiple, freeText },
            };

            context.Polls.Add(poll);
        }

        private void CreateAnswer(Repository.AppDbContext context)
        {
            var freeAnswer = new FreeTextAnswer { Comment = "my comments", QuestionId = 2 };

            var multipleAns = new MultipleChoicesAnswer
                                  {
                                      QuestionId = 1,
                                      SelectedChoices =
                                          new List<Choice>
                                              {
                                                  new Choice { Id = 1 },
                                                  new Choice { Id = 3 }
                                              }
                                  };

            var answer = new PollAnswer
                             {
                                 AnswerDate = DateTime.Now,
                                 PollId = 1,
                                 QuestionAnswers = new List<QuestionAnswer> { freeAnswer, multipleAns }
                             };

            context.PollAnswers.Add(answer);
        }
    }
}
