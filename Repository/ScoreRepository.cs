using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DAO;

namespace Repository
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly IScoreDAO _scoreDAO;

        public ScoreRepository(IScoreDAO scoreDAO)
        {
            _scoreDAO = scoreDAO;
        }

        public async Task<Score> GetScoreByIdAsync(int id)
        {
            return await _scoreDAO.GetScoreByIdAsync(id);
        }

        public async Task<IEnumerable<Score>> GetScoresByProjectIdAsync(int projectId)
        {
            return await _scoreDAO.GetScoresByProjectIdAsync(projectId);
        }

        public async Task AddScoreAsync(Score score)
        {
            await _scoreDAO.AddScoreAsync(score);
        }

        public async Task UpdateScoreAsync(Score score)
        {
            await _scoreDAO.UpdateScoreAsync(score);
        }

        public async Task DeleteScoreAsync(int id)
        {
            await _scoreDAO.DeleteScoreAsync(id);
        }
    }
}
