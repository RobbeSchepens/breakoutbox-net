using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class PadConfiguration : IEntityTypeConfiguration<Pad>
    {
        public void Configure(EntityTypeBuilder<Pad> builder)
        {
            builder.ToTable("Pad");
            builder.Ignore(t => t.Acties);
            builder.Ignore(t => t.Opdrachten);
        }
    }
}
