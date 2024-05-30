using MediatR;
using StoreDataModels.Clothes;
using System.ComponentModel.DataAnnotations;

namespace StoreDataModels.DTO
{
    public record FitDTO : IRequest<Fit>
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
