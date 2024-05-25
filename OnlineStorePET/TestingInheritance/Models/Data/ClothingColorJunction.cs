using System.Diagnostics.Eventing.Reader;

namespace TestingInheritance.Models.Data
{
    public class ClothingColorJunction
    {
        public long Id { get; set; }    

        public long ClothingId { get; set; }
        public Clothing Clothing { get; set; }
        public long ColorId { get; set; }
        public Color Color { get; set; }
    }
}
