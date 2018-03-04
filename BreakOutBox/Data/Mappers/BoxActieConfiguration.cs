using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class BoxActieConfiguration : IEntityTypeConfiguration<BoxActie>
    {
        public void Configure(EntityTypeBuilder<BoxActie> builder)
        {
            builder.ToTable("BoxActie");

            //Primary Key
            builder.HasKey(t => new { t.BoxId, t.ActieId });

            //Relations
            builder.HasOne(t => t.Box)
                .WithMany(t => t.BoxActies)
                .HasForeignKey(t => t.BoxId)
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
