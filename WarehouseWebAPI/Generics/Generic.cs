using Microsoft.EntityFrameworkCore;
using WarehouseWebAPI.Data;

namespace WarehouseWebAPI.Generics
{
    public class Generic<T> : IGeneric<T> where T : class
    {
        WareHouseContext context;

        public Generic(WareHouseContext _context)
        {
            context = _context;
        }

        public async Task Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public async Task<List<T>> LoadAll()
        {
            return await context.Set<T>().ToListAsync();
        }
        public async Task Delete(int Id)
        {
            T entity = context.Set<T>().Find(Id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(T entitiy)
        {
            context.Set<T>().Attach(entitiy);
            context.Entry(entitiy).State = EntityState.Modified;
            await context.SaveChangesAsync();

        }

        public async Task<T> Load(int Id)
        {
            T entity = await context.Set<T>().FindAsync(Id);
            return entity;
        }
    }
}
