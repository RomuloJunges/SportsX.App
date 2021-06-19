using Microsoft.EntityFrameworkCore;
using SportsX.Domain;
using SportsX.Persistence.Context;
using SportsX.Persistence.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace SportsX.Persistence
{
    public class PhonePersist : IPhonePersist
    {
        private readonly SportsXDbContext _context;

        public PhonePersist(SportsXDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Metodo que retorna o Phone atraves do ID do Phone e do User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="phoneId"></param>
        /// <returns>Retorna o primeiro Phone</returns>
        public async Task<Phone> GetPhoneByIdsAsync(int userId, int phoneId)
        {
            IQueryable<Phone> query = _context.Phones;

            query = query.AsNoTracking().Where(p => p.UserId == userId && p.Id == phoneId);

            return await query.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Metodo que retorna todo os Phones de um User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Array de Phone do User</returns>
        public async Task<Phone[]> GetPhonesByUserIdAsync(int userId)
        {
            IQueryable<Phone> query = _context.Phones;

            query = query.AsNoTracking().Where(p => p.UserId == userId);

            return await query.ToArrayAsync();
        }
    }
}