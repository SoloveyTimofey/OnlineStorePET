using ManagementApplication.Models;
using ManagementApplication.Services.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using StoreDataModels;
using StoreDataModels.Clothes;
using StoreDataModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManagementApplication.Services.Repositories.Proxy
{
    public class ClothingRepositoryProxy:ProxyBase
    {
        private readonly IClothingGetRepository clothingGetRepository;
        private readonly IClothingActionRepository clothingActionRepository;
        public ClothingRepositoryProxy(IClothingGetRepository clothingGetRepository,IClothingActionRepository clothingActionRepository, TokenExpired tokenExpiredHandler):base(tokenExpiredHandler)
        {
            this.clothingGetRepository = clothingGetRepository;
            this.clothingActionRepository = clothingActionRepository;
        }

        #region Action
        #region Clothing
        public async Task<(Clothing, HttpStatusCode)> CreateClothingAsync(ClothingDTO clothing)
        {
            return await HandleRCUResponseAsync(() => clothingActionRepository.CreateClothingAsync(clothing));
        }
        public async Task<(Clothing, HttpStatusCode)> UpdateClothingAsync(long id, JsonPatchDocument<Clothing> patchDoc)
        {
            return await HandleRCUResponseAsync(() => clothingActionRepository.UpdateClothingAsync(id, patchDoc));
        }
        public async Task<HttpStatusCode> DeleteClothingAsync(long id)
        {
            return await HandleDeleteResponseAsync(() => clothingActionRepository.DeleteClothingAsync(id));
        }
        #endregion

        #region ClothingCategory
        public async Task<(ClothingCategory, HttpStatusCode)> CreateClothingCategoryAsync(ClothingCategoryDTO clothingCategory)
        {
            return await HandleRCUResponseAsync(() => clothingActionRepository.CreateClothingCategoryAsync(clothingCategory));
        }
        public async Task<(ClothingCategory, HttpStatusCode)> UpdateClothingCategoryAsync(long id, JsonPatchDocument<ClothingCategory> patchDoc)
        {
            return await HandleRCUResponseAsync(()=>clothingActionRepository.UpdateClothingCategoryAsync(id, patchDoc));
        }
        public async Task<HttpStatusCode> DeleteClothingCategoryAsync(long id)
        {
            return await HandleDeleteResponseAsync(() => clothingActionRepository.DeleteClothingCategoryAsync(id));
        }
        #endregion

        #region SleeveLenght
        public async Task<(SleeveLenght, HttpStatusCode)> CreateSleeveLenghtAsync(SleeveLenghtDTO sleeveLenght)
        {
            return await HandleRCUResponseAsync(() => clothingActionRepository.CreateSleeveLenghtAsync(sleeveLenght));
        }
        public Task<(SleeveLenght, HttpStatusCode)> UpdateSleeveLenghtAsync(long id, JsonPatchDocument<SleeveLenght> patchDoc)
        {
            throw new NotImplementedException();
        }
        public async Task<HttpStatusCode> DeleteSleeveLenghtAsync(long id)
        {
            return await HandleDeleteResponseAsync(() => clothingActionRepository.DeleteSleeveLenghtAsync(id));
        }
        #endregion

        #region Fit
        public async Task<(Fit, HttpStatusCode)> CreateFitAsync(FitDTO fit)
        {
            return await HandleRCUResponseAsync(() => clothingActionRepository.CreateFitAsync(fit));
        }
        public async Task<(Fit, HttpStatusCode)> UpdateFitAsync(long id, JsonPatchDocument<Fit> patchDoc)
        {
            return await HandleRCUResponseAsync(() => clothingActionRepository.UpdateFitAsync(id, patchDoc));
        }
        public async Task<HttpStatusCode> DeleteFitAsync(long id)
        {
            return await HandleDeleteResponseAsync(()=>clothingActionRepository.DeleteFitAsync(id));
        }
        #endregion

        #region ClothingSize
        public async Task<(ClothingSize, HttpStatusCode)> CreateClothingSizeAsync(ClothingSizeDTO clothingSize)
        {
             return await HandleRCUResponseAsync(()=>clothingActionRepository.CreateClothingSizeAsync(clothingSize));
        }
        public async Task<(ClothingSize, HttpStatusCode)> UpdateClothingSizeAsync(long id, JsonPatchDocument<ClothingSize> patchDoc)
        {
            return await HandleRCUResponseAsync(() => clothingActionRepository.UpdateClothingSizeAsync(id, patchDoc));
        }
        public async Task<HttpStatusCode> DeleteClothingSizeAsync(long id)
        {
            return await HandleDeleteResponseAsync(() => clothingActionRepository.DeleteClothingSizeAsync(id));
        }
        #endregion

        #region ClothingSizeJunc
        public async Task<(ClothingSizeJunction, HttpStatusCode)> AddSizeToClothingAsync(ClothingSizeJunctionDTO clothingSizeJunction)
        {
            return await HandleRCUResponseAsync(() => clothingActionRepository.AddSizeToClothingAsync(clothingSizeJunction));
        }
        public async Task<(IEnumerable<ClothingSizeJunction>, HttpStatusCode)> AddRangeSizeToClothingAsync(IEnumerable<ClothingSizeJunctionDTO> clothingSizeJunctions)
        {
            return await HandleRCUResponseAsync(() => clothingActionRepository.AddRangeSizeToClothingAsync(clothingSizeJunctions));
        }
        public async Task<HttpStatusCode> RemoveSizeFromClothingAsync(long id)
        {
            return await HandleDeleteResponseAsync(() => clothingActionRepository.RemoveSizeFromClothingAsync(id));
        }
        #endregion
        #endregion

        #region Get
        public async Task<(ICollection<Clothing>, HttpStatusCode)> GetAllClothesAsync()
        {
            return await HandleRCUResponseAsync(() => clothingGetRepository.GetAllClothesAsync());
        }

        public async Task<(ICollection<ClothingCategory>, HttpStatusCode)> GetAllClothingCategoriesAsync()
        {
            return await HandleRCUResponseAsync(() => clothingGetRepository.GetAllClothingCategoriesAsync());
        }

        public async Task<(ICollection<ClothingSize>, HttpStatusCode)> GetAllClothingSizesAsync()
        {
            return await HandleRCUResponseAsync(() => clothingGetRepository.GetAllClothingSizesAsync());
        }

        public async Task<(ICollection<Fit>, HttpStatusCode)> GetAllFitsAsync()
        {
            return await HandleRCUResponseAsync(() => clothingGetRepository.GetAllFitsAsync());
        }

        public async Task<(ICollection<SleeveLenght>, HttpStatusCode)> GetAllSleeveLenghtsAsync()
        {
            return await HandleRCUResponseAsync(() => clothingGetRepository.GetAllSleeveLenghtsAsync());
        }
        #endregion
    }
}
