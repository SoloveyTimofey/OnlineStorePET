using StoreDataModels;

namespace OnlineStorePET.Services.Interfaces.Repositories
{
    public interface IGeneralGetRepository
    {
        Task<IQueryable<Country>> GetAllCountriesAsync();
        
        Task<IQueryable<Brand>> GetAllBrandsAsync();

        Task<IQueryable<Image>> GetAllImagesAsync();

        Task<IQueryable<Color>> GetAllColorsAsync();
    }
}
