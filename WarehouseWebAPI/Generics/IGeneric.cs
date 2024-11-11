
namespace WarehouseWebAPI.Generics
{
    public interface IGeneric<T> where T : class
    {
        Task Add(T entity);
        Task Delete(int Id);
        Task<T> Load(int Id);
        Task<List<T>> LoadAll();
        Task Update(T entitiy);
    }
}