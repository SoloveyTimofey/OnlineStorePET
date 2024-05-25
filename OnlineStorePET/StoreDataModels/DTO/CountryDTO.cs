using System.ComponentModel.DataAnnotations;

namespace StoreDataModels.DTO
{
    public record CountryDTO
    {
        [Required]
        public string Name { get; set; } = null!;

        public ICollection<long> Brands { get; set; } = [];
    }
}
