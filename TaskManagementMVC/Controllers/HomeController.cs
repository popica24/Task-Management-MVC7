using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManagementMVC.Business.Project;
using TaskManagementMVC.DataAccess.Abstract;
using TaskManagementMVC.Models;

namespace TaskManagementMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<ProjectModel> _projectsRepo;
        private readonly ProjectStateManager _stateManager;

        public HomeController(
            ILogger<HomeController> logger, 
            IRepository<ProjectModel> projectsRepo, 
            ProjectStateManager stateManager
            )
        {
            _logger = logger;
            _projectsRepo = projectsRepo;
            _stateManager = stateManager;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ProjectModel> projects = await _projectsRepo.GetAll();

            return View(projects);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectModel request)
        {
           await _projectsRepo.Create(request);

            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}