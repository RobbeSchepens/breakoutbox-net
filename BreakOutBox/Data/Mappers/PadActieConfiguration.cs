using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class PadActieConfiguration : IEntityTypeConfiguration<PadActie>
    {
        public void Configure(EntityTypeBuilder<PadActie> builder)
        {
            builder.ToTable("PadActie");

            //Primary Key
            builder.HasKey(t => new { t.PadId, t.ActieId });

            //Relations
            builder.HasOne(t => t.Pad)
                .WithMany(t => t.PadActies)
                .HasForeignKey(t => t.PadId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pt => pt.Actie)
                .WithMany()
                .HasForeignKey(pt => pt.ActieId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
