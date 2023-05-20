using Microsoft.EntityFrameworkCore;
using TaskManagementMVC.DataAccess.Abstract;
using TaskManagementMVC.Models;
using TaskManagementMVC.DataContext;

namespace TaskManagementMVC.DataAccess.TaskRepo
{
    public class ProjectRepository : IRepository<ProjectModel>
    {
        private readonly TechfolioDbContext _context;

        public ProjectRepository(TechfolioDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(ProjectModel model)
        {
            model.Status = Models.Enums.Status.Planning;
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

        public async Task<List<ProjectModel>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<ProjectModel> GetById(int id)
        {
            return await _context.Tasks.FirstAsync(x => x.ID == id);
        }

        public async Task Update(ProjectModel model)
        {
            _context.Tasks.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
