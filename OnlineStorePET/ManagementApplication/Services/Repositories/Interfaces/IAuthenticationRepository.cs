using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ManagementApplication.Models;
using StoreDataModels.Identity;

namespace ManagementApplication.Services.Repositories.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<JwtResponse> SignInAsync(SignInCredentials signInCredentials);
    }
}
