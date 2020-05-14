using System.Threading.Tasks;
using zuzudemo.Models;

namespace zuzudemo.Services.Contracts
{
    public interface IWeatherStackService
    {
        Task<LocationModel> GetWeatherForLocation(string location);
    }
}