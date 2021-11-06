using CognizantCaseStudy.DB.Services;
using CognizantCaseStudy.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CognizantCaseStudy.Controllers
{
    public class LeaderboardController : Controller
    {
        private readonly ISubmittedChallengeResultRepository _submittedChallengeResultRepository;

        public LeaderboardController(ISubmittedChallengeResultRepository submittedChallengeResultRepository)
        {
            _submittedChallengeResultRepository = submittedChallengeResultRepository;
        }

        public async Task<IActionResult> Index()
        {
            var submittedChallengeResults = await _submittedChallengeResultRepository.All();
            var resultsViewModel = submittedChallengeResults.Where(item => item.IsSuccess)
                                                            .GroupBy(item => item.PlayerName)
                                                            .OrderByDescending(item => item.Count())
                                                            .Take(3)
                                                            .Select(item => new SubmittedChallengeResultsViewModel(
                                                                                  item.Key,
                                                                                  item.Count(),
                                                                 string.Join(",", item.Select(item => item.TaskName).Distinct())))
                                                            .ToList();
            return View(resultsViewModel);
        }
    }
}
