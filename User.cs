using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp
{
    class User
    {
        public int Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User() { }
        public User(string login, string pass, string email)
        {
            this.Login = login;
            this.Email = email;
            this.Password = pass;
        }
        public override string ToString()
        {
            return $"Пользователь: [{Login}] | Email: {Email}";
        }
    }
}
