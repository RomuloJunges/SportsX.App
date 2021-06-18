using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsX.Domain;
using SportsX.Persistence.Context;
using SportsX.Persistence.Contracts;

namespace SportsX.Persistence
{
    public class UserPersist : IUserPersist
    {
        private readonly SportsXDbContext _context;

        public UserPersist(SportsXDbContext context)
        {
            this._context = context;
        }

        public async Task<User[]> GetAllUsersAsync()
        {
            IQueryable<User> query = _context.Users.Include(u => u.Phones).AsNoTracking();

            query = query.OrderBy(u => u.FullName);

            return await query.ToArrayAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            IQueryable<User> query = _context.Users.Include(u => u.Phones).AsNoTracking();

            query = query.OrderBy(u => u.FullName).Where(u => u.Id == userId);

            return await query.FirstOrDefaultAsync();
        }
    }
}