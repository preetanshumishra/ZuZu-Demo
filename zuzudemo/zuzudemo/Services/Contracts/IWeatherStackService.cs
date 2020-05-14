using System.Threading.Tasks;
using zuzudemo.Models;

namespace zuzudemo.Services.Contracts
{
    public interface IWeatherStackService
    {
        Task<CurrentWeatherModel> GetCurrentWeatherForLocation(string location);

        Task<CurrentWeatherModel> GetHistoricalWeatherForLocation(string location, string date);

        Task<CurrentWeatherModel> GetForecastWeatherForLocation(string location, string days);
    }
}