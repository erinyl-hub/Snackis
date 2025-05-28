using System.Text.Json;

namespace CodeAlongKassabokRazor.DAL
{
    public class TransactionAPIManager
    {
        private static Uri BaseAdress = new Uri("https://localhost:44328/");

        public static async Task<List<Models.Transaction>> GetAllTransactions()
        {
            List<Models.Transaction> transactions = new();

            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAdress;
                HttpResponseMessage response = await client.GetAsync("api/Transaction");
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    transactions = JsonSerializer.Deserialize<List<Models.Transaction>>(responseString);

                }
                return transactions;
            }
        }

        public static async Task<Models.Transaction> GetTransaction(int id)
        {
            Models.Transaction transaction = new Models.Transaction();

            using (var client = new HttpClient())
            {
                client.BaseAddress= BaseAdress;
                HttpResponseMessage response = await client.GetAsync("api/Transaction/" + id);
                if (response.IsSuccessStatusCode)
                {
                    string responsString = await response.Content.ReadAsStringAsync();
                    transaction = JsonSerializer.Deserialize<Models.Transaction>(responsString);
                }

                return transaction;
            }
        }

        public static async Task SaveTransaction(Models.Transaction transaction)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = BaseAdress;

                var json = JsonSerializer.Serialize(transaction);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json"); // Vad är StringContent?

                HttpResponseMessage response = await client.PostAsync("api/Transaction/", httpContent);
            }
        }


    }
}
