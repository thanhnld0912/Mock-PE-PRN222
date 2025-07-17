using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repository
{
    public interface IScoreRepository
    {
        Task<Score> GetScoreByIdAsync(int id);
        Task<IEnumerable<Score>> GetScoresByProjectIdAsync(int projectId);
        Task AddScoreAsync(Score score);
        Task UpdateScoreAsync(Score score);
        Task DeleteScoreAsync(int id);
    }
}
