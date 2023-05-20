using TaskManagementMVC.Business.Project.Abstract;
using TaskManagementMVC.Business.Project.ProjectStates;
using TaskManagementMVC.Models;

namespace TaskManagementMVC.Business.Project
{
    public class ProjectStateManager
    {
        private ProjectModel? _task;
        private readonly IEnumerable<IProjectState> _serviceProvider;
        public ProjectStateManager(IEnumerable<IProjectState> serviceProvider)
        {
            _serviceProvider = serviceProvider;
          
        }

        public void SetTask(ProjectModel task)
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

        private IProjectState? GetCurrentState()
        {
            if( _task != null ) {
                switch (_task.Status)
                {
                    case Models.Enums.Status.Planning:
                        return _serviceProvider.FirstOrDefault(x => x.GetType() == typeof(Planning));
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
