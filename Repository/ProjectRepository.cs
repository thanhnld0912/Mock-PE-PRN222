using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DAO;

namespace Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IProjectDAO _projectDAO;

        public ProjectRepository(IProjectDAO projectDAO)
        {
            _projectDAO = projectDAO;
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _projectDAO.GetProjectByIdAsync(id);
        }

        public async Task<IEnumerable<Project>> GetProjectsByTeamIdAsync(int teamId)
        {
            return await _projectDAO.GetProjectsByTeamIdAsync(teamId);
        }

        public async Task AddProjectAsync(Project project)
        {
            await _projectDAO.AddProjectAsync(project);
        }

        public async Task UpdateProjectAsync(Project project)
        {
            await _projectDAO.UpdateProjectAsync(project);
        }

        public async Task DeleteProjectAsync(int id)
        {
            await _projectDAO.DeleteProjectAsync(id);
        }
    }
}
