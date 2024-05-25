using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using OnlineStorePET.Models.Database;
using OnlineStorePET.Services.Interfaces.Repositories;
using StoreDataModels;
using StoreDataModels.DTO;
using StoreDataModels.DTO.Infrastructure;

namespace OnlineStorePET.Services.Implementations.Repositories
{
    public class GeneralRepository : IGeneralActionRepository, IGeneralGetRepository
    {
        private readonly OnlineStoreDbContext context;
        public GeneralRepository(OnlineStoreDbContext context)
        {
            this.context = context;
        }

        #region Action
        #region Country
        public async Task<Country> CreateCountryAsync(CountryDTO country)
        {
            Country c = DTOMapper.MapFromDTO<CountryDTO, Country>(country);
            await context.Countries.AddAsync(c);
            await context.SaveChangesAsync();

            return context.Entry(c).Entity;
        }

        public async Task<Country> UpdateCountryAsync(long id, JsonPatchDocument<Country> patchDoc)
        {
            Country? c = await context.Countries.FindAsync(id);
            if (c!=null)
            {
                patchDoc.ApplyTo(c);
                await context.SaveChangesAsync();
                return c;
            }
            throw new ArgumentException($"Country with Id {id} was not found.");
        }

        public async Task DeleteCountryAsync(long id)
        {
            Country c = await context.Countries.FirstAsync(ctr=>ctr.Id==id);
            context.Countries.Remove(c);
            await context.SaveChangesAsync();
        }
        #endregion

        #region Brand
        public async Task<Brand> CreateBrandAsync(BrandDTO brand)
        {
            Brand b = DTOMapper.MapFromDTO<BrandDTO, Brand>(brand);
            await context.Brands.AddAsync(b);
            await context.SaveChangesAsync();

            return context.Entry(b).Entity;
        }
        public async Task<Brand> UpdateBrandAsync(long id, JsonPatchDocument<Brand> patchDoc)
        {
            Brand? b = await context.Brands.FindAsync(id);
            if (b!=null)
            {
                patchDoc.ApplyTo(b);
                await context.SaveChangesAsync();
                return b;
            }
            throw new ArgumentException($"Brand with Id {id} was not found.");
        }

        public async Task DeleteBrandAsync(long id)
        {
            Brand b = await context.Brands.FirstAsync(brnd=>brnd.Id==id);
            context.Brands.Remove(b);
            await context.SaveChangesAsync();
        }
        #endregion

        #region Color
        public async Task<Color> CreateColorAsync(ColorDTO color)
        {
            Color c = DTOMapper.MapFromDTO<ColorDTO, Color>(color);
            await context.Colors.AddAsync(c);
            await context.SaveChangesAsync();

            return context.Entry(c).Entity;
        }
        public async Task<Color> UpdateColorAsync(long id, JsonPatchDocument<Color> patchDoc)
        {
            Color? c = await context.Colors.FindAsync(id);
            if (c!=null)
            {
                patchDoc.ApplyTo(c);
                await context.SaveChangesAsync();
                return c;
            }
            throw new ArgumentException($"Color with Id {id} was not found.");
        }

        public async Task DeleteColorAsync(long id)
        {
            Color c = await context.Colors.FirstAsync(clr => clr.Id == id);
            context.Colors.Remove(c);
            await context.SaveChangesAsync();
        }
        #endregion

        #region Image
        public async Task<Image> CreateImageAsync(ImageDTO image)
        {
            Image i = DTOMapper.MapFromDTO<ImageDTO, Image>(image);
            await context.Images.AddAsync(i);
            await context.SaveChangesAsync();

            return context.Entry(i).Entity;
        }

        public async Task<Image> UpdateImageAsync(long id, JsonPatchDocument<Image> patchDoc)
        {
            Image? i = await context.Images.FindAsync(id);
            if (i!=null)
            {
                patchDoc.ApplyTo(i);
                await context.SaveChangesAsync();
                return i;
            }
            throw new ArgumentException($"Image with Id {id} was not found.");
        }

        public async Task DeleteImageAsync(long id)
        {
            Image i = await context.Images.FirstAsync(img => img.Id == id);
            context.Images.Remove(i);
            await context.SaveChangesAsync();
        }
        #endregion
        #endregion

        #region Get
        public async Task<IQueryable<Country>> GetAllCountriesAsync()
        {
            return await Task.FromResult(context.Countries
                .Include(c=>c.Brands));
        }

        public async Task<IQueryable<Brand>> GetAllBrandsAsync()
        {
            return await Task.FromResult(context.Brands
                .Include(b=>b.Country));
        }

        public async Task<IQueryable<Image>> GetAllImagesAsync()
        {
            return await Task.FromResult(context.Images
                .Include(i=>i.Items));
        }

        public async Task<IQueryable<Color>> GetAllColorsAsync()
        {
            return await Task.FromResult(context.Colors);
        }
        #endregion
    }
}
