using GariCuvari.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace GariCuvari.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Gari> Garis { get; set; }

        public DbSet<Druzenje> Druzenja { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Gari>().HasMany(g => g.Druzenja).WithMany(d => d.Garis);
        }
    }
}
