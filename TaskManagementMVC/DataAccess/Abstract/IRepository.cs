namespace TaskManagementMVC.DataAccess.Abstract
{
    public interface IRepository<T>
    {
        Task<int> Create(T model);
        Task Update(T model);
        Task Delete(int id);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
    }
}
