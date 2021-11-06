using CognizantCaseStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace CognizantCaseStudy.DB.Services
{
    public class CodeChallengeRepository : ICodeChallengeRepository
    {
        private readonly ApplicationContext _context;

        public CodeChallengeRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<CodeChallenge>> All()
        {
            return await _context.CodeChallenges.ToListAsync();
        }
    }
}
