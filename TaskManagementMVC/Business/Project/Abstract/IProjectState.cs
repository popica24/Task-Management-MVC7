using TaskManagementMVC.Models;
using TaskManagementMVC.Models.Enums;

namespace TaskManagementMVC.Business.Project.Abstract
{
    public interface IProjectState
    {
       Task<Status> Handle(ProjectModel context);
    }
}
