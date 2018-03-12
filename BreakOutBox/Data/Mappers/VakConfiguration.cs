using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class VakConfiguration : IEntityTypeConfiguration<Vak>
    {
        public void Configure(EntityTypeBuilder<Vak> builder)
        {
            builder.ToTable("Vak");
            builder.Property(t => t.Naam).IsRequired().HasMaxLength(40);
        }
    }
}
