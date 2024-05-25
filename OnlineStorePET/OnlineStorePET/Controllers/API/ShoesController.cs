using Azure;
using Microsoft.AspNetCore.Mvc;
using OnlineStorePET.Services.Interfaces.Repositories;
using StoreDataModels.DTO;
using Microsoft.AspNetCore.JsonPatch;
using StoreDataModels.Shoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace OnlineStorePET.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ShoesController : ControllerBase
    {
        private readonly IShoeActionRepository shoeActionRepository;
        private readonly IShoeGetRepository shoeGetRepository;
        public ShoesController(IShoeActionRepository shoeActionRepository, IShoeGetRepository shoeGetRepository)
        {
            this.shoeActionRepository = shoeActionRepository;
            this.shoeGetRepository = shoeGetRepository;
        }

        #region Action
        #region Shoe
        [HttpPost, Route(nameof(CreateShoe))]
        public async Task<Shoe> CreateShoe([FromBody]ShoeDTO shoe)
        {
            return await shoeActionRepository.CreateShoeAsync(shoe);
        }

        [HttpPatch, Route(nameof(UpdateShoe)+"/{id}")]
        public async Task<Shoe> UpdateShoe([FromRoute] long id,[FromBody] JsonPatchDocument<Shoe> patchDoc)
        {
            return await shoeActionRepository.UpdateShoeAsync(id, patchDoc);
        }

        [HttpDelete, Route(nameof(DeleteShoe)+"/{id}")]
        public async Task DeleteShoe([FromRoute] long id)
        {
            await shoeActionRepository.DeleteShoeAsync(id);
        }
        #endregion

        #region ShoeCategory
        [HttpPost, Route(nameof(CreateShoeCategory))]
        public async Task<ShoeCategory> CreateShoeCategory([FromBody] ShoeCategoryDTO shoeCategory)
        {
            return await shoeActionRepository.CreateShoeCategoryAsync(shoeCategory);
        }

        [HttpPatch, Route(nameof(UpdateShoeCategory)+"/{id}")]
        public async Task<ShoeCategory> UpdateShoeCategory([FromRoute]long id,[FromBody] JsonPatchDocument<ShoeCategory> patchDoc)
        {
            return await shoeActionRepository.UpdateShoeCategoryAsync(id, patchDoc);
        }

        [HttpDelete, Route(nameof(DeleteShoeCategory)+"/{id}")]
        public async Task DeleteShoeCategory([FromRoute] long id)
        {
            await shoeActionRepository.DeleteShoeAsync(id);
        }
        #endregion

        #region ShoeSize
        [HttpPost, Route(nameof(CreateShoeSize))]
        public async Task<ShoeSize> CreateShoeSize([FromBody] ShoeSizeDTO shoeSize)
        {
            return await shoeActionRepository.CreateShoeSizeAsync(shoeSize);
        }

        [HttpPatch, Route(nameof(UpdateShoeSize)+"/{id}")]
        public async Task<ShoeSize> UpdateShoeSize([FromRoute] long id,[FromBody] JsonPatchDocument<ShoeSize> patchDoc)
        {
            return await shoeActionRepository.UpdateShoeSizeAsync(id, patchDoc);
        }

        [HttpDelete, Route(nameof(DeleteShoeSize)+"/{id}")]
        public async Task DeleteShoeSize([FromRoute] long id)
        {
            await shoeActionRepository.DeleteShoeSizeAsync(id);
        }
        #endregion

        #region ShoeSizeJunc
        [HttpPost, Route(nameof(AddSizeToShoe))]
        public async Task<ShoeSizeJunction> AddSizeToShoe([FromBody]ShoeSizeJunctionDTO shoeSizeJunc)
        {
            return await shoeActionRepository.AddSizeToShoeAsync(shoeSizeJunc);
        }

        [HttpDelete, Route(nameof(RemoveSizeFromShoe)+"/{id}")]
        public async Task RemoveSizeFromShoe(long id)
        {
            await shoeActionRepository.RemoveSizeFromShoeAsync(id);
        }
        #endregion
        #endregion

        #region Get
        [HttpGet, Route(nameof(GetAllShoes))]
        public async Task<ICollection<Shoe>> GetAllShoes()
        {
            return await shoeGetRepository.GetAllShoesAsync().Result.ToArrayAsync();
        }

        [HttpGet, Route(nameof(GetAllShoeCategories))]
        public async Task<ICollection<ShoeCategory>> GetAllShoeCategories()
        {
            return await shoeGetRepository.GetAllShoeCategoriesAsync().Result.ToArrayAsync();
        }

        [HttpGet, Route(nameof(GetAllShoeSizes))]
        public async Task<ICollection<ShoeSize>> GetAllShoeSizes()
        {
            return await shoeGetRepository.GetAllShoeSizesAsync().Result.ToArrayAsync();
        }
        #endregion
    }
}
