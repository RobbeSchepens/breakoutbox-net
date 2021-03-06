﻿using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreakOutBox.Data.Mappers
{
    public class SessieConfiguration : IEntityTypeConfiguration<Sessie>
    {
        public void Configure(EntityTypeBuilder<Sessie> builder)
        {
            builder.ToTable("Sessie");
            builder.HasKey(t => t.Code);
            builder.Property(t => t.Naam).IsRequired().HasMaxLength(20);
            builder.Property(t => t.Omschrijving).IsRequired().HasMaxLength(100);
            builder.Ignore(s => s.CurrentState);
            
            //Associations
            builder.HasOne(s => s.Klas).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(s => s.Groepen).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.Box).WithOne().IsRequired(false).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
