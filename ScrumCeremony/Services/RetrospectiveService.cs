using System.Collections.Generic;
using ScrumCeremony.Models;

namespace ScrumCeremony.Services
{
    public class RetrospectiveService : IRetrospectiveService
    {
        public IEnumerable<Retrospective> GetRetrospectives()
        {
            return Database.GetRetrospectives();
        }

        public IEnumerable<Retrospective> GetRetrospectivesByDate(string date)
        {
            return Database.GetRetrospectivesByDate(date);
        }

        public void AddRetrospective(Retrospective retrospective)
        {
            Database.AddNewRetrospective(retrospective);
        }

        public void AddRetrospectiveFeedback(string retrospectiveName, Feedback feedback)
        {
            Database.AddFeedbackToRetrospective(retrospectiveName, feedback);
        }
    }
}