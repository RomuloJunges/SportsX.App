using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsX.Domain;
using SportsX.Persistence.Context;
using SportsX.Persistence.Contracts;

namespace SportsX.Persistence
{
    public class PhonePersist : IPhonePersist
    {
        private readonly SportsXDbContext _context;

        public PhonePersist(SportsXDbContext context)
        {
            this._context = context;
        }

        public async Task<Phone> GetPhoneByIdAsync(Guid phoneId)
        {
            IQueryable<Phone> query = _context.Phones.AsNoTracking();

            query = query.Where(p => p.Id == phoneId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Phone[]> GetPhonesByUserAsync(Guid userId)
        {
            IQueryable<Phone> query = _context.Phones.AsNoTracking();

            query = query.Where(p => p.UserId == userId);

            return await query.ToArrayAsync();
        }
    }
}