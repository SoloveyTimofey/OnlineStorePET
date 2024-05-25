using StoreDataModels.DTO;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDataModels.Shoes
{
    public class ShoeSizeJunction
    {
        public long Id { get; set; }

        [NotMapped]
        public bool InStock
        {
            get => Quantity > 0 ? true : false;
            set => InStock = value;
        }

        public long Quantity { get; set; }

        public long ShoeSizeId { get; set; }
        public ShoeSize ShoeSize { get; set; } = null!;

        public long ShoeId { get; set; }
        public Shoe Shoe { get; set; } = null!;
    }

}