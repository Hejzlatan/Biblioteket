using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    internal class UserSystem
    {
        private static UserSystem instance = null;
        private List<User> users = new List<User>();
        private string userFilePath = "../../../User.json"; // Namn och sökväg till filen där användare sparas som JSON

        private UserSystem()
        {
            LoadUsers();
        }

        public static UserSystem GetInstance()
        {
            if (instance == null)
            {
                instance = new UserSystem();
            }
            return instance;
        }

        public void Save()
        {
            // Skriva user listan till en user.json fil
            string usersJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(userFilePath, usersJson);
        }

        public void LoadUsers()
        {
            // Läsa av user.json filen till user listan
            if (File.Exists(userFilePath))
            {
                string usersJson = File.ReadAllText(userFilePath);
                users = JsonConvert.DeserializeObject<List<User>>(usersJson);
            }
        }

        public User CreateUser(string personalNumber, string password)
        {
            User user = new User() { PersonalNumber = personalNumber, Password = password };
            users.Add(user);
            Save();
            return user;
        }

        public User Login(string personalNumber, string password)
        {
            foreach (User user in users)
            {
                if (user.PersonalNumber == personalNumber && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }

        public void ChangePassword(User user, string oldPassword, string newPassword)
        {
            if (user.Password == oldPassword)
            {
                user.Password = newPassword;
                Save();
            }
        }
    }
}
