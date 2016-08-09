using System.Collections.Generic;
using ScrumCeremony.Models;

namespace ScrumCeremony.Services
{
    /*
     * this will define a service that will allow abstract the underlying database
     * away from the calling code. This benefits us as it can let us change the
     * database/store underneath without having to modify code elsewhere
     * Note: this could also be done as a repository pattern etc.
     */
    public interface IRetrospectiveService
    {
        IEnumerable<Retrospective> GetRetrospectives();
        IEnumerable<Retrospective> GetRetrospectivesByDate(string date);
        void AddRetrospective(Retrospective retrospective);
        void AddRetrospectiveFeedback(string retrospectiveName, Feedback feedback);
    }
}