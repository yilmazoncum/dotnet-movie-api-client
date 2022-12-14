using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieApi.Data.Entities;
using Newtonsoft.Json;

namespace dotnet_movie_api_client.Pages.personPage
{
    public class filmographyModel : PageModel
    {
        public List<Filmography> filmos = new List<Filmography>();
        public string personName;
        public async Task<IActionResult> OnGet()
        {
            var personId = Request.Query["id"];
            personName = Request.Query["name"];
            await makeRequest(personId);
            return Page();
        }
        public async Task makeRequest(string id)
        {
            string baseUrl = "https://localhost:7245/Filmography/" + id;

            HttpClient client = new HttpClient();

            using HttpResponseMessage response = await client.GetAsync(baseUrl);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            filmos = JsonConvert.DeserializeObject<List<Filmography>>(responseBody);
        }

    }
}
