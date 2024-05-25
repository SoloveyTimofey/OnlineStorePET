using StoreDataModels;

namespace StoreDataModels.Clothes
{
    public class ClothingCategory : Category, IPrototype<ClothingCategory>
    {
        public ICollection<Clothing> Clothes { get; set; } = [];

        public ClothingCategory Clone()
        {
            return new ClothingCategory
            {
                Id = this.Id,
                Name = this.Name,
                Items = this.Items,
                Clothes = this.Clothes
            };
        }

        public override string ToString()
        {
            return base.Name;
        }
    }
}
