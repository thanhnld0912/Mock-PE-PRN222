using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DAO;

namespace Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ITeamDAO _teamDAO;

        public TeamRepository(ITeamDAO teamDAO)
        {
            _teamDAO = teamDAO;
        }

        public async Task<Team> GetTeamByIdAsync(int id)
        {
            return await _teamDAO.GetTeamByIdAsync(id);
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return await _teamDAO.GetAllTeamsAsync();
        }

        public async Task AddTeamAsync(Team team)
        {
            await _teamDAO.AddTeamAsync(team);
        }

        public async Task UpdateTeamAsync(Team team)
        {
            await _teamDAO.UpdateTeamAsync(team);
        }

        public async Task DeleteTeamAsync(int id)
        {
            await _teamDAO.DeleteTeamAsync(id);
        }
    }
}
