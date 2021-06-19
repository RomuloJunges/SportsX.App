using SportsX.Persistence.Context;
using SportsX.Persistence.Contracts;
using System.Threading.Tasks;

namespace SportsX.Persistence
{
    public class GenericPersist : IGenericPersist
    {
        private readonly SportsXDbContext _context;

        public GenericPersist(SportsXDbContext context)
        {
            this._context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.AddAsync(entity);
        }

        public void AddRange<T>(T[] entities) where T : class
        {
            _context.AddRangeAsync(entities);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void UpdateRange<T>(T[] entities) where T : class
        {
            _context.UpdateRange(entities);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
