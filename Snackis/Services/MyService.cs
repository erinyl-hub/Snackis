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
    }
}
