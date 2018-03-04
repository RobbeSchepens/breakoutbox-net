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

            //Associations
            builder.HasMany(s => s.Opdrachten).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
