using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class BoxConfiguration : IEntityTypeConfiguration<Box>
    {
        public void Configure(EntityTypeBuilder<Box> builder)
        {
            builder.ToTable("Box");

            //Associations
            builder.HasMany(s => s.Acties).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(s => s.Oefeningen).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(s => s.Toegangscodes).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
