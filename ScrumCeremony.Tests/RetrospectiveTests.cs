using System;
using System.Linq;
using NUnit;
using NUnit.Framework;
using ScrumCeremony.Models;

namespace ScrumCeremony.Tests
{
    [TestFixture]
    public class RetrospectiveTests
    {
        [SetUp]
        public void Setup()
        {
                
        }
        
        [Test]
        public void AddNewRetrospectiveSuccessfully()
        {
            Database.AddNewRetrospective(new Retrospective
            {
                Name = "R1",
                Date = DateTime.Now,
                Participants = new[] {"James", "Sean", "Frank"},
            });
            Assert.AreEqual(2, Database.GetRetrospectives().Count);
        }

        [Test]
        public void AddFeedbackToRetrospectiveSuccessfully()
        {
            var retrospective = Database.GetRetrospectives().First();
            retrospective.FeedbackItems.Add(new Feedback
            {
                Name = "New Feedback",
                Body = "Body text",
                FeedbackType = FeedbackType.Positive-27
            });

            Assert.AreEqual(4, retrospective.FeedbackItems.Count);
        }

        [TestCase("2016-07-27", 1)]
        [TestCase("2016-07-25", 0)]
        public void GetRetrospectivesByDate(string date, int expectedCount)
        {
            var retrospectives = Database.GetRetrospectivesByDate(date);

            Assert.AreEqual(expectedCount, retrospectives.Count);
        }
    }
}
