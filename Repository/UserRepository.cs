using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DAO;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserDAO _userDAO;

        public UserRepository(IUserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userDAO.GetUserByIdAsync(id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userDAO.GetUserByEmailAsync(email);
        }

        public async Task AddUserAsync(User user)
        {
            await _userDAO.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userDAO.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id) => await _userDAO.DeleteUserAsync(id);
    }
}
