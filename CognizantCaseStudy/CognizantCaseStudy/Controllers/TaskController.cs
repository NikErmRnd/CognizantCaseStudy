using CognizantCaseStudy.DB.Services;
using CognizantCaseStudy.Models;
using Microsoft.AspNetCore.Mvc;

namespace CognizantCaseStudy.Controllers
{
    public class TaskController : Controller
    {
        private readonly ICodeChallengeSubmitterService _codeChallengeSubmitterService;
        private readonly ICodeChallengeRepository _codeChallengeRepository;
        private readonly ISubmittedChallengeResultRepository _submittedChallengeResultRepository;
        private int retryCount = 20;
        private readonly TimeSpan delay = TimeSpan.FromMilliseconds(10);

        public TaskController(ICodeChallengeSubmitterService codeChallengeSubmitterService,
                              ICodeChallengeRepository codeChallengeRepository,
                              ISubmittedChallengeResultRepository submittedChallengeResultRepository)
        {
            _codeChallengeSubmitterService = codeChallengeSubmitterService;
            _codeChallengeRepository = codeChallengeRepository;
            _submittedChallengeResultRepository = submittedChallengeResultRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Submit(TaskSubmitModel model)
        {
            if (ModelState.IsValid)
            {
                var task = (await _codeChallengeRepository.All()).First(item => item.Description == model.CodeTask);

                string submitOutput = await SubmitCodeWithRetry(model, task);

                await _submittedChallengeResultRepository.Add(
                    new SubmittedChallengeResult() { PlayerName = model.Person,
                                                     TaskName = model.CodeTask,
                                                     IsSuccess = submitOutput == task.OutputParameter });

                return RedirectToActionPermanent("Index", "Leaderboard");
            }
            return new BadRequestObjectResult("validation or submiting issue");
        }

        private async Task<string> SubmitCodeWithRetry(TaskSubmitModel model, CodeChallenge task)
        {
            int currentRetry = 0;

            string submitOutput;

            for (; ; )
            {
                submitOutput = await _codeChallengeSubmitterService.Submit(model.Code, task.TestInputParameter);
                currentRetry++;
                if (currentRetry > this.retryCount || !submitOutput.Contains("Unable to execute"))
                {
                    submitOutput = submitOutput.Replace("\n", "");
                    break;
                }
                await Task.Delay(delay);
            }

            return submitOutput;
        }
    }
}
