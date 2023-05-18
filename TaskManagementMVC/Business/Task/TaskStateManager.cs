using TaskManagementMVC.Business.Task.Abstract;
using TaskManagementMVC.Business.Task.TaskStates;
using TaskManagementMVC.Models;

namespace TaskManagementMVC.Business.Task
{
    public class TaskStateManager
    {
        private readonly TaskModel _task;

        public TaskStateManager(TaskModel task)
        {
            _task = task;
        }

        public void Request()
        {
            GetCurrentState().Handle(_task);
        }

        private ITaskState GetCurrentState()
        {
            switch (_task.Status)
            {
                case Models.Enums.Status.Started:
                    return new Started();
                case Models.Enums.Status.InProcess:
                    return new InProcess();
                case Models.Enums.Status.Completed:
                    return new Completed();
                default:
                    throw new InvalidOperationException("Invalid task status.");
            }
        }

    }
}
