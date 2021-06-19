using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsX.Domain;

namespace SportsX.Persistence.Mappings
{
    public class PhoneMapping : IEntityTypeConfiguration<Phone>
    {
        /// <summary>
        /// Mapeamento das colunas do banco de dados
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Number).HasColumnType("varchar(11)");

            builder.ToTable("Phones");
        }
    }
}