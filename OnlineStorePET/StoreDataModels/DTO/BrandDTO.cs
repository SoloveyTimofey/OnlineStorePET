using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StoreDataModels.DTO
{
    public record BrandDTO
    {

        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        
        public long CountryId { get;set; }
    }
}
