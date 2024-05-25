using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using OnlineStorePET.Migrations;
using OnlineStorePET.Models.Database;
using OnlineStorePET.Services.Interfaces.Repositories;
using StoreDataModels.Clothes;
using StoreDataModels.DTO;
using StoreDataModels.DTO.Infrastructure;
using System.Security.Claims;
using StoreDataModels;

namespace OnlineStorePET.Services.Implementations.Repositories
{
    public class ClothingRepository : IClothingActionRepository, IClothingGetRepository
    {
        private readonly OnlineStoreDbContext context;
        public ClothingRepository(OnlineStoreDbContext context)
        {
            this.context = context;
        }

        #region Action
        #region Clothing
        public async Task<Clothing> CreateClothingAsync(ClothingDTO clothing)
        {
            Clothing c = DTOMapper.MapFromDTO<ClothingDTO, Clothing>(clothing);

            Image? image = null;
            if (clothing?.ImageBytes?.Length>0)
            {
                image = new Image
                {
                    Description = clothing.Name,
                    ImageBytes = clothing.ImageBytes
                };

                await context.Images.AddAsync(image);

                await context.SaveChangesAsync();
                image = context.Entry(image).Entity;
            }

            if (image!=null)
            {
                c.ImageId = image.Id;
            }

            await context.Clothes.AddAsync(c);
            await context.SaveChangesAsync();

            return context.Entry(c).Entity;
        }

        public async Task<Clothing> UpdateClothingAsync(long id, JsonPatchDocument<Clothing> patchDoc)
        {
            Clothing? c = await context.Clothes.FindAsync(id);
            if (c!=null)
            {
                patchDoc.ApplyTo(c);
                await context.SaveChangesAsync();
                return c;
            }
            throw new ArgumentException($"Clothing with Id {id} was not found.");
        }

        public async Task DeleteClothingAsync(long id)
        {
            Clothing c = await context.Clothes.FirstAsync(cl => cl.Id == id);
            context.Clothes.Remove(c);
            await context.SaveChangesAsync();
        }
        #endregion

        #region ClothingCategory
        public async Task<ClothingCategory> CreateClothingCategoryAsync(ClothingCategoryDTO clothingCategory)
        {
            ClothingCategory ct = DTOMapper.MapFromDTO<ClothingCategoryDTO, ClothingCategory>(clothingCategory);
            await context.ClothingCategories.AddAsync(ct);
            await context.SaveChangesAsync();

            return context.Entry(ct).Entity;
        }
        public async Task<ClothingCategory> UpdateClothingCategoryAsync(long id, JsonPatchDocument<ClothingCategory> patchDoc)
        {
            ClothingCategory? ct = await context.ClothingCategories.FindAsync(id);
            if (ct != null)
            {
                patchDoc.ApplyTo(ct);
                await context.SaveChangesAsync();
                return ct;
            }
            throw new ArgumentException($"Clothing category with Id {id} was not found.");
        }

        public async Task DeleteClothingCategoryAsync(long id)
        {
            ClothingCategory ct = await context.ClothingCategories.FirstAsync(clCt => clCt.Id == id);
            context.ClothingCategories.Remove(ct);
            await context.SaveChangesAsync();
        }
        #endregion

        #region SleeveLenght
        public async Task<SleeveLenght> CreateSleeveLenghtAsync(SleeveLenghtDTO sleeveLenght)
        {
            SleeveLenght sl = DTOMapper.MapFromDTO<SleeveLenghtDTO, SleeveLenght>(sleeveLenght);
            await context.SleeveLenghts.AddAsync(sl);
            await context.SaveChangesAsync();

            return context.Entry(sl).Entity;
        }
        public async Task<SleeveLenght> UpdateSleeveLenghtAsync(long id, JsonPatchDocument<SleeveLenght> patchDoc)
        {
            SleeveLenght? s = await context.SleeveLenghts.FindAsync(id);
            if (s!=null)
            {
                patchDoc.ApplyTo(s);
                await context.SaveChangesAsync();
            }
            throw new ArgumentException($"Sleeve lenght with Id {id} was not found.");
        }
        public async Task DeleteSleeveLenghtAsync(long id)
        {
            SleeveLenght sl = await context.SleeveLenghts.FirstAsync(sl=>sl.Id == id);
            context.SleeveLenghts.Remove(sl);
            await context.SaveChangesAsync();
        }
        #endregion

