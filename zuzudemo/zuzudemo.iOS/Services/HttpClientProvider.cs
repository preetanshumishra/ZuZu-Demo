using System.Net;
using System.Net.Http;
using Xamarin.Forms;
using zuzudemo.iOS.Services;
using zuzudemo.Services.Contracts;

[assembly: Dependency(typeof(HttpClientProvider))]
namespace zuzudemo.iOS.Services
{
    public class HttpClientProvider : IHttpClientProvider
    {
        public HttpClient GetClient()
        {
            var clientHandler = new HttpClientHandler();
            clientHandler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            var client = new HttpClient(clientHandler);
            return client;
        }
    }
}