using StoreDataModels;

namespace StoreDataModels.Shoes
{
    public class ShoeCategory : Category, IPrototype<ShoeCategory>
    {
        public ICollection<Shoe> Shoes { get; set; } = [];

        public ShoeCategory Clone()
        {
            return new ShoeCategory
            {
                Id = this.Id,
                Name = this.Name,
                Items=this.Items,
                Shoes=this.Shoes
            };
        }
    }
}
