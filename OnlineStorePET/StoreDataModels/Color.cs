using System.ComponentModel.DataAnnotations;
using StoreDataModels.Shoes;
using StoreDataModels.Clothes;

namespace StoreDataModels
{
    public class Color : IPrototype<Color>
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(7)]
        [RegularExpression("^#[0-9A-Fa-f]{6}$")]
        public string HEX { get; set; } = null!;

        public ICollection<Item> Items { get; set; } = [];

        public Color Clone()
        {
            return new Color
            {
                Id = this.Id,
                Name = this.Name,
                HEX = this.HEX,
                Items = this.Items
            };
        }
    }
}
