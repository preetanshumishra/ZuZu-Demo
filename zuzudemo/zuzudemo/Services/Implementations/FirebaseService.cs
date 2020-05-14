using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using zuzudemo.Constants;
using zuzudemo.Models;
using zuzudemo.Services.Contracts;

namespace zuzudemo.Services.Implementations
{
    public class FirebaseService : IFirebaseService
    {
        public FirebaseService() { }

        public FirebaseClient firebase = new FirebaseClient(AppConstants.FirebaseUri);

        public async Task<List<UserModel>> GetAllUser()
        {
            try
            {
                var userlist = (await firebase
                .Child("Users")
                .OnceAsync<UserModel>()).Select(item =>
                new UserModel
                {
                    Email = item.Object.Email,
                    Password = item.Object.Password,
                    Location = item.Object.Location
                }).ToList();
                return userlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Read
        public async Task<UserModel> GetUser(string email)
        {
            try
            {
                var allUsers = await GetAllUser();
                await firebase
                .Child("Users")
                .OnceAsync<UserModel>();
                return allUsers.Where(a => a.Email == email).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Inser a user
        public async Task<bool> AddUser(string email, string password, string location)
        {
            try
            {
                await firebase
                .Child("Users")
                .PostAsync(new UserModel() { Email = email, Password = password, Location = location });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Update
        public async Task<bool> UpdateUser(string email, string password, string location)
        {
            try
            {
                var toUpdateUser = (await firebase
                .Child("Users")
                .OnceAsync<UserModel>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase
                .Child("Users")
                .Child(toUpdateUser.Key)
                .PutAsync(new UserModel() { Email = email, Password = password, Location = location });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Delete User
        public async Task<bool> DeleteUser(string email)
        {
            try
            {
                var toDeletePerson = (await firebase
                .Child("Users")
                .OnceAsync<UserModel>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase.Child("Users").Child(toDeletePerson.Key).DeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }
    }
}