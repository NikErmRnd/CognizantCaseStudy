using CognizantCaseStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace CognizantCaseStudy.DB.Services
{
    public class SubmittedChallengeResultRepository : ISubmittedChallengeResultRepository
    {
        private readonly ApplicationContext _context;

        public SubmittedChallengeResultRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(SubmittedChallengeResult submittedChallengeResult)
        {
            await _context.SubmittedChallengeResults.AddAsync(submittedChallengeResult);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SubmittedChallengeResult>> All()
        {
            return await _context.SubmittedChallengeResults.ToListAsync();
        }
    }
}
