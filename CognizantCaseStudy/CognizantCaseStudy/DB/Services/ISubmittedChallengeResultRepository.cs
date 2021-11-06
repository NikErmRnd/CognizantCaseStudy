using CognizantCaseStudy.Models;

namespace CognizantCaseStudy.DB.Services
{
    public interface ISubmittedChallengeResultRepository
    {
        Task Add(SubmittedChallengeResult submittedChallengeResult);
        Task<List<SubmittedChallengeResult>> All();
    }
}
