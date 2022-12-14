using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_movie_api_client.Pages
{
    public class searchModel : PageModel
    {
        public void OnGet()
        {
        }
       
        public IActionResult SearchMovie(IFormCollection data)
        {
            Console.WriteLine("Geldim");
            Console.WriteLine(data["txtMovie"]);
            return Page();
        }

    }
}
