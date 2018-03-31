using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class GroepConfiguration : IEntityTypeConfiguration<Groep>
    {
        public void Configure(EntityTypeBuilder<Groep> builder)
        {
            builder.ToTable("Groep");
            //builder.Ignore(g => g.CurrentState);

            //Associations
            builder.HasMany(s => s.Leerlingen).WithOne().IsRequired(false).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Pad).WithOne(s => s.Groep).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
