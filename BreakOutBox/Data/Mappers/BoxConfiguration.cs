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
            builder.Ignore(t => t.Acties);
            builder.Ignore(t => t.Oefeningen);
            builder.Ignore(t => t.Toegangscodes);
        }
    }
}
