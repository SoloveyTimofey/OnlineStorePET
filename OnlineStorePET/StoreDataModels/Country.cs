using System.ComponentModel.DataAnnotations;

namespace StoreDataModels
{
    public class Country : IPrototype<Country>
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public ICollection<Brand> Brands { get; set; } = [];

        public Country Clone()
        {
            return new Country
            {
                Id = Id,
                Name = Name,
                Brands = Brands
            };
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
