using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieApi.Data.Entities;
using Newtonsoft.Json;

namespace dotnet_movie_api_client.Pages.moviePage
{
    public class detailModel : PageModel
    {
        public Movie movie = new Movie();

        public async Task<IActionResult> OnGetAsync()
        {
            var movieId = Request.Query["id"];
            await makeRequest(movieId);
            return Page();
        }

        public async Task makeRequest(string id)
        {
            string baseUrl = "https://localhost:7245/Movies/db/" + id;

            HttpClient client = new HttpClient();

            using HttpResponseMessage response = await client.GetAsync(baseUrl);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            movie = JsonConvert.DeserializeObject<Movie>(responseBody);
        }
    }
}
