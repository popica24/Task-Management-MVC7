using Microsoft.EntityFrameworkCore;
using TaskManagementMVC.Models;

namespace TaskManagementMVC.DataContext
{
    public class TechfolioDbContext : DbContext
    {
        public TechfolioDbContext(DbContextOptions<TechfolioDbContext> options) : base(options) { }

        public DbSet<ProjectModel> Tasks { get; set; }

    }
}
