using StoreDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.Services.Repositories.Interfaces
{
    public  interface IGeneralGetRepository
    {
        Task<(ICollection<Country>, HttpStatusCode)> GetAllCountriesAsync();

        Task<(ICollection<Brand>, HttpStatusCode)> GetAllBrandsAsync();

        Task<(ICollection<Image>, HttpStatusCode)> GetAllImagesAsync();

        Task<(ICollection<Color>, HttpStatusCode)> GetAllColorsAsync();
    }
}
