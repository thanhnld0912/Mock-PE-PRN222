using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repository;

namespace Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IScoreRepository _scoreRepository;
        private readonly ITeamRepository _teamRepository;

        public ProjectService(IProjectRepository projectRepository, IScoreRepository scoreRepository, ITeamRepository teamRepository)
        {
            _projectRepository = projectRepository;
            _scoreRepository = scoreRepository;
            _teamRepository = teamRepository;
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _projectRepository.GetProjectByIdAsync(id);
        }

        public async Task<IEnumerable<Project>> GetProjectsByTeamIdAsync(int teamId)
        {
            return await _projectRepository.GetProjectsByTeamIdAsync(teamId);
        }

        public async Task AddProjectAsync(Project project)
        {
            await _projectRepository.AddProjectAsync(project);
        }

        public async Task UpdateProjectAsync(Project project)
        {
            await _projectRepository.UpdateProjectAsync(project);
        }

        public async Task DeleteProjectAsync(int id)
        {
            await _projectRepository.DeleteProjectAsync(id);
        }

        public async Task ApproveProjectAsync(int projectId)
        {
            var project = await _projectRepository.GetProjectByIdAsync(projectId);
            if (project != null)
            {
                project.IsApproved = true;
                await _projectRepository.UpdateProjectAsync(project);
            }
        }

        public async Task RejectProjectAsync(int projectId)
        {
            var project = await _projectRepository.GetProjectByIdAsync(projectId);
            if (project != null)
            {
                project.IsApproved = false;
                await _projectRepository.UpdateProjectAsync(project);
            }
        }

        public async Task ScoreProjectAsync(int projectId, int lecturerId, int score, string comment)
        {
            var scoreEntity = new Score
            {
                ProjectId = projectId,
                LecturerId = lecturerId,
                Score1 = score,
                Comment = comment
            };
            await _scoreRepository.AddScoreAsync(scoreEntity);
        }
    }
}
