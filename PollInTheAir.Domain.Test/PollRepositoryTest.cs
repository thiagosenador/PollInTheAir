using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace PollInTheAir.Domain.Test
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PollInTheAir.Domain.Models;
    using PollInTheAir.Domain.Repository;

    [TestClass]
    public class PollRepositoryTest
    {
        [TestMethod]
        public void RetrieveEntirePollStructure()
        {
            var context = new AppDbContext();

            var poll = context.Polls.Find(1);
            var free = context.Questions.OfType<Question>().Where(y => y.Type == QuestionType.FreeText).ToList();
            var multiple = context.Questions.OfType<MultipleChoicesQuestion>().Include(c => c.Choices).ToList();

            var questions = new List<Question>();
            questions.AddRange(free);
            questions.AddRange(multiple);

            questions.Sort((x, y) => x.Id.CompareTo(y.Id));

            poll.Questions = questions;
        }

        [TestMethod]
        public void Populate()
        {
            var c = new AppDbContext();

            this.CreatePoll(c);
            // this.CreateAnswer(c);
        }

        private void CreatePoll(AppDbContext context)
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
            context.SaveChanges();
        }

        private void CreateAnswer(AppDbContext context)
        {
            var c1 = new Choice { Id = 1 };
            var c3 = new Choice { Id = 3 };

            var freeAnswer = new FreeTextAnswer { Comment = "my comments", QuestionId = 2 };

            var multipleAns = new MultipleChoicesAnswer
            {
                QuestionId = 1,
                SelectedChoices = new List<Choice> { c1, c3 }
            };

            var answer = new PollAnswer
            {
                AnswerDate = DateTime.Now,
                PollId = 1,
                QuestionAnswers = new List<QuestionAnswer> { freeAnswer, multipleAns }
            };

            context.PollAnswers.AddOrUpdate(answer);
            context.SaveChanges();
        }
    }
}
