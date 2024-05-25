using System.ComponentModel.DataAnnotations;

namespace StoreDataModels.Clothes
{
    public class SleeveLenght : IPrototype<SleeveLenght>
    {
        public long Id { get; set; }

        [Required]
        public string Lenght { get; set; } = null!;

        public ICollection<Clothing> Clothes { get; set; } = [];

        public SleeveLenght Clone()
        {
            return new SleeveLenght
            {
                Id = this.Id,
                Lenght = this.Lenght,
                Clothes = this.Clothes
            };
        }

        public override string ToString()
        {
            return this.Lenght;
        }
    }
}
