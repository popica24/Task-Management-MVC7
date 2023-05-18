using Azure.Core;
using TaskManagementMVC.Business.Task.Abstract;
using TaskManagementMVC.DataAccess.TaskDAL;
using TaskManagementMVC.DataContext;
using TaskManagementMVC.Models;
using TaskManagementMVC.Models.Enums;

namespace TaskManagementMVC.Business.Task.TaskStates
{
    public class Started : ITaskState
    {
        private readonly TaskRepository _repo;

        public Started(TaskRepository repo)
        {
           _repo = repo;
        }

        public async Task<Status> Handle(TaskModel context)
        {
            context.Status = Status.InProcess;
            await _repo.Update(context);
            return context.Status;
        }
    }
}
