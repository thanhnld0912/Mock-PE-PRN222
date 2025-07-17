using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace InnovationWeb.Controllers
{
    [Route("teams")]
    public class TeamController : Controller
    {
        private readonly ITeamRepository _teamRepository;

        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            var team = await _teamRepository.GetTeamByIdAsync(id);
            if (team == null)
                return NotFound();

            return View(team);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTeam([FromBody] Team team)
        {
            await _teamRepository.AddTeamAsync(team);
            return RedirectToAction("GetTeam", new { id = team.Id });
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateTeam(int id, [FromBody] Team updatedTeam)
        {
            var team = await _teamRepository.GetTeamByIdAsync(id);
            if (team == null)
                return NotFound();

            team.TeamName = updatedTeam.TeamName;
            team.Description = updatedTeam.Description;

            await _teamRepository.UpdateTeamAsync(team);
            return RedirectToAction("GetTeam", new { id = team.Id });
        }
    }
}