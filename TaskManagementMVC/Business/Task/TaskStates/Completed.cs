using TaskManagementMVC.Business.Task.Abstract;
using TaskManagementMVC.Models;

namespace TaskManagementMVC.Business.Task.TaskStates
{
    public class Completed : ITaskState
    {
        public void Handle(TaskModel context)
        {

        }
    }
}
