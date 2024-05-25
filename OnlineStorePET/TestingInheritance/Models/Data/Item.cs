using System.ComponentModel.DataAnnotations.Schema;

namespace TestingInheritance.Models.Data
{
    public abstract class Item
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public IEnumerable<Color> Colors { get; } = [];
    }
}
