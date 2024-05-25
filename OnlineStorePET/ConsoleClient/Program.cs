using System.Net;
using System.Security.Cryptography;
using System.Net.Http.Json;
using Newtonsoft.Json;
using StoreDataModels.Identity;

//Tests.PostTest();

//Tests.GetTest();

Tests.GetCountriesTest();

AuthorizationResponce authorizationResponce1 = await Tests.AuthorizationTest();

Tests.GetTest(authorizationResponce1);

Console.ReadLine();

static class Tests
{
    public static async Task<AuthorizationResponce> AuthorizationTest()
    {
        using (HttpClient client  = new HttpClient())
        {
            string apiUrl = "http://localhost:5041/api/Authentication/SignIn";

            HttpResponseMessage responce = await client.PostAsJsonAsync(apiUrl, new SignInCredentials { Password = "adminSecret", Username = "admin1" });

            AuthorizationResponce resp = JsonConvert.DeserializeObject<AuthorizationResponce>(await responce.Content.ReadAsStringAsync())!;
            resp.token = String.Concat("Bearer ", resp.token);

            return resp;        
        }
    }

    public static async void GetCountriesTest()
    {
        using (HttpClient client = new HttpClient())
        {
            string apiUrl = "http://localhost:5041/api/General/GetAllCountries";

            HttpResponseMessage responce = await client.GetAsync(apiUrl);

            await Console.Out.WriteLineAsync("Headers: " + responce.RequestMessage.Headers.ToString() ?? "empty string");
            await Console.Out.WriteLineAsync("StatusCode: " + responce.StatusCode);
            await Console.Out.WriteLineAsync(await responce.Content.ReadAsStringAsync());
        }
    }

    public static async void GetTest(AuthorizationResponce authorizationResponce)
    {
        using (HttpClient client = new HttpClient())
        {
            string apiUrl = "http://localhost:5041/api/Home/GetShoeSize/1";

            client.DefaultRequestHeaders.Add("Authorization", authorizationResponce.token);

            HttpResponseMessage responce = await client.GetAsync(apiUrl);

            await Console.Out.WriteLineAsync("Headers: "+ responce.RequestMessage.Headers.ToString()??"empty string");
            await Console.Out.WriteLineAsync("StatusCode: "+ responce.StatusCode);
            await Console.Out.WriteLineAsync(await responce.Content.ReadAsStringAsync());
        }
    }

    public static void PostTest()
    {
        using (HttpClient client = new HttpClient())
        {
            string apiUrl = "http://localhost:5041/api/Authentication/SignIn";            

            client.PostAsync("http://localhost:5041/api/Authentication/SignOut", null);

            try
            {
                SignInCredentials credentials = new SignInCredentials()
                {
                    Password = "adminSecret",
                    Username = "admin1"
                };
                HttpResponseMessage response = client.PostAsJsonAsync(apiUrl, credentials).Result;

                string responseBody = response.Content.ReadAsStringAsync().Result;

                Console.WriteLine(responseBody);

                HttpStatusCode statusCode = response.StatusCode;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

public record AuthorizationResponce
{
    public bool? success;
    public string? token;
}