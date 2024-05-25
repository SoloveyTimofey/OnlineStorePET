using System.ComponentModel.DataAnnotations;

namespace StoreDataModels.DTO
{
    public record ShoeCategoryDTO
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
