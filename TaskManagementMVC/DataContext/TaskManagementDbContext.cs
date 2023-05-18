using Microsoft.EntityFrameworkCore;
using TaskManagementMVC.Models;

namespace TaskManagementMVC.DataContext
{
    public class TaskManagementDbContext : DbContext
    {
        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options) : base(options) { }

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskModel>()
                .HasOne(t => t.user)             // Specify that a Task has a single User
                .WithMany(u => u.Tasks)          // Specify that a User can have multiple Tasks
                .HasForeignKey(t => t.UserID);   // Set the foreign key property in the Task entity to UserId
        }
    }
}
