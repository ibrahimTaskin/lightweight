using lightweight.data.Model;
using Microsoft.EntityFrameworkCore;

namespace lightweight.data.Context
{
    public class lwContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=postgres;User ID=postgres;password=Master.12;");
            // optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=lightWeihtDb;Trusted_Connection=True");

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Product> Products { get; set; } // Ürün modeli context'e tanıttık.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(new Users { id = 1, email = "i@berkanarikan.com.tr", lastName = "ARIKAN", firstName = "Berkan", password = "vFTlduBZkNsjuhjbDazejw==" });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 1, Name = "Some Product", Price = 1500 }); // Modele data ekledik.
        }


    }
}