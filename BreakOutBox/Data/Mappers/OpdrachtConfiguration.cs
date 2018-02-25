using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class OpdrachtConfiguration : IEntityTypeConfiguration<Opdracht>
    {
        public void Configure(EntityTypeBuilder<Opdracht> builder)
        {
            builder.ToTable("Opdracht");
            builder.Property(t => t.VolgNr).IsRequired().HasMaxLength(5);
            builder.Property(t => t.Toegangscode).IsRequired().HasMaxLength(5);

            //Associations
            builder.HasMany(s => s.Oefeningen).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
