using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace StoreDataModels
{
    public class Image : IPrototype<Image>
    {
        public long Id { get; set; }
        public string? Description { get; set; }
        [Required]
        public byte[] ImageBytes { get; set; } = null!;
        public ICollection<Item> Items { get; set; } = [];

        public Image Clone()
        {
            return new Image
            {
                Id = this.Id,
                Description = this.Description,
                ImageBytes = this.ImageBytes,
                Items = this.Items
            };
        }
    }
}
