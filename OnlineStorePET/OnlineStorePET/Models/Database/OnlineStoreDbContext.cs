using Microsoft.EntityFrameworkCore;
using StoreDataModels;
using StoreDataModels.Clothes;
using StoreDataModels.Shoes;

namespace OnlineStorePET.Models.Database
{
    public class OnlineStoreDbContext : DbContext
    {
        public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options) : base(options) { }

        #region Genereal
        public DbSet<Country> Countries { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Image> Images { get; set; }
        #endregion

        #region Shoes
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<ShoeSize> ShoeSizes { get; set; }
        public DbSet<ShoeCategory> ShoeCategories { get; set; }
        public DbSet<ShoeSizeJunction> ShoeSizeJunctions { get; set; }
        #endregion

        #region Clothes
        public DbSet<Clothing> Clothes { get; set; }
        public DbSet<ClothingSize> ClothingSizes { get; set; }
        public DbSet<ClothingCategory> ClothingCategories { get; set; }
        public DbSet<ClothingSizeJunction> ClothingSizeJunctions { get; set; }
        public DbSet<SleeveLenght> SleeveLenghts { get; set; }
        public DbSet<Fit> Fits { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clothing>().Navigation(c => c.Brand).AutoInclude();
            modelBuilder.Entity<Clothing>().Navigation(c => c.Image).AutoInclude();
            modelBuilder.Entity<Clothing>().Navigation(c => c.Color).AutoInclude();
            modelBuilder.Entity<Clothing>().Navigation(c => c.SleeveLenght).AutoInclude();
            modelBuilder.Entity<Clothing>().Navigation(c => c.Fit).AutoInclude();
            modelBuilder.Entity<Clothing>().Navigation(c => c.Category).AutoInclude();
            modelBuilder.Entity<Clothing>().Navigation(c => c.ClothingSizeJunctions).AutoInclude();

            modelBuilder.Entity<ClothingSizeJunction>().Navigation(csj=>csj.ClothingSize).AutoInclude();

            modelBuilder.Entity<Shoe>().Navigation(s => s.Brand).AutoInclude();
            modelBuilder.Entity<Shoe>().Navigation(s => s.Image).AutoInclude();
            modelBuilder.Entity<Shoe>().Navigation(s => s.Color).AutoInclude();
            modelBuilder.Entity<Shoe>().Navigation(s => s.Category).AutoInclude();
            modelBuilder.Entity<Shoe>().Navigation(s => s.Sizes).AutoInclude();

            modelBuilder.Entity<Item>().UseTpcMappingStrategy();
            modelBuilder.Entity<Category>().UseTpcMappingStrategy();

            modelBuilder.Entity<Clothing>()
                .HasMany(c => c.Sizes)
                .WithMany(s => s.Clothes)
                .UsingEntity<ClothingSizeJunction>();

            modelBuilder.Entity<Shoe>()
                .HasMany(s => s.Sizes)
                .WithMany(s => s.Shoes)
                .UsingEntity<ShoeSizeJunction>();


            base.OnModelCreating(modelBuilder);
        }
    }
}
