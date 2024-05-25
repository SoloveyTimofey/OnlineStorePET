using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDataModels
{
    public abstract class Category
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [NotMapped]
        public ICollection<Item> Items { get; set; } = [];

    }
}
