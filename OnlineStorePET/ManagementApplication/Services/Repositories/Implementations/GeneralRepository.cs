using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ManagementApplication.Services.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using StoreDataModels;
using StoreDataModels.DTO;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using System.Threading;
using ManagementApplication.Services.Repositories.Implementations;
using StoreDataModels.Clothes;

namespace ManagementApplication.Services.Implementations.Repositories
{
    public class GeneralRepository : RepositoryBase,IGeneralActionRepository, IGeneralGetRepository
    {
        private readonly HttpClient httpClient;
        public GeneralRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        #region Action
        #region Country
        public async Task<(Country, HttpStatusCode)> CreateCountryAsync(CountryDTO country)
        {
            return await HandleResponse<Country>(() => httpClient.PostAsJsonAsync("api/General/CreateCountry", country));
        }
        public async Task<(Country, HttpStatusCode)> UpdateCountryAsync(long id, JsonPatchDocument<Country> patchDoc)
        {
            throw new NotImplementedException();
        }
        public async Task<HttpStatusCode> DeleteCountryAsync(long id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Brand
        public async Task<(Brand, HttpStatusCode)> CreateBrandAsync(BrandDTO brand)
        {
            return await HandleResponse<Brand>(() => httpClient.PostAsJsonAsync("api/General/CreateBrand", brand));
        }
        public Task<(Brand, HttpStatusCode)> UpdateBrandAsync(long id, JsonPatchDocument<Brand> patchDoc)
        {
            throw new NotImplementedException();
        }
        public Task<HttpStatusCode> DeleteBrandAsync(long id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Color
        public async Task<(Color, HttpStatusCode)> CreateColorAsync(ColorDTO color)
        {
            return await HandleResponse<Color>(() => httpClient.PostAsJsonAsync("api/General/CreateColor", color));
        }
        public async Task<(Color, HttpStatusCode)> UpdateColorAsync(long id, JsonPatchDocument<Color> patchDoc)
        {
            throw new NotImplementedException();
        }
        public async Task<HttpStatusCode> DeleteColorAsync(long id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Image
        public async Task<(Image, HttpStatusCode)> CreateImageAsync(ImageDTO image)
        {
            return await HandleResponse<Image>(() => httpClient.PostAsJsonAsync("/api/General/CreateImage", image));
        }

        public async Task<(Image, HttpStatusCode)> UpdateImageAsync(long id, JsonPatchDocument<Image> patchDoc)
        {
            throw new NotImplementedException();
        }
        public async Task<HttpStatusCode> DeleteImageAsync(long id)
        {
            throw new NotImplementedException();
        }

        #endregion
        #endregion

        #region Get
        public async Task<(ICollection<Country>, HttpStatusCode)> GetAllCountriesAsync()
        {
            return await HandleResponse<ICollection<Country>>(() => httpClient.GetAsync("api/General/GetAllCountries"));
        }

        public async Task<(ICollection<Brand>, HttpStatusCode)> GetAllBrandsAsync()
        {
            return await HandleResponse<ICollection<Brand>>(() => httpClient.GetAsync("api/General/GetAllBrands"));
        }

        public async Task<(ICollection<Image>, HttpStatusCode)> GetAllImagesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<(ICollection<Color>, HttpStatusCode)> GetAllColorsAsync()
        {
            return await HandleResponse<ICollection<Color>>(() => httpClient.GetAsync("api/General/GetAllColors"));
        }
        #endregion
    }
}
