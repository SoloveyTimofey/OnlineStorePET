using System.ComponentModel.DataAnnotations;

namespace StoreDataModels.Clothes
{
    public class ClothingSize : IPrototype<ClothingSize>
    {
        public long Id { get;set; }

        [Required]
        [StringLength(4)]
        public string Size { get; set; } = null!;

        public ICollection<Clothing> Clothes { get; set; } = [];

        public ClothingSize Clone()
        {
            return new ClothingSize
            {
                Id = this.Id,
                Size = this.Size,
                Clothes = this.Clothes
            };
        }
    }
}
