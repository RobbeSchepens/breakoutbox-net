using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class BoxOefeningConfiguration : IEntityTypeConfiguration<BoxOefening>
    {
        public void Configure(EntityTypeBuilder<BoxOefening> builder)
        {
            builder.ToTable("BoxOefening");

            //Primary Key
            builder.HasKey(t => new { t.BoxId, t.OefeningId });

            //Relations
            builder.HasOne(t => t.Box)
                .WithMany(t => t.BoxOefeningen)
                .HasForeignKey(t => t.BoxId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pt => pt.Oefening)
                .WithMany()
                .HasForeignKey(pt => pt.OefeningId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
