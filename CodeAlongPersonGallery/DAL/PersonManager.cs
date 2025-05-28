using System.Text.Json;

namespace CodeAlongPersonGallery.DAL
{
    public class PersonManager
    {

        private static Uri BaseAdress = new Uri("https://localhost:7008/");

        public static async Task<List<Models.Person>> GetAllPersons()
        {
            List<Models.Person> persons = new();

            using (var client = new HttpClient()) 
            {
                client.BaseAddress = BaseAdress;

                HttpResponseMessage response = await client.GetAsync("api/Person");

                if (response.IsSuccessStatusCode)
                {

                    string responseString = await response.Content.ReadAsStringAsync();
                    persons = JsonSerializer.Deserialize<List<Models.Person>>(responseString);


                }

                return persons;


            }





            
        }
    }
}
