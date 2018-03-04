using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class BoxToegangscodeConfiguration : IEntityTypeConfiguration<BoxToegangscode>
    {
        public void Configure(EntityTypeBuilder<BoxToegangscode> builder)
        {
            builder.ToTable("BoxToegangscode");

            //Primary Key
            builder.HasKey(t => new { t.BoxId, t.ToegangscodeId });

            //Relations
            builder.HasOne(t => t.Box)
                .WithMany(t => t.BoxToegangscodes)
                .HasForeignKey(t => t.BoxId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pt => pt.Toegangscode)
                .WithMany()
                .HasForeignKey(pt => pt.ToegangscodeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
