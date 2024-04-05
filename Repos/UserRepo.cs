using Microsoft.EntityFrameworkCore;
using SignalRwithEntityFramework.Models;

namespace SignalRwithEntityFramework.Repos
{
    public class UserRepo
    { 
        public UserRepo()
        { }

        public async Task<User> GetUserDetails(string username, string password)
        {
            var dbUsersMock = new List<User>()
            {
                new User
                {
                    Username = "User1",
                    Password = "1234"
                },
                new User
                {
                    Username = "User2",
                    Password = "1234"
                },
                new User
                {
                    Username = "User3",
                    Password = "1234"
                },
            };

            return dbUsersMock?.FirstOrDefault(user => user.Username == username && user.Password == password);
        }
    }
}
