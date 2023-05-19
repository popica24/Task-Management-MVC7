using TaskManagementMVC.Business.Task.Abstract;
using TaskManagementMVC.DataAccess.Abstract;
using TaskManagementMVC.Models;
using TaskManagementMVC.Models.Enums;

namespace TaskManagementMVC.Business.Task.TaskStates
{
    public class Started : ITaskState
    {
        private readonly IRepository<TaskModel> _repo;

        public Started(IRepository<TaskModel> repo)
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
