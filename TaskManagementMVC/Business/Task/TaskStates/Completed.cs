using Azure.Core;
using TaskManagementMVC.Business.Task.Abstract;
using TaskManagementMVC.DataAccess.TaskDAL;
using TaskManagementMVC.DataContext;
using TaskManagementMVC.Models;
using TaskManagementMVC.Models.Enums;

namespace TaskManagementMVC.Business.Task.TaskStates
{
    public class Completed : ITaskState
    {
        private readonly TaskRepository _repo;

        public Completed(TaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<Status> Handle(TaskModel context)
        {
            context.Status = Status.Completed;
            await _repo.Update(context);
            return context.Status;
        }
    }
}
