using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OnlineStorePET.Models.Identity
{
    public class OnlineStoreIdentityContext : IdentityDbContext<IdentityUser>
    {
        public OnlineStoreIdentityContext(DbContextOptions<OnlineStoreIdentityContext> options) : base(options){ }
    }
}
