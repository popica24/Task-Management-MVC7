using TaskManagementMVC.Models;
using TaskManagementMVC.Models.Enums;

namespace TaskManagementMVC.Business.Task.Abstract
{
    public interface ITaskState
    {
       Task<Status> Handle(TaskModel context);
    }
}
