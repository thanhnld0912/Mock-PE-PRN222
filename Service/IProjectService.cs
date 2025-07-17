using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Service
{
    public interface IProjectService
    {
        Task<Project> GetProjectByIdAsync(int id);
        Task<IEnumerable<Project>> GetProjectsByTeamIdAsync(int teamId);
        Task AddProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(int id);
        Task ApproveProjectAsync(int projectId);
        Task RejectProjectAsync(int projectId);
        Task ScoreProjectAsync(int projectId, int lecturerId, int score, string comment);
    }
}
