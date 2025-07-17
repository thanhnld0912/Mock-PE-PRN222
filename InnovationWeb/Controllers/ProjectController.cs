using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace InnovationWeb.Controllers
{
    [Route("projects")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
                return NotFound();

            return View(project);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProject([FromBody] Project project)
        {
            await _projectService.AddProjectAsync(project);
            return RedirectToAction("GetProject", new { id = project.Id });
        }

        [HttpPost("approve/{id}")]
        public async Task<IActionResult> ApproveProject(int id)
        {
            await _projectService.ApproveProjectAsync(id);
            return RedirectToAction("GetProject", new { id });
        }

        [HttpPost("reject/{id}")]
        public async Task<IActionResult> RejectProject(int id)
        {
            await _projectService.RejectProjectAsync(id);
            return RedirectToAction("GetProject", new { id });
        }

        [HttpPost("score")]
        public async Task<IActionResult> ScoreProject(int projectId, int lecturerId, int score, string comment)
        {
            await _projectService.ScoreProjectAsync(projectId, lecturerId, score, comment);
            return RedirectToAction("GetProject", new { id = projectId });
        }
    }
}