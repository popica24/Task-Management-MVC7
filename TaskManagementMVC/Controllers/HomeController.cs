using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManagementMVC.Business.Task;
using TaskManagementMVC.DataAccess;
using TaskManagementMVC.DataAccess.Abstract;
using TaskManagementMVC.DataAccess.TaskDAL;
using TaskManagementMVC.DataAccess.UserDAL;
using TaskManagementMVC.Models;
using TaskManagementMVC.Models.Enums;

namespace TaskManagementMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<UserModel> _userRepository;
        private readonly IRepository<TaskModel> _taskRepository;
        private readonly TaskStateManager _stateManager;
        public HomeController(ILogger<HomeController> logger, IRepository<TaskModel>? taskRepository, 
            IRepository<UserModel>? userRepository, TaskStateManager stateManager)
        {
            _logger = logger;
            _userRepository = userRepository;
            _taskRepository = taskRepository;
            _stateManager = stateManager;
         
        }

        public IActionResult Index()
        {
            var list = _taskRepository.GetAll().Result;
            _stateManager.SetTask(_taskRepository.GetById(2).Result);

            _stateManager.Request();
            
           
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}