using TaskManagementMVC.Business.Task.Abstract;
using TaskManagementMVC.Models;

namespace TaskManagementMVC.Business.Task.TaskStates
{
    public class InProcess : ITaskState
    {
        public void Handle(TaskModel context)
        {
            context.Status = Models.Enums.Status.Completed;
        }
    }
}
