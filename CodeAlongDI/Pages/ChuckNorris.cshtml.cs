using CodeAlongDI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CodeAlongDI.Pages
{
    public class ChuckNorrisModel : PageModel
    {
        private readonly HttpClient _client;

        public Joke Joke { get; set; }

        public ChuckNorrisModel(HttpClient client)
        {
            _client = client;
        }
        public async Task OnGetAsync()
        {
            _client.BaseAddress = new Uri("https://api.chucknorris.io/");
            HttpResponseMessage response = await _client.GetAsync("jokes/random");
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                Joke = JsonSerializer.Deserialize<Models.Joke>(responseString);
            }

        }
    }
}
