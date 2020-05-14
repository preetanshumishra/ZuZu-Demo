using System.Threading.Tasks;
using Firebase.Auth;
using Xamarin.Forms;
using zuzudemo.iOS.Services;
using zuzudemo.Services.Contracts;

[assembly: Dependency(typeof(FirebaseAuthService))]
namespace zuzudemo.iOS.Services
{
    public class FirebaseAuthService : IFirebaseAuthService
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
            var token = await user.User.GetIdTokenAsync();
            return token;
        }
    }
}