using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManagementMVC.Business.Task;
using TaskManagementMVC.DataAccess.Abstract;
using TaskManagementMVC.Models;

namespace TaskManagementMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<UserModel> _userRepository;
        private readonly IRepository<TaskModel> _taskRepository;
        private readonly TaskStateManager _stateManager;

        public HomeController(ILogger<HomeController> logger, IRepository<TaskModel> taskRepository, 
            IRepository<UserModel> userRepository, TaskStateManager stateManager)
        {
            _logger = logger;
            _userRepository = userRepository;
            _taskRepository = taskRepository;
            _stateManager = stateManager;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<TaskModel> tasks = await _taskRepository.GetAll();
            var filteredTasks = tasks.Where(x => x.UserID == 1);

            return View(filteredTasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskModel request)
        {
           await _taskRepository.Create(request);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}