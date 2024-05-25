namespace TestingInheritance.Models.Data
{
    public class Shoe : Item
    {

        public string BootHeight = null!;

        public ICollection<ShoeColorJunction> ShoeColorJunctions { get; set; } = [];
        //public ICollection<Color> Colors { get; set; } = [];
    }
}
