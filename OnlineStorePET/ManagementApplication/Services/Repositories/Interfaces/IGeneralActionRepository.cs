using StoreDataModels.DTO;
using StoreDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;
using System.Net;

namespace ManagementApplication.Services.Repositories.Interfaces
{
    public interface IGeneralActionRepository
    {
        Task<(Country, HttpStatusCode)> CreateCountryAsync(CountryDTO country);
        Task<(Country, HttpStatusCode)> UpdateCountryAsync(long id, JsonPatchDocument<Country> patchDoc);
        Task<HttpStatusCode> DeleteCountryAsync(long id);

        Task<(Brand, HttpStatusCode)> CreateBrandAsync(BrandDTO brand);
        Task<(Brand, HttpStatusCode)> UpdateBrandAsync(long id, JsonPatchDocument<Brand> patchDoc);
        Task<HttpStatusCode> DeleteBrandAsync(long id);

        Task<(Color, HttpStatusCode)> CreateColorAsync(ColorDTO color);
        Task<(Color, HttpStatusCode)> UpdateColorAsync(long id, JsonPatchDocument<Color> patchDoc);
        Task<HttpStatusCode> DeleteColorAsync(long id);

        Task<(Image, HttpStatusCode)> CreateImageAsync(ImageDTO image);
        Task<(Image, HttpStatusCode)> UpdateImageAsync(long id, JsonPatchDocument<Image> patchDoc);
        Task<HttpStatusCode> DeleteImageAsync(long id);
    }
}
