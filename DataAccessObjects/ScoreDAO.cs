using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class ScoreDAO : IScoreDAO
    {
        private readonly InnovationDbContext _context;

        public ScoreDAO(InnovationDbContext context)
        {
            _context = context;
        }

        public async Task<Score> GetScoreByIdAsync(int id)
        {
            return await _context.Scores
                .Include(s => s.Project)
                .Include(s => s.Lecturer)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Score>> GetScoresByProjectIdAsync(int projectId)
        {
            return await _context.Scores
                .Where(s => s.ProjectId == projectId)
                .Include(s => s.Project)
                .Include(s => s.Lecturer)
                .ToListAsync();
        }

        public async Task AddScoreAsync(Score score)
        {
            await _context.Scores.AddAsync(score);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateScoreAsync(Score score)
        {
            _context.Scores.Update(score);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteScoreAsync(int id)
        {
            var score = await GetScoreByIdAsync(id);
            if (score != null)
            {
                _context.Scores.Remove(score);
                await _context.SaveChangesAsync();
            }
        }
    }
}
