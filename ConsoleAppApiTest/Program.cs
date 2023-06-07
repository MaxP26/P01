using System.Net;

namespace ConsoleAppApiTest
{
    internal class Program
    {
        static HttpClient httpClient = new HttpClient();
        static async Task Main(string[] args)
        {
            var uh = new UriBuilder();
            httpClient.BaseAddress = new Uri("https://localhost:7215");
            double a = 10;
            double b = 30;
            var request = await httpClient.GetAsync($"api/WeatherForecast/Calc?a={a}&b={b}");
            if ( request != null )
            {
                if (request.IsSuccessStatusCode)
                {
                    var s = await request.Content.ReadAsStringAsync();
                }
            }
        }
    }
}