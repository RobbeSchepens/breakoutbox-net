using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class ActieConfiguration : IEntityTypeConfiguration<Actie>
    {
        public void Configure(EntityTypeBuilder<Actie> builder)
        {
            builder.ToTable("Actie");
            builder.Property(t => t.Omschrijving).IsRequired().HasMaxLength(100);
        }
    }
}
