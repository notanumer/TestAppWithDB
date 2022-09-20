
namespace TestAppWithDB.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T model);

        Task<T> GetAsync(string firstName);

        Task<List<T>> Select();

        bool Delete(T model);
    }
}
