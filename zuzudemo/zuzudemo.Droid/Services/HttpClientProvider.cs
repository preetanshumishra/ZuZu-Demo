using System.Net;
using System.Net.Http;
using Xamarin.Android.Net;
using Xamarin.Forms;
using zuzudemo.Droid.Services;
using zuzudemo.Services.Contracts;

[assembly: Dependency(typeof(HttpClientProvider))]
namespace zuzudemo.Droid.Services
{
    public class HttpClientProvider : IHttpClientProvider
    {
        public HttpClient GetClient()
        {
            var clientHandler = new AndroidClientHandler();

            //Enable/Disable proxy based on QA setting flag
            //clientHandler.UseProxy = settingService.EnableWebProxy;
            //Bug: with AndroidClientHandler Timeout is not working https://bugzilla.xamarin.com/show_bug.cgi?id=44673
            //Bug: But using it fixes some more important bugs for us
            clientHandler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            var client = new HttpClient(clientHandler);
            return client;
        }
    }
}