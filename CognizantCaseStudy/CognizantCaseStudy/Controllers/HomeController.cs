using CognizantCaseStudy.DB.Services;
using CognizantCaseStudy.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CognizantCaseStudy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICodeChallengeRepository _codeChallengeRepository;

        public HomeController(ICodeChallengeRepository codeChallengeRepository)
        {
            _codeChallengeRepository = codeChallengeRepository;
        }

        public async Task<IActionResult> Index()
        {
            var challengeList = await _codeChallengeRepository.All();
            challengeList.Insert(0, new CodeChallenge());
            return View(challengeList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}