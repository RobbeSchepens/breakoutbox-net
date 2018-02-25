using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class KlasLeerkrachtConfiguration : IEntityTypeConfiguration<KlasLeerkracht>
    {
        public void Configure(EntityTypeBuilder<KlasLeerkracht> builder)
        {
            builder.ToTable("KlasLeerkracht");

            //Primary Key
            builder.HasKey(t => new { t.KlasId, t.LeerkrachtId });

            //Relations
            builder.HasOne(t => t.Klas)
                .WithMany(t => t.KlasLeerkrachten)
                .HasForeignKey(t => t.KlasId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pt => pt.Leerkracht)
                .WithMany()
                .HasForeignKey(pt => pt.LeerkrachtId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
