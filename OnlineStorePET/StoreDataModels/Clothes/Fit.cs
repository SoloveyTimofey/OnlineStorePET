using System.ComponentModel.DataAnnotations;

namespace StoreDataModels.Clothes
{
    public class Fit : IPrototype<Fit>
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public ICollection<Clothing> Clothes { get; set; } = [];

        public Fit Clone()
        {
            return new Fit
            {
                Id = this.Id,
                Name = this.Name,
                Clothes = this.Clothes
            };
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
