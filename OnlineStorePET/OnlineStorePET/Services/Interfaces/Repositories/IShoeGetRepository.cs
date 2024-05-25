using StoreDataModels.Shoes;

namespace OnlineStorePET.Services.Interfaces.Repositories
{
    public interface IShoeGetRepository
    {
        Task<IQueryable<Shoe>> GetAllShoesAsync();
        Task<IQueryable<ShoeCategory>> GetAllShoeCategoriesAsync();
        Task<IQueryable<ShoeSize>> GetAllShoeSizesAsync();
    }
}
