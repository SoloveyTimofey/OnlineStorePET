using System.ComponentModel.DataAnnotations;

namespace StoreDataModels.DTO
{
    public record ClothingSizeDTO
    {
        [Required]
        [StringLength(4)]
        public string Size { get; set; } = null!;
    }
}
