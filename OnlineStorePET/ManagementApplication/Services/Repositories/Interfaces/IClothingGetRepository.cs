using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreDataModels.Clothes;
using System.Threading.Tasks;
using System.Net;

namespace ManagementApplication.Services.Repositories.Interfaces
{
    public interface IClothingGetRepository
    {
        Task<(ICollection<Clothing>, HttpStatusCode)> GetAllClothesAsync();
        Task<(ICollection<ClothingCategory>, HttpStatusCode)> GetAllClothingCategoriesAsync();
        Task<(ICollection<ClothingSize>, HttpStatusCode)> GetAllClothingSizesAsync();
        Task<(ICollection<Fit>, HttpStatusCode)> GetAllFitsAsync();
        Task<(ICollection<SleeveLenght>, HttpStatusCode)> GetAllSleeveLenghtsAsync();
    }
}
