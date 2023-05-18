using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementMVC.DataAccess.Abstract;
using TaskManagementMVC.Models;
using TaskManagementMVC.DataContext;

namespace TaskManagementMVC.DataAccess.TaskDAL
{
    public class TaskRepository : IRepository<TaskModel>
    {
        private readonly TaskManagementDbContext _context;

        public TaskRepository(TaskManagementDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(TaskModel model)
        {
            _context.Tasks.Add(model);
            await _context.SaveChangesAsync();
            return model.ID;
        }

        public async Task Delete(int id)
        {
            var model = await GetById(id);
            if (model != null)
            {
                _context.Tasks.Remove(model);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TaskModel>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskModel> GetById(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task Update(TaskModel model)
        {
            _context.Tasks.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
