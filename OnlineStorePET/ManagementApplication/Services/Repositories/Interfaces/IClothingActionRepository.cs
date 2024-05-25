using Microsoft.AspNetCore.JsonPatch;
using StoreDataModels.Clothes;
using StoreDataModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.Services.Repositories.Interfaces
{
    public interface IClothingActionRepository
    {
        Task<(Clothing, HttpStatusCode)> CreateClothingAsync(ClothingDTO clothing);
        Task<(Clothing, HttpStatusCode)> UpdateClothingAsync(long id, JsonPatchDocument<Clothing> patchDoc);
        Task<HttpStatusCode> DeleteClothingAsync(long id);

        Task<(ClothingCategory, HttpStatusCode)> CreateClothingCategoryAsync(ClothingCategoryDTO clothingCategory);
        Task<(ClothingCategory, HttpStatusCode)> UpdateClothingCategoryAsync(long id, JsonPatchDocument<ClothingCategory> patchDoc);
        Task<HttpStatusCode> DeleteClothingCategoryAsync(long id);

        Task<(SleeveLenght, HttpStatusCode)> CreateSleeveLenghtAsync(SleeveLenghtDTO sleeveLenght);
        Task<(SleeveLenght, HttpStatusCode)> UpdateSleeveLenghtAsync(long id, JsonPatchDocument<SleeveLenght> patchDoc);
        Task<HttpStatusCode> DeleteSleeveLenghtAsync(long id);

        Task<(Fit, HttpStatusCode)> CreateFitAsync(FitDTO fit);
        Task<(Fit, HttpStatusCode)> UpdateFitAsync(long id, JsonPatchDocument<Fit> patchDoc);
        Task<HttpStatusCode> DeleteFitAsync(long id);

        Task<(ClothingSize, HttpStatusCode)> CreateClothingSizeAsync(ClothingSizeDTO clothingSize);
        Task<(ClothingSize, HttpStatusCode)> UpdateClothingSizeAsync(long id, JsonPatchDocument<ClothingSize> patchDoc);
        Task<HttpStatusCode> DeleteClothingSizeAsync(long id);

        Task<(ClothingSizeJunction, HttpStatusCode)> AddSizeToClothingAsync(ClothingSizeJunctionDTO clothingSizeJunction);
        Task<(IEnumerable<ClothingSizeJunction>, HttpStatusCode)> AddRangeSizeToClothingAsync(IEnumerable<ClothingSizeJunctionDTO> clothingSizeJunctions);
        Task<HttpStatusCode> RemoveSizeFromClothingAsync(long id);
    }
}
