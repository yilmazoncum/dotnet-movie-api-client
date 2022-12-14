using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieApi.Data.Entities;
using Newtonsoft.Json;

namespace dotnet_movie_api_client.Pages.moviePage
{
    public class listModel : PageModel
    {
        public List<Movie> movies= new List<Movie>();
        public async Task<IActionResult> OnGetAsync()
        {
            await makeRequest();
            return Page();
        }
        public async Task makeRequest()
        {
            string baseUrl = "https://localhost:7245/Movies/list";

            HttpClient client = new HttpClient();

            using HttpResponseMessage response = await client.GetAsync(baseUrl);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            movies = JsonConvert.DeserializeObject<List<Movie>>(responseBody);
        }
    }
}
