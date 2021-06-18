using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsX.Persistence.Contracts
{
    public interface IGenericPersist
    {
        void Add<T>(T entity) where T : class;
        void AddRange<T>(T[] entities) where T : class;
        void Update<T>(T entity) where T : class;
        void UpdateRange<T>(T[] entities) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}
