#nullable disable
using Letters.Domain.Models;
using Letters.Models;
using Microsoft.EntityFrameworkCore;

namespace Letters.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<Mail> Product { get; set; }
        public DbSet<Recipient> Genre { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }        

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // builder.UseSnakeCaseNames();        
        }    
    }
}