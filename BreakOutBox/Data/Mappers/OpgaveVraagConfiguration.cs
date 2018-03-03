using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class OpgaveVraagConfiguration : IEntityTypeConfiguration<OpgaveVraag>
    {
        public void Configure(EntityTypeBuilder<OpgaveVraag> builder)
        {
            builder.ToTable("OpgaveVraag");
            builder.Property(t => t.Vraag).IsRequired().HasMaxLength(500);
        }
    }
}
