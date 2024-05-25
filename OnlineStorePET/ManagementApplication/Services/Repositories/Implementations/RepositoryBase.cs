using Newtonsoft.Json;
using StoreDataModels.Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.Services.Repositories.Implementations
{
    public abstract class RepositoryBase
    {
        public async Task<(TResult, HttpStatusCode)> HandleResponse<TResult>(Func<Task<HttpResponseMessage>> action)
        {
            HttpResponseMessage? response = await action();

            string respString = await response.Content.ReadAsStringAsync();

            TResult resultEntityFromResp = JsonConvert.DeserializeObject<TResult>(respString) ?? Activator.CreateInstance<TResult>();

            return (resultEntityFromResp, response.StatusCode);
        }

    }
}
