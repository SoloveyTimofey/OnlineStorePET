using Azure;
using Microsoft.AspNetCore.JsonPatch;
using StoreDataModels.DTO;
using StoreDataModels.Shoes;

namespace OnlineStorePET.Services.Interfaces.Repositories
{
    public interface IShoeActionRepository
    {
        Task<Shoe> CreateShoeAsync(ShoeDTO shoe);
        Task<Shoe> UpdateShoeAsync(long id, JsonPatchDocument<Shoe> patchDoc);
        Task DeleteShoeAsync(long id);

        Task<ShoeCategory> CreateShoeCategoryAsync(ShoeCategoryDTO shoeCategory);
        Task<ShoeCategory> UpdateShoeCategoryAsync(long id, JsonPatchDocument<ShoeCategory> patchDoc);
        Task DeleteShoeCategoryAsync(long id);

        Task<ShoeSize> CreateShoeSizeAsync(ShoeSizeDTO shoeSize);
        Task<ShoeSize> UpdateShoeSizeAsync(long id, JsonPatchDocument<ShoeSize> patchDoc);
        Task DeleteShoeSizeAsync(long id);

        Task<ShoeSizeJunction> AddSizeToShoeAsync(ShoeSizeJunctionDTO shoeSizeJunction);
        Task RemoveSizeFromShoeAsync(long id);
    }
}
