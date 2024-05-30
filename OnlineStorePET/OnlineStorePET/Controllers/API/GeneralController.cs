using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnlineStorePET.CQRS.Command.General.Commands;
using OnlineStorePET.CQRS.Command.General.Handlers;
using OnlineStorePET.CQRS.Query.Clothes.Queries;
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
        private readonly IMediator mediator;
        public GeneralController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #region Action
        #region Country
        [HttpPost, Route(nameof(CreateCountry))]
        public async Task<Country> CreateCountry([FromBody] CountryDTO country)
        {
            return await mediator.Send(country);
        }

        [HttpPatch, Route(nameof(UpdateCountry) + "/{id}")]
        public async Task<Country> UpdateCountry([FromRoute] long id, [FromBody] JsonPatchDocument<Country> patchDoc)
        {
            var command = new UpdateCountryCommand(id, patchDoc);
            return await mediator.Send(command);
        }

        [HttpDelete, Route(nameof(DeleteCountry) + "/{id}")]
        public async Task DeleteCountry([FromRoute] long id)
        {
            var command = new DeleteCountryCommand(id);
            await mediator.Send(command);
        }
        #endregion

        #region Brand
        [HttpPost, Route(nameof(CreateBrand))]
        public async Task<Brand> CreateBrand([FromBody] BrandDTO brand)
        {
            return await mediator.Send(brand); 
        }

        [HttpPatch, Route(nameof(UpdateBrand)+"/{id}")]
        public async Task<Brand> UpdateBrand([FromRoute] long id, [FromBody] JsonPatchDocument<Brand> patchDoc)
        {
            var command = new UpdateBrandCommand(id, patchDoc);
            return await mediator.Send(command);
        }

        [HttpDelete, Route(nameof(DeleteBrand)+"/{id}")]
        public async Task DeleteBrand([FromRoute] long id)
        {
            var command = new DeleteBrandCommand(id);
            await mediator.Send(command);
        }
        #endregion

        #region Color 

        [HttpPost, Route(nameof(CreateColor))]
        public async Task<Color> CreateColor([FromBody]ColorDTO color)
        {
            return await mediator.Send(color);
        }

        [HttpPatch, Route(nameof(UpdateColor))]
        public async Task<Color> UpdateColor([FromRoute]long id, [FromBody]JsonPatchDocument<Color> patchDoc)
        {
            var command = new UpdateColorCommand(id, patchDoc);
            return await mediator.Send(command);
        }

        [HttpDelete, Route(nameof(DeleteColor)+"/{id}")]
        public async Task DeleteColor([FromRoute]long id)
        {
            var command = new DeleteColorCommand(id);
            await mediator.Send(command);
        }
        #endregion

        #region Image
        [HttpPost, Route(nameof(CreateImage))]
        public async Task<Image> CreateImage([FromBody]ImageDTO image)
        {
            return await mediator.Send(image);
        }

        [HttpPatch, Route(nameof(UpdateImage)+"/{id}")]
        public async Task<Image> UpdateImage([FromRoute]long id,[FromBody] JsonPatchDocument<Image> patchDoc)
        {
            var command = new UpdateImageCommand(id, patchDoc);
            return await mediator.Send(command);
        }

        [HttpDelete, Route(nameof(DeleteImage)+"/{id}")]
        public async Task DeleteImage([FromRoute]long id)
        {
            var command = new DeleteImageCommand(id);
            await mediator.Send(command);
        }
        #endregion
        #endregion

        #region Get
        [HttpGet, Route(nameof(GetAllCountries))]
        public async Task<ICollection<Country>> GetAllCountries()
        {
            var query = new GetAllCountriesQuery();
            return await mediator.Send(query);
        }

        [HttpGet, Route(nameof(GetAllBrands))]
        public async Task<ICollection<Brand>> GetAllBrands()
        {
            var query = new GetAllBransQuery();
            return await mediator.Send(query);
        }

        [HttpGet, Route(nameof(GetAllImages))]
        public async Task<ICollection<Image>> GetAllImages()
        {
            var query = new GetAllImagesQuery();
            return await mediator.Send(query);
        }

        [HttpGet, Route(nameof(GetAllColors))]
        public async Task<ICollection<Color>> GetAllColors()
        {
            var query = new GetAllColorsQuery();
            return await mediator.Send(query);
        }
        #endregion
    }
}
