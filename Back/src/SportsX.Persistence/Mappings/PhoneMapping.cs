using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsX.Domain;

namespace SportsX.Persistence.Mappings
{
    public class PhoneMapping : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Number).HasColumnType("varchar(11)");

            builder.ToTable("Phones");
        }
    }
}