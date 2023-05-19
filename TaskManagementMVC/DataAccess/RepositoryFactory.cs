using TaskManagementMVC.DataAccess.Abstract;
using TaskManagementMVC.DataAccess.TaskRepo;
using TaskManagementMVC.DataAccess.UserRepo;

namespace TaskManagementMVC.DataAccess
{
    public static class RepositoryFactory
    {
        public static IRepository<T>? Create<T>(IServiceProvider serviceProvider, int type)
        {
            switch (type){
                case (int)RepositoryType.User:
                    return serviceProvider.GetService<UserRepository>() as IRepository<T>;
                case (int)RepositoryType.Task:
                    return serviceProvider.GetService<TaskRepository>() as IRepository<T>;
            }
            return null;
        }
    }
}
