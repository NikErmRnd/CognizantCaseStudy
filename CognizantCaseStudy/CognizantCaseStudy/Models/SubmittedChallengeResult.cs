namespace CognizantCaseStudy.Models
{
    public class SubmittedChallengeResult
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public string TaskName { get; set; }
        public bool IsSuccess { get; set; }
    }
}
