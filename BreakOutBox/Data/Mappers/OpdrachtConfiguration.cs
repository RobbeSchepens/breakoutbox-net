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
            builder.HasOne(s => s.Oefening).WithMany().IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.Toegangscode).WithOne(s => s.Opdracht).IsRequired(true).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Actie).WithOne(s => s.Opdracht).IsRequired(true).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Groepsbewerking).WithOne(g => g.Opdracht).HasForeignKey<Groepsbewerking>(e => e.OpdrachtIdFK).IsRequired(true).OnDelete(DeleteBehavior.Restrict);
        }
    }
}