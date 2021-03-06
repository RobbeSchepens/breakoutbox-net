﻿using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class OefeningConfiguration : IEntityTypeConfiguration<Oefening>
    {
        public void Configure(EntityTypeBuilder<Oefening> builder)
        {
            builder.ToTable("Oefening");
            builder.Property(t => t.Naam).IsRequired().HasMaxLength(20);
            builder.Property(t => t.Antwoord).IsRequired().HasMaxLength(8);
            builder.Property(t => t.Opgave).IsRequired().HasMaxLength(20);

            //Associations
            builder.HasOne(s => s.Vak).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
