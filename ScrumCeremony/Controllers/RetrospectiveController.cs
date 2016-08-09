using System;
using System.Web;
using System.Web.Http;
using ScrumCeremony.Models;
using ScrumCeremony.Services;
using ScrumCeremony.Utils;

namespace ScrumCeremony.Controllers
{
    [RoutePrefix("api/retrospective")]
    public class RetrospectiveController : ApiController
    {
        private readonly ILogger logger;
        private readonly IRetrospectiveService retrospectiveService;

        public RetrospectiveController()
        {
            this.logger = new Logger();
            this.retrospectiveService = new RetrospectiveService();
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return this.Ok(this.retrospectiveService.GetRetrospectives());
        }

        [Route("{date}")]
        public IHttpActionResult GetByDate(string date)
        {
            return this.Ok(this.retrospectiveService.GetRetrospectivesByDate(date));
        }

        /*
         * I chose to add the "add" prefix so you could distinctively see
         * what this API route was doing. For example, if a user was given
         * this url to use, they'd instantly know it was to add a new one.
         * If I didn't have the "add" and had POST/PUT/DELETE verbs then 
         * the consumer might not know what they'd have to use. This would
         * be fixed via documentation however. My view is there is two ways
         * this can be done depending on the designer of the API.    
        */
        [Route("")]
        [HttpPost]
        public IHttpActionResult AddRetrospective(Retrospective retrospective)
        {
            try
            {
                this.retrospectiveService.AddRetrospective(retrospective);
                return this.Created("/api/retrospective", retrospective);
            }
            catch (Exception ex)
            {
                this.logger.Log(ex, "Couldn't add feedback to retrospective");
                return this.InternalServerError(ex);
            }
        }


        [Route("addfeedback")]
        [HttpPost]
        public IHttpActionResult AddRetrospectiveFeedback(Feedback feedback)
        {
            try
            {
                string name = HttpUtility.ParseQueryString(Request.RequestUri.Query).Get("name");
                this.retrospectiveService.AddRetrospectiveFeedback(name, feedback);
                return this.Created("/api/retrospective/addfeedback", feedback);
            }
            catch (Exception ex)
            {
                this.logger.Log(ex, "Couldn't add feedback to retrospective");
                return this.InternalServerError(ex);
            }
        }
    }
}
