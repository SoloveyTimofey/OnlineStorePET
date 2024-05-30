using MediatR;
using StoreDataModels.Shoes;
using System.ComponentModel.DataAnnotations;

namespace StoreDataModels.DTO
{
    public record ShoeCategoryDTO : IRequest<ShoeCategory>
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
