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
        private readonly TaskManagementDbContext _context;

        public UserRepository(TaskManagementDbContext context)
        {
            _context = context;    
        }

        public async Task<int> Create(UserModel model)
        {
            _context.Users.Add(model);
            await _context.SaveChangesAsync();
            return model.ID;
        }

        public async Task Delete(int id)
        {
            var model = await GetById(id);
            if(model != null)
            {
                _context.Users.Remove(model);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<UserModel>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _context.Users.FirstAsync(x => x.ID == id);
        }

        public async Task Update(UserModel model)
        {
            _context.Users.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
