using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
        public HomeController(ILogger<HomeController> logger, IRepository<TaskModel>? taskRepository, IRepository<UserModel>? userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _taskRepository = taskRepository;
        }

        public IActionResult Index()
        {

            _taskRepository.Create(new TaskModel()
            {
                Title = "Sample Task",
                Status = Status.Started,
                Created = DateTime.Now,
               UserID = 1,
                Due = DateTime.Now.AddDays(7)
            }).Wait();
            var list = _userRepository.GetAll().Result;
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