using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementMVC.DataAccess.Abstract;
using TaskManagementMVC.DataContext;
using TaskManagementMVC.Models;

namespace TaskManagementMVC.DataAccess.UserDAL
{
    public class UserRepository : IRepository<UserModel>
    {
        private readonly TaskManagementDbContext _dbContext;

        public UserRepository(TaskManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(UserModel model)
        {
            _dbContext.Users.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.ID;
        }

        public async Task Delete(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<UserModel>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task Update(UserModel model)
        {
            _dbContext.Users.Update(model);
            await _dbContext.SaveChangesAsync();
        }
    }
}
