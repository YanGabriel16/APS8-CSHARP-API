using APS8_CSHARP_API.Domain.Interfaces.Repository;
using APS8_CSHARP_API.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace APS8_CSHARP_API.Infra.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected DbSet<T> DbSet;
        public BaseRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;            
            this.DbSet = this._context.Set<T>();
        }
        public void Add(T entity)
        {
            this.DbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}