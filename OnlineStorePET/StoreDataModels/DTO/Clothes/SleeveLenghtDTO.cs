using MediatR;
using StoreDataModels.Clothes;
using System.ComponentModel.DataAnnotations;

namespace StoreDataModels.DTO
{
    public record SleeveLenghtDTO : IRequest<SleeveLenght>
    {
        [Required]
        public string Lenght { get; set; } = null!;
    }
}
