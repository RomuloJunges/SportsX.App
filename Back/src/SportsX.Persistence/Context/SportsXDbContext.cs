using Microsoft.EntityFrameworkCore;
using SportsX.Domain;

namespace SportsX.Persistence.Context
{
    public class SportsXDbContext : DbContext
    {
        public SportsXDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Phone> Phones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Busca as classes que herdam IEntityTypeConfiguration e aplica as modificações
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SportsXDbContext).Assembly);

            //Mapeamento de 1 para N na qual o Objeto Phone possui 1 User e o mesmo possui muitos Phones
            //com o comportamento de deletar todos os phones caso o user seja deletado
            modelBuilder.Entity<Phone>().HasOne(p => p.User).WithMany(u => u.Phones).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}