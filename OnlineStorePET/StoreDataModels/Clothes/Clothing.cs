using StoreDataModels;

namespace StoreDataModels.Clothes
{
    public class Clothing : Item, IPrototype<Clothing> 
    {
        public long CategoryId { get; set; }
        public ClothingCategory Category { get; set; } = null!;

        public long? SleeveLenghtId { get;set; }
        public SleeveLenght? SleeveLenght { get; set; }

        public long FitId { get; set; }
        public Fit Fit { get; set; } = null!;

        public ICollection<ClothingSizeJunction> ClothingSizeJunctions { get; set; } = [];
        public ICollection<ClothingSize> Sizes { get; set; } = [];

        public Clothing Clone()
        {
            return new Clothing
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
                SleeveLenghtId =this.SleeveLenghtId,
                SleeveLenght = this.SleeveLenght,
                ClothingSizeJunctions = this.ClothingSizeJunctions,
                Sizes = this.Sizes
            };
        }
    }
}
