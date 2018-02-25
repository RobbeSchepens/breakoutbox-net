using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class GroepsbewerkingConfiguration : IEntityTypeConfiguration<Groepsbewerking>
    {
        public void Configure(EntityTypeBuilder<Groepsbewerking> builder)
        {
            builder.ToTable("Groepsbewerking");
            builder.Property(t => t.Bewerking).IsRequired().HasMaxLength(100);
        }
    }
}
