using ManagementApplication.Models;
using ManagementApplication.Services.Repositories.Interfaces;
using StoreDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManagementApplication.Services.Repositories.Proxy
{
    public abstract class ProxyBase
    {
        public TokenExpired tokenExpired;
        public ProxyBase(TokenExpired tokenExpiredHandler)
        {
            this.tokenExpired = tokenExpiredHandler;
        }

        //Templete Method - GoF Pattern
        //RCU means Read, Create, Update
        public async Task<(TResult, HttpStatusCode)> HandleRCUResponseAsync<TResult>(Func<Task<(TResult, HttpStatusCode)>> action)
        {
            var result = await action();

            if (result.Item2 == HttpStatusCode.Unauthorized)
            {
                tokenExpired();
                return result;
            }
            if (result.Item2 != HttpStatusCode.OK)
            {
                MessageBox.Show($"Request ended up with status code {result.Item2}.");
            }

            return result;
        }

        public async Task<HttpStatusCode> HandleDeleteResponseAsync(Func<Task<HttpStatusCode>> action)
        {
            var result = await action();

            if (result == HttpStatusCode.Unauthorized)
            {
                tokenExpired();
                return result;
            }
            if (result != HttpStatusCode.OK)
            {
                MessageBox.Show($"Request ended up with status code {result}.");
            }

            return result;
        }
    }
}
