using Microsoft.AspNetCore.Mvc;
using OnlineStorePET.Services.Interfaces.Repositories;
using StoreDataModels.Clothes;
using StoreDataModels.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using MediatR;

namespace OnlineStorePET.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClothesController : ControllerBase
    {
        private readonly IClothingActionRepository clothingActionRepository;
        private readonly IClothingGetRepository clothingGetRepository;
        public ClothesController(IClothingGetRepository clothingGetRepository, IClothingActionRepository clothingActionRepository, IMediator mediator)
        {
            this.clothingActionRepository = clothingActionRepository;
            this.clothingGetRepository = clothingGetRepository;
        }

        #region Action
        #region Clothing
        [HttpPost, Route(nameof(CreateClothing))]
        public async Task<Clothing> CreateClothing([FromBody] ClothingDTO clothing)
        {
            return await clothingActionRepository.CreateClothingAsync(clothing);
        }

        [HttpPatch, Route(nameof(UpdateClothing) + "/{id}")]
        public async Task<Clothing> UpdateClothing([FromRoute] long id, [FromBody] JsonPatchDocument<Clothing> patchDoc)
        {
            return await clothingActionRepository.UpdateClothingAsync(id, patchDoc);
        }

        [HttpDelete, Route(nameof(DeleteClothing) + "/{id}")]
        public async Task DeleteClothing([FromRoute] long id)
        {
            await clothingActionRepository.DeleteClothingAsync(id);
        }
        #endregion

        #region ClothingCategory
        [HttpPost, Route(nameof(CreateClothingCategory))]
        public async Task<ClothingCategory> CreateClothingCategory([FromBody] ClothingCategoryDTO clothingCategory)
        {
            return await clothingActionRepository.CreateClothingCategoryAsync(clothingCategory);
        }

        [HttpPatch, Route(nameof(UpdateClothingCategory) + "/{id}")]
        public async Task<ClothingCategory> UpdateClothingCategory([FromRoute] long id, [FromBody] JsonPatchDocument<ClothingCategory> patchDoc)
        {
            return await clothingActionRepository.UpdateClothingCategoryAsync(id, patchDoc);
        }

        [HttpDelete, Route(nameof(DeleteClothingCategory) + "/{id}")]
        public async Task DeleteClothingCategory(long id)
        {
            await clothingActionRepository.DeleteClothingCategoryAsync(id);
        }
        #endregion

        #region SleeveLenght
        [HttpPost, Route(nameof(CreateSleeveLenght))]
        public async Task<SleeveLenght> CreateSleeveLenght([FromBody] SleeveLenghtDTO sleeveLenght)
        {
            return await clothingActionRepository.CreateSleeveLenghtAsync(sleeveLenght);
        }

        [HttpPatch, Route(nameof(UpdateSleeveLenght) + "/{id}")]
        public async Task<SleeveLenght> UpdateSleeveLenght([FromRoute] long id, [FromBody] JsonPatchDocument<SleeveLenght> patchDoc)
        {
            return await clothingActionRepository.UpdateSleeveLenghtAsync(id, patchDoc);
        }

        [HttpDelete, Route(nameof(DeleteSleveLenght) + "{id}")]
        public async Task DeleteSleveLenght([FromRoute] long id)
        {
            await clothingActionRepository.DeleteSleeveLenghtAsync(id);
        }
        #endregion

        #region Fit
        [HttpPost, Route(nameof(CreateFit))]
        public async Task<Fit> CreateFit([FromBody] FitDTO fit)
        {
            return await clothingActionRepository.CreateFitAsync(fit);
        }

        [HttpPatch, Route(nameof(UpdateFit) + "/{id}")]
        public async Task<Fit> UpdateFit([FromRoute] long id, [FromBody] JsonPatchDocument<Fit> patchDoc)
        {
            return await clothingActionRepository.UpdateFitAsync(id, patchDoc);
        }

        [HttpDelete, Route(nameof(DeleteFit) + "/{id}")]
        public async Task DeleteFit([FromRoute] long id)
        {
            await clothingActionRepository.DeleteFitAsync(id);
        }
        #endregion

        #region ClothingSize
        [HttpPost, Route(nameof(CreateClothingSize))]
        public async Task<ClothingSize> CreateClothingSize([FromBody] ClothingSizeDTO clothingSize)
        {
            return await clothingActionRepository.CreateClothingSizeAsync(clothingSize);
        }

        [HttpPatch, Route(nameof(UpdateClothingSize) + "/{id}")]
        public async Task<ClothingSize> UpdateClothingSize([FromRoute] long id, [FromBody] JsonPatchDocument<ClothingSize> patchDoc)
        {
            return await clothingActionRepository.UpdateClothingSizeAsync(id, patchDoc);
        }

        [HttpDelete, Route(nameof(DeleteClothingSize) + "/{id}")]
        public async Task DeleteClothingSize([FromRoute] long id)
        {
            await clothingActionRepository.DeleteClothingSizeAsync(id);
        }
        #endregion

        #region ClothingSizeJunc
        [HttpPost, Route(nameof(AddSizeToClothing))]
        public async Task<ClothingSizeJunction> AddSizeToClothing([FromBody] ClothingSizeJunctionDTO clothingSizeJunction)
        {
            return await clothingActionRepository.AddSizeToClothingAsync(clothingSizeJunction);
        }

        [HttpPost, Route(nameof(AddRangeSizeToClothing))]
        public async Task<IEnumerable<ClothingSizeJunction>> AddRangeSizeToClothing(IEnumerable<ClothingSizeJunctionDTO> clothingSizeJunctions)
        {
            return await clothingActionRepository.AddRangeSizeToClothingAsync(clothingSizeJunctions);
        }

        [HttpDelete, Route(nameof(RemoveSizeFromClothing) +"/{id}")]
        public async Task RemoveSizeFromClothing([FromRoute] long id)
        {
            await clothingActionRepository.RemoveSizeFromClothingAsync(id);
        }
        #endregion

        #endregion

        #region Get
        [HttpGet, Route(nameof(GetAllClothes))]
        public async Task<IEnumerable<Clothing>> GetAllClothes()
        {
            return await clothingGetRepository.GetAllClothesAsync();
        }

        [HttpGet, Route(nameof(GetAllClothingCategories))]
        public async Task<IEnumerable<ClothingCategory>> GetAllClothingCategories()
        {
            return await clothingGetRepository.GetAllClothingCategoriesAsync();
        }

        [HttpGet, Route(nameof(GetAllClothingSizes))]
        public async Task<IEnumerable<ClothingSize>> GetAllClothingSizes()
        {
            return await clothingGetRepository.GetAllClothingSizesAsync();
        }

        [HttpGet, Route(nameof(GetAllClothingFits))]
        public async Task<IEnumerable<Fit>> GetAllClothingFits()
        {
            return await clothingGetRepository.GetAllFitsAsync();
        }

        [HttpGet, Route(nameof(GetAllSleeveLenghts))]
        public async Task<IEnumerable<SleeveLenght>> GetAllSleeveLenghts()
        {
            return await clothingGetRepository.GetAllSleeveLenghtsAsync();
        }
        #endregion
    }
}
