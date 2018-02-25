using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class LeerkrachtConfiguration : IEntityTypeConfiguration<Leerkracht>
    {
        public void Configure(EntityTypeBuilder<Leerkracht> builder)
        {
            builder.ToTable("Leerkracht");
            builder.Property(t => t.Voornaam).IsRequired().HasMaxLength(20);
            builder.Property(t => t.Achternaam).IsRequired().HasMaxLength(20);
        }
    }
}
