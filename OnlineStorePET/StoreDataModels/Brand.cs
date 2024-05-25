using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using StoreDataModels.Shoes;
using StoreDataModels.Clothes;

namespace StoreDataModels
{
    public class Brand : IPrototype<Brand>
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public long CountryId { get; set; }
        public Country Country { get; set; } = null!;

        public ICollection<Clothing> Clothes { get; set; } = [];
        public ICollection<Shoe> Shoes { get; set; } = [];

        public Brand Clone()
        {
            return new Brand
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                CountryId = this.CountryId,
                Country = this.Country,
                Clothes = this.Clothes,
                Shoes =this.Shoes
            };
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
