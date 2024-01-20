using Letters.Domain.Models;
using Letters.Models;
using Microsoft.EntityFrameworkCore;

namespace Letters.Infrastructure
{
    /// <summary>
    /// A DbContext instance represents a session with the database and can be used to query and save instances of your entities. DbContext is a combination of the Unit Of Work and Repository patterns.
    /// </summary>
    public class Context : DbContext
    {
        public DbSet<Mail> Mail { get; set; }
        public DbSet<Recipient> Recipients { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Mail>()
                .Property(e => e.FaildMessage)
                .HasDefaultValue("");
            builder.Entity<Mail>()
                .Property(e => e.Result)
                .HasConversion<string>();

            // builder.UseSnakeCaseNames();        
        }    
    }
}