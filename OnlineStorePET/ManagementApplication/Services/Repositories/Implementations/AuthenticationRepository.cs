using ManagementApplication.Models;
using StoreDataModels.Identity;
using System;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ManagementApplication.Services.Repositories.Interfaces;

namespace ManagementApplication.Services.Implementations.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly HttpClient httpClient;
        private readonly IJwtStorageManager jwtStorageManager;
        public AuthenticationRepository(HttpClient httpClient, IJwtStorageManager jwtStorageManager)
        {
            this.httpClient = httpClient;
            this.jwtStorageManager = jwtStorageManager;
        }
        public async Task<JwtResponse> SignInAsync(SignInCredentials signInCredentials)
        {
            var httpResponse = await httpClient.PostAsJsonAsync("api/Authentication/SignIn", signInCredentials);

            JwtResponse jwtResponse = JsonConvert.DeserializeObject<JwtResponse>(await httpResponse.Content.ReadAsStringAsync())!;

            if (jwtResponse.Success)
            {
                jwtStorageManager.SaveToken(jwtResponse);
            }

            return jwtResponse;
        }
    }
}
