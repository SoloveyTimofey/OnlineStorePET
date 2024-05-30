using MediatR;
using StoreDataModels.Clothes;
using System.ComponentModel.DataAnnotations;

namespace StoreDataModels.DTO
{
    public record ClothingSizeDTO : IRequest<ClothingSize>
    {
        [Required]
        [StringLength(4)]
        public string Size { get; set; } = null!;
    }
}
