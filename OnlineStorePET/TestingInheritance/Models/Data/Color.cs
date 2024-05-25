namespace TestingInheritance.Models.Data
{
    public class Color
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<ClothingColorJunction> ClothingColorJunctions { get; set; } = [];
        public ICollection<Clothing> Clothes { get; set; } = [];

        public ICollection<ShoeColorJunction> ShoeColorJunctions { get; set; } = [];
        public ICollection<Shoe> Shoes { get; set; } = [];
    }
}
