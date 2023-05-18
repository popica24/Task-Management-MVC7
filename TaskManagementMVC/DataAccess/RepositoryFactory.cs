using Microsoft.Extensions.DependencyInjection;
using TaskManagementMVC.DataAccess.Abstract;
using TaskManagementMVC.DataAccess.TaskDAL;
using TaskManagementMVC.DataAccess.UserDAL;
using TaskManagementMVC.Models;

namespace TaskManagementMVC.DataAccess
{
    public static class RepositoryFactory
    {
        public static IRepository<T> Create<T>(IServiceProvider serviceProvider, int type)
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
