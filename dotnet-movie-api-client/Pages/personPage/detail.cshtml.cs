using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieApi.Data.Entities;
using Newtonsoft.Json;

namespace dotnet_movie_api_client.Pages.personPage
{
    public class detailModel : PageModel
    {
        public Person person = new Person();
        public async Task<IActionResult> OnGetAsync()
        {
            var personId = Request.Query["id"];
            await makeRequest(personId);
            return Page();
        }
        public async Task makeRequest(string id)
        {
            string baseUrl = "https://localhost:7245/Person/db/" + id;

            HttpClient client = new HttpClient();

            using HttpResponseMessage response = await client.GetAsync(baseUrl);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            person = JsonConvert.DeserializeObject<Person>(responseBody);
        }
    }
}
