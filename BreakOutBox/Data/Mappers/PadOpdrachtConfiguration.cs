using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class PadOpdrachtConfiguration : IEntityTypeConfiguration<PadOpdracht>
    {
        public void Configure(EntityTypeBuilder<PadOpdracht> builder)
        {
            builder.ToTable("PadOpdracht");

            //Primary Key
            builder.HasKey(t => new { t.PadId, t.OpdrachtId });

            //Relations
            builder.HasOne(t => t.Pad)
                .WithMany(t => t.PadOpdrachten)
                .HasForeignKey(t => t.PadId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pt => pt.Opdracht)
                .WithMany()
                .HasForeignKey(pt => pt.OpdrachtId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
