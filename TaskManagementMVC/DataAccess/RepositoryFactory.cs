using TaskManagementMVC.DataAccess.Abstract;
using TaskManagementMVC.DataAccess.TaskRepo;


namespace TaskManagementMVC.DataAccess
{
    public static class RepositoryFactory
    {
        public static IRepository<T>? Create<T>(IServiceProvider serviceProvider, int type)
        {
            switch (type){
                case (int)RepositoryType.Task:
                    return serviceProvider.GetService<ProjectRepository>() as IRepository<T>;
            }
            return null;
        }
    }
}
