using TaskManagementMVC.Business.Project.Abstract;
using TaskManagementMVC.DataAccess.Abstract;
using TaskManagementMVC.Models;
using TaskManagementMVC.Models.Enums;

namespace TaskManagementMVC.Business.Project.ProjectStates
{
    public class Planning : IProjectState
    {
        private readonly IRepository<ProjectModel> _repo;

        public Planning(IRepository<ProjectModel> repo)
        {
           _repo = repo;
        }

        public async Task<Status> Handle(ProjectModel context)
        {
            context.Status = Status.InProcess;
            await _repo.Update(context);
            return context.Status;
        }
    }
}
