using System.Threading.Tasks;

namespace zuzudemo.Services.Contracts
{
    public interface IFirebaseAuthService
    {
        Task<string> LoginWithEmailPassword(string email, string password);
    }
}