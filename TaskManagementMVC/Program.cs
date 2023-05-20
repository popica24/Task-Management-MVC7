using Microsoft.EntityFrameworkCore;
using TaskManagementMVC.Business.Project;
using TaskManagementMVC.Business.Project.Abstract;
using TaskManagementMVC.Business.Project.ProjectStates;
using TaskManagementMVC.DataAccess.Abstract;
using TaskManagementMVC.DataAccess.TaskRepo;
using TaskManagementMVC.DataContext;
using TaskManagementMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TechfolioDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Techfolio"));
});

builder.Services.AddScoped<IRepository<ProjectModel>, ProjectRepository>();

builder.Services.AddScoped<IProjectState, Planning>();
builder.Services.AddScoped<IProjectState, InProcess>();
builder.Services.AddScoped<IProjectState, Completed>();

builder.Services.AddScoped<ProjectStateManager>();



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
