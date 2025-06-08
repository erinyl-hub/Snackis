namespace Snackis.Services
{
    public class MyService
    {
        private readonly HttpClient _httpClient;

        public MyService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("ReportApi");
        }

        public async Task PostReportAsync(Models.Postings.Report report)
        {
            await _httpClient.PostAsJsonAsync("api/report", report);
        }

        public async Task<List<Models.Postings.Report>> GetReportsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Models.Postings.Report>>("api/report");
            return response!;
        }
    }
}
