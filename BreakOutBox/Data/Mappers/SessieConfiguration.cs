using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class SessieConfiguration
    {
        public void Configure(EntityTypeBuilder<Sessie> builder)
        {
            builder.ToTable("Sessie");
            builder.HasKey(t => t.UniekeCode);
            builder.Property(t => t.Naam).IsRequired().HasMaxLength(20);
            //builder.Property(t => t.Klas).IsRequired().HasMaxLength(20);
            builder.Property(t => t.Omschrijving).IsRequired().HasMaxLength(100);
        }
    }
}
