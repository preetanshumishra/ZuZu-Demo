using System.Threading.Tasks;
using Firebase.Auth;
using Xamarin.Forms;
using zuzudemo.Droid.Services;
using zuzudemo.Services.Contracts;

[assembly: Dependency(typeof(FirebaseAuthService))]
namespace zuzudemo.Droid.Services
{
    public class FirebaseAuthService : IFirebaseAuthService
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
            var token = await user.User.GetIdTokenAsync(false);
            return token.Token;
        }
    }
}