using System.ComponentModel.DataAnnotations;

namespace StoreDataModels.DTO
{
    public record SleeveLenghtDTO
    {
        [Required]
        public string Lenght { get; set; } = null!;
    }
}
