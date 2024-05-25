using ManagementApplication.Services.Repositories.Implementations;
using ManagementApplication.Services.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using StoreDataModels;
using StoreDataModels.Clothes;
using StoreDataModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.Services.Implementations.Repositories
{
    public class ClothingRepository : RepositoryBase,IClothingGetRepository, IClothingActionRepository
    {
        private readonly HttpClient httpClient;
        public ClothingRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        #region Action
        #region Clothing
        public async Task<(Clothing, HttpStatusCode)> CreateClothingAsync(ClothingDTO clothing)
        {
            return await HandleResponse<Clothing>(() => httpClient.PostAsJsonAsync("api/Clothes/CreateClothing", clothing));
        }
        public Task<HttpStatusCode> DeleteClothingAsync(long id)
        {
            throw new NotImplementedException();
        }
        public Task<(Clothing, HttpStatusCode)> UpdateClothingAsync(long id, JsonPatchDocument<Clothing> patchDoc)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ClothingCategory
        public async Task<(ClothingCategory, HttpStatusCode)> CreateClothingCategoryAsync(ClothingCategoryDTO clothingCategory)
        {
            return await HandleResponse<ClothingCategory>(() => httpClient.PostAsJsonAsync("api/Clothes/CreateClothingCategory", clothingCategory));
        }
        public Task<(ClothingCategory, HttpStatusCode)> UpdateClothingCategoryAsync(long id, JsonPatchDocument<ClothingCategory> patchDoc)
        {
            throw new NotImplementedException();
        }
        public Task<HttpStatusCode> DeleteClothingCategoryAsync(long id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region SleeveLenght
        public async Task<(SleeveLenght, HttpStatusCode)> CreateSleeveLenghtAsync(SleeveLenghtDTO sleeveLenght)
        {
            return await HandleResponse<SleeveLenght>(() => httpClient.PostAsJsonAsync("api/Clothes/CreateSleeveLenght", sleeveLenght));
        }
        public Task<HttpStatusCode> DeleteSleeveLenghtAsync(long id)
        {
            throw new NotImplementedException();
        }
        public Task<(SleeveLenght, HttpStatusCode)> UpdateSleeveLenghtAsync(long id, JsonPatchDocument<SleeveLenght> patchDoc)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Fit
        public async Task<(Fit, HttpStatusCode)> CreateFitAsync(FitDTO fit)
        {
            return await HandleResponse<Fit>(() => httpClient.PostAsJsonAsync("api/Clothes/CreateFit", fit));
        }
        public Task<(Fit, HttpStatusCode)> UpdateFitAsync(long id, JsonPatchDocument<Fit> patchDoc)
        {
            throw new NotImplementedException();
        }
        public Task<HttpStatusCode> DeleteFitAsync(long id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ClothingSize
        public async Task<(ClothingSize, HttpStatusCode)> CreateClothingSizeAsync(ClothingSizeDTO clothingSize)
        {
            return await HandleResponse<ClothingSize>(()=> httpClient.PostAsJsonAsync("api/Clothes/CreateClothingSize", clothingSize));
        }
        public Task<(ClothingSize, HttpStatusCode)> UpdateClothingSizeAsync(long id, JsonPatchDocument<ClothingSize> patchDoc)
        {
            throw new NotImplementedException();
        }
        public Task<HttpStatusCode> DeleteClothingSizeAsync(long id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ClothingSizeJunc
        public Task<(ClothingSizeJunction, HttpStatusCode)> AddSizeToClothingAsync(ClothingSizeJunctionDTO clothingSizeJunction)
        {
            throw new NotImplementedException();
        }
        public async Task<(IEnumerable<ClothingSizeJunction>, HttpStatusCode)> AddRangeSizeToClothingAsync(IEnumerable<ClothingSizeJunctionDTO> clothingSizeJunctions)
        {
            return await HandleResponse<IEnumerable<ClothingSizeJunction>>(() => httpClient.PostAsJsonAsync("api/Clothes/AddRangeSizeToClothing", clothingSizeJunctions));
        }
        public Task<HttpStatusCode> RemoveSizeFromClothingAsync(long id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion

        #region Get
        public async Task<(ICollection<Clothing>, HttpStatusCode)> GetAllClothesAsync()
        {
            return await HandleResponse<ICollection<Clothing>>(() => httpClient.GetAsync("/api/Clothes/GetAllClothes"));
        }

        public async Task<(ICollection<ClothingCategory>, HttpStatusCode)> GetAllClothingCategoriesAsync()
        {
            return await HandleResponse<ICollection<ClothingCategory>>(()=>httpClient.GetAsync("/api/Clothes/GetAllClothingCategories"));
        }

        public async Task<(ICollection<ClothingSize>, HttpStatusCode)> GetAllClothingSizesAsync()
        {
            return await HandleResponse<ICollection<ClothingSize>>(() => httpClient.GetAsync("/api/Clothes/GetAllClothingSizes"));
        }

        public async Task<(ICollection<Fit>, HttpStatusCode)> GetAllFitsAsync()
        {
            return await HandleResponse<ICollection<Fit>>(() => httpClient.GetAsync("/api/Clothes/GetAllClothingFits"));
        }

        public async Task<(ICollection<SleeveLenght>, HttpStatusCode)> GetAllSleeveLenghtsAsync()
        {
            return await HandleResponse<ICollection<SleeveLenght>>(() => httpClient.GetAsync("/api/Clothes/GetAllSleeveLenghts"));
        }
        #endregion

    }
}
