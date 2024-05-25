using System.ComponentModel.DataAnnotations;

namespace StoreDataModels.DTO
{
    public record ClothingCategoryDTO
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
