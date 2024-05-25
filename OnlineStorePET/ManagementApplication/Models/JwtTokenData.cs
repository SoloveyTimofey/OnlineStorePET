using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.Models
{
    public class JwtTokenData
    {
        public string Token { get; set; } = String.Empty;
        public DateTime ExpiresAt { get; set; }
    }

    public class EncryptedJwtTokenData
    {
        public byte[] TokenBytes { get; set; } = [];
        public DateTime ExpiresAt { get; set; }
    }

    public class JwtResponse : JwtTokenData 
    {
        public bool Success;
    }
}
