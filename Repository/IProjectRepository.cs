using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repository
{
    public interface IProjectRepository
    {
        Task<Project> GetProjectByIdAsync(int id);
        Task<IEnumerable<Project>> GetProjectsByTeamIdAsync(int teamId);
        Task AddProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(int id);
        string? GetAllProjectsWithTeams();
    }
}
