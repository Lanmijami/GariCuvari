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
    }
}
