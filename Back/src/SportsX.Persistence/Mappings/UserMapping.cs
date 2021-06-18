using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsX.Domain;

namespace SportsX.Persistence.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        //Mapeamento das colunas da tabela Users com EF Core
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FullName).IsRequired().HasColumnType("varchar(100)");
            builder.Property(u => u.CompanyName).HasColumnType("varchar(100)");
            builder.Property(u => u.Document).HasColumnType("varchar(14)");
            builder.Property(u => u.Email).IsRequired().HasColumnType("varchar(150)");
            builder.Property(u => u.CEP).HasColumnType("varchar(8)");
            builder.Property(u => u.Classification).IsRequired().HasColumnType("int");

            builder.HasMany(p => p.Phones).WithOne(u => u.User).HasForeignKey(p => p.UserId);

            builder.ToTable("Users");
        }
    }
}