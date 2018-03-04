using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class ToegangscodeConfiguration : IEntityTypeConfiguration<Toegangscode>
    {
        public void Configure(EntityTypeBuilder<Toegangscode> builder)
        {
            builder.ToTable("Toegangscode");
            builder.Property(t => t.Code).IsRequired(true).HasMaxLength(100);
        }
    }
}
