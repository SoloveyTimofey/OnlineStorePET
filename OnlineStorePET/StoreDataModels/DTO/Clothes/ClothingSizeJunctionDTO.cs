using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDataModels.DTO
{
    public record ClothingSizeJunctionDTO
    {
        public long Quantity { get; set; }

        public long ClothingSizeId { get; set; }

        public long ClothingId { get; set; }
    }
}
