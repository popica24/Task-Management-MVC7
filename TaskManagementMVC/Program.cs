using Microsoft.EntityFrameworkCore;
using TaskManagementMVC.DataAccess;
using TaskManagementMVC.DataAccess.Abstract;
using TaskManagementMVC.DataAccess.TaskDAL;
using TaskManagementMVC.DataAccess.UserDAL;
using TaskManagementMVC.DataContext;
using TaskManagementMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TaskManagementDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaskManagement"));
});

builder.Services.AddScoped<IRepository<UserModel>,UserRepository>();
builder.Services.AddScoped<IRepository<TaskModel>, TaskRepository>();

//builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryFactory));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();