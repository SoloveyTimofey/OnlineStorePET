using ManagementApplication.Models;
using Microsoft.AspNetCore.JsonPatch;
using StoreDataModels.DTO;
using StoreDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics.Metrics;
using ManagementApplication.Services.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;

namespace ManagementApplication.Services.Repositories.Proxy
{
    public class GeneralRepositoryProxy : ProxyBase
    {
        private readonly IGeneralActionRepository generalActionRepository;
        private readonly IGeneralGetRepository generalGetRepository;
        public GeneralRepositoryProxy(IGeneralActionRepository generalActionRepository, IGeneralGetRepository generalGetRepository,
            TokenExpired tokenExpiredHandler):base(tokenExpiredHandler)
        {
            this.generalActionRepository = generalActionRepository;
            this.generalGetRepository = generalGetRepository;
        }

        #region Action
        #region Country
        public async Task<(Country, HttpStatusCode)> CreateCountryAsync(CountryDTO country)
        {
            return await HandleRCUResponseAsync(()=>generalActionRepository.CreateCountryAsync(country));
        }
        public async Task<(Country, HttpStatusCode)> UpdateCountryAsync(long id, JsonPatchDocument<Country> patchDoc)
        {
            return await HandleRCUResponseAsync(()=>generalActionRepository.UpdateCountryAsync(id, patchDoc));
        }
        public async Task<HttpStatusCode> DeleteCountryAsync(long id)
        {
            return await HandleDeleteResponseAsync(()=>generalActionRepository.DeleteCountryAsync(id));
        }
        #endregion

        #region Brand
        public async Task<(Brand, HttpStatusCode)> CreateBrandAsync(BrandDTO brand)
        {
            return await HandleRCUResponseAsync(()=>generalActionRepository.CreateBrandAsync(brand));
        }
        public async Task<(Brand, HttpStatusCode)> UpdateBrandAsync(long id, JsonPatchDocument<Brand> patchDoc)
        {
            return await HandleRCUResponseAsync(() => generalActionRepository.UpdateBrandAsync(id, patchDoc));
        }
        public async Task<HttpStatusCode> DeleteBrandAsync(long id)
        {
            return await HandleDeleteResponseAsync(() => generalActionRepository.DeleteBrandAsync(id));
        }
        #endregion

        #region Color
        public async Task<(Color, HttpStatusCode)> CreateColorAsync(ColorDTO color)
        {
            return await HandleRCUResponseAsync(()=>generalActionRepository.CreateColorAsync(color));
        }
        public async Task<(Color, HttpStatusCode)> UpdateColorAsync(long id, JsonPatchDocument<Color> patchDoc)
        {
            return await HandleRCUResponseAsync(()=>generalActionRepository.UpdateColorAsync(id, patchDoc));
        }
        public async Task<HttpStatusCode> DeleteColorAsync(long id)
        {
            return await HandleDeleteResponseAsync(()=>generalActionRepository.DeleteColorAsync(id));
        }
        #endregion

        #region Image
        public async Task<(Image, HttpStatusCode)> CreateImageAsync(ImageDTO image)
        {
            return await HandleRCUResponseAsync(() => generalActionRepository.CreateImageAsync(image));
        }

        public async Task<(Image, HttpStatusCode)> UpdateImageAsync(long id, JsonPatchDocument<Image> patchDoc)
        {
            return await HandleRCUResponseAsync(()=>generalActionRepository.UpdateImageAsync(id, patchDoc));
        }
        public async Task<HttpStatusCode> DeleteImageAsync(long id)
        {
            return await HandleDeleteResponseAsync(()=>generalActionRepository.DeleteImageAsync(id));
        }
        #endregion
        #endregion

        #region Get
        public async Task<(ICollection<Country>, HttpStatusCode)> GetAllCountriesAsync()
        {
            return await HandleRCUResponseAsync(() => generalGetRepository.GetAllCountriesAsync());
        }

        public async Task<(ICollection<Brand>, HttpStatusCode)> GetAllBrandsAsync()
        {
            return await HandleRCUResponseAsync(() => generalGetRepository.GetAllBrandsAsync());
        }

        public async Task<(ICollection<Image>, HttpStatusCode)> GetAllImagesAsync()
        {
            return await HandleRCUResponseAsync(() => generalGetRepository.GetAllImagesAsync());
        }

        public async Task<(ICollection<Color>,HttpStatusCode)> GetAllColorsAsync()
        {
            return await HandleRCUResponseAsync(() => generalGetRepository.GetAllColorsAsync());
        }
        #endregion
    }
}
