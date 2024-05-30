using Microsoft.EntityFrameworkCore;
using OnlineStorePET.Models.Database;
using Microsoft.AspNetCore.Identity;
using OnlineStorePET.Extensions;
using OnlineStorePET.Models.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using System.Reflection;
using Newtonsoft.Json;
using OnlineStorePET.Services.Implementations.Repositories;
using MediatR;
using OnlineStorePET.Services.Interfaces.Repositories;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
}).AddNewtonsoftJson();

builder.Services.AddScoped<IGeneralActionRepository, GeneralRepository>();
builder.Services.AddScoped<IGeneralGetRepository, GeneralRepository>();
builder.Services.AddScoped<IShoeActionRepository, ShoeRepository>();
builder.Services.AddScoped<IShoeGetRepository, ShoeRepository>();
builder.Services.AddScoped<IClothingActionRepository, ClothingRepository>();
builder.Services.AddScoped<IClothingGetRepository, ClothingRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

builder.Services.AddDbContext<OnlineStoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
});
 
builder.Services.AddDbContext<OnlineStoreIdentityContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:OnlineStoreIdentityConnection"]);
});
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<OnlineStoreIdentityContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
});

builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.Events.DisableRedirectionForApiClients();
});

builder.Services.AddAuthentication()
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.TokenValidationParameters.ValidateAudience = false;
    options.TokenValidationParameters.ValidateIssuer = false;
    options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["BearerTokens:Key"]!));
});

var app = builder.Build();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

//app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
