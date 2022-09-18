
namespace TestAppWithDB.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T model);

        T Get(string firstName);

        Task<List<T>> Select();

        bool Delete(T model);
    }
}
