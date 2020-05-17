using System.Threading.Tasks;
using zuzudemo.Models;

namespace zuzudemo.Services.Contracts
{
    public interface IWeatherStackService
    {
        Task<WeatherModel> GetCurrentWeatherForLocation(string location);

        Task<WeatherModel> GetHistoricalWeatherForLocation(string location, string date);

        Task<WeatherModel> GetForecastWeatherForLocation(string location, string days);
    }
}