using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class KlasConfiguration : IEntityTypeConfiguration<Klas>
    {
        public void Configure(EntityTypeBuilder<Klas> builder)
        {
            builder.ToTable("Klas");
            builder.Ignore(t => t.Leerkrachten);

            //Associations
            builder.HasMany(s => s.Leerlingen).WithOne().IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
