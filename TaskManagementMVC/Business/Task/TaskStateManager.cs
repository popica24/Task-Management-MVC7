using TaskManagementMVC.Business.Task.Abstract;
using TaskManagementMVC.Business.Task.TaskStates;
using TaskManagementMVC.Models;

namespace TaskManagementMVC.Business.Task
{
    public class TaskStateManager
    {
        private TaskModel _task;
        private readonly IServiceProvider _serviceProvider;
        public TaskStateManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
          
        }

        public void SetTask(TaskModel task)
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
                    return _serviceProvider.GetRequiredService<Started>();
                case Models.Enums.Status.InProcess:
                    return _serviceProvider.GetRequiredService<InProcess>();
                case Models.Enums.Status.Completed:
                    return _serviceProvider.GetRequiredService<Completed>();
                default:
                    throw new InvalidOperationException("Invalid task status.");
            }
        }

    }
}
