using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class OpgaveConfiguration : IEntityTypeConfiguration<Opgave>
    {
        public void Configure(EntityTypeBuilder<Opgave> builder)
        {
            builder.ToTable("Opgave");
            builder.Property(t => t.Uitleg).IsRequired().HasMaxLength(100);
            
            //Associations
            builder.HasMany(s => s.Vragen).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
