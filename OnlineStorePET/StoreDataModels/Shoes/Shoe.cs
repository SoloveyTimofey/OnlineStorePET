using StoreDataModels;

namespace StoreDataModels.Shoes
{
    public class Shoe : Item, IPrototype<Shoe>
    {
        public long CategoryId { get; set; }
        public ShoeCategory Category { get; set; } = null!;

        public ICollection<ShoeSizeJunction> ShoeSizeJunctions { get; set; } = [];
        public ICollection<ShoeSize> Sizes { get; set; } = [];

        public Shoe Clone()
        {
            return new Shoe
            {
                Id = this.Id,
                Name = this.Name,
                Price = this.Price,
                Gender = this.Gender,
                ImageId = this.ImageId,
                Image = this.Image,
                ColorId = this.ColorId,
                Color = this.Color,
                BrandId = this.BrandId,
                Brand = this.Brand,
                CategoryId = this.CategoryId,
                Category = this.Category,
                ShoeSizeJunctions = this.ShoeSizeJunctions,
                Sizes = this.Sizes,
            };
        }
    }
}
