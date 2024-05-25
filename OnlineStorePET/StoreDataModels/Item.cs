using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StoreDataModels;

namespace StoreDataModels
{
    public abstract class Item
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public long ImageId { get; set; }
        public Image Image { get; set; } = null!;

        public long ColorId { get; set; }
        public Color Color { get; set; } = null!;

        public long BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
    }

    public enum Gender
    {
        Male=1,
        Female=2,
        Unisex=3
    }
}
