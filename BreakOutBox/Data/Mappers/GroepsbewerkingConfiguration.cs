using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data
{
    public class GroepsbewerkingConfiguration : IEntityTypeConfiguration<Groepsbewerking>
    {
        public void Configure(EntityTypeBuilder<Groepsbewerking> builder)
        {
            builder.ToTable("Groepsbewerking");
        }
    }
}