using CognizantCaseStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace CognizantCaseStudy.DB
{
    public class ApplicationContext : DbContext
    {
        public DbSet<CodeChallenge> CodeChallenges { get; set; }
        public DbSet<SubmittedChallengeResult> SubmittedChallengeResults { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }
    }
}
