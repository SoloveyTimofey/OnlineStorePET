using Microsoft.EntityFrameworkCore;

namespace TestingInheritance.Models.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> opts):base(opts)
        {          
        }
        public DbSet<Clothing> Clothes { get; set; }    
        public DbSet<ClothingColorJunction> ClothingColorJunctions { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<ShoeColorJunction> ShoeColorJunctions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clothing>().UseTpcMappingStrategy();
            modelBuilder.Entity<Shoe>().UseTpcMappingStrategy();

            //modelBuilder.Entity<Clothing>().Ignore(c => c.Colors);
            modelBuilder.Entity<Clothing>()
                .HasMany(c => c.Colors)
                .WithMany(c => c.Clothes)
                .UsingEntity<ClothingColorJunction>();

            //modelBuilder.Entity<Shoe>().Ignore(s => s.Colors);
            modelBuilder.Entity<Shoe>()
                .HasMany(s => s.Colors)
                .WithMany(c => c.Shoes)
                .UsingEntity<ShoeColorJunction>();
        }
    }
}
