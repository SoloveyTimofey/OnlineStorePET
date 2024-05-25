using Azure;
using StoreDataModels.Clothes;
using StoreDataModels.DTO;
using Microsoft.AspNetCore.JsonPatch;

namespace OnlineStorePET.Services.Interfaces.Repositories
{
    public interface IClothingActionRepository
    {
        Task<Clothing> CreateClothingAsync(ClothingDTO clothing);
        Task<Clothing> UpdateClothingAsync(long id, JsonPatchDocument<Clothing> patchDoc);
        Task DeleteClothingAsync(long id);

        Task<ClothingCategory> CreateClothingCategoryAsync(ClothingCategoryDTO clothingCategory);
        Task<ClothingCategory> UpdateClothingCategoryAsync(long id, JsonPatchDocument<ClothingCategory> patchDoc);
        Task DeleteClothingCategoryAsync(long id);

        Task<SleeveLenght> CreateSleeveLenghtAsync(SleeveLenghtDTO sleeveLenght);
        Task<SleeveLenght> UpdateSleeveLenghtAsync(long id, JsonPatchDocument<SleeveLenght> patchDoc);
        Task DeleteSleeveLenghtAsync(long id);

        Task<Fit> CreateFitAsync(FitDTO fit);
        Task<Fit> UpdateFitAsync(long id, JsonPatchDocument<Fit> patchDoc);
        Task DeleteFitAsync(long id);

        Task<ClothingSize> CreateClothingSizeAsync(ClothingSizeDTO clothingSize);
        Task<ClothingSize> UpdateClothingSizeAsync(long id, JsonPatchDocument<ClothingSize> patchDoc);
        Task DeleteClothingSizeAsync(long id);

        Task<ClothingSizeJunction> AddSizeToClothingAsync(ClothingSizeJunctionDTO clothingSizeJunction);
        Task<IEnumerable<ClothingSizeJunction>> AddRangeSizeToClothingAsync(IEnumerable<ClothingSizeJunctionDTO> clothingSizeJunctions);
        Task RemoveSizeFromClothingAsync(long id);
    }
}
