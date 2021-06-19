using Microsoft.EntityFrameworkCore;
using SportsX.Domain;
using SportsX.Persistence.Context;
using SportsX.Persistence.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace SportsX.Persistence
{
    public class UserPersist : IUserPersist
    {
        private readonly SportsXDbContext _context;

        public UserPersist(SportsXDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Metodo que busca todos os Users com os Phones
        /// </summary>
        /// <returns>Array de Users</returns>
        public async Task<User[]> GetAllUsersAsync()
        {
            IQueryable<User> query = _context.Users.Include(u => u.Phones).AsNoTracking();

            query = query.OrderBy(u => u.FullName);

            return await query.ToArrayAsync();
        }

        /// <summary>
        /// Metodo que busca o User pelo ID passado nos parametros
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Retorna o primeiro User</returns>
        public async Task<User> GetUserByIdAsync(int userId)
        {
            IQueryable<User> query = _context.Users.Include(u => u.Phones).AsNoTracking();

            query = query.OrderBy(u => u.FullName).Where(u => u.Id == userId);

            return await query.FirstOrDefaultAsync();
        }
    }
}