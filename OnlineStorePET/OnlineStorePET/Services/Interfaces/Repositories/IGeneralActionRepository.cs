using StoreDataModels.DTO;
using StoreDataModels;
using Azure;
using Microsoft.AspNetCore.JsonPatch;

namespace OnlineStorePET.Services.Interfaces.Repositories
{
    public interface IGeneralActionRepository
    {
        Task<Country> CreateCountryAsync(CountryDTO country);
        Task<Country> UpdateCountryAsync(long id, JsonPatchDocument<Country> patchDoc);
        Task DeleteCountryAsync(long id);

        Task<Brand> CreateBrandAsync(BrandDTO brand);
        Task<Brand> UpdateBrandAsync(long id, JsonPatchDocument<Brand> patchDoc);
        Task DeleteBrandAsync(long id);

        Task<Color> CreateColorAsync(ColorDTO color);
        Task<Color> UpdateColorAsync(long id, JsonPatchDocument<Color> patchDoc);
        Task DeleteColorAsync(long id);

        Task<Image> CreateImageAsync(ImageDTO image);
        Task<Image> UpdateImageAsync(long id, JsonPatchDocument<Image> patchDoc);
        Task DeleteImageAsync(long id);
    }
}
