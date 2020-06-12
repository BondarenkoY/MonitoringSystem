using System;
using System.Collections.Generic;
using System.Text;

namespace CLL.Security.Identity
{
    public abstract class User
    {
        public User(int userId, string name, string login, int password)
        {
            UserID = userId;
            Name = name;
            Login = login;
            Password = password;
        }
        public int UserID { get; }
        public string Name { get; }
        protected string Login { get; }
        public int Password { get; }
    }
}