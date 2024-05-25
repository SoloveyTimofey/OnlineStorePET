using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementApplication.Models;
using Newtonsoft.Json;
using ManagementApplication.StaticFiles;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Net.Http;
using ManagementApplication.Services.Repositories.Interfaces;

namespace ManagementApplication.Services.Repositories.Repositories
{
    public class JwtStorageManager : IJwtStorageManager
    {
        private readonly HttpClient httpClient;
        public JwtStorageManager(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public bool CheckIfTokenExpired()
        {
            string json = File.ReadAllText(Paths.JwtTokePath);

            EncryptedJwtTokenData encryptedJwtTokenData = JsonConvert.DeserializeObject<EncryptedJwtTokenData>(json)!;

            if (json == null)
            {
                throw new ArgumentNullException(json);
            }

            JwtTokenData decryptedJwtTokenData = new JwtTokenData
            {
                Token = DecryptToken(encryptedJwtTokenData.TokenBytes),
                ExpiresAt = encryptedJwtTokenData.ExpiresAt,
            };

            if (decryptedJwtTokenData.ExpiresAt.Ticks > DateTime.Now.Ticks)
            {
                SetDefaultAuthoriationHeader(decryptedJwtTokenData.Token);
                return false;
            }
            else
            {
                return true;
            }
        }

        public JwtTokenData GetToken()
        {
            string json = File.ReadAllText(Paths.JwtTokePath);

            if (json == null)
            {
                throw new ArgumentNullException(json);
            }

            EncryptedJwtTokenData encryptedJwtTokenData = JsonConvert.DeserializeObject<EncryptedJwtTokenData>(json)!;

            string decryptedToken = DecryptToken(encryptedJwtTokenData.TokenBytes);
            SetDefaultAuthoriationHeader(decryptedToken);

            return new JwtTokenData
            {
                Token = DecryptToken(encryptedJwtTokenData.TokenBytes),
                ExpiresAt = encryptedJwtTokenData.ExpiresAt
            };
        }

        public void SaveToken(JwtTokenData jwtTokenData)
        {
            EncryptedJwtTokenData encryptedJwtTokenData = new EncryptedJwtTokenData
            {
                TokenBytes = EncryptToken(jwtTokenData.Token),
                ExpiresAt = jwtTokenData.ExpiresAt
            };

            string json = JsonConvert.SerializeObject(encryptedJwtTokenData);

            File.WriteAllText(Paths.JwtTokePath, json);

            SetDefaultAuthoriationHeader(jwtTokenData.Token);
        }

        private byte[] EncryptToken(string token)
        {
            byte[] tokenBytes = Encoding.UTF8.GetBytes(token);

            byte[] encryptedToken = ProtectedData.Protect(tokenBytes, null, DataProtectionScope.CurrentUser);

            return encryptedToken;
        }

        private string DecryptToken(byte[] encryptedToken)
        {
            byte[] decryptedTokenBytes = ProtectedData.Unprotect(encryptedToken, null, DataProtectionScope.CurrentUser);

            string decryptedToken = Encoding.UTF8.GetString(decryptedTokenBytes);

            return decryptedToken;
        }

        private void SetDefaultAuthoriationHeader(string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
    }
}
