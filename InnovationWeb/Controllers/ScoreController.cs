using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace InnovationWeb.Controllers
{
    [Route("scores")]
    public class ScoreController : Controller
    {
        private readonly IScoreRepository _scoreRepository;

        public ScoreController(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        [HttpGet("project/{projectId}")]
        public async Task<IActionResult> GetScoresByProjectId(int projectId)
        {
            var scores = await _scoreRepository.GetScoresByProjectIdAsync(projectId);
            if (scores == null || !scores.Any())
                return NotFound();

            return View(scores);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateScore([FromBody] Score score)
        {
            await _scoreRepository.AddScoreAsync(score);
            return RedirectToAction("GetScoresByProjectId", new { projectId = score.ProjectId });
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateScore(int id, [FromBody] Score updatedScore)
        {
            var score = await _scoreRepository.GetScoreByIdAsync(id);
            if (score == null)
                return NotFound();

            score.Score1 = updatedScore.Score1;
            score.Comment = updatedScore.Comment;

            await _scoreRepository.UpdateScoreAsync(score);
            return RedirectToAction("GetScoresByProjectId", new { projectId = score.ProjectId });
        }
    }
}
