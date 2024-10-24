namespace SummervilleLibrary.Data;

using Microsoft.EntityFrameworkCore;
using SummervilleLibrary.Models.DatabaseEntities;
using System.Reflection.Emit;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Define your DbSets here if you need any tables.
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Model configurations go here
        }
    }

