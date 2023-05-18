using TaskManagementMVC.Models;

namespace TaskManagementMVC.Business.Task.Abstract
{
    public interface ITaskState
    {
        void Handle(TaskModel context);
    }
}
