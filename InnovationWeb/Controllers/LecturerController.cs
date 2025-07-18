using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace InnovationWeb.Controllers
{
    public class LecturerController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IScoreRepository _scoreRepository;

        public LecturerController(IProjectRepository projectRepository, IScoreRepository scoreRepository)
        {
            _projectRepository = projectRepository;
            _scoreRepository = scoreRepository;
        }

        // Trang chủ của giảng viên, hiển thị danh sách các dự án của học sinh
        public IActionResult Index()
        {
            var projects = _projectRepository.GetAllProjectsWithTeams();
            return View(projects);
        }

        // Xem chi tiết một dự án
        public IActionResult ProjectDetails(int projectId)
        {
            var project = _projectRepository.GetProjectByIdAsync(projectId);
            return View(project);
        }

        // Duyệt và chấm điểm dự án
        [HttpPost]
        public IActionResult ScoreProject(int projectId, int score, string comment)
        {
            var scoreEntity = new Score
            {
                ProjectId = projectId,
                LecturerId = int.Parse(HttpContext.Session.GetString("UserId")),
                Score1 = score,
                Comment = comment
            };

            _scoreRepository.AddScoreAsync(scoreEntity);

            return RedirectToAction("Index");
        }
    }
}
