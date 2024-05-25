using System.ComponentModel.DataAnnotations;

namespace StoreDataModels.Shoes
{
    public class ShoeSize : IPrototype<ShoeSize>
    {
        public long Id { get; set; }

        [Range(20, 55)]
        public byte Size { get;set; }

        public ICollection<ShoeSizeJunction> ShoeSizeJunctions { get; set; } = [];
        public ICollection<Shoe> Shoes { get; set; } = [];

        public ShoeSize Clone()
        {
            return new ShoeSize
            {
                Id = this.Id,
                Size = this.Size,
                ShoeSizeJunctions = this.ShoeSizeJunctions,
                Shoes = this.Shoes
            };
        }
    }
}
