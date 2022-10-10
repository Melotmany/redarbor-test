namespace Pandape.CandidatesManager.WebUI.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Pandape.CandidatesManager.Application.CandidateExperiences.Commands;
    using Pandape.CandidatesManager.Application.CandidateExperiences.Queries;
    using Pandape.CandidatesManager.Application.Candidates.Commands;
    using Pandape.CandidatesManager.Application.Candidates.Queries;
    using Pandape.CandidatesManager.Domain.Entities;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IMediator mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var candidates = await mediator.Send(new GetAllCandidatesQuery());
            return View(candidates);
        }

        public IActionResult NewCandidate()
        {
            return View(new Candidate());
        }

        [HttpGet]
        public IActionResult NewCandidateExperience(int id)
        {
            return View(new CandidateExperience() { IdCandidate = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateCandidate(Candidate candidate)
        {
            var addedCandidate = await mediator.Send(new CreateCandidateCommand(candidate));

            return RedirectToAction(nameof(CandidateDetails), new { id = addedCandidate.IdCandidate });
        }

        [HttpPost]
        public async Task<IActionResult> CreateCandidateExperience(CandidateExperience candidateExperience)
        {
            await mediator.Send(new CreateCandidateExperienceCommand(candidateExperience));

            return RedirectToAction(nameof(CandidateDetails), new { id = candidateExperience.IdCandidate });
        }

        [HttpGet]
        public async Task<IActionResult> EditCandidate(int id)
        {
            var candidate = await mediator.Send(new GetCandidateQuery(id));

            return View(candidate);
        }

        [HttpGet]
        public async Task<IActionResult> EditCandidateExperience(int id)
        {
            var candidateExperience = await mediator.Send(new GetCandidateExperienceQuery(id));

            return View(candidateExperience);
        }

        [HttpGet]
        public async Task<IActionResult> CandidateDetails(int id)
        {
            var candidate = await mediator.Send(new GetCandidateQuery(id));

            return View(candidate);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCandidate(Candidate candidate)
        {
            await mediator.Send(new UpdateCandidateCommand(candidate));

            return RedirectToAction(nameof(CandidateDetails), new { id = candidate.IdCandidate });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCandidateExperience(CandidateExperience candidateExperience)
        {
            await mediator.Send(new UpdateCandidateExperienceCommand(candidateExperience));

            return RedirectToAction(nameof(CandidateDetails), new { id = candidateExperience.IdCandidate });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            await mediator.Send(new DeleteCandidateCommand(id));

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCandidateExperience(int id)
        {
            var deletedExperience = await mediator.Send(new DeleteCandidateExperienceCommand(id));

            return RedirectToAction(nameof(CandidateDetails), new { id = deletedExperience.IdCandidate });
        }
    }
}
