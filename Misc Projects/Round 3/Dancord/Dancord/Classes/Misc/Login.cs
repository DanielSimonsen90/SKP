using Dancord.Classes.Base;
using Dancord.Classes.Users;
using System;

namespace Dancord.Classes
{
    class Login : IJSONID
    {
        private string Username { get; set; }
        private string Password { get; set; }
        public User User { get; }

        public Login(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.User = new User(username, LoginPage.NextID);
        }

        public bool CheckUsername(string username) => this.Username.ToLower() == username.ToLower();
        public bool CheckPassword(string password) => this.Password.ToLower() == password.ToLower();

        public string ToJSON() =>
            "{" +
                $"Username: {Username}" + 
                $"Password: {Password}" + 
                $"User: {User.ToJSON()}" +
            "}";
    }
}
