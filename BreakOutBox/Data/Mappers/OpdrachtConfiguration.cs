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

            //Associations
            builder.HasOne(s => s.Oefening).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.Toegangscode).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
