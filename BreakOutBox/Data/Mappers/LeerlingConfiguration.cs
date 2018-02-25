using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class LeerlingConfiguration : IEntityTypeConfiguration<Leerling>
    {
        public void Configure(EntityTypeBuilder<Leerling> builder)
        {
            builder.ToTable("Leerling");
            builder.Property(t => t.Voornaam).IsRequired().HasMaxLength(20);
            builder.Property(t => t.Achternaam).IsRequired().HasMaxLength(20);
        }
    }
}
