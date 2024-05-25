namespace TestingInheritance.Models.Data
{
    public class ShoeColorJunction
    {
        public long Id { get; set; }

        public long ShoeId {get;set; }
        public Shoe Shoe { get; set; }
        public long ColorId { get; set; }
        public Color Color { get; set; }
    }
}
