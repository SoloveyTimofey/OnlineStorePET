using ManagementApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.Services.Repositories.Interfaces
{
    public interface IJwtStorageManager
    {
        bool CheckIfTokenExpired();
        void SaveToken(JwtTokenData jwtTokenData);
        JwtTokenData GetToken();
    }
}
