namespace ScrumCeremony.Models
{
    public class Feedback
    {
        public string Name { get; set; }
        public string Body { get; set; }
        public FeedbackType FeedbackType { get; set; }
    }

    public enum FeedbackType
    {
        Positive = 0,
        Negative = 1,
        Idea = 2,
        Praise = 3
    }
}