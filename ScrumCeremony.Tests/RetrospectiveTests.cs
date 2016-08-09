using System;
using System.Linq;
using NUnit;
using NUnit.Framework;
using ScrumCeremony.Models;
using ScrumCeremony.Services;

namespace ScrumCeremony.Tests
{
    [TestFixture]
    public class RetrospectiveTests
    {
        private IRetrospectiveService retrospectiveService;

        [SetUp]
        public void Setup()
        {
            this.retrospectiveService = new RetrospectiveService();    
        }
        
        [Test]
        public void AddNewRetrospectiveSuccessfully()
        {
            var retrospective = new Retrospective
            {
                Name = "R1",
                Date = DateTime.Now,
                Participants = new[] {"James", "Sean", "Frank"},
            };
            this.retrospectiveService.AddRetrospective(retrospective);
            Assert.AreEqual(retrospective.Name, Database.GetRetrospectives().Last().Name);
        }

        [Test]
        public void AddFeedbackToRetrospectiveSuccessfully()
        {
            var retrospective = this.retrospectiveService.GetRetrospectives().First();
            var feedback = new Feedback
            {
                Name = "New Feedback",
                Body = "Body text",
                FeedbackType = FeedbackType.Positive-27
            };
            this.retrospectiveService.AddRetrospectiveFeedback(retrospective.Name, feedback);

            Assert.AreEqual(retrospective.FeedbackItems, this.retrospectiveService.GetRetrospectives().First().FeedbackItems);
        }

        [Test]
        public void CreateRetrospectiveAndAddFeedback()
        {
            var retrospective = new Retrospective
            {
                Name = "New Retro",
                Date = DateTime.Now,
                Participants = new[] {"Jim", "Fred", "Joe", "Peter"}
            };
            this.retrospectiveService.AddRetrospective(retrospective);

            this.retrospectiveService.AddRetrospectiveFeedback(retrospective.Name, new Feedback
            {
                Name = "Jim",
                Body = "Idea",
                FeedbackType = FeedbackType.Idea
            });
            this.retrospectiveService.AddRetrospectiveFeedback(retrospective.Name, new Feedback
            {
                Name = "Fred",
                Body = "Positive",
                FeedbackType = FeedbackType.Positive
            });

            Assert.AreEqual(this.retrospectiveService.GetRetrospectives().Last(), retrospective);
        }

        [TestCase("2016-07-27", 1)]
        [TestCase("2016-07-25", 0)]
        public void GetRetrospectivesByDate(string date, int expectedCount)
        {
            var retrospectives = this.retrospectiveService.GetRetrospectivesByDate(date);

            Assert.AreEqual(expectedCount, retrospectives.Count());
        }
    }
}
