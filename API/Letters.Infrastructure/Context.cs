using Letters.Domain.Models;
using Letters.Models;
using Microsoft.EntityFrameworkCore;

namespace Letters.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<Mail> Mail { get; set; }
        public DbSet<Recipient> Recipients { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }        

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // builder.UseSnakeCaseNames();        
        }    
    }
}