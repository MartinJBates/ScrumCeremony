using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;
using ScrumCeremony.Models;
using ScrumCeremony.Utils;

namespace ScrumCeremony.Controllers
{
    [RoutePrefix("api/retrospective")]
    public class RetrospectiveController : ApiController
    {
        private readonly ILogger logger;

        public RetrospectiveController()
        {
            this.logger = new Logger();
        }

        [Route("")]
        public IEnumerable<Retrospective> Get()
        {
            return Database.GetRetrospectives();
        }

        [Route("{date}")]
        public IEnumerable<Retrospective> GetByDate(string date)
        {
            return Database.GetRetrospectivesByDate(date);
        }

        [Route("addretrospective")]
        [HttpPost]
        public bool AddRetrospective(Retrospective retrospective)
        {
            try
            {
                Database.AddNewRetrospective(retrospective);
                return true;
            }
            catch (Exception ex)
            {
                this.logger.Log(ex, "Couldn't add feedback to retrospective");
                return false;
            }
        }


        [Route("addretrospectivefeedback")]
        [HttpPost]
        public void AddRetrospectiveFeedback(Feedback feedback)
        {
            try
            {
                string name = HttpUtility.ParseQueryString(Request.RequestUri.Query).Get("name");
                Database.AddFeedbackToRetrospective(name, feedback);
            }
            catch (Exception ex)
            {
                this.logger.Log(ex, "Couldn't add feedback to retrospective");
            }
        }
    }
}
