using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDataModels.Clothes
{
    public class ClothingSizeJunction
    {
        public long Id { get; set; }

        private bool isInStock { get; set; }

        [NotMapped]
        public bool IsInStock
        {
            get => Quantity > 0 ? true : false;
            set=>isInStock= value;
        }
        public long Quantity { get; set; }

        public long ClothingSizeId { get; set; }
        public ClothingSize ClothingSize { get; set; } = null!;

        public long ClothingId { get; set; }
        public Clothing Clothing { get; set; } = null!;
    }
}
