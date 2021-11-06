using CognizantCaseStudy.Models;

namespace CognizantCaseStudy.DB.Services
{
    public interface ICodeChallengeRepository
    {
        Task<List<CodeChallenge>> All();
    }
}
