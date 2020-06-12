using System;
using System.Collections.Generic;
using System.Text;

namespace CLL.Security.Identity
{
    public class Admin
        : User
    {
        public Admin(int userId, string name, string login, int password)
            : base(userId, name, nameof(Admin), password)
        {
        }
    }
}