using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieApi.Data.Entities;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace dotnet_movie_api_client.Pages.moviePage
{
    public class castModel : PageModel
    {
        public List<Cast> casts = new List<Cast>();
        public string movieName;

        public async Task<IActionResult> OnGet()
        {
            var movieId = Request.Query["id"];
            movieName = Request.Query["name"];
            await makeRequest(movieId);
            return Page();
        }
        public async Task makeRequest(string id)
        {
            string baseUrl = "https://localhost:7245/Casts/" + id;

            HttpClient client = new HttpClient();

            using HttpResponseMessage response = await client.GetAsync(baseUrl);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            casts = JsonConvert.DeserializeObject<List<Cast>>(responseBody);
        }
    }
}
