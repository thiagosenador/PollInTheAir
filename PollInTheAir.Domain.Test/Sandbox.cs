using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PollInTheAir.Domain.Models;
using PollInTheAir.Domain.Repository;
using PollInTheAir.Domain.Repository.Impl;

namespace PollInTheAir.Domain.Test
{
    [TestClass]
    public class Sandbox
    {
        [TestMethod]
        public void SandboxTest()
        {
            var context = new AppDbContext();

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

        [TestMethod]
        public void CallResponse()
        {
            var r = new PollAnswerRepository(new AppDbContext());

            var res = r.GetPollResults(1);
        }
    }
}
