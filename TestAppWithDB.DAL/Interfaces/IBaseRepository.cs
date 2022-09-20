
namespace TestAppWithDB.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T model);

        Task<T> GetAsync(int id);

        Task<List<T>> Select();

        bool Delete(T model);
        Task<bool> UpdateAsync(T model);
    }
}
