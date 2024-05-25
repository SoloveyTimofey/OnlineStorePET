using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using OnlineStorePET.Models.Database;
using OnlineStorePET.Services.Interfaces.Repositories;
using StoreDataModels.DTO;
using StoreDataModels.DTO.Infrastructure;
using StoreDataModels.Shoes;

namespace OnlineStorePET.Services.Implementations.Repositories
{
    public class ShoeRepository : IShoeActionRepository, IShoeGetRepository
    {
        private readonly OnlineStoreDbContext context;
        public ShoeRepository(OnlineStoreDbContext context)
        {
            this.context = context;
        }

        #region Action
        #region Shoe
        public async Task<Shoe> CreateShoeAsync(ShoeDTO shoe)
        {
            Shoe s = DTOMapper.MapFromDTO<ShoeDTO, Shoe>(shoe);
            await context.Shoes.AddAsync(s);
            await context.SaveChangesAsync();

            return context.Entry(s).Entity;
        }

        public async Task<Shoe> UpdateShoeAsync(long id, JsonPatchDocument<Shoe> patchDoc)
        {
            Shoe? s = await context.Shoes.FindAsync(id);
            if (s != null)
            {
                patchDoc.ApplyTo(s);
                await context.SaveChangesAsync();
                return s;
            }
            throw new ArgumentException($"Shoe with Id {id} was not found.");
        }

        public async Task DeleteShoeAsync(long id)
        {
            Shoe s = await context.Shoes.FirstAsync(sh=>sh.Id == id);
            context.Shoes.Remove(s);
            await context.SaveChangesAsync();
        }
        #endregion

        #region ShoeCategory
        public async Task<ShoeCategory> CreateShoeCategoryAsync(ShoeCategoryDTO shoeCategory)
        {
            ShoeCategory sc = DTOMapper.MapFromDTO<ShoeCategoryDTO, ShoeCategory>(shoeCategory);
            await context.ShoeCategories.AddAsync(sc);
            await context.SaveChangesAsync();

            return context.Entry(sc).Entity;
        }

        public async Task<ShoeCategory> UpdateShoeCategoryAsync(long id, JsonPatchDocument<ShoeCategory> patchDoc)
        {
            ShoeCategory? sc = await context.ShoeCategories.FindAsync(id);
            if (sc != null)
            {
                patchDoc.ApplyTo(sc);
                await context.SaveChangesAsync();
                return sc;
            }
            throw new ArgumentException($"Shoe category with Id {id} was not found.");
        }

        public async Task DeleteShoeCategoryAsync(long id)
        {
            ShoeCategory sc = await context.ShoeCategories.FirstAsync(sc=>sc.Id == id);
            context.ShoeCategories.Remove(sc);
            await context.SaveChangesAsync();
        }
        #endregion

        #region ShoeSize
        public async Task<ShoeSize> CreateShoeSizeAsync(ShoeSizeDTO shoeSize)
        {
            ShoeSize ss = DTOMapper.MapFromDTO<ShoeSizeDTO, ShoeSize>(shoeSize);
            await context.ShoeSizes.AddAsync(ss);
            await context.SaveChangesAsync();

            return context.Entry(ss).Entity;
        }

        public async Task<ShoeSize> UpdateShoeSizeAsync(long id, JsonPatchDocument<ShoeSize> patchDoc)
        {
            ShoeSize? ss = await context.ShoeSizes.FindAsync(id);
            if (ss != null)
            {
                patchDoc.ApplyTo(ss);
                await context.SaveChangesAsync();
                return ss;
            }
            throw new ArgumentException($"Country with Id {id} was not found.");
        }

        public async Task DeleteShoeSizeAsync(long id)
        {
            ShoeSize ss = await context.ShoeSizes.FirstAsync(ss=>ss.Id == id);
            context.ShoeSizes.Remove(ss);
            await context.SaveChangesAsync();
        }
        #endregion

        #region ShoeSizeJunc
        public async Task<ShoeSizeJunction> AddSizeToShoeAsync(ShoeSizeJunctionDTO shoeSizeJunction)
        {
            ShoeSizeJunction ssj = DTOMapper.MapFromDTO<ShoeSizeJunctionDTO, ShoeSizeJunction>(shoeSizeJunction); 
            await context.ShoeSizeJunctions.AddAsync(ssj);
            await context.SaveChangesAsync();

            return context.Entry(ssj).Entity;
        }
        public async Task RemoveSizeFromShoeAsync(long junctionId)
        {
            ShoeSizeJunction ssj = await context.ShoeSizeJunctions.FirstAsync(x => x.Id == junctionId);
            context.ShoeSizeJunctions.Remove(ssj);
            await context.SaveChangesAsync();
        }
        #endregion

        #endregion

        #region Get
        public async Task<IQueryable<Shoe>> GetAllShoesAsync()
        {
            return await Task.FromResult(context.Shoes
                .Include(s => s.Sizes)
                .Include(s => s.Color)
                );
        }

        public async Task<IQueryable<ShoeCategory>> GetAllShoeCategoriesAsync()
        {
            return await Task.FromResult(context.ShoeCategories
                .Include(sc=>sc.Shoes));
        }

        public async Task<IQueryable<ShoeSize>> GetAllShoeSizesAsync()
        {
            return await Task.FromResult(
                context.ShoeSizes.Include(ss => ss.ShoeSizeJunctions).ThenInclude(ssj=>ssj.Shoe)
                .ThenInclude(ssj=>ssj.ShoeSizeJunctions).ThenInclude(ssj=>ssj.ShoeSize));
        }
        #endregion
    }
}
