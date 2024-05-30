using MediatR;
using StoreDataModels.Clothes;
using System.ComponentModel.DataAnnotations;

namespace StoreDataModels.DTO
{
    public record ClothingCategoryDTO : IRequest<ClothingCategory>
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
