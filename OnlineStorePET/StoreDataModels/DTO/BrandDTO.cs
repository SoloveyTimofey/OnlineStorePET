using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace StoreDataModels.DTO
{
    public record BrandDTO : IRequest<Brand>
    {

        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        
        public long CountryId { get;set; }
    }
}
