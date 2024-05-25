using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStorePET.Services.Interfaces.Repositories;
using StoreDataModels;
using StoreDataModels.DTO;

namespace OnlineStorePET.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GeneralController:ControllerBase
    {
        private readonly IGeneralActionRepository generalActionRepository;
        private readonly IGeneralGetRepository generalGetRepository;
        public GeneralController(IGeneralActionRepository generalActionRepository, IGeneralGetRepository generalGetRepository)
        {
            this.generalActionRepository = generalActionRepository;
            this.generalGetRepository = generalGetRepository;
        }

        #region Action
        #region Country
        [HttpPost, Route(nameof(CreateCountry))]
        public async Task<Country> CreateCountry([FromBody] CountryDTO country)
        {
            return await generalActionRepository.CreateCountryAsync(country);
        }

        [HttpPatch, Route(nameof(UpdateCountry) + "/{id}")]
        public async Task<Country> UpdateCountry([FromRoute] long id, [FromBody] JsonPatchDocument<Country> patchDoc)
        {

            return await generalActionRepository.UpdateCountryAsync(id, patchDoc);
        }

        [HttpDelete, Route(nameof(DeleteCountry) + "/{id}")]
        public async Task DeleteCountry([FromRoute] long id)
        {
            await generalActionRepository.DeleteCountryAsync(id);
        }
        #endregion

        #region Brand
        [HttpPost, Route(nameof(CreateBrand))]
        public async Task<Brand> CreateBrand([FromBody] BrandDTO brand)
        {
            return await generalActionRepository.CreateBrandAsync(brand);
        }

        [HttpPatch, Route(nameof(UpdateBrand)+"/{id}")]
        public async Task<Brand> UpdateBrand([FromRoute] long id, [FromBody] JsonPatchDocument<Brand> patchDoc)
        {
            return await generalActionRepository.UpdateBrandAsync(id, patchDoc);
        }

        [HttpDelete, Route(nameof(DeleteBrand)+"/{id}")]
        public async Task DeleteBrand([FromRoute] long id)
        {
            await generalActionRepository.DeleteBrandAsync(id);
        }
        #endregion

        #region Color 

        [HttpPost, Route(nameof(CreateColor))]
        public async Task<Color> CreateColor([FromBody]ColorDTO color)
        {
            return await generalActionRepository.CreateColorAsync(color);
        }

        [HttpPatch, Route(nameof(UpdateColor))]
        public async Task<Color> UpdateColor([FromRoute]long id, [FromBody]JsonPatchDocument<Color> patchDoc)
        {
            return await generalActionRepository.UpdateColorAsync(id, patchDoc);
        }

        [HttpDelete, Route(nameof(DeleteColor)+"/{id}")]
        public async Task DeleteColor([FromRoute]long id)
        {
            await generalActionRepository.DeleteColorAsync(id);
        }
        #endregion

        #region Image
        [HttpPost, Route(nameof(CreateImage))]
        public async Task<Image> CreateImage([FromBody]ImageDTO image)
        {
            return await generalActionRepository.CreateImageAsync(image);
        }

        [HttpPatch, Route(nameof(UpdateImage)+"/{id}")]
        public async Task<Image> UpdateImage([FromRoute]long id,[FromBody] JsonPatchDocument<Image> patchDoc)
        {
            return await generalActionRepository.UpdateImageAsync(id, patchDoc);
        }

        [HttpDelete, Route(nameof(DeleteImage)+"/{id}")]
        public async Task DeleteImage([FromRoute]long id)
        {
            await generalActionRepository.DeleteImageAsync(id);
        }
        #endregion
        #endregion

        #region Get
        [HttpGet, Route(nameof(GetAllCountries))]
        public async Task<ICollection<Country>> GetAllCountries()
        {
            return await generalGetRepository.GetAllCountriesAsync().Result.ToArrayAsync();
        }

        [HttpGet, Route(nameof(GetAllBrands))]
        public async Task<ICollection<Brand>> GetAllBrands()
        {
            return await generalGetRepository.GetAllBrandsAsync().Result.ToArrayAsync();
        }

        [HttpGet, Route(nameof(GetAllImages))]
        public async Task<ICollection<Image>> GetAllImages()
        {
            return await generalGetRepository.GetAllImagesAsync().Result.ToArrayAsync();
        }

        [HttpGet, Route(nameof(GetAllColors))]
        public async Task<ICollection<Color>> GetAllColors()
        {
            return await generalGetRepository.GetAllColorsAsync().Result.ToArrayAsync();
        }
        #endregion
    }
}
