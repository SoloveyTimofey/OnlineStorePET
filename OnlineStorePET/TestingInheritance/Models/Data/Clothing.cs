namespace TestingInheritance.Models.Data
{
    public class Clothing : Item
    {
        public string SleeveLenght { get; set; } = null!;

        public ICollection<ClothingColorJunction> ClothingColorJunctions { get; set; } = [];
        //public ICollection<Color> Colors { get; set; } = [];
    }
}
