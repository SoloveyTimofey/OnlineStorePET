using MediatR;
using System.ComponentModel.DataAnnotations;

namespace StoreDataModels.DTO
{
    public record CountryDTO : IRequest<Country>
    {
        [Required]
        public string Name { get; set; } = null!;

        public ICollection<long> Brands { get; set; } = [];
    }
}
