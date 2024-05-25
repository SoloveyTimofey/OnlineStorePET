using System.ComponentModel.DataAnnotations;

namespace StoreDataModels.DTO
{
    public record FitDTO
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
