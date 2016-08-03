using System;
using System.Collections.Generic;

namespace ScrumCeremony.Models
{
    public class Retrospective
    {
        public Retrospective()
        {
            FeedbackItems = new List<Feedback>();
        }
        
        public string Name { get; set; }
        public string Summary { get; set; }
        public DateTime Date { get; set; }

        public string[] Participants { get; set; }

        public List<Feedback> FeedbackItems { get; set; }
    }
}