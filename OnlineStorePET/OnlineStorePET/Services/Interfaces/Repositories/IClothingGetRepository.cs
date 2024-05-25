using StoreDataModels.Clothes;

namespace OnlineStorePET.Services.Interfaces.Repositories
{
    public interface IClothingGetRepository
    {
        Task<IQueryable<Clothing>> GetAllClothesAsync();
        Task<IQueryable<ClothingCategory>> GetAllClothingCategoriesAsync();
        Task<IQueryable<ClothingSize>> GetAllClothingSizesAsync();
        Task<IQueryable<Fit>> GetAllFitsAsync();
        Task<IQueryable<SleeveLenght>> GetAllSleeveLenghtsAsync();
    }
}
