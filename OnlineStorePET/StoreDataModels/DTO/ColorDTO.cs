using MediatR;
using System.ComponentModel.DataAnnotations;

namespace StoreDataModels.DTO
{
    public record ColorDTO : IRequest<Color>
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(7)]
        [RegularExpression("^#[0-9A-Fa-f]{6}$")]
        public string HEX { get; set; } = null!;
    }
}
