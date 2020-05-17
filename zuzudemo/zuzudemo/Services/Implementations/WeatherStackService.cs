using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using zuzudemo.Constants;
using zuzudemo.Models;
using zuzudemo.Services.Contracts;

namespace zuzudemo.Services.Implementations
{
    public class WeatherStackService : IWeatherStackService
    {
        private HttpClient GetRequest(string url)
        {
            HttpClient client = DependencyService.Resolve<IHttpClientProvider>().GetClient();

            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public async Task<WeatherModel> GetCurrentWeatherForLocation(string location)
        {
            HttpClient client = GetRequest(AppConstants.WeatherStackBaseUrl);

            var queryParams = $"current?access_key={AppConstants.WeatherStackAccessKey}&query={location}";

            var httpMessage = new HttpRequestMessage(HttpMethod.Get, AppConstants.WeatherStackBaseUrl + queryParams);

            HttpResponseMessage response = await client.SendAsync(httpMessage, default(CancellationToken));
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<WeatherModel>(responseContent);
                return result;
            }
            else
            {
                Console.WriteLine("Api Error");
            }

            return null;
        }

        public async Task<WeatherModel> GetHistoricalWeatherForLocation(string location, string date)
        {
            HttpClient client = GetRequest(AppConstants.WeatherStackBaseUrl);

            var queryParams = $"historical?access_key={AppConstants.WeatherStackAccessKey}&query={location}&historical_date={date}";

            var httpMessage = new HttpRequestMessage(HttpMethod.Get, AppConstants.WeatherStackBaseUrl + queryParams);

            HttpResponseMessage response = await client.SendAsync(httpMessage, default(CancellationToken));
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<WeatherModel>(responseContent);
                return result;
            }
            else
            {
                Console.WriteLine("Api Error");
            }

            return null;
        }

        public async Task<WeatherModel> GetForecastWeatherForLocation(string location, string days)
        {
            HttpClient client = GetRequest(AppConstants.MockBaseUrl);

            var queryParams = $"forecast?access_key={AppConstants.WeatherStackAccessKey}&query={location}&forecast_days={days}";

            var httpMessage = new HttpRequestMessage(HttpMethod.Get, AppConstants.MockBaseUrl + queryParams);

            HttpResponseMessage response = await client.SendAsync(httpMessage, default(CancellationToken));
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<WeatherModel>(responseContent);
                return result;
            }
            else
            {
                Console.WriteLine("Api Error");
            }

            return null;
        }
    }
}