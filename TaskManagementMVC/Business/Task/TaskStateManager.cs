using TaskManagementMVC.Business.Task.Abstract;
using TaskManagementMVC.Business.Task.TaskStates;
using TaskManagementMVC.Models;

namespace TaskManagementMVC.Business.Task
{
    public class TaskStateManager
    {
        private TaskModel? _task;
        private readonly IEnumerable<ITaskState> _serviceProvider;
        public TaskStateManager(IEnumerable<ITaskState> serviceProvider)
        {
            _serviceProvider = serviceProvider;
          
        }

        public void SetTask(TaskModel task)
        {
            _task = task;
        }

        public void Request()
        {
            var state = GetCurrentState();
            if(state!=null && _task != null) {
                state.Handle(_task);
            }   
        }

        private ITaskState? GetCurrentState()
        {
            if( _task != null ) {
                switch (_task.Status)
                {
                    case Models.Enums.Status.Started:
                        return _serviceProvider.FirstOrDefault(x => x.GetType() == typeof(Started));
                    case Models.Enums.Status.InProcess:
                        return _serviceProvider.FirstOrDefault(x => x.GetType() == typeof(InProcess));
                    case Models.Enums.Status.Completed:
                        return _serviceProvider.FirstOrDefault(x => x.GetType() == typeof(Completed));
                    default:
                        throw new InvalidOperationException("Invalid task status.");
                }
            }
            return null;
            
        }

    }
}
