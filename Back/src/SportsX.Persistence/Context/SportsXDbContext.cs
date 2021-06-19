using Microsoft.EntityFrameworkCore;
using SportsX.Domain;

namespace SportsX.Persistence.Context
{
    public class SportsXDbContext : DbContext
    {
        public SportsXDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Phone> Phones { get; set; }

        /// <summary>
        /// Metódo para criar o banco de dados através do Mapping de casa modelo
        /// Mapeamento do relacionamento de 1 para N
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SportsXDbContext).Assembly);

            modelBuilder.Entity<Phone>().HasOne(p => p.User).WithMany(u => u.Phones).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}