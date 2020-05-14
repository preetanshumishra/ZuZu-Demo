using System.Collections.Generic;
using System.Threading.Tasks;
using zuzudemo.Models;

namespace zuzudemo.Services.Contracts
{
    public interface IFirebaseService
    {
        Task<List<UserModel>> GetAllUser();

        Task<UserModel> GetUser(string email);

        Task<bool> AddUser(string email, string password, string location);

        Task<bool> UpdateUser(string email, string password, string location);

        Task<bool> DeleteUser(string email);
    }
}