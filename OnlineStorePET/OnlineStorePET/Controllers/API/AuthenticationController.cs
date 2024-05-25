using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StoreDataModels.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace OnlineStorePET.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private SignInManager<IdentityUser> SignInManager;
        private UserManager<IdentityUser> UserManager;
        private IConfiguration Configuration;

        public AuthenticationController(SignInManager<IdentityUser> SignInManager, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            this.SignInManager = SignInManager;
            UserManager = userManager;
            Configuration = configuration;
        }

        [HttpPost]
        [Route(nameof(SignIn))]
        public async Task<object> SignIn([FromBody] SignInCredentials credentials)
        {
            IdentityUser? user = await UserManager.FindByNameAsync(credentials.Username);
            if (user != null)
            {
                //This code checks if the password of given user is valide without signing in
                Microsoft.AspNetCore.Identity.SignInResult result = await SignInManager.CheckPasswordSignInAsync(user, credentials.Password, true);
                if (result.Succeeded)
                {
                    SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
                    {
                        Subject = (await SignInManager.CreateUserPrincipalAsync(user)).Identities.First(),
                        Expires = DateTime.Now.AddHours(int.Parse(Configuration["BearerTokens:ExpiryHours"]!)),
                        SigningCredentials = new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["BearerTokens:Key"]!)), SecurityAlgorithms.HmacSha256Signature)
                    };
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    SecurityToken securityToken;
                    try
                    {
                        securityToken = new JwtSecurityTokenHandler().CreateToken(descriptor);
                    }
                    catch (Exception ex)
                    {
                        await Console.Out.WriteLineAsync(ex.Message);
                        throw;
                    }

                    return new { success = true, token = handler.WriteToken(securityToken), ExpiresAt = DateTime.Now.Add(TimeSpan.FromHours(int.Parse(Configuration["BearerTokens:ExpiryHours"]!))) };
                }
            }

            return new { success = false };
        }

        //[HttpPost("SignOut")]
        //public async Task<IActionResult> ApiSignOut()
        //{
        //    await SignInManager.SignOutAsync();
        //    return Ok();
        //}
    }
}
