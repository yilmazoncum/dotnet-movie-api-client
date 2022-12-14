using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieApi.Data.Entities;
using Newtonsoft.Json;

namespace dotnet_movie_api_client.Pages.personPage
{
    public class listModel : PageModel
    {
        public List<Person> persons = new List<Person>();
        public async Task<IActionResult> OnGetAsync()
        {
            await makeRequest();
            return Page();

        }


        public async Task makeRequest()
        {
            string baseUrl = "https://localhost:7245/Person/list";

            HttpClient client = new HttpClient();

            using HttpResponseMessage response = await client.GetAsync(baseUrl);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            persons = JsonConvert.DeserializeObject<List<Person>>(responseBody);
        }
    }
}