        #region Fit
        public async Task<Fit> CreateFitAsync(FitDTO fit)
        {
            Fit f = DTOMapper.MapFromDTO<FitDTO, Fit>(fit);
            await context.Fits.AddAsync(f);
            await context.SaveChangesAsync();

            return context.Entry(f).Entity;
        }

        public async Task<Fit> UpdateFitAsync(long id, JsonPatchDocument<Fit> patchDoc)
        {
            Fit? f = await context.Fits.FindAsync(id);
            if (f!=null)
            {
                patchDoc.ApplyTo(f);
                await context.SaveChangesAsync();
                return f;
            }
            throw new ArgumentException($"Fit with Id {id} was not found.");
        }
        public async Task DeleteFitAsync(long id)
        {
            Fit f = await context.Fits.FirstAsync(ft=>ft.Id==id);
            context.Fits.Remove(f);
            await context.SaveChangesAsync();
        }
        #endregion

        #region ClothingSize
        public async Task<ClothingSize> CreateClothingSizeAsync(ClothingSizeDTO clothingSize)
        {
            ClothingSize cs = DTOMapper.MapFromDTO<ClothingSizeDTO, ClothingSize>(clothingSize);
            await context.ClothingSizes.AddAsync(cs);
            await context.SaveChangesAsync();

            return context.Entry(cs).Entity;
        }
        public async Task<ClothingSize> UpdateClothingSizeAsync(long id, JsonPatchDocument<ClothingSize> patchDoc)
        {
            ClothingSize? cs = await context.ClothingSizes.FindAsync(id);
            if (cs!=null)
            {
                patchDoc.ApplyTo(cs);
                await context.SaveChangesAsync();
                return cs;
            }
            throw new ArgumentException($"Clothing size with Id {id} was not found.");
        }
        public async Task DeleteClothingSizeAsync(long id)
        {
            ClothingSize cs = await context.ClothingSizes.FirstAsync(clSi=>clSi.Id==id);
            context.ClothingSizes.Remove(cs);
            await context.SaveChangesAsync();
        }
        #endregion

        #region ClothingSizeJunc
        public async Task<ClothingSizeJunction> AddSizeToClothingAsync(ClothingSizeJunctionDTO clothingSizeJunction)
        {
            ClothingSizeJunction csj = DTOMapper.MapToDTO<ClothingSizeJunctionDTO, ClothingSizeJunction>(clothingSizeJunction);
            await context.ClothingSizeJunctions.AddAsync(csj);
            await context.SaveChangesAsync();

            return context.Entry(csj).Entity;
        }

        public async Task<IEnumerable<ClothingSizeJunction>> AddRangeSizeToClothingAsync(IEnumerable<ClothingSizeJunctionDTO> clothingSizeJunctions)
        {
            List<ClothingSizeJunction> csjs = new List<ClothingSizeJunction>();
            foreach (ClothingSizeJunctionDTO csj in clothingSizeJunctions)
            {
                csjs.Add(DTOMapper.MapFromDTO<ClothingSizeJunctionDTO, ClothingSizeJunction>(csj));
            }

            await context.ClothingSizeJunctions.AddRangeAsync(csjs);
            await context.SaveChangesAsync();
            
            return csjs;
        }
        public async Task RemoveSizeFromClothingAsync(long id)
        {
            ClothingSizeJunction csj = await context.ClothingSizeJunctions.FirstAsync(x => x.Id == id);
            context.ClothingSizeJunctions.Remove(csj);
            await context.SaveChangesAsync();
        }
        #endregion
        #endregion

        #region Get
        public async Task<IQueryable<Clothing>> GetAllClothesAsync()
        {
            return await Task.FromResult(context.Clothes);
        }

        public async Task<IQueryable<ClothingCategory>> GetAllClothingCategoriesAsync()
        {
            return await Task.FromResult(context.ClothingCategories);
        }

        public async Task<IQueryable<ClothingSize>> GetAllClothingSizesAsync()
        {
            return await Task.FromResult(context.ClothingSizes);
        }

        public async Task<IQueryable<Fit>> GetAllFitsAsync()
        {
            return await Task.FromResult(context.Fits);
        }

        public async Task<IQueryable<SleeveLenght>> GetAllSleeveLenghtsAsync()
        {
            return await Task.FromResult(context.SleeveLenghts);
        }
        #endregion
    }
}
