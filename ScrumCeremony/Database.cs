using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ScrumCeremony.Models;

namespace ScrumCeremony
{
    public static class Database
    {
        private static List<Retrospective> _retrospectives = new List<Retrospective>();

        static Database()
        {
            _retrospectives.Add(new Retrospective
            {
                Name = "Retrospective",
                Summary = "Post release retrospective",
                Date = DateTime.Parse("27/07/2016"),
                Participants = new [] { "Viktor", "Gareth", "Mike"},
                FeedbackItems = new List<Feedback>
                {
                    new Feedback
                    {
                        Name = "Gareth",
                        Body = "Sprint objective met",
                        FeedbackType = FeedbackType.Positive
                    },
                    new Feedback
                    {
                        Name = "Viktor",
                        Body = "Too many items piled up in the awaiting QA",
                        FeedbackType = FeedbackType.Negative
                    },
                    new Feedback
                    {
                        Name = "Mike",
                        Body = "We should be looking to start using VS2015",
                        FeedbackType = FeedbackType.Idea
                    },
                }
            });    
        }

        /* the below code could be done via EF or some other form of ORM with/without the repository pattern etc */
        public static List<Retrospective> GetRetrospectives()
        {
            return _retrospectives;
        }

        public static List<Retrospective> GetRetrospectivesByDate(string date)
        {
            DateTime retrospectiveDate;
            DateTime.TryParse(date, out retrospectiveDate);
            return _retrospectives.FindAll(r => r.Date == retrospectiveDate);
        } 

        public static void AddNewRetrospective(Retrospective retrospective)
        {
            if (!_retrospectives.Exists(r => r.Name == retrospective.Name))
            {
                _retrospectives.Add(retrospective);
            }
        }

        public static void AddFeedbackToRetrospective(string retrospectiveName, Feedback feedback)
        {
            var retrospective = _retrospectives.Find(r => r.Name == retrospectiveName);
            if (retrospective != null)
            {
               retrospective.FeedbackItems.Add(feedback);
            }
        }
    }
}