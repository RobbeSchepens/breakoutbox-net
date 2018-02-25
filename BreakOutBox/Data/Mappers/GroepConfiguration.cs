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
            builder.Property(t => t.Naam).IsRequired().HasMaxLength(20);
            
            //Associations
            builder.HasMany(s => s.Leerlingen).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(s => s.Paden).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
