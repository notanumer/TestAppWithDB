
namespace TestAppWithDB.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> CreateAsync(T model);

        Task<T> GetAsync(int id);

        Task<List<T>> SelectAsync();

        Task<bool>DeleteAsync(T model);
        Task<bool> UpdateAsync(T model);
    }
}
