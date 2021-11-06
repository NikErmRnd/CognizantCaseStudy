namespace CognizantCaseStudy.DB.Services
{
    public interface ICodeChallengeSubmitterService
    {
        Task<string> Submit(string script, string args);
    }
}
