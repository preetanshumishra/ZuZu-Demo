using System.Net.Http;

namespace zuzudemo.Services.Contracts
{
    public interface IHttpClientProvider
    {
        HttpClient GetClient();
    }
}