using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BreakOutBox.Models;
using BreakOutBox.Data.Mappers;
using BreakOutBox.Models.Domain;

namespace BreakOutBox.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Sessie> Sessies { get; set; }
        public DbSet<Leerkracht> Leerkrachten { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.ApplyConfiguration(new SessieConfiguration());
            builder.ApplyConfiguration(new KlasConfiguration());
            builder.ApplyConfiguration(new LeerkrachtConfiguration());
            builder.ApplyConfiguration(new LeerlingConfiguration());
            builder.ApplyConfiguration(new GroepConfiguration());
            builder.ApplyConfiguration(new PadConfiguration());
            builder.ApplyConfiguration(new OpdrachtConfiguration());
            builder.ApplyConfiguration(new BoxConfiguration());
            builder.ApplyConfiguration(new ActieConfiguration());
            builder.ApplyConfiguration(new OefeningConfiguration());
            builder.ApplyConfiguration(new ToegangscodeConfiguration());
        }
    }
}
